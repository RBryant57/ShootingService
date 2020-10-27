using System;
using System.Collections.Generic;

namespace ShootingService.Models
{
    public partial class Primer
    {
        public Primer()
        {
            Cartridge = new HashSet<Cartridge>();
            PrimerCost = new HashSet<PrimerCost>();
            PrimerQuantity = new HashSet<PrimerQuantity>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int PrimerTypeId { get; set; }
        public int ManufacturerId { get; set; }
        public string Notes { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }
        public virtual PrimerType PrimerType { get; set; }
        public virtual ICollection<Cartridge> Cartridge { get; set; }
        public virtual ICollection<PrimerCost> PrimerCost { get; set; }
        public virtual ICollection<PrimerQuantity> PrimerQuantity { get; set; }
    }
}
