using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class PatientEmergencyContact
    {
        public long EmergencyContactID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int? RelationshipId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public long UserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? CreatedById { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public long? ModifiedById { get; set; }
        public bool IsActive { get; set; }
        public bool IsSMSNotified { get; set; }
        public bool IsEmailNotified { get; set; }
        public bool IsCommunicationSMS { get; set; }
        public bool IsCommunicationEmail { get; set; }
        public bool IsCommunicationPhone { get; set; }
        public bool isBioRecognition { get; set; }
        public bool isFaceRecognition { get; set; }

        public virtual PatientRelationship Relationship { get; set; }
        public virtual Users User { get; set; }
    }
}
