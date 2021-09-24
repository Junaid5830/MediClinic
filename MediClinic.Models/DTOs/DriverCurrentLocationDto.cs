using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MediClinic.Models.DTOs
{
    public class DriverCurrentLocationDto
    {
        [JsonIgnore]

        public int CurrentLocationId { get; set; }
        public int DriverId { get; set; }
        public string Driverlat { get; set; }
        public string Driverlng { get; set; }
    }
}
