using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Models.DTOs
{
    public class AttendanceNotificationDto
    {
        public AttendanceNotificationDto()
        {
            devicesNotifyList = new List<DriverDevicesForNotify>();
        }
        public int DriverId { get; set; }
        public string WorkingStartTime { get; set; }
        public string WorkingEndTime { get; set; }

        public List<DriverDevicesForNotify> devicesNotifyList { get; set; }
    }

    public class DriverDevicesForNotify
    {
        public int DeviceTypeId { get; set; }
        public string DeviceToken { get; set; }
    }

}
