using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class ClaimStatus
    {
        public ClaimStatus()
        {
            PatientsClaimInfo = new HashSet<PatientsClaimInfo>();
        }

        public int ClaimStatusId { get; set; }
        public string ClaimStatus1 { get; set; }

        public virtual ICollection<PatientsClaimInfo> PatientsClaimInfo { get; set; }
    }
}
