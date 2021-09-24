using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using MediClinic.Models;
using MediClinic.Services.Interfaces;
using MediClinic.Services.Interfaces.GrowthChartInterface;
using MediClinic.Services.Interfaces.ImagingInterface;
using MediClinic.Services.Interfaces.ImmunizationInterface;
using MediClinic.Services.Interfaces.LabInterface;
using MediClinic.Services.Interfaces.PatientInfoInterface;
using MediClinic.Services.Interfaces.PatientPrescriptionInterface;
using MediClinic.Services.Interfaces.PatientVitalInterface;
using MediClinic.Services.Interfaces.ProviderInfoInterface;
using MediClinic.Services.Interfaces.ReportInterface;
using MediClinic.Services.Interfaces.SessionManager;
using Microsoft.AspNetCore.Mvc;

namespace MediClinic.Controllers
{
    public class PatientExamController : Controller
    {
        private ISessionManager _sessionManager;

        private IReportService _reportService;
        private IPatientVitalService _patientVitalService;
        private IProviderInfoService _providerInfoService;
        private IPatientExamService _patientExamService;
        private IGrowthChartService _growthChartService;
        private IimmunizationService _immunizationService;
        private IPatientPrescriptionService _patientPrescriptionService;
        private ILabService _labService;
        private IImagingService _imagingService;
        private readonly IPatientInfoService _patientInfoService;


        public PatientExamController(ISessionManager sessionManager, IReportService reportService, IPatientVitalService patientVitalService,
            IProviderInfoService providerInfoService, IPatientExamService patientExamService, IGrowthChartService growthChartService,
            IimmunizationService iimmunizationService, IPatientPrescriptionService patientPrescriptionService, ILabService labService,
            IImagingService imagingService, IPatientInfoService patientInfoService)
        {
            _sessionManager = sessionManager;
            _reportService = reportService;
            _patientVitalService = patientVitalService;
            _providerInfoService = providerInfoService;
            _patientExamService = patientExamService;
            _growthChartService = growthChartService;
            _immunizationService = iimmunizationService;
            _patientPrescriptionService = patientPrescriptionService;
            _labService = labService;
            _imagingService = imagingService;
            _patientInfoService = patientInfoService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Exam()
        {
            PatientExamViewModel examViewModel = new PatientExamViewModel();
            var patientId = _sessionManager.GetPatientInfoId();
            examViewModel.ExamInfromationList = await _reportService.GetReportInfoList(patientId);
            examViewModel.Vitallist = await _patientVitalService.GetVitalListByVisits(patientId);
            foreach (var item in examViewModel.Vitallist)
            {
                if (item.ExamTime.Date == DateTime.Today.Date)
                {
                    item.IsEditableOrNot = true;
                }
                else
                {
                    item.IsEditableOrNot = false;
                }
            }
            examViewModel.ProviderList = await _providerInfoService.GetProviderList();
            examViewModel.PatientExamReasonList = _patientExamService.GetExamReasonlist();
            examViewModel.growthChartList = await _growthChartService.GetGrowthChartListByVisits(patientId);
            examViewModel.Listimmunization = await _immunizationService.ImmunizationList(patientId);
            examViewModel.prescriptionBasicsList = await _patientPrescriptionService.prescriptionListByVisits(patientId);
            examViewModel.getLabList = await _labService.GetLabListByVisits(patientId);
            examViewModel.getImagingDto = await _imagingService.GetImagingListByVisits(patientId);
            examViewModel.ICDList = await _immunizationService.GetAllICDCodes(true);
            examViewModel.MedicineList = _patientPrescriptionService.GetMedicine().Take(20);

            return View(examViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddVitalsElite(PatientExamViewModel viewModel)
        {
            var VisitId = _sessionManager.GetVisitId();
            viewModel.VitalDto.VisitId = VisitId;
            _patientVitalService.SavePatientVital(viewModel.VitalDto);
            var patientId = _sessionManager.GetPatientInfoId();
            viewModel.Vitallist = await _patientVitalService.GetVitalListByVisits(patientId);

            return PartialView("~/Views/PatientExam/ExamPartialViews/_VitalListing.cshtml", viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> ExamInformation(PatientExamViewModel viewModel)
        {
            viewModel.ExamInfromation.VisitId = _sessionManager.GetVisitId();
            await _reportService.CreateExamInformation(viewModel.ExamInfromation);
            var patientId = _sessionManager.GetPatientInfoId();

            viewModel.ExamInfromationList = await _reportService.GetReportInfoList(patientId);

            return PartialView("~/Views/PatientExam/ExamPartialViews/_PhysicalExamList.cshtml", viewModel);

        }
        [HttpPost]
        public async Task<IActionResult> GrowthChart(PatientExamViewModel viewModel)
        {
            var VisitId = _sessionManager.GetVisitId();
            viewModel.growthChardto.VisitId = VisitId;
            _growthChartService.Add(viewModel.growthChardto);
            var patientId = _sessionManager.GetPatientInfoId();
            viewModel.growthChartList = await _growthChartService.GetGrowthChartListByVisits(patientId);

            return PartialView("~/Views/PatientExam/ExamPartialViews/_GrowthList.cshtml", viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> AssignImmunization(PatientExamViewModel viewModel)
        {
            var age = _sessionManager.GetPatientDOB();
            var VisiId = _sessionManager.GetVisitId();
            var patientId = _sessionManager.GetPatientInfoId();

            var rec = await _patientInfoService.GetPatientDetailInfo(patientId);
            if (viewModel.immunization.ImmunizationId > 0)
            {
                viewModel.immunization.PatientCurrentAge = rec.DateOfBirth;
                viewModel.immunization.IsActive = true;

                await _immunizationService.ImmunizationUpdate(viewModel.immunization);
            }
            else
            {
                viewModel.immunization.PatientCurrentAge = rec.DateOfBirth;
                viewModel.immunization.IsActive = true;
                viewModel.immunization.VisitId = VisiId;
                await _immunizationService.ImmunizationCreate(viewModel.immunization);
            }
            viewModel.ICDList = await _immunizationService.GetAllICDCodes(true);
            viewModel.Listimmunization = await _immunizationService.ImmunizationList(patientId);

            return PartialView("~/Views/PatientExam/ExamPartialViews/_ImmunizationList.cshtml", viewModel);

        }
        [HttpPost]
        public async Task<IActionResult> AddPrescription(PatientExamViewModel viewModel)
        {

            try
            {
                //DateTime sDate;
                //DateTime eDate;
                //if (viewModel.prescriptionBasicDto.Id == 0)
                //{
                //    CultureInfo provider = CultureInfo.InvariantCulture;
                //    sDate = DateTime.ParseExact(viewModel.StartDate, "mm/dd/yyyy", provider);
                //    eDate = DateTime.ParseExact(viewModel.EndDate, "mm/dd/yyyy", provider);
                //}
                //else
                //{
                //    sDate = Convert.ToDateTime(viewModel.StartDate);
                //    eDate = Convert.ToDateTime(viewModel.StartDate);
                //}
                var patientId = _sessionManager.GetPatientInfoId();
                var RoleId = _sessionManager.GetRoleId();
                var VisitId = _sessionManager.GetVisitId();
                //viewModel.prescriptionBasicDto.StartDate = sDate;
                //viewModel.prescriptionBasicDto.EndDate = eDate;

                if (viewModel.prescriptionBasicDto.Id > 0)
                {
                    var exist = await _patientPrescriptionService.isUpdatePrescriptionExistorNot(viewModel.prescriptionBasicDto.Id, viewModel.prescriptionBasicDto.MedicationId, patientId);
                    if (exist.Data)
                    {
                        return Json("exist");
                    }
                    else
                    {
                        await _patientPrescriptionService.prescriptionUpdate(viewModel.prescriptionBasicDto);
                    }
                }
                else
                {
                    if (RoleId == 1)
                    {
                        viewModel.prescriptionBasicDto.PatientInfoId = patientId;

                    }
                    //var exist = await _patientPrescriptionService.isPrescriptionExistorNot(viewModel.prescriptionBasicDto.MedicationId, patientId);
                    //if (exist.Data)
                    //{
                    //    return Json("exist");
                    //}
                    else
                    {
                        viewModel.prescriptionBasicDto.VisitId = VisitId;
                        viewModel.prescriptionBasicDto.PatientInfoId = patientId;
                        await _patientPrescriptionService.prescriptionCreate(viewModel.prescriptionBasicDto);

                    }
                }
                viewModel.prescriptionBasicsList = await _patientPrescriptionService.prescriptionListByVisits(patientId);

                return PartialView("~/Views/PatientExam/ExamPartialViews/_PrescriptionList.cshtml", viewModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        [HttpPost]
        public async Task<IActionResult> AddLab(PatientExamViewModel viewModel)
        {
            var VisitID = _sessionManager.GetVisitId();
            viewModel.labDto.VisitId = VisitID;
            _labService.Add(viewModel.labDto);
            var patientId = _sessionManager.GetPatientInfoId();
            viewModel.getLabList = await _labService.GetLabListByVisits(patientId);

            return PartialView("~/Views/PatientExam/ExamPartialViews/_LabList.cshtml", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddImaging(PatientExamViewModel viewModel)
        {
            var VisitId = _sessionManager.GetVisitId();
            viewModel.imagingDto.VisitId = VisitId;
            await _imagingService.Add(viewModel.imagingDto);
            var patientId = _sessionManager.GetPatientInfoId();
            viewModel.getImagingDto = await _imagingService.GetImagingListByVisits(patientId);

            return PartialView("~/Views/PatientExam/ExamPartialViews/_LabList.cshtml", viewModel);
        }

    }
}
