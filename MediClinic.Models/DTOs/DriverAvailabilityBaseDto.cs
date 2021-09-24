using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Models.DTOs
{
    public class DriverAvailabilityBaseDto
    {
        public int DriverAvailability { get; set; }
        public long DriverId { get; set; }
        public int StatusId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
