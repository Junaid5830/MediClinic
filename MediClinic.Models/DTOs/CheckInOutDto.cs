using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Models.DTOs
{
    public class CheckInOutDto
    {
        public int CheckInOutId { get; set; }
        public long? UserId { get; set; }
        public TimeSpan? CheckInTime { get; set; }
        public TimeSpan? CheckOutTime { get; set; }
        public TimeSpan? TotalHours { get; set; }
        public DateTime? Date { get; set; }

        public int? Hours { get; set; }
        public string UserName { get; set; }

        public string RoleType { get; set; }
    }
}
