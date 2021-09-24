using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs.PatientSignatureIdTypeBasicDto
{
    public class PatientSignatureIdTypeDto
    {
        public int TypeId { get; set; }
        [Required]
        [Display(Name = "Type Name")]
        public string TypeName { get; set; }
    }
}
