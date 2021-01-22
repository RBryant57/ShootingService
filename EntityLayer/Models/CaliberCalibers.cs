using System;
using System.Collections.Generic;

using EntityLayer.Interfaces;

namespace EntityLayer.Models
{
    public partial class CaliberCalibers : IEntity
    {
        public int Id { get; set; }
        public int PrimaryCaliberId { get; set; }
        public int SecondaryCaliberId { get; set; }
        public string Notes { get; set; }

        public virtual Caliber PrimaryCaliber { get; set; }
        public virtual Caliber SecondaryCaliber { get; set; }
    }
}
