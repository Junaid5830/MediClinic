using MediClinic.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Models.DTOs.PatientMedicalHistoryDto
{
    public class PatientMedicalHistoryBasicDto
    {
        public int MedicalHistryId { get; set; }
        public long? PatientId { get; set; }
        public long? ExaminerId { get; set; }
        public int? DiseaseTypeId { get; set; }
        public DateTime? DataYear { get; set; }
        public string CurrentStatus { get; set; }
        public string DocumentReport { get; set; }
        public string MedicalHistoryTemplate { get; set; }
        public virtual MedicalDiseaseType DiseaseType { get; set; }
    }
}
