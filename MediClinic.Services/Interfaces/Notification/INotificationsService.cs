using MediClinic.Models.DTOs.NotificationDto;
using MediClinic.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.Notification
{
    public interface INotificationsService
    {
        public List<Notifications> GetAllNotifications(long Id);
        public Notifications SaveUserNotification(Notifications modal);
        public bool UpdateNotificationIsRead(long Id);
        public Task<List<NotificationDto>> GetNotification(long Id);
    }
}
