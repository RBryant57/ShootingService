using System;
using System.Collections.Generic;

using EntityLayer.Interfaces;

namespace EntityLayer.Models
{
    public partial class InventoryType : IEntity
    {
        public InventoryType()
        {
            BrassQuantity = new HashSet<BrassQuantity>();
            BulletQuantity = new HashSet<BulletQuantity>();
            CartridgeQuantity = new HashSet<CartridgeQuantity>();
            PowderQuantity = new HashSet<PowderQuantity>();
            PrimerQuantity = new HashSet<PrimerQuantity>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }

        public virtual ICollection<BrassQuantity> BrassQuantity { get; set; }
        public virtual ICollection<BulletQuantity> BulletQuantity { get; set; }
        public virtual ICollection<CartridgeQuantity> CartridgeQuantity { get; set; }
        public virtual ICollection<PowderQuantity> PowderQuantity { get; set; }
        public virtual ICollection<PrimerQuantity> PrimerQuantity { get; set; }
    }
}
