using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class DriverAttendance
    {
        public long AttendanceId { get; set; }
        public int? AttendanceTypeId { get; set; }
        public TimeSpan? CheckIn { get; set; }
        public TimeSpan? CheckOut { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? DriverId { get; set; }

        public virtual Lookups AttendanceType { get; set; }
        public virtual DriverProfile Driver { get; set; }
    }
}
