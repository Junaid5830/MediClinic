using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class CptHspcCodes
    {
        public int CptCodeId { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public string Modifier { get; set; }
        public string Type { get; set; }
        public string VisitType { get; set; }
        public string Currency { get; set; }
        public string FeeSchedule { get; set; }
        public string CptHspcCode { get; set; }
    }
}
