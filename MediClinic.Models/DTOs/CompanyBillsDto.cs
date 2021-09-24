using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Models.DTOs
{
    public class CompanyBillsDto
    {
        public int BillId { get; set; }
        public string CompanyType { get; set; }
        public string CompanyName { get; set; }
        public string CompanyInfo { get; set; }
        public string MaterName { get; set; }
        public string MasterUser { get; set; }
        public string MasterUserPassword { get; set; }
        public string AuthorizedToAddUser { get; set; }
        public string CompanyStatus { get; set; }
        public string AuthorizedToViewRecord { get; set; }
        public string AuthorizedToOrderRecord { get; set; }
        public string AuthorizeToEditProfile { get; set; }
        public string AuthorizedToSendInternalMessage { get; set; }
        public string MedicalRecordFeeSchedule { get; set; }
        public string AuthorizeToProviderAllBill { get; set; }
        public string AuthorizedToCreateNewClaims { get; set; }
        public string AuthorizedToEditBill { get; set; }
        public string AuthorizedToEditClaims { get; set; }
        public string AuthorizeToRecreateBill { get; set; }
        public string AuthorizedToEditCptHspcCodes { get; set; }
        public string AuthorizedToEditIcdCode { get; set; }
        public string AuthorizedToEditBillDueDate { get; set; }
        public string AuthorizedToSendNF2Forms { get; set; }
        public string AuthorizedToScanDocuments { get; set; }
        public string AuthorizedToPrintDocuments { get; set; }
        public string AuthorizedToAddSubUsers { get; set; }
        public string AuthorizedToEditBillingSettings { get; set; }
        public string AuthorizedToEditClaimsSettings { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
