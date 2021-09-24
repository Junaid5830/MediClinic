using MediClinic.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.SurgeryCenterInterface
{
    public interface ISurgeryCenterService
    {
        public Task<bool> Add(SurgeryCenterDto surgeryCenterDto);
        public bool Delete(int SurgeryCenterId);
        public SurgeryCenterDto GetSurgeryCenterById(int SurgeryCenterId);
        public List<SurgeryCenterDto> GetSurgeryCenter();
        public List<SurgeryCenterDto> GetSurgeryCenterWithProImag();
    }
}
