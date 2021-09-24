using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.PatientPIPersonalInjury;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.PatientPersonalInjuryInterface
{
    public interface IPatientPersonalInjuryService
    {
        public Task<ResponseDto<bool>> patientPersonalInjury(PatientPersonalInjuryBasicDto patientPersonalInjuryBasicDto);
        public Task<ResponseDto<bool>> patientPersonalInjuryUpdae(PatientPersonalInjuryBasicDto patientPersonalInjuryBasicDto);

        public Task<ResponseDto<PatientPersonalInjuryBasicDto>> patientPersonalInjuryId(int Id);
    }
}
