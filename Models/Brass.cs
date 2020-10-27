using System;
using System.Collections.Generic;

namespace ShootingService.Models
{
    public partial class Brass
    {
        public Brass()
        {
            BrassCost = new HashSet<BrassCost>();
            BrassQuantity = new HashSet<BrassQuantity>();
            Cartridge = new HashSet<Cartridge>();
        }

        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public int CaliberId { get; set; }
        public int MaterialId { get; set; }
        public int ManufacturerId { get; set; }
        public int TimesFired { get; set; }
        public string Notes { get; set; }

        public virtual Caliber Caliber { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public virtual Material Material { get; set; }
        public virtual ICollection<BrassCost> BrassCost { get; set; }
        public virtual ICollection<BrassQuantity> BrassQuantity { get; set; }
        public virtual ICollection<Cartridge> Cartridge { get; set; }
    }
}
