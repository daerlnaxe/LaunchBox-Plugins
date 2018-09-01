using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unbroken.LaunchBox.Plugins.Data;

namespace SappPasRoot.Core
{
    public class LBGame : IGame
    {
        //Id utilisée sur les images etc
        public string Id { get; set; }
        public string TestID { get { return Id; } }
        public string Title { get; set; }

        public string SortTitle { get; set; }
        public string SortTitleOrTitle { get; }

        public string Platform { get; set; }
        public string Developer { get; set; }
        public string Publisher { get; set; }

        public string[] Developers { get; }

        public string[] Publishers { get; }

        /// <summary>
        /// Saga
        /// </summary>
        public string Series { get; set; }

        /// <summary>
        /// Region du jeu
        /// </summary>
        public string Region { get; set; }

        public string CloneOf { get; set; }
        public string GenresString { get; set; }

        /// <summary>
        /// Synopsis par ex
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// idée de labase de donnée, pas clair. Nombre
        /// </summary>
        public int? LaunchBoxDbId { get; set; }

        #region Paths
        public string ApplicationPath { get; set; }

        /// <summary>
        /// ??? Vu aucune utilité
        /// </summary>
        public string ThemeVideoPath { get; set; }
        public string ScreenshotImagePath { get; }
        public string FrontImagePath { get; }
        /// <summary>
        /// Bordure
        /// </summary>
        public string MarqueeImagePath { get; }
        public string BackImagePath { get; }
        public string Box3DImagePath { get; }
        public string BackgroundImagePath { get; }

        // Cartouches
        public string Cart3DImagePath { get; }
        public string CartFrontImagePath { get; }
        public string CartBackImagePath { get; }

        public string ClearLogoImagePath { get; }

        /// <summary>
        /// Logo commun à tous les jeux d'une même machine, pas utile de déplacer
        /// </summary>
        public string PlatformClearLogoImagePath { get; }

        /// <summary>
        /// Vu aucune utilité pour les roms mégadrive
        /// </summary>
        public string RootFolder { get; set; }
        public string ManualPath { get; set; }
        public string MusicPath { get; set; }
        public string VideoPath { get; set; }


        /// <summary>
        /// ???
        /// </summary>
        public string ConfigurationPath { get; set; }
        /// <summary>
        /// Pas vu d'utilité pour le moment
        /// </summary>
        public string DosBoxConfigurationPath { get; set; }

        #endregion

        #region Booléens
        public bool Favorite { get; set; }
        public bool ShowBack { get; set; }

        public bool Hide { get; set; }
        public bool Broken { get; set; }

        public bool Portable { get; set; }

        public bool Completed { get; set; }

        public bool UseDosBox { get; set; }
        public bool UseScummVm { get; set; }
        #endregion

        /// <summary>
        /// Vu aucune utilité
        /// </summary>
        public string ConfigurationCommandLine { get; set; }

        public Image RatingImage { get; }

        // Sortes de récapitulatif
        public string DetailsWithPlatform { get; }
        public string DetailsWithoutPlatform { get; }


        /// <summary>
        /// ??????
        /// </summary>
        public string CommandLine { get; set; }

        public DateTime DateAdded { get; set; }
        public DateTime DateModified { get; set; }
        public string EmulatorId { get; set; }

        #region statistiques
        public DateTime? LastPlayedDate { get; set; }
        #endregion



        public string Rating { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? ReleaseYear { get; set; }

        #region scumm
        public bool ScummVmAspectCorrection { get; set; }
        public bool ScummVmFullscreen { get; set; }
        public string ScummVmGameDataFolderPath { get; set; }
        public string ScummVmGameType { get; set; }
        #endregion

        /// <summary>
        /// ???
        /// </summary>
        public string Source { get; set; }
        public int StarRating { get; set; }

        public float CommunityOrLocalStarRating { get; }

        public float StarRatingFloat { get; set; }
        public float CommunityStarRating { get; set; }
        public int CommunityStarRatingTotalVotes { get; set; }
        public string Status { get; set; }

        public int? WikipediaId { get; set; }
        public string WikipediaUrl { get; set; }

        /// <summary>
        /// Version du jeu (us-eu etc... )
        /// </summary>
        public string Version { get; set; }

        public string PlayMode { get; set; }

        public int PlayCount { get; set; }

        public BlockingCollection<string> Genres { get; }


        public string[] PlayModes { get; }


        public string[] SeriesValues { get; }


        #region fonctions
        public IAdditionalApplication AddNewAdditionalApplication()
        {
            throw new NotImplementedException();
        }

        public ICustomField AddNewCustomField()
        {
            throw new NotImplementedException();
        }

        public IMount AddNewMount()
        {
            throw new NotImplementedException();
        }

        public string Configure()
        {
            throw new NotImplementedException();
        }

        public IAdditionalApplication[] GetAllAdditionalApplications()
        {
            throw new NotImplementedException();
        }

        public ICustomField[] GetAllCustomFields()
        {
            throw new NotImplementedException();
        }

        public ImageDetails[] GetAllImagesWithDetails()
        {
            throw new NotImplementedException();
        }

        public ImageDetails[] GetAllImagesWithDetails(string imageType)
        {
            throw new NotImplementedException();
        }

        public IMount[] GetAllMounts()
        {
            throw new NotImplementedException();
        }

        public string GetBigBoxDetails(bool showPlatform)
        {
            throw new NotImplementedException();
        }

        public string GetManualPath()
        {
            throw new NotImplementedException();
        }

        public string GetMusicPath()
        {
            throw new NotImplementedException();
        }

        public string GetNewManualFilePath(string extension)
        {
            throw new NotImplementedException();
        }

        public string GetNewMusicFilePath(string extension)
        {
            throw new NotImplementedException();
        }

        public string GetNewThemeVideoFilePath(string extension)
        {
            throw new NotImplementedException();
        }

        public string GetNewVideoFilePath(string extension)
        {
            throw new NotImplementedException();
        }

        public string GetNextAvailableImageFilePath(string extension, string imageType, string region)
        {
            throw new NotImplementedException();
        }

        public string GetThemeVideoPath()
        {
            throw new NotImplementedException();
        }

        public string GetVideoPath(bool prioritizeThemeVideos = false)
        {
            throw new NotImplementedException();
        }

        public string OpenFolder()
        {
            throw new NotImplementedException();
        }

        public string OpenManual()
        {
            throw new NotImplementedException();
        }

        public string Play()
        {
            throw new NotImplementedException();
        }

        public bool TryRemoveAdditionalApplication(IAdditionalApplication additionalApplication)
        {
            throw new NotImplementedException();
        }

        public bool TryRemoveCustomField(ICustomField customField)
        {
            throw new NotImplementedException();
        }

        public bool TryRemoveMount(IMount mount)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
