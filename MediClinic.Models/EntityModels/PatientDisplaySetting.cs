using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class PatientDisplaySetting
    {
        public long? PatientId { get; set; }
        public bool? Phone { get; set; }
        public bool? Sms { get; set; }
        public bool? Email { get; set; }
        public bool? Fax { get; set; }
        public bool? Print_ { get; set; }
        public bool? LastName { get; set; }
        public bool? FirstName { get; set; }
        public bool? DOB { get; set; }
        public bool? Age { get; set; }
        public bool? Address { get; set; }
        public bool? Gender { get; set; }
        public bool? MobilePhone { get; set; }
        public bool? HomePhone { get; set; }
        public bool? EmergencyPhone { get; set; }
        public bool? Languages { get; set; }
        public bool? CaseType { get; set; }
        public bool? ClaimNumber { get; set; }
        public bool? PolicyNumber { get; set; }
        public bool? InsuranceNumber { get; set; }
        public bool? FullClaimInfo { get; set; }
        public bool? DateCreated { get; set; }
        public bool? PrimaryDr { get; set; }
        public bool? Dispatch { get; set; }
        public bool? AssignTransport { get; set; }
        public bool? RouteOptions { get; set; }
        public bool? FirstVisit { get; set; }
        public bool? LastVisit { get; set; }
        public bool? LastExam { get; set; }
        public bool? Vitals { get; set; }
        public bool? BodyStatus { get; set; }
        public bool? Tests { get; set; }
        public bool? Reminders { get; set; }
        public bool? Missing { get; set; }
        public bool? PIAttorney { get; set; }
        public bool? Paralegal { get; set; }
        public bool? CollectionAttorney { get; set; }
        public bool? ReferralName { get; set; }
        public bool? CurrentLocationInFacility { get; set; }
        public bool? LastIME { get; set; }
        public bool? LastEUO { get; set; }
        public bool? AllVisit { get; set; }
        public bool? NumberOfVisits { get; set; }
        public bool? RelatedPatientList { get; set; }
        public int DisplayId { get; set; }
        public long? UserId { get; set; }

        public virtual PatientInfo Patient { get; set; }
        public virtual Users User { get; set; }
    }
}
