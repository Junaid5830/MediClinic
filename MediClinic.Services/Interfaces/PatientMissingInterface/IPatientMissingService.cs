using MediClinic.Models.DTOs.NotificationDto;
using MediClinic.Models.DTOs.PatientMissingDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.PatientMissingInterface
{
    public interface IPatientMissingService
    {
        public Task<List<PatientMissingsDto>> GetPatientInfoMissingFieldsByPatientId(long patientId);
        public Task<NotificationDto> GetPatientInfoMissingFieldsByPatientIdForNotification(long patientId);

    }
}
