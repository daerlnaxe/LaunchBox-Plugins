using DxTBoxWPF.Languages;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DxTBoxWPF.Cont;
using DxTBoxWPF.Common;
using DxTBoxWPF.MBox;
using DxTBoxWPF.Images;
using Unbroken.LaunchBox.Plugins.Data;
using DxTrace;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Unbroken.LaunchBox.Plugins;
using ManageImages.Cont;
using Unbroken.LaunchBox.Data;
using Path = System.IO.Path;

namespace ManageImages.IHM
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class Manage_W : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public IGame GameSelected { get; set; }
        public ObservableCollection<ExtImageDetails> CollecImages { get; set; } = new ObservableCollection<ExtImageDetails>();
        public ObservableCollection<ExtPlatformFolder> CollecPlatformsFolders { get; set; } = new ObservableCollection<ExtPlatformFolder>();
        public ObservableCollection<RegionElem> CollecRegions { get; set; } = new ObservableCollection<RegionElem>();

        /* public bool NameWithID { get; set; } = Properties.Settings.Default.bNameWithID;
         public bool NameWithoutID { get; set; } = Properties.Settings.Default.bNameWithoutID;*/

        public ExtImageDetails _CurrentImage { get; set; }
        public ExtImageDetails CurrentImage
        {
            get { return _CurrentImage; }
            set
            {
                ITrace.WriteLine("Current Image appel");
                _CurrentImage = value;
                if (PropertyChanged != null) PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CurrentImage"));
            }
        }



        //public IPlatformFolder[] LPlatformFolders { get; set; }

        private string DllLocation;
        private int _ImagePos;
        public int ImagePosition
        {
            get { return _ImagePos; }
            set
            {
                _ImagePos = value;
                if (PropertyChanged != null) PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ImagePosition"));
            }
        }

        //??
        const int valString = 100;

        /// <summary>
        /// Liste des images à trier
        /// </summary>
        //public List<string> ListImages { get; set; } = new List<string>();


        public Manage_W()
        {
            InitializeComponent();
            DllLocation = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (GameSelected == null) throw new Exception("GameSelected is null !");
            this.DataContext = this;
            Init();

            var test = PluginHelper.DataManager.GetAllPlatformCategories();
            foreach (var cat in test)
            {
                ITrace.WriteLine(cat.Name);
            }
        }

        private void Init()
        {

            string platform = GameSelected.Platform;
            var oPlatform = PluginHelper.DataManager.GetPlatformByName(platform);

            Rewind.IsEnabled = false;

            try
            {
                //CollecImages = new ObservableCollection<ExtImageDetails>(images);
                ImageDetails[] images = GameSelected.GetAllImagesWithDetails();
                images.ToList().ForEach(x => CollecImages.Add(new ExtImageDetails(x)));
                ITrace.WriteLine($"{CollecImages.Count} trouvées pour ce jeu");

                // platform folders
                IPlatformFolder[] arrIPF = oPlatform.GetAllPlatformFolders();
                foreach (IPlatformFolder ipf in arrIPF)
                {
                    switch (ipf.MediaType)
                    {
                        case "Theme Video":
                        case "Manual":
                        case "Music":
                        case "Video":
                            break;

                        default:
                            ExtPlatformFolder epf = new ExtPlatformFolder(ipf);
                            CollecPlatformsFolders.Add(epf);
                            break;
                    }
                }
                // Regions
                string[] regions = Properties.Settings.Default.Regions.Split(',');
                foreach (string region in regions)
                {                  
                    var tmp = new RegionElem(region.Trim(), false);
                    CollecRegions.Add(tmp);
                }


                ImagePosition = 1;
                SetLeftImage(CollecImages[0]);

            }
            catch (Exception exc)
            {
                ITrace.WriteLine(exc.ToString());
            }
        }

        /// <summary>
        /// Set Main title on the top of window
        /// </summary>
        /// <param name="title"></param>
        public void SetMainTitle(string title)
        {
            tbTitre.Text = title;
        }

        public void SetHash(string hash)
        {
            tbHash.Text = hash;
        }

        /// <summary>
        /// Set image, path, resolution to left side
        /// </summary>
        /// <param name="img"></param>
        public void SetLeftImage(ExtImageDetails img)
        {
            BitmapImage biImage = new BitmapImage();
            // Obligatoire pour pouvoir effacer ensuite
            biImage.BeginInit();
            biImage.CacheOption = BitmapCacheOption.OnLoad;
            biImage.UriSource = new Uri(img.FilePath);
            biImage.EndInit();
            LeftPic.Source = biImage;
            tbLeftDims.Text = $"{biImage.PixelWidth} x {biImage.PixelHeight}";
            //

            CurrentImage = img;
            // tbImagePath.Text = img.FilePath;
            // tbImageName.Text = System.IO.Path.GetFileName(img.FilePath);
            // tbMediaType.Text = img.ImageType;
            // tbRegion.Text = img.Region;

            SetActiveItem(img.ImageType);
            ITrace.WriteLine($"Set Left: Image mediatype vaut {img.ImageType}");
            SetActiveRegion(img.Region);

            /*foreach (ExtPlatformFolder epf in CollecPlatformsFolders)
            {
                if (img.ImageType.Equals(epf.MediaType))
                {
                    ITrace.WriteLine($"Set Left correspond à {epf.MediaType}");
                    epf.Checked = true;
                }
                else
                {
                    epf.Checked = false;
                }
            }*/
        }

        private void SetActiveRegion(string region)
        {
            ITrace.WriteLine($"Region cherchée '{region}'");
            foreach(RegionElem regionelem in CollecRegions)
            {
                ITrace.WriteLine($"Region testée '{regionelem.Name}'");

                if (regionelem.Name == region)
                {
                    ITrace.WriteLine($"Region trouvée {regionelem.Name}");
                    regionelem.IsChecked = true;
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private ExtPlatformFolder SetActiveItem(string value)
        {
            ExtPlatformFolder epfFound = null;

            foreach (ExtPlatformFolder epf in CollecPlatformsFolders)
            {
                if (value.Equals(epf.MediaType))
                {
                    ITrace.WriteLine($"Set Left correspond à {epf.MediaType}");
                    epf.Checked = true;
                    epfFound = epf;
                }
                else
                {
                    epf.Checked = false;
                }
            }
            return epfFound;
        }



        /// <summary>
        /// Set image, path, resolution to right side
        /// </summary>
        /// <param name="img"></param>
        /*
        public void SetRightImage(DxImage img)
        {

            BitmapImage biImage = new BitmapImage();
            // Obligatoire pour pouvoir effacer ensuite
            biImage.BeginInit();
            biImage.CacheOption = BitmapCacheOption.OnLoad;
            biImage.UriSource = new Uri(img.FullPath);
            biImage.EndInit();
            //

            //BitmapImage biImage = new BitmapImage(new Uri(imgLink));
            RightPic.Source = biImage;

            //tbRightImagePath.ToolTip = img;
            tbImagePath.Text = SizeString(img.FullPath);

            tbRightTitle.Text = img.Title;
            tbRightDims.Text = $"{biImage.PixelWidth} x {biImage.PixelHeight}";
        }*/

        /// <summary>
        /// Resize string to fit
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private string SizeString(string value)
        {
            if (value.Length > valString) return "[...]" + value.Substring(value.Length - valString);

            return value;
        }

        /// <summary>
        /// Click on a pic
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pic_Clicked(object sender, MouseButtonEventArgs e)
        {
            Image imgBox = (Image)sender;
            BigPic showBig = new BigPic();
            showBig.ImageLink = imgBox.Source;
            showBig.ShowDialog();
        }

        /// <summary>
        /// External Launch left image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LeftLab_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //////////////////////////////////// Process.Start(tbLeftImagePath.Text);
        }

        /// <summary>
        /// External Launch right image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RightLab_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Process.Start(tbImagePath.Text);
        }

        /*
        private void LeftTrash2_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (QImages.Count > 1)
            {
                QImages.Enqueue(sLeftPic);
                sLeftPic = QImages.Dequeue();
                SetLeftImage(sLeftPic);
                //    if (tmp == sLeftPic || tmp == sRightPic) tmp
            }
        }*/

        /// <summary>
        /// Left Forward
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Forward_Click(object sender, RoutedEventArgs e)
        {
            ImagePosition++;
            ITrace.WriteLine($"imageactu: {ImagePosition}");
            SetLeftImage(CollecImages[ImagePosition - 1]);

            if (ImagePosition >= CollecImages.Count())
            {
                Forward.IsEnabled = false;
            }


            if (ImagePosition > 1) Rewind.IsEnabled = true;
        }

        /// <summary>
        /// Right Forward
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rewind_Click(object sender, RoutedEventArgs e)
        {
            ImagePosition--;
            ITrace.WriteLine($"imageactu: {ImagePosition}");
            SetLeftImage(CollecImages[ImagePosition - 1]);

            if (ImagePosition <= 1)
            {
                Rewind.IsEnabled = false;
            }

            if (ImagePosition < CollecImages.Count)
            {
                Forward.IsEnabled = true;
            }

        }

        /// <summary>
        /// Delete left file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LeftTrash_Click(object sender, RoutedEventArgs e)
        {
            /*
            DeleteFile(iLeftPic.FullPath);
            
            if (QImages.Count > 0)
            {
                iLeftPic = QImages.Dequeue();
                SetLeftImage(iLeftPic);
            }
            else
            {
                LeftPic.Source = new BitmapImage(new Uri(@"/DxTBoxWPF;component/Resources/no-photo.png", UriKind.Relative));
                iLeftPic = null;

                tbLeftTitle.Text = tbImagePath.Text = "No More Pics";
                tbLeftDims.Text = "";

                Forward.IsEnabled = false;
                RightForward.IsEnabled = false;
                LeftTrash.IsEnabled = false;
            }*/
        }

        /// <summary>
        /// Delete right file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RightTrash_Click(object sender, RoutedEventArgs e)
        {
            /*
            DeleteFile(iRightPic.FullPath);

            if (QImages.Count > 0)
            {
                iRightPic = QImages.Dequeue();
                SetRightImage(iRightPic);
            }
            else
            {
                this.RightPic.Source = new BitmapImage(new Uri(@"/DxTBoxWPF;component/Resources/no-photo.png", UriKind.Relative));
                iRightPic = null;

                tbRightTitle.Text =/*tbRightImagePath.Text=*/ /*"No More Pics";
                tbRightDims.Text = "";
                
                Forward.IsEnabled = false;
                RightForward.IsEnabled = false;
                RightTrash.IsEnabled = false;

            }
        */
        }

        /// <summary>
        /// Delete function
        /// </summary>
        /// <param name="toDel"></param>
        private void DeleteFile(string toDel)
        {
            bool? res = DxMBox.ShowDial(Lang.Trash_Question + $"\n{toDel}", Lang.Trash_FileTitle, DxButtons.YesNo);
            if (res == true)
            {
                try
                {
                    FileSystem.DeleteFile(toDel, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc);
                }
            }
        }

        /// <summary>
        /// Button to leave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtLeave_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Fin de duplicate");
            DialogResult = true;
            this.Close();
        }

        private void StopAll_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Arrêt total demandé");
            DialogResult = false;
            this.Close();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem itm = (MenuItem)sender;
            string vImgName;
            string filepath;

            string imagetype = itm.Header.ToString();

            if (imagetype.Equals(CurrentImage.ImageType))
            {
                itm.IsChecked = true;
                return;
            }

            ITrace.WriteLine("Source: " + itm.Header);
            ExtPlatformFolder catPath = SetActiveItem(imagetype);

            // With or without id game
            vImgName = Properties.Settings.Default.bNameWithID ?
                vImgName = $"{GameSelected.Title}.{GameSelected.Id}" :
                vImgName = $"{GameSelected.Title}";

            string extension = Path.GetExtension(CurrentImage.FilePath);


            int i = 1;
            do
            {
                string imgName = vImgName + String.Format("-{0:00}", i) + extension;


                // Region or not
                filepath = CurrentImage.Region != null ?
                    filepath = Path.Combine(catPath.FolderPath, CurrentImage.Region, imgName) :
                    filepath = Path.Combine(catPath.FolderPath, imgName);


                ITrace.WriteLine($"Future chaine = {filepath}");

            } while (File.Exists(filepath));


            // string filepath = System.IO.Path.Combine(catPath.FolderPath, System.IO.Path.GetFileName(CurrentImage.FilePath));

            File.Move(CurrentImage.FilePath, filepath);


            //CurrentImage = new ImageDetails(filepath, imagetype, CurrentImage.Region);
            CurrentImage.FilePath = filepath;
            CurrentImage.ImageType = imagetype;


        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            MenuItem itemChecked = (MenuItem)sender;
            MenuItem itemParent = (MenuItem)itemChecked.Parent;

            foreach (MenuItem item in itemParent.Items)
            {
                if (item == itemChecked)
                {
                    ITrace.WriteLine("MI_Click exception");
                    continue;
                }
                item.IsChecked = false;
            }
        }



        private void Window_Closing(object sender, CancelEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Regions += $", {NewRegion.Text}";
            Properties.Settings.Default.Save();
            NewRegion.Text = "";
        }
    }


}
