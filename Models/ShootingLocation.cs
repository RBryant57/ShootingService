using System;
using System.Collections.Generic;

namespace ShootingService.Models
{
    public partial class ShootingLocation
    {
        public ShootingLocation()
        {
            ShootingSession = new HashSet<ShootingSession>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public string Location { get; set; }
        public string Notes { get; set; }

        public virtual ICollection<ShootingSession> ShootingSession { get; set; }
    }
}
