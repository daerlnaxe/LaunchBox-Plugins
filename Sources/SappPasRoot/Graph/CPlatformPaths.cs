﻿using System;
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
using CCLaunchBox;
using SappPasRoot.Core;
using SappPasRoot.Languages;
using Unbroken.LaunchBox.Plugins;
using Unbroken.LaunchBox.Plugins.Data;
using DxPaths.Windows;
using System.Text.RegularExpressions;

namespace SappPasRoot.Graph
{
    public partial class CPlatformPaths : Form
    {
        public string Platform { get; set; }

        bool DebugMode;
        private string PlatformFolder;

        // Chemin de l'appli - Utile en mode debug
        private string AppPath;

        // Liste des dossiers
        private IPlatformFolder[] IPFolders { get; set; }
        private MvFolder[] aMVFolders { get; set; }
        private MvFolder Game { get; set; }

        private IPlatform _PlatformObject;

        // Current folders
        private string _CHardLink;
        private string _CRelatLink;
        // Liens en dur
        private string _NewRoot;

        private Dictionary<string, int> _Cols { get; set; }
        private List<Bandeau> lBandeaux = new List<Bandeau>();

        // Largeur du flowlayout principal
        private int ContWidth;
        private int BandHeight;

        private bool MoreShowed = false;
        //   private Color _BColor = Color.White;

        public CPlatformPaths()
        {
            InitializeComponent();
            
        }

        #region Initialisations
        /// <summary>
        /// Make list of folders - Ne pas utiliser hors plugin
        /// </summary>
        internal void Initialization()
        {
            PluginHelper.LaunchBoxMainForm.FormClosing += LaunchBoxMainForm_FormClosing;
            boxLog.Text = "Initialisation";
            //
            AppPath = AppDomain.CurrentDomain.BaseDirectory;
            boxLog.Text = boxLog.Text.Insert(0, $@"LaunchBox main path: {AppPath}" + Environment.NewLine); ;

            // récupération de la plateforme concernée
            _PlatformObject = PluginHelper.DataManager.GetPlatformByName(Platform);
            PlatformFolder = _PlatformObject.Folder;

            // Récupération de tous les dossiers + tri
            IPFolders = _PlatformObject.GetAllPlatformFolders()
                                                    .OrderBy(x => x.MediaType).ToArray();
            //var foldersOrdered = ArrPlatFolder.OrderBy(x => x.MediaType).ToArray();

        }

        private void LaunchBoxMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// private à la compil
        /// </summary>
        public void DebugTest()
        {          

            DebugMode = true;
            boxLog.Text = "Debug Mode";

            Platform = "Sega Mega Drive";

           // _CRelatLink = @"..\..\Games\Roms\Sega Mega Drive";

            AppPath = @"i:\Frontend\LaunchBox\";
            //PlatformFolder = @"..\..\Games\Roms\Sega Mega Drive";
            PlatformFolder = @".\Roms\Sega Mega Drive";


            IPlatformFolder[] raoul = new IPlatformFolder[15];

            MvFolder mvManuel = new MvFolder();
            mvManuel.FolderPath = @"..\..\Games\Manuels\Sega Mega Drive";
            mvManuel.MediaType = "Manual";
            raoul[0] = mvManuel;


            MvFolder mvMusic = new MvFolder();
            mvMusic.FolderPath = @"..\..\Games\Music\Sega Mega Drive";
            mvMusic.MediaType = "Music";
            raoul[1] = mvMusic;


            MvFolder mvVideo = new MvFolder();
            mvVideo.FolderPath = @"..\..\Games\Videos\Sega Mega Drive";
            mvVideo.MediaType = "Video";
            raoul[2] = mvVideo;

            for (int i = 3; i < 15; i += 3)
            {
                MvFolder mv3 = new MvFolder();
                mv3.FolderPath = @"..\..\Games\Covers\Sega Mega Drive\Steam Banner";
                mv3.MediaType = "Banner";
                raoul[i] = mv3;

                MvFolder ac = new MvFolder();
                ac.FolderPath = @"..\..\Games\Covers\Sega Mega Drive\Arcade - Cabinet";
                ac.MediaType = "Arcade - Cabinet";
                raoul[i + 1] = ac;

                MvFolder fbf = new MvFolder();
                fbf.FolderPath = @"..\..\Games\Covers\Sega Mega Drive\Fanart - Box - Front";
                fbf.MediaType = "Fanart - Box - Front";
                raoul[i + 2] = fbf;
            }

            IPFolders = raoul;
        }

        private async void Change_Path_Load(object sender, EventArgs e)
        {
            GrabMyShovel();
        }
        #endregion

        #region Principales

        /// <summary>
        /// Core / 1st time - i don't not let it Load in case of problem
        /// </summary>
        private async void GrabMyShovel()
        {
            boxLog.Text = boxLog.Text.Insert(0, @"Transformation RelatLink To HardLink " + Environment.NewLine); ;

            FillInformation();

            // Assignation du dernier chemin visité
            if (string.IsNullOrEmpty(Properties.Settings.Default.LastKPath))
            {
                Properties.Settings.Default.LastKPath = _CHardLink;
            }


            //Obsolète ? 
            Game = new MvFolder(PlatformFolder, AppPath);
            Game.Platform = Platform;
            Game.MediaType = "Game";


            //Dictionary<string, IPlatformFolder> dicFolder = new Dictionary<string, IPlatformFolder>();
            aMVFolders = MvFolder.Convert(IPFolders, AppPath);

            AnalyseProps(aMVFolders);


            await GenerateInfoPath(aMVFolders);


            /*
            // Reorder
            dicFolder.OrderBy( x => x.Key);
            */


            StyleMainFLP();
            SetMainWindow();
            boxLog.Text = boxLog.Text.Insert(0, @"Ready." + Environment.NewLine);
        }

        private void FillInformation()
        {
            boxLog.Text = boxLog.Text.Insert(0, @"Filling of information fields" + Environment.NewLine);


            // conversion en dur du lien vers le dossier actuel           
            _CRelatLink = PlatformFolder.Replace($@"\{Platform}", "");
            _CRelatLink = _CRelatLink.Substring(0, _CRelatLink.LastIndexOf('\\'));
            _CHardLink = Path.GetFullPath(Path.Combine(AppPath, _CRelatLink));

            _NewRoot = _CHardLink;

            this.tboxROldPath.Text = _CRelatLink;
            this.tboxHOldPath.Text = tbMainPath.Text = _CHardLink;
            this.labPName.Text = Platform;

        }

        /// <summary>
        /// Analyse les propriétés de tout le tableau pour calculer la taille des colonnes
        /// </summary>
        /// <param name="folders"></param>
        private void AnalyseProps(MvFolder[] folders)
        {
            boxLog.Text = boxLog.Text.Insert(0, @"Analysis of columns width" + Environment.NewLine); ;

            _Cols = new Dictionary<string, int>();
            _Cols.Add("Arrow", 20);
            // Name of the Media
            PropertyInfo propMedia = typeof(MvFolder).GetProperty("MediaType");
            _Cols.Add(propMedia.Name, Analyse.Rows(x => x.MediaType, propMedia, folders, new Label().Font).Width);

            // OldPath
            PropertyInfo propOldRelat = typeof(MvFolder).GetProperty("FolderPath");
            Size sORelat = Analyse.Rows(x => x.FolderPath, propOldRelat, folders, UCPaths.GetUCPRelatFont);

            PropertyInfo propOldHard = typeof(MvFolder).GetProperty("HFolderPath");
            Size sOHard = Analyse.Rows(x => x.HFolderPath, propOldHard, folders, UCPaths.GetUCPHardFont);

            _Cols.Add("UCP1", sOHard.Width > sORelat.Width ? sOHard.Width : sORelat.Width);

            // NewPath
            PropertyInfo propNRelat = typeof(MvFolder).GetProperty("NewFolderPath");
            Size sNRelat = Analyse.Rows(x => x.NewFolderPath, propNRelat, folders, UCPaths.GetUCPRelatFont);

            PropertyInfo propNHard = typeof(MvFolder).GetProperty("HNewFolderPath");
            Size sNHard = Analyse.Rows(x => x.HNewFolderPath, propNHard, folders, UCPaths.GetUCPHardFont);


            _Cols.Add("UCP2", sNHard.Width > sNRelat.Width ? sNHard.Width : sNRelat.Width);
        }

        /// <summary>
        /// Genère tous les bandeaux - Partie graphique
        /// </summary>
        /// <param name="folders"></param>
        /// <returns></returns>
        private async Task GenerateInfoPath(MvFolder[] folders)
        {
            boxLog.Text = boxLog.Text.Insert(0, @"Creation of data graphic forms" + Environment.NewLine); ;
            BandHeight = 60;

            flpPaths.Controls.Clear();

            lBandeaux.Clear();
            Bandeau game = StyleBandeaux("Game");
            game.UCPath1.RelatPath = Game.FolderPath;
            game.UCPath1.FullPath = Game.HFolderPath;
            game.UCPath2.RelatPath = Game.NewFolderPath;
            game.UCPath2.FullPath = Game.HNewFolderPath;

            flpPaths.Controls.Add(game);
            lBandeaux.Add(game);



            foreach (var folder in folders)
            {
                Bandeau bdTmp = StyleBandeaux(folder.MediaType);
                bdTmp.UCPath1.RelatPath = folder.FolderPath;
                bdTmp.UCPath1.FullPath = folder.HFolderPath;
                bdTmp.UCPath2.RelatPath = folder.NewFolderPath;
                bdTmp.UCPath2.FullPath = folder.HNewFolderPath;

                flpPaths.Controls.Add(bdTmp);
                lBandeaux.Add(bdTmp);
            }
        }

        #endregion

        #region Graphismes

        private void StyleMainFLP()
        {
            boxLog.Text = boxLog.Text.Insert(0, @"Adaptation of layout background " + Environment.NewLine); ;

            flpPaths.BackColor = Color.FromArgb(141, 177, 227);
            ContWidth = lBandeaux[0].Width;
            if (flpPaths.VerticalScroll.Enabled) ContWidth += 22;

            //_Cols.Sum(x => x.Value);
            // Height size of each item
            int minheightB = (BandHeight + 6) * 6;
            int minH = Screen.PrimaryScreen.Bounds.Height < minheightB ? Screen.PrimaryScreen.Bounds.Height : minheightB;

            flpPaths.Size = flpPaths.MinimumSize = new Size(ContWidth + 6, minH);

            //this.flpPaths.MaximumSize = new Size(ContWidth + 6, maxH);
            //flpPaths.MinimumSize = new Size(ContWidth +6, flpPaths.Height);
        }

        private void SetMainWindow()
        {
            boxLog.Text = boxLog.Text.Insert(0, @"Adaptation of window " + Environment.NewLine); ;
            int largr = flpPaths.Width + 40;
            int hautr = flpPaths.Height + boxLog.Height + tlpInfos.Height + 100;
            /* int minLargr = 100;
             int minHautr = 100;*/

            // Mainwindow size + Block according to primary screen
            largr = Screen.PrimaryScreen.Bounds.Width > largr ? largr : Screen.PrimaryScreen.Bounds.Width;
            hautr = Screen.PrimaryScreen.Bounds.Height > hautr ? hautr : Screen.PrimaryScreen.Bounds.Height;

            Size = new Size(largr, hautr);

            // MinSize
            // minLargr = Screen.PrimaryScreen.Bounds.Width > ContWidth + 68 ? ContWidth + 68 : Screen.PrimaryScreen.Bounds.Width ;
            // minHautr = Screen.PrimaryScreen.Bounds.Height > Height ? Height : Screen.PrimaryScreen.Bounds.Height;
            //MinimumSize = new Size(ContWidth + 80, 600);
            //MaximumSize = new Size(largr, Screen.PrimaryScreen.Bounds.Height);
            boxLog.Width = flpPaths.Width;
            panelTop.Width = flpPaths.Width;
        }

        private Bandeau StyleBandeaux(string MediaType)
        {
            Bandeau bdTmp = new Bandeau();
            bdTmp.Name = $"Bandeau - {MediaType}";
            bdTmp.CategValue = MediaType;

            bdTmp.ElementsBgd = Color.White;
            bdTmp.ElementsHeight = BandHeight;
            bdTmp.Height = BandHeight;
            bdTmp.BackColor = Color.FromArgb(0);

            bdTmp.CategWidth = _Cols["MediaType"];
            bdTmp.UCPath1.Width = _Cols["UCP1"];
            bdTmp.UCPath2.Width = _Cols["UCP2"];

            return bdTmp;
        }


        private void ResizeTextBox(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Width = TextRenderer.MeasureText(tb.Text, tb.Font).Width;
        }

        #endregion

        #region New Path Chosen

        private void btBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = Lang.FB_Description;
            fbd.SelectedPath = Properties.Settings.Default.LastKPath;

            if (fbd.ShowDialog() != DialogResult.OK) return;

            // Memorisation lastKnowPath
            string tmpPath;
            Properties.Settings.Default.LastKPath = tmpPath = fbd.SelectedPath;
            Properties.Settings.Default.Save();

            // Assignation 
            this.tbMainPath.Text = _NewRoot = tmpPath;

            btApply.Visible = false;
            btSimul.Visible = true;
        }

        private void txbMainPath_Validating(object sender, CancelEventArgs e)
        {
            ManualVerif();
        }

        private void txbMainPath_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                ManualVerif();
            }
        }

        private void ManualVerif()
        {
            boxLog.Text = boxLog.Text.Insert(0, @"Folder verification" + Environment.NewLine); ;
            if (!Directory.Exists(tbMainPath.Text))
            {
                MessageBox.Show($"{Lang.NK_Dir}", Lang.Error_Word, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.tbMainPath.Text = _NewRoot;
                return;
            }

            Properties.Settings.Default.LastKPath = _NewRoot = this.tbMainPath.Text;
            Properties.Settings.Default.Save();
            //AlterPath();
        }

        #endregion

        #region Simulation


        private void btSimul_Click(object sender, EventArgs e)
        {
            if (tlpFolders.Visible) tlpFolders.Visible = MoreShowed = false;
            AlterPath();
            btApply.Visible = true;
            btSimul.Visible = false;
        }

        /// <summary>
        /// Alteration de tous les chemins sur les MVFolders
        /// </summary>
        private async void AlterPath()
        {
            boxLog.Text = boxLog.Text.Insert(0, @"Simuation start ..." + Environment.NewLine);

            Game.HNewFolderPath = Path.Combine(_NewRoot, tbGames.Text, Platform);
            Game.NewFolderPath = DxPath.ToRelative(AppPath, Game.HNewFolderPath);


            for (int i = 0; i < aMVFolders.Length; i++)
            {
                var amvF = aMVFolders[i];

                // Choix de filtrer que videos / games / manuals / music et ... ?
                string hardPath;
                switch (amvF.MediaType)
                {
                    //case "Game":
                    //    hardPath = Path.Combine(_NewRoot, tbGames.Text, Platform);
                    //    break;

                    case "Manual":
                        hardPath = Path.Combine(_NewRoot, tbManual.Text, Platform);
                        break;

                    case "Music":
                        hardPath = Path.Combine(_NewRoot, tbMusic.Text, Platform);
                        break;

                    case "Video":
                        hardPath = Path.Combine(_NewRoot, tbVideo.Text, Platform);
                        break;

                    default:
                        hardPath = Path.Combine(_NewRoot, tbImages.Text, Platform, amvF.MediaType);
                        break;

                }

                string relatPath = DxPath.ToRelative(AppPath, hardPath);

                aMVFolders[i].NewFolderPath = relatPath;
                aMVFolders[i].HNewFolderPath = hardPath;


            }
            //
            AnalyseProps(aMVFolders);
            await GenerateInfoPath(aMVFolders);
            StyleMainFLP();
            SetMainWindow();
            boxLog.Text = boxLog.Text.Insert(0, @"Simuation finish ..." + Environment.NewLine);
            boxLog.Text = boxLog.Text.Insert(0, @"Ready, click on proceed to save this modifications." + Environment.NewLine);
        }

        #endregion
        #region Application des changements 

        /// <summary>
        /// Modification des datas - Datas modification
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btApply_Click(object sender, EventArgs e)
        {
            ApplyChanges();
        }

        private void ApplyChanges()
        {
            boxLog.Text = boxLog.Text.Insert(0, @"Process start ..." + Environment.NewLine);

            Game.FolderPath = Game.NewFolderPath;
            Game.HFolderPath = Game.HNewFolderPath;

            DematroiChka();

            if (!DebugMode)
            {
                _PlatformObject.Folder = Game.FolderPath;

                PluginHelper.DataManager.Save();
            }

            MessageBox.Show(Lang.Save_Ok, Lang.Save_Title, MessageBoxButtons.OK, MessageBoxIcon.Information);

            PlatformFolder = Game.FolderPath;
            FillInformation();
            btApply.Visible = false;
        }

        /// <summary>
        /// Envoie les paramètres aux IPFolder originels
        /// </summary>
        /// <remarks>n'utilise pas la partie graphique</remarks>
        private void DematroiChka()
        {
            foreach (var ipFolder in IPFolders)
            {
                foreach (var mvFolder in aMVFolders)
                {
                    if (String.Equals(ipFolder.MediaType, mvFolder.MediaType))
                    {

                        mvFolder.FolderPath = mvFolder.NewFolderPath;
                        mvFolder.HFolderPath = mvFolder.HNewFolderPath;

                        // Changement in/dans Launchbox
                        ipFolder.FolderPath = mvFolder.FolderPath;
                        break;
                    }

                }
            }
        }

        #endregion

        #region Resets
        private void btResetFactory_Click(object sender, EventArgs e)
        {
            ResetFactory();
        }

        private void ResetFactory()
        {
            Params.Reset(this, AppPath, Platform);
            _NewRoot = Params.FactoryRelativePath;
            AlterPath();
            btSimul.Visible = false; ;
            btApply.Visible = true;

        }



        #endregion

        #region Menu More
        /// <summary>
        /// Click on MenuMore label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label8_Click(object sender, EventArgs e)
        {
            O_o();
        }

        /// <summary>
        /// Show or mask MenuMore
        /// </summary>
        private void O_o()
        {
            if (MoreShowed)
            {
                Console.WriteLine("Menu More est masqué");

                btResetFactory.Visible = true;
                tlpFolders.Visible = false;
                MoreShowed = false;
                btBrowse.Visible = true;

                //     panelTop.Height = 80;
            }
            else
            {
                Console.WriteLine("Menu More est affiché");
                btResetFactory.Visible = false;
                tlpFolders.Visible = true;
                //   panelTop.Height = 80;
                MoreShowed = true;
                btBrowse.Visible = false;


            }
        }

        private void MenuChanged(object sender, EventArgs e)
        {
            btApply.Visible = false;
            btSimul.Visible = true;
        }
        #endregion
        private void panelTop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void messageQueue1_ReceiveCompleted(object sender, System.Messaging.ReceiveCompletedEventArgs e)
        {

        }



        private void FolderNameVerif(object sender, KeyPressEventArgs e)
        {
            TextBox tb = (TextBox)sender;


            var regex = new Regex(@"[\\\/:*<>|" + '"' + "]");
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                Console.WriteLine("Probleme2: " + e.KeyChar);
                //     tb.Text = tb.Text.Substring(0, tb.Text.Length - 1);
                e.Handled = true;
                toolTip1.Show($"{Lang.Cant_Contains} '{e.KeyChar}' ", tb, duration: 1000, x: tb.Width, y: -60);
            }
        }

        private void LinkVerif(object sender, KeyPressEventArgs e)
        {

        }
    }
}
