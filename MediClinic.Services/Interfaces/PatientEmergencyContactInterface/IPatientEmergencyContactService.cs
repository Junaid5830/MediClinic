using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.PatientEmergencyContactDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.PatientEmergencyContactInterface
{
    public interface IPatientEmergencyContactService
    {
        public Task<ResponseDto<PatientEmergencyContactBasicDto>> PatientEmergencyContact(PatientEmergencyContactBasicDto patientEmergencyContactBasicDto);
        public Task<ResponseDto<bool>> PatientEmergencyContactUpdate(PatientEmergencyContactBasicDto patientEmergencyContactBasicDto);
    }
}
