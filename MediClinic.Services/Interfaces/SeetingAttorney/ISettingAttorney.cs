using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.CommonDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.SeetingAttorney
{
    public interface ISettingAttorney
    {
        public Task<ResponseDto<SettingAttorneyDto>> GetById(int Id);
        public Task<ResponseDto<SettingAttorneyDto>> AddSettingAttorney(SettingAttorneyDto settingAttorney); 
        public Task<ResponseDto<SettingAttorneyDto>> UpdateSettingAttorney(SettingAttorneyDto settingAttorney);
        public Task<List<SettingAttorneyDto>> GetList();
        public Task<bool> Delete(int Id);
       
    }
}
