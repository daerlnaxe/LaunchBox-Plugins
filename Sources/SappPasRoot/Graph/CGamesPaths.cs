using CCLaunchBox;
using SappPasRoot.Core;
using SappPasRoot.Languages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
    /*
     * Modification des chemins pour les fichiers
     * La partie simulation va stocker en mémoire le nouveau chemin d'accès
     */


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

        /// <summary>
        /// Dico contenant les pahts de la plateforme
        /// </summary>
        /// <remarks>Used by CheckGame, Simul</remarks>
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
            cbHidden.Checked = Properties.Settings.Default.ScanHiddenGames;

            //listView1.Items.Clear();
        }

        /// <summary>
        /// Event window launched
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CGamesPaths_Load(object sender, EventArgs e)
        {
            GrabMyShovel();
        }

        private void CGamesPaths_Shown(object sender, EventArgs e)
        {
        }

        internal void Initialization(IPlatform platform)
        {
            // PluginHelper.LaunchBoxMainForm.FormClosing += LaunchBoxMainForm_FormClosing;

            boxLog.Text += @"Initialization" + Environment.NewLine;
            Debug.WriteLine("[CGamePaths] Initialization");

            _PlatformObject = platform;

            // Application folder
            AppPath = AppDomain.CurrentDomain.BaseDirectory;

            // FakeGenerator();
        }

        #region Debug
        public void DebugTest(IPlatform fakePLat/*IGame[] fakelist*/)
        {
            Debug.WriteLine("[CGamePaths] DebugTest");

            DebugMode = true;
            AppPath = @"I:\Frontend\LaunchBox\";
            _PlatformObject = fakePLat;
            //_IPGames = fakelist;           

            /*
            // dicSystemPaths.Add("ApplicationPath");
            dicSystemPaths.Add("Application",@"..\..\fauxgames\Roms");
            dicSystemPaths.Add("Manual", @"..\..\fauxgames\Manuals\Sega Mega Drive");
            dicSystemPaths.Add("Music", @"..\..\fauxgames\Music\Sega Mega Drive");
            dicSystemPaths.Add("Video", @"..\..\fauxgames\Manuals\Sega Mega Drive");*/
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
        /// Called when windows is launched
        /// </summary>
        private void GrabMyShovel()
        {
            boxLog.Text += $@"Platform '{_PlatformObject.Name}' selected" + Environment.NewLine;
            Debug.WriteLine($"[CGamePaths] [GrabMyShovel] Initialisation");

            PlatformName = _PlatformObject.Name;

            // Construction des informations
            FillInformation();

            // Construction du dictionnaire des dossiers de la plateforme
            Debug.WriteLine($"[Init - CGameP] [Application]: '{_PlatformFolderRL}'");
            dicSystemPaths.Add("Application", _PlatformFolderRL);
            foreach (var ob in _PlatformObject.GetAllPlatformFolders())
            {
                Debug.WriteLine($"[Init - CGameP] [{ob.MediaType}]: '{ob.FolderPath}'");
                //boxLog.Text += $@"{ob.MediaType}: {ob.FolderPath}" + Environment.NewLine;
                dicSystemPaths.Add(ob.MediaType, ob.FolderPath);
            }

            // Assignation du dernier chemin visité
            if (string.IsNullOrEmpty(Properties.Settings.Default.LastKPath))
            {
                Properties.Settings.Default.LastKPath = _PlatformFolderHL;
            }

            GetGames();
            cbHidden.Enabled = true;
        }

        /// <summary>
        /// Récupère les jeux et met en forme
        /// </summary>
        private async void GetGames()
        {

            // Récupération des jeux avec tri        
            _IPGames = _PlatformObject.GetAllGames(cbHidden.Checked, true)//(false, false)
                                                          .OrderBy(x => x.Title).ToArray();


            // Conversion to MvGame
            _AmVGames = MvGame.Convert(_IPGames, AppPath);

            //AnalyseProps(aMvGames);
            // Taille généralisée de la portion des chemins
            PathsWidth = AnalyseVPrinciple(_AmVGames);

            await GenerateTitles(_AmVGames);
        }


        /// <summary>
        /// Rempli les champs d'information et initialise certaines variables communes
        /// </summary>
        private void FillInformation()
        {
            boxLog.Text += @"Filling of information fields" + Environment.NewLine;
            boxLog.Text += @"Transformation RelatLink To HardLink " + Environment.NewLine;

            _PlatformFolderRL = _PlatformObject.Folder;
            _PlatformFolderHL = Path.GetFullPath(Path.Combine(AppPath, _PlatformFolderRL));

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
        private async Task GenerateTitles(MvGame[] aMvGames)
        {
            boxLog.Text += @"Creation of data graphic forms" + Environment.NewLine;
            Debug.WriteLine("[CGamePaths] GenerateTitles");
            Debug.Indent();

            flpGames.Controls.Clear();

            foreach (MvGame mvGame in aMvGames)
            {
                /*
                if (!cbHidden.Checked && mvGame.Hide)
                {
                    Debug.WriteLine($"[GenerateTitles] {mvGame.Title} hidden => pass");
                    continue;
                }*/

                toolStripStatusLabel1.Text = $"Création of bandeau: '{mvGame.Title}'";
                Debug.WriteLine($"[GenerateTitles] Creation of the '{mvGame.Title}' banner");

                GameBandeauV bdTmp = StyleTitles(mvGame.Id);
                bdTmp.Objet = mvGame;
                bdTmp.Title = $" {mvGame.Title}";
                if (mvGame.Hide) bdTmp.Title += " (Hidden)";
                if (mvGame.Broken) bdTmp.Title += " (Broken)";

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

            Debug.Unindent();
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

                Debug.WriteLine($"[CheckGame] {pathO.Type}: {pathO.Original_RLink}");
                switch (pathO.Type)
                {
                    case EnumPathType.ApplicationPath:
                        Debug.WriteLine($"[CheckGame] Dico[Application]: {dicSystemPaths["Application"]}");
                        valide &= pathO.Original_RLink.Contains(dicSystemPaths["Application"]);
                        break;

                    case EnumPathType.ManualPath:
                        Debug.WriteLine($"[CheckGame] Dico[Manual]: {dicSystemPaths["Manual"]}");
                        valide &= pathO.Original_RLink.Contains(dicSystemPaths["Manual"]);
                        break;

                    case EnumPathType.MusicPath:
                        Debug.WriteLine($"[CheckGame] Dico[Music]: {dicSystemPaths["Music"]}");
                        valide &= pathO.Original_RLink.Contains(dicSystemPaths["Music"]);
                        break;

                    case EnumPathType.VideoPath:
                        Debug.WriteLine($"[CheckGame] Dico[Video]: {dicSystemPaths["Video"]}");
                        valide &= pathO.Original_RLink.Contains(dicSystemPaths["Video"]);
                        break;
                }


                //                valide &= pathO.Original_RLink.Contains(tboxROldPath.Text);
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
            Debug.WriteLine($"[GeneratePaths] Creation of the banner for {game.Title}");
            boxLog.Text += $"Creation of the banner for { game.Title}" + Environment.NewLine;

            //int largeurBandeau = AnalyseVPrinciple(game.GetPaths);


            //largeurBandeau = 850;

            foreach (var pathO in game.GetPaths)
            {
                Debug.WriteLine($"[GeneratePaths] Path {pathO.Type}: {pathO.Original_RLink}");
                if (string.IsNullOrEmpty(pathO.Original_RLink)) continue;

                DualBandV dbV = StylePaths(nameof(pathO.Type), PathsWidth);
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
            boxLog.Text += @"AnalyseVPrinciple" + Environment.NewLine;

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

            boxLog.Text += $"Bandactif: {sender.Name}" + Environment.NewLine;
            toolStripStatusLabel1.Text = $"Bandeau unrolled";

            _BandActif = sender;
            if (sender.flp1.Controls.Count == 0)
            {

                MvGame game = (MvGame)sender.Objet;

                GeneratePaths(sender, game);
                boxLog.Text += $"Generate graphical elements for '{game.Title}'" + Environment.NewLine;
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
            boxLog.Text += @"Adaptation of layout background " + Environment.NewLine;

            //   flpGames.BackColor = Color.FromArgb(141, 177, 227);
            //ContWidth = flpGames.Controls[0].Width; // lBandeaux[0].Width;
            int largFLP = widthsaispas + 6;
            if (flpGames.VerticalScroll.Enabled) largFLP += 22;

            //_Cols.Sum(x => x.Value);
            // Height size of each item
            int minheightB = (BandHeight + 6) * 2;
            //int minH = Screen.PrimaryScreen.Bounds.Height < minheightB ? Screen.PrimaryScreen.Bounds.Height : minheightB;

            flpGames.Size = flpGames.MinimumSize = new Size(largFLP, flpGames.Height);

        }


        private void SetMainWindow()
        {

            boxLog.Text += @"Adaptation of window " + Environment.NewLine;
            int largr = flpGames.Width + 40;
            int hautr = flpGames.Height + boxLog.Height + tlpInfos.Height + 200;

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


        private void CheckedChanged(object sender, EventArgs e)
        {
            RadioButton cb = (RadioButton)sender;
            if (cb.Checked)
            {
                btApply.Visible = false;
                btSimul.Visible = true;
            }
        }

        #endregion

        ///////// <summary>
        ///////// Analyse les propriétés de tout le tableau pour calculer la taille des colonnes
        ///////// </summary>
        ///////// <param name="pathCollec"></param>
        //////private Dictionary<string, int> AnalyseProps(PathsCollec[] pathCollec)
        //////{
        //////    boxLog.Text +=@"Analysis of columns width" + Environment.NewLine); ;

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
            boxLog.Text += "Simulation" + Environment.NewLine;
            AlterPath();
            GenerateTitles(_AmVGames);
            btSimul.Visible = false;
            btApply.Visible = true;
            boxLog.Text += "End of Simulation" + Environment.NewLine;
        }

        /// <summary>
        /// Change Destination paths (relat and hard) to show in simulate mode the result
        /// </summary>
        private void AlterPath()
        {
            Debug.WriteLine("");
            foreach (var game in _AmVGames)
            {
                Debug.WriteLine($@"{game.Title}: ");

                // say mode
                if (rbForced.Checked) Debug.WriteLine("Forced mode");
                else if (rbKeepSub.Checked) Debug.WriteLine("KeepSub mode");

                Debug.Indent();

                // On examine tous les chemins, et en fonction du type on modifie les destinations
                foreach (PathsCollec pathO in game.EnumGetPaths)
                {
                    Debug.Write($@"type: {pathO.Type}: ");

                    // On passe si le chemin d'origine est vide
                    if (string.IsNullOrEmpty(pathO.Original_RLink))
                    {
                        Debug.WriteLine("null");
                        continue;
                    }

                    Debug.WriteLine($@"{pathO.Original_RLink}");

                    // modes
                    string fichier = "";    // Récupération du nom du fichier ?
                    if (rbForced.Checked)       // mode forcé
                    {
                        int pos = pathO.Original_RLink.LastIndexOf('\\');
                        fichier = pathO.Original_RLink.Substring(pos + 1); //+1 pour lever le \
                    }
                    else if (rbKeepSub.Checked) // Mode conservant les sous-dossiers 
                    {
                        int pos = pathO.Original_RLink.IndexOf($@"\{PlatformName}\");
                        fichier = pathO.Original_RLink.Substring(pos + PlatformName.Length + 2);
                    }

                    //
                    string fileDest = "";
                    string rootPath = "";

                    switch (pathO.Type)
                    {
                        case EnumPathType.ApplicationPath:
                            //  rootPath = _PlatformFolderRL;
                            rootPath = dicSystemPaths["Application"];

                            break;

                        case EnumPathType.ManualPath:
                            rootPath = dicSystemPaths["Manual"];
                            break;

                        case EnumPathType.MusicPath:
                            rootPath = dicSystemPaths["Music"];
                            break;

                        case EnumPathType.VideoPath:
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
                            Debug.WriteLine("!!! Untreated");
                            continue;

                    }
                    Debug.Unindent();

                    fileDest = Path.Combine(rootPath, fichier);
                    Debug.WriteLine($@"{ fichier } => {fileDest}");

                    pathO.Destination_RLink = fileDest;
                    pathO.Destination_HLink = Path.GetFullPath(Path.Combine(AppPath, fileDest));
                }

                #region 2020

                // Si la fonctoin pour modifier aussi les romx mixed n'est pas activée on passe
                if (cbAddAppPaths.Checked != true)
                    continue;

                // Modifications sur les chemins des roms mixed
                foreach (PathsCollec addiAppPath in game.AddiRomPaths)
                {
                    // modes
                    string fichier = "";    // Récupération du nom du fichier ?
                    if (rbForced.Checked)       // mode forcé
                    {
                        int pos = addiAppPath.Original_RLink.LastIndexOf('\\');
                        fichier = addiAppPath.Original_RLink.Substring(pos + 1); //+1 pour lever le \
                    }
                    else if (rbKeepSub.Checked) // Mode conservant les sous-dossiers 
                    {
                        int pos = addiAppPath.Original_RLink.IndexOf($@"\{PlatformName}\");
                        fichier = addiAppPath.Original_RLink.Substring(pos + PlatformName.Length + 2);
                    }

                    string fileDest = Path.Combine(dicSystemPaths["Application"], fichier);
                    addiAppPath.Destination_RLink = fileDest;
                    addiAppPath.Destination_HLink = Path.GetFullPath(Path.Combine(AppPath, fileDest));

                    boxLog.Text += $"2020 : {addiAppPath.Original_RLink} => {addiAppPath.Destination_RLink}" + Environment.NewLine;
                    boxLog.Text += $"2020 : {addiAppPath.Original_HLink} => {addiAppPath.Destination_HLink}" + Environment.NewLine;

                }
                #endregion --- 2020
            }
        }
        #endregion

        private void LaunchBoxMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }

        #region Application des changements ---------------------------------------------------

        /// <summary>
        /// Modification des datas - Datas modification
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btApply_Click(object sender, EventArgs e)
        {
            ApplyChanges();
        }

        /// <summary>
        /// Method called by click on "Apply" button
        /// </summary>
        private void ApplyChanges()
        {
            boxLog.Text += @"[ApplyChanges] Process start ..." + Environment.NewLine;
            Debug.WriteLine($"[GamePaths] [ApplyChanges]");
            Debug.Indent();

            foreach (MvGame game in _AmVGames)
            {
                //
                if (game.Valide)
                {
                    Debug.WriteLine($"[GamePaths] [ApplyChanges] {game.Title}: is already valid => pass");
                    continue;
                }

                DematrioChka(game);
            }

            Debug.Unindent();

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
            Debug.WriteLine($"[GamePaths] [DematrioChka] {game.Title}");
            Debug.Indent();

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


            // Passer tous les dossiers cibles des mvGames dans IPGames
            foreach (PathsCollec collecOPaths in game.EnumGetPaths)
            {
                switch (collecOPaths.Type)
                {
                    case EnumPathType.ApplicationPath:
                        originalGame.ApplicationPath = collecOPaths.Destination_RLink;
                        break;

                    case EnumPathType.ManualPath:
                        originalGame.ManualPath = collecOPaths.Destination_RLink;
                        break;

                    case EnumPathType.MusicPath:
                        originalGame.MusicPath = collecOPaths.Destination_RLink;
                        break;

                    case EnumPathType.VideoPath:
                        originalGame.VideoPath = collecOPaths.Destination_RLink;
                        break;

                }

                collecOPaths.Original_RLink = collecOPaths.Destination_RLink;
                collecOPaths.Original_HLink = collecOPaths.Destination_HLink;
                collecOPaths.Destination_HLink = collecOPaths.Destination_RLink = Lang.Waiting;
            }

            #region 2020 Prise en charge des mixed roms
            foreach(var oMixedRoms in originalGame.GetAllAdditionalApplications())
            {

            }
            #endregion

            Debug.Unindent();
        }

        #endregion


        private void btRescan_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ScanHiddenGames = cbHidden.Checked;
            Properties.Settings.Default.Save();
            GetGames();
        }

        private void cbHidden_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
