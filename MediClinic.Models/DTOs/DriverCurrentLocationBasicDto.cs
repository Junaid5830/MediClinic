using MediClinic.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Models.DTOs
{
    public class DriverCurrentLocationBasicDto
    {
        public int CurrentLocationId { get; set; }
        public int DriverId { get; set; }
        public string Driverlat { get; set; }
        public string Driverlng { get; set; }

        public int TransportId { get; set; }
        public string FullName { get; set; }
    }
}
