using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.LegalInfolegealStatusDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.LegalInfoLegalInterface
{
    public interface ILegalInfolegalService
    {
        public Task<ResponseDto<List<legalInfoLegalBasicDto>>> LegalInfolegalStatusList();

        public Task<ResponseDto<int>> Legalinfostatus(legalInfoLegalBasicDto legalInfoLegalBasicDto);
        public Task<ResponseDto<bool>> isExistorNot(string Name);
    }
}
