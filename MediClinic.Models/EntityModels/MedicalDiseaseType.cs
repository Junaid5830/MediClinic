using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class MedicalDiseaseType
    {
        public MedicalDiseaseType()
        {
            PatientMedicalHistory = new HashSet<PatientMedicalHistory>();
            PatientMedicalProblem = new HashSet<PatientMedicalProblem>();
        }

        public int DiseaseTypeId { get; set; }
        public string DiseaseTypeName { get; set; }

        public virtual ICollection<PatientMedicalHistory> PatientMedicalHistory { get; set; }
        public virtual ICollection<PatientMedicalProblem> PatientMedicalProblem { get; set; }
    }
}
