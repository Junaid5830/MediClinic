using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class Allergy
    {
        public int ID { get; set; }
        public int Type { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public DateTime DateIdentified { get; set; }
        public int? Severity { get; set; }
        public string Reaction { get; set; }
        public DateTime? DateInactivated { get; set; }
        public string ExternalProviderId { get; set; }
        public string Notes { get; set; }
        public int? PatientProfileId { get; set; }
        public int? Createdby { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
