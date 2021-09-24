using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs
{
    public class QuickRegisterPatientDto
    {
        public long Id { get; set; }
        [Required(ErrorMessage ="First Name is required")]

        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]

        public string LastName { get; set; }
        [Required(ErrorMessage = "Address is required")]

        public string Address { get; set; }
        [Required(ErrorMessage = "Phone Number is required")]

        public string PhoneNumber { get; set; }
    }
}
