using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Models.DTOs.ProviderBasicSummaryDto
{
    public class ProviderSummaryDto
    {
        public string FullName { get; set; }
        public string Speciality { get; set; }
        public string Title { get; set; }
        public string Suffix { get; set; }
        public string LicenseNo { get; set; }
        public string NpiNumber { get; set; }
        public string PhoneNo { get; set; }
        public string AddressLine1 { get; set; }
        public DateTime CreatedDate { get; set; }
        public string EntityName { get; set; }
        public string ProviderProfilePic { get; set; }
        public string Email { get; set; }
        public string SignImage { get; set; }
    }
}
