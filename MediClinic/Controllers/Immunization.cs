using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using MediClinic.Models;
using MediClinic.Models.DTOs;
using MediClinic.Services.Interfaces.ImmunizationInterface;
using MediClinic.Services.Interfaces.PatientInfoInterface;
using MediClinic.Services.Interfaces.ProviderInfoInterface;
using MediClinic.Services.Interfaces.SessionManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MediClinic.Controllers
{
    public class Immunization : Controller
    {
        private readonly ILogger<Immunization> _logger;
        private ISessionManager _sessionManager;
        private IimmunizationService _immunizationService;
        private readonly IPatientInfoService _patientInfoService;
        private IProviderInfoService _providerInfoService;


        public Immunization(ILogger<Immunization> logger, ISessionManager sessionManager,
            IimmunizationService immunizationService, IPatientInfoService patientInfoService, IProviderInfoService providerInfoService)
        {
            _logger = logger;
            _sessionManager = sessionManager;
            _immunizationService = immunizationService;
            _patientInfoService = patientInfoService;
            _providerInfoService = providerInfoService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> ImmunizationList(long? Id)
        {
            var RoleId = _sessionManager.GetRoleId();
            var PatientId = _sessionManager.GetPatientInfoId();
            ImmunizationViewModel immunization = new ImmunizationViewModel();

            //if (Id == null)
            //{
            //    immunization.Listimmunization = await _immunizationService.ImmunizationListByVisits(PatientId);
            //}
            //else
            //{
            //    immunization.Listimmunization = await _immunizationService.ImmunizationListByVisits(Id);
            //}

            if (RoleId == 1)
            {
                immunization.Listimmunization = await _immunizationService.ImmunizationList(PatientId);
            }
            else
            {
                if (PatientId == 0)
                {
                    immunization.Listimmunization = await _immunizationService.AllImmunizationList();

                }
                else
                {
                    immunization.Listimmunization = await _immunizationService.ImmunizationList(PatientId);

                }
            }

            return View(immunization);
        }
        public async Task<IActionResult> AssignImmunization(int? Id)
        {
            ImmunizationViewModel immunization = new ImmunizationViewModel();
            //if (!(Id is null))
            //{
            //    immunization.immunization = await _immunizationService.ImmunizationGetById(Id.Value);
                
            //}
            immunization.patientListWithUsers = await _patientInfoService.GetPatientListWithDetails();
            immunization.ProviderList = await _providerInfoService.GetProviderList();

            immunization.ICDList = await _immunizationService.GetAllICDCodes(true);
            return View(immunization);
        }
        [HttpPost]
        public async Task<IActionResult> GetAssignPatientDetail(long Id)
        {
            ImmunizationViewModel immunization = new ImmunizationViewModel();
           
            immunization.patientListWithUsers = await _patientInfoService.GetPatientListWithDetails();
            immunization.ProviderList = await _providerInfoService.GetProviderList();
            if (Id > 0)
            {
                var rec = await _patientInfoService.GetPatientDetailInfo(Id);
                var result = DateTime.Parse(rec.DateOfBirth.ToString(), new CultureInfo("en-US")).Year;
                var resultM = DateTime.Parse(rec.DateOfBirth.ToString(), new CultureInfo("en-US")).Month;
                var Currentage = DateTime.Today.Year - result;
                var CurrentMonth = DateTime.Today.Month - resultM;
                ViewBag.CurrentAgeMonth = Currentage + "y," + CurrentMonth + "m";
            }
           
            immunization.ICDList = await _immunizationService.GetAllICDCodes(true);
            return PartialView("~/Views/Immunization/PartialView/_Immunization.cshtml", immunization);
        }
        [HttpPost]
        public async Task<IActionResult> AssignImmunization(ImmunizationViewModel ImmunizationViewModel)
        {
            var age = _sessionManager.GetPatientDOB();
            var VisiId = _sessionManager.GetVisitId();

            var rec = await _patientInfoService.GetPatientDetailInfo((long)ImmunizationViewModel.immunization.PatientInfoId);
            if (ImmunizationViewModel.immunization.ImmunizationId > 0)
            {
                ImmunizationViewModel.immunization.PatientCurrentAge =rec.DateOfBirth;
                ImmunizationViewModel.immunization.IsActive = true;

                await _immunizationService.ImmunizationUpdate(ImmunizationViewModel.immunization);
            }
            else
            {
                ImmunizationViewModel.immunization.PatientCurrentAge = rec.DateOfBirth;
                ImmunizationViewModel.immunization.IsActive = true;
                ImmunizationViewModel.immunization.VisitId = VisiId;
                await _immunizationService.ImmunizationCreate(ImmunizationViewModel.immunization);
            }
            ImmunizationViewModel.ICDList = await _immunizationService.GetAllICDCodes(true);
            var data = new { Success = "Data saved successfully" };

            return Json(data);
        }
        public IActionResult ImmunizationDelete(int Id)
        {
            var PatById = _immunizationService.ImmunizationDeleteById(Id);
            //return RedirectToAction("PatientList", "PatientSide");
            return Json(PatById);
        }
    }
}
