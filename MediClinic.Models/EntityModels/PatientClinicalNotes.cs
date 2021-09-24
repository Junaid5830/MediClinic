using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class PatientClinicalNotes
    {
        public int ClinicalNoteId { get; set; }
        public string NoteNo { get; set; }
        public long NoteBy { get; set; }
        public int? NoteType { get; set; }
        public string WriteNote { get; set; }
        public long? PatientId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? NoteDate { get; set; }
        public bool? IsSigned { get; set; }
        public int? VisitId { get; set; }
        public string ObjectiveNotes { get; set; }
        public string AssessmentNotes { get; set; }
        public string PlanNotes { get; set; }
        public int? HistoryOfIllnessId { get; set; }
        public int? RosId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }

        public virtual ClinicalHistoryOfillness HistoryOfIllness { get; set; }
        public virtual ProviderInfo NoteByNavigation { get; set; }
        public virtual PatientInfo Patient { get; set; }
        public virtual ClincalROS Ros { get; set; }
        public virtual Visits Visit { get; set; }
    }
}
