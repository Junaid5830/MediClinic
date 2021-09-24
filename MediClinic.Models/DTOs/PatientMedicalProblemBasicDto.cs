using MediClinic.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs.PatientMedicalProblemDto
{
    public class PatientMedicalProblemBasicDto
    {
        public int MedicalProblemId { get; set; }
        public int? DiseaseTypeId { get; set; }

        public string DieaseName { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateYear { get; set; }
        public string CurrentStatus { get; set; }
        public string DocumentReport { get; set; }
        public long? PatientId { get; set; }
        public long? ExaminerId { get; set; }

        public virtual MedicalDiseaseType DiseaseType { get; set; }
    }
}
