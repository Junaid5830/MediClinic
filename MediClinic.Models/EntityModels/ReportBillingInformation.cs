using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class ReportBillingInformation
    {
        public ReportBillingInformation()
        {
            ReportBillingCode = new HashSet<ReportBillingCode>();
            ReportBillingInvoice = new HashSet<ReportBillingInvoice>();
        }

        public int ReportBillingInfoId { get; set; }
        public string EmployeeInsuranceCarrier { get; set; }
        public string CarrierCode { get; set; }
        public string InsuranceCarrierAddress { get; set; }
        public string PatientName { get; set; }
        public DateTime? DateOfInjury { get; set; }
        public bool PPO { get; set; }
        public int? VisitId { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string zip { get; set; }
        public string TotalCharge { get; set; }
        public string AmountPaid { get; set; }
        public string BalanceDue { get; set; }

        public virtual Visits Visit { get; set; }
        public virtual ICollection<ReportBillingCode> ReportBillingCode { get; set; }
        public virtual ICollection<ReportBillingInvoice> ReportBillingInvoice { get; set; }
    }
}
