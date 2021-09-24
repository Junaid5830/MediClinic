using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MediClinic.Models.ApiDtos
{
    public class AttendanceDto
    {
        public long AttendanceId { get; set; }
        [JsonIgnore]
        public long AttendanceTypeId { get; set; }
        public long DriverId { get; set; }

        public int AttendanceStatus { get; set; }
        [JsonIgnore]
        public DateTime? CreatedDate { get; set; }
      

    }
}
