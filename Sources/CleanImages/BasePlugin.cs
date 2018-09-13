using Unbroken.LaunchBox.Plugins;
using Unbroken.LaunchBox.Plugins.Data;
using DxTrace;
//using CleanImages.IHM;
using DxTBoxWPF.Images;
using DxTBoxWPF.Cont;
using DxTBoxWPF.MBox;
using DxTBoxWPF.Progress;
using CleanImages.Languages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Threading;
using DxTBoxWPF.Collec;
using DxTBoxWPF.Common;

namespace CleanImages
{
    /// <summary>
    /// Suivez les étapes 1a ou 1b puis 2 pour utiliser ce contrôle personnalisé dans un fichier XAML.
    ///
    /// Étape 1a) Utilisation de ce contrôle personnalisé dans un fichier XAML qui existe dans le projet actif.
    /// Ajoutez cet attribut XmlNamespace à l'élément racine du fichier de balisage où il doit 
    /// être utilisé :
    ///
    ///     xmlns:MyNamespace="clr-namespace:CleanImages"
    ///
    ///
    /// Étape 1b) Utilisation de ce contrôle personnalisé dans un fichier XAML qui existe dans un autre projet.
    /// Ajoutez cet attribut XmlNamespace à l'élément racine du fichier de balisage où il doit 
    /// être utilisé :
    ///
    ///     xmlns:MyNamespace="clr-namespace:CleanImages;assembly=CleanImages"
    ///
    /// Vous devrez également ajouter une référence du projet contenant le fichier XAML
    /// à ce projet et regénérer pour éviter des erreurs de compilation :
    ///
    ///     Cliquez avec le bouton droit sur le projet cible dans l'Explorateur de solutions, puis sur
    ///     "Ajouter une référence"->"Projets"->[Sélectionnez ce projet]
    ///
    ///
    /// Étape 2)
    /// Utilisez à présent votre contrôle dans le fichier XAML.
    ///
    ///     <MyNamespace:CustomControl1/>
    ///
    /// </summary>
    public class BasePlugin : Control, IGameMenuItemPlugin
    {
        bool StopAll { get; }
        /*public event Action<int> CurrentPosition;
        public event Action<int> MaxProgress;
        public event Action CurrentTotal;
        public event Action<string> CurrentOperation;*/

        /// <summary>
        /// Window for multiple games
        /// </summary>
        DxCollecProgress cProgress;

        static BasePlugin()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BasePlugin), new FrameworkPropertyMetadata(typeof(BasePlugin)));
            //_App = AppDomain.CurrentDomain.BaseDirectory;
#if DEBUG
            InfoToFile logFile = new InfoToFile(@".\Logs\Clean_Images.log", true);
            ITrace.AddListener(logFile);
            ITrace.WriteLine("DebugMode");
#endif

            ITrace.WriteLine($"\n {new string('=', 10)} Initialization {new string('=', 10)}");
        }

        public bool SupportsMultipleGames => true;

        public string Caption => Lang.Title_Menu;

        public System.Drawing.Image IconImage => null;

        public bool ShowInLaunchBox => true;

        public bool ShowInBigBox => false;

        // Intervient avant selected, possibilité de restreindre aux roms, à voir
        public bool GetIsValidForGame(IGame selectedGame)
        {
            ITrace.WriteLine("GetIsValidForGames");
            return true;
            //  throw new NotImplementedException();
        }

        public bool GetIsValidForGames(IGame[] selectedGames)
        {
            ITrace.WriteLine("GetIsValidForGames[]");
            return true;

            // throw new NotImplementedException();
        }


        public void OnSelected(IGame selectedGame)
        {
            Mouse.OverrideCursor = Cursors.Arrow;
            ITrace.WriteLine("On Selected");

            bool? res = DxMBox.ShowDial(Lang.Launch_Question, "Question", DxButtons.YesNo);
            ITrace.WriteLine($"Window Result: {res}");
            try
            {
                if (res == true)
                {
                    Launch4One(selectedGame);
                }
            }
            catch (Exception exc)
            {
                ITrace.WriteLine(exc.ToString());
            }
        }


        public void OnSelected(IGame[] selectedGames)
        {
            Mouse.OverrideCursor = Cursors.Arrow;
            ITrace.WriteLine("On Selected[]");

            try
            {
                DxMCollec WCollec = new DxMCollec();
                WCollec.SetCollection<IGame>(selectedGames);
                WCollec.SetDisplay("Title");

                if (WCollec.ShowDialog() == true)
                {
                    LaunchThem(selectedGames);
                }
            }
            catch (Exception exc)
            {
                ITrace.WriteLine(exc.ToString());
            }
            // throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        private bool Launch4One(IGame game)
        {
            ITrace.WriteLine($"[Launch] process for {game.Title}");

            ImageDetails[] images = game.GetAllImagesWithDetails();
            ITrace.WriteLine($"[Launch] Images Found: {images.Length}");

            //ExtImageDetails[] extImages = ExtImageDetails.Convert(images);
            var extImages = Array.ConvertAll(images, item => (ExtImageDetails)item);

            // A améliorer
            //Splash.Pop(images.Length);

            Md5Func Md5Job = new Md5Func();
            Md5Job.CurrentPosition += (x) => { DxProgressB1.SCurrentProgress = x; };

            Task t1 = Task.Run(() => Md5Job.Calculate_MD5(extImages, 10));
            t1.ContinueWith((antecedant) => DxProgressB1.AsyncCloseIt());

            //Calculate_MD5(extImages);

            // La fenêtre bloque la suite tant qu'elle n'est pas fermée
            DxProgressB1.ModalShow("CleanImages - Calculate MD5", images.Length);


            ITrace.WriteLine("Fin de Calculate Md5");

            // Scan des doublons;
            List<List<ExtImageDetails>> Doublons = Scan(extImages);


            int dNumber = Doublons.Count();

            if (dNumber < 1)
            {
                DxMBox.ShowDial($"{Lang.Duplicate_No_Res}: {game.Title}", Lang.Scan_Title, DxButtons.Ok);
            }

            //ManualProcess
            PManualDuplicates(Doublons, game);

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="games"></param>
        /// <returns></returns>
        private async Task<bool> LaunchThem(IGame[] games)
        {
            ITrace.WriteLine("[LaunchThem] Begin");

            cProgress = new DxCollecProgress();
            cProgress.SetCollection<IGame>(games, "Title");
            //cProgress.CurrentTotal = 100;
            cProgress.MaxProgress = 100;
            cProgress.MaxTotal = games.Length;
            Dictionary<IGame, List<List<ExtImageDetails>>> AllDoublons = new Dictionary<IGame, List<List<ExtImageDetails>>>();

            cProgress.Show();
            bool poursuite = false;

            foreach (IGame game in games)
            {
                ITrace.WriteLine($"[Launch] process for {game.Title}");
                cProgress.CurrentOP = Lang.Search_Images;

                ImageDetails[] images = game.GetAllImagesWithDetails();
                ITrace.WriteLine($"[Launch] Images Found: {images.Length}");
                cProgress.MaxProgress = images.Length;

                var extImages = Array.ConvertAll(images, item => (ExtImageDetails)item);

                Md5Func Md5Job = new Md5Func();
                ITrace.WriteLine($"[LaunchThem] {Lang.Md5_Begin}\n");
                cProgress.CurrentOP = Lang.Md5_Begin;

                Md5Job.CurrentPosition += (x) => { cProgress.CurrentProgress = x; };
                Md5Job.CurrentPosition += (x) => { Console.WriteLine("md5job " + x); };
                await Md5Job.Calculate_MD5(extImages, 10);
                ITrace.WriteLine("après md5 await");

                #region Scan des doublons;
                cProgress.CurrentOP = Lang.Duplicate_Begin;
                ITrace.WriteLine($"[LaunchThem] {Lang.Duplicate_Begin}");

                List<List<ExtImageDetails>> doublons = Scan(extImages);

                cProgress.CurrentTotal++;

                int dNumber = doublons.Count();
                if (dNumber < 1)
                {
                    cProgress.SetCurrentFinished(Lang.Duplicate_No_Res);
                    ITrace.WriteLine($"[LaunchThem] {Lang.Duplicate_No_Res}");
                    continue;
                }
                #endregion

                if (cProgress.StopIt)
                {
                    ITrace.WriteLine("[LaunchThem] Stopped by user");
                    cProgress.Close();
                    return false;
                }

                //ManualProcess
                bool resDupli= PManualDuplicates(doublons, game);
                ITrace.WriteLine($"Resultat de resDupli {resDupli}");
                if (!resDupli)
                {
                    ITrace.WriteLine("[LaunchThem] Stopped by user 2");
                    cProgress.Close();
                    return false;
                }
                               
                cProgress.SetCurrentFinished("");
            }
            return true;

            Task t1 = Task
                .Run(() => LaunchThemProcess(games, AllDoublons))
                .ContinueWith((tResult) =>
                {

                    if (!tResult.Result)
                    {
                        ITrace.WriteLine("Task aborded");
                        cProgress.AsyncClose();


                    }

                    if (tResult.Result)
                    {
                        ITrace.WriteLine("Task ended normally");
                        cProgress.AsyncClose();
                        poursuite = true;

                    }
                });


            cProgress.ShowDialog();

            if (!poursuite) return poursuite;

            ITrace.WriteLine("Taille du dico" + AllDoublons.Count());
            if (AllDoublons.Count() < 1) DxMBox.ShowDial("No doublon", "info", DxButtons.Ok);

            // Traitement manuel
            bool res;
            foreach (IGame game in games)
            {
                res = PManualDuplicates(AllDoublons[game], game);
                if (!res) break;
            }

            ITrace.WriteLine("[LaunchThem] End");
            return true;
        }

        /// <summary>
        /// Core for LaunchThem
        /// </summary>
        /// <param name="games"></param>
        private async Task<bool> LaunchThemProcess(IGame[] games, Dictionary<IGame, List<List<ExtImageDetails>>> AllDoublons)
        {

            foreach (IGame game in games)
            {
                ITrace.WriteLine($"\n[LaunchThem] process for {game.Title}");
                cProgress.CurrentOP = Lang.Search_Images;
                cProgress.CurrentTotal++;

                ImageDetails[] images = game.GetAllImagesWithDetails();
                ITrace.WriteLine($"[LaunchThem] Images Found: {images.Length}");
                cProgress.MaxProgress = images.Length;

                var extImages = Array.ConvertAll(images, item => (ExtImageDetails)item);

                #region md5
                Md5Func Md5Job = new Md5Func();
                Md5Job.CurrentPosition += (x) => { cProgress.CurrentProgress = x; };
                ITrace.WriteLine($"[LaunchThem] {Lang.Md5_Begin}\n");

                cProgress.CurrentOP = Lang.Md5_Begin;

                //await Task.Run(() => 
                await Md5Job.Calculate_MD5(extImages, 10);//);

                cProgress.CurrentOP = Lang.Md5_End;
                ITrace.WriteLine($"[LaunchThem] {Lang.Md5_End} \n");
                #endregion md5

                #region Scan des doublons;
                cProgress.CurrentOP = Lang.Duplicate_Begin;
                ITrace.WriteLine($"[LaunchThem] {Lang.Duplicate_Begin}");

                List<List<ExtImageDetails>> doublons = Scan(extImages);
                AllDoublons.Add(game, doublons);

                /*
                int dNumber = Doublons.Count();
                if (dNumber < 1)
                {

                    dxCProgress.AsyncSetCurrentFinished(Lang.Duplicate_No_Res);
                    ITrace.WriteLine($"[LaunchThem] {Lang.Duplicate_No_Res}");
                    continue;
                }

                dxCProgress.CurrentOP = Lang.Duplicate_End;
                ITrace.WriteLine($"[LaunchThem] {Lang.Duplicate_End}");*/
                #endregion


                cProgress.AsyncSetCurrentFinished("");
                if (cProgress.StopIt) return false;

            }
            return true;
        }

        /// <summary>
        /// Search duplicates for each sum
        /// </summary>
        /// <param name="extImages"></param>
        /// <returns></returns>
        private List<List<ExtImageDetails>> Scan(ExtImageDetails[] extImages)
        {
            ITrace.Indent++;
            ITrace.WriteLine("[Scan] Begin");
            var toTreat = new List<List<ExtImageDetails>>();
            int nbToTreat = 0;

            // copy of extImages
            List<ExtImageDetails> extCopy = extImages.ToList();

            //ExtImageDetails[] extICopy = ExtImageDetails.ArrayCopy(extImages);

            foreach (ExtImageDetails image in extImages)
            {

                if (image.doublon)
                {
                    ITrace.WriteLine($"[Scan] déjà scanné => pass ('{image.FilePath}')");
                    continue;
                }

                if (String.IsNullOrEmpty(image.Md5Sum)) continue;

                var doublons = GetDuplicates(image, extCopy);

                if (doublons != null)
                {
                    ITrace.WriteLine($"[Scan] doublons = {doublons}");
                    toTreat.Add(doublons);
                    nbToTreat = toTreat.Count();
                }
            }

            ITrace.WriteLine($"[Scan] End: {nbToTreat}");
            ITrace.Indent--;
            return toTreat;
        }

        /// <summary>
        /// Scanne une liste en fonction d'une référence
        /// </summary>
        /// <remarks>Enlève le premier élement qui est la référence pour réduire la liste</remarks>
        /// <remarks>Enlève le doublon trouvé</remarks>
        /// <remarks>Positionne le booléan doublon à true si occurence trouvée pour que la liste de référence passe par la suite</remarks>
        /// <param name="imRef"></param>
        /// <param name="extImages"></param>
        /// <returns></returns>
        private List<ExtImageDetails> GetDuplicates(ExtImageDetails imRef, List<ExtImageDetails> extImages)
        {
            List<ExtImageDetails> similaire = new List<ExtImageDetails>();
            similaire.Add(imRef);       // On ajoute en référence
            extImages.RemoveAt(0);      // On lève le premier élement qui est en cours d'exam;

            ITrace.Indent++;
            ITrace.WriteLine($"[GetDuplicates] Recherche de similitudes pour '{imRef.FilePath}', {imRef.Md5Sum}, {imRef.doublon} dans tableau de taille {extImages.Count}");

            for (int i = 0; i < extImages.Count; i++)
            {
                ExtImageDetails image = extImages[i];
                ITrace.WriteLine($"Examen de element { i}, {image.FilePath}");

                // Passer sur les images déjà repérées
                //   if (image.doublon) continue;
                try
                {
                    if (image.Md5Sum.Equals(imRef.Md5Sum))
                    {
                        extImages[i].doublon = true;
                        extImages.RemoveAt(i);
                        similaire.Add(image);
                        ITrace.WriteLine($"[GetDuplicates] similitude '{image.FilePath}', {image.Md5Sum} ajoutée");
                        i--;
                    }
                }
                catch (Exception exc)
                {
                    ITrace.WriteLine($"[GetDuplicates] Erreur {exc}");
                }
            }


            ITrace.WriteLine($"[GetDuplicates] Nombre d'occurence(s) trouvée(s): {similaire.Count}");
            ITrace.Indent--;
            if (similaire.Count <= 1) return null;

            return similaire;

        }

        private bool PManualDuplicates(List<List<ExtImageDetails>> Doublons, IGame game)
        {
            int ii = 1;
            int dNumber = Doublons.Count();

            ITrace.WriteLine("[PManualDuplicates] Traitement des doublons");
            // Traitement des doublons
            foreach (var lDoublon in Doublons)
            {
                Duplicate_W duplicate_W = new Duplicate_W();
                duplicate_W.ForceCursor = true;
                duplicate_W.Title = $"Clean Images - {ii}/{dNumber}";
                duplicate_W.SetHash(lDoublon[0].Md5Sum);

                ITrace.WriteLine($"[PManualDuplicates] Nombre de doublons ayant la somme {lDoublon[0].Md5Sum}: {dNumber}");
                foreach (ExtImageDetails extImage in lDoublon)
                {
                    ITrace.WriteLine($"[PManualDuplicates] Add To Queue: {extImage.FilePath}");
                    duplicate_W.QImages.Enqueue(new DxImage(extImage.ImageType, extImage.FilePath));
                }

                ITrace.WriteLine($"[PManualDuplicates] {ii} passe de doublons");

                duplicate_W.SetMainTitle(game.Title);
                //var res = duplicate_W.Dispatcher?.Invoke(duplicate_W.ShowDialog);
                var res = duplicate_W.ShowDialog();
                ITrace.WriteLine($"Resultat de duplicate show dialog {res}");
                // Stop process
                if (res == false)
                {
                    ITrace.WriteLine($"[PManualDuplicate] Arrêt utilisateur");
                    return false;
                }

                ii++;
            }
            return true;
        }

    }
}
