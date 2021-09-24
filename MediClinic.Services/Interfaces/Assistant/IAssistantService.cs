using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.CommonDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.Assistant
{
    public interface IAssistantService
    {
        public Task<ResponseDto<AssistantInfoDto>> assistantInfoGetId(int Id);
        public Task<ResponseDto<AssistantSettingDto>> SettingAssistantInfoGetId(int Id);
        public Task<ResponseDto<AssistantInfoDto>> assistantInfoAdd(AssistantInfoDto assistantInfoDto);
        public Task<ResponseDto<AssistantSettingDto>> SettingassistantInfoAdd(AssistantSettingDto settingassistantInfoDto);
        public Task<ResponseDto<AssistantWorkingScheduleDto>> workingScheduleAdd(List<AssistantWorkingScheduleDto> WorkingSchedule);
        public Task<List<AssistantWorkingScheduleDto>> getworkschedule(int id);
        public Task<List<AssistantInfoDto>> AssistantInfoList(int? userid);
        public Task<ResponseDto<bool>> assistantInfoDeleteById(int Id);
        public Task<ResponseDto<bool>> CheckEmailExistOrNot(string email, long? userId);
        public Task<ResponseDto<bool>> assistantInfoUpdate(AssistantInfoDto assistantInfoDto);
        public Task<List<DepartmentDto>> GetDepartmentList();
        public Task<List<DoctorsInfoDto>> GetDoctorList();
        public Task<ResponseDto<AssistantWorkingScheduleDto>> removeSchedule(int id);
    }
}
