using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class UserDevices
    {
        public int UserDeviceId { get; set; }
        public int? UserId { get; set; }
        public int? DeviceTypeId { get; set; }
        public string DeviceToken { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual Lookups DeviceType { get; set; }
        public virtual DriverProfile User { get; set; }
    }
}
