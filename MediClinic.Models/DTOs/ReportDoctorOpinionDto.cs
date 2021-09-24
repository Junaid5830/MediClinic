using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Models.DTOs
{
    public class ReportDoctorOpinionDto
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
