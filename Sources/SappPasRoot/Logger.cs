using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SappPasRoot
{
    static class Logger
    {
        static private List<TextWriterTraceListener> listeners;
        static public bool AutoFlush;

        static public void AddListener(TextWriterTraceListener txtWTL)
        {
            listeners.Add(txtWTL);

        }

        static public void WriteInit(char ornement, string who)
        {
            foreach (var listener in listeners)
            {
             //   listener.WriteLine($"{ new string {'' } }");
            }
        }

    }
}
