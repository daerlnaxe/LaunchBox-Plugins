using CCLaunchBox;
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
        private string _PlatformFolderRL;
        private string _PlatformFolderHL;

        /// <summary>
        /// Liste originale desjeux
        /// </summary>
        private LBGame[] IPGames;
        private MvGame[] _AmVGames;

        /// <summary>
        /// Copie de la plateforme
        /// </summary>
        private IPlatform _PlatformObject;
        //private List<PlatformBandeau> lBandeaux = new List<PlatformBandeau>();

        /// <summary>
        /// Pseudo colonnes
        /// </summary>
       // private Dictionary<string, int> _Cols { get; set; }

        /// <summary>
        /// Bandeau déroulé
        /// </summary>
        GameBandeau _BandActif;

        // Largeur du flowlayout principal
        private int ContWidth;
        // hauteur du bandeau et des éléments
        private int BandHeight;
        private Font bRelatFont = new Font(FontFamily.GenericSansSerif, 10F, FontStyle.Bold);
        private Font bHardFont = new Font(FontFamily.GenericSansSerif, 7F);


        private bool DebugMode;

        public CGamesPaths()
        {
            InitializeComponent();
            listView1.Items.Clear();
        }

        private void CGamesPaths_Load(object sender, EventArgs e)
        {
            //GrabMyShovel();
        }

        internal void Initialization(IPlatform platform)
        {
            PluginHelper.LaunchBoxMainForm.FormClosing += LaunchBoxMainForm_FormClosing;

            boxLog.Text = boxLog.Text.Insert(0, $@"Initialization" + Environment.NewLine);

            _PlatformObject = platform;
            boxLog.Text = boxLog.Text.Insert(0, $@"Platform '{_PlatformObject.Name}' selected" + Environment.NewLine);


            // Application folder
            AppPath = AppDomain.CurrentDomain.BaseDirectory;

            _PlatformFolderRL = _PlatformObject.Folder;
            _PlatformFolderHL = Path.GetFullPath(Path.Combine(AppPath, _PlatformFolderRL));


            IPGames = (LBGame[])_PlatformObject.GetAllGames(true, true)//(false, false)
                                    .OrderBy(x => x.Title).ToArray();

            FakeGenerator();
        }


        public void DebugTest(LBGame[] fakelist)
        {
            DebugMode = true;
            AppPath = @"I:\Frontend\LaunchBox\";
            IPGames = fakelist;
            _PlatformFolderRL = @".\Roms\Sega Mega Drive";
            _PlatformFolderHL = Path.GetFullPath(Path.Combine(AppPath, _PlatformFolderRL));
        }

        /// <summary>
        /// 
        /// </summary>
        private void GrabMyShovel()
        {
            FillInformation();

            // Assignation du dernier chemin visité
            if (string.IsNullOrEmpty(Properties.Settings.Default.LastKPath))
            {
                Properties.Settings.Default.LastKPath = _PlatformFolderHL;
            }


            // Conversion to MvGame
            _AmVGames = MvGame.Convert(IPGames, AppPath);

            //AnalyseProps(aMvGames);

            BackgroundWorker bGroundwker = new BackgroundWorker();
            bGroundwker.DoWork += new DoWorkEventHandler(bw_Work1);
            bGroundwker.ProgressChanged += new ProgressChangedEventHandler(bgw1_ProgressChanged);
            //bGroundwker.RunWorkerAsync(aMvGames);

            GenerateTitles(_AmVGames);


            StyleMainFLP();
            SetMainWindow();
        }

        private void bgw1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //   throw new NotImplementedException();
        }

        /// <summary>
        /// Travail en background à faire
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bw_Work1(object sender, DoWorkEventArgs e)
        {
            MvGame[] aMvGames = (MvGame[])e.Argument;
            GenerateTitles(aMvGames);
        }

        #region Graphismes

        /// <summary>
        /// Création des bandeaux de titre
        /// </summary>
        /// <param name="aMvGames"></param>
        private void GenerateTitles(MvGame[] aMvGames)
        {
            try
            {
                boxLog.Text = boxLog.Text.Insert(0, @"Creation of data graphic forms" + Environment.NewLine);
                flpGames.Controls.Clear();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            foreach (var mvGame in aMvGames)
            {
                toolStripStatusLabel1.Text = $"Création of bandeau: {mvGame.Title}";

                Console.WriteLine(mvGame.Title);

                GameBandeau bdTmp = StyleTitles(mvGame.Id);
                bdTmp.Objet = mvGame;
                bdTmp.Title += $" {mvGame.Title}";

                flpGames.Controls.Add(bdTmp);
                flpGames.Refresh();
                //lBandeaux.Add(bdTmp);
            }
        }


        /// <summary>
        /// Genère les bandeaux de paths
        /// </summary>
        /// <param name="folders"></param>
        /// <returns></returns>
        private async Task GeneratePaths(MvGame game, FlowLayoutPanel flp, Dictionary<string, int> columns)
        {
            boxLog.Text = boxLog.Text.Insert(0, @"Creation of data graphic forms" + Environment.NewLine);

            /*flp.Clear();
            
            PlatformBandeau game = StyleBandeaux("Game");
            game.UCPath1.RelatPath = Game.FolderPath;
            game.UCPath1.FullPath = Game.HFolderPath;
            game.UCPath2.RelatPath = Game.NewFolderPath;
            game.UCPath2.FullPath = Game.HNewFolderPath;

            flpGames.Controls.Add(game);
            flpGames.Refresh();
            lBandeaux.Add(game);
            */
            foreach (var pathO in game.GetPaths)
            {
                /* Label pfbGame = new Label();
                 pfbGame.Text = path.Type;*/

                PlatformBandeau pfbGame = StylePaths(pathO.Type, columns);
                //pfbGame.CategValue = pathO.Type;
                pfbGame.UCPath1.RelatPath = pathO.Original_RLink;
                pfbGame.UCPath1.FullPath = pathO.Original_HLink;

                pfbGame.UCPath2.RelatPath = pathO.Destination_RLink;
                pfbGame.UCPath2.FullPath = pathO.Destination_HLink;
                flp.Controls.Add(pfbGame);
            }



            // games.Add(bdTmp);

        }

        /// <summary>
        /// Style des titres
        /// </summary>
        /// <param name="titre"></param>
        /// <returns></returns>
        private GameBandeau StyleTitles(string titre)
        {
            int rightSpace = 10;

            GameBandeau bdTmp = new GameBandeau();
            bdTmp.Name = titre;

            bdTmp.Height = BandHeight = 54;
            bdTmp.DeroulBand += new GameBandeau.DeroulHandler(FillBand);

            return bdTmp;
        }

        private PlatformBandeau StylePaths(string MediaType, Dictionary<string,int> columns)
        {
            int rightSpace = 10;

            PlatformBandeau bdTmp = new PlatformBandeau();
            bdTmp.Name = $"Bandeau - {MediaType}";
            bdTmp.CategValue = MediaType;

            bdTmp.ElementsBgd = Color.White;
            bdTmp.ElementsHeight = BandHeight = 60;
            bdTmp.Height = BandHeight;
            bdTmp.BackColor = Color.FromArgb(0);

            bdTmp.CategWidth = columns["MediaType"] + rightSpace; ;

            bdTmp.UCPath1.TopFont = bHardFont;
            bdTmp.UCPath1.BottomFont = bRelatFont;
            bdTmp.UCPath1.Width = columns["UCP1"] + rightSpace; ;

            bdTmp.UCPath2.TopFont = bHardFont;
            bdTmp.UCPath2.BottomFont = bRelatFont;
            bdTmp.UCPath2.Width = columns["UCP2"] + rightSpace; ;

            return bdTmp;
        }




        private void StyleMainFLP()
        {
            boxLog.Text = boxLog.Text.Insert(0, @"Adaptation of layout background " + Environment.NewLine); ;

            flpGames.BackColor = Color.FromArgb(141, 177, 227);
            ContWidth = flpGames.Controls[0].Width; // lBandeaux[0].Width;
            if (flpGames.VerticalScroll.Enabled) ContWidth += 22;

            //_Cols.Sum(x => x.Value);
            // Height size of each item
            int minheightB = (BandHeight + 6) * 6;
            int minH = Screen.PrimaryScreen.Bounds.Height < minheightB ? Screen.PrimaryScreen.Bounds.Height : minheightB;

            flpGames.Size = flpGames.MinimumSize = new Size(ContWidth + 6, minH);

            //this.flpPaths.MaximumSize = new Size(ContWidth + 6, maxH);
            //flpPaths.MinimumSize = new Size(ContWidth +6, flpPaths.Height);
        }


        private void ResizeTextBox(object sender, EventArgs e)
        {
            GraphFunc.ResizeTextBox(sender);
        }


        #endregion
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
            this.tboxROldPath.Text = _PlatformFolderRL;
            this.tboxHOldPath.Text = _PlatformFolderHL;
        }

        /// <summary>
        /// Analyse les propriétés de tout le tableau pour calculer la taille des colonnes
        /// </summary>
        /// <param name="pathCollec"></param>
        private Dictionary<string, int> AnalyseProps(PathsCollec[] pathCollec)
        {
            boxLog.Text = boxLog.Text.Insert(0, @"Analysis of columns width" + Environment.NewLine); ;

            Dictionary<string, int> columns = new Dictionary<string, int>();

            // Name of the Media
            //PropertyInfo propMedia = typeof(MvFolder).GetProperty("MediaType");
            columns.Add("MediaType", Analyse.Rows(x => x.Type, pathCollec, new Label().Font).Width);

            // OldPath            
            Size sORelat = Analyse.Rows(x => x.Original_RLink, pathCollec, bRelatFont);
            Size sOHard = Analyse.Rows(x => x.Original_HLink, pathCollec, bHardFont);

            columns.Add("UCP1", sOHard.Width > sORelat.Width ? sOHard.Width : sORelat.Width);

            // NewPath
            Size sNRelat = Analyse.Rows(x => x.Destination_RLink, pathCollec, bRelatFont);
            Size sNHard = Analyse.Rows(x => x.Destination_HLink, pathCollec, bHardFont);


            columns.Add("UCP2", sNHard.Width > sNRelat.Width ? sNHard.Width : sNRelat.Width);

            return columns;
        }

        private void LaunchBoxMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// Rempli chaque flowlayout d'un jeu avec les informations relatives aux paths
        /// </summary>
        /// <param name="sender"></param>
        private void FillBand(GameBandeau sender)
        {
            if (_BandActif != null) _BandActif.Collapse_Fl();

            boxLog.Text = boxLog.Text.Insert(0, $"Bandactif: {sender.Name}" + Environment.NewLine); ;
            toolStripStatusLabel1.Text = $"Bandeau unrolled";
            
           _BandActif = sender;
            if (sender.flp1.Controls.Count ==0)
            {
                MvGame game = (MvGame)sender.Objet;

                var paths = game.GetPaths;

                var columns = AnalyseProps(paths);

                columns.Add("Arrow", 20);
                GeneratePaths(game, sender.flp1, columns);
                boxLog.Text = boxLog.Text.Insert(0, $"Generate graphical elements for '{game.Title}'" + Environment.NewLine); ;
            }
        }

        /// <summary>
        /// Makes fake list code for debugtest
        /// </summary>
        private void FakeGenerator()
        {
            boxLog.Text += Environment.NewLine;
            boxLog.Text += $"LBGame[] KingOfSpain = new LBGame[{IPGames.Length}];" + Environment.NewLine;

            for (int i = 0; i < IPGames.Length; i++)
            {
                var rameuh = IPGames[i];
                var pseuRoot = @"I:\Frontend\LaunchBox\";

                var gamename = $"game_{i}";

                boxLog.Text += $"LBGame {gamename} = new LBGame();" + Environment.NewLine;
                boxLog.Text += $"{gamename}.Title= \"{rameuh.Title}\";" + Environment.NewLine;
                boxLog.Text += $"{gamename}.Id = \"{rameuh.Id}\";" + Environment.NewLine;
                boxLog.Text += $"{ gamename}.ApplicationPath = @\"{rameuh.ApplicationPath}\";" + Environment.NewLine;

                boxLog.Text += $"KingOfSpain[{i}] = {gamename};" + Environment.NewLine + Environment.NewLine;
            }
        }

        private void CGamesPaths_Shown(object sender, EventArgs e)
        {
            GrabMyShovel();
        }



        private void SetMainWindow()
        {
            boxLog.Text = boxLog.Text.Insert(0, @"Adaptation of window " + Environment.NewLine); ;
            int largr = flpGames.Width + 40;
            int hautr = flpGames.Height + boxLog.Height + tlpInfos.Height + 100;

            // Mainwindow size + Block according to primary screen
            largr = Screen.PrimaryScreen.Bounds.Width > largr ? largr : Screen.PrimaryScreen.Bounds.Width;
            hautr = Screen.PrimaryScreen.Bounds.Height > hautr ? hautr : Screen.PrimaryScreen.Bounds.Height;

            Size = new Size(largr, hautr);

            boxLog.Width = flpGames.Width;
            panelTop.Width = flpGames.Width;
        }

        private void flpGames_MouseHover(object sender, EventArgs e)
        {
            if (_BandActif != null) _BandActif.Collapse_Fl();
            _BandActif = null;
        }
    }
}
