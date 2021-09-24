using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class TransportAttachments
    {
        public long TransportAttachmentId { get; set; }
        public string AttachmentUrl { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? IsActive { get; set; }
        public int? TransportId { get; set; }

        public virtual TransportEms Transport { get; set; }
    }
}
