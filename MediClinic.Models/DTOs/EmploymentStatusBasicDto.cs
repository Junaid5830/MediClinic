using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs.EmploymentStatusDto
{
    public class EmploymentStatusBasicDto
    {
        public int EmploymentStatusId { get; set; }
        [Required]
        [Display(Name = "Status Name")]
        public string EmploymentStatus1 { get; set; }
    }
}
