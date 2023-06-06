using System;
using System.Collections.Generic;

namespace LoLmanager.Models
{
    public partial class SubRune3
    {
        public SubRune3()
        {
            BuildIdMainSubRune3Navigations = new HashSet<Build>();
            BuildIdSudeSubRune3Navigations = new HashSet<Build>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public virtual ICollection<Build> BuildIdMainSubRune3Navigations { get; set; }
        public virtual ICollection<Build> BuildIdSudeSubRune3Navigations { get; set; }
    }
}
