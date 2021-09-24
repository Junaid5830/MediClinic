using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;


namespace MediClinic.Models.ApiDtos
{
    public class DriverProfileUpdateDto
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
        public DateTime? DOB { get; set; }
        public string SSNNumber { get; set; }
        public string DriverLicence { get; set; }
        public string LicenseState { get; set; }
        public string LicenseClass { get; set; }
        public string Languages { get; set; }

        [JsonIgnore]

        public string Email { get; set; }
        public string DriverImage { get; set; }
        public string DriverSignature { get; set; }
        [JsonIgnore]

        public string Password { get; set; }


        public string Gender { get; set; }
    }
}
