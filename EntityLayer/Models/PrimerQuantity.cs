using System;
using System.Collections.Generic;

using EntityLayer.Interfaces;

namespace EntityLayer.Models
{
    public partial class PrimerQuantity : IEntity
    {
        public int Id { get; set; }
        public int PrimerId { get; set; }
        public int InventoryTypeId { get; set; }
        public DateTime Date { get; set; }
        public int StartQuantity { get; set; }
        public int EndQuantity { get; set; }
        public int Change { get; set; }
        public int UnitId { get; set; }
        public string Notes { get; set; }

        public virtual InventoryType InventoryType { get; set; }
        public virtual Primer Primer { get; set; }
        public virtual Unit Unit { get; set; }
    }
}
