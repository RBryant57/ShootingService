﻿using System;
using System.Collections.Generic;

namespace ShootingService.Models
{
    public partial class GunsCalibersView
    {
        public int GunId { get; set; }
        public string GunName { get; set; }
        public int CaliberId { get; set; }
        public string CaliberName { get; set; }
    }
}
