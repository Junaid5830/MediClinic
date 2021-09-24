using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class PatientMedicalProblem
    {
        public int MedicalProblemId { get; set; }
        public int? DiseaseTypeId { get; set; }
        public DateTime? DateYear { get; set; }
        public string CurrentStatus { get; set; }
        public string DocumentReport { get; set; }
        public long? PatientId { get; set; }
        public long? ExaminerId { get; set; }

        public virtual MedicalDiseaseType DiseaseType { get; set; }
        public virtual ProviderInfo Examiner { get; set; }
        public virtual PatientInfo Patient { get; set; }
    }
}
