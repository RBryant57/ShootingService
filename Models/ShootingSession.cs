using System;
using System.Collections.Generic;

namespace ShootingService.Models
{
    public partial class ShootingSession
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int LocationId { get; set; }
        public int GunId { get; set; }
        public int CartridgeId { get; set; }
        public int Rounds { get; set; }
        public int? Retention { get; set; }
        public string Notes { get; set; }

        public virtual Cartridge Cartridge { get; set; }
        public virtual Gun Gun { get; set; }
        public virtual ShootingLocation Location { get; set; }
    }
}
