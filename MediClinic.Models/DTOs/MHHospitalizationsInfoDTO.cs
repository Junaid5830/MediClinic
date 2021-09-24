using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs.PMHistory
{
    public class MHHospitalizationsInfoDTO
    {
        public int Id { get; set; }
        public int? PatientId { get; set; }

        [Required(ErrorMessage = "Hospital Name is required")]
        [StringLength(100, ErrorMessage = "Hospital Name cannot be longer than {1} characters.")]
        public string HospitalName { get; set; }
        [StringLength(50, ErrorMessage = "Phone No cannot be longer than {1} characters.")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Please enter valid Phone No.(+923211234567)")]
        public string PhoneNo { get; set; }
        public int? CountryId { get; set; }
        public int? StateId { get; set; }
        public int? CityId { get; set; }
        public int? Year { get; set; }
        public string illnessORinjury { get; set; }
        [StringLength(200, ErrorMessage = "Address cannot be longer than {1} characters.")]
        public string Address { get; set; }
        [StringLength(500, ErrorMessage = "Notes cannot be longer than {1} characters.")]
        public string Notes { get; set; }
    }
}
