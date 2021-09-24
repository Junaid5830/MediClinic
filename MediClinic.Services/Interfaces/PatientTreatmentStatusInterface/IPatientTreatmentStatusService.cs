using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.PatientTreatmentStatusDto;
using MediClinic.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.PatientTreatmentStatusInterface
{
    public interface IPatientTreatmentStatusService
    {
        public List<PatientTreatmentStatus> patientTreatmentlist(dynamic name);
        public Task<ResponseDto<List<PatientTreatmentStatusBasicDto>>> patientTreatmentStatus();
        public Task<ResponseDto<int>> patientTreatmentStatusCreate(PatientTreatmentStatusBasicDto patientTreatmentStatusBasicDto);
        public Task<ResponseDto<bool>> patientTreatmentStatusDeleteById(int Id);
        public Task<ResponseDto<PatientTreatmentStatusBasicDto>> patientTreatmentStatusGetId(int Id);
        public Task<ResponseDto<bool>> patientTreatmentStatusUpdate(PatientTreatmentStatusBasicDto patientTreatmentStatusBasicDto);

        public Task<ResponseDto<bool>> IsExistOrNot(string Name);
    }
}
