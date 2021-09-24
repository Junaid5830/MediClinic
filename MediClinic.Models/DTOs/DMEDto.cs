using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Models.DTOs
{
    public class DMEDto
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

    }
}
