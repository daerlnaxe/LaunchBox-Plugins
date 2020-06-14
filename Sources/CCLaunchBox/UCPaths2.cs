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
    public partial class UCPaths2 : UserControl
    {
        public string FullPath
        {
            get { return this.tbHardPath.Text; }
            set { this.tbHardPath.Text = value; }
        }

        [Description("TopTextbox Font"), Category("Police")]
        public Font TopFont
        {
            get { return this.tbHardPath.Font; }
            set { this.tbHardPath.Font = value; }
        }

        [Description("BottomLabel Font"), Category("Police")]
        public Font BottomFont
        {
            get { return this.lbRelatPath.Font; }
            set { this.lbRelatPath.Font = value; }
        }




        public int TableWidth
        {
            get { return tableLP.Size.Width; }
            set { tableLP.Size = new Size(value, tableLP.Height); }
        }

        public string RelatPath
        {
            get { return this.lbRelatPath.Text; }
            set { this.lbRelatPath.Text = value; }
        }




        //public Font GetHardFont
        //{
        //    get{ return tbHardPath.Font; }
        //}

        //public Font GetRelatFont
        //{
        //    get { return lbRelatPath.Font;}
        //}

        public UCPaths2()
        {
            InitializeComponent();
        }

        private void tbHardPath_TextChanged(object sender, EventArgs e)
        {

        }

        private void UCPaths_Load(object sender, EventArgs e)
        {



        }

        private void lbRelatPath_Click(object sender, EventArgs e)
        {

        }
    }
}
