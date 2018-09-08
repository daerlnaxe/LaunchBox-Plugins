using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unbroken.LaunchBox.Plugins;
using Unbroken.LaunchBox.Plugins.Data;
using DxTrace;
using

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

            dx
            
            //  throw new NotImplementedException();
        }

        public void OnSelected(IGame[] selectedGames)
        {
            ITrace.WriteLine("On Selected[]");

            // throw new NotImplementedException();
        }
    }
}
