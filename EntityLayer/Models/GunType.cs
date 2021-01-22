using System;
using System.Collections.Generic;

using EntityLayer.Interfaces;

namespace EntityLayer.Models
{
    public partial class GunType : IEntity
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
