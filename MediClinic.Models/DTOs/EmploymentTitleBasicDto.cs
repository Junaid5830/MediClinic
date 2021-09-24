using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs.EmploymentTitleDto
{
    public class EmploymentTitleBasicDto
    {

        public int EmploymentTitleId { get; set; }
           [Required]
           [Display(Name = "Title Name")]
        public string EmploymentTitle1 { get; set; }
    }
}
