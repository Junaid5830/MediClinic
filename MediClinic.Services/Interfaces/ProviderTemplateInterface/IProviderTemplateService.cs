using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.ProviderTemplateDto;
using MediClinic.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.ProviderTemplateInterface
{
    public interface IProviderTemplateService
    {
        public Task<ResponseDto<List<ProviderTemplateBasicDto>>> providerTemplate();
        public List<ProviderTemplates> providerTemplateByname(string name);
        public Task<ResponseDto<bool>> providerTemplateCreate(ProviderTemplateBasicDto providerTemplateBasicDto);

        public Task<ResponseDto<bool>> providerTemplateUpdate(ProviderTemplateBasicDto providerTemplateBasicDto);

        public Task<ResponseDto<ProviderTemplateBasicDto>> providerTemplateGetId(int Id);

        public Task<ResponseDto<bool>> providerTemplateDeleteById(int Id);
    }
}
