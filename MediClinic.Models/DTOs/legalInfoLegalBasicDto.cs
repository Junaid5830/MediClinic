using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs.LegalInfolegealStatusDto
{
    public class legalInfoLegalBasicDto
    {
        public int legalStatusId { get; set; }
        [Required]
        [Display(Name = "Legal Status")]
        public string LegalStatus { get; set; }
    }
}
