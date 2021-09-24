using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs.InsuranceProviderNameBasicDto
{
    public class InsuranceProviderNameBasicDto
    {
        public int ProviderId { get; set; }
        [Required]
        [Display(Name = "Provider Name")]
        public string ProviderName { get; set; }
    }
}
