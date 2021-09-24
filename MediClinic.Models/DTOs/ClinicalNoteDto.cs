using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs.ClinicalNotesDto
{
    public class ClinicalNoteDto
    {
        public int ClinicalNoteId { get; set; }
        public string NoteNo { get; set; }
        public long NoteBy { get; set; }
        public int NoteType { get; set; }
        [Required(ErrorMessage = "Please 'provide Notes")]
        public string WriteNote { get; set; }
        public string ObjectiveNotes { get; set; }
        public string AssessmentNotes { get; set; }
        public string PlanNotes { get; set; }
        public long? PatientId { get; set; }
        public bool? IsActive { get; set; }
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]

        [Required(ErrorMessage = "Please provide notes date")]
        [DisplayName("Note Date")]
        [DataType(DataType.Date)]
        public DateTime NoteDate { get; set; }
        public string NoteTypeValue { get; set; }
        public string WriterName { get; set; }
        public bool? IsSigned { get; set; }
        public int? VisitId { get; set; }
        public int? RosId { get; set; }
        public int? HistoryOfIllnessId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }

    }
}
