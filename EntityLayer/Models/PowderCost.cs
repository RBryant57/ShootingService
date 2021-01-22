using System;
using System.Collections.Generic;

using EntityLayer.Interfaces;

namespace EntityLayer.Models
{
    public partial class PowderCost : IEntity
    {
        public int Id { get; set; }
        public int PowderId { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public int UnitId { get; set; }
        public decimal Cost { get; set; }
        public string Notes { get; set; }

        public virtual Powder Powder { get; set; }
        public virtual Unit Unit { get; set; }
    }
}
