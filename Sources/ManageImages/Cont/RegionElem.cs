using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageImages.Cont
{
    public class RegionElem: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Name { get; set; }

        private bool _IsChecked;
        public bool IsChecked
        {
            get { return _IsChecked; }
            set
            {
                _IsChecked = value;
                if (PropertyChanged != null) PropertyChanged?.Invoke(this,new PropertyChangedEventArgs("IsChecked"));
            }
        }

        public RegionElem()
        {

        }

        public RegionElem(string r, bool c)
        {
            Name = r;
            IsChecked = c;
        }
    }
}
