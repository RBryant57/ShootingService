using System;
using System.Collections.Generic;

namespace ShootingService.Models
{
    public partial class UnitType
    {
        public UnitType()
        {
            Unit = new HashSet<Unit>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }

        public virtual ICollection<Unit> Unit { get; set; }
    }
}
