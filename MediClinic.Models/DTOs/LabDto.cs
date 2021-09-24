using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs
{
    public class LabDto
    {
        public int LabId { get; set; }
        [Required]
        [Display(Name = "Enter Date")]
        public DateTime? DateTime { get; set; }
        [Required]
        [Display(Name = "Enter Examiner")]
        public string Examiner { get; set; }
        [Required]
        [Display(Name = "Enter Type Of Exam")]
        public string TypeOfExam { get; set; }
        [Required]
        [Display(Name = "Enter Results")]
        public string Results { get; set; }
        [Required]
        [Display(Name = "Enter Report")]
        public string Report { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdateBy { get; set; }
        public string ReasonForExam { get; set; }
        public int? VisitId { get; set; }
    }
}
