using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class Immunization
    {
        public int ImmunizationId { get; set; }
        public string VaccineName { get; set; }
        public string VaccineAbberivation { get; set; }
        public DateTime? PatientCurrentAge { get; set; }
        public string DoesInRouten { get; set; }
        public string ICDCode { get; set; }
        public DateTime? RouteOfAdministration { get; set; }
        public string Route { get; set; }
        public bool? ReasonOfVaccine { get; set; }
        public bool? IsActive { get; set; }
        public long? PatientInfoId { get; set; }
        public long? ProviderInfoId { get; set; }
        public DateTime? IsCretedDate { get; set; }
        public int? IsCretedId { get; set; }
        public DateTime? IsModifiedDate { get; set; }
        public int? IsModifiedId { get; set; }
        public int? VisitId { get; set; }

        public virtual PatientInfo PatientInfo { get; set; }
        public virtual ProviderInfo ProviderInfo { get; set; }
        public virtual Visits Visit { get; set; }
    }
}
