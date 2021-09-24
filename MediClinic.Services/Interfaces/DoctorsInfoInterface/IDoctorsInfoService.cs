using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.CommonDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.DoctorsInfoInterface
{
    public interface IDoctorsInfoService
    {
        public Task<List<DoctorsInfoDto>> GetAllDoctorsInfoNames();

    }
}
