using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.PatientTertiaryInsuranceDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.PatientTertiaryInsuranceInterface
{
    public interface IPatientTertiaryInsuranceService
    {
        public Task<ResponseDto<bool>> patientTertiaryInsurance(PatientTertiaryInsuranceBasicDto patientTertiaryInsuranceBasicDto);

        public Task<ResponseDto<bool>> patientTertiaryInsuranceUpdate(PatientTertiaryInsuranceBasicDto patientTertiaryInsuranceBasicDto);

    }
}
