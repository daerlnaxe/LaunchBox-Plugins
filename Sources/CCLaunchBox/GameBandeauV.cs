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

    public partial class GameBandeauV : UserControl
    {
        public delegate void DeroulHandler(GameBandeauV sender);
        public event DeroulHandler DeroulBand;
        public event DeroulHandler EnroulBand;
        
        public object Objet { get; set; }

        public int BandRef { get; set; }


        bool Deroul;

        public GameBandeauV()
        {
            InitializeComponent();
            this.flp1.Controls.Clear();
            Collapse_Fl();

            // this.Height = lbTitle.Height + pictureBox1.Height;

        }

        private void GameBandeauV_Load(object sender, EventArgs e)
        {

        }

        public void ShowVerif(bool valide)
        {
            if (valide)
            {
                picCheck.BackgroundImage = Properties.Resources.check_256_282474;
                BackColor = Color.LawnGreen;
            }
            else
            {
                BackColor = Color.Crimson;
                picCheck.BackgroundImage = Properties.Resources.cross_256_282471;

            }
        }


        #region  Categorie
        //public string CategValue
        //{
        //    get { return lbCateg.Text; }
        //    set { lbCateg.Text = value; }
        //}

        //public int CategWidth
        //{
        //    get { return lbCateg.Width; }
        //    set { lbCateg.Width = value; }
        //}
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

        //public UCPaths UCPath1
        //{
        //    get { return ucPaths1; }
        //}

        //public UCPaths UCPath2
        //{
        //    get { return ucPaths2; }
        //}

        public int UCPath1Width { get; set; }
        public int UCPath2Width { get; set; }
        #endregion
        

        /// <summary>
        /// Titre du bandeau
        /// </summary>
        public string Title
        {
            get { return this.lbTitle.Text; }
            set { this.lbTitle.Text = value; }
        }

        ///// <summary>
        ///// Color elements background
        ///// </summary>
        //public Color ElementsBgd//(Color couleur)
        //{
        //    get { return lbCateg.BackColor; }
        //    set
        //    {
        //        this.lbCateg.BackColor = value;
        //        this.ucPaths1.BackColor = value;
        //        this.lbArrow.BackColor = value;
        //        this.ucPaths2.BackColor = value;
        //    }
        //}

        ///// <summary>
        ///// Elements height
        ///// </summary>
        //public int ElementsHeight
        //{
        //    get { return Height; }
        //    set
        //    {
        //        //  if (value < 60) throw new Exception("Bandeau: Hauteur inférieure à 60");

        //        this.lbCateg.AutoSize = false;
        //        this.lbArrow.AutoSize = false;

        //        this.lbCateg.Height = value;

        //        this.lbArrow.Height = value;

        //        this.ucPaths1.Height = value;
        //        this.ucPaths2.Height = value;

        //        //this.flowLayoutPanel1.Height = value;


        //    }
        //}

        //private void tableLayoutPanel1_SizeChanged(object sender, EventArgs e)
        //{
        //    var newWidth = lbCateg.Margin.Left + lbCateg.Width + lbCateg.Margin.Right +
        //        ucPaths1.Margin.Left + ucPaths1.Width + ucPaths1.Margin.Right +
        //        lbArrow.Margin.Left + lbArrow.Width + lbArrow.Margin.Right +
        //        ucPaths2.Margin.Left + ucPaths2.Width + ucPaths2.Margin.Right;

        //    Console.WriteLine($"Modification taille, Nouvelle taille:{newWidth}");
        //    this.Size = new Size(newWidth, Height);
        //    //tableLayoutPanel1.Size = Size;
        //}
        /*
        public int nHeight
        {
            get { return this.Height; }
            set
            {
                this.Height = this.Margin.Top + this.Margin.Bottom + lbTitle.Height + pictureBox1.Height +
                    +value;
            }
        }
        */


        #region agrandissement bandeau

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (!Deroul)
            {
                Grow_FL();
            }
            else
            {
                Collapse_Fl();
            }
        }

        private void tableLayoutPanel1_MouseLeave(object sender, EventArgs e)
        {
            //  Collapse_Fl();
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            Console.WriteLine($"Panneau activé: {Deroul}");

        }
        
        /// <summary>
        /// Agrandit le bandeau
        /// </summary>
        private void Grow_FL()
        {
            Console.WriteLine("Panneau activé");
            Deroul = true;
            flp1.Visible = true;

            DeroulBand?.Invoke(this);
            pictureBox1.Cursor = Cursors.PanNorth;

            //Width = Width > (flp1.Width + 50) ? Width : flp1.Width + 50;
          //  tlpMain.Width = Width;
            this.Height = tlpMain.Height;
        }

        /// <summary>
        /// Réduit le bandeau
        /// </summary>
        public void Collapse_Fl()
        {
            //this.Height = lbTitle.Height + pictureBox1.Height+20;
            flp1.Visible = false;
            Console.WriteLine("Panneau désactivé");
            Deroul = false;
            pictureBox1.Cursor = Cursors.PanSouth;
            EnroulBand?.Invoke(this);
            this.Height = lbTitle.Height + pictureBox1.Height;
            this.Width = tlpMain.Width;
        }
        #endregion
        
        #region Width
        public void Resize_Me()
        {
            if (Width > tlpMain.Width)
            {
                tlpMain.Width = Width;
            }
            else
            {
                Width = tlpMain.Width;
            }
        }
        #endregion


        //public int Tlp_Height
        //{
        //    get { return tableLayoutPanel1.Height;}
        //    set
        //    {
        //        tableLayoutPanel1.Height = value;

        //        this.lbCateg.Height = value - lbTitle.Height - pictureBox1.Height;

        //        this.lbArrow.Height = value- lbTitle.Height - pictureBox1.Height;

        //        this.ucPaths1.Height = value - lbTitle.Height - pictureBox1.Height;
        //        this.ucPaths2.Height = value - lbTitle.Height - pictureBox1.Height;
        //    }
        //}
    }

}
