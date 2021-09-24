using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class CheckInOut
    {
        public int CheckInOutId { get; set; }
        public long? UserId { get; set; }
        public TimeSpan? CheckInTime { get; set; }
        public TimeSpan? CheckOutTime { get; set; }
        public TimeSpan? TotalHours { get; set; }
        public DateTime? Date { get; set; }

        public virtual Users User { get; set; }
    }
}
