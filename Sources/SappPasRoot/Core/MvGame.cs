using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unbroken.LaunchBox.Plugins;
using Unbroken.LaunchBox.Plugins.Data;

namespace SappPasRoot.Core
{
    public class MvGame
    {
        // ?
        public string Id { get; }

        public string Title { get; set; }
        public string ApplicationPath { get; set; }

        /// <summary>
        /// ..??
        /// </summary>
        public int? LaunchBoxDbId { get; set; }

        /// <summary>
        /// ??? pas inclus
        /// </summary>
        public string ThemeVideoPath { get; set; }

        /// <summary>
        /// ??? pas inclus
        /// </summary>
        public string ConfigurationPath { get; set; }

        public string ManualPath { get; set; }
        public string MusicPath { get; set; }
        public string VideoPath { get; set; }

        #region images
        public string ScreenshotImagePath { get; }
        public string FrontImagePath { get; }
        public string MarqueeImagePath { get; }
        public string BackImagePath { get; }
        public string Box3DImagePath { get; }
        public string BackgroundImagePath { get; }
        public string Cart3DImagePath { get; }
        public string CartFrontImagePath { get; }
        public string CartBackImagePath { get; }
        public string ClearLogoImagePath { get; }
        #endregion

        public MvGame(IGame srcGame, string launchBoxRoot)
        {
            Title = srcGame.Title;
            ApplicationPath = srcGame.ApplicationPath;
            LaunchBoxDbId = srcGame.LaunchBoxDbId;
            ManualPath = srcGame.ManualPath;
            MusicPath = srcGame.ManualPath;
            VideoPath = srcGame.VideoPath;

            #region images
            ScreenshotImagePath = srcGame.ScreenshotImagePath;
            FrontImagePath = srcGame.FrontImagePath;
            MarqueeImagePath = srcGame.MarqueeImagePath;
            BackImagePath = srcGame.BackImagePath;
            Box3DImagePath = srcGame.Box3DImagePath;
            BackgroundImagePath = srcGame.BackgroundImagePath;
            Cart3DImagePath = srcGame.Cart3DImagePath;
            CartFrontImagePath = srcGame.CartFrontImagePath;
            CartBackImagePath = srcGame.CartBackImagePath;
            ClearLogoImagePath = srcGame.ClearLogoImagePath;
            #endregion

        }

        public MvGame()
        {
        }


        public static MvGame[] Convert(IGame[] ArrGame, string LaunchBoxRoot)
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
