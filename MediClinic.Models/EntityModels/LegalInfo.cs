using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class LegalInfo
    {
        public int LegalInfoId { get; set; }
        public int? options { get; set; }
        public bool FromAttorney { get; set; }
        public bool ToAttorney { get; set; }
        public bool OfAttorney { get; set; }
        public string FirmName { get; set; }
        public string AttorneyName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string Country { get; set; }
        public string city { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string PhoneNumber { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string LeadingName { get; set; }
        public string LeadingPhone { get; set; }
        public string LeadingExtension { get; set; }
        public string LeadingEmail { get; set; }
        public string LeadingFax { get; set; }
        public string LegalStatus { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
