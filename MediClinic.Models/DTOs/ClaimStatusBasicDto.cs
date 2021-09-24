using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs.ClaimStatus
{
     public class ClaimStatusBasicDto
    {
        public int ClaimStatusId { get; set; }
        [Required]
        [Display(Name ="Claim Status")]
        public string ClaimStatus1 { get; set; }
    }
}
