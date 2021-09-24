using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediClinic.Models;
using MediClinic.Services.Interfaces;
using MediClinic.Services.Services.ProviderInfoService;
using MediClinic.Services.Services.SessionManager;
using MediClinic.Services.Interfaces.SessionManager;
using Microsoft.AspNetCore.Mvc;
using MediClinic.Services.Interfaces.ProviderInfoInterface;
using MediClinic.Models.DTOs.ProviderInfoDto;

namespace MediClinic.Controllers
{
    public class CareGiverController : Controller
    {
        private IProviderSettingsService _providerSettingsService;
        private ISessionManager _sessionManager;
        private IProviderInfoService _providerInfoService;
        private object providerId;

        public CareGiverController(IProviderSettingsService providerSettingsService, ISessionManager sessionManager, IProviderInfoService providerInfoService)
        {
            _providerSettingsService = providerSettingsService;
            _sessionManager = sessionManager;
            _providerInfoService = providerInfoService;
        }
            

        public async Task<IActionResult> CareGiver()
        {
            ProviderViewModel providerViewModel = new ProviderViewModel();
            long? userId = (long?)_sessionManager.GetUserId();
            if (!(userId is null))
            {
                providerViewModel.ProviderListSettingDto = _providerSettingsService.getProviderListSettingsById((int)userId);
            }
            else
            {
                providerViewModel.ProviderListSettingDto = new Models.DTOs.ProviderListSettingDto();
            }

            var infoList = await _providerInfoService.providerInfo();
            providerViewModel.ProviderList = infoList.Data;
            return View(providerViewModel);
        }
       
        public async Task<IActionResult> FullView(long id)
        
        {
            ProviderViewModel providerViewModel = new ProviderViewModel();
            var providerData = await _providerInfoService.GetProviderSummaryDetails(id);
            providerViewModel.ProviderSummary = providerData;
            providerViewModel.ScheduleList = await _providerInfoService.ProviderScheduleList(id);

            return View(providerViewModel);
        }
    }
}
