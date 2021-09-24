using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class Messages
    {
        public int MessageId { get; set; }
        public long? FromId { get; set; }
        public long? ToId { get; set; }
        public string Message { get; set; }
        public int? Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public string FromUser { get; set; }
        public string ToUser { get; set; }
        public int? VisitId { get; set; }

        public virtual Users From { get; set; }
        public virtual Users To { get; set; }
        public virtual Visits Visit { get; set; }
    }
}
