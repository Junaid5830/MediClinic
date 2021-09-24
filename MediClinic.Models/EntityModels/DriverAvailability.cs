using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class DriverAvailability
    {
        public int DriverAvailabilityId { get; set; }
        public int? DriverId { get; set; }
        public bool StatusId { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual DriverProfile Driver { get; set; }
    }
}
