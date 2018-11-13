using DxTrace;
using ManageImages.IHM;
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

namespace ManageImages
{
    /// <summary>
    /// Suivez les étapes 1a ou 1b puis 2 pour utiliser ce contrôle personnalisé dans un fichier XAML.
    ///
    /// Étape 1a) Utilisation de ce contrôle personnalisé dans un fichier XAML qui existe dans le projet actif.
    /// Ajoutez cet attribut XmlNamespace à l'élément racine du fichier de balisage où il doit 
    /// être utilisé :
    ///
    ///     xmlns:MyNamespace="clr-namespace:ManageImages"
    ///
    ///
    /// Étape 1b) Utilisation de ce contrôle personnalisé dans un fichier XAML qui existe dans un autre projet.
    /// Ajoutez cet attribut XmlNamespace à l'élément racine du fichier de balisage où il doit 
    /// être utilisé :
    ///
    ///     xmlns:MyNamespace="clr-namespace:ManageImages;assembly=ManageImages"
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

        public bool SupportsMultipleGames => false;

        public string Caption => "Manage Images...";

        public System.Drawing.Image IconImage => null;

        public bool ShowInLaunchBox => true;

        public bool ShowInBigBox => false;

        public bool GetIsValidForGame(IGame selectedGame)
        {
            return true;
        }

        public bool GetIsValidForGames(IGame[] selectedGames)
        {
            return true;
        }

        public void OnSelected(IGame selectedGame)
        {          


            Mouse.OverrideCursor = Cursors.Arrow;

#if DEBUG
            InfoToFile log = new InfoToFile(@".\Logs\ManageImages.log", true);
            ITrace.AddListener(log);
            try
            {
              //  ITrace.Clear();
            }
            catch (Exception exc2)
            {
                ITrace.WriteLine(exc2.ToString());
            }
#endif

            try
            {

                Manage_W mw = new Manage_W();
                mw.GameSelected = selectedGame;
                mw.ShowDialog();
            }
            catch(Exception exc)
            {
                ITrace.WriteLine(exc.ToString());
            }
        }

        public void OnSelected(IGame[] selectedGames)
        {

        }


    }
}
