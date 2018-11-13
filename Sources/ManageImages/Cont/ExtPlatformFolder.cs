using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unbroken.LaunchBox.Data;
using Unbroken.LaunchBox.Plugins.Data;

namespace ManageImages.Cont
{
    public class ExtPlatformFolder : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string MediaType { get; }
        public new string FolderPath { get; set; }
        public string Platform { get; }

        private bool _Checked;
        public bool Checked
        {
            get { return _Checked; }
            set
            {
                _Checked = value;
                if (PropertyChanged != null) PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Checked"));
            }
        }

        public ExtPlatformFolder() { }

        public ExtPlatformFolder(IPlatformFolder ipf)
        {
            this.MediaType = ipf.MediaType;
            this.FolderPath = Path.GetFullPath(ipf.FolderPath);//Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ipf.FolderPath);
            this.Platform = ipf.Platform;
        }


    }
}
