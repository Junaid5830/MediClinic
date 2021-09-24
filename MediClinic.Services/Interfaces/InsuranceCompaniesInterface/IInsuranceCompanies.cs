using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.CommonDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.InsuranceCompaniesInterface
{
    public interface IInsuranceCompanies
    {
        public Task<ResponseDto<List<InsuranceCompaniesDto>>> GetListOfCompanies();
        public Task<ResponseDto<InsuranceCompaniesDto>> GetCompanyById(int Id);
        public Task<ResponseDto<InsuranceCompaniesDto>> AddUpdateCompany(InsuranceCompaniesDto insuranceCompaniesDto);
        public Task<ResponseDto<bool>> DeleteCompany(int Id);
    }
}
