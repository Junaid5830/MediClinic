using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class SubContractorInfo
    {
        public long SubContractorId { get; set; }
        public string EntityName { get; set; }
        public string SubContractorProfilePic { get; set; }
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
        public long? UserId { get; set; }
        public string Password { get; set; }
        public int? Status { get; set; }
    }
}
