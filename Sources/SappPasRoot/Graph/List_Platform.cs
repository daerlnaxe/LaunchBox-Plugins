﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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

    /* 
     * IHM
     * Used to show list of platforms, you can choose to launch modification for platform or games for the platform
     */
    public partial class List_Platform : Form
    {
        // LaunchBox refuse two platforms with same name (to watching)
        private Dictionary<string, IPlatform> dicPlatforms = new Dictionary<string, IPlatform>();


        public List_Platform()
        {
            InitializeComponent();
            this.Text += $" {Assembly.GetAssembly(typeof(Main)).GetName().Version.ToString()}";

            ListPlatform();

        }

        private void Fermeture(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// List Platforms, create a item for each
        /// </summary>
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

        /// <summary>
        /// Double clic sur la liste de plateformes
        /// Double clic event on platform list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvPlatforms_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) return;
            Change_Platform_Paths();
        }

        /// <summary>
        /// Clic sur l'élement du menu contextuel
        /// Clic on contextual menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cPlatPaths_Click(object sender, EventArgs e)
        {
            Change_Platform_Paths();
        }

        /// <summary>
        /// Lanceur pour les modifications des plateformes
        /// Launcher for platforms modifications
        /// </summary>
        private void Change_Platform_Paths()
        {
            string platSel = lvPlatforms.SelectedItems[0].Text;
            Debug.WriteLine($"Change Platform Paths - Selected Platform: {platSel}");

            CPlatformPaths cp = new CPlatformPaths();
            //MessageBox.Show($"plat {lvPlatforms.SelectedItems[0].Text}");
            cp.Platform = platSel;
            cp.Initialization();

            this.Hide();
            cp.ShowDialog();
            this.Show();
        }

        /// <summary>
        /// Menu Contextuel
        /// Contextual Menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvPlatforms_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) return;

            var hti = lvPlatforms.HitTest(e.Location);
            //     if(hti.Item !=null) 
            cxMenuListP.Show(lvPlatforms, e.Location);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string platSel = lvPlatforms.SelectedItems[0].Text;
            Change_Platform_Games_Paths(platSel);
        }

        #region Relative to modifications on Game Paths
        /// <summary>
        /// Event when you choose to modify game paths
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cGamesPaths_Click(object sender, EventArgs e)
        {
            string platSel = lvPlatforms.SelectedItems[0].Text;
            Change_Platform_Games_Paths(platSel);
        }

        /// <summary>
        /// Function called when you want to modify game paths of a platform
        /// </summary>
        /// <param name="platSel"></param>
        private void Change_Platform_Games_Paths(string platSel)
        {
            Debug.WriteLine($"Change Platform Games Paths - Selected Platform: {platSel}");
            CGamesPaths tcpj = new CGamesPaths();
            tcpj.Initialization(dicPlatforms[platSel]);
            tcpj.ShowDialog();
        }
        
        #endregion

    }
}
