using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class LegalInfoAttorneyName
    {
        public LegalInfoAttorneyName()
        {
            PatientArbitrationAttorney = new HashSet<PatientArbitrationAttorney>();
            PatientPersonalInjury = new HashSet<PatientPersonalInjury>();
            PatientsClaimInfo = new HashSet<PatientsClaimInfo>();
        }

        public int AttorneyId { get; set; }
        public string AttorneyName { get; set; }

        public virtual ICollection<PatientArbitrationAttorney> PatientArbitrationAttorney { get; set; }
        public virtual ICollection<PatientPersonalInjury> PatientPersonalInjury { get; set; }
        public virtual ICollection<PatientsClaimInfo> PatientsClaimInfo { get; set; }
    }
}
