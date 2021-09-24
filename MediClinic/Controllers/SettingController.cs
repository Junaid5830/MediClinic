using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediClinic.Models;
using MediClinic.Services.Interfaces.Nf2StatusInterface;
using MediClinic.Services.Interfaces.PatientLegalStatusInterface;
using MediClinic.Services.Interfaces.PatientRelationshipInterface;
using MediClinic.Services.Interfaces.PatientTreatmentStatusInterface;
using MediClinic.Services.Interfaces.SessionManager;

using MediClinic.Services.Interfaces.ClaimStatusInterface;

using MediClinic.Models.DTOs.PatientIncidentRoleDto;
using MediClinic.Services.Interfaces.IncidentReportStatusInterface;
using MediClinic.Services.Interfaces.PatientIncidentRoleInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MediClinic.Filters;
using MedliClinic.Utilities.Utility.Enum;
using MediClinic.Models.DTOs.PatientSettingsDto;
using MediClinic.Services.Interfaces.PatientSettings;
using MediClinic.Services.Interfaces.PatientInfoInterface;
using System.Globalization;
using MediClinic.Models.DTOs.PatientInfoListDto;
using MediClinic.Services.Interfaces.PatientVitalInterface;
using MediClinic.Services.Interfaces.PatientMissingInterface;
using System.IO;
using System.Web;
using System.Text;
using MediClinic.Services.Interfaces;
using MediClinic.Models.DTOs;
using MediClinic.Services.Interfaces.SeetingAttorney;
using System.Drawing.Imaging;
using System.Drawing;

namespace MediClinic.Controllers.Setting
{
    //[AuthFilter(RoleNames.Doctor,RoleNames.Patient,RoleNames.Admin)]
    public class SettingController : Controller
    {
        private readonly ILogger<SettingController> _logger;
        private IPatientTreatmentStatusService _patientTreatmentStatus;
        private IPatientLegalStatusService _patientLegalStatusService;
        private INf2StatusService _nf2StatusService;
        private IPatientRelationshipService _patientRelationshipService;
        private ISessionManager _sessionManager;
        private IPatientIncidentRoleService _patientIncident;
        private IIncidentReportStatusService _incidentReportStatusService;
        private IClaimStatusService _claimStatusService;
        private IPatientSettings _patientSettings;
        private readonly IPatientInfoService _patientInfoService;
        private IPatientVitalService _patientVitalService;
        private IPatientMissingService _patientMissingService;
        private IProviderSettingsService _providerSettingsService;
        private ISettingAttorney _SettingsAttorneyService;
        public SettingController(ILogger<SettingController> logger, IPatientTreatmentStatusService patientTreatmentStatus, 
            IPatientLegalStatusService patientLegalStatusService, IPatientRelationshipService patientRelationshipService, INf2StatusService nf2StatusService, IIncidentReportStatusService incidentReportStatusService, IClaimStatusService claimStatusService, IPatientIncidentRoleService patientIncident, ISessionManager sessionManager, IPatientSettings patientSettings, IPatientInfoService patientInfoService
            , IPatientVitalService patientVitalService, IPatientMissingService patientMissingService, IProviderSettingsService providerSettingsService
            , ISettingAttorney SettingsAttorneyService
            )
        {
            _logger = logger;
            _incidentReportStatusService = incidentReportStatusService;
            _patientIncident = patientIncident;
            _claimStatusService = claimStatusService;
            _patientTreatmentStatus = patientTreatmentStatus;
            _patientLegalStatusService = patientLegalStatusService;
            _nf2StatusService = nf2StatusService;
            _patientRelationshipService = patientRelationshipService;
            _sessionManager = sessionManager;
            _patientSettings = patientSettings;
            _patientInfoService = patientInfoService;
            _patientVitalService = patientVitalService;
            _patientMissingService = patientMissingService;
            _providerSettingsService = providerSettingsService;
            _SettingsAttorneyService = SettingsAttorneyService;
        }

        public IActionResult Setting(int? Id) //PatientId
        {
            return View();
        }
        #region Incidenet Report Status
        public async Task<IActionResult> IncidentReportStatus(int Id)
        {

            PatientViewModel patientViewModel = new PatientViewModel();
            var infoList = await _incidentReportStatusService.PatientIncidentReport();
            patientViewModel.IncidentReportStatusList = infoList.Data;
            return View(patientViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> IncidentReportStatus(PatientViewModel patientViewModel)
        {
            if (patientViewModel.IncidentReportStatusBasicDto.IncidentReportId>0)
            {
                var update = await _incidentReportStatusService.IncidentRepotStatusUpdate(patientViewModel.IncidentReportStatusBasicDto);
                var Data = new { Success = "Data Update successfully" };
                return Json(Data);
            }
            else
            {
                var Create = await _incidentReportStatusService.IncidentRepotStatus(patientViewModel.IncidentReportStatusBasicDto);
                var Data = new { Success = "Data Create successfully" };
                return Json(Data);
            }
        }

        public async Task<IActionResult> DeleteIncidentReportStatus(int Id)
        {
            var DeleteIncident = await _incidentReportStatusService.IncidentReportDeleteId(Id);
            return RedirectToAction("IncidentReportStatus","Setting");
        }
        public async Task<IActionResult> IncidentReportStatusEdit(int Id)
        {
            var IncidentEdit = await _incidentReportStatusService.IncidentReportId(Id);
            return Json(IncidentEdit.Data);
        }
        [HttpGet]
        //[Route("Setting/GetIncidentList")]
        public async Task<IActionResult> GetIncidentReportList()
        {
            PatientViewModel patientViewModel = new PatientViewModel();
            var IncidentList = await _incidentReportStatusService.PatientIncidentReport();
            patientViewModel.IncidentReportStatusList = IncidentList.Data;
            return PartialView("~/Views/Setting/SettingPartialViwe/_IncidentReportStatus.cshtml" ,patientViewModel);
        }
        #endregion Incident Report Status

        #region PatientRoleIncidentSettings
        public async Task<IActionResult> PatientRoleIncidentSetting()
        {
            PatientIncidentViewModel patientIncidentVM = new PatientIncidentViewModel();
            var data = await _patientIncident.PatientIncidentList();
            patientIncidentVM.patientIncidentList = data.Data;
            return View(patientIncidentVM);
        }
        public async Task<IActionResult> CreatePatientRoleIncidentSetting(PatientIncidentRoleBasicDto patientIncidentDto)
        {
            var data = await _patientIncident.patientIncidentRole(patientIncidentDto);
            return View();
        }

        public async Task<IActionResult> GetIncidentList()
        {
            PatientIncidentViewModel VM = new PatientIncidentViewModel();
            var data = await _patientIncident.PatientIncidentList();
            VM.patientIncidentList = data.Data;

            return PartialView("~/Views/Setting/_IncidentList.cshtml", VM);
        }

        [HttpGet]
        public async Task<IActionResult> GetEditIncidentRoleDetails(int patientIncidentRoleId)
        {
            return Json(await _patientIncident.GetEditpatientRoleIncidentDetails(patientIncidentRoleId));
        }

        public async Task<IActionResult> DeletePatientRoleIncidentSetting(int patientIncidentRoleId)
        {
            var data = await _patientIncident.DeletePatientIncident(patientIncidentRoleId);
            return Json(data);
            //return RedirectToAction("PatientRoleIncidentSetting");
        }

        #endregion

        #region claim Info
        public async Task<IActionResult> Claiminfo()
        {
            PatientViewModel patientViewModel = new PatientViewModel();
            var ClaimList = await _claimStatusService.PatientClaimStatusList();
            patientViewModel.ClaimStatusList = ClaimList.Data;
            return View(patientViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Claiminfo(PatientViewModel patientViewModel)
        {
            if (patientViewModel.claimStatusBasicDto.ClaimStatusId>0)
            {
                var update = await _claimStatusService.ClaimStatusUpdate(patientViewModel.claimStatusBasicDto);
                var Data = new { Success = "Data Update successfully" };
                return Json(Data);
            }
            else
            {
                var create = await _claimStatusService.claimStatus(patientViewModel.claimStatusBasicDto);
                var Data = new { Success = "Data Create successfully" };
                return Json(Data);
            }
        }
        public async Task<IActionResult> DeleteClaimStatus(int Id)
        {
            var DeleteClaim = await _claimStatusService.ClaimStatusDeleteId(Id);
            return RedirectToAction("Claiminfo", "Setting");
        }
        public async Task<IActionResult> EditClaimStatusbyId(int Id)
        {
            var EditClaim = await _claimStatusService.ClaimStatusGetId(Id);
            return Json(EditClaim.Data);
        }
        #endregion claim info
        
        #region patient treatment status
        public async Task<IActionResult> PatientTreatmentStatus()
        {
            SettingViewModel settingViewModel = new SettingViewModel();
            var infoList = await _patientTreatmentStatus.patientTreatmentStatus();
            settingViewModel.PatientTreatmentStatusList = infoList.Data;
            return View(settingViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> PatientTreatmentStatus(SettingViewModel settingViewModel)
        {
            if (settingViewModel.PatientTreatmentStatus.PatientTreatmentId > 0)
            {
                var PIupdate = await _patientTreatmentStatus.patientTreatmentStatusUpdate(settingViewModel.PatientTreatmentStatus);
                var data = new { Success = "Data updated successfully" };
                return Json(data);
            }
            else
            {
                var infocre = await _patientTreatmentStatus.patientTreatmentStatusCreate(settingViewModel.PatientTreatmentStatus);
                var data = new { Success = "Data saved successfully" };
                return Json(data);
            }
        }
        public async Task<IActionResult> PatientTreatmentStatusEdit(int patientTreatmentStatusId)
        {
            var PatientTreatmentStatusById = await _patientTreatmentStatus.patientTreatmentStatusGetId(patientTreatmentStatusId);
            return Json(PatientTreatmentStatusById.Data);
        }
        public async Task<IActionResult> PatientTreatmentStatusDelete(int patientTreatmentStatusId)
        {
            try
            {
                var PatientTreatmentStatusById = await _patientTreatmentStatus.patientTreatmentStatusDeleteById(patientTreatmentStatusId);
                var data = new { Success = "Data deleted successfully" };
                return Json(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion patient treatment status

        #region patient legal status
        public async Task<IActionResult> PatientLegalStatus()
        {
            SettingViewModel settingViewModel = new SettingViewModel();
            var infoList = await _patientLegalStatusService.patientlegalStatus();
            settingViewModel.PatientLegalStatusList = infoList.Data;
            return View(settingViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> PatientLegalStatus(SettingViewModel settingViewModel)
        {
            if (settingViewModel.PatientLegalStatus.PatientLegalId > 0)
            {
                var PIupdate = await _patientLegalStatusService.patientLegalStatusUpdate(settingViewModel.PatientLegalStatus);
                var data = new { Success = "Data updated successfully" };
                return Json(data);
            }
            else
            {
                var infocre = await _patientLegalStatusService.patientLegalStatusCreate(settingViewModel.PatientLegalStatus);
                var data = new { Success = "Data saved successfully" };
                return Json(data);
            }
        }
        public async Task<IActionResult> PatientLegalStatusEdit(int patientLegalStatusId)
        {
            var PatientLegalStatusById = await _patientLegalStatusService.patientLegalStatusGetId(patientLegalStatusId);
            return Json(PatientLegalStatusById.Data);
        }
        public async Task<IActionResult> PatientLegalStatusDelete(int patientLegalStatusId)
        {
            var PatientLegalStatusById = await _patientLegalStatusService.patientLegalStatusDeleteById(patientLegalStatusId);
            var data = new { Success = "Data deleted successfully" };
            return Json(data);
        }
        #endregion patient legal status

        #region patient nf2 status
        public async Task<IActionResult> PatientNF2Status()
        {
            SettingViewModel settingViewModel = new SettingViewModel();
            var infoList = await _nf2StatusService.nf2Status();
            settingViewModel.NF2StatusList = infoList.Data;
            return View(settingViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> PatientNF2Status(SettingViewModel settingViewModel)
        {
            if (settingViewModel.NF2Status.Nf2Id > 0)
            {
                var PIupdate = await _nf2StatusService.nf2StatusUpdate(settingViewModel.NF2Status);
                var data = new { Success = "Data updated successfully" };
                return Json(data);
            }
            else
            {
                var infocre = await _nf2StatusService.nf2StatusCreate(settingViewModel.NF2Status);
                var data = new { Success = "Data saved successfully" };
                return Json(data);
            }
        }
        public async Task<IActionResult> PatientNF2StatusEdit(int nf2StatusId)
        {
            var Nf2StatusById = await _nf2StatusService.nf2StatusGetId(nf2StatusId);
            return Json(Nf2StatusById.Data);
        }
        public async Task<IActionResult> PatientNF2StatusDelete(int nf2StatusId)
        {
            var Nf2StatusById = await _nf2StatusService.nf2StatusDeleteById(nf2StatusId);
            var data = new { Success = "Data deleted successfully" };
            return Json(data);
        }
        #endregion patient nf2 status

        #region patient relationship
        public async Task<IActionResult> PatientRelationship()
        {
            SettingViewModel settingViewModel = new SettingViewModel();
            var infoList = await _patientRelationshipService.patientRelationship();
            settingViewModel.PatientRelationshipList = infoList.Data;
            return View(settingViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> PatientRelationship(SettingViewModel settingViewModel)
        {
            if (settingViewModel.PatientRelationship.RelationshipId > 0)
            {
                var PIupdate = await _patientRelationshipService.patientRelationshipUpdate(settingViewModel.PatientRelationship);
                var data = new { Success = "Data updated successfully" };
                return Json(data);
            }
            else
            {
                var infocre = await _patientRelationshipService.patientRelationshipCreate(settingViewModel.PatientRelationship);
                var data = new { Success = "Data saved successfully" };
                return Json(data);
            }
        }
        public async Task<IActionResult> PatientRelationshipEdit(int patientRelationshipId)
        {
            var Nf2StatusById = await _patientRelationshipService.patientRelationshipGetId(patientRelationshipId);
            return Json(Nf2StatusById.Data);
        }
        public async Task<IActionResult> PatientRelationshipDelete(int patientRelationshipId)
        {
            var Nf2StatusById = await _patientRelationshipService.patientRelationshipDeleteById(patientRelationshipId);
            var data = new { Success = "Data deleted successfully" };
            return Json(data);
        }
        #endregion patient relationship

      
        
        [HttpPost]
        public IActionResult PatientSummarySetting(PatientSettingDto settingValues)
        {
            var userId = (long?)_sessionManager.GetUserId();
            settingValues.UserId = userId.Value;
            var result = _patientSettings.SavePatientSummaryDisplaySettings(settingValues);
            return Json(result);
        }
        [HttpPost]
        public IActionResult PatientPrintSetting(PatientPrintSettingDto settingValues)
        {
            var userId = (long?)_sessionManager.GetUserId();
            settingValues.UserId = userId.Value;
            var result = _patientSettings.SavePatientPrintSettings(settingValues);
            return Json(result);
        }
        [HttpGet]
        public IActionResult PatientListSetting()
        {
            SettingViewModel model = new SettingViewModel();
            var userId = (long?)_sessionManager.GetUserId();
            if (!(userId is null))
            {
                model.PatientListSettingDto = _patientSettings.getPatientListSettingsById((int)userId);
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult PatientListSetting(PatientListSettingDto settingValues)
        {
            var userId = (long?)_sessionManager.GetUserId();
            settingValues.UserId = userId.Value;
            var result = _patientSettings.SavePatientListDispalySettings(settingValues);
            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> PrintPreview(PatientViewModel printValues)
        {
            PatientViewModel patientViewModel = new PatientViewModel();

            var patientInfos = await _patientInfoService.GetPatientSummaryDetails(printValues.PatientPrintSettingDto.PatientId.Value);
            if (patientInfos.DateOfBirth != null)
            {
                var result = DateTime.Parse(patientInfos.DateOfBirth.ToString(), new CultureInfo("en-US")).Year;
                var age = DateTime.Today.Year - result;
                patientInfos.Age = age;
            }

            //IF relatedPatientList checkbox is checked
            if (printValues.PatientPrintSettingDto.RelatedPatientList)
            {
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
            }
            else
            {
                patientViewModel.patientListWithUsers = new List<PatientInfoListDto>();
            }

            //IF vitals or body status checkBoxes are checked
            if (printValues.PatientPrintSettingDto.BodyStatus)
            {
                patientViewModel.VitalDto = _patientVitalService.GetVitalSummaryByPatientInfoId(printValues.PatientPrintSettingDto.PatientId.Value);
            }
            else
            {
                patientViewModel.VitalDto = new Models.DTOs.VitalBasicDto.VitalDto();
            }

            //IF patient remainders checkBoxe is checked
            if (printValues.PatientPrintSettingDto.Reminder)
            {
                patientViewModel.PatientMissingsListDto = await _patientMissingService.GetPatientInfoMissingFieldsByPatientId(printValues.PatientPrintSettingDto.PatientId.Value);
            }

            patientViewModel.PatientPrintSettingDto = printValues.PatientPrintSettingDto;


            patientViewModel.patientCompleteInfo = patientInfos;
            return View(patientViewModel);
        }
       
        public IActionResult PatientSettings(long Id) 
        {
            SettingViewModel model = new SettingViewModel();
            var userId = (long?)_sessionManager.GetUserId();

            if (!(userId is null))
            {
                model.PatientSettingDto = _patientSettings.getPatientSettingsById((int)userId);
                model.PatientPrintSettingDto = _patientSettings.getPatientPrintSettingsById((int)userId);
                model.PatientListSettingDto = _patientSettings.getPatientListSettingsById((int)userId);
                model.PatientRequireFieldSettingDto = _patientSettings.GetPatientRequireFieldSettingsById();
            }
            return View(model);
        }



        public async Task<IActionResult> Attorenies()
        {

            var SettingAttorneyDto = new List<SettingAttorneyDto>();
            SettingAttorneyDto = await _SettingsAttorneyService.GetList();
            return View(SettingAttorneyDto);
        }

      

        public async Task<IActionResult> Attorney(int? Id)
        {
            SettingViewModel attorneyViewModel = new SettingViewModel();
            if (!(Id is null))
            {
                var data = await _SettingsAttorneyService.GetById((Int32)Id);
                attorneyViewModel.SettingAttorneyDto = data.Data;
                ViewBag.action = "Update";
                if (attorneyViewModel.SettingAttorneyDto is null)
                {
                    ViewBag.ProviderImage = string.Empty;

                }
                else
                {
                    ViewBag.ProviderImage = attorneyViewModel.SettingAttorneyDto.AttornyPhoto;


                }
            }
         

            return View(attorneyViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Attorney(SettingViewModel settingViewModel, string profileImage)
        {
            if (settingViewModel.SettingAttorneyDto.AttorneyId > 0)
            {
                string previousImage = settingViewModel.SettingAttorneyDto.AttornyPhoto;
                if (profileImage == "/app-assets/images/user/male-user.png")
                {
                    settingViewModel.SettingAttorneyDto.AttornyPhoto = previousImage;
                }
                else if (profileImage is null)
                {
                    settingViewModel.SettingAttorneyDto.AttornyPhoto = previousImage;
                }
                else if (profileImage == "/images/" + settingViewModel.SettingAttorneyDto.AttornyPhoto)
                {
                    settingViewModel.SettingAttorneyDto.AttornyPhoto = previousImage;
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
                    settingViewModel.SettingAttorneyDto.AttornyPhoto = ProfileImageFile;
                    pic_memStream.Close();
                }
               await _SettingsAttorneyService.UpdateSettingAttorney(settingViewModel.SettingAttorneyDto);
            }
            else
            {
                if (profileImage == "/app-assets/images/user/male-user.png")
                {
                    settingViewModel.SettingAttorneyDto.AttornyPhoto = null;
                }
                else if (profileImage is null)
                {
                    settingViewModel.SettingAttorneyDto.AttornyPhoto = null;
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
                         pic_memStream.CopyToAsync(fileSteam);
                    }
                    settingViewModel.SettingAttorneyDto.AttornyPhoto = ProfileImageFile;
                    pic_memStream.Close();
                }
               await _SettingsAttorneyService.AddSettingAttorney(settingViewModel.SettingAttorneyDto);
            }

            return RedirectToAction("Attorenies");
        }

        public async Task<IActionResult> AttorneyDelete(int Id)
        {

            var data = await _SettingsAttorneyService.Delete(Id);
          
            return RedirectToAction("Attorney", "Setting");
        }

        [HttpPost]
        public IActionResult AttorneyAdd(SettingViewModel settingViewModel)
        {
            return View();
        }
        [HttpGet]
        public IActionResult PatientRequiredFieldsInEditing()
        {
            SettingViewModel model = new SettingViewModel();
            var userId = (long?)_sessionManager.GetUserId();
            if (!(userId is null))
            {
                model.PatientRequireFieldSettingDto = _patientSettings.GetPatientRequireFieldSettingsById();
            }

            return View(model);
        }
        [HttpPost]
        public IActionResult PatientRequiredFieldsInEditing(PatientRequireFieldSettingDto requireValues)
        {
            var userId = (long?)_sessionManager.GetUserId();
            requireValues.UserId = userId.Value;
            var result = _patientSettings.SavePatientRequireSettings(requireValues);
            return Json(result);
        }
        public IActionResult PatientEmergencyContact()
        {
            return View();
        }
        public IActionResult PatientLoginandSecurity()
        {
            return View();
        }




        #region Provider Settings
        public IActionResult ProviderSettings(long Id)
        {
            SettingViewModel model = new SettingViewModel();
            var userId = (long?)_sessionManager.GetUserId();

            if (!(userId is null))
            {
                //model.PatientSettingDto = _patientSettings.getPatientSettingsById((int)userId);
                //model.PatientPrintSettingDto = _patientSettings.getPatientPrintSettingsById((int)userId);
                model.ProviderListSettingDto = _providerSettingsService.getProviderListSettingsById((int)userId);
                //model.PatientRequireFieldSettingDto = _patientSettings.GetPatientRequireFieldSettingsById();
            }
            return View(model);
        }


        [HttpPost]
        public IActionResult SaveProviderListSettings(ProviderListSettingDto settingValues)
        {
            var userId = (long?)_sessionManager.GetUserId();
            settingValues.UserId = userId.Value;
            var result = _providerSettingsService.SaveProviderListSettings(settingValues);
            return Json(result);
        }
        [HttpPost]
        public IActionResult SaveProviderSummarySettings(ProviderSummarySettingsDto printSettingValues)
        {
            var userId = (long?)_sessionManager.GetUserId();
            printSettingValues.UserId = userId.Value;
            printSettingValues.FirstName = false;
            printSettingValues.LastName = false;
           
            printSettingValues.Email = false;
            printSettingValues.MobileNo = false;
            printSettingValues.AssignRoomNo = false;
            printSettingValues.FaxNo = false;
            printSettingValues.TaxId = false;


            var result = _providerSettingsService.SaveProviderSummarySettings(printSettingValues);
            return Json(result);
        }

        public async Task<IActionResult> ProviderSessionSettings()
        {
            ProviderSessionTypeDto sessionTypeDto = new ProviderSessionTypeDto();
            sessionTypeDto.providerSessionTypeList = await _providerSettingsService.GetAllSessionSettings();
            return View(sessionTypeDto);
        }

        public IActionResult SaveProviderSessionSettings(ProviderSessionTypeDto dto)
        {
            var userId = _sessionManager.GetUserId();

            return Json(_providerSettingsService.AddProviderSessionSettings(dto, userId));
        }

        public async Task<IActionResult> GetProviderSessionSettings()
        {
            return Json(await _providerSettingsService.GetAllSessionSettings());
        }

        public async Task<IActionResult> DeleteSessionSettings(long providerSessionId)
        {
            return Json(await _providerSettingsService.DeleteSessionSettings(providerSessionId));
        }
        #endregion

    }
}