using System;
using System.Collections.Generic;

namespace ShootingService.Models
{
    public partial class GunType
    {
        public GunType()
        {
            Gun = new HashSet<Gun>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }

        public virtual ICollection<Gun> Gun { get; set; }
    }
}
