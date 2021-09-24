using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediClinic.Models;
using MediClinic.Models.DTOs;
using MediClinic.Services.Interfaces.SessionManager;
using MediClinic.Services.Interfaces.TestsInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MediClinic.Services.Interfaces.LookupInteface;
using MediClinic.Services.Interfaces.DoctorsInfoInterface;
using MediClinic.Models.DTOs.DMESuppliesDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.CPTCodesInterface;
using MediClinic.Services.Interfaces.ICDCodesInterface;
using MediClinic.Services.Interfaces.ProviderInfoInterface;

namespace MediClinic.Controllers
{
    public class TestsController : Controller
    {
        private readonly ILogger<TestsController> _logger;
        private ISessionManager _sessionManager;
        private ITestsService _testsService;
        private TestsViewModel viewModel;
        private ILookupService _lookupService;
        private IDoctorsInfoService _doctorsInfoService;
        private ICPTCodesService _cptCodesService;
        private IICDCodesService _icdCodesService;
        private IProviderInfoService _providerInfoService;

        public TestsController(
            ILogger<TestsController> logger,
            ISessionManager sessionManager,
            ITestsService testsService,
            ILookupService lookupService,
            IDoctorsInfoService doctorsInfoService,
            ICPTCodesService cptCodesService,
            IICDCodesService icdCodesService,
            IProviderInfoService providerInfoService

            )
        {
            _logger = logger;
            _sessionManager = sessionManager;
            _testsService = testsService;
            _lookupService = lookupService;
            _doctorsInfoService = doctorsInfoService;
            _cptCodesService = cptCodesService;
            _icdCodesService = icdCodesService;
            _providerInfoService = providerInfoService;
            viewModel = new TestsViewModel();
        }
        [HttpGet]
        public async Task<IActionResult> Index(long? Id)
        {
            var roleId = _sessionManager.GetRoleId();
            var PatientId = _sessionManager.GetPatientInfoId();
            if (roleId == 1)
            {
                viewModel.TestsDtoList =await _testsService.TestListByVisit((long)Id);
            }
            else
            {
                if (PatientId == 0)
                {
                    viewModel.TestsDtoList = _testsService.GetAllTests();
                }
                else
                {
                    viewModel.TestsDtoList = await _testsService.TestListByVisit((long)Id);
                }

            }
            return View(viewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Add(int? TestId)
        {
            if (TestId != 0)
            {
                viewModel.TestsDto = _testsService.GetTestById(Convert.ToInt32(TestId));
            }

            var visitProcedureCatList = _lookupService.lookupByTypeBasicDto("VisitProcedureCategory");
            viewModel.VisitProcedureCategoryDtoList = visitProcedureCatList.Data;
            //viewModel.DoctorsNamesDtoList = await _doctorsInfoService.GetAllDoctorsInfoNames();
            viewModel.CPTCodesDtoList = await _cptCodesService.GetAllCPTCodes();
            viewModel.ICDCodesDtoList = await _icdCodesService.GetAllICDCodes(true);
            viewModel.ProviderList = await _providerInfoService.GetProviderList();

            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Delete(int TestId)
        {
            var DeleteID = _testsService.Delete(TestId);
            return Json(DeleteID); 
        }
        [HttpPost]
        public async Task<IActionResult> Add(TestsDto testsDto)
        {
            var VisitId = _sessionManager.GetVisitId();
            testsDto.VisitId = VisitId;
            await _testsService.Add(testsDto);
            viewModel.TestsDtoList = _testsService.GetAllTests();
            var PatientId = _sessionManager.GetPatientInfoId();
            return RedirectToAction("Index", "Tests", new { Id = PatientId });
  
        }
    }
}