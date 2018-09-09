﻿using CleanImages.IHM;
using DxTBoxWPF.Images;
using DxTBoxWPF.MessageBox;
using DxTrace;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Unbroken.LaunchBox.Plugins;
using Unbroken.LaunchBox.Plugins.Data;

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
        static BasePlugin()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BasePlugin), new FrameworkPropertyMetadata(typeof(BasePlugin)));
            //_App = AppDomain.CurrentDomain.BaseDirectory;
            DxTrace.InfoToFile logFile = new InfoToFile(@".\Logs\Clean_Images.log", true);

            ITrace.AddListener(logFile);

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
            ITrace.WriteLine("On Selected");

            Launch(selectedGame);
            //  throw new NotImplementedException();
        }

        public void OnSelected(IGame[] selectedGames)
        {
            ITrace.WriteLine("On Selected[]");
            foreach (IGame game in selectedGames)
            {
                Launch(game);
            }
            // throw new NotImplementedException();
        }

        private void Launch(IGame game)
        {
            bool? res = DxMBox.ShowDial(Lang.Launch_Question, "Question", DxMBoxButtons.YesNo);
            ITrace.WriteLine($"Window Result: {res}");
            if (res == true)
            {
                // obsolète ? 


                ImageDetails[] images = game.GetAllImagesWithDetails();
                ITrace.WriteLine($"Images Found: {images.Length}");

                //ExtImageDetails[] extImages = ExtImageDetails.Convert(images);
                var extImages = Array.ConvertAll(images, item => (ExtImageDetails)item);

                Splash.Pop(images.Length);
                Calculate_MD5(extImages);


                Splash.CloseIt();

                // Scan des doublons;
                List<List<ExtImageDetails>> Doublons = Scan(extImages);

                // Traitement des doublons
                int i=1;
                foreach (var lDoublon in Doublons)
                {
                    ITrace.WriteLine($"{i} passe de doublons");
                    TreatDuplicates(lDoublon);
                    i++;
                }
            }
        }

        private async void Calculate_MD5(ExtImageDetails[] images)
        {
            ExtImageDetails[] extImages = new ExtImageDetails[images.Length];

            int i = 0;
            foreach (ExtImageDetails image in images)
            {

                //Debug.WriteLine($"[Md5] {image.FilePath}");
                ITrace.WriteLine($"[Md5] {image.ImageType}");
                ITrace.WriteLine($"[Md5] {image.Region}");
                ITrace.WriteLine($"[Md5] {image.FilePath}");
                ITrace.WriteLine("Calcul du md5");
                //extImages[i].Md5Sum = 
                image.Md5Sum = GetMD5HashFromFile(image.FilePath);
                ITrace.WriteLine($"[Md5] Somme: {image.Md5Sum}");


                ITrace.WriteLine();
                Splash.ProgressStatus = i;
                i++;

            }

        }

        private string GetMD5HashFromFile(string fileName)
        {
            try
            {
                using (var md5 = MD5.Create())
                {
                    using (var stream = File.OpenRead(fileName))
                    {
                        string hash = BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", string.Empty);
                        ITrace.WriteLine($"[GetMD5HashFromFile] hash : {hash}");
                        return hash;
                    }
                }
            }
            catch (Exception exc)
            {
                ITrace.WriteLine($"GetMd5HashFromFile: {exc}");
                throw new Exception($"Erreur en GetMD5HashFromFile\n {exc}");
            }
        }

        private List<List<ExtImageDetails>> Scan(ExtImageDetails[] extImages)
        {
            var toTreat = new List<List<ExtImageDetails>>();

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
                }
            }

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

            ITrace.WriteLine($"\n[GetDuplicates] Recherche de similitudes pour '{imRef.FilePath}', {imRef.Md5Sum}, {imRef.doublon} dans tableau de taille {extImages.Count}");

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

            if (similaire.Count <= 1) return null;

            return similaire;

        }

        private void TreatDuplicates(List<ExtImageDetails> extImages)
        {
            ITrace.WriteLine($"\n[TreatDuplicates] Traitement débuté pour: {extImages.Count} doublons");
            Duplicate_W handleW = new Duplicate_W();
            for (int i = 0; i < extImages.Count; i++)
            {
                if ((i+1)>extImages.Count)
                {
                    ITrace.WriteLine("[TreatDuplicates] Sortie");
                    break;
                }
                //var image = extImages[i].FilePath;
                ITrace.WriteLine($"[TreatDuplicates] {extImages[i].FilePath}");
                ITrace.WriteLine($"[TreatDuplicates] {extImages[i+1].FilePath}");

                handleW.SetLeftImage(extImages[i].FilePath);
                handleW.SetRightImage(extImages[i+1].FilePath);
                handleW.Show();
            }
        }
    }
}