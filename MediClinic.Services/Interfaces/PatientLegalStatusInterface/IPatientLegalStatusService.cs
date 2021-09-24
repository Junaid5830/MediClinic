using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.PatientLegalStatusDto;
using MediClinic.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.PatientLegalStatusInterface
{
    public interface IPatientLegalStatusService
    {
        public Task<ResponseDto<List<PatientLegalStatusBasicDto>>> patientlegalStatus();
        public List<PatientLegalStatus> patientLegalStatusList(string legalName);
        public Task<ResponseDto<int>> patientLegalStatusCreate(PatientLegalStatusBasicDto patientLegalStatusBasicDto);
        public Task<ResponseDto<bool>> patientLegalStatusDeleteById(int Id);
        public Task<ResponseDto<PatientLegalStatusBasicDto>> patientLegalStatusGetId(int Id);
        public Task<ResponseDto<bool>> patientLegalStatusUpdate(PatientLegalStatusBasicDto patientLegalStatusBasicDto);

        public Task<ResponseDto<bool>> IsExitorNot(string Name);
    }
}
