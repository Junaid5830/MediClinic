using MediClinic.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs.ProviderInfoDto
{
   public class ProviderDetails
    {
        public long ProviderInfoId { get; set; }
        public string EntityName { get; set; }
        public string ProviderProfilePic { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Speciality { get; set; }
        public string Title { get; set; }
        public string Suffix { get; set; }
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
        public string IsBilledAmountVisible { get; set; }
        public string IsAllowToBill { get; set; }
        public string IsAllowToAddVisits { get; set; }
        public string IsAllowToSchedule { get; set; }
        public string ProviderPermission { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UidType { get; set; }
        public string CodeByMasterProvider { get; set; }
        public string Status { get; set; }
        public string AllowSms { get; set; }
        public long UserId { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Term { get; set; }
        public virtual RelatedFacilities RelatedFacility { get; set; }
        public virtual Lookups RentTypeNavigation { get; set; }
        public virtual ProviderSpecialities SpecialityNavigation { get; set; }
        public virtual Lookups StatusNavigation { get; set; }
        public virtual Lookups SuffixNavigation { get; set; }
        public virtual ProviderTerms TermNavigation { get; set; }
        public virtual Lookups TitleNavigation { get; set; }
        public virtual ProviderUIDTypes UidTypeNavigation { get; set; }
        public virtual Users User { get; set; }
        public string Profileimage { get; set; }
        public string Signatureimage { get; set; }
        public string HiddentWriteSignImage { get; set; }
        public string HiddenSignImg { get; set; }

    }
}
