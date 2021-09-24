using MediClinic.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces
{
    public interface IProviderSettingsService
    {
        public bool SaveProviderListSettings(ProviderListSettingDto providerListSettingDto);
        public bool SaveProviderSummarySettings(ProviderSummarySettingsDto providerSummarySettingDto);
        public ProviderListSettingDto getProviderListSettingsById(int userId);

        public bool AddProviderSessionSettings(ProviderSessionTypeDto dto, long userId);
        public Task<List<ProviderSessionTypeDto>> GetAllSessionSettings();
        public Task<bool> DeleteSessionSettings(long providerSessionTypeId);

    }
}
