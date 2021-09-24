using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediClinic.Models;
using MediClinic.Models.DTOs.NotificationDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.Notification;
using MediClinic.Services.Interfaces.PatientAppointmentInterface;
using MediClinic.Services.Interfaces.SessionManager;
using MedliClinic.Utilities.Utility;
using Microsoft.AspNetCore.Mvc;

namespace MediClinic.Controllers
{
    public class NotificationController : Controller
    {
        private readonly INotificationsService _service;
        private readonly ISessionManager _session;
        private IPatientAppointmentService _appointmentService;
        public NotificationController(INotificationsService service, ISessionManager session, IPatientAppointmentService appointmentService)
        {
            _service = service;
            _session = session;
            _appointmentService = appointmentService;
        }

        public IActionResult Notifications()
        {
            var userId = _session.GetUserId();
            var roleId = _session.GetRoleId();
            NotificationViewModel model = new NotificationViewModel();
            model.GetNotifications = _service.GetAllNotifications(userId).ToList();
            if (roleId == 1)
            {
                ViewBag.Layout = "~/Views/Shared/_PatientLayout/_LayoutPatientElite.cshtml";
            }
            else
            {
                ViewBag.Layout = "~/Views/Shared/_LayoutElite.cshtml";
            }

            return View(model);
        }

        public async Task<IActionResult> GetNotifications(long userId)
        {
            var data = await _service.GetNotification(userId);
            List<NotificationDto> data2 = new List<NotificationDto>();
            foreach (var item in data)
            {
                item.NotificationTime = DateTimeExtensions.GetConvertedDateToAgo(Convert.ToDateTime(item.NotificationDateTime));
                data2.Add(item);
            }
            data = data2;
            return Json(data);
        }
        public IActionResult UpdateNotifications(long Id)
        {
            var result = _service.GetAllNotifications(Id).ToList();
            foreach (var item in result)
            {
                if (item.IsRead == false)
                {
                    _service.UpdateNotificationIsRead(item.Id);
                }
            }
            return RedirectToAction("Notifications");
        }

        public IActionResult SaveNotification(int UserId, string NotificationType, string NotificationText, string NotificationInfo, int UserRoleId, long? CreatedBy)
        {
            long patientId = _session.GetPatientInfoId();
            var appointment = _appointmentService.GetAppointmentDetailByPatientId(patientId).Max(x => x.AppointmentId);

            Notifications notifications = new Notifications();
            notifications.UserId = UserId;
            notifications.NotificationType = NotificationType;
            notifications.NotificationText = NotificationText;
            notifications.NotificationInfo = NotificationInfo;
            notifications.IsRead = false;
            notifications.CreatedBy = CreatedBy;
            notifications.UserRoleId = UserRoleId;
            notifications.CreatedDate = DateTime.UtcNow;
            notifications.AppointmentId = appointment;
            var data = _service.SaveUserNotification(notifications);
            return Json("success");
        }
    }
}
