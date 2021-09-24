using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class PatientPrescriptions
    {
        public long Id { get; set; }
        public long MedicationId { get; set; }
        public int Quantity { get; set; }
        public string FrequencyId { get; set; }
        public int? Dose { get; set; }
        public string Unit { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Notes { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public long PatientInfoId { get; set; }
        public int? VisitId { get; set; }

        public virtual Medicines Medication { get; set; }
        public virtual PatientInfo PatientInfo { get; set; }
    }
}
