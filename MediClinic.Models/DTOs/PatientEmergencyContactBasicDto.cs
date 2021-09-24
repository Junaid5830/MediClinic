using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs.PatientEmergencyContactDto
{
    public class PatientEmergencyContactBasicDto
    {
        public long EmergencyContactID { get; set; }
        [Required]
        [Display(Name = "First Name")]
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Use Characters only")]

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Use Characters only")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Relationship is required")]
        public int RelationshipId { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
       

        public string Country { get; set; }
       
        public string City { get; set; }
     
        public string State { get; set; }
        [Required]
        [Display(Name = "ZIP Code")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Use Digits only")]
        public string Zip { get; set; }
        public string HomePhone { get; set; }
        [Required(ErrorMessage = "Mobile Number is required")]
        public string MobilePhone { get; set; }
        public string Fax { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        public long UserId { get; set; }
        public bool IsActive { get; set; }
        public bool IsSMSNotified { get; set; }
        public bool IsEmailNotified { get; set; }
        public bool isBioRecognition { get; set; }
        public bool isFaceRecognition { get; set; }
        public bool IsCommunicationSMS { get; set; }
        public bool IsCommunicationEmail { get; set; }
        public bool IsCommunicationPhone { get; set; }
    }
}
