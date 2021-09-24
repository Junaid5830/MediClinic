using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs
{
    public class DepartmentsDto
    {
        public int DepartmentsID { get; set; }
        [Required]
        [Display(Name ="Dep Name")]
        public string DepName { get; set; }
        [Required]
        [Display(Name = "Room")]
        public int? Room { get; set; }
        [Required]
        [Display(Name = "IsActive")]
        public bool Isactive { get; set; }
        [Required]
        [Display(Name = "Isdeleted")]
        [RegularExpression(@"^[0-9\-]*$", ErrorMessage = "Use digits only")]
        public bool? Isdeleted { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
