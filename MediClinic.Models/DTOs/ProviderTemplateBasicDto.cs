using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs.ProviderTemplateDto
{
    public class ProviderTemplateBasicDto
    {
        public int ProviderTemplateId { get; set; }

        [Required]
        [Display(Name = "Provider Template")]
        [RegularExpression(@"^[^-\s][a-zA-Z_\s-]+$", ErrorMessage = "Allow only alphabets and spaces except space at beginning.")]
        public string ProviderTemplate { get; set; }
    }
}
