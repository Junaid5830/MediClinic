using Dapper;
using MediClinic.Models.DTOs;
using MediClinic.Models.EntityModels;
using MedliClinic.Utilities.Utility;
using MedliClinic.Utilities.Utility.Enum;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.AttendanceJob
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(async () =>
            {
                var driversForNotifications = await GetDriversForAttendanceNotify();
                if (driversForNotifications != null && driversForNotifications.Count > 0)
                {
                    PushNotification.SendToMultiple(driversForNotifications.Select(x => x.DeviceToken).ToList(), NotificationTitle.AttendanceAlert,
                    NotificationTitle.NotifyAlertForAttendance, Convert.ToInt32(NotificationType.AttendanceAlert), "MediClinic-EMR");
                }

            }).GetAwaiter().GetResult();
        }


        private static async Task<List<DriverDevicesForNotify>> GetDriversForAttendanceNotify()
        {
            var toBeSentNotifications = new List<DriverDevicesForNotify>();
            var driverAlert = new List<DriverAttendanceAlert>();

            using (var _context = new MediClinicContext())
            {
                using var conn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString);
                var result = await conn.QueryAsync<string>(sql: "[dbo].[GetDriversForAttendanceNotification]",
                commandType: CommandType.StoredProcedure);
                var builder = new StringBuilder();
                foreach (var r in result)
                {
                    builder.Append(r);
                }
                var response = JsonConvert.DeserializeObject<List<AttendanceNotificationDto>>(builder.ToString());
                

                if (!(response is null) && response.Count > 0)
                {
                    foreach (var item in response)
                    {
                        if (!string.IsNullOrEmpty(item.WorkingStartTime))
                        {
                            var index = item.WorkingStartTime.LastIndexOf(':');
                            item.WorkingStartTime = item.WorkingStartTime.Substring(0, index);

                            var time = DateFormattor.LocalTimeToUTCTime(DateTime.ParseExact(item.WorkingStartTime, "HH:mm", CultureInfo.InvariantCulture).TimeOfDay);
                            var currentTime = DateTime.UtcNow.TimeOfDay;

                            var startSpan = new TimeSpan(currentTime.Hours, currentTime.Minutes - 10, 0);
                            var endSpan = new TimeSpan(currentTime.Hours, currentTime.Minutes + 10, 0);

                            if (startSpan <= time && time <= endSpan)
                            {
                                if (item.devicesNotifyList != null && item.devicesNotifyList.Count > 0)
                                {
                                    foreach (var toBeNotify in item.devicesNotifyList)
                                    {
                                        toBeSentNotifications.Add(new DriverDevicesForNotify() { DeviceToken = toBeNotify.DeviceToken, DeviceTypeId = toBeNotify.DeviceTypeId });
                                    }
                                    driverAlert.Add(new DriverAttendanceAlert() { DriverId = item.DriverId, CreatedDate = DateTime.UtcNow });
                                }
                            }
                        }
                    }
                    if (toBeSentNotifications != null && toBeSentNotifications.Count > 0)
                    {
                        await _context.DriverAttendanceAlert.AddRangeAsync(driverAlert);
                        await _context.SaveChangesAsync();
                    }
                }
            }

            return toBeSentNotifications;
        }
    }
}
