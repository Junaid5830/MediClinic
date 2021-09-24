using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class ReportBillingCode
    {
        public int BillCodeId { get; set; }
        public string ICDCode { get; set; }
        public string ICDCodeDescriptionOne { get; set; }
        public string ICDCodeTwo { get; set; }
        public string ICDCodeDescriptionTwo { get; set; }
        public string ICDCodeThree { get; set; }
        public string ICDCodeDescriptionThree { get; set; }
        public string ICDCodeFour { get; set; }
        public string ICDCodeDescriptionFour { get; set; }
        public int? ReportBillingInfoId { get; set; }

        public virtual ReportBillingInformation ReportBillingInfo { get; set; }
    }
}
