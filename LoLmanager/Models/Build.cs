using System;
using System.Collections.Generic;

namespace LoLmanager.Models
{
    public partial class Build
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int IdHero { get; set; }
        public int IdSummonerSpell1 { get; set; }
        public int IdSummonerSpell2 { get; set; }
        public int IdMainSubRune1 { get; set; }
        public int IdMainSubRune2 { get; set; }
        public int IdMainSubRune3 { get; set; }
        public int IdMainRune { get; set; }
        public int? IdSudeSubRune1 { get; set; }
        public int? IdSudeSubRune2 { get; set; }
        public int? IdSudeSubRune3 { get; set; }
        public int IdPassive1 { get; set; }
        public int IdPassive2 { get; set; }
        public int IdPassive3 { get; set; }

        public virtual Hero IdHeroNavigation { get; set; } = null!;
        public virtual MainRune IdMainRuneNavigation { get; set; } = null!;
        public virtual SubRune1 IdMainSubRune1Navigation { get; set; } = null!;
        public virtual SubRune2 IdMainSubRune2Navigation { get; set; } = null!;
        public virtual SubRune3 IdMainSubRune3Navigation { get; set; } = null!;
        public virtual Passive1 IdPassive1Navigation { get; set; } = null!;
        public virtual Passive2 IdPassive2Navigation { get; set; } = null!;
        public virtual Passive3 IdPassive3Navigation { get; set; } = null!;
        public virtual SubRune1 IdSudeSubRune1Navigation { get; set; } = null!;
        public virtual SubRune2 IdSudeSubRune2Navigation { get; set; } = null!;
        public virtual SubRune3 IdSudeSubRune3Navigation { get; set; } = null!;
        public virtual SummonerSpell1 IdSummonerSpell1Navigation { get; set; } = null!;
        public virtual SummonerSpell2 IdSummonerSpell2Navigation { get; set; } = null!;
    }
}
