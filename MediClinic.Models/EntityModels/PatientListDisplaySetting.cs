using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class PatientListDisplaySetting
    {
        public int PatientListDisplayId { get; set; }
        public bool? PatientId { get; set; }
        public bool? Name { get; set; }
        public bool? HomePhone { get; set; }
        public bool? MobilePhone { get; set; }
        public bool? Address { get; set; }
        public bool? DOB { get; set; }
        public bool? Attorney { get; set; }
        public bool? Paralegal { get; set; }
        public bool? Dispatch { get; set; }
        public bool? AssignTransport { get; set; }
        public bool? Route { get; set; }
        public bool? BarcodeNumber { get; set; }
        public bool? Gender { get; set; }
        public bool? MartialStatus { get; set; }
        public bool? HighRisk { get; set; }
        public bool? Pregnent { get; set; }
        public long? ProviderId { get; set; }
        public bool? REFERRALNAME { get; set; }
        public long? UserId { get; set; }
        public bool? FirstName { get; set; }
        public bool? LastName { get; set; }

        public virtual ProviderInfo Provider { get; set; }
        public virtual Users User { get; set; }
    }
}
