using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class DriverJobRequestStatus
    {
        public long CurrentRequestStatusId { get; set; }
        public int? StatusId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? RequestId { get; set; }

        public virtual DriverJobRequest Request { get; set; }
        public virtual Lookups Status { get; set; }
    }
}
