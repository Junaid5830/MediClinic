using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class PatientMedicationsTemplate
    {
        public long Id { get; set; }
        public long TemplateId { get; set; }
        public long MedicineId { get; set; }
        public int? Quantity { get; set; }
        public string FrequencyId { get; set; }
        public int? Dose { get; set; }
        public string Unit { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Notes { get; set; }
        public int? VisitId { get; set; }

        public virtual Medicines Medicine { get; set; }
        public virtual PrescriptionTemplates Template { get; set; }
    }
}
