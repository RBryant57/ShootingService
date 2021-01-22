using System;
using System.Collections.Generic;

using EntityLayer.Interfaces;

namespace EntityLayer.Models
{
    public partial class Unit : IEntity
    {
        public Unit()
        {
            BrassCost = new HashSet<BrassCost>();
            BrassQuantity = new HashSet<BrassQuantity>();
            BulletCost = new HashSet<BulletCost>();
            BulletDiameterUnit = new HashSet<Bullet>();
            BulletLengthUnit = new HashSet<Bullet>();
            BulletMassUnit = new HashSet<Bullet>();
            BulletQuantity = new HashSet<BulletQuantity>();
            CaliberBrassLengthUnit = new HashSet<Caliber>();
            CaliberColunit = new HashSet<Caliber>();
            CaliberDiameterUnit = new HashSet<Caliber>();
            CartridgeCost = new HashSet<CartridgeCost>();
            CartridgeLoadColunit = new HashSet<CartridgeLoad>();
            CartridgeLoadPowderWeightUnit = new HashSet<CartridgeLoad>();
            CartridgeLoadPressureUnit = new HashSet<CartridgeLoad>();
            CartridgeLoadVelocityUnit = new HashSet<CartridgeLoad>();
            CartridgeQuantity = new HashSet<CartridgeQuantity>();
            Gun = new HashSet<Gun>();
            PowderCost = new HashSet<PowderCost>();
            PowderQuantity = new HashSet<PowderQuantity>();
            PrimerCost = new HashSet<PrimerCost>();
            PrimerQuantity = new HashSet<PrimerQuantity>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Plural { get; set; }
        public string Abbreviation { get; set; }
        public int UnitTypeId { get; set; }
        public string Notes { get; set; }

        public virtual UnitType UnitType { get; set; }
        public virtual ICollection<BrassCost> BrassCost { get; set; }
        public virtual ICollection<BrassQuantity> BrassQuantity { get; set; }
        public virtual ICollection<BulletCost> BulletCost { get; set; }
        public virtual ICollection<Bullet> BulletDiameterUnit { get; set; }
        public virtual ICollection<Bullet> BulletLengthUnit { get; set; }
        public virtual ICollection<Bullet> BulletMassUnit { get; set; }
        public virtual ICollection<BulletQuantity> BulletQuantity { get; set; }
        public virtual ICollection<Caliber> CaliberBrassLengthUnit { get; set; }
        public virtual ICollection<Caliber> CaliberColunit { get; set; }
        public virtual ICollection<Caliber> CaliberDiameterUnit { get; set; }
        public virtual ICollection<CartridgeCost> CartridgeCost { get; set; }
        public virtual ICollection<CartridgeLoad> CartridgeLoadColunit { get; set; }
        public virtual ICollection<CartridgeLoad> CartridgeLoadPowderWeightUnit { get; set; }
        public virtual ICollection<CartridgeLoad> CartridgeLoadPressureUnit { get; set; }
        public virtual ICollection<CartridgeLoad> CartridgeLoadVelocityUnit { get; set; }
        public virtual ICollection<CartridgeQuantity> CartridgeQuantity { get; set; }
        public virtual ICollection<Gun> Gun { get; set; }
        public virtual ICollection<PowderCost> PowderCost { get; set; }
        public virtual ICollection<PowderQuantity> PowderQuantity { get; set; }
        public virtual ICollection<PrimerCost> PrimerCost { get; set; }
        public virtual ICollection<PrimerQuantity> PrimerQuantity { get; set; }
    }
}
