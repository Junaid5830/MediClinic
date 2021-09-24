using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class EmploymentStatus
    {
        public EmploymentStatus()
        {
            PatientInfo = new HashSet<PatientInfo>();
        }

        public int EmploymentStatusId { get; set; }
        public string EmploymentStatus1 { get; set; }

        public virtual ICollection<PatientInfo> PatientInfo { get; set; }
    }
}
