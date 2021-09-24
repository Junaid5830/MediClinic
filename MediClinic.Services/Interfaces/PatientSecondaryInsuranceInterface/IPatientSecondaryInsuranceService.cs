using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.PatientSecondaryInsuranceDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.PatientSecondaryInsuranceInterface
{
    public interface IPatientSecondaryInsuranceService
    {
        public Task<ResponseDto<bool>> patientSecondaryInsurance(PatientSecondaryInsuranceBasicDto patientSecondaryInsuranceBasicDto);
        public Task<ResponseDto<bool>> patientSecondaryInsuranceUpdate(PatientSecondaryInsuranceBasicDto patientSecondaryInsuranceBasicDto);
    }
}
