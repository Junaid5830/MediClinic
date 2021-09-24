using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediClinic.Models;
using MediClinic.Models.DTOs.PatientLegalStatusDto;
using MediClinic.Models.DTOs.PatientTreatmentStatusDto;
using MediClinic.Services.Interfaces.AddNewCaseTypeInterface;
using MediClinic.Services.Interfaces.ClaimStatusInterface;
using MediClinic.Services.Interfaces.IncidentReportStatusInterface;
using MediClinic.Services.Interfaces.LegalInfoLegalInterface;
using MediClinic.Services.Interfaces.LookupInteface;
using MediClinic.Services.Interfaces.Nf2StatusInterface;
using MediClinic.Services.Interfaces.PatientArbitrationAttorneyInterface;
using MediClinic.Services.Interfaces.PatientCaseTypeInterface;
using MediClinic.Services.Interfaces.PatientClaimInfoInterface;
using MediClinic.Services.Interfaces.PatientEmergencyContactInterface;
using MediClinic.Services.Interfaces.PatientIdandSignatureInterface;
using MediClinic.Services.Interfaces.PatientIncidentRoleInterface;
using MediClinic.Services.Interfaces.PatientInfoInterface;
using MediClinic.Services.Interfaces.PatientLegalStatusInterface;
using MediClinic.Services.Interfaces.PatientPersonalInjuryInterface;
using MediClinic.Services.Interfaces.PatientPhoneNumberInterface;
using MediClinic.Services.Interfaces.PatientSecondaryInsuranceInterface;
using MediClinic.Services.Interfaces.PatientTertiaryInsuranceInterface;
using MediClinic.Services.Interfaces.PatientTreatmentStatusInterface;
using MediClinic.Services.Interfaces.PatientVehicleInterface;
using MediClinic.Services.Interfaces.SessionManager;
using MediClinic.Services.Interfaces.UserInterface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Drawing;
using MediClinic.Services.Interfaces.EmploymentStatusInterface;
using MediClinic.Services.Interfaces.EmploymentTitleInterface;
using System.Globalization;
using MediClinic.Services.Interfaces.PatientSignatureIdTypeInterface;
using MediClinic.Services.Interfaces.InsuranceProviderNameInterface;
using MediClinic.Services.Interfaces.InsuranceGroupNumberInterface;
using MediClinic.Services.Interfaces.LegalInfoLeadingAttorney;
using MediClinic.Services.Interfaces.LeagalInfoFirmNameInterface;
using MediClinic.Services.Interfaces.LegalInfoAttorneyNameInterface;
using MediClinic.Services.Interfaces.LegalInfoLeadingParalegalInterface;
using MediClinic.Filters;
using MediClinic.Services.Interfaces.AuthInterface;
using System.Text.Json;
using MediClinic.Services.Interfaces.PatientRelationshipInterface;
using MediClinic.Services.Interfaces.PatientLanguageInterface;
using MediClinic.Services.Interfaces.MedicalDiseaseTypeInterface;
using MediClinic.Services.Interfaces.PatientMedicalProblemInterface;
using MediClinic.Models.DTOs.PatientInfoListDto;
using MediClinic.Models.DTOs.VitalBasicDto;
using MediClinic.Services.Interfaces.ProviderInfoInterface;
using MediClinic.Services.Interfaces;
using MediClinic.Services.Interfaces.PatientVitalInterface;
using MediClinic.Services.Interfaces.PatientMissingInterface;
using MediClinic.Services.Interfaces.PatientMedicalHistoryInterface;
using MediClinic.Services.Interfaces.Doctor;
using MediClinic.Services.Interfaces.Patient;
using MedliClinic.Utilities.Utility;
using MediClinic.Services.Interfaces.ProviderSpecialityInterface;
using MediClinic.Services.Interfaces.PatientSettings;
using MediClinic.Services.Interfaces.PatientPrescriptionInterface;
using MediClinic.Services.Interfaces.PrescriptionTemplateService;

using Microsoft.AspNetCore.SignalR;
using MediClinic.SignalRHub;
using MediClinic.Models.DTOs.ClaimStatus;
using System.IO;
using System.Net.Http.Headers;
using System.Drawing.Imaging;
using MediClinic.Services.Interfaces.UserRolePageInterface;
using MediClinic.Models.DTOs.DMESuppliesDto;
using Microsoft.EntityFrameworkCore.Internal;
using MediClinic.Services.Interfaces.AllergyInterface;
using MediClinic.Services.Interfaces.FacilityLocation;
using MediClinic.Services.Interfaces.ReportInterface;
using MediClinic.Models.DTOs.PatientClaimInfo;

namespace MediClinic.Controllers.PatiendSide
{
    //[AuthFilter(RoleNames.Doctor, RoleNames.Patient, RoleNames.Receptionist, RoleNames.Admin)]

    public class PatientSideEliteController : Controller
    {
        private readonly ILogger<PatientSideEliteController> _logger;
        private readonly IPatientInfoService _patientInfoService;
        private IPatientPhoneNumberService _patientPhoneNumberService;
        private IPatientEmergencyContactService _patientEmergencyContactService;
        private IPatientSecondaryInsuranceService _patientSecondaryInsuranceService;
        private IPatientTertiaryInsuranceService _patientTertiaryInsuranceService;
        private IPatientArbitrationAttorneyService _patientArbitrationAttorneyService;
        private IPatientPersonalInjuryService _patientPersonalInjuryService;
        private IPatientClaimInfoService _patientClaimInfoService;
        private IPatientVehicleService _patientVehicleService;
        private IPatientIdandSignatureService _patientIdandSignatureService;
        private IPatientTreatmentStatusService _patientTreatmentStatusService;
        private IPatientLegalStatusService _patientLegalStatusService;
        private IClaimStatusService _claimStatusService;
        private IUserService _userService;
        private IIncidentReportStatusService _incidentReportStatus;
        private INf2StatusService _nf2StatusService;
        private IPatientIncidentRoleService _patientIncidentRoleService;
        private IPatientCaseTypeService _patientCaseTypeService;
        private IAddNewCaseTypeService _addNewCaseTypeService;
        private IEmploymentTitleService _employmentTitleService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private IEmploymentStatusService _employmentStatus;
        private ILegalInfolegalService _legalInfolegalService;
        private IInsuranceProviderNameService _insuranceProviderNameService;
        private IPatientSignatureIdTypeService _patientSignatureIdTypeService;
        private IInsuranceGroupNumberService _insuranceGroupNumberService;
        private ILegalInfoFirmNameService _legalInfoFirmNameService;
        private ILegalInfoAttorneyNameService _legalInfoAttorneyNameService;
        private ILegalInfoLeadingParalegal _legalInfoLeadingParalegalService;
        private IPatientRelationshipService _patientRelationship;
        private IPatientLanguageService _patientLanguageService;
        private IMedicalDiseaseTypeService _medicalDiseaseTypeService;
        private IPatientMedicalProblemService _patientMedicalProblemService;
        private ISessionManager _sessionManager;
        private ILookupService _lookupService;
        private ILegalInfoLeadingAttorneyService _legalInfoLeadingAttorney;
        private IAuthService _authService;
        private IProviderInfoService _providerInfoService;
        private IPatientExamService _patientExamService;
        private IPatientVitalService _patientVitalService;
        private IPatientMissingService _patientMissingService;
        private ICommonService _Common;
        private IDoctorService _DoctorService;
        private IPatientService _PatientService;
        private IPatientPrescriptionService _patientPrescriptionService;
        private IPatientMedicalHistoryService _patientMedicalHistoryService;
        private IProviderSpecialityService _providerSpecialityService;
        private IPatientSettings _patientSettings;
        private readonly IMediTemplateService _templateService;
        private readonly IHubContext<NotificationsHub> _notificationHubContext;
        private readonly IUserRolePageService _userRolePageService;
        private readonly IDMESuppliesService _dMESuppliesService;
        private IAllergyService _allergyService;
        private IFacilityLocation _facilityLocation;
        private IReportService _reportService;
        public PatientSideEliteController(ILogger<PatientSideEliteController> logger,
            ICommonService common,
            IPatientInfoService patientInfoService, IPatientPhoneNumberService patientPhoneNumberService,
            IPatientEmergencyContactService patientEmergencyContactService,
            IPatientSecondaryInsuranceService patientSecondaryInsuranceService,
            IPatientTertiaryInsuranceService patientTertiaryInsuranceService,
            IPatientArbitrationAttorneyService patientArbitrationAttorneyService,
            IPatientPersonalInjuryService patientPersonalInjuryService,
            IPatientClaimInfoService patientClaimInfoService,
            IPatientVehicleService patientVehicleService,
             ILegalInfoLeadingAttorneyService legalInfoLeadingAttorney,
            IPatientIdandSignatureService patientIdandSignatureService,
            IPatientTreatmentStatusService patientTreatmentStatusService,
            IPatientLegalStatusService patientLegalStatusService,
            IClaimStatusService claimStatusService,
            INf2StatusService nf2StatusService,
            IUserService userService,
            IPatientCaseTypeService patientCaseTypeService,
            IAddNewCaseTypeService addNewCaseTypeService,
            IPatientIncidentRoleService patientIncidentRoleService,
            IIncidentReportStatusService incidentReportStatusService,
            ILegalInfolegalService legalInfolegalService,
            IEmploymentStatusService employmentStatusService,
            IEmploymentTitleService employmentTitleService,
            IInsuranceProviderNameService insuranceProviderNameService,
            IPatientSignatureIdTypeService patientSignatureIdTypeService,
            IInsuranceGroupNumberService insuranceGroupNumberService,
            ILegalInfoFirmNameService legalInfoFirmNameService,
            ILegalInfoAttorneyNameService legalInfoAttorneyNameService,
            ILegalInfoLeadingParalegal legalInfoLeadingParalegal,
            IPatientRelationshipService patientRelationship,
            IPatientLanguageService patientLanguageService,
            IMedicalDiseaseTypeService medicalDiseaseTypeService,
            IPatientMedicalProblemService patientMedicalProblemService,
            IWebHostEnvironment webHostEnvironment,
            IProviderInfoService providerInfoService,
            IPatientExamService patientExamService,
            IPatientVitalService patientVitalService,
            IPatientMissingService patientMissingService,
            IPatientMedicalHistoryService patientMedicalHistoryService,
            IDoctorService DoctorService,
            IPatientService PatientService,
            IPatientPrescriptionService patientPrescriptionService,
            IProviderSpecialityService providerSpecialityService,
            IPatientSettings patientSettings,
            IMediTemplateService templateService,
            IUserRolePageService userRolePageService,
            IHubContext<NotificationsHub> notificationHubContext,
            IDMESuppliesService dMESuppliesService,
            IFacilityLocation facilityLocation,
            IReportService reportService,

        ISessionManager sessionManager, ILookupService lookupService, IAuthService authService, IAllergyService allergyService)
        {
            _logger = logger;
            _patientInfoService = patientInfoService;
            _patientPhoneNumberService = patientPhoneNumberService;
            _patientEmergencyContactService = patientEmergencyContactService;
            _patientSecondaryInsuranceService = patientSecondaryInsuranceService;
            _patientTertiaryInsuranceService = patientTertiaryInsuranceService;
            _patientArbitrationAttorneyService = patientArbitrationAttorneyService;
            _patientPersonalInjuryService = patientPersonalInjuryService;
            _patientClaimInfoService = patientClaimInfoService;
            _patientVehicleService = patientVehicleService;
            _patientIdandSignatureService = patientIdandSignatureService;
            _patientTreatmentStatusService = patientTreatmentStatusService;
            _patientLegalStatusService = patientLegalStatusService;
            _claimStatusService = claimStatusService;
            _incidentReportStatus = incidentReportStatusService;
            _nf2StatusService = nf2StatusService;
            _userService = userService;
            _patientIncidentRoleService = patientIncidentRoleService;
            _patientCaseTypeService = patientCaseTypeService;
            _legalInfolegalService = legalInfolegalService;
            _addNewCaseTypeService = addNewCaseTypeService;
            _employmentTitleService = employmentTitleService;
            _patientSignatureIdTypeService = patientSignatureIdTypeService;
            _insuranceProviderNameService = insuranceProviderNameService;
            _insuranceGroupNumberService = insuranceGroupNumberService;
            _legalInfoFirmNameService = legalInfoFirmNameService;
            _legalInfoAttorneyNameService = legalInfoAttorneyNameService;
            _webHostEnvironment = webHostEnvironment;
            _lookupService = lookupService;
            _legalInfoLeadingParalegalService = legalInfoLeadingParalegal;
            _employmentStatus = employmentStatusService;
            _patientRelationship = patientRelationship;
            _patientLanguageService = patientLanguageService;
            _medicalDiseaseTypeService = medicalDiseaseTypeService;
            _patientMedicalProblemService = patientMedicalProblemService;
            _sessionManager = sessionManager;
            _legalInfoLeadingAttorney = legalInfoLeadingAttorney;
            _authService = authService;
            _providerInfoService = providerInfoService;
            _patientExamService = patientExamService;
            _patientVitalService = patientVitalService;
            _patientMissingService = patientMissingService;
            _DoctorService = DoctorService;
            _PatientService = PatientService;
            _patientMissingService = patientMissingService;
            _patientMedicalHistoryService = patientMedicalHistoryService;
            _providerSpecialityService = providerSpecialityService;
            _patientSettings = patientSettings;
            _patientPrescriptionService = patientPrescriptionService;
            _templateService = templateService;
            _Common = common;
            _userRolePageService = userRolePageService;
            _notificationHubContext = notificationHubContext;
            _dMESuppliesService = dMESuppliesService;
            _allergyService = allergyService;
            _facilityLocation = facilityLocation;
            _reportService = reportService;
        }
        #region Patient Summary
        public async Task<IActionResult> PatientSummary2(long? Id)
        {

            var PermisionPageList = await _userRolePageService.GetSideBarList(1);
            _sessionManager.SetPermisionPage(PermisionPageList);
            ViewBag.PatientSummary = "nav-active";
            PatientViewModel patientViewModel = new PatientViewModel();
            var userId = (long?)_sessionManager.GetUserId();
            var VisitId = (Int32)_sessionManager.GetVisitId();
            if (Id is null)
            {
                var patientInfos = new PatientInfoListDto();
                patientViewModel.patientListWithUsers = new List<PatientInfoListDto>();
                patientViewModel.patientCompleteInfo = patientInfos;
                patientViewModel.VitalDto = new VitalDto();
                return View(patientViewModel);
            }
            else
            {
                _sessionManager.SetPatientInfoId(Id.Value);
                var VisitDate = await _patientInfoService.GetPatientLatestVisitDate((long)Id);
                var ExamDate = await _patientInfoService.GetPatientLatestExamDate((long)Id);
                if (!(VisitDate is null))
                {
                    var Date = VisitDate.Split(' ');
                    ViewBag.VisitDate = Date[0];

                }
                else
                {
                    ViewBag.VisitDate = "N/A";
                }
                if (!(ExamDate is null))
                {
                    var Date = ExamDate.Split(' ');
                    ViewBag.ExamDate = Date[0];

                }
                else
                {
                    ViewBag.ExamDate = "N/A";
                }
                var patientInfos = await _patientInfoService.GetPatientSummaryDetails((long)Id);
                var patientName = _patientInfoService.GetPatientName((long)Id);

                _sessionManager.SetPatientName(patientName.UserName);
                _sessionManager.SetPatientDOB(patientInfos.DateOfBirth);
                if (patientInfos.DateOfBirth != null)
                {
                    var result = DateTime.Parse(patientInfos.DateOfBirth.ToString(), new CultureInfo("en-US")).Year;
                    var age = DateTime.Today.Year - result;
                    patientInfos.Age = age;
                }

                patientViewModel.patientListWithUsers = await _patientInfoService.GetRelevantPatientDetails(patientInfos.HomePhone, patientInfos.AddressLine1, patientInfos.EmergencyMobileNumber, patientInfos.EmergencyPerson, patientInfos.AdjusterName);
                if (patientViewModel.patientListWithUsers != null)
                {
                    foreach (var item in patientViewModel.patientListWithUsers)
                    {
                        var result = DateTime.Parse(item.DateOfBirth.ToString(), new CultureInfo("en-US")).Year;
                        var age = DateTime.Today.Year - result;
                        item.Age = age;
                    }
                }
                patientViewModel.VitalDto = _patientVitalService.GetVitalSummaryByPatientInfoId(Id.Value);
                patientViewModel.PatientMissingsListDto = await _patientMissingService.GetPatientInfoMissingFieldsByPatientId(Id.Value);
                //In Order to get settings details i.e for display and printing
                patientViewModel.PatientSettingDto = _patientSettings.getPatientSettingsById((int)userId);
                patientViewModel.PatientPrintSettingDto = _patientSettings.getPatientPrintSettingsById((int)userId);

                //patientViewModel.NotificationDto = await _patientMissingService.GetPatientInfoMissingFieldsByPatientIdForNotification(Id.Value);

                patientViewModel.patientCompleteInfo = patientInfos;
                return View(patientViewModel);
            }
        }
        public async Task<IActionResult> getSummary(long patientId)
        {
            PatientViewModel patientViewModel = new PatientViewModel();
            var patientInfos = await _patientInfoService.GetPatientSummaryDetails(patientId);

            if (patientInfos.DateOfBirth != null)
            {
                var result = DateTime.Parse(patientInfos.DateOfBirth.ToString(), new CultureInfo("en-US")).Year;
                var age = DateTime.Today.Year - result;
                patientInfos.Age = age;
            }
            patientViewModel.patientCompleteInfo = patientInfos;
            patientViewModel.PatientSettingDto = _patientSettings.getPatientSettingsById((int)patientId);
            patientViewModel.PatientPrintSettingDto = _patientSettings.getPatientPrintSettingsById((int)patientId);

            return PartialView("~/Views/PatientSideElite/_PatientPartialView/_patientSummary.cshtml", patientViewModel);
        }

        #endregion Patient Summary

      
      
        #region Claim Info
        public async Task<IActionResult> ClaimInfoListElite()
        {
            PatientViewModel patientViewModel = new PatientViewModel();
            var PatientName = _sessionManager.GetPatientInfoId();
            var ROleId = _sessionManager.GetRoleId();
            if (ROleId == 5)
            {
                patientViewModel.patientClaimInfoList = await _patientClaimInfoService.AllClaimInfoList();
            }
            else
            {
                patientViewModel.patientClaimInfoList = await _patientClaimInfoService.ClaimInfoList(PatientName);

            }

            return View(patientViewModel);
        }
        
        [HttpPost]
        public async Task<IActionResult> ClaimInfoListElite(PatientViewModel patientViewModel)
        {
            await _patientInfoService.AddEmail(patientViewModel.ClaimEmailDto);
            _patientInfoService.EmployeeVerificationEmail(patientViewModel.ClaimEmailDto.SendTo, patientViewModel.ClaimEmailDto.Subject, patientViewModel.ClaimEmailDto.Message);

            return Redirect("ClaimInfoListElite");
        }
        public async Task<IActionResult> AddClaimInfoElite(int? Id)
        {
            PatientViewModel patientViewModel = new PatientViewModel();
            var data = await _patientInfoService.GetPatientDropDownData();
           
            if (Id>0)
            {
                patientViewModel.patientClaimInfo = await _patientClaimInfoService.ClaimInfoGetById((int)Id);
               
            }
           
            patientViewModel.patientListWithUsers = await _patientInfoService.GetPatientListWithDetails();

            patientViewModel.ClaimStatusList = data.ClaimStatusList;
            patientViewModel.Nf2list = data.Nf2list;
            patientViewModel.IncidentReportStatusList = data.IncidentReportStatusList;
            patientViewModel.IncidentList = data.IncidentList;
            var AttorneyNameList = await _legalInfoAttorneyNameService.LegalInfoAttorneyList();
            patientViewModel.legalInfoAttorneyNameList = AttorneyNameList.Data;

            return View(patientViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> AddClaimInfoElite(PatientViewModel patientViewModel)
        {
            var ROleId = _sessionManager.GetRoleId();
           
            if (patientViewModel.patientClaimInfo.PatientClaimID > 0)
            {
                patientViewModel.patientClaimInfo.IsActive = true;
                patientViewModel.patientClaimInfo.UserId = _sessionManager.GetUserId();
                if (ROleId == 1)
                {
                    patientViewModel.patientClaimInfo.PatientInfo = _sessionManager.GetPatientInfoId();

                }
                ViewBag.BtnSubmit = "Save";
                var Update = await _patientClaimInfoService.patientClaimInfoUpdate(patientViewModel.patientClaimInfo);
            }
            else
            {
                ViewBag.BtnSubmit = "Save";
                patientViewModel.patientClaimInfo.UserId = _sessionManager.GetUserId();
                if (ROleId == 1)
                {
                    patientViewModel.patientClaimInfo.PatientInfo = _sessionManager.GetPatientInfoId();

                }
               
                patientViewModel.patientClaimInfo.IsActive =true;

                var infocre = await _patientClaimInfoService.patientClaimInfo(patientViewModel.patientClaimInfo);
            }
            var data = "Success full";
            return Json(data);
        }
        
        public async Task<IActionResult> AddClaimVisit(int? visitid,int? Id)
        {

            if(!(Id is null))
            {
                ViewBag.PatientId = Id;
            }
            else
            {
                ViewBag.PatientId = 0;
            }
            ReportsViewModel reportsViewModel = new ReportsViewModel();
            var data = await _patientInfoService.GetPatientDropDownData();


            reportsViewModel.ClaimStatusList = data.ClaimStatusList;
            reportsViewModel.Nf2list = data.Nf2list;
            reportsViewModel.IncidentReportStatusList = data.IncidentReportStatusList;
            reportsViewModel.IncidentList = data.IncidentList;
            var AttorneyNameList = await _legalInfoAttorneyNameService.LegalInfoAttorneyList();
            reportsViewModel.legalInfoAttorneyNameList = AttorneyNameList.Data;
            reportsViewModel.patientListWithUsers = await _patientInfoService.GetPatientListWithDetails();
            reportsViewModel.DropDownListForInuranceCompanies = _patientInfoService.DropDownListInsuranceCompanies();
            return View(reportsViewModel);
        }

        public async Task<IActionResult> ClaimListForReceptionist(long Id)
        {
            PatientViewModel patientViewModel = new PatientViewModel();

            patientViewModel.patientClaimInfoList = await _patientClaimInfoService.ClaimInfoList(Id);

            return View(patientViewModel);
        }
        public IActionResult ClaimDelete(int Id)
        {
            var PatById = _patientClaimInfoService.ClaimDelete(Id);
            //return RedirectToAction("PatientList", "PatientSide");
            return Json(PatById);
        }
        #endregion
        public IActionResult ClaimsElite()
        {
            return View();
        }
        public IActionResult CareGiver()
        {
            return View();
        }
        public IActionResult PatientDocumentElite()
        {
            return View();
        }
        public IActionResult ClinicalNotesElite()
        {
            return View();
        }
        public IActionResult ClinicalReminderElite()
        {
            return View();
        }
        public async Task<IActionResult> currentlocationinfacilityElite(long? Id)
        {

            var PatientId = _sessionManager.GetPatientInfoId();
            var ListOfLocations = await _facilityLocation.GetListLocationByPatientId(PatientId);
            

            return View(ListOfLocations);
        }
        public IActionResult DMEsuppliesElite()
        {
            return View();
        }
        public IActionResult PatientClaimsElite()
        {
            return View();
        }
        public IActionResult EUOElite()
        {
            return View();
        }
        public async Task<IActionResult> PatientClaimsExamsElite()
        {
            var patientId = _sessionManager.GetPatientInfoId();
            var list = await _reportService.GetReportInfoList(patientId);
            return View(list);
        }

        public async Task<IActionResult> ExamVisitDetail(int Id)
        {
            var response = await _reportService.GetExamInformationById(Id);
            var data = response.Data;
            return PartialView("~/Views/PatientSideElite/_ExamsElitePartial/_ExamDetailsView.cshtml", data);

        }

        [HttpPost]
        public async Task<IActionResult> DeleteExamInformation(int? Id)
        {
            var result = await _reportService.DeleteExamInformation((int)Id);
            var data = new { Result = result };
            return Json(data);
        }
        #region Family History
        public async Task<IActionResult> FamilyHistoryElite(int? Id)
        {
            var patientId = _sessionManager.GetPatientInfoId();
            PatientViewModel model = new PatientViewModel();
            model.GetMHFamilyHistory = await _PatientService.GetMHFamilyHistory(Convert.ToInt32(patientId));

            return View(model);
        }
        public async Task<IActionResult> AddFamilyHistoryElite(int? Id)
        {
            PatientViewModel model = new PatientViewModel();
            if (!(Id is null))
            {
                var rec = await _PatientService.mHFamilyHistoryGetId((int)Id);
                model.MHFamilyHistory = rec.Data;
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> SaveMHFamilyHistory(PatientViewModel model)
        {
            var patientId = _sessionManager.GetPatientInfoId();
            var ExistName = await _PatientService.isFamilyHistoryExistorNot(model.MHFamilyHistory.Relation, model.MHFamilyHistory.DeceasedOrDeathAge, model.MHFamilyHistory.Notes, model.MHFamilyHistory.MedicalConditionsOrCauseDeath, Convert.ToInt32(patientId));
            if (ExistName.Data)
            {
                return Json("exist");
            }

            model.MHFamilyHistory.PatientId = Convert.ToInt32(patientId);
            if (model.MHFamilyHistory.Id == 0)
            {
                var create = await _PatientService.mHFamilyHistoryCreate(model.MHFamilyHistory);

            }
            else
            {
                var update = await _PatientService.mHFamilyHistoryUpdate(model.MHFamilyHistory);

            }
            model.GetMHFamilyHistory = await _PatientService.GetMHFamilyHistory(Convert.ToInt32(patientId));
            return Json("Save SuccessFully");
        }

        public IActionResult DeleteMHFamilyHistory(int Id)
        {
            var result = _PatientService.mHFamilyHistoryDeleteById(Id);
            return Json(result);
        }
        #endregion 
        public IActionResult GrowthChartListElite()
        {
            return View();
        }
        public IActionResult HippaRelease()
        {
            return View();
        }
        public IActionResult IMEElite()
        {
            return View();
        }
        public IActionResult PatientHippaReleaseImagingElite()
        {
            return View();
        }
        public IActionResult LabsElite()
        {
            return View();
        }
        public IActionResult LegalInfoListElite()
        {
            return View();
        }
        public IActionResult PatientMedicalHistoryElite()
        {
            return View();
        }
        public IActionResult MedicationsElite()
        {
            return View();
        }

        #region Patient missing Fields
        public async Task<IActionResult> MissingElite(long Id)
        {
            PatientMissingViewModel patientMissing = new PatientMissingViewModel();
            patientMissing.PatientMissingsListDto = await _patientMissingService.GetPatientInfoMissingFieldsByPatientId(Id);

            ViewBag.Missing = "nav-active";

            return View(patientMissing);
        }
        #endregion
        public async Task<IActionResult> PrescriptionListElite()
        {
            ViewBag.Prescription = "nav-active";
            long patientId = _sessionManager.GetPatientInfoId();
            var RoleId = _sessionManager.GetRoleId();
            PatientViewModel model = new PatientViewModel();
            if (RoleId == 1)
            {
                model.prescriptionBasicsList = await _patientPrescriptionService.prescriptionListByVisits(patientId);
            }
            else
            {
                if (patientId == 0)
                {
                    var prescriptionlist = await _patientPrescriptionService.AllprescriptionList();
                    model.prescriptionBasicsList = prescriptionlist.Data;
                }
                else
                {
                    model.prescriptionBasicsList = await _patientPrescriptionService.prescriptionListByVisits(patientId);

                }

            }

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> AddPrescriptionElite(int? Id)
        {
            PatientViewModel model = new PatientViewModel();
            var dtoObj = new DMESupplieDto();
            var patientId = _sessionManager.GetPatientInfoId();
            ViewBag.Image = string.Empty;
            var patientName = _patientInfoService.GetPatientName(patientId);
            //_sessionManager.SetPatientName(patientName.UserName);
            if (!(Id is null))
            {
                ViewBag.Action = "Update";
                var res = await _patientPrescriptionService.prescriptionGetId((int)Id);
                model.dMEDto = await _patientPrescriptionService.GetDMESupplyById(Id);
                ViewBag.Image = model.dMEDto.ImageUrl;
                model.prescriptionBasicDto = res.Data;
                model.StartDate = res.Data.StartDate.ToString();
                model.EndDate = res.Data.EndDate.ToString();
            }
            else
            {
                ViewBag.Action = "Save";

            }
            model.patientListWithUsers = await _patientInfoService.GetPatientListWithDetails();

            model.MedicineList = _patientPrescriptionService.GetMedicine().Take(20);
            model.TemplateBasicList = await _templateService.ProviderTemplateList();
            dtoObj.ICDList = await _dMESuppliesService.GetAllICDCodes(true);
            dtoObj.CPTList = await _dMESuppliesService.GetAllCPTCodes();
            dtoObj.ItemList = await _dMESuppliesService.GetAllItemsGroup();
            dtoObj.PrescriberList = await _providerInfoService.GetProviderList();
            model.dMEDto = dtoObj;
            return View(model);
        }

        public async Task<IActionResult> ViewPrescription(int? Id)
        {
            PatientViewModel model = new PatientViewModel();
            var res = await _patientPrescriptionService.prescriptionGetId((int)Id);
            model.dMEDto = await _dMESuppliesService.GetDMESupplyById(2);
            model.MedicineName = _patientPrescriptionService.GetMedicineById(res.Data.MedicationId);
            model.dMeSupply = await _patientPrescriptionService.GetItemGroupById(model.dMEDto.ItemId);
            model.prescriptionBasicDto = res.Data;
            model.StartDate = res.Data.StartDate.ToString();
            model.EndDate = res.Data.EndDate.ToString();
            model.TemplateBasicList = await _templateService.ProviderTemplateList();

            var userId = _sessionManager.GetPatientInfoId();

            var MedicalProblemList = await _patientMedicalProblemService.MedicalProblemList(userId);
            model.patientMedicalProblemsList = MedicalProblemList.Data;
            model.GetMHPastDiseaseHistory = await _PatientService.GetMHPastDiseaseHistory(Convert.ToInt32(userId));
            model.GetMHPastMedicationHistory = _PatientService.GetMHPastMedicationHistory(userId);
            model.MHRecreationalDrugsHistoryList = _PatientService.GetMHRecreationalDrugsHistory(userId);
            model.GetMHExerciseHistory = await _PatientService.GetMHExerciseHistoryList(Convert.ToInt32(userId));
            model.GetMHMyPhysician = _PatientService.GetMHMyPhysiciany(userId);
            model.GetMHSurgicalHistory = _PatientService.GetMHSurgicalHistory(userId);
            model.GetMHDetailPregnancyHistory = await _PatientService.GetMHDetailPregnanciesHistory(Convert.ToInt32(userId));
            model.GetMHAllergiesHistory = await _PatientService.GetMHAllergiesHistory(Convert.ToInt32(userId));
            model.GetMHPharmacyInfo = await _PatientService.GetMHPharmacyInfoHistory(Convert.ToInt32(userId));
            model.GetMHFamilyHistory = await _PatientService.GetMHFamilyHistory(Convert.ToInt32(userId));
            return View(model);
        }

        public async Task<IActionResult> PatientChart(int patientId) 
        {
            PatientViewModel model = new PatientViewModel();
           // var patientId = _sessionManager.GetPatientInfoId();
            var MedicalProblemList = await _patientMedicalProblemService.MedicalProblemList(patientId);
            model.patientMedicalProblemsList = MedicalProblemList.Data;
            model.GetMHPastDiseaseHistory = await _PatientService.GetMHPastDiseaseHistory(Convert.ToInt32(patientId));
            model.GetMHPastMedicationHistory = _PatientService.GetMHPastMedicationHistory(patientId);
            model.MHRecreationalDrugsHistoryList = _PatientService.GetMHRecreationalDrugsHistory(patientId);
            model.GetMHExerciseHistory = await _PatientService.GetMHExerciseHistoryList(Convert.ToInt32(patientId));
            model.GetMHMyPhysician = _PatientService.GetMHMyPhysiciany(patientId);
            model.GetMHSurgicalHistory = _PatientService.GetMHSurgicalHistory(patientId);
            model.GetMHDetailPregnancyHistory = await _PatientService.GetMHDetailPregnanciesHistory(Convert.ToInt32(patientId));
            model.GetMHAllergiesHistory = await _PatientService.GetMHAllergiesHistory(Convert.ToInt32(patientId));
            model.GetMHPharmacyInfo = await _PatientService.GetMHPharmacyInfoHistory(Convert.ToInt32(patientId));
            model.GetMHFamilyHistory = await _PatientService.GetMHFamilyHistory(Convert.ToInt32(patientId));

            model.AlergyList = await _allergyService.GetAllergyList();
            model.AlergyTypeList = await _allergyService.GetAllergyTypeList();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddPrescription(PatientViewModel patientViewModel)
        {

            try
            {
                DateTime sDate;
                DateTime eDate;
                if (patientViewModel.prescriptionBasicDto.Id == 0)
                {
                    CultureInfo provider = CultureInfo.InvariantCulture;
                    sDate = DateTime.ParseExact(patientViewModel.StartDate, "mm/dd/yyyy", provider);
                    eDate = DateTime.ParseExact(patientViewModel.EndDate, "mm/dd/yyyy", provider);
                }
                else
                {
                    sDate = Convert.ToDateTime(patientViewModel.StartDate);
                    eDate = Convert.ToDateTime(patientViewModel.StartDate);
                }
                var patientId = _sessionManager.GetPatientInfoId();
                var RoleId = _sessionManager.GetRoleId();
                var VisitId = _sessionManager.GetVisitId();
                patientViewModel.prescriptionBasicDto.StartDate = sDate;
                patientViewModel.prescriptionBasicDto.EndDate = eDate;
                
                if (patientViewModel.prescriptionBasicDto.Id > 0)
                {
                    var exist = await _patientPrescriptionService.isUpdatePrescriptionExistorNot(patientViewModel.prescriptionBasicDto.Id, patientViewModel.prescriptionBasicDto.MedicationId, patientId);
                    if (exist.Data)
                    {
                        return Json("exist");
                    }
                    else
                    {
                        await _patientPrescriptionService.prescriptionUpdate(patientViewModel.prescriptionBasicDto);
                    }
                }
                else
                {
                    if (RoleId == 1)
                    {
                        patientViewModel.prescriptionBasicDto.PatientInfoId = patientId;

                    }
                    var exist = await _patientPrescriptionService.isPrescriptionExistorNot(patientViewModel.prescriptionBasicDto.MedicationId, patientId);
                    if (exist.Data)
                    {
                        return Json("exist");
                    }
                    else
                    {
                        patientViewModel.prescriptionBasicDto.VisitId = VisitId;
                        await _patientPrescriptionService.prescriptionCreate(patientViewModel.prescriptionBasicDto);

                    }
                }
                return Json("Save Successfully");
            }
            catch (Exception ex) {
                throw ex;
            }


            }

        [HttpPost]
        public async Task<IActionResult> DMESuppliesEdit(DMESupplieDto dMESupplieDto)
        {
            var patientId = _sessionManager.GetPatientInfoId();
            var loginUserId = _sessionManager.GetUserId();
            var prescriberId = _sessionManager.GetProviderInfoId();
            var fileName = string.Empty;
            var files = Request.Form.Files;

            if (files.Count > 0)
            {
                foreach (IFormFile source in files)
                {
                    fileName = ContentDispositionHeaderValue.Parse(source.ContentDisposition).FileName.Trim('"');
                    fileName = "DME" + Path.GetFileName(fileName);
                    string extension = Path.GetExtension(fileName);

                    using (FileStream output = System.IO.File.Create(this.GetFullPath(fileName)))
                        await source.CopyToAsync(output);
                }
            }
            else
            {
                fileName = dMESupplieDto.ImageUrlHidden;
            }
            dMESupplieDto.IsActive = true;
            //dMESupplieDto.PrescriptionDate = DateTime.Now;
            dMESupplieDto.PatientId = patientId;
            dMESupplieDto.UserId = loginUserId;
            dMESupplieDto.ImageUrl = fileName;
            dMESupplieDto.PrescriberId = prescriberId;

            if (dMESupplieDto.DMEEquipSupId > 0)
            {
                _dMESuppliesService.UpdateDMESupplyEquipment(dMESupplieDto);
            }
            else
            {
                _dMESuppliesService.SaveDMESupplyEquipment(dMESupplieDto);
            }
            return RedirectToAction("DMESuppliesElite");
        }
        public IActionResult ReminderListElite()
        {
            return View();
        }
        public IActionResult MessageListElite()
        {
            return View();
        }
        #region Patient Vital
        public async Task<IActionResult> VitalElite(long? Id)
        {
            PatientViewModel patientViewModel = new PatientViewModel();
            var roleId = _sessionManager.GetRoleId();

            //_sessionManager.SetPatientInfoId(Id.Value);
            patientViewModel.Vitallist = await _patientVitalService.GetVitalListByVisits((long)Id);
            //if (roleId == 5 || roleId == 2)
            //{
            //    patientViewModel.Vitallist = _patientVitalService.GetAllVital();
            //}
            //else
            //{
            //    if (Id != null)
            //    {
            //        patientViewModel.Vitallist = _patientVitalService.GetAllVitalByPatientInfoId(Id.Value);

            //    }
            //    else {
            //        patientViewModel.Vitallist = new List<VitalDto>();

            //    }
            //}
            foreach (var item in patientViewModel.Vitallist)
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
            ViewBag.VITALS = "nav-active";

            return View(patientViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> AddVitalsElite(int? patientVitalId, string actionType)
        {
            PatientViewModel viewModel = new PatientViewModel();
            if (!(patientVitalId is null))
            {
                viewModel.VitalDto = _patientVitalService.GetVitalById(patientVitalId.Value);
                if (viewModel.VitalDto != null && actionType.Equals("view"))
                {
                    if (patientVitalId == 0 && actionType.Equals("view"))
                    {
                        viewModel.VitalDto.IsDisableFields = false;
                    }
                    else
                    {
                        viewModel.VitalDto.IsDisableFields = true;
                    }
                }
                else
                {
                    viewModel.VitalDto.IsDisableFields = false;
                }
            }


            viewModel.ProviderList = await _providerInfoService.GetProviderList();
            //viewModel.patientExamTypeList = _patientExamService.GetExamTypelist();
            viewModel.PatientExamReasonList = _patientExamService.GetExamReasonlist();
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult AddVitalsElite(VitalDto vitalDto)
        {
            var VisitId = _sessionManager.GetVisitId();
            vitalDto.VisitId = VisitId;
            _patientVitalService.SavePatientVital(vitalDto);
            var PatientId = _sessionManager.GetPatientInfoId();
            return RedirectToAction("VitalElite","PatientSideElite",new { Id = PatientId });
        }

        public IActionResult DeleteVital(int patientVitalId)
        {
            var result = _patientVitalService.RemoveVitalById(patientVitalId);
            return Json(result);
        }

        public IActionResult ExamType(PatientViewModel patientViewModel)
        {
            var ExistName = _patientExamService.isTypeExistOrNot(patientViewModel.PatientExamTypeDto.ExamName);
            if (ExistName)
            {
                var message = new { Success = "Exam type already exist", IsError = true };
                return Json(message);
            }
            var examTypeId = _patientExamService.CreateExamType(patientViewModel.PatientExamTypeDto);
            var data = new { ExamTypeId = examTypeId, ExamName = patientViewModel.PatientExamTypeDto.ExamName };

            return Json(data);
        }

        public IActionResult ExamReason(PatientViewModel patientViewModel)
        {
            var ExistName = _patientExamService.isReasonExistOrNot(patientViewModel.PatientExamReasonDto.ReasonName);
            if (ExistName)
            {
                var message = new { Success = "Exam reason already exist", IsError = true };
                return Json(message);
            }
            var examReasonId = _patientExamService.CreateExamReason(patientViewModel.PatientExamReasonDto);
            var data = new { ExamReasonId = examReasonId, ReasonName = patientViewModel.PatientExamReasonDto.ReasonName };

            return Json(data);
        }

        #endregion Patient Vital
        public IActionResult ImmunizationElite()
        {
            return View();
        }
        public IActionResult PatientReportsElite()
        {
            return View();
        }
        public IActionResult MedicalProblemlistElite()
        {
            return View();
        }
        public IActionResult ProcedureTestsElite()
        {
            return View();
        }
        public IActionResult VisitsElite()
        {
            return View();
        }
        public IActionResult PatientBillAddElite()
        {
            return View();
        }
        public IActionResult AddClinicalNoteElite()
        {
            return View();
        }
        public IActionResult AddReminderElite()
        {
            return View();
        }
        public async Task<IActionResult> EditCurrentLocationInFacilityElite(int? Id)
        {
            var locationViewModel = new LocationFacilityViewModel();
            locationViewModel.patientListWithUsers = await _patientInfoService.GetPatientListWithDetails();
            if (Id != null)
            {
                var model = _facilityLocation.GetById(Convert.ToInt32(Id));
                
                locationViewModel.CurrentLocation = await model;
                
                



                return View(locationViewModel);
            }
            else
            {
                return View(locationViewModel);
            }
            
        }
        
        [HttpPost]
        public async Task<IActionResult> EditCurrentLocationInFacilityElite(LocationFacilityViewModel viewModel)
        {
            var VisitId = _sessionManager.GetVisitId();
            if (viewModel.CurrentLocation.CurrentLocationId > 0)
            {
                await _facilityLocation.AddUpdate(viewModel.CurrentLocation);
            }
            else
            {
                viewModel.CurrentLocation.VisitId = VisitId;
                await _facilityLocation.AddUpdate(viewModel.CurrentLocation);
            }

            var PatientId = _sessionManager.GetPatientInfoId();
            return RedirectToAction("currentlocationinfacilityElite", new { Id = PatientId });
        }

        [HttpPost]
        public async  Task<IActionResult> DeleteCurrentLocationFacility(int Id)
        {
           var result = await _facilityLocation.Delete(Id);
            var data = new { Result = result };
            return Json(data);
        }

        public IActionResult EUOFormElite()
        {
            return View();
        }
        #region Patient Info Form
        public async Task<IActionResult> PatientInfo(int? id, string clickfrom)
        {
            PatientViewModel patientViewModel = new PatientViewModel();
            patientViewModel.patientTreatmentStatuslist = new List<PatientTreatmentStatusBasicDto>();
            ViewBag.RoleId = _sessionManager.GetRoleId();

            //In Case of Edit
            if (!(id is null))
            {
                if (clickfrom is null)
                {
                    ViewBag.clickValue = string.Empty;
                }
                else if (clickfrom.Equals("Editicon"))
                {
                    ViewBag.clickValue = clickfrom;
                }


                ViewBag.BtnSubmit = "Save";
                ViewBag.Action = "Update";
                patientViewModel.patientInfoBasicDto = await _patientInfoService.GetPatientDetailInfo((int)id);
                patientViewModel.PatientInfoIdForDisplay = patientViewModel.patientInfoBasicDto.PatientInfoId;

                if (!(patientViewModel.patientInfoBasicDto.PatientLanguage is null))
                {
                    patientViewModel.patientInfoBasicDto.PatientLanguages = patientViewModel.patientInfoBasicDto.PatientLanguage.Split(",");
                }
                ViewBag.InfoId = id;
                ViewBag.Password = patientViewModel.patientInfoBasicDto.Password;
                patientViewModel.patientPhoneNumber = _patientInfoService.mappedPhoneNumber(patientViewModel.patientInfoBasicDto.PatientPhoneNumber);
                if (patientViewModel.patientPhoneNumber != null)
                {
                    if (patientViewModel.patientPhoneNumber.EmergencyPhone != null)
                    {
                        ViewBag.EmergencyPhoneContains = true;
                    }
                }

                else
                {
                    ViewBag.EmergencyPhoneContains = string.Empty;
                }
                ViewBag.color = patientViewModel.patientInfoBasicDto.PatientColor;
                patientViewModel.patientEmergencyContact = _patientInfoService.mappedEmergencyNumber(patientViewModel.patientInfoBasicDto.PatientEmergencyContact);
                patientViewModel.patientIdandSignature = _patientInfoService.mappedPatientIdSignature(patientViewModel.patientInfoBasicDto.PatientIdAndSignature);
                if (patientViewModel.patientIdandSignature is null)
                {
                    ViewBag.SignaturePassword = string.Empty;
                    ViewBag.PatientImage = string.Empty;
                    ViewBag.SignImage = string.Empty;
                    ViewBag.WriteSignature = string.Empty;

                    ViewBag.PassportContains = string.Empty;

                }

                else
                {
                    ViewBag.SignaturePassword = patientViewModel.patientIdandSignature.ElectronicSignature;
                    ViewBag.PatientImage = patientViewModel.patientIdandSignature.PaitentImage;
                    TempData["ProfileImage"] = patientViewModel.patientIdandSignature.PaitentImage;
                    ViewBag.SignImage = patientViewModel.patientIdandSignature.SignatureImage;
                    ViewBag.WriteSignature = patientViewModel.patientIdandSignature.WriteSignature;
                    if (patientViewModel.patientIdandSignature.PassportNumber != null)
                    {
                        ViewBag.PassportContains = true;
                    }

                }

                if (patientViewModel.patientInfoBasicDto.SecondaryAddress1 != null || patientViewModel.patientInfoBasicDto.SecondaryAddress2 != null || patientViewModel.patientInfoBasicDto.SecondaryAddress3 != null)
                {
                    ViewBag.SecondaryAddressContains = true;
                }
                else
                {
                    ViewBag.SecondaryAddressContains = string.Empty;
                }

                patientViewModel.patientCaseTypeBasicDto = _patientInfoService.mappedCaseType(patientViewModel.patientInfoBasicDto.PatientCaseType);
                if (patientViewModel.patientCaseTypeBasicDto != null)
                {
                    ViewBag.CaseType = patientViewModel.patientCaseTypeBasicDto.CaseTypeName;
                }
                patientViewModel.patientClaimInfo = _patientInfoService.mappedClaimInfo(patientViewModel.patientInfoBasicDto.PatientsClaimInfo);

                patientViewModel.patientSecondaryInsurance = _patientInfoService.mappedSecondaryInsurance(patientViewModel.patientInfoBasicDto.SecondaryInsurenceProvider);
                patientViewModel.PatientTertiaryInsuranceBasicDto = _patientInfoService.mappedTertiaryInsurance(patientViewModel.patientInfoBasicDto.TertiaryInsurenceProvider);
                patientViewModel.patientPersonalInjury = _patientInfoService.mappedPersonalInjury(patientViewModel.patientInfoBasicDto.PatientPersonal);
                patientViewModel.patientArbitrationAttorney = _patientInfoService.mappedArbitrationAttorney(patientViewModel.patientInfoBasicDto.PatientArbitrationAttorney);


                patientViewModel.patientVehiclesBasiclist = _patientVehicleService.getVehicleListByUserId(patientViewModel.patientInfoBasicDto.UserId);
                if (patientViewModel.patientVehiclesBasiclist != null && patientViewModel.patientVehiclesBasiclist.Count > 0)
                {
                    ViewBag.IsShowVehicleButton = false;
                }
                else
                {
                    ViewBag.IsShowVehicleButton = true;
                }
                patientViewModel.PatientInfoFormRequireSettingsDto = _patientSettings.GetPatientRequireFieldSettingsById();
            }
            // In case of new
            else
            {
                ViewBag.BtnSubmit = "Save";
                ViewBag.IsShowVehicleButton = true;
                ViewBag.Action = "Save";

                //Get Settings For PatientInfo
                patientViewModel.PatientInfoFormRequireSettingsDto = _patientSettings.GetPatientRequireFieldSettingsById();
                //For next ID
                patientViewModel.PatientInfoIdForDisplay = _patientInfoService.GetMaxPatientId();
            }

            // Dropdown Data For All 11 Forms
            var data = await _patientInfoService.GetPatientDropDownData();

            patientViewModel.EmploymentTitleList = data.EmploymentTitleList;
            patientViewModel.EmploymentStatuslist = data.EmploymentStatuslist;
            patientViewModel.ClaimStatusList = data.ClaimStatusList;
            patientViewModel.Nf2list = data.Nf2list;
            patientViewModel.IncidentReportStatusList = data.IncidentReportStatusList;
            patientViewModel.IncidentList = data.IncidentList;
            patientViewModel.prefixs = data.prefixs;
            patientViewModel.suffix = data.suffix;
            patientViewModel.gender = data.gender;
            ViewBag.Gender = data.gender;
            patientViewModel.maritalStatus = data.maritalStatus;
            patientViewModel.RaceEthnicity = data.RaceEthnicity;
            patientViewModel.RelationShip = data.RelationShip;
            patientViewModel.patientTreatmentStatuslist = data.patientTreatmentStatuslist;
            patientViewModel.patientLegalStatusBasicDtoslist = data.patientLegalStatusBasicDtoslist;
            if (data.legalInfoLegalStatusList == null)
            {
                patientViewModel.legalInfoLegalStatusList = new List<Models.DTOs.LegalInfolegealStatusDto.legalInfoLegalBasicDto>();
            }
            else
            {
                patientViewModel.legalInfoLegalStatusList = data.legalInfoLegalStatusList;
            }

            var Leadingattorney = await _legalInfoLeadingAttorney.LegalInfoAttorneyNameList();
            patientViewModel.legalInfoLeadingAttorneysList = Leadingattorney.Data;
            var leadingparalegal = await _legalInfoLeadingParalegalService.LeadingParaLegalNameList();
            patientViewModel.LegalInfoLeadingParalegallist = leadingparalegal.Data;
            var FirmList = await _legalInfoFirmNameService.LegalInfoFirmNameList();
            patientViewModel.legalInfoFirmNameList = FirmList.Data;
            var AttorneyNameList = await _legalInfoAttorneyNameService.LegalInfoAttorneyList();
            patientViewModel.legalInfoAttorneyNameList = AttorneyNameList.Data;
            var Providerlist = await _insuranceProviderNameService.InsuranceProviderNameList();
            patientViewModel.InsuranceProviderNamesList = Providerlist.Data;
            var patientRelationlist = await _patientRelationship.patientRelationship();
            patientViewModel.PatientRelationshipList = patientRelationlist.Data;
            ViewBag.ProviderName = JsonSerializer.Serialize(Providerlist.Data);
            var Grouplist = await _insuranceGroupNumberService.InsuranceGroupNumberList();
            patientViewModel.InsuranceGroupNumbersList = Grouplist.Data;
            patientViewModel.PatientSignatureIdTypeList = data.PatientSignatureIdTypeList;
            patientViewModel.patientLanguageList = data.patientLanguageList;

            return View(patientViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> PatientInfo(PatientViewModel patientViewModel, string[] language)
        {
            // For Save patient form
            if (patientViewModel.patientInfoBasicDto.PatientInfoId > 0)
            {
                var isExistdata = await _authService.CheckEmailExistOrNot(patientViewModel.patientInfoBasicDto.Email, patientViewModel.patientInfoBasicDto.UserId, patientViewModel.patientInfoBasicDto.UserName);
                if (isExistdata.Data)
                {
                    var message = new { Success = isExistdata.Message, IsError = true };
                    return Json(message);
                }

                //patientViewModel.patientInfoBasicDto.Language = MergeLanguages;
                var PIupdate = await _patientInfoService.patientInfoUpdate(patientViewModel.patientInfoBasicDto, language);

                //var userUpdate = await _userService.userInfoUpdate(patientViewModel.User);
                var data = new { Success = "Data updated successfully" };
                return Json(data);
            }
            // Update
            else
            {
                if (patientViewModel.User.UserId == 0)
                {
                    var isExistdata = await _authService.CheckEmailExistOrNot(patientViewModel.patientInfoBasicDto.Email, null, patientViewModel.patientInfoBasicDto.UserName);
                    if (isExistdata.Data)
                    {
                        var message = new { Success = isExistdata.Message, IsError = true };
                        return Json(message);
                    }
                    patientViewModel.User.RoleTypeId = 1;

                    patientViewModel.User.Password = patientViewModel.patientInfoBasicDto.Password;
                    patientViewModel.User.Email = patientViewModel.patientInfoBasicDto.Email;
                    patientViewModel.User.UserName = patientViewModel.patientInfoBasicDto.UserName;

                    var userforce = await _userService.userInfoCreate(patientViewModel.User);
                    patientViewModel.patientInfoBasicDto.UserId = userforce.Data.UserId;

                    _sessionManager.SetPatientUserId(userforce.Data.UserId);
                }
                else
                {
                    patientViewModel.patientInfoBasicDto.UserId = patientViewModel.User.UserId;
                }

                //var MergeLanguages = string.Join(",", language);
                //patientViewModel.patientInfoBasicDto.Language = MergeLanguages;
                var patientAdded = await _patientInfoService.patientInfoCreate(patientViewModel.patientInfoBasicDto, language);
                var patientInfoId = patientAdded.Data.PatientInfoId;
                CommonMethod.VerificationEmail(patientViewModel.patientInfoBasicDto.Email, patientInfoId);
                var data = new { PatientUserId = patientViewModel.patientInfoBasicDto.UserId, PatientInfoId = patientInfoId, Success = "Data saved successfully" };
                return Json(data);
            }

        }
        #endregion

        #region Patient Phone Number
        [HttpPost]
        public async Task<IActionResult> PatientPhoneNumber(PatientViewModel patientViewModel)
        {

            if (patientViewModel.patientPhoneNumber.PhoneNumberId > 0)
            {
                ViewBag.BtnSubmit = "Save";
                var PhonumberUpdate = await _patientPhoneNumberService.CreatePatientPhoneUpdate(patientViewModel.patientPhoneNumber);
            }
            else
            {
                ViewBag.BtnSubmit = "Save";
                var userId = _sessionManager.GetPatientUserId();

                if (patientViewModel.patientPhoneNumber.UserId == 0)
                {
                    if (!(patientViewModel.patientInfoBasicDto.UserId is 0))
                    {
                        patientViewModel.patientPhoneNumber.UserId = patientViewModel.patientInfoBasicDto.UserId;
                    }
                    else if (userId == 0)
                    {
                        var returnObj = new { IsError = true };
                        return Json(returnObj);
                    }
                    else
                    {
                        patientViewModel.patientPhoneNumber.UserId = userId;
                    }

                }

                var PhonumberCreate = await _patientPhoneNumberService.CreatePatientPhoneNumber(patientViewModel.patientPhoneNumber);
            }
            var obj = new { UserId = patientViewModel.patientPhoneNumber.UserId, PhoneId = patientViewModel.patientPhoneNumber.PhoneNumberId };
            return Json(obj);
        }

        #endregion Patient Phone Number

        #region Patient Emergency Contact
        [HttpPost]
        public async Task<IActionResult> PatientEmergencyContact(PatientViewModel patientViewModel)
        {
            //if (patientViewModel.User.UserId == 0)
            //{
            //    patientViewModel.User.RoleTypeId = 1;
            //    var userforce = await _userService.userInfoCreate(patientViewModel.User);
            //    patientViewModel.patientEmergencyContact.UserId = userforce.Data.UserId;
            //}
            //else
            //{
            //    var userUpdate = await _userService.userInfoUpdate(patientViewModel.User);

            //    patientViewModel.patientEmergencyContact.UserId = patientViewModel.User.UserId;
            //}

            if (patientViewModel.patientEmergencyContact.EmergencyContactID > 0)
            {
                ViewBag.BtnSubmit = "Save";
                var PhonumberCreate = await _patientEmergencyContactService.PatientEmergencyContactUpdate(patientViewModel.patientEmergencyContact);
            }
            else
            {
                ViewBag.BtnSubmit = "Save";
                var userId = _sessionManager.GetPatientUserId();

                if (patientViewModel.patientEmergencyContact.UserId == 0)
                {
                    if (!(patientViewModel.patientInfoBasicDto.UserId is 0))
                    {
                        patientViewModel.patientEmergencyContact.UserId = patientViewModel.patientInfoBasicDto.UserId;
                    }
                    else if (userId == 0)
                    {
                        var returnObj = new { IsError = true };
                        return Json(returnObj);
                    }
                    else
                    {
                        patientViewModel.patientEmergencyContact.UserId = userId;
                    }

                }
                var PhonumberCreate = await _patientEmergencyContactService.PatientEmergencyContact(patientViewModel.patientEmergencyContact);
                var RelationshipList = await _lookupService.LookupDtolist("RelationShip");
                patientViewModel.RelationShip = RelationshipList.Data;
            }


            return Json(patientViewModel);
        }

        #endregion Patient Emergency Contact

        #region Patient Signature and Id
        [HttpPost]
        public async Task<IActionResult> PatientIdandSignature(PatientViewModel patientViewModel, string Signature, string profileImage)
        {
            try
            {
                if (patientViewModel.patientIdandSignature.PatientSignatureId > 0)
                {
                    var UpdateProfile = TempData["ProfileImage"];
                    ViewBag.BtnSubmit = "Save";
                    if (profileImage == "/images/" + UpdateProfile)
                    {
                        patientViewModel.patientIdandSignature.PaitentImage = patientViewModel.patientIdandSignature.HiddenimagePath;
                    }
                    else if (profileImage == "/app-assets/images/user/male-user.png")
                    {
                        patientViewModel.patientIdandSignature.PaitentImage = null;
                    }
                    else
                    {
                        string pic = "data:image/png;base64,";
                        profileImage = profileImage.Replace(pic, "");
                        byte[] Picbytes = Convert.FromBase64String(profileImage);
                        Image image_profile;
                        using (MemoryStream pic_ms = new MemoryStream(Picbytes))
                        {
                            image_profile = Image.FromStream(pic_ms);
                        }
                        MemoryStream pic_memStream = new MemoryStream();
                        image_profile.Save(pic_memStream, ImageFormat.Png);
                        pic_memStream.Seek(0, SeekOrigin.Begin);
                        var ProfileImageFile = DateTime.UtcNow.ToString("ddMMyyyyhhmmss");
                        ProfileImageFile = System.IO.Path.GetFileName(ProfileImageFile) + ".png";
                        var ProfileImageFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images", ProfileImageFile);
                        using (var fileSteam = new FileStream(ProfileImageFilePath, FileMode.Create))
                        {
                            await pic_memStream.CopyToAsync(fileSteam);
                        }
                        patientViewModel.patientIdandSignature.PaitentImage = ProfileImageFile;
                        pic_memStream.Close();
                    }

                    if (Signature is null)
                    {
                        patientViewModel.patientIdandSignature.WriteSignature = patientViewModel.patientIdandSignature.HidddentWriteSigniamge;
                    }
                    else
                    {
                        string x = "data:image/png;base64,";
                        Signature = Signature.Replace(x, "");
                        byte[] bytes = Convert.FromBase64String(Signature);
                        Image image;
                        using (MemoryStream ms = new MemoryStream(bytes))
                        {
                            image = Image.FromStream(ms);
                        }
                        MemoryStream memStream = new MemoryStream();
                        image.Save(memStream, ImageFormat.Png);
                        memStream.Seek(0, SeekOrigin.Begin);
                        var Signfilename = DateTime.UtcNow.ToString("ddMMyyyyhhmmss");
                        Signfilename = System.IO.Path.GetFileName(Signfilename) + ".png";
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\SignatureImages", Signfilename);
                        using (var fileSteam = new FileStream(filePath, FileMode.Create))
                        {
                            await memStream.CopyToAsync(fileSteam);
                        }
                        patientViewModel.patientIdandSignature.WriteSignature = Signfilename;
                        memStream.Close();
                    }

                    var files = Request.Form.Files;
                    if (files.Count > 0)
                    {
                        string filename = "";
                        string Signfile = "";
                        string patientfile = "";
                        foreach (IFormFile source in files)
                        {
                            var ControlName = source.Name;
                            filename = ContentDispositionHeaderValue.Parse(source.ContentDisposition).FileName.Trim('"');
                            filename = DateTime.UtcNow.ToString("ddMMyyyyhhmmss") + "_" + System.IO.Path.GetFileName(filename);
                            string extension = System.IO.Path.GetExtension(filename);

                            using (FileStream output = System.IO.File.Create(this.GetSignFullPath(filename)))
                                await source.CopyToAsync(output);
                            if (ControlName == "patientIdandSignature.WriteSignature")
                            {
                                Signfile = filename;
                                if (patientViewModel.patientIdandSignature.HidddentWriteSigniamge is null)
                                {
                                    patientViewModel.patientIdandSignature.WriteSignature = patientViewModel.patientIdandSignature.HiddenimagePath;
                                }
                            }
                            if (ControlName == "patientIdandSignature.PaitentImage")
                            {
                                patientfile = filename;
                                if (patientViewModel.patientIdandSignature.HiddenimagePath is null)
                                {
                                    patientViewModel.patientIdandSignature.SignatureImage = patientViewModel.patientIdandSignature.HiddenSignImg;
                                }
                            }
                            if(ControlName== "patientIdandSignature.FrontPicture")
                            {
                                
                                patientViewModel.patientIdandSignature.IdFrontPictureUrl = filename;
                            }
                            if (ControlName == "patientIdandSignature.BackPicture")
                            {
                                
                                patientViewModel.patientIdandSignature.IdBackPictureUrl = filename;
                            }
                        };
                        if (!string.IsNullOrEmpty(patientfile))
                        {

                            patientViewModel.patientIdandSignature.PaitentImage = patientfile;

                        }

                        if (!string.IsNullOrEmpty(Signfile))
                        {

                            patientViewModel.patientIdandSignature.WriteSignature = Signfile;

                        }

                    }

                    else if (files.Count == 0)
                    {

                        patientViewModel.patientIdandSignature.SignatureImage = patientViewModel.patientIdandSignature.HiddenSignImg;

                    }
                    var update = _patientIdandSignatureService.patientIdandSignatureUpdate(patientViewModel.patientIdandSignature);
                }
                else
                {
                    ViewBag.BtnSubmit = "Save";
                    var userId = _sessionManager.GetPatientUserId();
                    ViewBag.PatientId = _sessionManager.GetPatientUserId();
                    if (patientViewModel.patientIdandSignature.UserId == 0)
                    {
                        if (!(patientViewModel.patientInfoBasicDto.UserId is 0))
                        {
                            patientViewModel.patientIdandSignature.UserId = patientViewModel.patientInfoBasicDto.UserId;
                        }
                        else if (userId == 0)
                        {
                            var returnObj = new { IsError = true };
                            return Json(returnObj);
                        }
                        else
                        {
                            patientViewModel.patientIdandSignature.UserId = userId;

                        }
                    }
                    if (profileImage == "/app-assets/images/user/male-user.png")
                    {
                        patientViewModel.patientIdandSignature.PaitentImage = patientViewModel.patientIdandSignature.HiddenimagePath;
                    }
                    else
                    {
                        string pic = "data:image/png;base64,";
                        profileImage = profileImage.Replace(pic, "");
                        byte[] Picbytes = Convert.FromBase64String(profileImage);
                        Image image_profile;
                        using (MemoryStream pic_ms = new MemoryStream(Picbytes))
                        {
                            image_profile = Image.FromStream(pic_ms);
                        }
                        MemoryStream pic_memStream = new MemoryStream();
                        image_profile.Save(pic_memStream, ImageFormat.Png);
                        pic_memStream.Seek(0, SeekOrigin.Begin);
                        var ProfileImageFile = DateTime.UtcNow.ToString("ddMMyyyyhhmmss");
                        ProfileImageFile = System.IO.Path.GetFileName(ProfileImageFile) + ".png";
                        var ProfileImageFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images", ProfileImageFile);
                        using (var fileSteam = new FileStream(ProfileImageFilePath, FileMode.Create))
                        {
                            await pic_memStream.CopyToAsync(fileSteam);
                        }
                        patientViewModel.patientIdandSignature.PaitentImage = ProfileImageFile;
                        pic_memStream.Close();
                    }

                    if (Signature is null)
                    {

                        var Signfilenames = "Empty.png";

                        patientViewModel.patientIdandSignature.WriteSignature = Signfilenames;

                    }
                    else
                    {
                        string x = "data:image/png;base64,";
                        Signature = Signature.Replace(x, "");
                        byte[] bytes = Convert.FromBase64String(Signature);
                        Image image;
                        using (MemoryStream ms = new MemoryStream(bytes))
                        {
                            image = Image.FromStream(ms);
                        }
                        MemoryStream memStream = new MemoryStream();
                        image.Save(memStream, ImageFormat.Png);
                        memStream.Seek(0, SeekOrigin.Begin);
                        var Signfilename = DateTime.UtcNow.ToString("ddMMyyyyhhmmss");
                        Signfilename = System.IO.Path.GetFileName(Signfilename) + ".png";
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\SignatureImages", Signfilename);
                        using (var fileSteam = new FileStream(filePath, FileMode.Create))
                        {
                            await memStream.CopyToAsync(fileSteam);
                        }
                        patientViewModel.patientIdandSignature.WriteSignature = Signfilename;
                        memStream.Close();
                    }

                    var files = Request.Form.Files;
                    if (files.Count > 0)
                    {
                        string filename = "";
                        string Signfile = "";
                        string patientfile = "";
                        string fronImage = "";
                        string backImage = "";
                        foreach (IFormFile source in files)
                        {
                            var ControlName = source.Name;
                            filename = ContentDispositionHeaderValue.Parse(source.ContentDisposition).FileName.Trim('"');
                            filename = DateTime.UtcNow.ToString("ddMMyyyyhhmmss") + "_" + System.IO.Path.GetFileName(filename);
                            string extension = System.IO.Path.GetExtension(filename);

                            using (FileStream output = System.IO.File.Create(this.GetFullPath(filename)))
                                await source.CopyToAsync(output);
                            if (ControlName == "patientIdandSignature.SignatureImage")
                            {
                                Signfile = filename;
                            }
                            if (ControlName == "patientIdandSignature.PaitentImage")
                            {
                                patientfile = filename;
                            }
                            if (ControlName == "patientIdandSignature.FrontPicture")
                            {
                                fronImage = filename;
                                
                            }
                            if (ControlName == "patientIdandSignature.BackPicture")
                            {
                                backImage = filename;
                               
                            }
                        };
                        if (!string.IsNullOrEmpty(patientfile))
                        {

                            patientViewModel.patientIdandSignature.PaitentImage = patientfile;

                        }

                        if (!string.IsNullOrEmpty(Signfile))
                        {

                            patientViewModel.patientIdandSignature.SignatureImage = Signfile;

                        }
                        if (!string.IsNullOrEmpty(fronImage))
                        {

                            patientViewModel.patientIdandSignature.IdFrontPictureUrl = fronImage;

                        }
                        if (!string.IsNullOrEmpty(backImage))
                        {

                            patientViewModel.patientIdandSignature.IdBackPictureUrl = backImage;

                        }
                    }

                    var create = _patientIdandSignatureService.patientIdandSignature(patientViewModel.patientIdandSignature);

                }
            }
            catch (Exception ex)
            {

                throw ex;

            }

            return Json(patientViewModel);
        }
        //For Patient Image
        private string GetFullPath(string filename)
        {
            return this._webHostEnvironment.WebRootPath + "\\images\\" + filename;
        }
        //For Patient Signature Image
        private string GetSignFullPath(string Signfilename)
        {
            return this._webHostEnvironment.WebRootPath + "\\SignatureImages\\" + Signfilename;
        }

        #endregion Patient Signature and Id

        #region Patient ClaimInfo
        [HttpPost]
        public async Task<IActionResult> PatientClaimInfo(PatientViewModel patientViewModel)
        {
            if (patientViewModel.patientClaimInfo.PatientClaimID > 0)
            {
                ViewBag.BtnSubmit = "Save";
                var data = await _patientClaimInfoService.patientClaimInfoUpdate(patientViewModel.patientClaimInfo);
            }
            else
            {
                ViewBag.BtnSubmit = "Save";
                var userId = _sessionManager.GetPatientUserId();

                if (patientViewModel.patientClaimInfo.UserId == 0)
                {
                    if (!(patientViewModel.patientInfoBasicDto.UserId is 0))
                    {
                        patientViewModel.patientClaimInfo.UserId = patientViewModel.patientInfoBasicDto.UserId;
                    }
                    else if (userId == 0)
                    {
                        var returnObj = new { IsError = true };
                        return Json(returnObj);
                    }
                    else
                    {
                        patientViewModel.patientClaimInfo.UserId = userId;
                    }
                }

                var infocre = await _patientClaimInfoService.patientClaimInfo(patientViewModel.patientClaimInfo);
            }


            return Json(patientViewModel);
        }

        #endregion Patient ClaimInfo

        #region Patient Vehicle
        [HttpPost]
        public async Task<IActionResult> PatientVehicle(PatientViewModel patientViewModel)
        {

            if (patientViewModel.patientVehiclesBasic.PatientVehicleID > 0)
            {
                ViewBag.BtnSubmit = "Save";
                var data = await _patientVehicleService.patientVehicleUpdate(patientViewModel.patientVehiclesBasiclist);
            }
            else
            {
                ViewBag.BtnSubmit = "Save";
                var userId = _sessionManager.GetPatientUserId();

                if (patientViewModel.patientVehiclesBasic.UserId == 0)
                {
                    if (!(patientViewModel.patientInfoBasicDto.UserId is 0))
                    {
                        patientViewModel.patientVehiclesBasic.UserId = patientViewModel.patientInfoBasicDto.UserId;

                        foreach (var item in patientViewModel.patientVehiclesBasiclist)
                        {
                            item.UserId = patientViewModel.patientInfoBasicDto.UserId;
                        }
                    }
                    else if (userId == 0)
                    {
                        {
                            var returnObj = new { IsError = true };
                            return Json(returnObj);
                        }
                    }
                    else
                    {
                        foreach (var item in patientViewModel.patientVehiclesBasiclist)
                        {
                            item.UserId = userId;
                        }
                    }
                }

                var infocre = _patientVehicleService.patientVehicle(patientViewModel.patientVehiclesBasiclist);
            }
            return Json(patientViewModel);

        }

        public IActionResult DeleteVehicle(long vehicleId)
        {
            var response = _patientVehicleService.deleteVehicleById(vehicleId);
            return Json(response);
        }

        #endregion Patient Vehicle

        #region Patient Secondary Insurance
        [HttpPost]
        public async Task<IActionResult> PatientSecondaryInsurance(PatientViewModel patientViewModel)
        {
            
            if (patientViewModel.patientSecondaryInsurance.SecondaryInsuranceProviderID > 0)
            {
                ViewBag.BtnSubmit = "Save";
                var data = await _patientSecondaryInsuranceService.patientSecondaryInsuranceUpdate(patientViewModel.patientSecondaryInsurance);
            }
            else
            {
                ViewBag.BtnSubmit = "Save";
                var userId = _sessionManager.GetPatientUserId();

                if (patientViewModel.patientSecondaryInsurance.UserId == 0)
                {
                    if (!(patientViewModel.patientInfoBasicDto.UserId is 0))
                    {
                        patientViewModel.patientSecondaryInsurance.UserId = patientViewModel.patientInfoBasicDto.UserId;
                    }
                    else if (userId == 0)
                    {
                        var returnObj = new { IsError = true };
                        return Json(returnObj);
                    }
                    else
                    {
                        patientViewModel.patientSecondaryInsurance.UserId = userId;
                    }
                }
                var infocre = await _patientSecondaryInsuranceService.patientSecondaryInsurance(patientViewModel.patientSecondaryInsurance);
            }

            return Json(patientViewModel);
        }
        #endregion Patient Secondary Insurance

        #region Patient Teritary Insurance
        [HttpPost]
        public async Task<IActionResult> PatientTeritaryInsurance(PatientViewModel patientViewModel)
        {
            if (patientViewModel.PatientTertiaryInsuranceBasicDto.TertiaryInsurenceProviderID > 0)
            {
                ViewBag.BtnSubmit = "Save";
                var update = await _patientTertiaryInsuranceService.patientTertiaryInsuranceUpdate(patientViewModel.PatientTertiaryInsuranceBasicDto);
            }
            else
            {
                ViewBag.BtnSubmit = "Save";
                var userId = _sessionManager.GetPatientUserId();

                if (patientViewModel.PatientTertiaryInsuranceBasicDto.UserId == 0)
                {
                    if (!(patientViewModel.patientInfoBasicDto.UserId is 0))
                    {
                        patientViewModel.PatientTertiaryInsuranceBasicDto.UserId = patientViewModel.patientInfoBasicDto.UserId;
                    }
                    else if (userId == 0)
                    {
                        var returnObj = new { IsError = true };
                        return Json(returnObj);
                    }
                    else
                    {
                        patientViewModel.PatientTertiaryInsuranceBasicDto.UserId = userId;

                    }
                }
                var infocre = await _patientTertiaryInsuranceService.patientTertiaryInsurance(patientViewModel.PatientTertiaryInsuranceBasicDto);

            }

            return Json(patientViewModel);
        }
        #endregion Patient Teritary Insurance

        #region Patient Personal Injury
        [HttpPost]
        public async Task<IActionResult> PatientPersonalInjury(PatientViewModel patientViewModel)
        {
            if (patientViewModel.patientPersonalInjury.PersonalInjuryId > 0)
            {
                ViewBag.BtnSubmit = "Save";
                var update = await _patientPersonalInjuryService.patientPersonalInjuryUpdae(patientViewModel.patientPersonalInjury);
            }
            else
            {
                ViewBag.BtnSubmit = "Save";
                var userId = _sessionManager.GetPatientUserId();

                if (patientViewModel.patientPersonalInjury.UserId == 0)
                {
                    if (!(patientViewModel.patientInfoBasicDto.UserId is 0))
                    {
                        patientViewModel.patientPersonalInjury.UserId = patientViewModel.patientInfoBasicDto.UserId;
                    }
                    else if (userId == 0)
                    {
                        var returnObj = new { IsError = true };
                        return Json(returnObj);
                    }
                    else
                    {
                        patientViewModel.patientPersonalInjury.UserId = userId;
                    }
                }
                var Create = await _patientPersonalInjuryService.patientPersonalInjury(patientViewModel.patientPersonalInjury);

            }
            return Json(patientViewModel);
        }
        #endregion Patient Personal Injury 

        #region patient Collection/Arbitration Attorney
        [HttpPost]
        public async Task<IActionResult> PatientArbitrationAttorney(PatientViewModel patientViewModel)
        {
            if (patientViewModel.patientArbitrationAttorney.ArbitrationAttorneyID > 0)
            {
                ViewBag.BtnSubmit = "Save";
                var update = await _patientArbitrationAttorneyService.patientArbitrationAttorneyUpdate(patientViewModel.patientArbitrationAttorney);
            }
            else
            {
                ViewBag.BtnSubmit = "Save";
                var userId = _sessionManager.GetPatientUserId();
                if (patientViewModel.patientArbitrationAttorney.UserId == 0)
                {
                    if (!(patientViewModel.patientInfoBasicDto.UserId is 0))
                    {
                        patientViewModel.patientArbitrationAttorney.UserId = patientViewModel.patientInfoBasicDto.UserId;
                    }
                    else if (userId == 0)
                    {
                        var returnObj = new { IsError = true };
                        return Json(returnObj);
                    }
                    else
                    {
                        patientViewModel.patientArbitrationAttorney.UserId = userId;
                    }
                }
                var AttorneyCollectionCreate = await _patientArbitrationAttorneyService.patientArbitrationAttorney(patientViewModel.patientArbitrationAttorney);

            }


            return Json(patientViewModel);
        }

        #endregion patient Collection/Arbitration Attorney 


        public async Task<IActionResult> GetPatintLanguages(long userId)
        {
            PatientViewModel patientViewModel = new PatientViewModel();
            var selectedLanguages = await _patientInfoService.GetPatientLanguages(userId);

            return Json(selectedLanguages.Select(x => x.LanguageName).ToList());
        }

        #region Discard Form

        public async Task<IActionResult> GetPatientInfoData(long userId)
        {
            PatientViewModel patientViewModel = new PatientViewModel();
            try
            {
                patientViewModel.patientInfoBasicDto = await _patientInfoService.GetPatientInfoData(userId);
                if (patientViewModel.patientInfoBasicDto.PatientInfoId > 0)
                {
                    var data = await _patientInfoService.GetPatientDropDownData();

                    patientViewModel.prefixs = data.prefixs;
                    patientViewModel.suffix = data.suffix;
                    patientViewModel.gender = data.gender;
                    patientViewModel.maritalStatus = data.maritalStatus;
                    patientViewModel.RaceEthnicity = data.RaceEthnicity;
                    patientViewModel.RelationShip = data.RelationShip;
                    patientViewModel.patientTreatmentStatuslist = data.patientTreatmentStatuslist;
                    patientViewModel.patientLegalStatusBasicDtoslist = data.patientLegalStatusBasicDtoslist;
                    patientViewModel.EmploymentTitleList = data.EmploymentTitleList;
                    patientViewModel.EmploymentStatuslist = data.EmploymentStatuslist;
                    patientViewModel.patientLanguageList = data.patientLanguageList;
                    patientViewModel.patientInfoBasicDto.PatientLanguages = patientViewModel.patientInfoBasicDto.PatientLanguage.Split(",");





                    patientViewModel.ClaimStatusList = new List<ClaimStatusBasicDto>();
                    patientViewModel.Nf2list = new List<Models.DTOs.Nf2StatusDto.Nf2StatusBasicDto>();
                    patientViewModel.IncidentReportStatusList = new List<Models.DTOs.IncidentReportStatusDto.IncidentReportStatusBasicDto>();
                    patientViewModel.IncidentList = new List<Models.DTOs.PatientIncidentRoleDto.PatientIncidentRoleBasicDto>();
                    patientViewModel.legalInfoLegalStatusList = new List<Models.DTOs.LegalInfolegealStatusDto.legalInfoLegalBasicDto>();


                    patientViewModel.legalInfoLeadingAttorneysList = new List<Models.DTOs.LegalInfoLeadingAttorneyDto.LegalInfoLeadingAttorneyBasicDto>();
                    patientViewModel.LegalInfoLeadingParalegallist = new List<Models.DTOs.LegalInfoLeadingParalegalDto.LegalInfoLeadingParalegalBasicDto>();
                    patientViewModel.legalInfoFirmNameList = new List<Models.DTOs.LegalInfoFirmNameDto.LegalInfoFirmNameBasicDto>();
                    patientViewModel.legalInfoAttorneyNameList = new List<Models.DTOs.LegalInfoAttorneyNameDto.LegalInfoAttorneyNameBasicDto>();
                    patientViewModel.InsuranceProviderNamesList = new List<Models.DTOs.InsuranceProviderNameBasicDto.InsuranceProviderNameBasicDto>();
                    patientViewModel.PatientRelationshipList = new List<Models.DTOs.PatientRelationshipDto.PatientRelationshipBasicDto>();
                    patientViewModel.InsuranceGroupNumbersList = new List<Models.DTOs.InsuranceGroupNumberBasicDto.InsuranceGroupNumberBasicDto>();
                    patientViewModel.PatientSignatureIdTypeList = new List<Models.DTOs.PatientSignatureIdTypeBasicDto.PatientSignatureIdTypeDto>();



                    ViewBag.Action = "Update";
                    return PartialView("~/Views/PatientSideElite/PatientInfoPartial/_PatientInfoElite.cshtml", patientViewModel);
                }
                else
                {
                    return Json(false);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public async Task<IActionResult> GetPhoneNumberData(long userId)
        {
            PatientViewModel patientViewModel = new PatientViewModel();
            patientViewModel.patientPhoneNumber = await _patientInfoService.GetPatientPhoneNumberData(userId);
            if (patientViewModel.patientPhoneNumber.PhoneNumberId > 0)
            {
                ViewBag.Action = "Update";
                return PartialView("~/Views/PatientSideElite/PatientInfoPartial/_PhoneNumber.cshtml", patientViewModel);
            }
            else
            {
                return Json(false);
            }

        }
        public async Task<IActionResult> GetEmergencyData(long userId)
        {
            PatientViewModel patientViewModel = new PatientViewModel();
            patientViewModel.patientEmergencyContact = await _patientInfoService.GetPatientEmergencyData(userId);
            if (patientViewModel.patientEmergencyContact.EmergencyContactID > 0)
            {
                var patientRelationlist = await _patientRelationship.patientRelationship();
                patientViewModel.PatientRelationshipList = patientRelationlist.Data;
                ViewBag.Action = "Update";
                return PartialView("~/Views/PatientSideElite/PatientInfoPartial/_EmergencyContact", patientViewModel);
            }
            else
            {
                return Json(false);
            }
        }

        public async Task<IActionResult> GetSignatureFormData(long userId)
        {
            PatientViewModel patientViewModel = new PatientViewModel();
            patientViewModel.patientIdandSignature = await _patientInfoService.GetPatientSignatureFormData(userId);
            if (patientViewModel.patientIdandSignature.PatientSignatureId > 0)
            {
                var data = await _patientInfoService.GetPatientDropDownData();
                patientViewModel.PatientSignatureIdTypeList = data.PatientSignatureIdTypeList;

                ViewBag.SignaturePassword = patientViewModel.patientIdandSignature.ElectronicSignature;
                ViewBag.PatientImage = patientViewModel.patientIdandSignature.PaitentImage;
                TempData["ProfileImage"] = patientViewModel.patientIdandSignature.PaitentImage;
                ViewBag.SignImage = patientViewModel.patientIdandSignature.SignatureImage;
                ViewBag.WriteSignature = patientViewModel.patientIdandSignature.WriteSignature;
                if (patientViewModel.patientIdandSignature.PassportNumber != null)
                {
                    ViewBag.PassportContains = true;
                }

                ViewBag.Action = "Update";
                return PartialView("~/Views/PatientSideElite/PatientInfoPartial/_IdAndSignature.cshtml", patientViewModel);
            }
            else
            {
                ViewBag.SignaturePassword = string.Empty;
                ViewBag.PatientImage = string.Empty;
                ViewBag.SignImage = string.Empty;
                ViewBag.WriteSignature = string.Empty;

                ViewBag.PassportContains = string.Empty;
                return Json(false);
            }
        }

        public async Task<IActionResult> GetClaimInfoData(long userId)
        {
            PatientViewModel patientViewModel = new PatientViewModel();
            patientViewModel.patientClaimInfo = await _patientInfoService.GetPatientClaimInfoData(userId);

            if (patientViewModel.patientClaimInfo.PatientClaimID > 0)
            {
                var data = await _patientInfoService.GetPatientDropDownData();
                patientViewModel.IncidentList = data.IncidentList;
                patientViewModel.IncidentReportStatusList = data.IncidentReportStatusList;
                patientViewModel.Nf2list = data.Nf2list;
                patientViewModel.ClaimStatusList = data.ClaimStatusList;

                ViewBag.Action = "Update";
                return PartialView("~/Views/PatientSideElite/PatientInfoPartial/_ClaimInfo.cshtml", patientViewModel);
            }
            else
            {
                return Json(false);
            }

        }

        public async Task<IActionResult> GetVehicleData(long userId)
        {
            PatientViewModel patientViewModel = new PatientViewModel();
            patientViewModel.patientVehiclesBasiclist = await _patientInfoService.GetPatientVehicleData(userId);
            if (patientViewModel.patientVehiclesBasiclist.Count > 0)
            {
                var providerlist = await _insuranceProviderNameService.InsuranceProviderNameList();
                patientViewModel.InsuranceProviderNamesList = providerlist.Data;
                if (patientViewModel.patientVehiclesBasiclist != null && patientViewModel.patientVehiclesBasiclist.Count > 0)
                {
                    ViewBag.IsShowVehicleButton = false;
                }
                else
                {
                    ViewBag.IsShowVehicleButton = true;
                }

                ViewBag.Action = "Update";
                return PartialView("~/Views/PatientSideElite/PatientInfoPartial/_VehicleInvolved.cshtml", patientViewModel);
            }
            else
            {
                return Json(false);
            }

        }

        public async Task<IActionResult> GetSecondaryFormData(long userId)
        {
            PatientViewModel patientViewModel = new PatientViewModel();
            patientViewModel.patientSecondaryInsurance = await _patientInfoService.GetPatientSecondaryData(userId);
            if (patientViewModel.patientSecondaryInsurance.SecondaryInsuranceProviderID > 0)
            {
                var Providerlist = await _insuranceProviderNameService.InsuranceProviderNameList();
                patientViewModel.InsuranceProviderNamesList = Providerlist.Data;
                var Grouplist = await _insuranceGroupNumberService.InsuranceGroupNumberList();
                patientViewModel.InsuranceGroupNumbersList = Grouplist.Data;

                ViewBag.Action = "Update";
                return PartialView("~/Views/PatientSideElite/PatientInfoPartial/_SecondaryInsurance.cshtml", patientViewModel);
            }
            else
            {
                return Json(false);
            }
        }
        public async Task<IActionResult> GetTertiaryFormData(long userId)
        {
            PatientViewModel patientViewModel = new PatientViewModel();
            patientViewModel.PatientTertiaryInsuranceBasicDto = await _patientInfoService.GetPatientTertiaryData(userId);

            if (patientViewModel.PatientTertiaryInsuranceBasicDto.TertiaryInsurenceProviderID > 0)
            {
                var Providerlist = await _insuranceProviderNameService.InsuranceProviderNameList();
                patientViewModel.InsuranceProviderNamesList = Providerlist.Data;
                var Grouplist = await _insuranceGroupNumberService.InsuranceGroupNumberList();
                patientViewModel.InsuranceGroupNumbersList = Grouplist.Data;

                ViewBag.Action = "Update";
                return PartialView("~/Views/PatientSideElite/PatientInfoPartial/_TertiaryInsurance.cshtml", patientViewModel);
            }
            else
            {
                return Json(false);
            }

        }

        public async Task<IActionResult> GetPIFormData(long userId)
        {
            PatientViewModel patientViewModel = new PatientViewModel();
            patientViewModel.patientPersonalInjury = await _patientInfoService.GetPatientPIData(userId);

            if (patientViewModel.patientPersonalInjury.PersonalInjuryId > 0)
            {
                var data = await _patientInfoService.GetPatientDropDownData();
                var FirmList = await _legalInfoFirmNameService.LegalInfoFirmNameList();
                patientViewModel.legalInfoFirmNameList = FirmList.Data;

                var AttorneyNameList = await _legalInfoAttorneyNameService.LegalInfoAttorneyList();
                patientViewModel.legalInfoAttorneyNameList = AttorneyNameList.Data;

                var Leadingattorney = await _legalInfoLeadingAttorney.LegalInfoAttorneyNameList();
                patientViewModel.legalInfoLeadingAttorneysList = Leadingattorney.Data;

                var leadingparalegal = await _legalInfoLeadingParalegalService.LeadingParaLegalNameList();
                patientViewModel.LegalInfoLeadingParalegallist = leadingparalegal.Data;

                patientViewModel.legalInfoLegalStatusList = data.legalInfoLegalStatusList;


                ViewBag.Action = "Update";
                return PartialView("~/Views/PatientSideElite/PatientInfoPartial/_CollectionAttorney", patientViewModel);
            }
            else
            {
                return Json(false);
            }

        }

        public async Task<IActionResult> GetCollectionFormData(long userId)
        {
            PatientViewModel patientViewModel = new PatientViewModel();
            patientViewModel.patientArbitrationAttorney = await _patientInfoService.GetPatientCollectionData(userId);
            if (patientViewModel.patientArbitrationAttorney.ArbitrationAttorneyID > 0)
            {
                var data = await _patientInfoService.GetPatientDropDownData();
                var FirmList = await _legalInfoFirmNameService.LegalInfoFirmNameList();
                patientViewModel.legalInfoFirmNameList = FirmList.Data;

                var AttorneyNameList = await _legalInfoAttorneyNameService.LegalInfoAttorneyList();
                patientViewModel.legalInfoAttorneyNameList = AttorneyNameList.Data;

                var Leadingattorney = await _legalInfoLeadingAttorney.LegalInfoAttorneyNameList();
                patientViewModel.legalInfoLeadingAttorneysList = Leadingattorney.Data;

                var leadingparalegal = await _legalInfoLeadingParalegalService.LeadingParaLegalNameList();
                patientViewModel.LegalInfoLeadingParalegallist = leadingparalegal.Data;

                patientViewModel.legalInfoLegalStatusList = data.legalInfoLegalStatusList;


                ViewBag.Action = "Update";
                return PartialView("~/Views/_PatientPartialView/_PatientCollection.cshtml", patientViewModel);
            }
            else
            {
                return Json(false);
            }

        }

        #endregion

        [HttpPost]
        public IActionResult LookupByType(string lookupType, string name)
        {
            var infoList = _lookupService.lookupsByType(lookupType, name);
            return Json(infoList);
        }
        public IActionResult AddDocumentsElite()
        {
            return View();
        }
       
        public IActionResult AddGrowthChartElite()
        {
            return View();
        }
        public IActionResult AddIMEElite()
        {
            return View();
        }
        public IActionResult AddImagingElite()
        {
            return View();
        }
        public IActionResult AddImmunizationElite()
        {
            return View();
        }
        public IActionResult AddLabElite()
        {
            return View();
        }
        public IActionResult AddLegalInfoElite()
        {
            return View();
        }
        public IActionResult AddMedicationElite()
        {
            return View();
        }
        public IActionResult AddProcedureElite()
        {
            return View();
        }
        public IActionResult AddNewReminderElite()
        {
            return View();
        }
        public IActionResult AddMessageElite()
        {
            return View();
        }
        public IActionResult AddReportElite()
        {
            return View();
        }
        public IActionResult AddvisitElite()
        {
            return View();
        }
       
        public async Task<IActionResult> NewExamElite(int? Id) 
        {
            ReportsViewModel report = new ReportsViewModel();

            if (Id != null)
            {
                var response = await _reportService.GetExamInformationById((int)Id);
                report.ExamInfromation = response.Data;
            }
            else
            {

            }
            return View(report);
        }
        public IActionResult Appointment() 
        {
            return View();
        }
        public IActionResult PatientCalendar()
        {
            return View();
        }

        public async Task<IActionResult> PatientList(long? Id)
        {
            PatientViewModel patientViewModel = new PatientViewModel();
            var userId = (long?)_sessionManager.GetUserId();
            if (!(userId is null))
            {
                patientViewModel.PatientListSettingDto = _patientSettings.getPatientListSettingsById((int)userId);
            }
            patientViewModel.ProviderList = await _providerInfoService.GetProviderList();
            patientViewModel.patientListWithUsers = await _patientInfoService.GetPatientListWithDetails();
            if (patientViewModel.patientListWithUsers.Count > 0 )
            {
                patientViewModel.patientListWithUsers = patientViewModel.patientListWithUsers.Distinct().ToList();
            }
            return View(patientViewModel);
        }
        public async Task<IActionResult> InActivePatientsList(long? Id)
        {
            PatientViewModel patientViewModel = new PatientViewModel();

            patientViewModel.patientInfoList = await _patientInfoService.GetInActivePatientList();
        
            return View(patientViewModel);
        }
        public async Task<IActionResult> PatientProgressReport(int patientId) 
        {
            PatientViewModel patientViewModel = new PatientViewModel();
            patientViewModel.GetVisitsListDto = await _patientInfoService.GetVisitsList(patientId);
            return View(patientViewModel);
        }

        
        public IActionResult GetLatestVisitID(long patientId)
        {
            var result = _patientInfoService.GetLatestVisitIDAgainstPatient(patientId);
            return Json(result);
        }

        public async Task<IActionResult> PatientInfoActive(long patientId)
        {
            var PatById = await _patientInfoService.patientActiveById(patientId);
            //return RedirectToAction("PatientList", "PatientSide");
            return Json(PatById.Data);
        }
    }
}

