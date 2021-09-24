using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.PatientCaseTypeDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.PatientCaseTypeInterface
{
    public interface IPatientCaseTypeService
    {
        public Task<ResponseDto<bool>> PatientCaseTypeCreate(PatientCaseTypeBasicDto patientCaseTypeBasicDto);

        public Task<ResponseDto<bool>> PatientCaseTypeUpdate(PatientCaseTypeBasicDto patientCaseTypeBasicDto);

    }
}
