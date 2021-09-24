using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class EUO
    {
        public int EUOId { get; set; }
        public DateTime? Date { get; set; }
        public TimeSpan Time { get; set; }
        public int? Place { get; set; }
        public int? RepresentedBy { get; set; }
        public int? Status { get; set; }
        public int? Reason { get; set; }
        public int? Transcripts { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? VisitId { get; set; }

        public virtual Visits Visit { get; set; }
    }
}
