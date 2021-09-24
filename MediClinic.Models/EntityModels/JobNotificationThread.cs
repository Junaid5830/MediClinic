using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class JobNotificationThread
    {
        public long NotificationThreadID { get; set; }
        public int? DriverId { get; set; }
        public string RequestLatitude { get; set; }
        public string RequestLongitude { get; set; }
        public string NotificationTitle { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string DestinationAddress { get; set; }
        public string DeviceToken { get; set; }
        public int? DeviceTypeId { get; set; }

        public virtual Lookups DeviceType { get; set; }
        public virtual DriverProfile Driver { get; set; }
    }
}
