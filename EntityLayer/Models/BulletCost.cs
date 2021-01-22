using System;
using System.Collections.Generic;

using EntityLayer.Interfaces;

namespace EntityLayer.Models
{
    public partial class BulletCost : IEntity
    {
        public int Id { get; set; }
        public int BulletId { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public int UnitId { get; set; }
        public decimal Cost { get; set; }
        public string Notes { get; set; }

        public virtual Bullet Bullet { get; set; }
        public virtual Unit Unit { get; set; }
    }
}
