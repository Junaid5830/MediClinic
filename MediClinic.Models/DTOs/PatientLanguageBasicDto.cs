using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs.PatientLanguageDto
{
    public class PatientLanguageBasicDto
    {
        public int LanguageId { get; set; }
        [Required]
        [Display(Name ="Language")]
        public string LanguageName { get; set; }
    }
}
