using MediClinic.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Models.DTOs
{
    public class ReportHistoryDto
    {
        public int ReportHistoryId { get; set; }
        public string Hopsitaliaztion { get; set; }
        public string HospitalizationDetail { get; set; }
        public string WorkRelatedInjury { get; set; }
        public string WorkRelatedInjuryDetail { get; set; }
        public int? VisitId { get; set; }
        public string InjuryOrillnes { get; set; }
        public string InjuryOrillnesDetail { get; set; }
        public string InjuryOrillneshappen { get; set; }

        public virtual Visits Visit { get; set; }
    }
}
