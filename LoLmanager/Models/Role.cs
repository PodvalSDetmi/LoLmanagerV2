using System;
using System.Collections.Generic;

namespace LoLmanager.Models
{
    public partial class Role
    {
        public Role()
        {
            Heroes = new HashSet<Hero>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Hero> Heroes { get; set; }
    }
}
