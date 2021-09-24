using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class Invoices
    {
        public Invoices()
        {
            InvoiceCharges = new HashSet<InvoiceCharges>();
        }

        public int InvoiceId { get; set; }
        public long? PatientId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Terms { get; set; }
        public int? Crew { get; set; }
        public string MessageOnInvoice { get; set; }
        public string MessageOnStatement { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedById { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedById { get; set; }
        public string MobileNumber { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public DateTime? DueDate { get; set; }
        public int? VisitId { get; set; }

        public virtual PatientInfo Patient { get; set; }
        public virtual Visits Visit { get; set; }
        public virtual ICollection<InvoiceCharges> InvoiceCharges { get; set; }
    }
}
