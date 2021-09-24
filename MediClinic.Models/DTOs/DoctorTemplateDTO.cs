using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs
{
    public class DoctorTemplateDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public int DoctorId { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public int TemplateId { get; set; }
    }
}
