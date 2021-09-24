using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs.PMHistory
{
   public  class MHPastDiseaseHistoryDTO
    {
        public int Id { get; set; }
        public int? PatientId { get; set; }
        [Required(ErrorMessage = "Disease Name is required")]
        [StringLength(100, ErrorMessage = "Disease Name cannot be longer than {1} characters.")]
        public string Name { get; set; }
        [StringLength(500, ErrorMessage = "Notes cannot be longer than {1} characters.")]
        public string Notes { get; set; }
    }
}
