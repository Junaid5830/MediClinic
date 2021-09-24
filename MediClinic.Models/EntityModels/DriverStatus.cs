using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class DriverStatus
    {
        public int StatusId { get; set; }
        public long? DriverId { get; set; }
        public int? DriverStatusId { get; set; }
        public TimeSpan? time { get; set; }
        public DateTime? Date { get; set; }
        public TimeSpan? ModfiyTime { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}
