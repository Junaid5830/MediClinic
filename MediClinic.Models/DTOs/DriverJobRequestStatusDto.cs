using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MediClinic.Models.DTOs
{
    public class DriverJobRequestStatusDto
    {
        [JsonIgnore]
        public long CurrentRequestStatusId { get; set; }

        public int RequestId { get; set; }
        public int DriverId { get; set; }
        public int? StatusId { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
