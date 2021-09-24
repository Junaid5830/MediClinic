using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class PatientPrintSetting
    {
        public int PrintId { get; set; }
        public long? PatientId { get; set; }
        public bool? LastName { get; set; }
        public bool? FIrstName { get; set; }
        public bool? DOB { get; set; }
        public bool? Age { get; set; }
        public bool? Address { get; set; }
        public bool? SSNumber { get; set; }
        public bool? Gender { get; set; }
        public bool? MaritalStatus { get; set; }
        public bool? MobilePhone { get; set; }
        public bool? HomePhone { get; set; }
        public bool? EmergencyPhone { get; set; }
        public bool? languages { get; set; }
        public bool? CaseType { get; set; }
        public bool? ClaimNumber { get; set; }
        public bool? PolicyNumber { get; set; }
        public bool? WCBNumber { get; set; }
        public bool? CarrierCaseNumber { get; set; }
        public bool? PolicyHolderName { get; set; }
        public bool? EmployerInfo { get; set; }
        public bool? DOA { get; set; }
        public bool? PlaceTimeOfAccident { get; set; }
        public bool? FullInsuranceInfo { get; set; }
        public bool? FullClaimInfo { get; set; }
        public bool? Nf2fillingDate { get; set; }
        public bool? DateCreated { get; set; }
        public bool? PrimaryDr { get; set; }
        public bool? FirstVisit { get; set; }
        public bool? LastVisit { get; set; }
        public bool? Vitals { get; set; }
        public bool? BodyStatus { get; set; }
        public bool? Tests { get; set; }
        public bool? Reminder { get; set; }
        public bool? Missing { get; set; }
        public bool? FullPIAttorneyinfo { get; set; }
        public bool? Paralegal { get; set; }
        public bool? CollectionAttorney { get; set; }
        public bool? ReferralName { get; set; }
        public bool? CurrentLocationInFacility { get; set; }
        public bool? LastIME { get; set; }
        public bool? LastEUO { get; set; }
        public bool? AllVisits { get; set; }
        public bool? NumberOfVisits { get; set; }
        public bool? RelatedPatientList { get; set; }
        public long? UserId { get; set; }
        public bool? LastExam { get; set; }

        public virtual PatientInfo Patient { get; set; }
    }
}
