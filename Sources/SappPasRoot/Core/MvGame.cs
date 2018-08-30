using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unbroken.LaunchBox.Plugins;
using Unbroken.LaunchBox.Plugins.Data;

namespace SappPasRoot.Core
{
    class MvGame
    {


        public string Title { get; set; }
        public string ApplicationPath { get; set; }

        public MvGame(IGame srcGame, string launchBoxRoot)
        {
            Title = srcGame.Title;
            ApplicationPath = srcGame.ApplicationPath;

        }

        public MvGame()
        {
        }

        public static MvGame[] MvGames(IGame[] ArrGame, string LaunchBoxRoot)
        {
            MvGame[] retMvG = new MvGame[ArrGame.Length];
            for (int i = 0; i < ArrGame.Length; i++)
            {
                retMvG[i] = new MvGame(ArrGame[i], LaunchBoxRoot);
            }

            return retMvG;
        }



    }
}
