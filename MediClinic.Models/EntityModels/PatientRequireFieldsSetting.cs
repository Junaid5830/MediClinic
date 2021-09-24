using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class PatientRequireFieldsSetting
    {
        public int PatientRequiredFieldsId { get; set; }
        public bool? FirstName { get; set; }
        public bool? LastName { get; set; }
        public bool? Gender { get; set; }
        public bool? DOB { get; set; }
        public bool? SSNumber { get; set; }
        public bool? MaritalStatus { get; set; }
        public bool? Address { get; set; }
        public bool? UserName { get; set; }
        public bool? Email { get; set; }
        public bool? Password { get; set; }
        public bool? ZipCode { get; set; }
        public bool? PatientColorStatus { get; set; }
        public bool? Languages { get; set; }
        public bool? EmployementStatus { get; set; }
        public bool? EmploymentTitle { get; set; }
        public bool? ReferralName { get; set; }
        public bool? PatientTreatmentStatus { get; set; }
        public bool? PatientLegalStatus { get; set; }
        public long? UserId { get; set; }
        public bool? PhoneNumber { get; set; }
        public bool? MobileNumber { get; set; }
        public bool? WorkNumber { get; set; }
        public bool? EmergencyNumber { get; set; }

        public virtual Users User { get; set; }
    }
}
