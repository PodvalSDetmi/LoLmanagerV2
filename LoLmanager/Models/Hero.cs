using System;
using System.Collections.Generic;

namespace LoLmanager.Models
{
    public partial class Hero
    {
        public Hero()
        {
            Builds = new HashSet<Build>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int IdDifficult { get; set; }
        public byte[]? Image { get; set; }
        public int IdTypeDamage { get; set; }
        public int IdRole { get; set; }
        public int IdClass { get; set; }

        public virtual Class IdClassNavigation { get; set; } = null!;
        public virtual Difficult IdDifficultNavigation { get; set; } = null!;
        public virtual Role IdRoleNavigation { get; set; } = null!;
        public virtual TypeDamage IdTypeDamageNavigation { get; set; } = null!;
        public virtual ICollection<Build> Builds { get; set; }
    }
}
