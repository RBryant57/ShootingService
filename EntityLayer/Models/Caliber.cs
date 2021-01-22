using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using EntityLayer.Interfaces;

namespace EntityLayer.Models
{
    public partial class Caliber : IEntity
    {
        public Caliber()
        {
            Brass = new HashSet<Brass>();
            CaliberCalibersPrimaryCaliber = new HashSet<CaliberCalibers>();
            CaliberCalibersSecondaryCaliber = new HashSet<CaliberCalibers>();
            CartridgeLoad = new HashSet<CartridgeLoad>();
            Gun = new HashSet<Gun>();
            GunsCalibers = new HashSet<GunsCalibers>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Diameter { get; set; }
        public int DiameterUnitId { get; set; }
        public decimal BrassLength { get; set; }
        public int BrassLengthUnitId { get; set; }
        public decimal Col { get; set; }
        public int ColunitId { get; set; }
        public int PrimerTypeId { get; set; }
        public int SortOrder { get; set; }
        public string Notes { get; set; }

        public virtual Unit BrassLengthUnit { get; set; }
        public virtual Unit Colunit { get; set; }
        public virtual Unit DiameterUnit { get; set; }
        public virtual PrimerType PrimerType { get; set; }
        public virtual ICollection<Brass> Brass { get; set; }
        public virtual ICollection<CaliberCalibers> CaliberCalibersPrimaryCaliber { get; set; }
        public virtual ICollection<CaliberCalibers> CaliberCalibersSecondaryCaliber { get; set; }
        public virtual ICollection<CartridgeLoad> CartridgeLoad { get; set; }
        public virtual ICollection<Gun> Gun { get; set; }
        public virtual ICollection<GunsCalibers> GunsCalibers { get; set; }
    }
}
