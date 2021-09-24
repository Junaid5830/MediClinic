using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class Claims
    {
        public int Claim_Id { get; set; }
        public DateTime? BillDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? DateOfService { get; set; }
        public DateTime? DurationOfService { get; set; }
        public string TypeOfService { get; set; }
        public DateTime? DosFrom { get; set; }
        public DateTime? DosTo { get; set; }
        public string PlaceOfService { get; set; }
        public string DescriptionOfService { get; set; }
        public string CaseType { get; set; }
        public string FeeSchedule { get; set; }
        public long? CPTCode { get; set; }
        public string TotalBill { get; set; }
        public string OutStandingBalance { get; set; }
        public long? ICDCode { get; set; }
        public string DiagnosisCode { get; set; }
        public string ReferringProvider { get; set; }
        public string TreatingProvider { get; set; }
        public string Assistant { get; set; }
        public string BillStatus { get; set; }
        public string TrackingNo { get; set; }
        public bool isActive { get; set; }
        public int? VisitId { get; set; }

        public virtual CPTCodes CPTCodeNavigation { get; set; }
        public virtual ICDCodes ICDCodeNavigation { get; set; }
        public virtual Visits Visit { get; set; }
    }
}
