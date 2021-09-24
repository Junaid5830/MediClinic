using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class PatientPhoneNumber
    {
        public long PhoneNumberId { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public string MobilePhone { get; set; }
        public string EmergencyPhone { get; set; }
        public string Fax { get; set; }
        public string NewNumber { get; set; }
        public bool IsSMSNotified { get; set; }
        public bool IsEmailNotified { get; set; }
        public bool IsCommunicationSMS { get; set; }
        public bool IsCommunicationPhone { get; set; }
        public bool IsCommunicationEmail { get; set; }
        public long UserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? CreatedById { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public long? ModifiedById { get; set; }
        public bool IsActive { get; set; }
        public string ContactNumber2 { get; set; }
        public string ContactNumber3 { get; set; }

        public virtual Users User { get; set; }
    }
}
