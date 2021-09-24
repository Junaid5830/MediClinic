using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class Cities
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public int? StateId { get; set; }
    }
}
