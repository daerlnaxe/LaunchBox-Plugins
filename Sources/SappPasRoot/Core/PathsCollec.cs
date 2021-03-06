﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SappPasRoot.Core
{
    public class PathsCollec: BasePaths
    {
        /// <summary>
        /// Type de Chemin
        /// </summary>
        public override EnumPathType Type { get; set; }
        public override string Original_RLink { get; set; }
        public override string Original_HLink { get; set; }
        public override string Destination_RLink { get; set; }
        public override string Destination_HLink { get; set; }

        public PathsCollec(EnumPathType type, string orelatlink, string refPath)
        {
            Type = type;
            if (string.IsNullOrEmpty(orelatlink)) return;

            Original_RLink = orelatlink;
            Original_HLink = Path.GetFullPath(Path.Combine(refPath, orelatlink));

            Destination_RLink = Languages.Lang.Waiting;
            Destination_HLink = Languages.Lang.Waiting;
        }
    }
}
