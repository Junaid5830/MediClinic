using MediClinic.Models.DTOs.NotificationDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.Notification;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.Notification
{
    public class NotificationsService : INotificationsService
    {
        private MediClinicContext _context;

        public NotificationsService(MediClinicContext context)
        {
            _context = context;
        }

        public async Task<List<NotificationDto>> GetNotification(long Id)
        {
            var joinData = await(from N in _context.Notifications.Where(x => x.UserId == Id).Take(3).OrderByDescending(x => x.Id)


                                 select new NotificationDto
                                 {
                                     NotificationInfo = N.NotificationInfo,
                                     NotificationDateTime = N.CreatedDate,
                                     AppointmentId = N.AppointmentId,
                                     NotificationType = N.NotificationType,
                                     IsRead = N.IsRead
                                 }).ToListAsync();
            return joinData;
        }
        public List<Notifications> GetAllNotifications(long Id)
        {
            return _context.Notifications.Where(x => x.UserId == Id).ToList();
        }
        public Notifications SaveUserNotification(Notifications modal)
        {
            _context.Notifications.Add(modal);
            _context.SaveChanges();
            return modal;
        }
        public bool UpdateNotificationIsRead(long Id)
        {
            var oldEntity = _context.Notifications.Where(x => x.Id == Id).FirstOrDefault();
            oldEntity.IsRead = true;
            _context.Entry(oldEntity).CurrentValues.SetValues(oldEntity);
            _context.SaveChanges();
            return true;
        }
    }
}
