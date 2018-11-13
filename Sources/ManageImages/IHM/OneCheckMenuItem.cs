using DxTrace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ManageImages.IHM
{
    class OneCheckMenuItem : MenuItem
    {
        public string GroupName { get; set; }

        protected override void OnClick()
        {
            ItemsControl ics = this.Parent as ItemsControl;
            ITrace.WriteLine($"ic {ics.ToString()}, {ics.GetHashCode()}");

            foreach (OneCheckMenuItem ocmi in ics.Items.OfType<OneCheckMenuItem>())
            {
                if (ocmi == this)
                {
                    ocmi.IsChecked = true;
                    continue;
                }
                if (ocmi.GroupName.Equals(GroupName) && ocmi.IsChecked) ocmi.IsChecked=false ;

            }

            /*
            if (ic != null)
            {
                OneCheckMenuItem ocmi = ic.Items.OfType<OneCheckMenuItem>().FirstOrDefault(i => i.GroupName == GroupName && i.IsChecked);

                if (ocmi != null) ocmi.IsChecked = false;

                IsChecked = true;
            }*/
            base.OnClick();
        }
    }
}
