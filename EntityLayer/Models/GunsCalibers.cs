using System;
using System.Collections.Generic;

using EntityLayer.Interfaces;

namespace EntityLayer.Models
{
    public partial class GunsCalibers : IEntity
    {
        public int Id { get; set; }
        public int GunId { get; set; }
        public int CaliberId { get; set; }

        public virtual Caliber Caliber { get; set; }
        public virtual Gun Gun { get; set; }
    }
}
