using MediClinic.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Models.DTOs
{
    public class MessagesDto
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
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public virtual Users From { get; set; }
        public virtual Users To { get; set; }
        public long UserID { get; set; }
        public string FacilityName { get; set; }
        public string SenderName { get; set; }
    }
}
