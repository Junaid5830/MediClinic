using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediClinic.Models;
using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Services.Interfaces.PatientInfoInterface;
using MediClinic.Services.Interfaces.PatientSettings;
using MediClinic.Services.Interfaces.ProviderInfoInterface;
using MediClinic.Services.Interfaces.ReportInterface;
using MediClinic.Services.Interfaces.SessionManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MediClinic.Controllers
{
    public class ReportsController : Controller
    {
        private IReportService _reportService;
        private readonly IPatientInfoService _patientInfoService;
        private IPatientSettings _patientSettings;
        private ISessionManager _sessionManager;
        private IProviderInfoService _providerInfoService;

        public ReportsController(IReportService reportService, IProviderInfoService providerInfoService, ISessionManager sessionManager, IPatientSettings patientSettings, IPatientInfoService patientInfoService)
        {
            _reportService = reportService;
            _patientInfoService = patientInfoService;
            _patientSettings = patientSettings;
            _sessionManager = sessionManager;
            _providerInfoService = providerInfoService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> DoctorInitalReport()
        {
            ReportsViewModel modal = new ReportsViewModel();
            modal.patientListWithUsers = await _patientInfoService.GetPatientListWithDetails();

            return View(modal);
        }
        [HttpPost]
        public async Task<IActionResult> PatientInformation(ReportsViewModel reportsViewModel)
        {
            if (reportsViewModel.reportPatientDto.ReportPatientInfoId > 0)
            {

            }
            else
            {
                await _reportService.CreatePatientinformaton(reportsViewModel.reportPatientDto); 
            }
            var data = new { Success = "Successfully Save", IsError = true };

            return Json(data);
        }
        [HttpPost]
        public async Task<IActionResult> EmployeeInformation(ReportsViewModel reportsViewModel)
        {
            if (reportsViewModel.reportemployeeDto.ReportEmployeeId> 0)
            {

            }
            else
            {
                await _reportService.CreateEmployeeinformaton(reportsViewModel.reportemployeeDto);
            }
            var data = new { Success = "Successfully Save", IsError = true };

            return Json(data);
        }
        [HttpPost]
        public async Task<IActionResult> DoctorInformation(ReportsViewModel reportsViewModel)
        {

            if (reportsViewModel.reportDoctorInfoDto.ReportDoctorInfoId> 0)
            {

            }
            else
            {
                await _reportService.CreateDoctorinformaton(reportsViewModel.reportDoctorInfoDto);
            }
            var data = new { Success = "Successfully Save", IsError = true };

            return Json(data);
        }
        [HttpPost]
        public async Task<IActionResult> ReportHistory(ReportsViewModel reportsViewModel)
        {

            if (reportsViewModel.reportHistoryDto.ReportHistoryId > 0)
            {

            }
            else
            {
                await _reportService.CreateHistory(reportsViewModel.reportHistoryDto);
            }
            var data = new { Success = "Successfully Save", IsError = true };

            return Json(data);
        }
        [HttpPost]
        public async Task<IActionResult> BillingInformation(ReportsViewModel reportsViewModel)
        {

            if (reportsViewModel.reportBillingInfoDto.ReportBillingInfoId > 0)
            {

            }
            else
            {
                var rec = await _reportService.CreateBillingInformation(reportsViewModel.reportBillingInfoDto);
                reportsViewModel.reportBillingCodeDto.ReportBillingInfoId = rec.Data.ReportBillingInfoId;
                if (reportsViewModel.reportBillingInvoices.Count>0)
                {
                    reportsViewModel.reportBillingInvoices.ForEach(x => x.ReportBillingInfoId = rec.Data.ReportBillingInfoId);
                }  
                await _reportService.CreateBillingCode(reportsViewModel.reportBillingCodeDto);
                await _reportService.CreateBillingInvoice(reportsViewModel.reportBillingInvoices);
            }
            var data = new { Success = "Successfully Save", IsError = true };

            return Json(data);
        }
        [HttpPost]
        public async Task<IActionResult> ExamInformation(ReportsViewModel reportsViewModel)
        {
                reportsViewModel.ExamInfromation.VisitId = _sessionManager.GetVisitId();
                await _reportService.CreateExamInformation(reportsViewModel.ExamInfromation);
                var data = new { Success = "Successfully Save", IsError = true };
                return Json(data);
        }

        [HttpPost]
        public async Task<IActionResult> DoctorOpinion(ReportsViewModel reportsViewModel)
        {
            if (reportsViewModel.DoctorOpinion.DoctorOpinionId > 0)
            {

            }
            else
            {
                await _reportService.CreateDoctorOpinion(reportsViewModel.DoctorOpinion);
            }
            var data = new { Success = "Successfully Save", IsError = true };

            return Json(data);
        }

        [HttpPost]
        public async Task<IActionResult> PlanOfCare(ReportsViewModel reportsViewModel)
        {
            if (reportsViewModel.PlanOfCare.PlanCareId > 0)
            {

            }
            else
            {
                await _reportService.CreatePlanOfCare(reportsViewModel.PlanOfCare);
            }
            var data = new { Success = "Successfully Save", IsError = true };

            return Json(data);
        }
        [HttpPost]
        public async Task<IActionResult> WorkStatus(ReportsViewModel reportsViewModel)
        {
            if (reportsViewModel.WorkStatus.WorkStatusId > 0)
            {

            }
            else
            {
                await _reportService.CreateWorkStatus(reportsViewModel.WorkStatus);
            }
            var data = new { Success = "Successfully Save", IsError = true };

            return Json(data);
        }


        public IActionResult NoFaultInsurancelaw()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> NoFaultInsurancelaw(ReportsViewModel reportsViewModel)
        {
            if (reportsViewModel.nF2AobDto.Nf2AobId > 0)
            {

            }
            else
            {
              
                await _reportService.Createnf2Aob(reportsViewModel.nF2AobDto);
            }
            var data = new { Success = "Successfully Save", IsError = true };

            return Json(data);
        }




        public async Task<IActionResult> MaterReportingMode(long? Id)
        {
            PatientViewModel patientViewModel = new PatientViewModel();
            var userId = (long?)_sessionManager.GetUserId();
            if (!(userId is null))
            {
                patientViewModel.PatientListSettingDto = _patientSettings.getPatientListSettingsById((int)userId);
            }
            patientViewModel.ProviderList = await _providerInfoService.GetProviderList();
            patientViewModel.patientListWithUsers = await _patientInfoService.GetPatientListWithDetails();
            if (patientViewModel.patientListWithUsers.Count > 0)
            {
                patientViewModel.patientListWithUsers = patientViewModel.patientListWithUsers.Distinct().ToList();
            }
            patientViewModel.IncomeCategoryList = _reportService.GetListIncomeCategory();
            patientViewModel.ReportIncomeList = await _reportService.GetIncomeListForPatient(71);

            return View(patientViewModel);
        }


        public  IActionResult GetListForDropDown()
        {
            var ListItems =   _reportService.GetListIncomeCategory();
            
            return Json(ListItems);
        }


        [HttpPost]
        public async Task<IActionResult> AddCategory(PatientViewModel patientViewModel)
        {
            var category = new ResponseDto<IncomeExpenceCategoryDto>();
            if (patientViewModel.IncomeExpenceCategory.CategoryId > 0)
            {

            }
            else
            {
                category =  await _reportService.CreateCategory(patientViewModel.IncomeExpenceCategory);
            }
            var data = new { CategoryText=category.Data.CategoryName, CategoryValue=category.Data.CategoryId, Success = "Successfully Save", IsError = false };

            return Json(data);
        }


        [HttpPost]
        public async Task<IActionResult> CategoryPrice(int Id)
        {
            var category = new ResponseDto<IncomeExpenceCategoryDto>();
            if (Id > 0)
            {
                category = await _reportService.GetCategoryPriceById(Id);
                var data = new { CategoryPricePerUnit = category.Data.CategoryPrice };


                return Json(data);
            }
            else
                return Json(  new {IsErorr = true });
           

        }


        [HttpPost]
        public async Task<IActionResult> CreateIncome(PatientViewModel patientViewModel)
        {
            if (patientViewModel.ReportIncome.IncomeId > 0)
            {

            }
            else
            {
                await _reportService.CreateIncome(patientViewModel.ReportIncomeList);
            }
          

            var data = new { Success = "Successfully Save", IsError = false };

            return Json(data);
        }


        [HttpPost]
        public async Task<IActionResult> CreateExpence(PatientViewModel patientViewModel)
        {
            if (patientViewModel.ReportIncome.IncomeId > 0)
            {

            }
            else
            {
                await _reportService.CreateExpence(patientViewModel.ReportExpenceList);
            }


            var data = new { Success = "Successfully Save", IsError = false };

            return Json(data);
        }
        [HttpGet]
        public async Task<IActionResult> ReportIncomeList(long Id)
        {
            PatientViewModel patientViewModel = new PatientViewModel();
            patientViewModel.ReportIncomeList = await _reportService.GetIncomeListForPatient(Id);
            return PartialView("~/Views/Reports/PartialViews/_ReportIncomeList.cshtml", patientViewModel);
        }



        public async Task<IActionResult> CheckInOut()
        {
            ReportsViewModel reportsViewModel = new ReportsViewModel();
            DateTime today = DateTime.Today;
            reportsViewModel.checkInOutList = await _reportService.checkInoutList(today);
            return View(reportsViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> CheckInOutList(DateTime dateTime)
        {
            ReportsViewModel reportsViewModel = new ReportsViewModel();
            reportsViewModel.checkInOutList = await _reportService.checkInoutList(dateTime);
            return PartialView("~/Views/Reports/PartialViews/_CheckInOut.cshtml", reportsViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> CheckInCreate(int CheckId, long UserId)
        {
            ReportsViewModel reportsViewModel = new ReportsViewModel();
            await _reportService.checkInCreate(CheckId, UserId);
            DateTime today = DateTime.Today;
            reportsViewModel.checkInOutList = await _reportService.checkInoutList(today);
            return PartialView("~/Views/Reports/PartialViews/_CheckInOut.cshtml", reportsViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> CheckOutCreate(int CheckId, long UserId)
        {
            ReportsViewModel reportsViewModel = new ReportsViewModel();
            await _reportService.checkOutCreate(CheckId, UserId);
            DateTime today = DateTime.Today;
            reportsViewModel.checkInOutList = await _reportService.checkInoutList(today);
            return PartialView("~/Views/Reports/PartialViews/_CheckInOut.cshtml", reportsViewModel);
        }
        public async Task<IActionResult> DeleteId(long Id)
        {
            ReportsViewModel reportsViewModel = new ReportsViewModel();
            await _reportService.CheckInOutDelete(Id);
            DateTime today = DateTime.Today;
            reportsViewModel.checkInOutList = await _reportService.checkInoutList(today);
            return PartialView("~/Views/Reports/PartialViews/_CheckInOut.cshtml", reportsViewModel);
        }
    }
}
