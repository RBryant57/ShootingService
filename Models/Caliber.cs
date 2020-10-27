using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ShootingService.Models
{
    public partial class Caliber
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

        public async Task<int> AddCaliber(Caliber caliber, ShootingContext context)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                var higherCalibers = from c in context.Caliber
                            where c.SortOrder >= caliber.SortOrder
                            orderby c.SortOrder
                            select c;

                if(higherCalibers.Any())
                {
                    var startOrder = caliber.SortOrder + 1;
                    foreach(var cal in higherCalibers)
                    {
                        
                    }
                }
                context.Caliber.Add(caliber);
                return await context.SaveChangesAsync();
            }
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
