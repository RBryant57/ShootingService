using System;
using System.Collections.Generic;

namespace ShootingService.Models
{
    public partial class CartridgeLoad
    {
        public CartridgeLoad()
        {
            Cartridge = new HashSet<Cartridge>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CaliberId { get; set; }
        public int BulletId { get; set; }
        public int? PowderId { get; set; }
        public decimal? PowderWeight { get; set; }
        public int? PowderWeightUnitId { get; set; }
        public decimal Col { get; set; }
        public int ColunitId { get; set; }
        public int? Velocity { get; set; }
        public int? VelocityUnitId { get; set; }
        public int? Pressure { get; set; }
        public int? PressureUnitId { get; set; }
        public string Notes { get; set; }

        public virtual Bullet Bullet { get; set; }
        public virtual Caliber Caliber { get; set; }
        public virtual Unit Colunit { get; set; }
        public virtual Powder Powder { get; set; }
        public virtual Unit PowderWeightUnit { get; set; }
        public virtual Unit PressureUnit { get; set; }
        public virtual Unit VelocityUnit { get; set; }
        public virtual ICollection<Cartridge> Cartridge { get; set; }
    }
}
