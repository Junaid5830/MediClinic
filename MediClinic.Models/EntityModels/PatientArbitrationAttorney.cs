using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class PatientArbitrationAttorney
    {
        public long ArbitrationAttorneyID { get; set; }
        public bool FromAttorney { get; set; }
        public bool ToAttorney { get; set; }
        public bool OfAttorney { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string PhoneNumber { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public int? LeadingParalegalId { get; set; }
        public string LeadingParalegalPhone { get; set; }
        public string LeadingParalegalExtension { get; set; }
        public string LeadingParalegalEmail { get; set; }
        public string LeadingParalegalFax { get; set; }
        public string LegalStatus { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedById { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedById { get; set; }
        public bool IsActive { get; set; }
        public long UserId { get; set; }
        public int? FirmId { get; set; }
        public int? AttorneyId { get; set; }
        public int? LeadingAttorneyId { get; set; }
        public string LeadingAttorneyPhone { get; set; }
        public string LeadingAttorneyExtension { get; set; }
        public string LeadingAttorneyEmail { get; set; }
        public string LeadingAttorneyFax { get; set; }
        public string AttorneyFields { get; set; }

        public virtual LegalInfoAttorneyName Attorney { get; set; }
        public virtual LegalInfoFirmName Firm { get; set; }
        public virtual LegalInfoLeadingAttorney LeadingAttorney { get; set; }
        public virtual LegalInfoLeadingParalegal LeadingParalegal { get; set; }
        public virtual Users User { get; set; }
    }
}
