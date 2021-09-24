using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.MedicalDiseaseTypeDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.MedicalDiseaseTypeInterface
{
    public interface IMedicalDiseaseTypeService
    {
        public Task<ResponseDto<int>> MedicalDiseaseType(MedicalDiseaseTypeBasicDto medicalDiseaseTypeBasicDto);

        public Task<ResponseDto<List<MedicalDiseaseTypeBasicDto>>> MedicalDiseaseList();

        public Task<ResponseDto<bool>> isExistorNot(string Name);
    }
}
