using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SappPasRoot.Core
{
     public class AAppPath : BasePaths
    {

        public string ID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public override EnumPathType Type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public override string Original_RLink { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public override string Original_HLink { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public override string Destination_RLink { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public override string Destination_HLink { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id de l'appli</param>
        /// <param name="orelatlink"></param>
        /// <param name="refPath"></param>
        public AAppPath(string id, string orelatlink, string refPath)
        {
            //Type = type;
            ID = id;
            if (string.IsNullOrEmpty(orelatlink)) return;

            Original_RLink = orelatlink;
            Original_HLink = Path.GetFullPath(Path.Combine(refPath, orelatlink));

            Destination_RLink = Languages.Lang.Waiting;
            Destination_HLink = Languages.Lang.Waiting;
        }
    }
}
