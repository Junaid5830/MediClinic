using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class AssistanInfo
    {
        public long AssistantInfoID { get; set; }
        public string EntityName { get; set; }
        public string ReminderBy { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int? SpecialityID { get; set; }
        public int? TittleID { get; set; }
        public int? Suffix { get; set; }
        public string LicenseNo { get; set; }
        public string NpiNumber { get; set; }
        public string TaxID { get; set; }
        public string AssignRoomNo { get; set; }
        public string RentFee { get; set; }
        public int? RentType { get; set; }
        public int? ScannedDocument { get; set; }
        public string ElectronicSignPassword { get; set; }
        public string WriteSignature { get; set; }
        public string SignImage { get; set; }
        public string PhoneNo { get; set; }
        public string MobileNo { get; set; }
        public string FaxNo { get; set; }
        public string Email { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public long? UserID { get; set; }
        public int? Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public string FacilityAssociation { get; set; }
        public string FacilityAddress1 { get; set; }
        public string FacilityAddress2 { get; set; }
        public string FacilityAddress3 { get; set; }
        public string FacilityZip { get; set; }
        public string FacilityCity { get; set; }
        public string FacilityState { get; set; }
        public string FacilityCountry { get; set; }
        public string FacilityEmail { get; set; }
        public string FacilityPhone { get; set; }
        public bool AuthorizedToPrescribe { get; set; }
        public bool AuthorizedToExamin { get; set; }
        public bool AuthorizedToBill { get; set; }
        public bool AuthorizedFaceId { get; set; }
        public bool AuthorizedBioMetric { get; set; }
        public bool isFromSetting { get; set; }
        public DateTime? DOB { get; set; }
        public string BillPeriod { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
