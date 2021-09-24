using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.PatientAppointmentsDto;
using MediClinic.Models.DTOs.PatientInfoDto;
using MediClinic.Models.DTOs.ProviderBasicSummaryDto;
using MediClinic.Models.DTOs.ProviderInfoDto;
using MediClinic.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.ProviderInfoInterface
{
    public interface IProviderInfoService
    {
        public Task<ResponseDto<List<ProviderInfoBasicDto>>> providerInfo();
        public Task<ResponseDto<ProviderInfoBasicDto>> providerInfoCreate(ProviderInfoBasicDto providerInfoBasicDto);

        public Task<ResponseDto<ProviderInfoBasicDto>> providerInfoUpdate(ProviderInfoBasicDto providerInfoBasicDto);

        public Task<ResponseDto<ProviderInfoBasicDto>> providerInfoGetId(int Id);
        public Task<ResponseDto<ProviderInfoBasicDto>> providerInfoGetByUserId(int Id);

        public Task<ResponseDto<ProviderInfoBasicDto>> providerInfoGetLastAdded();

        public Task<ResponseDto<bool>> providerInfoDeleteById(int Id);

        public Task<ResponseDto<bool>> CheckEmailExistOrNot(string email, long? userId, string UserName);
        public Task<ProviderSummaryDto> GetProviderSummaryDetails(long providerInfoId);
        public Task<ProviderSummarySettingsDto> GetProviderSummarySetting();
        public Task<ProviderDetails> GetProviderDetails(long providerInfoId);
        public Task<List<ProviderInfoBasicDto>> GetProviderList();
        public ProviderInfo GetProviderUserId(long Id);

        public Task<bool> SaveWorkingHours(List<WeekDayWithSessionTypeDto> dayWithSessionTypeList, long providerId, long userId);

        public Task<bool> ProviderScheduling(List<ProviderWorkHrsDto> Schedule, long providerId);

        public Task<List<ProviderWorkHrsDto>> GetAllProviderSessions(long providerId);

        public Task<List<ProviderWorkHrsDto>> ProviderScheduleList(long ProviderId);
        public Task<List<PatientAppointmentBasicDto>> ProviderPatientBookSlotsList(long ProviderId);
        public Task<List<PatientAppointmentBasicDto>> ProviderBookedAppointment(long ProviderId);
        public Task<List<ProviderWorkHrsDto>> AllScheduleList();

        public Task<bool> DeleteScheduleByProviderId(int Id);

        Task<List<ProviderWorkHrsDto>> GetAllScheduleListById(long providerId);

        public Task<List<PatientInfoBasicDto>> ProviderPatientsList(long ProviderId);

        public Task<List<PatientAppointmentBasicDto>> ProviderPatientsbookedSlots(long ProviderId);
    }
}
