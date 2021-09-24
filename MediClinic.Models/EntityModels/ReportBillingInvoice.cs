using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class ReportBillingInvoice
    {
        public int ReportBillingInvoiceId { get; set; }
        public DateTime? DateForm { get; set; }
        public DateTime? DateTo { get; set; }
        public string PlaceOfService { get; set; }
        public string LeaveBank { get; set; }
        public string CPT { get; set; }
        public string Modifier { get; set; }
        public string DisgnosisCode { get; set; }
        public string Charges { get; set; }
        public string DaysOrUnits { get; set; }
        public string COB { get; set; }
        public string Zip { get; set; }
        public int? ReportBillingInfoId { get; set; }

        public virtual ReportBillingInformation ReportBillingInfo { get; set; }
    }
}
