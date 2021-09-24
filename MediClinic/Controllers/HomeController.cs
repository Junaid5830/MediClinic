using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MediClinic.Models;
using MediClinic.Services.Interfaces.AuthInterface;
using MediClinic.Models.DTOs.UsersDto;
using MediClinic.Services.Interfaces.ProviderInfoInterface;
using MediClinic.Services.Interfaces.ProviderTemplateInterface;
using MediClinic.Services.Interfaces.RelatedFacilityInterface;
using MediClinic.Services.Interfaces.LookupInteface;
using MediClinic.Services.Interfaces.UserInterface;
using MediClinic.Services.Interfaces.ProviderSpecialityInterface;
using MediClinic.Services.Interfaces.ProviderTermInterface;
using MediClinic.Services.Interfaces.ProviderUidTypeInterface;
using MediClinic.Services.Interfaces.SubProviderInterface;
using MediClinic.Services.Interfaces.SessionManager;
using MediClinic.Models.DTOs.ProviderInfoDto;
using MediClinic.Filters; 
using MedliClinic.Utilities.Utility.Enum;
using MediClinic.Utility;
using MedliClinic.Utilities.Utility;
using MediClinic.Services.Interfaces;
using MediClinic.Models.DTOs.DMESuppliesDto;
using MediClinic.Services.Interfaces.PatientMissingInterface;
using MediClinic.Services.Interfaces.PatientSettings;
using Microsoft.AspNetCore.SignalR;
using MediClinic.SignalRHub;
using MediClinic.Services.Interfaces.UserRolePageInterface;
using MediClinic.Services.Interfaces.EmployeeInterface;
using MediClinic.Models.DTOs.PatientInfoDto;
using MediClinic.Services.Interfaces.Patient;
using MediClinic.Services.Interfaces.DepartmentsInterface;
using MediClinic.Models.DTOs;

namespace MediClinic.Controllers
{
    //[AuthFilter(RoleNames.Doctor, RoleNames.Patient,RoleNames.Receptionist,RoleNames.Employees,RoleNames.Admin)]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IProviderInfoService _providerInfoService;
        private IProviderTemplateService _providerTemplateService;
        private IRelatedFacilityService _relatedFacilityService;
        private ILookupService _lookupService;
        private IUserService _userService;
        private IProviderSpecialityService _providerSpecialityService;
        private IProviderTermService _providerTermService;
        private IProviderUidTypeService _providerUidTypeService;
        private ISubProviderService _subProviderService;
        private ISessionManager _sessionManager;
        private IDMESuppliesService _DMESuppliesService;
        private IPatientMissingService _patientMissingService;
        private IPatientSettings _patientSettings;
        private IEmployeeService _EmployeeService;
        private IPatientService _patientService;
        private IDepartmentsService _departmentsService;

        private readonly IUserRolePageService _userRolePageService;

        private readonly IHubContext<NotificationsHub> _hubContext;
        public HomeController(ILogger<HomeController> logger,
            IProviderInfoService providerInfoService, IProviderTemplateService providerTemplateService, IUserService userService,
            IRelatedFacilityService relatedFacilityService, ILookupService lookupService, IProviderSpecialityService providerSpecialityService,
            IProviderTermService providerTermService, IPatientSettings patientSettings, IPatientMissingService patientMissingService,IProviderUidTypeService providerUidTypeService, ISubProviderService subProviderService, ISessionManager sessionManager, IDMESuppliesService dMESuppliesService,
            IHubContext<NotificationsHub> hubContext, IUserRolePageService userRolePageService, IEmployeeService employeeService, IPatientService patientService, IDepartmentsService departmentsService
            )
        {
            _logger = logger;
            _providerInfoService = providerInfoService;
            _providerTemplateService = providerTemplateService;
            _relatedFacilityService = relatedFacilityService;
            _lookupService = lookupService;
            _userService = userService;
            _providerSpecialityService = providerSpecialityService;
            _providerTermService = providerTermService;
            _providerUidTypeService = providerUidTypeService;
            _subProviderService = subProviderService;
            _sessionManager = sessionManager;
            _DMESuppliesService = dMESuppliesService;
            _patientMissingService = patientMissingService;
            _patientSettings = patientSettings;
            _userRolePageService = userRolePageService;
            _EmployeeService = employeeService;
            _hubContext = hubContext;
            _patientService = patientService;
            _departmentsService = departmentsService;
        }

        public async Task<IActionResult> Index(long? Id)
        {
            var userId = _sessionManager.GetUserId();
            var userData = _userService.GetUserDetail(Convert.ToInt32(userId));
            var provider = await _providerInfoService.GetProviderSummaryDetails((long)Id);
            _sessionManager.SetProviderName(provider.FullName);
            _sessionManager.SetProviderInfoId(Id.Value);
            return View();
        }
        public IActionResult Registration()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult PatientAllergy(long Id)
        {
            ViewBag.PatientAllergy = "nav-active";
            return View();
        }
        public IActionResult PatientCalendar(long Id)
        {
            ViewBag.PatientCalendar = "nav-active";
            return View();
        }
        public IActionResult PatientClaims(long Id)
        {
            ViewBag.PatientClaims = "nav-active";
            return View();
        }
        public IActionResult PatientClaimsExams(long Id)
        {
            ViewBag.PatientClaimsExams = "nav-active";
            return View();
        }
        public IActionResult PatientClaimsNewExam()
        {
            return View();
        }
        public IActionResult PatientHippaRelease(long Id)
        {
            ViewBag.PatientHippaRelease = "nav-active";
            return View();
        }
        public IActionResult PatientHippaReleaseEdit()
        {
            return View();
        }
        public IActionResult PatientHippaReleaseImaging(long Id)
        {
            ViewBag.PatientHippaReleaseImaging = "nav-active";
            return View();
        }
        public IActionResult PatientHippaReleaseImagingEdit()
        {
            return View();
        }
       
      
      
       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
     

        //public async Task<IActionResult> DoctorProfile(int? providerId)
        //{
        //    ProviderViewModel providerViewModel = new ProviderViewModel();
        //    providerViewModel.Provider = new ProviderInfoBasicDto();

        //    //var infoList = await _providerTemplateService.providerTemplate();
        //    //providerViewModel.ProviderTemplateList = infoList.Data;
        //    //var infoSpecList = await _providerSpecialityService.providerSpeciality();
        //    //providerViewModel.ProviderSpecialityList = infoSpecList.Data;
        //    var infoTitleList = _lookupService.lookupByTypeBasicDto("ProviderTitle");
        //    providerViewModel.ProviderTitleList = infoTitleList.Data;
        //    var infoSuffixList = _lookupService.lookupByTypeBasicDto("ProviderSuffix");
        //    providerViewModel.ProviderSuffixList = infoSuffixList.Data;
        //    //var infoRentTypeList = _lookupService.lookupByTypeBasicDto("ProviderRentType");
        //    //providerViewModel.ProviderRentTypeList = infoRentTypeList.Data;
        //    //var infoScannedDocumentList = _lookupService.lookupByTypeBasicDto("ScannedDocument");
        //    //providerViewModel.ProviderScannedDocumentsList = infoScannedDocumentList.Data;
        //    var infoStatusList = _lookupService.lookupByTypeBasicDto("ProviderStatus");
        //    providerViewModel.ProviderStatusList = infoStatusList.Data;
        //    //var infoRelatedFacilityList = await _relatedFacilityService.relatedFacility();
        //    //providerViewModel.ProviderRelatedFacilityList = infoRelatedFacilityList.Data;
        //    //var infoProviderTermList = await _providerTermService.providerTerm();
        //    //providerViewModel.ProviderTermList = infoProviderTermList.Data;
        //    //var infoSubProviderList = await _subProviderService.subProvider();
        //    //providerViewModel.SubProviderList = infoSubProviderList.Data;

        //    var infoUidTypeList = _providerUidTypeService.providerUidTypeBasicDto();
        //    providerViewModel.ProviderUidTypeList = infoUidTypeList;
        //    return View(providerViewModel);
        //}
      
      
        
      
      
      

        public IActionResult HipperRelease(long Id)
        {
            ViewBag.HipperRelease = "nav-active";
            return View();
        }
        
       



      
     
      



      
       
   

        public async Task<IActionResult> Index2(long? Id) 
        {
            DashbordViewModel viewModel = new DashbordViewModel();
            var userId = _sessionManager.GetUserId();
            var RoleId = _sessionManager.GetRoleId();
            _sessionManager.SetPatientInfoId(0);

            _sessionManager.SetEmployeeId((long)Id);
            var userData = _userService.GetUserDetail(Convert.ToInt32(userId));
            var PermisionPageList = await _userRolePageService.GetSideBarList(RoleId);
            _sessionManager.SetPermisionPage(PermisionPageList);
            viewModel.Dashboarcount = _patientService.GetProvidertinfo();
            if (RoleId == 2)
            {
                var provider = await _providerInfoService.GetProviderSummaryDetails((long)Id);
                _sessionManager.SetProviderName(provider.FullName);
                _sessionManager.SetProviderInfoId(Id.Value);
            }
            else
            {
                var Employee = _EmployeeService.EmployeeDetailById((long)Id);
                _sessionManager.SetEmployeeId(Employee.Employee_id);
                _sessionManager.SetEmployeeName(Employee.FirstName);
                viewModel.departmentsDto = _departmentsService.getlist();
            }
            return View(viewModel);


        }
        public IActionResult SpeechToText()
        {
            return View();
        }

        public async Task<IActionResult> SaveICDCodes(string codeName)
        {
            await _DMESuppliesService.SaveICDCode(codeName);
            return View();
        }

        //public IActionResult SaveCPTCodes()
        //{
        //    CommonFieldsDMECodesDto commonFields = new CommonFieldsDMECodesDto();
           
        //    var cptList = new List<CPTCodeDto>();
        //    var startFrom = 10004;
        //    var endTo = 69990;

        //    for (int i = startFrom; i < endTo; i++)
        //    {
        //        CPTCodeDto cPTCode = new CPTCodeDto();
        //        cPTCode.Name = i.ToString();
        //        cPTCode.Description = "";
        //        cptList.Add(cPTCode);
        //    }
        //    commonFields.CPTList = cptList;

        //    _DMESuppliesService.SaveCPTCodes(commonFields);

        //    return View();
        //}
        
        
    }
}

