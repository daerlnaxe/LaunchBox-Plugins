using CCLaunchBox;
using SappPasRoot.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unbroken.LaunchBox.Plugins;
using Unbroken.LaunchBox.Plugins.Data;

namespace SappPasRoot.Graph
{
    public partial class CGamesPaths : Form
    {
        public string PlatformName { get; set; }

        /// <summary>
        ///  Dossier de l'application - Utile au debugmode qui peut forcer du coup
        /// </summary>
        private string AppPath;
        private string _PlatformFolderRL;
        private string _PlatformFolderHL;

        /// <summary>
        /// Liste originale desjeux
        /// </summary>
        private IGame[] IPGames;


        /// <summary>
        /// Copie de la plateforme
        /// </summary>
        private IPlatform _PlatformObject;
        //private List<PlatformBandeau> lBandeaux = new List<PlatformBandeau>();

        /// <summary>
        /// Pseudo colonnes
        /// </summary>
        private Dictionary<string, int> _Cols { get; set; }


        // Largeur du flowlayout principal
        private int ContWidth;
        // hauteur du bandeau et des éléments
        private int BandHeight;
        private Font bRelatFont = new Font(FontFamily.GenericSansSerif, 10F, FontStyle.Bold);
        private Font bHardFont = new Font(FontFamily.GenericSansSerif, 7F);


        private bool DebugMode;

        public CGamesPaths()
        {
            InitializeComponent();
            listView1.Items.Clear();
        }


        private void CGamesPaths_Load(object sender, EventArgs e)
        {
            //GrabMyShovel();
        }

        internal void Initialization(IPlatform platform)
        {
            PluginHelper.LaunchBoxMainForm.FormClosing += LaunchBoxMainForm_FormClosing;

            boxLog.Text = boxLog.Text.Insert(0, $@"Initialization" + Environment.NewLine);

            _PlatformObject = platform;
            boxLog.Text = boxLog.Text.Insert(0, $@"Platform '{_PlatformObject.Name}' selected" + Environment.NewLine);

            _PlatformFolderRL = _PlatformObject.Folder;
            _PlatformFolderHL = Path.GetFullPath(Path.Combine(AppPath, _PlatformFolderRL));

            // Application folder
            AppPath = AppDomain.CurrentDomain.BaseDirectory;

            IPGames = _PlatformObject.GetAllGames(true, true)//(false, false)
                                    .OrderBy(x => x.Title).ToArray();

        }


        public void DebugTest(IGame[] fakelist)
        {
            DebugMode = true;
            AppPath = @"I:\Frontend\LaunchBox\";
            IPGames = fakelist;
            _PlatformFolderRL = @".\Roms\Sega Mega Drive";
            _PlatformFolderHL = Path.GetFullPath(Path.Combine(AppPath, _PlatformFolderRL));
        }

        /// <summary>
        /// 
        /// </summary>
        private void GrabMyShovel()
        {
            FillInformation();

            // Assignation du dernier chemin visité
            if (string.IsNullOrEmpty(Properties.Settings.Default.LastKPath))
            {
                Properties.Settings.Default.LastKPath = _PlatformFolderHL;
            }


            // Conversion to MvGame
            var aMvGames = MvGame.Convert(IPGames, AppPath);

            //AnalyseProps(aMvGames);

            BackgroundWorker bGroundwker = new BackgroundWorker();
            bGroundwker.DoWork += new DoWorkEventHandler(bw_Work1);
            bGroundwker.ProgressChanged += new ProgressChangedEventHandler(bgw1_ProgressChanged);
            //bGroundwker.RunWorkerAsync(aMvGames);

            GenerateInfoPath(aMvGames);


            StyleMainFLP();
            SetMainWindow();
        }

        private void bgw1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //   throw new NotImplementedException();
        }

        /// <summary>
        /// Travail en background à faire
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bw_Work1(object sender, DoWorkEventArgs e)
        {
            MvGame[] aMvGames = (MvGame[])e.Argument;
            GenerateInfoPath(aMvGames);
        }

        private void GenerateInfoPath(MvGame[] aMvGames)
        {
            try
            {
                boxLog.Text = boxLog.Text.Insert(0, @"Creation of data graphic forms" + Environment.NewLine);
                flpPaths.Controls.Clear();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            foreach (var mvGame in aMvGames)
            {
                toolStripStatusLabel1.Text = $"Création of bandeau: {mvGame.Title}";

                Console.WriteLine(mvGame.Title);

                GameBandeau bdTmp = StyleBandeaux(mvGame.Id);
                bdTmp.Title += $" {mvGame.Title}";
                //////bdTmp.UCPath1.RelatPath = mvGame.ApplicationPath.Original_RLink;
                //////bdTmp.UCPath1.FullPath = mvGame.ApplicationPath.Original_HLink;

                //////bdTmp.UCPath2.RelatPath = mvGame.ApplicationPath.Destination_RLink;
                //////bdTmp.UCPath2.FullPath = mvGame.ApplicationPath.Destination_HLink;

                flpPaths.Controls.Add(bdTmp);
                flpPaths.Refresh();
                //lBandeaux.Add(bdTmp);
            }
        }

        private void FillInformation()
        {
            boxLog.Text = boxLog.Text.Insert(0, @"Filling of information fields" + Environment.NewLine);
            boxLog.Text = boxLog.Text.Insert(0, @"Transformation RelatLink To HardLink " + Environment.NewLine); ;

            //boxLog.Text = boxLog.Text.Insert(0, $@"PlatformFolder: {PlatformFolder}" + Environment.NewLine); ;

            // conversion en dur du lien vers le dossier actuel           
            /*_CRelatLink = PlatformFolder.Replace($@"\{Platform}", "");
            _CRelatLink = _CRelatLink.Substring(0, _CRelatLink.LastIndexOf('\\'));
            _CHardLink = Path.GetFullPath(Path.Combine(AppPath, _CRelatLink));

            _NewRoot = _CHardLink;

            this.tboxROldPath.Text = _CRelatLink;
            this.tboxHOldPath.Text = tbMainPath.Text = _CHardLink;*/

            this.labPName.Text = PlatformName;
            this.tboxROldPath.Text = _PlatformFolderRL;
            this.tboxHOldPath.Text = _PlatformFolderHL;
        }

        /// <summary>
        /// Analyse les propriétés de tout le tableau pour calculer la taille des colonnes
        /// </summary>
        /// <param name="games"></param>
        private void AnalyseProps(MvGame[] games)
        {
            boxLog.Text = boxLog.Text.Insert(0, @"Analysis of columns width" + Environment.NewLine); ;

            _Cols = new Dictionary<string, int>();
            _Cols.Add("Arrow", 20);
            // Name of the Media
            //PropertyInfo propMedia = typeof(MvFolder).GetProperty("MediaType");
            _Cols.Add("MediaType", Analyse.Rows(x => x.ApplicationPath.Type, games, new Label().Font).Width);

            // OldPath            
            Size sORelat = Analyse.Rows<MvGame>(x => x.ApplicationPath.Original_RLink, games, bRelatFont);
            Size sOHard = Analyse.Rows(x => x.ApplicationPath.Original_HLink, games, bHardFont);

            _Cols.Add("UCP1", sOHard.Width > sORelat.Width ? sOHard.Width : sORelat.Width);

            // NewPath
            Size sNRelat = Analyse.Rows<MvGame>(x => x.ApplicationPath.Destination_RLink, games, bRelatFont);
            Size sNHard = Analyse.Rows(x => x.ApplicationPath.Destination_HLink, games, bHardFont);


            _Cols.Add("UCP2", sNHard.Width > sNRelat.Width ? sNHard.Width : sNRelat.Width);
        }

        private void LaunchBoxMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }


        private GameBandeau StyleBandeaux(string titre)
        {
            int rightSpace = 10;

            GameBandeau bdTmp = new GameBandeau();
            bdTmp.Name = titre; 
            //////bdTmp.CategValue = MediaType;

            //////bdTmp.ElementsBgd = Color.White;
            bdTmp.Height = BandHeight = 54;
            bdTmp.DeroulBand += new GameBandeau.DeroulHandler( FillBand);
            //////bdTmp.Tlp_Height = 0;
            // bdTmp.BackColor = Color.FromArgb(0);

            ////////bdTmp.CategWidth = _Cols["MediaType"] + rightSpace;

            ////////bdTmp.UCPath1.TopFont = bHardFont;
            ////////bdTmp.UCPath1.BottomFont = bRelatFont;
            ////////bdTmp.UCPath1.Width = _Cols["UCP1"] + rightSpace;

            ////////bdTmp.UCPath2.TopFont = bHardFont;
            ////////bdTmp.UCPath2.BottomFont = bRelatFont;
            ////////bdTmp.UCPath2.Width = _Cols["UCP2"] + rightSpace;

            return bdTmp;
        }

        private void FillBand(GameBandeau sender)
        {
            Console.WriteLine($"Bandactif: {sender.Name}");
        }

        private void ResizeTextBox(object sender, EventArgs e)
        {
            GraphFunc.ResizeTextBox(sender);
        }


        /// <summary>
        /// Makes fake list code for debugtest
        /// </summary>
        private void FakeGenerator()
        {
            foreach (var rameuh in IPGames)
            {
                var titlemod = rameuh.Title.Replace(' ', '_');
                titlemod = rameuh.Title.Replace('&', 'e');
                boxLog.Text += $"MvGame {titlemod} = new MvGame();" + Environment.NewLine;
                boxLog.Text += $"{titlemod}.Title= \"{rameuh.Title}\";" + Environment.NewLine;
                boxLog.Text += $"{ titlemod}.ApplicationPath= @\"{rameuh.ApplicationPath}\";" + Environment.NewLine + Environment.NewLine;
            }
        }

        private void CGamesPaths_Shown(object sender, EventArgs e)
        {
            GrabMyShovel();
        }



        private void StyleMainFLP()
        {
            boxLog.Text = boxLog.Text.Insert(0, @"Adaptation of layout background " + Environment.NewLine); ;

            flpPaths.BackColor = Color.FromArgb(141, 177, 227);
            ContWidth = flpPaths.Controls[0].Width; // lBandeaux[0].Width;
            if (flpPaths.VerticalScroll.Enabled) ContWidth += 22;

            //_Cols.Sum(x => x.Value);
            // Height size of each item
            int minheightB = (BandHeight + 6) * 6;
            int minH = Screen.PrimaryScreen.Bounds.Height < minheightB ? Screen.PrimaryScreen.Bounds.Height : minheightB;

            flpPaths.Size = flpPaths.MinimumSize = new Size(ContWidth + 6, minH);

            //this.flpPaths.MaximumSize = new Size(ContWidth + 6, maxH);
            //flpPaths.MinimumSize = new Size(ContWidth +6, flpPaths.Height);
        }

        private void SetMainWindow()
        {
            boxLog.Text = boxLog.Text.Insert(0, @"Adaptation of window " + Environment.NewLine); ;
            int largr = flpPaths.Width + 40;
            int hautr = flpPaths.Height + boxLog.Height + tlpInfos.Height + 100;

            // Mainwindow size + Block according to primary screen
            largr = Screen.PrimaryScreen.Bounds.Width > largr ? largr : Screen.PrimaryScreen.Bounds.Width;
            hautr = Screen.PrimaryScreen.Bounds.Height > hautr ? hautr : Screen.PrimaryScreen.Bounds.Height;

            Size = new Size(largr, hautr);

            boxLog.Width = flpPaths.Width;
            panelTop.Width = flpPaths.Width;
        }
    }
}
