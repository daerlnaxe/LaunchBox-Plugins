using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SappPasRoot.Graph;

namespace SappPasRoot.Core
{
    class Params : Change_Path
    {
        public string CCodesFolder;
        public string GamesFolder;
        public string ImagesFolder;
        public string ManualsFolder;
        public string MusicFolder;
        public string VideosFolder;
        public string HardPath;
        public static string FactoryHardPath;
        public string RelativePath;


        public static string FactoryCCodesFolder = "CCodes";
        public readonly static string FactoryGameFolder = "Games";
        public readonly static string FactoryImagesFolder = "Images";
        public readonly static string FactoryManualsFolder = "Manuals";
        public readonly static string FactoryMusicFolder = "Music";
        public readonly static string FactoryVideosFolder = "Videos";

        public static string FactoryRelativePath = @".\";





        public Params()
        {
        }

        public static void Reset(Change_Path cp, string AppFolder, string Platform)
        {
            cp.tbCCodes.Text = FactoryCCodesFolder;
            cp.tbGames.Text = FactoryGameFolder;
            cp.tbImages.Text = FactoryImagesFolder;
            cp.tbManual.Text = FactoryManualsFolder;
            cp.tbMusic.Text = FactoryMusicFolder;
            cp.tbVideo.Text = FactoryVideosFolder;
            cp.tboxROldPath.Text = FactoryRelativePath;

            string HardPath = Path.GetFullPath(Path.Combine(AppFolder, FactoryRelativePath));

            cp.tbMainPath.Text = cp.tboxHOldPath.Text = HardPath;

        }
    }
}
