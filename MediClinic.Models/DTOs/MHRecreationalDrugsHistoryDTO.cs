using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs.PMHistory
{
    public class MHRecreationalDrugsHistoryDTO
    {
        public int Id { get; set; }
        public int? PatientId { get; set; }
        [Required(ErrorMessage = "Drugs field is required")]
        public string Drugs { get; set; }
        [Required(ErrorMessage = "Drugs type is required")]
        public string RecreationalDugsType { get; set; }
        public int? RecreationDrugsAmount { get; set; }
        public int? RecreationalDrugsLastUsed { get; set; }
        public string RecreationDrugsNotes { get; set; }
    }
}
