using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class DriverCurrentLocation
    {
        public int CurrentLocationId { get; set; }
        public int DriverId { get; set; }
        public string Driverlat { get; set; }
        public string Driverlng { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual DriverProfile Driver { get; set; }
    }
}
