using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class Notifications
    {
        public long Id { get; set; }
        public long? UserId { get; set; }
        public string NotificationType { get; set; }
        public string NotificationText { get; set; }
        public string NotificationInfo { get; set; }
        public bool? IsRead { get; set; }
        public int? UserRoleId { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? AppointmentId { get; set; }

        public virtual PatientAppointments Appointment { get; set; }
        public virtual Users User { get; set; }
        public virtual UserInRoles UserRole { get; set; }
    }
}
