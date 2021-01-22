using System;
using System.Collections.Generic;

using EntityLayer.Interfaces;

namespace EntityLayer.Models
{
    public partial class GunImages : IEntity
    {
        public int Id { get; set; }
        public int GunId { get; set; }
        public string PictureLocation { get; set; }

        public virtual Gun Gun { get; set; }
    }
}
