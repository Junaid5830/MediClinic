using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class IncidentReportStatus
    {
        public IncidentReportStatus()
        {
            PatientsClaimInfo = new HashSet<PatientsClaimInfo>();
        }

        public int IncidentReportId { get; set; }
        public string IncidentReportStatus1 { get; set; }

        public virtual ICollection<PatientsClaimInfo> PatientsClaimInfo { get; set; }
    }
}
