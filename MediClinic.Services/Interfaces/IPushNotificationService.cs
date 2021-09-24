using MediClinic.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces
{
    public interface IPushNotificationService
    {
        Task<bool> AddDeviceTokenActive(int userId, int deviceTypeId, string token);
        Task<bool> RemoveDeviceTokenActive(int userId);
        bool SaveDriverJobNotifictionThread(List<JobNotificationThreadDto> threadDto);


        void GetDriversForAttendanceNotification();
        //Task<List<PushNotificationsResponseDto>> GetAll(int userId);
        //Task<bool> SendNotification(PushNotificationsResponseDto model);
        //Task<bool> SendListDeleteNotifications(List<PushNotificationsResponseDto> model);
    }
}
