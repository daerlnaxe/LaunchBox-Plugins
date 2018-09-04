using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unbroken.LaunchBox.Plugins.Data;

namespace SappPasRoot.Core
{
    public class MvFolder : IPlatformFolder
    {
        public string Platform { get; set; }
        public string MediaType { get; set; }
        
        /// <summary>
        /// LaunchBox relative link - original
        /// </summary>
        public string FolderPath { get; set; }

        #region extensions
        /// <summary>
        /// New relative link -> destination
        /// </summary>
        public string NewFolderPath { get; set; }

        public string HFolderPath { get; set; }
        public string HNewFolderPath { get; set; }
        #endregion


        public MvFolder() { }

        public MvFolder(IPlatformFolder src, string LaunchBoxRoot)
        {
            Platform = src.Platform;
            MediaType = src.MediaType;
            FolderPath = src.FolderPath;
            HFolderPath = Path.GetFullPath(Path.Combine(LaunchBoxRoot, FolderPath));

            NewFolderPath = Languages.Lang.Waiting;
            HNewFolderPath = Languages.Lang.Waiting;
        }

        public MvFolder(string CurrentFolder, string LaunchBoxRoot)
        {
            FolderPath = CurrentFolder;
            HFolderPath = Path.GetFullPath(Path.Combine(LaunchBoxRoot, CurrentFolder));
            NewFolderPath = HNewFolderPath = Languages.Lang.Waiting;
        }

        /* public MvFolder(MvFolder src)
         {
             Platform = src.Platform;
             MediaType = src.MediaType;
             FolderPath = src.FolderPath;
             NewPath = src.NewPath;
             NewPath = "src.FolderPath";// bug put to src.NewPath after test
         }*/

        public static MvFolder[] Convert(IPlatformFolder[] ArrPlatFolder, string LaunchBoxRoot)
        {
            MvFolder[] retMVF = new MvFolder[ArrPlatFolder.Length];
            for (int i = 0; i < ArrPlatFolder.Length; i++)
            {
                retMVF[i] = new MvFolder(ArrPlatFolder[i], LaunchBoxRoot);
            }

            return retMVF;
        }
    }
}
