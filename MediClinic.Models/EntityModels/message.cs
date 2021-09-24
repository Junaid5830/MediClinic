using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class message
    {
        public int message_id { get; set; }
        public long from_id { get; set; }
        public long to_id { get; set; }
        public string message1 { get; set; }
        public int? status_id { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual Users to_ { get; set; }
    }
}
