using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace MediClinic.Models.DTOs
{
    public class DriverAvailabilityDto
    {
        [JsonIgnore]
        public int DriverAvailabilityId { get; set; }
        public int? DriverId { get; set; }
        public bool StatusId { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
