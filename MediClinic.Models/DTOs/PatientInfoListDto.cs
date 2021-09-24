using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Models.DTOs.PatientInfoListDto
{
    public class PatientInfoListDto
    {
        public long PatientInfoId { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int GenderId { get; set; }
        public string Gender { get; set; }
        public string PatientLanguage { get; set; }
        public string LanguageName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? MaitalStatusId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZIP { get; set; }
        public string ReferralName { get; set; }
        public Nullable<double> Rating { get; set; }
        public long UserId { get; set; }
        public int? PatientTreatmentId { get; set; }
        public int? PatientLegalId { get; set; }
        public string EmergencyMobileNumber { get; set; }
        public string EmergencyPerson { get; set; }
        public string AdjusterName { get; set; }
        public string AdjusterID { get; set; }
        public string AdjusterExtension { get; set; }
        public string AdjusterFax { get; set; }
        public string AdjusterEmail { get; set; }
        public string UserName { get; set; }
        public string PolicyNumber { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }

        public long PhoneNumberId { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public string MobilePhone { get; set; }
        public string EmergencyPhone { get; set; }
        public int Age { get; set; }
        public string PlaceOfIncident { get; set; }
        public string FirstNameLetter { get; set; }
        public string LastNameLetter { get; set; }
        public string Color { get; set; }
        public string MaritalStatus { get; set; }
        public string PaitentImage { get; set; }
        public string CaseTypeName { get; set; }
        public string PatientSignature { get; set; }

        public string PatientClaimID { get; set; }
        public string PrimaryInsuranceProvider { get; set; }
        public string ClaimInfoAddress { get; set; }
        public string ClaimInfoState { get; set; }
        public string ClaimInfoZip { get; set; }
        public string ClaimInfoCountry { get; set; }
        public string ClaimInfoCity { get; set; }
        public string ClaimInfoWebPage { get; set; }
        public string PrimaryPhone { get; set; }
        public string ClaimInfoFax { get; set; }

        public string AttorneyName { get; set; }
        public string LeadingParalegalName { get; set; }
        public string CollectionAttorney { get; set; }
 
        public string SSN { get; set; }
        public string WCBNumber { get; set; }
        public string CarrierCaseNumber { get; set; }
        public string PolicyHolderName { get; set; }
        public DateTime PlaceTimeOfAccident { get; set; }
        public string FullInsuranceInfo { get; set; }
        public string FullClaimInfo { get; set; }
        public DateTime Nf2fillingDate { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime TimeOfIncident { get; set; }
        public string IncidentInCourse { get; set; }
        public string WasCasuseOfEmployment { get; set; }
        public string PolicyLimits { get; set; }
        public string GroupNumber { get; set; }
        public DateTime PolicyEffectiveDate { get; set; }
        public string RelationShipToPolicyHolder { get; set; }
        public string PolicyEffectAtIncidentTime { get; set; }
        public DateTime PolicyEffectEndDate { get; set; }
        public string FirstVisit { get; set; }
        public string NumberOfVisits { get; set; }
        public string AllVisits { get; set; }
        public string CoPay { get; set; }
        public string LastEUO { get; set; }
        public string LastIME { get; set; }
        public string CurrentLocationInFacility { get; set; }

        public string CurrentStatus { get; set; }
    }

}
