using AutoMapper;
using Dapper;
using MediClinic.Models.DTOs;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces;
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

namespace MediClinic.Services.Services
{
    public class PushNotificationService : IPushNotificationService
    {
        private MediClinicContext _context;
        private IMapper _mapper;
        public PushNotificationService(MediClinicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool SaveDriverJobNotifictionThread(List<JobNotificationThreadDto> threadDto)
        {
            var mapped = _mapper.Map<List<JobNotificationThread>>(threadDto);

             _context.JobNotificationThread.AddRange(mapped);
             _context.SaveChanges();

            return true; 
        }

        public Task<bool> AddDeviceTokenActive(int userId, int deviceTypeId, string token)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveDeviceTokenActive(int userId)
        {
            throw new NotImplementedException();
        }


        public void GetDriversForAttendanceNotification()
        {
            try
            {
                 using var conn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString);
                var result = conn.Query<string>(sql: "[dbo].[GetDriversForAttendanceNotification]",
                commandType: CommandType.StoredProcedure);
                var builder = new StringBuilder();
                foreach (var r in result)
                {
                    builder.Append(r);
                }
                var response = JsonConvert.DeserializeObject<List<AttendanceNotificationDto>>(builder.ToString());
                var toBeSentNotifications = new List<DriverDevicesForNotify>();
                var driverAlert = new List<DriverAttendanceAlert>();

                if (!(response is null) && response.Count > 0)
                {
                    foreach (var item in response)
                    {
                        if (!string.IsNullOrEmpty(item.WorkingStartTime))
                        {
                            var index = item.WorkingStartTime.LastIndexOf(':');
                            item.WorkingStartTime = item.WorkingStartTime.Substring(0, index);

                            var time = DateTime.ParseExact(item.WorkingStartTime, "HH:mm", CultureInfo.InvariantCulture).TimeOfDay;
                            var currentTime = DateTime.UtcNow.TimeOfDay;

                            var startSpan = new TimeSpan(currentTime.Hours, currentTime.Minutes - 10, 0);
                            var endSpan = new TimeSpan(currentTime.Hours,currentTime.Minutes + 10,0);

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
                        PushNotification.SendToMultiple(toBeSentNotifications.Select(x=>x.DeviceToken).ToList(), NotificationTitle.AttendanceAlert, NotificationTitle.NotifyAlertForAttendance, Convert.ToInt32(NotificationType.AttendanceAlert), "MediClinic-EMR");
                        _context.DriverAttendanceAlert.AddRange(driverAlert);
                        _context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
