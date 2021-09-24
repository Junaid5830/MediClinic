using MediClinic.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace MediClinic.Models.DTOs
{
    public class ClaimBasicDto
    {
        public int Claim_Id { get; set; }
        [Required(ErrorMessage = "Bill Date is required")]

        public DateTime? BillDate { get; set; }
        [Required(ErrorMessage = "Due Date is required")]


        public DateTime? DueDate { get; set; }
        public DateTime? DateOfService { get; set; }
        [Required(ErrorMessage = "Duration Date is required")]

        public DateTime? DurationOfService { get; set; }
        public string TypeOfService { get; set; }
        [Required(ErrorMessage = "DOS From Date is required")]

        public DateTime? DosFrom { get; set; }
        [Required(ErrorMessage = "DOS To Date is required")]

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
        public int? VisitId { get; set; }
        public virtual CPTCodes CPTCodeNavigation { get; set; }
        public virtual ICDCodes ICDCodeNavigation { get; set; }
    }

    public class ICDDto
    {
        public long ICDCodeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class CPTCodeDto
    {
        public long CPTCodeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

}
