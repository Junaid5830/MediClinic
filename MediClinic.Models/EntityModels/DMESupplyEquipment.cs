using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class DMESupplyEquipment
    {
        public int DMEEquipSupId { get; set; }
        public DateTime? PrescriptionDate { get; set; }
        public long? ICDCodeId { get; set; }
        public long? CPTCodeId { get; set; }
        public long? PrescriberId { get; set; }
        public string BarcodeNo { get; set; }
        public string ImageUrl { get; set; }
        public bool? IsActive { get; set; }
        public long? PatientId { get; set; }
        public long? UserId { get; set; }
        public int? ItemId { get; set; }
        public string PrescriptionRefNo { get; set; }
        public int? VisitId { get; set; }
        public string QRCodeImageUrl { get; set; }

        public virtual CPTCodes CPTCode { get; set; }
        public virtual ICDCodes ICDCode { get; set; }
        public virtual DMESupEquipItems Item { get; set; }
        public virtual PatientInfo Patient { get; set; }
        public virtual ProviderInfo Prescriber { get; set; }
        public virtual Users User { get; set; }
        public virtual Visits Visit { get; set; }
    }
}
