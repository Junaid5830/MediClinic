using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediClinic.Models;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.GrowthChartInterface;
using MediClinic.Services.Interfaces.SessionManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MediClinic.Controllers
{
    public class GrowthChartController : Controller
    {
        private readonly ILogger<InvoicesController> _logger;
        private ISessionManager _sessionManager;
        private IGrowthChartService _growthChartService;
        private GrowthChartViewModel growthChartViewModel;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly MediClinicContext _context;

        public ILogger<GrowthChartController> Logger { get; }

        public GrowthChartController(
            ILogger<GrowthChartController> logger,
            ISessionManager sessionManager, IGrowthChartService growthChartService, MediClinicContext context,
            IHttpContextAccessor contextAccessor
            )
        {
            Logger = logger;
            _sessionManager = sessionManager;
            _growthChartService = growthChartService;
            growthChartViewModel = new GrowthChartViewModel();
            _context = context;
            _contextAccessor = contextAccessor;
        }
        public async Task<IActionResult> GrowthChartList(long? Id)
        {
            var RoleId = _sessionManager.GetRoleId();
            var PatientId = _sessionManager.GetPatientInfoId();
            if (RoleId == 1)
            {
                growthChartViewModel.growthChartList = await _growthChartService.GetGrowthChartListByVisits((long)Id);
            }
            else
            {
                if (PatientId == 0)
                {
                    growthChartViewModel.growthChartList = await _growthChartService.GetGrowthChartList();

                }
                else
                {
                    growthChartViewModel.growthChartList = await _growthChartService.GetGrowthChartListByVisits((long)Id);
                }
            }
            return View(growthChartViewModel);;
        }
        [HttpPost]
        public  IActionResult Add(GrowthChartViewModel growthChartViewModel)
        {
            var VisitId = _sessionManager.GetVisitId();
            growthChartViewModel.growthChardto.VisitId = VisitId;
            _growthChartService.Add(growthChartViewModel.growthChardto);
            var PatientId = _sessionManager.GetPatientInfoId();
            return RedirectToAction("GrowthChartList","GrowthChart", new { Id = PatientId });
        }
        public IActionResult Add(int id)
        {
            growthChartViewModel.growthChardto = _growthChartService.GetImagingById(id);
            return View(growthChartViewModel);
        }

        public IActionResult Delete(int growthChartId)
        {
            var Id = _growthChartService.Delete(growthChartId);
            var PatientId = _sessionManager.GetPatientInfoId();
            return RedirectToAction("GrowthChartList", "GrowthChart", new { Id = PatientId });
        }
    }
}
