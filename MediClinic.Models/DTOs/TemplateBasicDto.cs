using MediClinic.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs.TemplateDto
{
    public class TemplateBasicDto
    {
        public long TemplateId { get; set; }

        [Required(ErrorMessage = "Template Name is required")]
        public string Name { get; set; }
        public bool? IsActive { get; set; }

        public long? ProviderInfoId { get; set; }

        public string ProviderName { get; set; }
        public virtual ICollection<PatientMedicationsTemplate> PatientMedicationsTemplate { get; set; }

    }
}
