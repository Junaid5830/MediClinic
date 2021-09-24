using MediClinic.Models.DTOs.PatientMissingDto;
using MediClinic.Models.DTOs.PatientSettingsDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Models.DTOs.NotificationDto
{
    public class NotificationDto
    {
        public PatientSettingDto PatientSettingsDto { get; set; }

        public List<PatientMissingsDto> PatientMissingsListDtos { get; set; }


        public string NotificationInfo { get; set; }
        public string NotificationTime { get; set; }

        public int? AppointmentId { get; set; }
        public string NotificationType { get; set; }
        public bool? IsRead { get; set; }

        public DateTime? NotificationDateTime { get; set; }
    }
}
