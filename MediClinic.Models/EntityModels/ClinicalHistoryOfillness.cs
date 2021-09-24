using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class ClinicalHistoryOfillness
    {
        public ClinicalHistoryOfillness()
        {
            PatientClinicalNotes = new HashSet<PatientClinicalNotes>();
        }

        public int HistoryOfillnessId { get; set; }
        public string Location { get; set; }
        public string LocationComments { get; set; }
        public string Quantity { get; set; }
        public string QuantityComments { get; set; }
        public string Severity { get; set; }
        public string SeverityComments { get; set; }
        public string Duration { get; set; }
        public string DurationComments { get; set; }
        public string Onset { get; set; }
        public string OnsetComments { get; set; }
        public string Context { get; set; }
        public string ContextComments { get; set; }
        public string Factor { get; set; }
        public string FactorComments { get; set; }
        public string Associated { get; set; }
        public string AssociatedComments { get; set; }
        public string PreviousTreatment { get; set; }

        public virtual ICollection<PatientClinicalNotes> PatientClinicalNotes { get; set; }
    }
}
