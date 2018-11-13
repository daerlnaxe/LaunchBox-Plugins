using DxTrace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ManageImages.IHM
{
    public class DebugWPF : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // Debugger.Break();
            ITrace.WriteLine($"wpf Convert value:{value.ToString()}");
            ITrace.WriteLine($"wpf Convert targetType:{targetType.ToString()}");
          
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // Debugger.Break();
            ITrace.WriteLine($"wpf ConvertBack {value.ToString()}");
            return value;
        }
    }
}
