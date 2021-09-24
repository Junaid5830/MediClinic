using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs.PMHistory
{
    public class MHPharmacyInfoDTO
    {
        public int Id { get; set; }
        public int? PatientId { get; set; }
        [Required(ErrorMessage = "Pharmacy Name is required")]
        public string Name { get; set; }
        [StringLength(50, ErrorMessage = "Phone No cannot be longer than {1} characters.")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Please enter valid Phone No.(+923211234567)")]
        public string PhoneNo { get; set; }
        [StringLength(50, ErrorMessage = "Fax No cannot be longer than {1} characters.")]
        public string FaxNo { get; set; }
        public string CountryId { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        [StringLength(200, ErrorMessage = "Address cannot be longer than {1} characters.")]
        public string Address { get; set; }
        public string ZipCode { get; set; }
    }
}
