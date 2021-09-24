using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class LegalInfoFirmName
    {
        public LegalInfoFirmName()
        {
            PatientArbitrationAttorney = new HashSet<PatientArbitrationAttorney>();
            PatientPersonalInjury = new HashSet<PatientPersonalInjury>();
        }

        public int FirmId { get; set; }
        public string FirmName { get; set; }

        public virtual ICollection<PatientArbitrationAttorney> PatientArbitrationAttorney { get; set; }
        public virtual ICollection<PatientPersonalInjury> PatientPersonalInjury { get; set; }
    }
}
