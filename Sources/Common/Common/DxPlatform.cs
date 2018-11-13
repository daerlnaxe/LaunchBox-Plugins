using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unbroken.LaunchBox.Plugins.Data;

namespace Common
{
    class DxPlatform : IPlatform
    {
        public string BannerImagePath => throw new NotImplementedException();

        public string DeviceImagePath => throw new NotImplementedException();

        public string ClearLogoImagePath => throw new NotImplementedException();

        public string BackgroundImagePath => throw new NotImplementedException();

        public string SortTitleOrTitle => throw new NotImplementedException();

        public string PlatformCategoryClearLogoImagePath => throw new NotImplementedException();

        public bool IsEmulated => throw new NotImplementedException();

        public string Name => throw new NotImplementedException();

        public DateTime? ReleaseDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Developer { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Manufacturer { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Cpu { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Memory { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Graphics { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Sound { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Display { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Media { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string MaxControllers { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Folder { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Notes { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string VideosFolder { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string FrontImagesFolder { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string BackImagesFolder { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ClearLogoImagesFolder { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string FanartImagesFolder { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ScreenshotImagesFolder { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string BannerImagesFolder { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string SteamBannerImagesFolder { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ManualsFolder { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string MusicFolder { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ScrapeAs { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string VideoPath { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ImageType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string SortTitle { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Category { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string LastGameId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string BigBoxView { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IGame[] GetAllGames(bool includeHidden, bool includeBroken)
        {
            throw new NotImplementedException();
        }

        public IGame[] GetAllGames(bool includeHidden, bool includeBroken, bool excludeGamesMissingVideos, bool excludeGamesMissingBoxFrontImage, bool excludeGamesMissingScreenshotImage, bool excludeGamesMissingClearLogoImage, bool excludeGamesMissingBackgroundImage)
        {
            throw new NotImplementedException();
        }

        public IPlatformFolder[] GetAllPlatformFolders()
        {
            throw new NotImplementedException();
        }

        public int GetGameCount(bool includeHidden, bool includeBroken)
        {
            throw new NotImplementedException();
        }

        public int GetGameCount(bool includeHidden, bool includeBroken, bool excludeGamesMissingVideos, bool excludeGamesMissingBoxFrontImage, bool excludeGamesMissingScreenshotImage, bool excludeGamesMissingClearLogoImage, bool excludeGamesMissingBackgroundImage)
        {
            throw new NotImplementedException();
        }

        public string GetNewPlatformLogoPath(string url)
        {
            throw new NotImplementedException();
        }

        public string GetNewPlatformVideoPath(string url)
        {
            throw new NotImplementedException();
        }

        public IPlatformFolder GetPlatformFolderByImageType(string imageType)
        {
            throw new NotImplementedException();
        }

        public string GetPlatformVideoPath(bool fallBackToGameVideos = true, bool allowThemePath = true)
        {
            throw new NotImplementedException();
        }

        public bool HasGames(bool includeHidden, bool includeBroken)
        {
            throw new NotImplementedException();
        }

        public bool HasGames(bool includeHidden, bool includeBroken, bool excludeGamesMissingVideos, bool excludeGamesMissingBoxFrontImage, bool excludeGamesMissingScreenshotImage, bool excludeGamesMissingClearLogoImage, bool excludeGamesMissingBackgroundImage)
        {
            throw new NotImplementedException();
        }
    }
}
