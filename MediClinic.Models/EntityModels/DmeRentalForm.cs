using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class DmeRentalForm
    {
        public int RentalFormId { get; set; }
        public int? DmePrescriptionId { get; set; }
        public long? PatientInfoId { get; set; }
        public long? DoctorInfoId { get; set; }
        public int? FacilityAssociationId { get; set; }
        public int? IcdCodeId { get; set; }
        public int? InsuranceCompanyId { get; set; }
        public string InsuranceType { get; set; }
        public string Adjuster { get; set; }
        public string PolicyNo { get; set; }
        public string ClaimNo { get; set; }
        public DateTime? AccidentDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public long? ModifiedBy { get; set; }
    }
}
