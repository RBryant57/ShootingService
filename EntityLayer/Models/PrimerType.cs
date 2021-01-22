using System;
using System.Collections.Generic;

using EntityLayer.Interfaces;

namespace EntityLayer.Models
{
    public partial class PrimerType : IEntity
    {
        public PrimerType()
        {
            Caliber = new HashSet<Caliber>();
            Primer = new HashSet<Primer>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public string Notes { get; set; }

        public virtual ICollection<Caliber> Caliber { get; set; }
        public virtual ICollection<Primer> Primer { get; set; }
    }
}
