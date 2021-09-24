using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.PatientMedicalProblemDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.PatientMedicalProblemInterface
{
    public interface IPatientMedicalProblemService
    {
        public Task<ResponseDto<List<PatientMedicalProblemBasicDto>>> MedicalProblemList(long Id);
        public Task<ResponseDto<List<PatientMedicalProblemBasicDto>>> MedicalProblemListProblemId(int Id);

        public Task<ResponseDto<PatientMedicalProblemBasicDto>> MedicalProblemCreate(PatientMedicalProblemBasicDto patientMedicalProblemBasicDto);

        public Task<ResponseDto<bool>> MedicalProblemUpdate(PatientMedicalProblemBasicDto patientMedicalProblemBasicDto);

        public Task<ResponseDto<PatientMedicalProblemBasicDto>> GetMedicalProblemById(int Id);

        public bool MedicalProblemDeleteById(int Id);
        public Task<ResponseDto<PatientMedicalProblemBasicDto>> GetMedicalProblemByMedicalHistoryId(int medicalProblemId);

        public Task<ResponseDto<PatientMedicalProblemBasicDto>> medicalProblemHistoryGetId(int Id);

    }
}
