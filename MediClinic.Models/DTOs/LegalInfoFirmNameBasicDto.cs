using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs.LegalInfoFirmNameDto
{
    public class LegalInfoFirmNameBasicDto
    {
        public int FirmId { get; set; }
        [Required]
        [Display(Name = "Firm Name")]
        public string FirmName { get; set; }
    }
}
