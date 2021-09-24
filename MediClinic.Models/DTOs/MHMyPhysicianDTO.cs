using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs.PMHistory
{
    public class MHMyPhysicianDTO
    {
        public int Id { get; set; }
        public int? PatientId { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name cannot be longer than {1} characters.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Location is required")]
        [StringLength(200, ErrorMessage = "Location cannot be longer than {1} characters.")]
        public string Location { get; set; }
        [Required(ErrorMessage = "Hospital is required")]
        [StringLength(100, ErrorMessage = "Hospital cannot be longer than {1} characters.")]
        public string Hospital { get; set; }
        [StringLength(50, ErrorMessage = "Phone No cannot be longer than {1} characters.")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Please enter valid Phone No.(+923211234567)")]
        public string PhoneNo { get; set; }
        [StringLength(50, ErrorMessage = "Specialty cannot be longer than {1} characters.")]
        public string Specialty { get; set; }
        [StringLength(500, ErrorMessage = "Notes cannot be longer than {1} characters.")]
        public string Notes { get; set; }
    }
}
