using System;
using System.Collections.Generic;

namespace ShootingService.Models
{
    public partial class ShootingLocationView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShootingLocationName { get; set; }
        public string State { get; set; }
        public string Location { get; set; }
        public string Notes { get; set; }
    }
}
