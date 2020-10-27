using System;
using System.Collections.Generic;

namespace ShootingService.Models
{
    public partial class GunsCalibers
    {
        public int Id { get; set; }
        public int GunId { get; set; }
        public int CaliberId { get; set; }

        public virtual Caliber Caliber { get; set; }
        public virtual Gun Gun { get; set; }
    }
}
