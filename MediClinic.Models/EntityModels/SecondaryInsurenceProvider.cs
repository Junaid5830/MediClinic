using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class SecondaryInsurenceProvider
    {
        public long SecondaryInsuranceProviderID { get; set; }
        public int? ProviderId { get; set; }
        public string PlanName { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public string PolicyNumber { get; set; }
        public int? GroupId { get; set; }
        public string SubscriberEmployer { get; set; }
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
        public string website { get; set; }
        public long UserId { get; set; }
        public long? CreatedById { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? ModifiedById { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual InsuranceGroupNumber Group { get; set; }
        public virtual InsuranceProviderName Provider { get; set; }
        public virtual Users User { get; set; }
    }
}
