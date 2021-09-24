using MediClinic.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.CompanyBillsInterface
{
    public interface ICompanyBillsServices
    {
        public Task<bool> Add(CompanyBillsDto companyBillsDto);
        public List<CompanyBillsDto> GetBillsList();
        public bool Delete(int billId);
        public CompanyBillsDto GetBillById(int BillId);
        
    }
}
