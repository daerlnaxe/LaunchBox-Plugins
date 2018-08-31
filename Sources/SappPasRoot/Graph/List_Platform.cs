using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unbroken.LaunchBox.Plugins;
using Unbroken.LaunchBox.Plugins.Data;

namespace SappPasRoot.Graph
{
    public partial class List_Platform : Form
    {
        // LaunchBox refuse two platforms with same name (to watching)
        private Dictionary<string, IPlatform> dicPlatforms = new Dictionary<string, IPlatform>();


        public List_Platform()
        {
            InitializeComponent();
            PluginHelper.LaunchBoxMainForm.FormClosing += new FormClosingEventHandler(Fermeture);
            
            this.Text += $" {Assembly.GetAssembly(typeof(Main)).GetName().Version.ToString()}";


            ListPlatform();
        }

        private void Fermeture(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }

        private void ListPlatform()
        {

            IPlatform[] platforms = PluginHelper.DataManager.GetAllPlatforms();

            foreach (var platform in platforms)
            {
                //MessageBox.Show(platform.Name);
                ListViewItem lvi = new ListViewItem(platform.Name);
                lvi.SubItems.Add(platform.Folder);
                lvPlatforms.Items.Add(lvi);

                dicPlatforms.Add(platform.Name, platform);
            }

            lvPlatforms.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

        }

        private void lvPlatforms_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            CPlatformPaths cp = new CPlatformPaths();
            //MessageBox.Show($"plat {lvPlatforms.SelectedItems[0].Text}");
            cp.Platform = lvPlatforms.SelectedItems[0].Text;
            cp.Initialization();

            this.Hide();
            cp.ShowDialog();
            this.Show();
        }

        private void lvPlatforms_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            string platSel = lvPlatforms.SelectedItems[0].Text;


            CGamesPaths tcpj = new CGamesPaths();
            tcpj.Initialization(dicPlatforms[platSel]);
            tcpj.ShowDialog();
        }
    }
}
