using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs.PMHistory
{
    public class MHFamilyHistoryDTO
    {
        public int Id { get; set; }
        public int? PatientId { get; set; }
        [Required(ErrorMessage = "Relation is required")]
        public string Relation { get; set; }
        [StringLength(50, ErrorMessage = "Deceased/Death Age cannot be longer than {1} characters.")]
        public string DeceasedOrDeathAge { get; set; }
        [StringLength(500, ErrorMessage = "Medical Conditions Or Cause Death cannot be longer than {1} characters.")]
        public string MedicalConditionsOrCauseDeath { get; set; }
        [StringLength(50, ErrorMessage = "Blood Relative Condition cannot be longer than {1} characters.")]
        public string BloodRelativeCondition { get; set; }
        [StringLength(500, ErrorMessage = "Notes cannot be longer than {1} characters.")]
        public string Notes { get; set; }
    }
}
