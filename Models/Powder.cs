using System;
using System.Collections.Generic;

namespace ShootingService.Models
{
    public partial class Powder
    {
        public Powder()
        {
            CartridgeLoad = new HashSet<CartridgeLoad>();
            PowderCost = new HashSet<PowderCost>();
            PowderQuantity = new HashSet<PowderQuantity>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int ManufacturerId { get; set; }
        public int PowderTypeId { get; set; }
        public int PowderShapeId { get; set; }
        public string Notes { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }
        public virtual PowderShape PowderShape { get; set; }
        public virtual PowderType PowderType { get; set; }
        public virtual ICollection<CartridgeLoad> CartridgeLoad { get; set; }
        public virtual ICollection<PowderCost> PowderCost { get; set; }
        public virtual ICollection<PowderQuantity> PowderQuantity { get; set; }
    }
}
