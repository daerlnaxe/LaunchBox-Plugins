using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CCLaunchBox
{
    public partial class PlatformBandeau : UserControl
    {

        #region  Categorie
        public string CategValue
        {
            get { return lbCateg.Text; }
            set { lbCateg.Text = value; }
        }

        public int CategWidth
        {
            get { return lbCateg.Width; }
            set { lbCateg.Width = value; }
        }
        #endregion

        #region Paths
        /*public string Path1FullPath
        {
            get { return ucPaths1.FullPath; }
            set { ucPaths1.FullPath = value; }
        }

        public string Path1RelatPath
        {
            get { return ucPaths1.RelatPath; }
            set { ucPaths1.RelatPath = value; }
        }*/

        public UCPaths UCPath1
        {
            get { return ucPaths1; }
        }

        public UCPaths UCPath2
        {
            get { return ucPaths2; }
        }

        public int UCPath1Width { get; set; }
        public int UCPath2Width { get; set; }
        #endregion


        /// <summary>
        /// Color elements background
        /// </summary>
        public Color ElementsBgd//(Color couleur)
        {
            get { return lbCateg.BackColor; }
            set
            {
                this.lbCateg.BackColor = value;
                this.ucPaths1.BackColor = value;
                this.lbArrow.BackColor = value;
                this.ucPaths2.BackColor = value;
            }
        }

        /// <summary>
        /// Elements height
        /// </summary>
        public int ElementsHeight
        {
            get { return Height; }
            set
            {
                if (value < 60) throw new Exception("Bandeau: Hauteur inférieure à 60");

                this.lbCateg.AutoSize = false;
                this.lbArrow.AutoSize = false;

                this.lbCateg.Height = value;

                this.lbArrow.Height = value;

                this.ucPaths1.Height = value;
                this.ucPaths2.Height = value;

                this.flowLayoutPanel1.Height = value;
            }
        }



        public PlatformBandeau()
        {
            InitializeComponent();
        }

        private void OnSizeChanged(object sender, EventArgs e)
        {

            var newWidth = lbCateg.Margin.Left + lbCateg.Width + lbCateg.Margin.Right +
                            ucPaths1.Margin.Left + ucPaths1.Width + UCPath1.Margin.Right +
                            lbArrow.Margin.Left + lbArrow.Width + lbArrow.Margin.Right +
                            ucPaths2.Margin.Left + ucPaths2.Width + ucPaths2.Margin.Right;

            Console.WriteLine($"Modification taille, Nouvelle taille:{newWidth}");
            this.Size = new Size(newWidth, Height);
            flowLayoutPanel1.Size = Size;
        }
    }
}
