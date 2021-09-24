using MediClinic.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Models.DTOs
{
    public class DmePatientsPrescriptionDto
    {
        public int DmePatientId { get; set; }
        public long? PrescriberId { get; set; }
        public string FacilityAssociation { get; set; }
        public string ReferredBy { get; set; }
        public DateTime? PrescriptionDate { get; set; }
        public string BarCodeNumber { get; set; }
        public int? IcdCodeId { get; set; }
        public int? ReferenceNoId { get; set; }
        public string BillNo { get; set; }
        public string DiagnosisDescription { get; set; }
        public long? PatientId { get; set; }
        public string BillingOption { get; set; }
        public int? Duration { get; set; }
        public string Denominations { get; set; }
        public decimal? FeeSchedule { get; set; }
        public decimal? Charges { get; set; }
        public DateTime? EstimatedEndDate { get; set; }
        public string StockNumber { get; set; }
        public string BarCodeImgUrl { get; set; }
        public int? VisitId { get; set; }
        public int? StatusId { get; set; }
        public int? RentalFormId { get; set; }

        public virtual DMEGroupItem IcdCode { get; set; }
        public virtual PatientInfo Patient { get; set; }
        public virtual ProviderInfo Prescriber { get; set; }
    }
}
