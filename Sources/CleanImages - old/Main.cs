using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unbroken.LaunchBox.Plugins;
using Unbroken.LaunchBox.Plugins.Data;
using DxTrace;
using DxTBoxWpf.MessageBox;

namespace CleanImages
{
    public class Main : IGameMenuItemPlugin
    {
        private string _App;

        public Main()
        {
            _App = AppDomain.CurrentDomain.BaseDirectory;
            DxTrace.InfoToFile logFile = new InfoToFile(@".\Logs\Clean_Images.log", false);

            ITrace.AddListener(logFile);                        

            ITrace.WriteLine($"\n {new string('=', 10)} Initialization {new string('=', 10)}");
        }


        public bool SupportsMultipleGames => true;

        // Titre
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
