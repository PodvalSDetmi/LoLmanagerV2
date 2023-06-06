using System;
using System.Collections.Generic;

namespace LoLmanager.Models
{
    public partial class SummonerSpell1
    {
        public SummonerSpell1()
        {
            Builds = new HashSet<Build>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Build> Builds { get; set; }
    }
}
