using System;
using System.Collections.Generic;

namespace ShootingService.Models
{
    public partial class Material
    {
        public Material()
        {
            Brass = new HashSet<Brass>();
            Bullet = new HashSet<Bullet>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }

        public virtual ICollection<Brass> Brass { get; set; }
        public virtual ICollection<Bullet> Bullet { get; set; }
    }
}
