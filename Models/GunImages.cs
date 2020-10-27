using System;
using System.Collections.Generic;

namespace ShootingService.Models
{
    public partial class GunImages
    {
        public int Id { get; set; }
        public int GunId { get; set; }
        public string PictureLocation { get; set; }

        public virtual Gun Gun { get; set; }
    }
}
