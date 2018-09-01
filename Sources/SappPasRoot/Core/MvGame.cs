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
        public string Id { get; set; }
        public int? LaunchBoxDbId { get; set; }

        public string Title { get; set; }

        public PathsCollec ApplicationPath { get; set; }
        public PathsCollec ManualPath { get; set; }
        public PathsCollec MusicPath { get; set; }
        public PathsCollec VideoPath { get; set; }

        /// <summary>
        /// ..??
        /// </summary>

        /// <summary>
        /// ??? pas inclus
        /// </summary>
        //public string ThemeVideoPath { get; set; }

        /// <summary>
        /// ??? pas inclus
        /// </summary>
        //public string ConfigurationPath { get; set; }


        #region images
        public PathsCollec ClearLogoImagePath { get; }
        public PathsCollec ScreenshotImagePath { get; }
        public PathsCollec FrontImagePath { get; }
        public PathsCollec MarqueeImagePath { get; }
        public PathsCollec BackImagePath { get; }
        public PathsCollec Box3DImagePath { get; }
        public PathsCollec BackgroundImagePath { get; }
        public PathsCollec Cart3DImagePath { get; }
        public PathsCollec CartFrontImagePath { get; }
        public PathsCollec CartBackImagePath { get; }

        #endregion

        public MvGame(IGame srcGame, string launchBoxRoot)
        {
            Title = srcGame.Title;

            Id = srcGame.Id;


            LaunchBoxDbId = srcGame.LaunchBoxDbId;
            Console.WriteLine(srcGame.Id);

            #region Présent dans platform.xml
            ApplicationPath = new PathsCollec("ApplicationPath", srcGame.ApplicationPath, launchBoxRoot);
            ManualPath = new PathsCollec("ManualPath", srcGame.ManualPath, launchBoxRoot);
            MusicPath = new PathsCollec("MusicPath", srcGame.ManualPath, launchBoxRoot);
            VideoPath = new PathsCollec("VideoPath", srcGame.VideoPath, launchBoxRoot);
            #endregion


            #region images
            ScreenshotImagePath = new PathsCollec("ScreenshotImagePath", srcGame.ScreenshotImagePath, launchBoxRoot);
            FrontImagePath = new PathsCollec("FrontImagePath", srcGame.FrontImagePath, launchBoxRoot);
            MarqueeImagePath = new PathsCollec("MarqueeImagePath", srcGame.MarqueeImagePath, launchBoxRoot);
            BackImagePath = new PathsCollec("BackImagePath", srcGame.BackImagePath, launchBoxRoot);
            Box3DImagePath = new PathsCollec("Box3DImagePath", srcGame.Box3DImagePath, launchBoxRoot);
            BackgroundImagePath = new PathsCollec("BackgroundImagePath", srcGame.BackgroundImagePath, launchBoxRoot);
            Cart3DImagePath = new PathsCollec("Cart3DImagePath", srcGame.Cart3DImagePath, launchBoxRoot);
            CartFrontImagePath = new PathsCollec("CartFrontImagePath", srcGame.CartFrontImagePath, launchBoxRoot);
            CartBackImagePath = new PathsCollec("CartBackImagePath", srcGame.CartBackImagePath, launchBoxRoot);
            ClearLogoImagePath = new PathsCollec("ClearLogoImagePath", srcGame.ClearLogoImagePath, launchBoxRoot);
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

        /// <remarks>bug possible si mise à jour des paths nécessaires</remarks>
        public IEnumerable<PathsCollec> EnumGetPaths
        {
            get
            {
                yield return ApplicationPath;
                yield return ManualPath;
                yield return MusicPath;
                yield return VideoPath;

                yield return ClearLogoImagePath;
                yield return ScreenshotImagePath;
                yield return FrontImagePath;
                yield return MarqueeImagePath;
                yield return BackImagePath;
                yield return Box3DImagePath;
                yield return BackgroundImagePath;
                yield return Cart3DImagePath;
                yield return CartFrontImagePath;
                yield return CartBackImagePath;
            }

        }

        /// <summary>
        /// Renvoie la collection des paths
        /// </summary>

        public PathsCollec[] GetPaths
        {
            get
            {
                PathsCollec[] zePaths = new PathsCollec[EnumGetPaths.Count()];
                int i = 0;
                foreach (var path in EnumGetPaths)
                {
                    zePaths[i] = path;
                    i++;
                }

                return zePaths;
            }

        }


    }
}
