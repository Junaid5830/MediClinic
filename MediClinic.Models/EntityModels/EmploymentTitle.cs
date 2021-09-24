using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class EmploymentTitle
    {
        public EmploymentTitle()
        {
            PatientInfo = new HashSet<PatientInfo>();
        }

        public int EmploymentTitleId { get; set; }
        public string EmploymentTitle1 { get; set; }

        public virtual ICollection<PatientInfo> PatientInfo { get; set; }
    }
}
