using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.InsuranceProviderNameBasicDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.InsuranceProviderNameInterface
{
    public interface IInsuranceProviderNameService
    {
        public Task<ResponseDto<int>> InsuranceProviderName(InsuranceProviderNameBasicDto insuranceProviderNameBasicDto);

        public Task<ResponseDto<List<InsuranceProviderNameBasicDto>>> InsuranceProviderNameList();

        public Task<ResponseDto<InsuranceProviderNameBasicDto>> InsuranceProviderNameById(int Id);

        public Task<ResponseDto<bool>> isExistorNot(string Name);
    }
}
