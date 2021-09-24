using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Models.ApiDtos
{
    public class DriverProfileApiDto
    {
        public int DriverId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string MobilePhone { get; set; }
        public string HomePhone { get; set; }
        public string EmergencyPhone { get; set; }
        public string OtherPhone { get; set; }
        public string Email { get; set; }
        public DateTime? DOB { get; set; }
        public string SSNNumber { get; set; }
        public string DriverLicence { get; set; }
        public string LicenseState { get; set; }
        public string LicenseClass { get; set; }
        public string DriverImage { get; set; }
        public string DriverSignature { get; set; }
        public int? TransportId { get; set; }
        public bool? IsOwnVehicle { get; set; }
       
        public List<Langauges> Langauges { get; set; }
        public string Token { get; set; }
        public string Gender { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
    public class Langauges
    {
        public string LanguageName { get; set; }
        public int LanguageId { get; set; }
    }
}
