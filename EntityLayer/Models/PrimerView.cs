﻿using System;
using System.Collections.Generic;

using EntityLayer.Interfaces;

namespace EntityLayer.Models
{
    public partial class PrimerView : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PrimerFullName { get; set; }
        public string PrimerName { get; set; }
        public int PrimerTypeId { get; set; }
        public string PrimerTypeName { get; set; }
        public string PrimerTypeAbbreviation { get; set; }
        public string PrimerTypeNotes { get; set; }
        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; }
        public string ManufacturerShortName { get; set; }
        public string ManufacturerAddress { get; set; }
        public string ManufacturerCity { get; set; }
        public string ManufacturerState { get; set; }
        public string ManufacturerZip { get; set; }
        public string ManufacturerUrl { get; set; }
        public string ManufacturerNotes { get; set; }
        public string Notes { get; set; }
    }
}
