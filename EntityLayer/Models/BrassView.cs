﻿using System;
using System.Collections.Generic;

using EntityLayer.Interfaces;

namespace EntityLayer.Models
{
    public partial class BrassView : IEntity
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public string BrassName { get; set; }
        public string BrassFullName { get; set; }
        public string ParentBrassFullName { get; set; }
        public int CaliberId { get; set; }
        public string CaliberViewName { get; set; }
        public decimal CaliberViewDiameter { get; set; }
        public int CaliberViewDiameterUnitId { get; set; }
        public string CaliberViewDiameterUnitViewName { get; set; }
        public string CaliberViewDiameterUnitViewPlural { get; set; }
        public string CaliberViewDiameterUnitViewAbbreviation { get; set; }
        public int CaliberViewDiameterUnitViewUnitTypeId { get; set; }
        public string CaliberViewDiameterUnitViewUnitTypeName { get; set; }
        public string CaliberViewDiameterUnitViewUnitTypeNotes { get; set; }
        public string CaliberViewDiameterUnitViewNotes { get; set; }
        public decimal CaliberViewBrassLength { get; set; }
        public int CaliberViewBrassLengthUnitId { get; set; }
        public string CaliberViewBrassLengthUnitViewName { get; set; }
        public string CaliberViewBrassLengthUnitViewPlural { get; set; }
        public string CaliberViewBrassLengthUnitViewAbbreviation { get; set; }
        public int CaliberViewBrassLengthUnitViewUnitTypeId { get; set; }
        public string CaliberViewBrassLengthUnitViewUnitTypeName { get; set; }
        public string CaliberViewBrassLengthUnitViewUnitTypeNotes { get; set; }
        public string CaliberViewBrassLengthUnitViewNotes { get; set; }
        public int CaliberViewPrimerTypeId { get; set; }
        public string CaliberViewPrimerTypeName { get; set; }
        public string CaliberViewPrimerTypeAbbreviation { get; set; }
        public string CaliberViewPrimerTypeNotes { get; set; }
        public int CaliberViewSortOrder { get; set; }
        public string CaliberViewNotes { get; set; }
        public int MaterialId { get; set; }
        public string MaterialName { get; set; }
        public string MaterialNotes { get; set; }
        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; }
        public string ManufacturerShortName { get; set; }
        public string ManufacturerAddress { get; set; }
        public string ManufacturerCity { get; set; }
        public string ManufacturerState { get; set; }
        public string ManufacturerZip { get; set; }
        public string ManufacturerUrl { get; set; }
        public string ManufacturerNotes { get; set; }
        public int TimesFired { get; set; }
        public string Notes { get; set; }
    }
}
