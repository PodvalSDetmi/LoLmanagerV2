using System;
using System.Collections.Generic;

namespace LoLmanager.Models
{
    public partial class Difficult
    {
        public Difficult()
        {
            Heroes = new HashSet<Hero>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Hero> Heroes { get; set; }
    }
}
