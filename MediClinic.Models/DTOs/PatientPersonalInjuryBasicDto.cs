using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs.PatientPIPersonalInjury
{
    public class PatientPersonalInjuryBasicDto
    {
        public long PersonalInjuryId { get; set; }
        public bool FromAttorney { get; set; }
        public bool ToAttorney { get; set; }
        public bool OfAttorney { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
         
        public string Country { get; set; }
      
        public string City { get; set; }
      
        public string State { get; set; }
        [Required]
        [Display(Name = "ZIP Code")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Use Digits only")]

        public string Zip { get; set; }
        public string PhoneNumber { get; set; }
        public string Fax { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        public string Website { get; set; }
        
        public int? LeadingParalegalId { get; set; }
        [Required(ErrorMessage = "Leading Paralegal Phone is required")]
        public string LeadingParalegalPhone { get; set; }
        public string LeadingParalegalExtension { get; set; }
        [Required(ErrorMessage = "Leading Paralegal Email is required")]
        public string LeadingParalegalEmail { get; set; }
        public string LeadingParalegalFax { get; set; }
        public string LegalStatus { get; set; }

        public int? AttorneyID { get; set; }
        public int? FirmId { get; set; }
        public int? LeadingAttorneyId { get; set; }
        public string LeadingAttorneyPhone { get; set; }
        public string LeadingAttorneyEmail { get; set; }
        public string LeadingAttorneyExtension { get; set; }
        public string LeadingAttorneyFax { get; set; }
        public long UserId { get; set; }
        public string AttorneyFields { get; set; }
    }
}
