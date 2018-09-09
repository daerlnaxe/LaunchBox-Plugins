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
    /// Logique d'interaction pour Splash.xaml
    /// </summary>
    public partial class Splash : Window
    {
        private static Splash _SplashWdw;


        public Splash()
        {
            InitializeComponent();
        }


        public static void Pop(int max)
        {
            _SplashWdw = new Splash();
            _SplashWdw.progressBar.Maximum = max;
            _SplashWdw.Show();
        }

        public static void CloseIt()
        {
            _SplashWdw.Close();
        }

        public static double ProgressStatus
        {
            get { return _SplashWdw.progressBar.Value; }
            set
            {
                _SplashWdw.progressBar.Value = value;
            }
        }
    }
}
