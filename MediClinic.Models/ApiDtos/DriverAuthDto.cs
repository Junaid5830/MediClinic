using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Models.ApiDtos
{
    public class DriverAuthDto
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public int DeviceTypeId { get; set; }
        public string DeviceToken { get; set; } = string.Empty;
    }

    public class LogoutRequestDto
    {
        public long DriverId { get; set; }
        public int DeviceTypeId { get; set; }
        public string DeviceToken { get; set; }
    }
}
