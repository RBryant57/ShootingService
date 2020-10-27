using System;
using System.Collections.Generic;

namespace ShootingService.Models
{
    public partial class PowderShape
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
