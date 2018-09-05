using SappPasRoot.Graph;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unbroken.LaunchBox.Plugins;


namespace SappPasRoot
{
    public class Main : ISystemMenuItemPlugin
    {
        /// <summary>
        /// Titre du plugin
        /// </summary>
        public string Caption => Languages.Lang.Plugin_Title;

        /// <summary>
        /// Montrer en mode bigbox
        /// </summary>
        public bool ShowInBigBox => false;

        /// <summary>
        /// 
        /// </summary>
        public bool AllowInBigBoxWhenLocked => false;

        /// <summary>
        /// Montrer dans Launchbox
        /// </summary>
        public bool ShowInLaunchBox => true;

        /// <summary>
        /// Icone de la dll pour le menu
        /// </summary>
        public Image IconImage => null;        

        public void OnSelected()
        {
            var app = AppDomain.CurrentDomain.BaseDirectory;
            TextWriterTraceListener textWriter = new TextWriterTraceListener(@".\Logs\SappPasRoot.log");
            //Ajout bit à bit de deux options de sortie
            textWriter.TraceOutputOptions = TraceOptions.Callstack | TraceOptions.ProcessId | TraceOptions.Timestamp;
            ;
            Debug.Listeners.Add(textWriter);
            Debug.AutoFlush = true;

            Debug.WriteLine($"\n {new string('=', 10)} Initialization {new string('=', 10)}");

            try
            {
                //PluginHelper. .LaunchBoxMainForm.FormClosing += new FormClosingEventHandler(Fermeture);


                List_Platform sp = new List_Platform();
                sp.ShowDialog();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

        }

    }
}
