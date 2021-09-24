using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class ReportDoctorOpinion
    {
        public int DoctorOpinionId { get; set; }
        public int VisitId { get; set; }
        public string IsPatientDescribedCompetent { get; set; }
        public string IsComplaintConsistent { get; set; }
        public string IsPercentageTemporary { get; set; }
        public string PercentageTemporary { get; set; }
        public string RelevantDiagnostic { get; set; }
    }
}
