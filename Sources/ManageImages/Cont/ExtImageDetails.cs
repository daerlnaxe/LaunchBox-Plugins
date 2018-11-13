using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unbroken.LaunchBox.Plugins.Data;

namespace ManageImages.Cont
{
    public class ExtImageDetails : ImageDetails, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private string _FilePath;
        public new string FilePath
        {
            get { return _FilePath; }
            set
            {
                _FilePath = value;
                if (PropertyChanged != null) PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FilePath"));
            }
        }


        private string _ImageType;
        public new string ImageType
        {
            get { return _ImageType; }
            set
            {
                _ImageType = value;
                if (PropertyChanged != null) PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ImageType"));
            }
        }

        private string _Region;
        public new string Region
        {
            get { return _Region; }
            set
            {
                _Region = value;
                if (PropertyChanged != null) PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Region"));
            }
        }

        public ExtImageDetails(string filePath, string imageType, string region) : base(filePath, imageType, region)
        {
            FilePath = filePath;
            ImageType = imageType;
            Region = region;
        }

        public ExtImageDetails(ImageDetails x) : base(x.FilePath, x.ImageType, x.Region)
        {
            FilePath = x.FilePath;
            ImageType = x.ImageType;
            Region = x.Region;
        }
    }
}
