using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs.PMHistory
{
   public  class MHAllergiesHistoryDTO
    {
        public int Id { get; set; }
        public int? PatientId { get; set; }
        [Required(ErrorMessage = "Allergy To is required")]
        [StringLength(50, ErrorMessage = "Allergy To cannot be longer than {1} characters.")]
        public string AllergyTo { get; set; }
        [Required(ErrorMessage = "Reaction is required")]
        [StringLength(50, ErrorMessage = "Reaction cannot be longer than {1} characters.")]
        public string Recation { get; set; }
        [StringLength(500, ErrorMessage = "Notes cannot be longer than {1} characters.")]
        public string Notes { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
