using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class IME
    {
        public int ID { get; set; }
        public DateTime? Date { get; set; }
        public TimeSpan? Time { get; set; }
        public string IME_Place { get; set; }
        public string Represented_By { get; set; }
        public string IME_Status { get; set; }
        public string Reason { get; set; }
        public string Transcripts { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public int? VisitId { get; set; }

        public virtual Visits Visit { get; set; }
    }
}
