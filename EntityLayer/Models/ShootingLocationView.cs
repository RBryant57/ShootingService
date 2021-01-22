using System;
using System.Collections.Generic;

using EntityLayer.Interfaces;

namespace EntityLayer.Models
{
    public partial class ShootingLocationView : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShootingLocationName { get; set; }
        public string State { get; set; }
        public string Location { get; set; }
        public string Notes { get; set; }
    }
}
