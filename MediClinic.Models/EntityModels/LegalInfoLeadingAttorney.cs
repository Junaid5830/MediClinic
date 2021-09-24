using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class LegalInfoLeadingAttorney
    {
        public LegalInfoLeadingAttorney()
        {
            PatientArbitrationAttorney = new HashSet<PatientArbitrationAttorney>();
            PatientPersonalInjury = new HashSet<PatientPersonalInjury>();
        }

        public int LeadingAttorneyId { get; set; }
        public string LeadingAttorneyName { get; set; }

        public virtual ICollection<PatientArbitrationAttorney> PatientArbitrationAttorney { get; set; }
        public virtual ICollection<PatientPersonalInjury> PatientPersonalInjury { get; set; }
    }
}
