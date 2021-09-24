using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class ClaimEmail
    {
        public int ClaimEmailId { get; set; }
        public string Subject { get; set; }
        public string SendTo { get; set; }
        public string Message { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
