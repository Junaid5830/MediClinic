using MediClinic.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;
using MediClinic.Models.DTOs;

namespace MediClinic.Models.DTOs
{
    public class ImmunizationBasicDto
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
        public int VisitId { get; set; }
        public virtual PatientInfo PatientInfo { get; set; }
        public virtual ProviderInfo ProviderInfo { get; set; }

    }
    
}
