using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Models.DTOs
{
    public class SupplierAssignedDmeDto
    {
        public int DmePatientId { get; set; }
        public decimal FeeSchedule { get; set; }
        public int Duration { get; set; }
        public decimal Charges { get; set; }
        public string Denominations { get; set; }
        public string StockNumber { get; set; }
        public DateTime PrescriptionDate { get; set; }
        public DateTime EstimatedEndDate { get; set; }
        public string Manufactures { get; set; }
        public string CPTCode { get; set; }
        public string GroupName { get; set; }
        public string PatientName { get; set; }
        public string PrescriberName { get; set; }
        public string BillingOption { get; set; }
        public string CurrentStatus { get; set; }
    }
}
