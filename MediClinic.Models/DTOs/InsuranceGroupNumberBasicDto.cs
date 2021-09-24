using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs.InsuranceGroupNumberBasicDto
{
    public class InsuranceGroupNumberBasicDto
    {
        public int GroupId { get; set; }
        [Required]
        [Display(Name = "Group Number")]
        public string GroupName { get; set; }
    }
}
