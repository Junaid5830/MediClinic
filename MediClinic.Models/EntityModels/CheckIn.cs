using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class CheckIn
    {
        public int id { get; set; }
        public string Type { get; set; }
        public string DAY { get; set; }
        public string DATE { get; set; }
        public string CHECKIN1 { get; set; }
        public string CHECKOUT { get; set; }
        public string HOURS { get; set; }
        public string ACTION { get; set; }
    }
}
