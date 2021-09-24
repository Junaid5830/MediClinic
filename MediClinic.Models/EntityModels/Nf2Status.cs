using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class Nf2Status
    {
        public Nf2Status()
        {
            PatientsClaimInfo = new HashSet<PatientsClaimInfo>();
        }

        public int Nf2Id { get; set; }
        public string Nf2Status1 { get; set; }

        public virtual ICollection<PatientsClaimInfo> PatientsClaimInfo { get; set; }
    }
}
