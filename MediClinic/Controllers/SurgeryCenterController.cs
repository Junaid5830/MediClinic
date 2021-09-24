using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediClinic.Models.DTOs;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.SessionManager;
using MediClinic.Services.Interfaces.SurgeryCenterInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MediClinic.Models;
using MediClinic.Services.Interfaces.LookupInteface;
using MediClinic.Services.Interfaces.PatientInfoInterface;
using MediClinic.Services.Interfaces.ProviderInfoInterface;
using System.Globalization;
using MediClinic.Services.Interfaces.TestsInterface;
using MediClinic.Services.Interfaces.ImagingInterface;

namespace MediClinic.Controllers
{
    public class SurgeryCenterController : Controller
    {
        private readonly ILogger<SurgeryCenterController> _logger;
        private ISessionManager _sessionManager;
        private ISurgeryCenterService _surgeryCenterService;
        private ILookupService _lookupService;
        private SurgeryCenterViewModel viewModel;
        private readonly IPatientInfoService _patientInfoService;
        private IProviderInfoService _providerInfoService;
        private ITestsService _TestsService;
        private IImagingService _imagingService;

        public SurgeryCenterController(
            ILogger<SurgeryCenterController> logger,
            ISessionManager sessionManager,
            ILookupService lookupService,
            ISurgeryCenterService surgeryCenterService,
            IPatientInfoService patientInfoService,
            IProviderInfoService providerInfoService,
            ITestsService testsService,
            IImagingService imagingService
            )
        {
            _logger = logger;
            _sessionManager = sessionManager;
            _surgeryCenterService = surgeryCenterService;
            _lookupService = lookupService;
            _patientInfoService = patientInfoService;
            _providerInfoService = providerInfoService;
            _TestsService = testsService;
            viewModel = new SurgeryCenterViewModel();
        }
        [HttpGet]
        public IActionResult Index()
        {
            //viewModel.SurgeryCenterDtoList = _surgeryCenterService.GetSurgeryCenter();
            viewModel.SurgeryCenterDtoList = _surgeryCenterService.GetSurgeryCenterWithProImag();
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> SurgeryDetail(long Id)
        {
            var patientInfos = await _patientInfoService.GetPatientSummaryDetails((long)Id);
            viewModel.patientCompleteInfo = patientInfos;
            var ProcedureList = await _TestsService.ProcedureList(Id);
            viewModel.ProceduresList = ProcedureList.Data;
            var ImageList = await _imagingService.PatientGetImagingList(Id);
            viewModel.getImagingDto = ImageList.Data;
            return PartialView("~/Views/SurgeryCenter/_PatientSurgeryDetail.cshtml", viewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Add(int? Id)
        {
            viewModel.patientListWithUsers = await _patientInfoService.GetPatientListWithDetails();
            //var patientInfos = await _patientInfoService.GetPatientSummaryDetails((long)Id);
            //viewModel.patientCompleteInfo = patientInfos;
            //if (SurgeryCenterId != 0)
            //{
            //    viewModel.SurgeryCenterDto = _surgeryCenterService.GetSurgeryCenterById(Convert.ToInt32(SurgeryCenterId));
            //}
            //var genderList = _lookupService.lookupByTypeBasicDto("Gender");
            //viewModel.GenderDtoList = genderList.Data;

            return View(viewModel);
        }
        public async Task<IActionResult> SurgeryProcedureAndImage(long Id)
        {
            viewModel.patientListWithUsers = await _patientInfoService.GetPatientListWithDetails();
            
            var patientInfos = await _patientInfoService.GetPatientSummaryDetails((long)Id);
            viewModel.patientCompleteInfo = patientInfos;
            var ProcedureList = await _TestsService.ProcedureList(Id);
            viewModel.ProceduresList = ProcedureList.Data;
            var ImageList = await _imagingService.PatientGetImagingList(Id);
            viewModel.getImagingDto = ImageList.Data;
            return PartialView("~/Views/SurgeryCenter/_SurgeryCenter.cshtml", viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> SurgeryProcedure(SurgeryCenterViewModel model)
        {
            if (model.Procedures.ProcedureId> 0)
            {

            }
            else
            {
               var rec =  await _TestsService.SurgeryProcedureAdd(model.Procedures);
                SurgeryCenterDto surgeryCenterDto = new SurgeryCenterDto();
                surgeryCenterDto.PatientId = rec.Data.PatientId;
                surgeryCenterDto.ProcedureId = rec.Data.ProcedureId;
                await _surgeryCenterService.Add(surgeryCenterDto);
                var ProcedureList = await _TestsService.ProcedureList((long)model.Procedures.PatientId);
                model.ProceduresList = ProcedureList.Data;
            }
            return PartialView("~/Views/SurgeryCenter/_SurgeryProcedureList.cshtml", model);
        }
        public async Task<IActionResult> SurgeryImage(SurgeryCenterViewModel model)
        {
            if (model.imagingDto.ImagingId > 0)
            {

            }
            else
            {
                var rec =  await _imagingService.AddSurgeryImaging(model.imagingDto);
                SurgeryCenterDto surgeryCenterDto = new SurgeryCenterDto();
                surgeryCenterDto.PatientId = rec.Data.PatientId;
                surgeryCenterDto.ImagingId = rec.Data.ImagingId;
                await _surgeryCenterService.Add(surgeryCenterDto);
                var ImageList = await _imagingService.PatientGetImagingList((long)model.imagingDto.PatientId);
                model.getImagingDto = ImageList.Data;
            }
            return PartialView("~/Views/SurgeryCenter/_SurgeryImagingList.cshtml", model);
        }
        [HttpGet]
        public IActionResult Delete(int SurgeryCenterId)
        {
            var DeleteId = _surgeryCenterService.Delete(SurgeryCenterId);
            return Json(DeleteId);
        }
        [HttpPost]
        public async Task<IActionResult> Add(SurgeryCenterDto surgeryCenterDto)
        {
            await _surgeryCenterService.Add(surgeryCenterDto);
            viewModel.SurgeryCenterDtoList = _surgeryCenterService.GetSurgeryCenter();
            return RedirectToAction("Index");
        }

    }
}