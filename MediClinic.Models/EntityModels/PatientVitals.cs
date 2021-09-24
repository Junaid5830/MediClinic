using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class PatientVitals
    {
        public int PatientVitalId { get; set; }
        public long ExaminerId { get; set; }
        public int? TypeofExamId { get; set; }
        public int ReasonForExamId { get; set; }
        public string Results { get; set; }
        public DateTime? ExamTime { get; set; }
        public long PatientInfoId { get; set; }
        public string Temprature { get; set; }
        public string BloodPressure { get; set; }
        public string Pulse { get; set; }
        public string Respiration { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string TempMethod { get; set; }
        public string BMIStatus { get; set; }
        public string BMI { get; set; }
        public string OxygenSaturation { get; set; }
        public string Allergies { get; set; }
        public int? VisitId { get; set; }

        public virtual ProviderInfo Examiner { get; set; }
        public virtual ExamReason ReasonForExam { get; set; }
    }
}
