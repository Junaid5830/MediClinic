using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediClinic.Models
{
    public class ProviderJsonConversionClass
    {
        public long? ProviderInfoId { get; set; }
        public string EntityName { get; set; }
        public string ProviderProfilePic { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int? Speciality { get; set; }
        public int? Title { get; set; }
        public int? Suffix { get; set; }
        public string LicenseNo { get; set; }
        public string NpiNumber { get; set; }
        public string TaxId { get; set; }
        public string AssignRoomNo { get; set; }
        public string Rent { get; set; }
        public int? RentType { get; set; }
        public int? ScannedDocuments { get; set; }
        public string ElectronicSignPassword { get; set; }
        public string ElectronicConfirmPassword { get; set; }
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
        public int? RelatedFacilityId { get; set; }
        public bool? IsBilledAmountVisible { get; set; }
        public bool? IsAllowToBill { get; set; }
        public bool? IsAllowToAddVisits { get; set; }
        public bool? IsAllowToSchedule { get; set; }
        public int? ProviderPermissions { get; set; }
        public int? UidType { get; set; }
        public string CodeByMasterProvider { get; set; }
        public int? Status { get; set; }
        public bool? AllowSms { get; set; }
        public long? UserId { get; set; }
        public int? Term { get; set; }
    }
}
