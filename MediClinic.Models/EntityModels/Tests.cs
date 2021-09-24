using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class Tests
    {
        public int TestId { get; set; }
        public int? VisitProcedureCategory { get; set; }
        public DateTime? DateTime { get; set; }
        public long ICDCodeId { get; set; }
        public long CPTCodeId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? VisitId { get; set; }
        public long? ProviderInfoId { get; set; }

        public virtual CPTCodes CPTCode { get; set; }
        public virtual ICDCodes ICDCode { get; set; }
        public virtual ProviderInfo ProviderInfo { get; set; }
        public virtual Visits Visit { get; set; }
    }
}
