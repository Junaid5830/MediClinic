using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class DriverAttendanceAlert
    {
        public long Id { get; set; }
        public int? DriverId { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual DriverProfile Driver { get; set; }
    }
}
