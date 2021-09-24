using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.ProviderSpecialityDto;
using MediClinic.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.ProviderSpecialityInterface
{
    public interface IProviderSpecialityService
    {
        public Task<ResponseDto<bool>> IsSpecialityExistOrNot(string Name);
        public Task<ResponseDto<List<ProviderSpecialityBasicDto>>> providerSpeciality();
        public List<ProviderSpecialities> providerSpecialityByName(string name);
        public Task<ResponseDto<int>> providerSpecialityCreate(ProviderSpecialityBasicDto providerSpecialityBasicDto);

        public Task<ResponseDto<bool>> providerSpecialityUpdate(ProviderSpecialityBasicDto providerSpecialityBasicDto);

        public Task<ResponseDto<ProviderSpecialityBasicDto>> providerSpecialityGetId(int Id);

        public Task<ResponseDto<bool>> providerSpecialityDeleteById(int Id);
    }
}
