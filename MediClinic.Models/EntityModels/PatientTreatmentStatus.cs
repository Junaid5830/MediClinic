using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class PatientTreatmentStatus
    {
        public PatientTreatmentStatus()
        {
            PatientInfo = new HashSet<PatientInfo>();
        }

        public int PatientTreatmentId { get; set; }
        public string PatientTreatmentStatus1 { get; set; }

        public virtual ICollection<PatientInfo> PatientInfo { get; set; }
    }
}
