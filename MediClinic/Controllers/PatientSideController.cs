using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Drawing.Imaging;
using System.Net.Http.Headers;
using System.Threading.Tasks;
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
using Microsoft.AspNetCore.Mvc;
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
using MedliClinic.Utilities.Utility.Enum;
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
using MediClinic.Models.EntityModels;
using MedliClinic.Utilities.Utility;
using MediClinic.Models.DTOs.EmailDto;
using MediClinic.Services.Interfaces.ProviderSpecialityInterface;
using MediClinic.Services.Interfaces.PatientSettings;
using MediClinic.Services.Interfaces.PatientPrescriptionInterface;
using MediClinic.Services.Interfaces.PrescriptionTemplateService;
using MediClinic.Models.DTOs.TemplateDto;
using MediClinic.Models.DTOs.PrescriptionDto;
using Microsoft.AspNetCore.SignalR;
using MediClinic.SignalRHub;
using MediClinic.Models.DTOs.ClaimStatus;
using MediClinic.Models.DTOs.DMESuppliesDto;

namespace MediClinic.Controllers.PatiendSide
{
    //[AuthFilter(RoleNames.Doctor, RoleNames.Patient,RoleNames.Receptionist,RoleNames.Admin)]
    public class PatientSideController : Controller
    {
        private readonly ILogger<PatientSideController> _logger;
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
        private IDMESuppliesService _dMESuppliesService;
        public PatientSideController(ILogger<PatientSideController> logger,
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
            IHubContext<NotificationsHub> notificationHubContext,
            IDMESuppliesService dMESuppliesService,
        ISessionManager sessionManager, ILookupService lookupService, IAuthService authService)
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
            _notificationHubContext = notificationHubContext;
             _dMESuppliesService= dMESuppliesService;
        }

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

        public async Task<IActionResult> GetPatintLanguages(long userId)
        {
            PatientViewModel patientViewModel = new PatientViewModel();
            var selectedLanguages = await _patientInfoService.GetPatientLanguages(userId);

            return Json(selectedLanguages.Select(x => x.LanguageName).ToList());
        }

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
                        };
                        if (!string.IsNullOrEmpty(patientfile))
                        {

                            patientViewModel.patientIdandSignature.PaitentImage = patientfile;

                        }

                        if (!string.IsNullOrEmpty(Signfile))
                        {

                            patientViewModel.patientIdandSignature.SignatureImage = Signfile;

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
        #endregion Patient Signature and Id

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

        #region Patient Case Type
        [HttpPost]
        public async Task<IActionResult> PatientCaseType(PatientViewModel patientViewModel)
        {
            if (patientViewModel.patientCaseTypeBasicDto.CaseTypeId > 0)
            {
                ViewBag.BtnSubmit = "Save";
                var infocre = await _patientCaseTypeService.PatientCaseTypeUpdate(patientViewModel.patientCaseTypeBasicDto);
            }
            else
            {
                ViewBag.BtnSubmit = "Save";
                var userId = _sessionManager.GetPatientUserId();

                if (patientViewModel.patientCaseTypeBasicDto.UserId == 0)
                {
                    if (!(patientViewModel.patientInfoBasicDto.UserId is 0))
                    {
                        patientViewModel.patientCaseTypeBasicDto.UserId = patientViewModel.patientInfoBasicDto.UserId;
                    }
                    else if (userId == 0)
                    {
                        var returnObj = new { IsError = true };
                        return Json(returnObj);
                    }
                    else
                    {
                        patientViewModel.patientCaseTypeBasicDto.UserId = userId;
                    }
                }
                var infocre = await _patientCaseTypeService.PatientCaseTypeCreate(patientViewModel.patientCaseTypeBasicDto);
            }

            return Json(patientViewModel);
        }
        #endregion Patient Case Type

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
                    return PartialView("~/Views/_PatientPartialView/_PatientInfo.cshtml", patientViewModel);
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
                return PartialView("~/Views/_PatientPartialView/_PatientPhoneNumber.cshtml", patientViewModel);
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
                return PartialView("~/Views/_PatientPartialView/_PatientEmergencyContact.cshtml", patientViewModel);
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
                return PartialView("~/Views/_PatientPartialView/_PatientIdandSignature.cshtml", patientViewModel);
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
                return PartialView("~/Views/_PatientPartialView/_PatientClaimInfo.cshtml", patientViewModel);
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
                return PartialView("~/Views/_PatientPartialView/_PatientVehicles.cshtml", patientViewModel);
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
                return PartialView("~/Views/_PatientPartialView/_PatientSecondaryInsurance.cshtml", patientViewModel);
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
                return PartialView("~/Views/_PatientPartialView/_PatientTertiaryInsurance.cshtml", patientViewModel);
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
                return PartialView("~/Views/_PatientPartialView/_PatientPI.cshtml", patientViewModel);
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
        public async Task<IActionResult> getCaseTypes()
        {
            PatientViewModel patientViewModel = new PatientViewModel();
            var result = await _addNewCaseTypeService.NewCaseList();
            patientViewModel.addNewCaseTypeList = result.Data;
            return PartialView("~/Views/_PatientPartialView/_NewCaseList.cshtml", patientViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> PatientNewCaseType(PatientViewModel patientViewModel)
        {
            var infocre = await _addNewCaseTypeService.AddNewCaseType(patientViewModel.addNewCaseTypeBasicDto);
            var result = await _addNewCaseTypeService.NewCaseList();
            patientViewModel.addNewCaseTypeList = result.Data;
            return PartialView("~/Views/_PatientPartialView/_NewCaseList.cshtml", patientViewModel);

        }
        [HttpPost]
        public async Task<IActionResult> PatientNewCaseList()
        {
            PatientViewModel patientViewModel = new PatientViewModel();
            var result = await _addNewCaseTypeService.NewCaseList();
            patientViewModel.addNewCaseTypeList = result.Data;
            return View(patientViewModel);
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

            return View(patientViewModel);
        }

        public async Task<IActionResult> PatientInfoUpdate(int Id)
        {
            var PatById = await _patientInfoService.patientInfoGetId(Id);
            return View("PatientInfo", PatById.Data);

        }
        public async Task<IActionResult> PatientInfoDelete(int patientId)
        {
            var PatById = await _patientInfoService.patientInfoDeleteById(patientId);
            //return RedirectToAction("PatientList", "PatientSide");
            return Json(PatById.Data);
        }
        public IActionResult LegalInfo()
        {

            return View();
        }
        public IActionResult LegalInfoList(long Id)
        {

            ViewBag.LegalInfoList = "nav-active";
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> PatientTreatmentStatus(PatientTreatmentStatusBasicDto patientTreatmentStatusBasicDto)
        {
            var ExistName = await _patientTreatmentStatusService.IsExistOrNot(patientTreatmentStatusBasicDto.PatientTreatmentStatus1);
            if (ExistName.Data)
            {
                var message = new { Success = ExistName.Message, IsError = true };
                return Json(message);
            }
            var result = await _patientTreatmentStatusService.patientTreatmentStatusCreate(patientTreatmentStatusBasicDto);
            var data = new { PatientTreatmentId = result.Data, PatientTreatmentStatus1 = patientTreatmentStatusBasicDto.PatientTreatmentStatus1 };
            return Json(data);
        }


        [HttpPost]
        public async Task<IActionResult> PatientLegalStatus(PatientLegalStatusBasicDto patientLegalStatusBasicDto)
        {
            var ExistName = await _patientLegalStatusService.IsExitorNot(patientLegalStatusBasicDto.PatientLegalStatus1);
            if (ExistName.Data)
            {
                var message = new { Success = ExistName.Message, IsError = true };
                return Json(message);
            }
            var result = await _patientLegalStatusService.patientLegalStatusCreate(patientLegalStatusBasicDto);
            var data = new { PatientLegalId = result.Data, PatientLegalStatus1 = patientLegalStatusBasicDto.PatientLegalStatus1 };
            return Json(data);
        }
        #region Patient Claim Status
        [HttpPost]
        public async Task<IActionResult> PatientClaimStatus(PatientViewModel patientViewModel)
        {
            var ExistName = await _claimStatusService.isExistorNot(patientViewModel.claimStatusBasicDto.ClaimStatus1);
            if (ExistName.Data)
            {
                var message = new { Success = ExistName.Message, IsError = true };
                return Json(message);
            }
            var create = await _claimStatusService.claimStatus(patientViewModel.claimStatusBasicDto);
            var data = new { ClaimStatusId = create.Data, ClaimStatus1 = patientViewModel.claimStatusBasicDto.ClaimStatus1 };

            return Json(data);
        }
        #endregion Patient Claim Status

        #region Incident Report Status
        [HttpPost]
        public async Task<IActionResult> IncidentReportStatus(PatientViewModel patientViewModel)
        {
            var ExistName = await _incidentReportStatus.isExistorNot(patientViewModel.IncidentReportStatusBasicDto.IncidentReportStatus1);
            if (ExistName.Data)
            {
                var message = new { Success = ExistName.Message, IsError = true };
                return Json(message);
            }
            var create = await _incidentReportStatus.IncidentRepotStatus(patientViewModel.IncidentReportStatusBasicDto);
            var data = new { IncidentReportId = create.Data, IncidentReportStatus1 = patientViewModel.IncidentReportStatusBasicDto.IncidentReportStatus1 };

            return Json(data); ;
        }
        #endregion Incident Report Status

        #region Patient nf2Status
        [HttpPost]
        public async Task<IActionResult> nf2Status(PatientViewModel patientViewModel)
        {
            var ExistName = await _nf2StatusService.isExistorNot(patientViewModel.nf2Status.Nf2Status1);
            if (ExistName.Data)
            {
                var message = new { Success = ExistName.Message, IsError = true };
                return Json(message);
            }
            var create = await _nf2StatusService.nf2StatusCreate(patientViewModel.nf2Status);
            var data = new { Nf2Id = create.Data, Nf2Status1 = patientViewModel.nf2Status.Nf2Status1 };

            return Json(data); ;
        }
        #endregion Patient nf2Status

        #region Patient Role Of incident
        [HttpPost]
        public async Task<IActionResult> patientRoleIncident(PatientViewModel model)
        {
            var ExistName = await _patientIncidentRoleService.isExistorNot(model.patientIncidentRole.PatientRoleInIncident);
            if (ExistName.Data)
            {
                var message = new { Success = ExistName.Message, IsError = true };
                return Json(message);
            }
            var create = await _patientIncidentRoleService.patientIncidentRole(model.patientIncidentRole);
            var data = new { PatientIncidentRoleId = create.Data, PatientRoleInIncident = model.patientIncidentRole.PatientRoleInIncident };

            return Json(data);
        }
        #endregion Patient Role Of incident
        [HttpPost]
        public IActionResult LookupByType(string lookupType, string name)
        {
            var infoList = _lookupService.lookupsByType(lookupType, name);
            return Json(infoList);
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

        public async Task<IActionResult> Missing(long Id) //PatientId
        {
            PatientMissingViewModel patientMissing = new PatientMissingViewModel();
            patientMissing.PatientMissingsListDto = await _patientMissingService.GetPatientInfoMissingFieldsByPatientId(Id);

            ViewBag.Missing = "nav-active";

            return View(patientMissing);
        }

        #region Patient Summary
        public async Task<IActionResult> PatientSummary(long? Id) //PatientInfoId
        {
            ViewBag.PatientSummary = "nav-active";
            PatientViewModel patientViewModel = new PatientViewModel();
            var userId = (long?)_sessionManager.GetUserId();

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
        #endregion Patient Summary

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

            return PartialView("~/Views/_PatientPartialView/_patientSummary.cshtml", patientViewModel);
        }

        #region Patient Employment Status 
        [HttpPost]
        public async Task<IActionResult> EmploymentStatus(PatientViewModel patientViewModel)
        {
            var ExistName = await _employmentStatus.isExistorNot(patientViewModel.EmploymentStatusBasicDto.EmploymentStatus1);
            if (ExistName.Data)
            {
                var message = new { Success = ExistName.Message, IsError = true };
                return Json(message);
            }
            var create = await _employmentStatus.EmploymentStatus(patientViewModel.EmploymentStatusBasicDto);
            var data = new { EmploymentStatusId = create.Data, EmploymentStatus1 = patientViewModel.EmploymentStatusBasicDto.EmploymentStatus1 };
            return Json(data);
        }
        #endregion Patient Employment Status 

        #region Patient Employment Title 
        //EmploymentList
        [HttpPost]
        public async Task<IActionResult> EmploymentTitle(PatientViewModel patientViewModel)
        {
            var ExistName = await _employmentTitleService.isExistorNot(patientViewModel.EmploymentTitleBasicDto.EmploymentTitle1);
            if (ExistName.Data)
            {
                var message = new { Success = ExistName.Message, IsError = true };
                return Json(message);
            }
            var create = await _employmentTitleService.EmploymentTitle(patientViewModel.EmploymentTitleBasicDto);
            var data = new { EmploymentTitleId = create.Data, EmploymentTitle1 = patientViewModel.EmploymentTitleBasicDto.EmploymentTitle1 };
            return Json(data);
        }
        #endregion Patient Employment Title 

        #region Patient Signature Type ID
        [HttpPost]
        public async Task<IActionResult> PatientSignatureIdType(PatientViewModel patientViewModel)
        {
            var ExistName = await _patientSignatureIdTypeService.isExistorNot(patientViewModel.PatientSignatureIdTypeBasicDto.TypeName);
            if (ExistName.Data)
            {
                var message = new { Success = ExistName.Message, IsError = true };
                return Json(message);
            }
            var create = await _patientSignatureIdTypeService.PatientSignatureIdType(patientViewModel.PatientSignatureIdTypeBasicDto);
            var data = new { TypeId = create.Data, TypeName = patientViewModel.PatientSignatureIdTypeBasicDto.TypeName };

            return Json(data);
        }
        #endregion Patient Signature Type ID

        #region Insurance Provider Name
        [HttpGet]
        public async Task<IActionResult> InsuranceProviderName()
        {
            PatientViewModel patientViewModel = new PatientViewModel();
            var Providerlist = await _insuranceProviderNameService.InsuranceProviderNameList();
            //patientViewModel.InsuranceProviderNamesList = Providerlist.Data;
            return Json(Providerlist.Data);
        }
        [HttpPost]
        public async Task<IActionResult> InsuranceProviderName(PatientViewModel patientViewModel)
        {
            var ExistName = await _insuranceProviderNameService.isExistorNot(patientViewModel.InsuranceProviderNameBasicDto.ProviderName);
            if (ExistName.Data)
            {
                var message = new { Success = ExistName.Message, IsError = true };
                return Json(message);
            }
            var result = await _insuranceProviderNameService.InsuranceProviderName(patientViewModel.InsuranceProviderNameBasicDto);
            var data = new { ProviderId = result.Data, ProviderName = patientViewModel.InsuranceProviderNameBasicDto.ProviderName };
            return Json(data);
        }
        #endregion Insurance Provider Name

        #region Insurance group Number
        [HttpPost]
        public async Task<IActionResult> InsuranceGroupNumber(PatientViewModel patientViewModel)
        {
            var ExistName = await _insuranceGroupNumberService.isExistorNot(patientViewModel.InsuranceGroupNumberBasicDto.GroupName);
            if (ExistName.Data)
            {
                var message = new { Success = ExistName.Message, IsError = true };
                return Json(message);
            }

            var result = await _insuranceGroupNumberService.InsuranceGroupNumber(patientViewModel.InsuranceGroupNumberBasicDto);
            var data = new { GroupId = result.Data, GroupName = patientViewModel.InsuranceGroupNumberBasicDto.GroupName };
            return Json(data);
        }
        #endregion Insurance group Number

        #region Legal Info Legal Status
        [HttpPost]
        public async Task<IActionResult> LegalInfoLegalStatus(PatientViewModel model)
        {
            var ExistName = await _legalInfolegalService.isExistorNot(model.LegalInfoLegalStatus.LegalStatus);
            if (ExistName.Data)
            {
                var message = new { Success = ExistName.Message, IsError = true };
                return Json(message);
            }
            var result = await _legalInfolegalService.Legalinfostatus(model.LegalInfoLegalStatus);
            var data = new { LegalStatusId = result.Data, LegalStatus = model.LegalInfoLegalStatus.LegalStatus };
            return Json(data);
        }
        #endregion Legal Info Legal Status

        #region legal Info Firm Name

        [HttpPost]
        public async Task<IActionResult> FirmName(PatientViewModel patientViewModel)
        {
            var ExistName = await _legalInfoFirmNameService.isExistorNot(patientViewModel.LegalInfoFirmNameBasicDto.FirmName);
            if (ExistName.Data)
            {
                var message = new { Success = ExistName.Message, IsError = true };
                return Json(message);
            }
            var result = await _legalInfoFirmNameService.LegalInfoFirmName(patientViewModel.LegalInfoFirmNameBasicDto);
            var data = new { FirmId = result.Data, FirmName = patientViewModel.LegalInfoFirmNameBasicDto.FirmName };
            return Json(data);
        }
        #endregion Legal Info Firm Name

        #region legal Info Attorney Name

        [HttpPost]
        public async Task<IActionResult> AttorneyName(PatientViewModel patientViewModel)
        {
            var ExistName = await _legalInfoAttorneyNameService.IsExistorNot(patientViewModel.LegalInfoAttorneyNameBasicDto.AttorneyName);
            if (ExistName.Data)
            {
                var message = new { Success = ExistName.Message, IsError = true };
                return Json(message);
            }
            var result = await _legalInfoAttorneyNameService.LegalInfoAttorneyName(patientViewModel.LegalInfoAttorneyNameBasicDto);
            var data = new { AttorneyId = result.Data, AttorneyName = patientViewModel.LegalInfoAttorneyNameBasicDto.AttorneyName };
            return Json(data);
        }
        #endregion Legal Info Attorney Name

        #region legal Info Leading Attorney Name
        [HttpPost]
        public async Task<IActionResult> PatientLeadingAttorney(PatientViewModel patientViewModel)
        {
            var ExistName = await _legalInfoLeadingAttorney.isExistorNot(patientViewModel.legalInfoLeadingAttorneyBasicDto.LeadingAttorneyName);
            if (ExistName.Data)
            {
                var message = new { Success = ExistName.Message, IsError = true };
                return Json(message);
            }
            var ressult = await _legalInfoLeadingAttorney.LegalInfoAttorneyName(patientViewModel.legalInfoLeadingAttorneyBasicDto);
            var data = new { LeadingAttorneyId = ressult.Data, LeadingAttorneyName = patientViewModel.legalInfoLeadingAttorneyBasicDto.LeadingAttorneyName };
            return Json(data);

        }
        #endregion legal Info Leading Attorney Name

        #region legal Info Leading Paralegal Name
        [HttpPost]
        public async Task<IActionResult> LeadingParalegal(PatientViewModel patientViewModel)
        {
            var ExistName = await _legalInfoLeadingParalegalService.isExistorNot(patientViewModel.LegalInfoLeadingParalegalBasicDto.LeadingParalegalName);
            if (ExistName.Data)
            {
                var message = new { Success = ExistName.Message, IsError = true };
                return Json(message);
            }
            var create = await _legalInfoLeadingParalegalService.LeadingParaLegalName(patientViewModel.LegalInfoLeadingParalegalBasicDto);
            var data = new { LeadingParalegalId = create.Data, LeadingParalegalName = patientViewModel.LegalInfoLeadingParalegalBasicDto.LeadingParalegalName };

            return Json(data);
        }
        #endregion legal Info Leading Paralegal Name

        #region patient RelationShip
        [HttpPost]
        public async Task<IActionResult> PatientEmergencyRelationShip(PatientViewModel patientViewModel)
        {
            var ExistName = await _patientRelationship.isExistorNot(patientViewModel.PatientRelationship.RelationshipName);
            if (ExistName.Data)
            {
                var message = new { Success = ExistName.Message, IsError = true };
                return Json(message);
            }
            var create = await _patientRelationship.relationShip(patientViewModel.PatientRelationship);
            var data = new { RelationshipId = create.Data, RelationshipName = patientViewModel.PatientRelationship.RelationshipName };

            return Json(data);
        }
        #endregion patient RelationShip

        #region Patient Language
        [HttpPost]
        public async Task<IActionResult> PatientLanguage(PatientViewModel patientViewModel)
        {
            var ExistName = await _patientLanguageService.isExistorNot(patientViewModel.patientLanguage.LanguageName);
            if (ExistName.Data)
            {
                var message = new { Success = ExistName.Message, IsError = true };
                return Json(message);
            }
            var create = await _patientLanguageService.patientLanguage(patientViewModel.patientLanguage);
            var data = new { LanguageId = create.Data, LanguageName = patientViewModel.patientLanguage.LanguageName };

            return Json(data);
        }
        #endregion Patient Language

        #region Medical Disease Type
        [HttpPost]
        public async Task<IActionResult> MedicalDiseaseType(PatientViewModel patientViewModel)
        {
            var ExistName = await _medicalDiseaseTypeService.isExistorNot(patientViewModel.medicalDiseaseTypeBasicDto.DiseaseTypeName);
            if (ExistName.Data)
            {
                var message = new { Success = ExistName.Message, IsError = true };
                return Json(message);
            }
            var create = await _medicalDiseaseTypeService.MedicalDiseaseType(patientViewModel.medicalDiseaseTypeBasicDto);
            var data = new { DiseaseTypeId = create.Data, DiseaseTypeName = patientViewModel.medicalDiseaseTypeBasicDto.DiseaseTypeName };

            return Json(data);
        }
        #endregion Medical Disease Type

        

        #region Patient Vital

        public IActionResult VITALS(long? Id) //patientId
        {
            PatientViewModel patientViewModel = new PatientViewModel();
            if (Id != null)
            {
                _sessionManager.SetPatientInfoId(Id.Value);
                patientViewModel.Vitallist = _patientVitalService.GetAllVitalByPatientInfoId(Id.Value);
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
            }
            else
            {
                patientViewModel.Vitallist = new List<VitalDto>();
            }
            ViewBag.VITALS = "nav-active";

            return View(patientViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> VITALSEdit(int? patientVitalId, string actionType)
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
        public IActionResult VITALSEdit(VitalDto vitalDto)
        {
            var patientId = _sessionManager.GetPatientInfoId();
            if (vitalDto.PatientVitalId == 0)
            {
                vitalDto.PatientInfoId = patientId;
            }

            _patientVitalService.SavePatientVital(vitalDto);
            return RedirectToAction("VITALS", new { Id = patientId });
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

        #endregion

        #region Medical History
        public async Task<IActionResult> MedicalHistoryList(long Id)
        {
            PatientViewModel vm = new PatientViewModel();
            vm.DiseaseList = _DoctorService.GetDisease();
            vm.MedicineList = _DoctorService.GetMedicine();
            var MedicalHistoryList = await _patientMedicalHistoryService.PatientMedicalHistoryList(Id);
            vm.patientMedicalHistoryList = MedicalHistoryList.Data;
            ViewBag.ViewProfile = true;
            ViewBag.MedicalHistory = "nav-active";
            return View(vm);
        }


        public async Task<IActionResult> MedicalHistory(long Id, int MedicalHistoryId)
        {
            PatientViewModel vm = new PatientViewModel();
            var list = await _medicalDiseaseTypeService.MedicalDiseaseList();
            vm.DiseaseList = _DoctorService.GetDisease().Take(50);
            vm.MedicineList = _DoctorService.GetMedicine().Take(50);
            vm.CountryList = _Common.CountryList();
            vm.CityList = _Common.CityList();
            ViewBag.ViewProfile = true;
            return View(vm);
        }
       

       
        [HttpGet]
        public ActionResult EditMHRecreationalDrugHistory(int Id)
        {

            var result = _PatientService.EditMHRecreationalDrugsHistory(Id);
            return Json(result);
        }
        public ActionResult DeleteMHRecreationalDrugsHistory(int Id)
        {

            bool status = false;
            PatientViewModel vm = new PatientViewModel();
            var PatientId = _sessionManager.GetPatientInfoId();

            status = _PatientService.DeleteMHRecreationalDrugsHistory(Id);
            vm.GetMHPastDiseaseHistory = _PatientService.GetMHPastDiseaseHistory(PatientId);

            vm.MHRecreationalDrugsHistoryList = _PatientService.GetMHRecreationalDrugsHistory(PatientId);
            return PartialView("../_PatientPartialView/_ManageMHRecreationalDrugsHistory", vm);
        }


     
        [HttpPost]
        public async Task<IActionResult> MedicalHistory(PatientViewModel patientViewModel)
        {


            var url = Convert.ToInt64(RouteData.Values["Id"]);
            if (patientViewModel.patientMedicalHistoryBasicDto.MedicalHistryId > 0)
            {
                var update = await _patientMedicalHistoryService.PatientMedicalHistoryUpdate(patientViewModel.patientMedicalHistoryBasicDto);
            }
            else
            {
                patientViewModel.patientMedicalHistoryBasicDto.PatientId = url;
                var Create = await _patientMedicalHistoryService.PatientMedicalHistoryCreate(patientViewModel.patientMedicalHistoryBasicDto);
                return RedirectToAction("MedicalHistoryList", "PatientSide", new { Id = url });


            }
            return View(patientViewModel);


        }

        public IActionResult DeleteMedicalHistory(int Id)
        {
            var result = _patientMedicalHistoryService.PatientMedicalHistoryDeleteById(Id);
            return Json(result);
        }

        
       
        #endregion Medical History

       
        public IActionResult ClaimInfolist()
        {
            ViewBag.claiminfo = "nav-active";

            return View();
        }
        #region Email & SMS Methods
        [HttpPost]
        public IActionResult EmailSend(PatientViewModel patientViewModel)
        {
            var result = CommonMethod.SendEmail(patientViewModel.EmailBasicDto);
            return Json(result);
        }
        public IActionResult EmailSms(PatientViewModel patientViewModel)
        {
            if (string.IsNullOrEmpty(patientViewModel.SmsDto.PhoneNo))
            {
                return Json(false);
            }
            patientViewModel.SmsDto.PhoneNo = "+" + patientViewModel.SmsDto.PhoneNo;
            var result = CommonMethod.SendSms(patientViewModel.SmsDto);
            return Json(result);
        }
        #endregion


        #region Prescription
        public async Task<IActionResult> Prescription()
        {
            ViewBag.Prescription = "nav-active";
            long patientId = _sessionManager.GetPatientInfoId();
            PatientViewModel model = new PatientViewModel();
            var prescriptionlist = await _patientPrescriptionService.prescriptionList(patientId);
            model.prescriptionBasicsList = prescriptionlist.Data;

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> AddPrescription(int? Id)
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
                //model.dMEDto = await _patientPrescriptionService.GetDMESupplyById(Id);
                ViewBag.Image = model.dMEDto.ImageUrl;
                model.prescriptionBasicDto = res.Data;
                model.StartDate = res.Data.StartDate.ToString();
                model.EndDate = res.Data.EndDate.ToString();
            }
            else
            {
                ViewBag.Action = "Save";

            }
            model.MedicineList = _patientPrescriptionService.GetMedicine().Take(20);
            model.TemplateBasicList = await _templateService.ProviderTemplateList();
            dtoObj.ICDList = await _dMESuppliesService.GetAllICDCodes(true);
            dtoObj.CPTList = await _dMESuppliesService.GetAllCPTCodes();
            dtoObj.ItemList = await _dMESuppliesService.GetAllItemsGroup();
            dtoObj.PrescriberList = await _providerInfoService.GetProviderList();
            model.dMEDto = dtoObj;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddPrescription(PatientViewModel patientViewModel)
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
                patientViewModel.prescriptionBasicDto.PatientInfoId = patientId;
                var exist = await _patientPrescriptionService.isPrescriptionExistorNot(patientViewModel.prescriptionBasicDto.MedicationId, patientId);
                if (exist.Data)
                {
                    return Json("exist");
                }
                else
                {
                    await _patientPrescriptionService.prescriptionCreate(patientViewModel.prescriptionBasicDto);

                }
            }
            return RedirectToAction("/PatientSide/Prescription");
        }
        public IActionResult Deleteprescription(int prescriptionlId)
        {
            var result = _patientPrescriptionService.prescriptionDeleteById(prescriptionlId);
            return Json(result);
        }
        [HttpPost]
        public async Task<IActionResult> patientTemplate(PatientViewModel patientViewModel)
        {
            string msg = "";
            var patientId = _sessionManager.GetPatientInfoId();
            string[] data = patientViewModel.SelectedData.Split(new string[] { "|-|" }, StringSplitOptions.None);
            PrescriptionBasicDto prescriptionBasicDto = new PrescriptionBasicDto();
            foreach (var item in data)
            {

                if (item != "")
                {

                    string[] metadata = item.Split(new string[] { "_" }, StringSplitOptions.None);

                    var exist = await _patientPrescriptionService.isPrescriptionExistorNot(Convert.ToInt64(metadata[0]), patientId);
                    if (exist.Data)
                    {
                        msg = "exist";
                    }
                    else
                    {
                        DateTime sDate = Convert.ToDateTime(metadata[4]);
                        DateTime eDate = Convert.ToDateTime(metadata[5]);

                        prescriptionBasicDto.MedicationId = Convert.ToInt32(metadata[0]);
                        prescriptionBasicDto.FrequencyId = metadata[1];
                        prescriptionBasicDto.Quantity = Convert.ToInt32(metadata[2]);
                        prescriptionBasicDto.Dose = Convert.ToInt32(metadata[3]);
                        prescriptionBasicDto.StartDate = sDate;
                        prescriptionBasicDto.EndDate = eDate;
                        prescriptionBasicDto.Unit = metadata[6];
                        prescriptionBasicDto.Notes = metadata[7];
                        prescriptionBasicDto.PatientInfoId = patientId;
                        await _patientPrescriptionService.prescriptionCreate(prescriptionBasicDto);
                        msg = "success";
                    }

                }
            }
            return Json(msg);
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
            return View(model);
        }
        #endregion Prescription

        public IActionResult Test()
        {
            return View();
        }
       

    }
}