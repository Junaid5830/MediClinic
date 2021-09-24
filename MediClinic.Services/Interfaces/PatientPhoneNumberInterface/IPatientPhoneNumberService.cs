using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.PatientPhoneNumberDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.PatientPhoneNumberInterface
{
    public interface IPatientPhoneNumberService
    {
        public Task<ResponseDto<bool>> CreatePatientPhoneNumber(PatientPhoneNumberBasicDto patientPhoneNumberBasicDto);

        public Task<ResponseDto<bool>> CreatePatientPhoneUpdate(PatientPhoneNumberBasicDto patientPhoneNumberBasicDto);

    }
}
