using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.PatientArbitrationAttorneyDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.PatientArbitrationAttorneyInterface
{
    public interface IPatientArbitrationAttorneyService
    {
        public Task<ResponseDto<bool>> patientArbitrationAttorney(PatientArbitrationAttorneyBasicDto patientArbitrationAttorneyBasicDto);
        public Task<ResponseDto<bool>> patientArbitrationAttorneyUpdate(PatientArbitrationAttorneyBasicDto patientArbitrationAttorneyBasicDto);

        public Task<ResponseDto<PatientArbitrationAttorneyBasicDto>> patientArbitrationAttorneyId(int Id);

    }
}
