using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.InsuranceGroupNumberBasicDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.InsuranceGroupNumberInterface
{
    public interface IInsuranceGroupNumberService
    {
        public Task<ResponseDto<int>> InsuranceGroupNumber(InsuranceGroupNumberBasicDto insuranceGroupNumberBasicDto);

        public Task<ResponseDto<List<InsuranceGroupNumberBasicDto>>> InsuranceGroupNumberList();

        public Task<ResponseDto<InsuranceGroupNumberBasicDto>> InsuranceGroupNumberById(int Id);

        public Task<ResponseDto<bool>> isExistorNot(string Name);
    }
}
