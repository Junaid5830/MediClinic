using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class DriverLanguages
    {
        public int DriverLangugaeId { get; set; }
        public int? DriverId { get; set; }
        public int? LangaugeId { get; set; }

        public virtual DriverProfile Driver { get; set; }
        public virtual PatientLanguage Langauge { get; set; }
    }
}
