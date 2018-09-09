using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unbroken.LaunchBox.Plugins.Data;

namespace CleanImages
{
    class ExtImageDetails
    {
        private ExtImageDetails[] extImages;
        private ExtImageDetails extImageDetails;

        public string ImageType { get; set; }
        public string Region { get; set; }
        public string FilePath { get; set; }
        public string Md5Sum { get; set; }
        public bool doublon { get; set; } = false;

        public ExtImageDetails()
        {
        }

        /*
        public ExtImageDetails(ExtImageDetails extImage)
        {
            ImageType = extImage.ImageType;
            Region= extImage.Region;
            FilePath = extImage.FilePath;
            Md5Sum = extImage.Md5Sum;
            doublon = extImage.doublon;
        }*/

        public static implicit operator ExtImageDetails(ImageDetails image)
        {
            return new ExtImageDetails() { ImageType = image.ImageType, Region = image.Region, FilePath = image.FilePath, Md5Sum = "", doublon = false };
        }

        /*
        public static ExtImageDetails[] ArrayCopy(ExtImageDetails[] extImages)
        {
            ExtImageDetails[] copy = new ExtImageDetails[extImages.Length];
            for (int i = 0; i < extImages.Length; i++)
            {
                copy[i] = new ExtImageDetails(extImages[i]);
            }
            return copy;
        }
        */
        /*
        public ExtImageDetails(string filePath, string imageType, string region) : base(filePath, imageType, region)
        {
        }

        public ExtImageDetails(ImageDetails image) : base(image.FilePath, image.ImageType, image.Region)
        {

        }

        public static ExtImageDetails[] Convert(ImageDetails[] images)
        {
            ExtImageDetails[] arrEIDet = new ExtImageDetails[images.Length];
            for (int i=0; i < images.Length; i++)
            {
                arrEIDet[i] = new ExtImageDetails(images[i]);
            }

            return arrEIDet;
        }*/

    }
}
