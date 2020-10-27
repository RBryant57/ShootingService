using System;
using System.Collections.Generic;

namespace ShootingService.Models
{
    public partial class Bullet
    {
        public Bullet()
        {
            BulletCost = new HashSet<BulletCost>();
            BulletQuantity = new HashSet<BulletQuantity>();
            CartridgeLoad = new HashSet<CartridgeLoad>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int BulletTypeId { get; set; }
        public int MaterialId { get; set; }
        public decimal Diameter { get; set; }
        public int DiameterUnitId { get; set; }
        public int Mass { get; set; }
        public int MassUnitId { get; set; }
        public decimal? SectionalDensity { get; set; }
        public decimal? BallisticCoefficient { get; set; }
        public decimal? Length { get; set; }
        public int? LengthUnitId { get; set; }
        public int ManufacturerId { get; set; }
        public string Notes { get; set; }

        public virtual BulletType BulletType { get; set; }
        public virtual Unit DiameterUnit { get; set; }
        public virtual Unit LengthUnit { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public virtual Unit MassUnit { get; set; }
        public virtual Material Material { get; set; }
        public virtual ICollection<BulletCost> BulletCost { get; set; }
        public virtual ICollection<BulletQuantity> BulletQuantity { get; set; }
        public virtual ICollection<CartridgeLoad> CartridgeLoad { get; set; }
    }
}
