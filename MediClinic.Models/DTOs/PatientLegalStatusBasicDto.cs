using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs.PatientLegalStatusDto
{
    public class PatientLegalStatusBasicDto
    {
        public int PatientLegalId { get; set; }
        [Required]
        [Display(Name = "Legal Status")]
        public string PatientLegalStatus1 { get; set; }

    }
}
