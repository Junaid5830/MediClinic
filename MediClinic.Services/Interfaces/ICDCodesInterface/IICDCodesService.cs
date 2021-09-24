using MediClinic.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.ICDCodesInterface
{
    public interface IICDCodesService
    {
        Task<List<ICDCodesDto>> GetAllICDCodes(bool withDetail);
    }
}
