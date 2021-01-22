using System;
using System.Collections.Generic;

using EntityLayer.Interfaces;

namespace EntityLayer.Models
{
    public partial class Cartridge : IEntity
    {
        public Cartridge()
        {
            CartridgeCost = new HashSet<CartridgeCost>();
            CartridgeQuantity = new HashSet<CartridgeQuantity>();
            ShootingSession = new HashSet<ShootingSession>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CartridgeLoadId { get; set; }
        public int BrassId { get; set; }
        public int? PrimerId { get; set; }
        public int ManufacturerId { get; set; }
        public string Notes { get; set; }

        public virtual Brass Brass { get; set; }
        public virtual CartridgeLoad CartridgeLoad { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public virtual Primer Primer { get; set; }
        public virtual ICollection<CartridgeCost> CartridgeCost { get; set; }
        public virtual ICollection<CartridgeQuantity> CartridgeQuantity { get; set; }
        public virtual ICollection<ShootingSession> ShootingSession { get; set; }
    }
}
