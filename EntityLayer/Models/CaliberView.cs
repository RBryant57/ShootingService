﻿using System;
using System.Collections.Generic;

using EntityLayer.Interfaces;

namespace EntityLayer.Models
{
    public partial class CaliberView : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Diameter { get; set; }
        public int DiameterUnitId { get; set; }
        public string DiameterUnitViewName { get; set; }
        public string DiameterUnitViewPlural { get; set; }
        public string DiameterUnitViewAbbreviation { get; set; }
        public int DiameterUnitViewUnitTypeId { get; set; }
        public string DiameterUnitViewUnitTypeName { get; set; }
        public string DiameterUnitViewUnitTypeNotes { get; set; }
        public string DiameterUnitViewNotes { get; set; }
        public decimal BrassLength { get; set; }
        public int BrassLengthUnitId { get; set; }
        public string BrassLengthUnitViewName { get; set; }
        public string BrassLengthUnitViewPlural { get; set; }
        public string BrassLengthUnitViewAbbreviation { get; set; }
        public int BrassLengthUnitViewUnitTypeId { get; set; }
        public string BrassLengthUnitViewUnitTypeName { get; set; }
        public string BrassLengthUnitViewUnitTypeNotes { get; set; }
        public string BrassLengthUnitViewNotes { get; set; }
        public int PrimerTypeId { get; set; }
        public string PrimerTypeName { get; set; }
        public string PrimerTypeAbbreviation { get; set; }
        public string PrimerTypeNotes { get; set; }
        public int SortOrder { get; set; }
        public string Notes { get; set; }
    }
}
