using System;
using System.Collections.Generic;

namespace ShootingService.Models
{
    public partial class BrassCost
    {
        public int Id { get; set; }
        public int BrassId { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public int UnitId { get; set; }
        public decimal Cost { get; set; }
        public string Notes { get; set; }

        public virtual Brass Brass { get; set; }
        public virtual Unit Unit { get; set; }
    }
}
