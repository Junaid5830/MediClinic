using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class LegalInfoLeadingParalegal
    {
        public LegalInfoLeadingParalegal()
        {
            PatientArbitrationAttorney = new HashSet<PatientArbitrationAttorney>();
            PatientPersonalInjury = new HashSet<PatientPersonalInjury>();
        }

        public int LeadingParalegalId { get; set; }
        public string LeadingParalegalName { get; set; }

        public virtual ICollection<PatientArbitrationAttorney> PatientArbitrationAttorney { get; set; }
        public virtual ICollection<PatientPersonalInjury> PatientPersonalInjury { get; set; }
    }
}
