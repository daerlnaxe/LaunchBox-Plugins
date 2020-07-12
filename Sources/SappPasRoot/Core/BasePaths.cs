using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SappPasRoot.Core
{
    public abstract class BasePaths
    {
        /// <summary>
        /// Type de Chemin
        /// </summary>
        public abstract EnumPathType Type { get; set; }

        /// <summary>
        /// Chemin relatif original
        /// </summary>
        public abstract string Original_RLink { get; set; }

        /// <summary>
        /// Chemin absolu original
        /// </summary>
        public abstract string Original_HLink { get; set; }

        /// <summary>
        /// Chemin relatif de destination
        /// </summary>
        public abstract string Destination_RLink { get; set; }

        /// <summary>
        /// Chemin absolu de destination
        /// </summary>
        public abstract string Destination_HLink { get; set; }
    }
}
