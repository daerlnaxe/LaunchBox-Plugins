using DxTrace;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CleanImages
{
    class Md5Func
    {
        public event Action<int> CurrentPosition;
        public event Action<string> CurrentFile;

        /// <summary>
        /// Calcul des sommes md5 et update de la fenetre de progression
        /// </summary>
        /// <param name="images"></param>
        /// <returns></returns>
        public async Task Calculate_MD5(ExtImageDetails[] images, int retardateur)
        {
            ITrace.Indent++;
            ExtImageDetails[] extImages = new ExtImageDetails[images.Length];

            int i = 1;
            foreach (ExtImageDetails image in images)
            {
                ITrace.WriteLine($"[Md5] {image.ImageType} | {image.Region}");
                ITrace.WriteLine($"[Md5] {image.FilePath}");
                //extImages[i].Md5Sum = 
                image.Md5Sum = await GetMD5HashFromFile(image.FilePath);
                // Pour permettre un affichage lisible retarde le calcul
                await Task.Delay(retardateur);

                ITrace.WriteLine($"[Md5] Somme: {image.Md5Sum} \n");

                CurrentFile?.Invoke(image.FilePath);
                CurrentPosition?.Invoke(i);

                i++;
            }

            ITrace.Indent--;
        }

        /// <summary>
        /// Fonction principale de calcul md5
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private async Task<string> GetMD5HashFromFile(string fileName)
        {
            try
            {
                using (var md5 = MD5.Create())
                {
                    using (var stream = File.OpenRead(fileName))
                    {
                        string hash = BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", string.Empty);
                        return hash;
                    }
                }
            }
            catch (Exception exc)
            {
                ITrace.WriteLine($"GetMd5HashFromFile: {exc}");
                throw new Exception($"Erreur en GetMD5HashFromFile\n {exc}");
            }
        }
    }
}
