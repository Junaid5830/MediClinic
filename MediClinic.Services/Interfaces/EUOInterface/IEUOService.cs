using MediClinic.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.EUOInterface
{
    public interface IEUOService
    {
        public Task<bool> Add(EUODto euoDto);
        public bool Delete(int EUOId);
        public EUODto GetEUOById(int EUOId);
        public List<EUODto> GetEUO();
        public Task<List<EUODto>> GetEUOByPatientId(long? Id);

    }
}
