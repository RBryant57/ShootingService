using System;
using System.Collections.Generic;

namespace ShootingService.Models
{
    public partial class Manufacturer
    {
        public Manufacturer()
        {
            Brass = new HashSet<Brass>();
            Bullet = new HashSet<Bullet>();
            Cartridge = new HashSet<Cartridge>();
            GunBuyer = new HashSet<Gun>();
            GunManufacturer = new HashSet<Gun>();
            GunSeller = new HashSet<Gun>();
            Powder = new HashSet<Powder>();
            Primer = new HashSet<Primer>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Url { get; set; }
        public string Notes { get; set; }

        public virtual ICollection<Brass> Brass { get; set; }
        public virtual ICollection<Bullet> Bullet { get; set; }
        public virtual ICollection<Cartridge> Cartridge { get; set; }
        public virtual ICollection<Gun> GunBuyer { get; set; }
        public virtual ICollection<Gun> GunManufacturer { get; set; }
        public virtual ICollection<Gun> GunSeller { get; set; }
        public virtual ICollection<Powder> Powder { get; set; }
        public virtual ICollection<Primer> Primer { get; set; }
    }
}
