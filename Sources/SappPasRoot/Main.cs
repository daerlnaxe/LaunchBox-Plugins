using SappPasRoot.Graph;
using System;
using System.Collections.Generic;
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
            List_Platform sp = new List_Platform();
            sp.ShowDialog();
        }

    }
}
