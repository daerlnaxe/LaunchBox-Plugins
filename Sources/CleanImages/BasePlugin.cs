using DxTBoxWpf.MessageBox;
using DxTrace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        }

        public bool SupportsMultipleGames => true;

        public string Caption => "testc";

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
            bool? res = DxMBox.Show(Lang.Launch_Question, "Question", DxMBoxButtons.YesNo);
            ITrace.WriteLine($"Window Result: {res}");

            // obsolète ? 
            ImageDetails[] images = game.GetAllImagesWithDetails();

            ITrace.WriteLine($"Images Found: {images.Length}");
            foreach (ImageDetails image in images)
            {
                ITrace.WriteLine(image.ImageType);
                ITrace.WriteLine(image.Region);
                ITrace.WriteLine(image.FilePath);
                ITrace.WriteLine();
            }


            /*
            ITrace.WriteLine($"Méthode algo2");

            List<string> stringImages = new List<string>();
            
            var platform = PluginHelper.DataManager.GetPlatformByName(game.Platform);
            IPlatformFolder[] folders = platform.GetAllPlatformFolders();
            foreach (var folder in folders)
            {
                ITrace.WriteLine($"Folder: {folder.MediaType}");
                ITrace.WriteLine($"Folder: {folder.FolderPath}");

            }
            */
        }
    }
}
