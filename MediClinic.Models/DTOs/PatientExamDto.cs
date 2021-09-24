using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Models.DTOs.PatientExamDto
{
    public class PatientExamTypeDto
    {
        public int ExamTypeId { get; set; }
        public string ExamName { get; set; }
    }
    public class PatientExamReasonDto
    {
        public int ExamReasonId { get; set; }
        public string ReasonName { get; set; }
    }
}
