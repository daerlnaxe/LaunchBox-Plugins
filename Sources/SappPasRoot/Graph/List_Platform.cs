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

namespace SappPasRoot.Graph
{
    public partial class List_Platform : Form
    {
        public List_Platform()
        {
            InitializeComponent();
            this.Text += $" {Assembly.GetAssembly(typeof(Main)).GetName().Version.ToString()}";
            ListPlatform();
            PluginHelper.LaunchBoxMainForm.FormClosing += new FormClosingEventHandler(Fermeture);
        }

        private void Fermeture(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }

        private void ListPlatform()
        {

            var platforms = PluginHelper.DataManager.GetAllPlatforms();

            foreach (var platform in platforms)
            {
                //MessageBox.Show(platform.Name);
                ListViewItem lvi = new ListViewItem(platform.Name);
                lvi.SubItems.Add(platform.Folder);
                lvPlatforms.Items.Add(lvi);
            }

            lvPlatforms.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

        }

        private void lvPlatforms_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Change_Path cp = new Change_Path();
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
            TempoChangePathsJeux tcpj = new TempoChangePathsJeux();
            tcpj.Initialization();
            tcpj.ShowDialog();
        }
    }
}
