using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class PatientRoleIncident
    {
        public PatientRoleIncident()
        {
            PatientsClaimInfo = new HashSet<PatientsClaimInfo>();
        }

        public int PatientIncidentRoleId { get; set; }
        public string PatientRoleInIncident { get; set; }

        public virtual ICollection<PatientsClaimInfo> PatientsClaimInfo { get; set; }
    }
}
