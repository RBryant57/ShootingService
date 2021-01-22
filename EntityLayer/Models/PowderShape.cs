using System;
using System.Collections.Generic;

using EntityLayer.Interfaces;

namespace EntityLayer.Models
{
    public partial class PowderShape : IEntity
    {
        public PowderShape()
        {
            Powder = new HashSet<Powder>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }

        public virtual ICollection<Powder> Powder { get; set; }
    }
}
