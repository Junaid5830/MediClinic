using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs.MedicalDiseaseTypeDto
{
    public class MedicalDiseaseTypeBasicDto
    {
        public int DiseaseTypeId { get; set; }
        [Required]
        [Display (Name = "Type Name")]
        public string DiseaseTypeName { get; set; }
    }
}
