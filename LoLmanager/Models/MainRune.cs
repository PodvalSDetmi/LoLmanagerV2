using System;
using System.Collections.Generic;

namespace LoLmanager.Models
{
    public partial class MainRune
    {
        public MainRune()
        {
            Builds = new HashSet<Build>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public virtual ICollection<Build> Builds { get; set; }
    }
}
