using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs
{
    public class RadiologyDto
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Radiology Name")]
        public string RadiologyName { get; set; }
        [Required]
        [Display(Name ="Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name ="Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name ="Phone")]
        [RegularExpression(@"^[0-9\-]*$", ErrorMessage = "Use digits only")]
        public string Phone { get; set; }
        [Required]
        [Display(Name ="Address")]
        public string Address { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

    }
}
