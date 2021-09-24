using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.PatientLanguageDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.PatientLanguageInterface
{
    public interface IPatientLanguageService
    {
        public Task<ResponseDto<int>> patientLanguage(PatientLanguageBasicDto patientLanguageBasicDto);

        public Task<ResponseDto<List<PatientLanguageBasicDto>>> patientLanguageList();

        public Task<ResponseDto<PatientLanguageBasicDto>> patientLanguageById(int Id);

        public Task<ResponseDto<bool>> isExistorNot(string Name);
    }
}
