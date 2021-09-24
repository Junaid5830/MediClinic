using MediClinic.Models.DTOs.DMESuppliesDto;
using MediClinic.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Models.DTOs
{
    public class TestsDto
    {
        public int TestId { get; set; }
        public int? VisitProcedureCategory { get; set; }
        public DateTime? DateTime { get; set; }
        public long? DoctorInfoId { get; set; }
        public long ICDCodeId { get; set; }
        public long CPTCodeId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string VPCategory { get; set; }
        public string DoctorName { get; set; }
        public string DescriptionCPT { get; set; }
        public string DescriptionICD { get; set; }
        public int? VisitId { get; set; }
        public string DocName { get; set; }
        public long? ProviderInfoId { get; set; }
        public virtual CPTCodes CPTCode { get; set; }
        public virtual ProviderInfo ProviderInfo { get; set; }
        public virtual ICDCodes ICDCode { get; set; }

    }

}