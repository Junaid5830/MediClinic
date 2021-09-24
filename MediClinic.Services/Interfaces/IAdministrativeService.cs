using MediClinic.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces
{
    public interface IAdministrativeService
    {
        Task<List<AdministrativeDto>> AdministrativeList();
        Task<bool> AddAdministrative(AdministrativeDto administrativeDto);
        Task<bool> DeleteAdministrative(int administrativeId);
        Task<AdministrativeDto> GetAdministrativeById(int Id);
    }
}
