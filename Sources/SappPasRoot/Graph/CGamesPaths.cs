using SappPasRoot.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unbroken.LaunchBox.Plugins;
using Unbroken.LaunchBox.Plugins.Data;

namespace SappPasRoot.Graph
{
    public partial class CGamesPaths : Form
    {
        /// <summary>
        ///  Dossier de l'application - Utile au debugmode qui peut forcer du coup
        /// </summary>
        private string AppPath;

        /// <summary>
        /// Liste originale desjeux
        /// </summary>
        private IGame[] _ListGames;


        public string PlatformName { get; set; }
        /// <summary>
        /// Copie de la plateforme
        /// </summary>
        private IPlatform _PlatformObject;
        


        private bool DebugMode;

        public CGamesPaths()
        {
            InitializeComponent();
        }

        internal void Initialization()
        {
            PluginHelper.LaunchBoxMainForm.FormClosing += LaunchBoxMainForm_FormClosing;

            AppPath = AppDomain.CurrentDomain.BaseDirectory;


            var _oPlatform = PluginHelper.DataManager.GetPlatformByName("");

            _ListGames = _oPlatform.GetAllGames(false, false)
                                    .OrderBy(x => x.Title).ToArray();

            GrabMyShovel();
        }

        public void DebugTest(IGame[] fakelist)
        {
            DebugMode = true;
            AppPath = @"I:\Frontend\LaunchBox\";
        }

        private void GrabMyShovel()
        {
            foreach (var rameuh in _ListGames)
            {
                var titlemod = rameuh.Title.Replace(' ', '_');
                richTextBox1.Text += $"MvGame {titlemod} = new MvGame();" + Environment.NewLine;
                richTextBox1.Text += $"{titlemod}.Title= \"{rameuh.Title}\";" + Environment.NewLine;
                richTextBox1.Text += $"{ titlemod}.ApplicationPath= @\"{rameuh.ApplicationPath}\";" + Environment.NewLine + Environment.NewLine;

            }
        }

        private void LaunchBoxMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }
    }
}
