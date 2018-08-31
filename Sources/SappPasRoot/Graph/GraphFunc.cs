using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SappPasRoot.Graph
{
    class GraphFunc
    {

        /// <summary>
        /// Calculate the content size of a textbox and resize it;
        /// </summary>
        /// <param name="sender"></param>
        public static void ResizeTextBox(object sender)
        {
            TextBox tb = (TextBox)sender;
            tb.Width = TextRenderer.MeasureText(tb.Text, tb.Font).Width;
        }
    }
}
