using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SappPasRoot.Core
{
    public class PathsCollec
    {
        public string Type { get; set; }
        public string Original_RLink { get; set; }
        public string Original_HLink { get; set; }
        public string Destination_RLink { get; set; }
        public string Destination_HLink { get; set; }

        public PathsCollec(string type, string orelatlink, string refPath)
        {
            Type = type;
            if (string.IsNullOrEmpty(orelatlink)) return;

            Original_RLink = orelatlink;
            Original_HLink = Path.GetFullPath(Path.Combine(refPath, orelatlink));

            Destination_RLink = "Waiting...";
            Destination_HLink = "Waiting...";
        }
    }
}
