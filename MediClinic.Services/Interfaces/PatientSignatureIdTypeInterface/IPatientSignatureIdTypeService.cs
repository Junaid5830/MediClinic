using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.PatientSignatureIdTypeBasicDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.PatientSignatureIdTypeInterface
{
    public interface IPatientSignatureIdTypeService
    {
        public Task<ResponseDto<int>> PatientSignatureIdType(PatientSignatureIdTypeDto patientSignatureIdTypeBasicDto);

        public Task<ResponseDto<List<PatientSignatureIdTypeDto>>> PatientSignatureIdTypeList();

        public Task<ResponseDto<PatientSignatureIdTypeDto>> PatientSignatureIdTypeById(int Id);

        public Task<ResponseDto<bool>> isExistorNot(string name);
    }
}
