using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs.PatientTreatmentStatusDto
{
    public  class PatientTreatmentStatusBasicDto
    {
        public int PatientTreatmentId { get; set; }
        [Required]
        [Display(Name = "Treatment Name")]
        public string PatientTreatmentStatus1 { get; set; }
    }
}
