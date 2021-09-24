using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediClinic.Models.DTOs
{
    public class EUODto
    {
        public int EUOId { get; set; }

        [Required(ErrorMessage = "*")]
        public DateTime? Date { get; set; }

        [Required(ErrorMessage = "*")]
        public TimeSpan? Time { get; set; }

        [Required(ErrorMessage = "*")]
        public int? Place { get; set; }

        [Required(ErrorMessage = "*")]
        public int? RepresentedBy { get; set; }

        [Required(ErrorMessage = "*")]
        public int? Status { get; set; }

        [Required(ErrorMessage = "*")]
        public int? Reason { get; set; }

        [Required(ErrorMessage = "*")]
        public int? Transcripts { get; set; }

        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? VisitId { get; set; }
        public string PlaceEUO { get; set; }
        public string RepresentedByEUO { get; set; }
        public string StatusEUO { get; set; }
        public string ReasonEUO { get; set; }
        public string TranscriptsEUO { get; set; }

    }
}
