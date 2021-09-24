using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs.PMHistory
{
    public class MHSurgicalHistoryDTO
    {
        public int Id { get; set; }
        public int? PatientId { get; set; }
        public string Disease { get; set; }

        [Required(ErrorMessage = "Surgery Type is required")]
        [StringLength(50, ErrorMessage = "Surgery Type cannot be longer than {1} characters.")]
        public string SurgeryType { get; set; }
        [StringLength(50, ErrorMessage = "Surgeon Name cannot be longer than {1} characters.")]
        public string SurgeonName { get; set; }
        public int? Year { get; set; }
        [StringLength(500, ErrorMessage = "Notes cannot be longer than {1} characters.")]
        public string Notes { get; set; }
    }
}
