using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Models.DTOs.PatientSettingsDto
{
    public class PatientSettingDto
    {
        public long UserId { get; set; }
        public int DisplayId { get; set; }
        public long? PatientId { get; set; }
        public bool Phone { get; set; }
        public bool Sms { get; set; }
        public bool Email { get; set; }
        public bool Fax { get; set; }
        public bool Print { get; set; }
        public bool FirstName { get; set; }
        public bool LastName { get; set; }
        public bool DOB { get; set; }
        public bool Age { get; set; }
        public bool Address { get; set; }
        public bool Gender { get; set; }
        public bool MobilePhone { get; set; }
        public bool HomePhone { get; set; }
        public bool EmergencyPhone { get; set; }
        public bool Languages { get; set; }
        public bool CaseType { get; set; }
        public bool ClaimNumber { get; set; }
        public bool PolicyNumber { get; set; }
        public bool InsuranceNumber { get; set; }
        public bool FullClaimInfo { get; set; }
        public bool DateCreated { get; set; }
        public bool PrimaryDr { get; set; }
        public bool Dispatch { get; set; }
        public bool AssignTransport { get; set; }
        public bool RouteOptions { get; set; }
        public bool FirstVisit { get; set; }
        public bool LastVisit { get; set; }
        public bool LastExam { get; set; }
        public bool Vitals { get; set; }
        public bool BodyStatus { get; set; }
        public bool Tests { get; set; }
        public bool Reminders { get; set; }
        public bool Missing { get; set; }
        public bool PIAttorney { get; set; }
        public bool Paralegal { get; set; }
        public bool CollectionAttorney { get; set; }
        public bool ReferralName { get; set; }
        public bool CurrentLocationInFacility { get; set; }
        public bool LastIME { get; set; }
        public bool LastEUO { get; set; }
        public bool AllVisit { get; set; }
        public bool NumberOfVisits { get; set; }
        public bool RelatedPatientList { get; set; }
    }

    public class PatientPrintSettingDto
    {
        public int PrintId { get; set; }
        public long? PatientId { get; set; }

        public bool LastName { get; set; }
        public bool FIrstName { get; set; }
        public bool DOB { get; set; }
        public bool Age { get; set; }
        public bool Address { get; set; }
        public bool SSNumber { get; set; }
        public bool Gender { get; set; }
        public bool MaritalStatus { get; set; }
        public bool MobilePhone { get; set; }
        public bool HomePhone { get; set; }
        public bool EmergencyPhone { get; set; }
        public bool languages { get; set; }
        public bool CaseType { get; set; }
        public bool ClaimNumber { get; set; }

        public bool WCBNumber { get; set; }

        public bool CarrierCaseNumber { get; set; }
        public bool PolicyNumber { get; set; }
        public bool PolicyHolderName { get; set; }
        public bool EmployerInfo { get; set; }
        public bool DOA { get; set; }
        public bool PlaceTimeOfAccident { get; set; }
        public bool FullInsuranceInfo { get; set; }
        public bool FullClaimInfo { get; set; }

        public bool Nf2fillingDate { get; set; }
        public bool DateCreated { get; set; }
        public bool PrimaryDr { get; set; }
        public bool FirstVisit { get; set; }
        public bool LastVisit { get; set; }
        public bool LastExam { get; set; }
        public bool LastEUO { get; set; }
        public bool Vitals { get; set; }
        public bool BodyStatus { get; set; }
        public bool Tests { get; set; }
  
        public bool Reminder { get; set; }
        public bool Missing { get; set; }
        public bool FullPIAttorneyinfo { get; set; }
        public bool Paralegal { get; set; }
        public bool CollectionAttorney { get; set; }
        public bool ReferralName { get; set; }
        public bool CurrentLocationInFacility { get; set; }
        public bool LastIME { get; set; }
        public bool LastEMO { get; set; }
        public bool AllVisits { get; set; }
        public bool NumberOfVisits { get; set; }
        public bool RelatedPatientList { get; set; }
        public long UserId { get; set; }
    }

    public class PatientListSettingDto
    {
        public int PatientListDisplayId { get; set; }
        public bool PatientId { get; set; }
        public bool Name { get; set; }
        public bool HomePhone { get; set; }
        public bool MobilePhone { get; set; }
        public bool Address { get; set; }
        public bool DOB { get; set; }
        public bool Attorney { get; set; }
        public bool Paralegal { get; set; }
        public bool Dispatch { get; set; }
        public bool AssignTransport { get; set; }
        public bool Route { get; set; }
        public bool BarcodeNumber { get; set; }
        public bool Gender { get; set; }
        public bool MartialStatus { get; set; }
        public bool HighRisk { get; set; }
        public bool Pregnent { get; set; }
        public long UserId { get; set; }
        public bool REFERRALNAME { get; set; }
        public bool FirstName { get; set; }
        public bool LastName { get; set; }
    }

    public class PatientRequireFieldSettingDto
    {
        public int PatientRequiredFieldsId { get; set; }
        public bool FirstName { get; set; }
        public bool LastName { get; set; }
        public bool Gender { get; set; }
        public bool DOB { get; set; }
        public bool SSNumber { get; set; }
        public bool MaritalStatus { get; set; }
        public bool Address { get; set; }
        public bool UserName { get; set; }
        public bool Email { get; set; }
        public bool Password { get; set; }
        public bool ZipCode { get; set; }
        public bool PatientColorStatus { get; set; }
        public bool Languages { get; set; }
        public bool EmployementStatus { get; set; }
        public bool EmploymentTitle { get; set; }
        public bool ReferralName { get; set; }
        public long UserId { get; set; }
        public bool PatientTreatmentStatus { get; set; }
        public bool PatientLegalStatus { get; set; }
        public bool PhoneNumber { get; set; }
        public bool MobileNumber { get; set; }
        public bool WorkNumber { get; set; }
        public bool EmergencyNumber { get; set; }
    }

}
