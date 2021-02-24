﻿using System;
using System.Collections.Generic;

using EntityLayer.Interfaces;

namespace EntityLayer.Models
{
    public partial class PowderType : IEntity
    {
        public PowderType()
        {
            Powder = new HashSet<Powder>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }

        public virtual ICollection<Powder> Powder { get; set; }
    }
}