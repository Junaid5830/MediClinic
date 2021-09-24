using MediClinic.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Models.DTOs
{
    public class InvoiceChargesDto
    {
        public int InvoiceChargesId { get; set; }
        public int? InvoiceFId { get; set; }
        public string Product { get; set; }
        public string Description { get; set; }
        public int? Qty { get; set; }
        public double? Rate { get; set; }
        public double? Amount { get; set; }

        public virtual Invoices InvoiceF { get; set; }
    }
}
