using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Models.DTOs
{
    public class JobNotificationThreadDto
    {
        public int DriverId { get; set; }
        public string RequestLatitude { get; set; }
        public string RequestLongitude { get; set; }
        public string NotificationTitle { get; set; }
        public string DestinationAddress { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string DeviceToken { get; set; }
        public int DeviceTypeId { get; set; }
    }
}
