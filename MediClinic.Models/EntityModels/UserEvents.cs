using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class UserEvents
    {
        public int EventId { get; set; }
        public long? UserId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string EventTitle { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
    }
}
