using MediClinic.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.LegalInfoInterface
{
    public interface ILegalInfoService
    {
        public  Task<bool> Add(LegalInfoDto legalInfoDto);
        public List<LegalInfoDto> GetLegalInfoList();
        public bool Delete(int legalid);
        public LegalInfoDto GetLegalInfoById(int legalid);
    }
}
