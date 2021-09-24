using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class DocumentReports
    {
        public int DocumentId { get; set; }
        public string Scannedby { get; set; }
        public DateTime? ScannedDate { get; set; }
        public TimeSpan? ScannedTime { get; set; }
        public string SourceOfDocument { get; set; }
        public bool DocumentInitalReport { get; set; }
        public bool DocumentDMEPrescription { get; set; }
        public bool DocumentDeclofenac { get; set; }
        public bool DocumentDriverLiecense { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedById { get; set; }
        public bool IsActive { get; set; }
        public int? VisitId { get; set; }

        public virtual Visits Visit { get; set; }
    }
}
