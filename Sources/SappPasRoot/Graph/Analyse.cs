using SappPasRoot.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SappPasRoot.Graph
{
    static class Analyse
    {

        internal static Size Rows<T>(Func<T, string> fc, /*PropertyInfo prop,*/ T[] elements, Font font)
        {
            int maxSize = 0;
            string lplong = null;

            foreach (var element in elements)
            {
                string val = fc(element);
                //ok Console.WriteLine(folder.GetType().GetProperty(prop.Name).GetValue(folder, null) );
               // string val = prop.GetValue(folder).ToString();
                //string val = "";
                
                //Console.WriteLine(prop.Name + " : " + val);

                int tmp = val.Length;
                //      int tmp = TextRenderer.MeasureText(prop.GetValue(folder).ToString(), ex.Font).Width + 5;
                if (maxSize < tmp)
                {
                    maxSize = tmp;
                    lplong = val;

                }
            }
            var mesure = TextRenderer.MeasureText(lplong, font);
            return mesure;
        }
    }
}
