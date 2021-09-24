using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class DME
    {
        public int DMEId { get; set; }
        public DateTime? PrescriptionDate { get; set; }
        public int? ItemId { get; set; }
        public long? CPTCodeId { get; set; }
        public long? ICDCodeId { get; set; }
        public int? PrescriberId { get; set; }
        public string BarcodeNo { get; set; }
        public int? PrescriptionRefNo { get; set; }
        public int? IsActive { get; set; }
        public string ImageUrl { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual CPTCodes CPTCode { get; set; }
        public virtual ICDCodes ICDCode { get; set; }
    }
}
