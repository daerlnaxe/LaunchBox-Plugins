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
            listView1.Items.Clear();
        }


        private void CGamesPaths_Load(object sender, EventArgs e)
        {
            GrabMyShovel();
        }

        internal void Initialization(IPlatform platform)
        {
            boxLog.Text = boxLog.Text.Insert(0, $@"Initialization" + Environment.NewLine);

            _PlatformObject = platform;
            boxLog.Text = boxLog.Text.Insert(0, $@"Platform '{_PlatformObject.Name}' selected" + Environment.NewLine);

            PluginHelper.LaunchBoxMainForm.FormClosing += LaunchBoxMainForm_FormClosing;

            AppPath = AppDomain.CurrentDomain.BaseDirectory;

            _ListGames = _PlatformObject.GetAllGames(true, true)//(false, false)
                                    .OrderBy(x => x.Title).ToArray();

        }


        public void DebugTest(IGame[] fakelist)
        {
            DebugMode = true;
            AppPath = @"I:\Frontend\LaunchBox\";
            _ListGames = fakelist;

        }

        /// <summary>
        /// 
        /// </summary>
        private void GrabMyShovel()
        {


            foreach (var game in _ListGames)
            {
                Console.WriteLine(game.Id);
                ListViewItem lvi = new ListViewItem();
                //lvi.SubItems.Add(game.Title);
                //lvi.SubItems.Add(game.LaunchBoxDbId.ToString());
                //lvi.SubItems.Add(game.ThemeVideoPath);
                //lvi.SubItems.Add(game.RootFolder);
                //lvi.SubItems.Add(game.ConfigurationPath);
                //lvi.SubItems.Add(game.ConfigurationCommandLine);
                //lvi.SubItems.Add(game.PlatformClearLogoImagePath);
                //lvi.SubItems.Add(game.DosBoxConfigurationPath);

                // ?
                

                Console.WriteLine();



                listView1.Items.Add(lvi);
            }
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }


        /// <summary>
        /// Makes fake list code for debugtest
        /// </summary>
        private void FakeGenerator()
        {
            foreach (var rameuh in _ListGames)
            {
                var titlemod = rameuh.Title.Replace(' ', '_');
                boxLog.Text += $"MvGame {titlemod} = new MvGame();" + Environment.NewLine;
                boxLog.Text += $"{titlemod}.Title= \"{rameuh.Title}\";" + Environment.NewLine;
                boxLog.Text += $"{ titlemod}.ApplicationPath= @\"{rameuh.ApplicationPath}\";" + Environment.NewLine + Environment.NewLine;
            }
        }

        private void LaunchBoxMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }


    }
}
