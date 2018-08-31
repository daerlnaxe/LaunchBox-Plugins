using SappPasRoot.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        public string PlatformName { get; set; }

        /// <summary>
        ///  Dossier de l'application - Utile au debugmode qui peut forcer du coup
        /// </summary>
        private string AppPath;
        private string _PlatformNameRL;
        private string _PlatformNameHL;

        /// <summary>
        /// Liste originale desjeux
        /// </summary>
        private IGame[] IPGames;


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
            PluginHelper.LaunchBoxMainForm.FormClosing += LaunchBoxMainForm_FormClosing;

            boxLog.Text = boxLog.Text.Insert(0, $@"Initialization" + Environment.NewLine);

            _PlatformObject = platform;
            boxLog.Text = boxLog.Text.Insert(0, $@"Platform '{_PlatformObject.Name}' selected" + Environment.NewLine);


            // Application folder
            AppPath = AppDomain.CurrentDomain.BaseDirectory;

            IPGames = _PlatformObject.GetAllGames(true, true)//(false, false)
                                    .OrderBy(x => x.Title).ToArray();

        }


        public void DebugTest(IGame[] fakelist)
        {
            DebugMode = true;
            AppPath = @"I:\Frontend\LaunchBox\";
            IPGames = fakelist;

        }

        /// <summary>
        /// 
        /// </summary>
        private void GrabMyShovel()
        {
            _PlatformNameRL = _PlatformObject.Folder;
            _PlatformNameHL = Path.GetFullPath(Path.Combine(AppPath, _PlatformNameRL));

            FillInformation();

            // Assignation du dernier chemin visité
            if (string.IsNullOrEmpty(Properties.Settings.Default.LastKPath))
            {
                Properties.Settings.Default.LastKPath = _PlatformNameHL;
            }


            // Conversion to MvGame
            var aMvGames = MvGame.Convert(IPGames, AppPath  );

            // stoppé là
            foreach (var game in IPGames)
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

        private void FillInformation()
        {
            boxLog.Text = boxLog.Text.Insert(0, @"Filling of information fields" + Environment.NewLine);
            boxLog.Text = boxLog.Text.Insert(0, @"Transformation RelatLink To HardLink " + Environment.NewLine); ;

            //boxLog.Text = boxLog.Text.Insert(0, $@"PlatformFolder: {PlatformFolder}" + Environment.NewLine); ;

            // conversion en dur du lien vers le dossier actuel           
            /*_CRelatLink = PlatformFolder.Replace($@"\{Platform}", "");
            _CRelatLink = _CRelatLink.Substring(0, _CRelatLink.LastIndexOf('\\'));
            _CHardLink = Path.GetFullPath(Path.Combine(AppPath, _CRelatLink));

            _NewRoot = _CHardLink;

            this.tboxROldPath.Text = _CRelatLink;
            this.tboxHOldPath.Text = tbMainPath.Text = _CHardLink;*/
            
            this.labPName.Text = PlatformName;
            this.tboxROldPath.Text = _PlatformNameRL;
            this.tboxHOldPath.Text = _PlatformNameHL;
        }


        /// <summary>
        /// Makes fake list code for debugtest
        /// </summary>
        private void FakeGenerator()
        {
            foreach (var rameuh in IPGames)
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

        private void ResizeTextBox(object sender, EventArgs e)
        {
            GraphFunc.ResizeTextBox(sender);
        }
    }
}
