using System;
using System.Collections.Generic;

using EntityLayer.Interfaces;

namespace EntityLayer.Models
{
    public partial class GunsCalibersView : IEntity
    {
        public int Id {get; set; }
        public int GunId { get; set; }
        public string GunName { get; set; }
        public int CaliberId { get; set; }
        public string CaliberName { get; set; }
    }
}
