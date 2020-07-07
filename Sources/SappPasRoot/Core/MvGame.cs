using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unbroken.LaunchBox.Plugins;
using Unbroken.LaunchBox.Plugins.Data;

namespace SappPasRoot.Core
{
    public class MvGame
    {
        public bool Valide;

        // ?
        public string Id { get; set; }
        public int? LaunchBoxDbId { get; set; }

        public string Title { get; set; }
        public bool Hide { get; set; }
        public bool Broken { get; }

        /// <summary>
        /// Path for the application
        /// </summary>
        public PathsCollec ApplicationPath { get; set; }

        /// <summary>
        /// Manual Path
        /// </summary>
        public PathsCollec ManualPath { get; set; }
        public PathsCollec MusicPath { get; set; }
        public PathsCollec VideoPath { get; set; }

        #region 2020 List for manage mixed roms
        /// <summary>
        /// Additionnals roms paths to manage mixed roms mode
        /// </summary>
        public HashSet<PathsCollec> AddiRomPaths = new HashSet<PathsCollec>();
        #endregion


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
            Debug.WriteLine($"[MvGame] New: '{srcGame.Id}': '{srcGame.Title}'");

            Title = srcGame.Title;

            Id = srcGame.Id;
            Hide = srcGame.Hide;
            Broken = srcGame.Broken;

            LaunchBoxDbId = srcGame.LaunchBoxDbId;

            #region Présent dans platform.xml
            ApplicationPath = new PathsCollec(EnumPathType.ApplicationPath, srcGame.ApplicationPath, launchBoxRoot);
            ManualPath = new PathsCollec(EnumPathType.ManualPath, srcGame.ManualPath, launchBoxRoot);
            MusicPath = new PathsCollec(EnumPathType.MusicPath, srcGame.MusicPath, launchBoxRoot);
            VideoPath = new PathsCollec(EnumPathType.VideoPath, srcGame.VideoPath, launchBoxRoot);
            #endregion



            #region images
            ScreenshotImagePath = new PathsCollec(EnumPathType.ScreenshotImagePath, srcGame.ScreenshotImagePath, launchBoxRoot);
            FrontImagePath = new PathsCollec(EnumPathType.FrontImagePath, srcGame.FrontImagePath, launchBoxRoot);
            MarqueeImagePath = new PathsCollec(EnumPathType.MarqueeImagePath, srcGame.MarqueeImagePath, launchBoxRoot);
            BackImagePath = new PathsCollec(EnumPathType.BackImagePath, srcGame.BackImagePath, launchBoxRoot);
            Box3DImagePath = new PathsCollec(EnumPathType.Box3DImagePath, srcGame.Box3DImagePath, launchBoxRoot);
            BackgroundImagePath = new PathsCollec(EnumPathType.BackgroundImagePath, srcGame.BackgroundImagePath, launchBoxRoot);
            Cart3DImagePath = new PathsCollec(EnumPathType.Cart3DImagePath, srcGame.Cart3DImagePath, launchBoxRoot);
            CartFrontImagePath = new PathsCollec(EnumPathType.CartFrontImagePath, srcGame.CartFrontImagePath, launchBoxRoot);
            CartBackImagePath = new PathsCollec(EnumPathType.CartBackImagePath, srcGame.CartBackImagePath, launchBoxRoot);
            ClearLogoImagePath = new PathsCollec(EnumPathType.ClearLogoImagePath, srcGame.ClearLogoImagePath, launchBoxRoot);
            #endregion

            #region  test pour les Additionnals apps
            // 2020 Additionnal to manage also "roms mixed"
            foreach (var addiApp in srcGame.GetAllAdditionalApplications())
            {
                /* Fitre sur les ids, si l'application a le même id que le jeu on conserve pour
                 * changer les paths. Choix pour le moment, pour ne garder que les jeux, en attendant de
                 * voir ce que ça donne au niveau de l'emploi des applications additionnelles dans Launchbox
                */
                if (addiApp.GameId != Id)
                    continue;

                AddiRomPaths.Add(new PathsCollec(EnumPathType.AdditionnalRom,  addiApp.ApplicationPath, launchBoxRoot));

            }
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

        ///<summary>
        /// Enumerate Paths
        /// Enumère les chemins
        ///</summary>         
        /// <remarks>bug possible si mise à jour des paths nécessaires</remarks>
        public IEnumerable<PathsCollec> EnumGetPaths
        {
            get
            {
                yield return ApplicationPath;
                yield return ManualPath;
                yield return MusicPath;
                yield return VideoPath;

                //images non traitées pourle moment
                /*
                yield return ClearLogoImagePath;
                yield return ScreenshotImagePath;
                yield return FrontImagePath;
                yield return MarqueeImagePath;
                yield return BackImagePath;
                yield return Box3DImagePath;
                yield return BackgroundImagePath;
                yield return Cart3DImagePath;
                yield return CartFrontImagePath;
                yield return CartBackImagePath;*/
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
