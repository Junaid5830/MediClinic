using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.PatientMedicalHistoryDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.PatientMedicalHistoryInterface
{
    public interface IPatientMedicalHistoryService
    {
        public Task<ResponseDto<List<PatientMedicalHistoryBasicDto>>> PatientMedicalHistoryList(long Id);


        public Task<ResponseDto<List<PatientMedicalHistoryBasicDto>>> PatientMedicalHistoryListbyHistoryId(int Id);

        public Task<ResponseDto<PatientMedicalHistoryBasicDto>> PatientMedicalHistoryCreate(PatientMedicalHistoryBasicDto patientMedicalHistoryBasicDto);

        public Task<ResponseDto<bool>> PatientMedicalHistoryUpdate(PatientMedicalHistoryBasicDto patientMedicalHistoryBasicDto);

        public Task<ResponseDto<PatientMedicalHistoryBasicDto>> GetPatientMedicalHistoryById(int Id);

        public bool PatientMedicalHistoryDeleteById(int Id);

    }
}
