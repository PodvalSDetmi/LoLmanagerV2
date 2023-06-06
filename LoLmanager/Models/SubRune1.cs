using System;
using System.Collections.Generic;

namespace LoLmanager.Models
{
    public partial class SubRune1
    {
        public SubRune1()
        {
            BuildIdMainSubRune1Navigations = new HashSet<Build>();
            BuildIdSudeSubRune1Navigations = new HashSet<Build>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public virtual ICollection<Build> BuildIdMainSubRune1Navigations { get; set; }
        public virtual ICollection<Build> BuildIdSudeSubRune1Navigations { get; set; }
    }
}
