using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class PatientLegalStatus
    {
        public PatientLegalStatus()
        {
            PatientInfo = new HashSet<PatientInfo>();
        }

        public int PatientLegalId { get; set; }
        public string PatientLegalStatus1 { get; set; }

        public virtual ICollection<PatientInfo> PatientInfo { get; set; }
    }
}
