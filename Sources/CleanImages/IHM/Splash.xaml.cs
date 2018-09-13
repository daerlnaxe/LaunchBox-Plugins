using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
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
        #region to mask close button
        private const int GWL_STYLE = -16;
        private const int WS_SYSMENU = 0x80000;
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        #endregion

        private static Splash _SplashWdw;
        public int pMaximum { get; set; }
        public double pValue { get; set; }
        public int pMinimum { get; set; }
        public string CurrentFile { get; set; }

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

        /// <summary>
        /// Update progress for static mode
        /// </summary>
        public static double ProgressStatus
        {
            get { return _SplashWdw.pValue; }
            set { _SplashWdw.pValue = value;}
        }

        public static string FileStatus
        {
            get { return _SplashWdw.CurrentFile; }
            set { _SplashWdw.CurrentFile = value; }
        }

        private void progressBar_Loaded(object sender, RoutedEventArgs e)
        {
            var hwnd = new WindowInteropHelper(this).Handle;
            SetWindowLong(hwnd, GWL_STYLE, GetWindowLong(hwnd, GWL_STYLE) & ~WS_SYSMENU);
        }
    }
}
