using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class States
    {
        public int Id { get; set; }
        public string StateName { get; set; }
        public int? CountryId { get; set; }
    }
}
