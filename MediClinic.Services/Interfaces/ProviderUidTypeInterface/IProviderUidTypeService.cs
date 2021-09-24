using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.ProviderUidTypeDto;
using MediClinic.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.ProviderUidTypeInterface
{
    public interface IProviderUidTypeService
    {
        public Task<ResponseDto<List<ProviderUidTypeBasicDto>>> providerUidType();
        public List<ProviderUIDTypes> providerUidTypeBasicDto();
        public List<ProviderUIDTypes> providerUidTypeByName(string name);
        public Task<ResponseDto<bool>> providerUidTypeCreate(ProviderUidTypeBasicDto providerUidTypeBasicDto);

        public Task<ResponseDto<bool>> providerUidTypeUpdate(ProviderUidTypeBasicDto providerUidTypeBasicDto);

        public Task<ResponseDto<ProviderUidTypeBasicDto>> providerUidTypeGetId(int Id);

        public Task<ResponseDto<bool>> providerUidTypeDeleteById(int Id);
    }
}
