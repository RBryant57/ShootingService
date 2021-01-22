using System;
using System.Collections.Generic;

using EntityLayer.Interfaces;

namespace EntityLayer.Models
{
    public partial class Gun : IEntity
    {
        public Gun()
        {
            GunImages = new HashSet<GunImages>();
            GunsCalibers = new HashSet<GunsCalibers>();
            ShootingSession = new HashSet<ShootingSession>();
        }

        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public string Name { get; set; }
        public int CaliberId { get; set; }
        public int ManufacturerId { get; set; }
        public int SellerId { get; set; }
        public int? BuyerId { get; set; }
        public int Capacity { get; set; }
        public decimal BarrelLength { get; set; }
        public int BarrelLengthUnitId { get; set; }
        public int GunTypeId { get; set; }
        public decimal Cost { get; set; }
        public DateTime AcquisitionDate { get; set; }
        public DateTime? RetireDate { get; set; }
        public string Details { get; set; }
        public string Notes { get; set; }

        public virtual Unit BarrelLengthUnit { get; set; }
        public virtual Manufacturer Buyer { get; set; }
        public virtual Caliber Caliber { get; set; }
        public virtual GunType GunType { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public virtual Manufacturer Seller { get; set; }
        public virtual ICollection<GunImages> GunImages { get; set; }
        public virtual ICollection<GunsCalibers> GunsCalibers { get; set; }
        public virtual ICollection<ShootingSession> ShootingSession { get; set; }
    }
}
