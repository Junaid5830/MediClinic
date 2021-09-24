using MediClinic.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs.VitalBasicDto
{
    public class VitalDto
    {
        public int PatientVitalId { get; set; }
        [Required(ErrorMessage = "Examiner field is required")]
        public long ExaminerId { get; set; }
        public int TypeofExamId { get; set; }
        [Required(ErrorMessage = "Reason field is required")]
        public int ReasonForExamId { get; set; }
        public string Results { get; set; }
        [Required(ErrorMessage ="Exam date field is required")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]

        [DataType(DataType.Date)]
        public DateTime ExamTime { get; set; }
        public long PatientInfoId { get; set; }
        public int? VisitId { get; set; }
        public string Temprature { get; set; }
        [DisplayName("Blood Pressure")]
        public string BloodPressure { get; set; }
        public string Pulse { get; set; }
        public string Respiration { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        [DisplayName("Temp Method")]
        public string TempMethod { get; set; }
        [DisplayName("BMI Status")]
        public string BMIStatus { get; set; }
        public string BMI { get; set; }
        [DisplayName("Oxygen Saturation")]
        public string OxygenSaturation { get; set; }
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Use Characters only")]

        public string Allergies { get; set; }
        public bool IsEditableOrNot { get; set; }
        public bool IsDisableFields { get; set; }

        public ProviderInfo Examiner { get; set; }
        public PatientInfo PatientInfo { get; set; }
        public ExamReason ReasonForExam { get; set; }
        public ExamType TypeofExam { get; set; }

    }
}
