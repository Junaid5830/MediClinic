using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.ProviderTermDto;
using MediClinic.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.ProviderTermInterface
{
    public interface IProviderTermService
    {
        public Task<ResponseDto<List<ProviderTermBasicDto>>> providerTerm();
        public List<ProviderTerms> providerTermByName(string name);
        public Task<ResponseDto<bool>> providerTermCreate(ProviderTermBasicDto providerTermBasicDto);

        public Task<ResponseDto<bool>> providerTermUpdate(ProviderTermBasicDto providerTermBasicDto);

        public Task<ResponseDto<ProviderTermBasicDto>> providerTermGetId(int Id);

        public Task<ResponseDto<bool>> providerTermDeleteById(int Id);
    }
}
