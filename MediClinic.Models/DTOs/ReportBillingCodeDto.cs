using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Models.DTOs
{
    public class ReportBillingCodeDto
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

    }
}
