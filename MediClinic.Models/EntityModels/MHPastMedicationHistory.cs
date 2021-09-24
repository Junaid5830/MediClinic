using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class MHPastMedicationHistory
    {
        public int Id { get; set; }
        public int? PatientId { get; set; }
        public string Name { get; set; }
        public string ReasonForMedicine { get; set; }
        public string DocName { get; set; }
        public string DocNumber { get; set; }
        public string PharName { get; set; }
        public string PharNumber { get; set; }
        public string Dose { get; set; }
        public bool AsNeeded { get; set; }
        public string DoseFrequency { get; set; }
        public string Notes { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
