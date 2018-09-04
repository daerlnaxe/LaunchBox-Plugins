using CCLaunchBox;
using SappPasRoot.Core;
using SappPasRoot.Languages;
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

        /// <summary>
        ///  Dossier de l'application - Utile au debugmode qui peut forcer du coup
        /// </summary>
        private string AppPath;
        private bool DebugMode;

        // Platform
        public string PlatformName { get; set; }
        private string _PlatformFolderRL;
        private string _PlatformFolderHL;
        /// <summary>
        /// Copie de la plateforme
        /// </summary>
        private IPlatform _PlatformObject;
        Dictionary<string, string> dicSystemPaths = new Dictionary<string, string>();

        /// <summary>
        /// Liste originale desjeux
        /// </summary>
        private IGame[] _IPGames;
        private MvGame[] _AmVGames;
        //private List<PlatformBandeau> lBandeaux = new List<PlatformBandeau>();

        #region Graphismes        
        // Bandeau déroulé
        GameBandeauV _BandActif;

        // Largeurs
        private int ContRolledWidth = 800;
        private int ContUnrolledWidth = 0;
        private int PathsWidth;

        // hauteurs
        private int BandHeight;

        // Polices
        private Font bRelatFont = new Font(FontFamily.GenericSansSerif, 9F, FontStyle.Bold);
        private Font bHardFont = new Font(FontFamily.GenericSansSerif, 7F);
        #endregion


        public CGamesPaths()
        {
            InitializeComponent();
            //listView1.Items.Clear();
        }

        private void CGamesPaths_Load(object sender, EventArgs e)
        {
            //GrabMyShovel();
        }

        private void CGamesPaths_Shown(object sender, EventArgs e)
        {
            GrabMyShovel();
        }

        internal void Initialization(IPlatform platform)
        {
           // PluginHelper.LaunchBoxMainForm.FormClosing += LaunchBoxMainForm_FormClosing;

            boxLog.Text = boxLog.Text.Insert(0, $@"Initialization" + Environment.NewLine);

            _PlatformObject = platform;
            PlatformName = _PlatformObject.Name;

            boxLog.Text = boxLog.Text.Insert(0, $@"Platform '{_PlatformObject.Name}' selected" + Environment.NewLine);


            // Application folder
            AppPath = AppDomain.CurrentDomain.BaseDirectory;

            _PlatformFolderRL = _PlatformObject.Folder;
            _PlatformFolderHL = Path.GetFullPath(Path.Combine(AppPath, _PlatformFolderRL));


            _IPGames = _PlatformObject.GetAllGames(true, true)//(false, false)
                                                          .OrderBy(x => x.Title).ToArray();

            foreach (var ob in _PlatformObject.GetAllPlatformFolders())
            {
                Console.WriteLine($"{ob.MediaType}: {ob.FolderPath}");
                boxLog.Text = boxLog.Text.Insert(0, $@"{ob.MediaType}: {ob.FolderPath}" + Environment.NewLine);
                dicSystemPaths.Add(ob.MediaType, ob.FolderPath);
            }
            //LBGame = IGame

            // FakeGenerator();
        }

        #region Debug
        public void DebugTest(IGame[] fakelist)
        {
            DebugMode = true;
            AppPath = @"I:\Frontend\LaunchBox\";
            _IPGames = fakelist;
            PlatformName = "Sega Mega Drive";
            _PlatformFolderRL = @"..\..\fauxgames\Games\Sega Mega Drive";
            _PlatformFolderHL = Path.GetFullPath(Path.Combine(AppPath, _PlatformFolderRL));

            // dicSystemPaths.Add("ApplicationPath");
            dicSystemPaths.Add("Manual", @"..\..\fauxgames\Manuals\Sega Mega Drive");
            dicSystemPaths.Add("Music", @"..\..\fauxgames\Music\Sega Mega Drive");
            dicSystemPaths.Add("Video", @"..\..\fauxgames\Manuals\Sega Mega Drive");
        }

        /// <summary>
        /// Makes fake list code for debugtest
        /// </summary>
        private void FakeGenerator()
        {
            boxLog.Text += Environment.NewLine;
            boxLog.Text += $"LBGame[] KingOfSpain = new LBGame[{_IPGames.Length}];" + Environment.NewLine;

            for (int i = 0; i < _IPGames.Length; i++)
            {
                var rameuh = _IPGames[i];
                var pseuRoot = @"I:\Frontend\LaunchBox\";

                var gamename = $"game_{i}";

                boxLog.Text += $"LBGame {gamename} = new LBGame();" + Environment.NewLine;
                boxLog.Text += $"{gamename}.Title= \"{rameuh.Title}\";" + Environment.NewLine;
                boxLog.Text += $"{gamename}.Id = \"{rameuh.Id}\";" + Environment.NewLine;
                boxLog.Text += $"{ gamename}.ApplicationPath = @\"{rameuh.ApplicationPath}\";" + Environment.NewLine;

                boxLog.Text += $"KingOfSpain[{i}] = {gamename};" + Environment.NewLine + Environment.NewLine;
            }
        }
        #endregion

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
            _AmVGames = MvGame.Convert(_IPGames, AppPath);

            //AnalyseProps(aMvGames);
            // Taille généralisée de la portion des chemins
            PathsWidth = AnalyseVPrinciple(_AmVGames);

            GenerateTitles(_AmVGames);

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

            // conversion en dur du lien vers le dossier actuel           
            string mahou = _PlatformFolderRL.Replace($@"\{PlatformName}", "");
            mahou = mahou.Substring(0, mahou.LastIndexOf('\\'));
            // mahou = Path.GetFullPath(Path.Combine(AppPath, mahou));
            this.tboxROldPath.Text = mahou;
            this.tboxHOldPath.Text = Path.GetFullPath(Path.Combine(AppPath, mahou));
        }

        #region Title
        /// <summary>
        /// Création des bandeaux de titre
        /// </summary>
        /// <param name="aMvGames"></param>
        private void GenerateTitles(MvGame[] aMvGames)
        {
            boxLog.Text = boxLog.Text.Insert(0, @"Creation of data graphic forms" + Environment.NewLine);
            flpGames.Controls.Clear();


            foreach (var mvGame in aMvGames)
            {
                toolStripStatusLabel1.Text = $"Création of bandeau: {mvGame.Title}";

                Console.WriteLine(mvGame.Title);

                GameBandeauV bdTmp = StyleTitles(mvGame.Id);
                bdTmp.Objet = mvGame;
                bdTmp.Title += $" {mvGame.Title}";
                bdTmp.Resize_Me();

                mvGame.Valide = CheckGame(mvGame);

                bdTmp.ShowVerif(mvGame.Valide);

                flpGames.Controls.Add(bdTmp);
                //bdTmp.Dock = DockStyle.Top;

                flpGames.Refresh();
                //lBandeaux.Add(bdTmp);
            }

            StyleMainFLP(ContRolledWidth);
            SetMainWindow();
        }

        /// <summary>
        /// Style des titres
        /// </summary>
        /// <param name="titre"></param>
        /// <returns></returns>
        private GameBandeauV StyleTitles(string titre)
        {
            int rightSpace = 10;

            GameBandeauV bdTmp = new GameBandeauV();
            bdTmp.Name = titre;

            bdTmp.DeroulBand += new GameBandeauV.DeroulHandler(DeroulBand);
            bdTmp.EnroulBand += EnroulBand;

            bdTmp.BackColor = Color.Crimson;

            //    bdTmp.Height = bdTmp
            BandHeight = bdTmp.Height + 2;
            bdTmp.AutoSize = false;
            //  = BandHeight = 54;
            bdTmp.Width = ContRolledWidth;

            // bdTmp.Height = 80;

            return bdTmp;
        }

        /// <summary>
        /// regarde si le dossier correspond
        /// </summary>
        /// <param name="mvGame"></param>
        /// <returns></returns>
        private bool CheckGame(MvGame mvGame)
        {
            bool valide = true;
            foreach (var pathO in mvGame.EnumGetPaths)
            {
                if (String.IsNullOrEmpty(pathO.Original_RLink)) continue;
                valide &= pathO.Original_RLink.Contains(tboxROldPath.Text);
            }
            return valide;
        }
        #endregion

        #region Graphismes Paths
        /// <summary>
        /// Genère les bandeaux de paths
        /// </summary>
        /// <param name="folders"></param>
        /// <returns></returns>
        private async Task GeneratePaths(GameBandeauV gameBand, MvGame game)
        {
            boxLog.Text = boxLog.Text.Insert(0, @"Creation of data graphic forms" + Environment.NewLine);

            //int largeurBandeau = AnalyseVPrinciple(game.GetPaths);


            //largeurBandeau = 850;

            foreach (var pathO in game.GetPaths)
            {
                if (string.IsNullOrEmpty(pathO.Original_RLink)) continue;

                DualBandV dbV = StylePaths(pathO.Type, PathsWidth);
                gameBand.flp1.Controls.Add(dbV);

                dbV.ucPaths21.RelatPath = pathO.Original_RLink;
                dbV.ucPaths21.FullPath = pathO.Original_HLink;

                dbV.ucPaths22.RelatPath = pathO.Destination_RLink;
                dbV.ucPaths22.FullPath = pathO.Destination_HLink;

            }
            gameBand.Resize_Me();
            // games.Add(bdTmp);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pathCollec"></param>
        private int AnalyseVPrinciple(MvGame[] mvGames)
        {
            boxLog.Text = boxLog.Text.Insert(0, @"AnalyseVPrinciple" + Environment.NewLine); ;

            int retour = 0;
            foreach (MvGame mvG in mvGames)
            {
                int lOrgRelat = Analyse.One_Col(x => x.Original_RLink, mvG.GetPaths, bRelatFont).Width;
                int lOrgHard = Analyse.One_Col(x => x.Original_HLink, mvG.GetPaths, bHardFont).Width;
                int lDestRelat = Analyse.One_Col(x => x.Destination_RLink, mvG.GetPaths, bRelatFont).Width;
                int lDestHard = Analyse.One_Col(x => x.Destination_HLink, mvG.GetPaths, bHardFont).Width;
                int tmp = Math.Max(lOrgRelat, Math.Max(lOrgHard, Math.Max(lDestRelat, lDestHard)));
                retour = tmp > retour ? tmp : retour;
            }
            //            int lType = Analyse.Rows(x => x.Type, pathCollec, new Label().Font).Width + 50;     // taille de l'image de retour

            return retour;
        }

        /*
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
        */
        /// <summary>
        /// Style des chemins
        /// </summary>
        /// <param name="MediaType"></param>
        /// <param name="lCols"></param>
        /// <returns></returns>
        private DualBandV StylePaths(string MediaType, int lCols)
        {
            int rightSpace = 10;

            DualBandV bdTmp = new DualBandV();
            bdTmp.Name = $"Bandeau - {MediaType}";
            bdTmp.Title = MediaType;
            bdTmp.Padding = new Padding(0, 1, 0, 1);
            bdTmp.BackColor = Color.AliceBlue;

            bdTmp.ElementsBgd = Color.White;
            //bdTmp.ElementsHeight = BandHeight = 60;
            // bdTmp.Height = BandHeight * 1;
            //bdTmp.BackColor = Color.FromArgb(50);

            // bdTmp.CategWidth = columns["MediaType"] + rightSpace; ;

            bdTmp.ucPaths21.TopFont = bHardFont;
            bdTmp.ucPaths21.BottomFont = bRelatFont;

            bdTmp.ucPaths22.TopFont = bHardFont;
            bdTmp.ucPaths22.BottomFont = bRelatFont;

            // int witdhMax = columns["UCP1"] > columns["UCP2"] ? columns["UCP1"] : columns["UCP2"];
            bdTmp.ucPaths21.Width = lCols + rightSpace; ;
            bdTmp.ucPaths22.Width = lCols + rightSpace; ;

            return bdTmp;
        }

        /// <summary>
        /// Rempli chaque flowlayout d'un jeu avec les informations relatives aux paths
        /// </summary>
        /// <param name="sender"></param>
        private void DeroulBand(GameBandeauV sender)
        {
            if (_BandActif != null && _BandActif != sender) _BandActif.Collapse_Fl();

            boxLog.Text = boxLog.Text.Insert(0, $"Bandactif: {sender.Name}" + Environment.NewLine); ;
            toolStripStatusLabel1.Text = $"Bandeau unrolled";

            _BandActif = sender;
            if (sender.flp1.Controls.Count == 0)
            {

                MvGame game = (MvGame)sender.Objet;

                GeneratePaths(sender, game);
                boxLog.Text = boxLog.Text.Insert(0, $"Generate graphical elements for '{game.Title}'" + Environment.NewLine); ;
            }

            if (sender.Width > ContUnrolledWidth)
            {
                ContUnrolledWidth = sender.Width;
            }
            else
            {
                sender.Width = ContUnrolledWidth;
            }

            // sender.Resize_Me();
            // flpGames.Width = sender.flp1.Width + 50;
            StyleMainFLP(ContUnrolledWidth);

            SetMainWindow();
        }

        private void EnroulBand(GameBandeauV sender)
        {
            statusStrip1.Text = ("EnroulBand");
            Console.WriteLine("EnroulBand");

            //    StyleMainFLP(ContRolledWidth);
        }

        #endregion

        #region Graph general
        /// <summary>
        /// Style du conteneur principal
        /// </summary>
        /// <param name="width"></param>
        private void StyleMainFLP(int widthsaispas)
        {
            boxLog.Text = boxLog.Text.Insert(0, @"Adaptation of layout background " + Environment.NewLine); ;

            //   flpGames.BackColor = Color.FromArgb(141, 177, 227);
            //ContWidth = flpGames.Controls[0].Width; // lBandeaux[0].Width;
            int largFLP = widthsaispas + 6;
            if (flpGames.VerticalScroll.Enabled) largFLP += 22;

            //_Cols.Sum(x => x.Value);
            // Height size of each item
            int minheightB = (BandHeight + 6) * 4;
            //int minH = Screen.PrimaryScreen.Bounds.Height < minheightB ? Screen.PrimaryScreen.Bounds.Height : minheightB;

            flpGames.Size = flpGames.MinimumSize = new Size(largFLP, flpGames.Height);

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


        private void ResizeTextBox(object sender, EventArgs e)
        {
            GraphFunc.ResizeTextBox(sender);
        }

        #endregion

        ///////// <summary>
        ///////// Analyse les propriétés de tout le tableau pour calculer la taille des colonnes
        ///////// </summary>
        ///////// <param name="pathCollec"></param>
        //////private Dictionary<string, int> AnalyseProps(PathsCollec[] pathCollec)
        //////{
        //////    boxLog.Text = boxLog.Text.Insert(0, @"Analysis of columns width" + Environment.NewLine); ;

        //////    Dictionary<string, int> columns = new Dictionary<string, int>();

        //////    // Name of the Media
        //////    //PropertyInfo propMedia = typeof(MvFolder).GetProperty("MediaType");
        //////    columns.Add("MediaType", Analyse.Rows(x => x.Type, pathCollec, new Label().Font).Width);

        //////    // OldPath            
        //////    Size sORelat = Analyse.Rows(x => x.Original_RLink, pathCollec, bRelatFont);
        //////    Size sOHard = Analyse.Rows(x => x.Original_HLink, pathCollec, bHardFont);

        //////    columns.Add("UCP1", sOHard.Width > sORelat.Width ? sOHard.Width : sORelat.Width);

        //////    // NewPath
        //////    Size sNRelat = Analyse.Rows(x => x.Destination_RLink, pathCollec, bRelatFont);
        //////    Size sNHard = Analyse.Rows(x => x.Destination_HLink, pathCollec, bHardFont);


        //////    columns.Add("UCP2", sNHard.Width > sNRelat.Width ? sNHard.Width : sNRelat.Width);

        //////    return columns;
        //////}

        #region simulation ++++++++++++++++++++++++++
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btSimul_Click(object sender, EventArgs e)
        {
            boxLog.Clear();
            foreach (var game in _AmVGames)
            {
                boxLog.Text += $@"{game.Title}: " + Environment.NewLine;

                foreach (var pathO in game.EnumGetPaths)
                {
                    if (string.IsNullOrEmpty(pathO.Original_RLink))
                    {
                        boxLog.Text += $@"type: {pathO.Type}: null" + Environment.NewLine;
                        continue;
                    }

                    boxLog.Text += Environment.NewLine + $@"type: {pathO.Type}: " + Environment.NewLine;


                    // modes
                    string fichier = "";
                    if (rbForced.Checked)
                    {
                        int pos = pathO.Original_RLink.LastIndexOf('\\');
                        fichier = pathO.Original_RLink.Substring(pos + 1); //+1 pour lever le \
                    }
                    else if (rbKeepSub.Checked)
                    {
                        int pos = pathO.Original_RLink.IndexOf($@"\{PlatformName}\");
                        fichier = pathO.Original_RLink.Substring(pos + PlatformName.Length + 2);
                    }
                    //

                    boxLog.Text += $@"&Donc {pathO.Original_RLink}" + Environment.NewLine;

                    //
                    string fileDest = "";
                    string rootPath = "";

                    switch (pathO.Type)
                    {
                        case "ApplicationPath":
                            rootPath = _PlatformFolderRL;
                            break;

                        case "ManualPath":
                            rootPath = dicSystemPaths["Manual"];
                            boxLog.Text += $@"ManualPath détecté " + Environment.NewLine;
                            break;

                        case "MusicPath":
                            rootPath = dicSystemPaths["Music"];
                            boxLog.Text += $@"MusicPath détecté " + Environment.NewLine;
                            break;

                        case "VideoPath":
                            rootPath = dicSystemPaths["Video"];
                            break;
                        #region
                        /*
                        case "CartBackImagePath":
                            rootPath = dicSystemPaths["Cart - Back"];
                            boxLog.Text.Insert(0, $"CartBackImagePath: {rootPath}" + Environment.NewLine);
                            break;

                        case "CartFrontImagePath":
                            rootPath = dicSystemPaths["Cart - Front"];
                            boxLog.Text.Insert(0, $"CartFrontImagePath: {rootPath}" + Environment.NewLine);
                            break;

                        case "Cart3DImagePath":
                            break;
                        case "BackgroundImagePath":
                            break;
                        case "Box3DImagePath":
                            break;
                        case "BackImagePath":
                            break;


                        case "MarqueeImagePath":
                        case "FrontImagePath":
                            rootPath = dicSystemPaths["Box - Front"];
                            break;

                        case "ScreenshotImagePath":
                            rootPath = dicSystemPaths["Screenshot - Gameplay"];
                            break;
                        case "ClearLogoImagePath":
                            rootPath = dicSystemPaths["Clear Logo"];
                            break;*/

                        #endregion
                        default:
                            boxLog.Text += $@"Non traité: {pathO.Type}: " + Environment.NewLine;
                            continue;

                    }

                    fileDest = Path.Combine(rootPath, fichier);
                    boxLog.Text += $@"{ fichier } => {fileDest}" + Environment.NewLine;

                    pathO.Destination_RLink = fileDest;
                    pathO.Destination_HLink = Path.GetFullPath(Path.Combine(AppPath, fileDest));
                }
            }

            GenerateTitles(_AmVGames);
            btSimul.Visible = false;
            btApply.Visible = true;
        }
        #endregion

        private void LaunchBoxMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }

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

            foreach (MvGame game in _AmVGames)
            {
                DematrioChka(game);
            }

            if (!DebugMode)
            {

                PluginHelper.DataManager.Save();
                MessageBox.Show(Lang.Save_Ok, Lang.Save_Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //FillInformation();
            GenerateTitles(_AmVGames);
            btApply.Visible = false;
            btSimul.Visible = true;
        }

        /// <summary>
        /// Envoie les paramètres aux originaux
        /// </summary>
        /// <remarks>n'utilise pas la partie graphique</remarks>
        private void DematrioChka(MvGame game)
        {
            // Cherchez dans tous les IGames
            IGame originalGame = null;
            foreach (IGame igame in _IPGames)
            {
                if (igame.Id.Equals(game.Id))
                {
                    originalGame = igame;
                    break;
                }
            }

            if (originalGame == null) return;


            // Passer tous les folders des mvGames dans IPGames
            foreach (var collecOPaths in game.EnumGetPaths)
            {
                switch (collecOPaths.Type)
                {
                    case "ApplicationPath":
                        originalGame.ApplicationPath = collecOPaths.Destination_RLink;
                        break;

                    case "ManualPath":
                        originalGame.ManualPath = collecOPaths.Destination_RLink;
                        break;

                    case "MusicPath":
                        originalGame.MusicPath = collecOPaths.Destination_RLink;
                        break;

                    case "VideoPath":
                        originalGame.VideoPath = collecOPaths.Destination_RLink;
                        break;

                }

                collecOPaths.Original_RLink = collecOPaths.Destination_RLink;
                collecOPaths.Original_HLink = collecOPaths.Destination_HLink;
                collecOPaths.Destination_HLink = collecOPaths.Destination_RLink = Lang.Waiting;
            }
        }

        #endregion
    }
}
