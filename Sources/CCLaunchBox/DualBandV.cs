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
    public partial class DualBandV : UserControl
    {
        public string Title
        {
            get { return lbTitle.Text; }
            set{ lbTitle.Text = value; }
        }

        public DualBandV()
        {
            InitializeComponent();
        }

        private void DualBandV_Load(object sender, EventArgs e)
        {

        }


        public Color ElementsBgd
        {
            get { return this.lbTitle.BackColor; }
            set
            {
                lbTitle.BackColor = value;
                pictureBox1.BackColor = value;
                ucPaths21.BackColor = value;
                ucPaths22.BackColor = value;                
                
                
                tableLayoutPanel1.BackColor = value;
            }
        }
    }
}
