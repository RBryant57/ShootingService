using System;
using System.Collections.Generic;

using EntityLayer.Interfaces;

namespace EntityLayer.Models
{
    public partial class UnitView : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Plural { get; set; }
        public string Abbreviation { get; set; }
        public int UnitTypeId { get; set; }
        public string UnitTypeName { get; set; }
        public string UnitTypeNotes { get; set; }
        public string Notes { get; set; }
    }
}
