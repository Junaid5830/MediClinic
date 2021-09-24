using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class ExamReason
    {
        public ExamReason()
        {
            PatientVitals = new HashSet<PatientVitals>();
        }

        public int ExamReasonId { get; set; }
        public string ReasonName { get; set; }

        public virtual ICollection<PatientVitals> PatientVitals { get; set; }
    }
}
