using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs.PatientPhoneNumberDto
{
    public class PatientPhoneNumberBasicDto
    {
        public long PhoneNumberId { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        [Required(ErrorMessage = "Mobile Number is required")]
        public string MobilePhone { get; set; }
        
        public string EmergencyPhone { get; set; }
        public string ContactNumber2 { get; set; }
        public string ContactNumber3 { get; set; }
        public string Fax { get; set; }
      
        public string NewNumber { get; set; }
        public bool IsSMSNotified { get; set; }
        public bool IsEmailNotified { get; set; }
        public bool IsCommunicationSMS { get; set; }
        public bool IsCommunicationPhone { get; set; }
        public bool IsCommunicationEmail { get; set; }
        public long UserId { get; set; }
    }
}
