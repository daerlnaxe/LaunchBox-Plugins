using System;
using System.Collections.Generic;
using System.Linq;
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

namespace CleanImages.IHM
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class Duplicate_W : Window
    {
        const int valString = 100;

        public Duplicate_W()
        {
            InitializeComponent();
        }



        public void SetLeftImage(string image)
        {
            BitmapImage biImage = new BitmapImage(new Uri(image));


            LeftPic.Source = biImage;

            LeftImagePath.ToolTip = image;
            LeftImagePath.Text = SizeString(image);

            tbLeftDims.Text = $"{biImage.Width} x {biImage.Height}";
        }

        public void SetRightImage(string image)
        {
            RightPic.Source = new BitmapImage(new Uri(image));

            RightImagePath.ToolTip = image;
            RightImagePath.Text = SizeString(image);

        }

        private string SizeString(string value)
        {
            if (value.Length > valString) return "[...]" + value.Substring(value.Length - valString);

            return value;
        }

        private void Enlarge_Pic(object sender, RoutedEventArgs e)
        {

        }

        private void RightPic_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void Pic_Clicked(object sender, MouseButtonEventArgs e)
        {
            Image imgBox = (Image)sender;
            BigPic showBig = new BigPic();
            showBig.imageBox.Source = imgBox.Source;
            showBig.ShowDialog();
        }

        private void Label_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start(LeftImagePath.Text);
        }


    }
}
