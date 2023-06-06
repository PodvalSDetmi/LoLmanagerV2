using System;
using System.Collections.Generic;

namespace LoLmanager.Models
{
    public partial class SubRune2
    {
        public SubRune2()
        {
            BuildIdMainSubRune2Navigations = new HashSet<Build>();
            BuildIdSudeSubRune2Navigations = new HashSet<Build>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public virtual ICollection<Build> BuildIdMainSubRune2Navigations { get; set; }
        public virtual ICollection<Build> BuildIdSudeSubRune2Navigations { get; set; }
    }
}
