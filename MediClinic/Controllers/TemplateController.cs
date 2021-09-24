using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediClinic.Models;
using MediClinic.Models.DTOs;
using MediClinic.Services.Interfaces.ProviderInfoInterface;
using MediClinic.Services.Interfaces.SessionManager;
using MediClinic.Services.Interfaces.Template;
using Microsoft.AspNetCore.Mvc;

namespace MediClinic.Controllers
{
    public class TemplateController : Controller
    {
        private ITemplateService _templateService;
        private ISessionManager _sessionManager;
        private IProviderInfoService _providerInfoService;

        public TemplateController(ITemplateService templateService, IProviderInfoService providerInfoService, ISessionManager sessionManager)
        {
            _templateService = templateService;
            _sessionManager = sessionManager;
            _providerInfoService = providerInfoService;
        }

        [HttpGet]
        public async Task<IActionResult> Template()
        {
            TemplateViewModal vm = new TemplateViewModal();
            vm.GetAllTemplate = await _templateService.getlist();
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Template(TemplateDTO TemplateDTO)
        {
            TemplateViewModal vm = new TemplateViewModal();
            bool status = await _templateService.Add(TemplateDTO);            
            vm.GetAllTemplate = await _templateService.getlist();
            return PartialView("_Template", vm);            
        }
        [HttpGet]
        public async Task<IActionResult> EditTemplate(int Id)
        {
            TemplateViewModal vm = new TemplateViewModal();
            TemplateDTO TemplateDTO = await _templateService.GetTemplate(Id);
            return Json(TemplateDTO);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteTemplate(int Id)
        {
            TemplateViewModal vm = new TemplateViewModal();
            Error error = await _templateService.DeleteTemplate(Id);
            if(error.Status == true)
            {
                return Json(error);
            }
            vm.GetAllTemplate = await _templateService.getlist();
            return PartialView("_Template", vm);
        }
        [HttpGet]
        public async Task<IActionResult> CreateTemplate()
        {
            TemplateViewModal vm = new TemplateViewModal();
            vm.GetAllTemplate = await _templateService.getlist();
            return View(vm);
        }
        [HttpGet]
        public async Task<IActionResult> GetTemplateComponent(int TemplateId)
        {
            TemplateViewModal vm = new TemplateViewModal();
            vm.GetComponentList = await _templateService.GetComponentList(TemplateId);
            return PartialView("_CreateTemplate", vm);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTemplate(TemplateComponentDTO TemplateComponentDTO, List<TemplateComponentDetailDTO> TemplateComponentDetailDTO)
        {
            TemplateViewModal vm = new TemplateViewModal();
            bool status = await _templateService.CreateComponent(TemplateComponentDTO, TemplateComponentDetailDTO);
            vm.GetComponentList = await _templateService.GetComponentList(TemplateComponentDTO.TemplateId);
            return PartialView("_CreateTemplate", vm);
        }

        [HttpGet]
        public async Task<IActionResult> DoctorTemplate(int? Id)
        {
            var DoctorId = _sessionManager.GetProviderInfoId();
            var RoleId = _sessionManager.GetRoleId();
            TemplateViewModal vm = new TemplateViewModal();

            if (RoleId == 2)
            {
                var providerData = await _providerInfoService.GetProviderSummaryDetails(DoctorId);
                ViewBag.DoctorName = providerData.FullName;
            }
            else
            {
                vm.ProviderList = await _providerInfoService.GetProviderList();

            }


            vm.GetAllTemplate = await _templateService.getlist();
            int doctorId = Convert.ToInt32(_sessionManager.GetEmployeeId());
            vm.GetDoctorTemplateList = await _templateService.GetDoctorTemplateList((int)DoctorId);
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> DoctorTemplate(DoctorTemplateDTO DoctorTemplateDTO)
        {
            TemplateViewModal vm = new TemplateViewModal();
            int doctorId = Convert.ToInt32(_sessionManager.GetEmployeeId());
            if (DoctorTemplateDTO.DoctorId == 0)
            {
                DoctorTemplateDTO.DoctorId = (int)_sessionManager.GetProviderInfoId();
            }
            bool status = await _templateService.DoctorTemplate(DoctorTemplateDTO);            
            vm.GetDoctorTemplateList = await _templateService.GetDoctorTemplateList(DoctorTemplateDTO.DoctorId);
            return PartialView("_DoctorTemplate", vm);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteControl(int Id, int TemplateId)
        {
            TemplateViewModal vm = new TemplateViewModal();
            Error error = await _templateService.DeleteControl(Id);
            if (error.Status == true)
            {
                return Json(error);
            }
            vm.GetComponentList = await _templateService.GetComponentList(TemplateId);
            return PartialView("_CreateTemplate", vm);
        }
        [HttpGet]
        public async Task<IActionResult> EditControl(int Id, int TemplateId)
        {
            TemplateViewModal vm = new TemplateViewModal();
            List<TemplateComponentDTO> TemplateComponentDTO = await _templateService.GetComponentList(TemplateId);
            List<TemplateComponentDTO> TemplateComponentDTORtn = TemplateComponentDTO.Where(a => a.Id == Id).ToList();
            return Json(TemplateComponentDTORtn);
        }        
        [HttpGet]
        public async Task<IActionResult> DoctorPatientTemplate(int? TemplateId, int? DoctorId, int? PatientId, int? VisitId)
        {
            TemplateViewModal vm = new TemplateViewModal();
            var PatId = _sessionManager.GetPatientInfoId();
            var VId = _sessionManager.GetVisitId();
            var DocId = _sessionManager.GetProviderInfoId();
            ViewBag.PatientId = PatId;
            ViewBag.VisitId = VId;
            vm.GetDoctorPatientTemplateList = await _templateService.GetDoctorPatientTemplate((int)TemplateId, (int)DocId, (int)PatId, VId);
            vm.patientInfoBasicDtos = await _templateService.GetlistofPatients();
            vm.patientInfoBasicDtos = await _templateService.GetlistofVisitCreatedPatients();
            vm.ICDList = await _templateService.GetAllICDCodes(true);

            return View(vm);
        }
        [HttpGet]
        public async Task<IActionResult> GetVisitByPatientId(int patientId)
        {
          VisitsDto visitsDto = await _templateService.GetVisitByPatientId(patientId);
            return Json(visitsDto);
        }
        [HttpPost]
        public async Task<IActionResult> DoctorPatientTemplate(List<DoctorPatientTemplateDTO> DoctorPatientTemplateDTO, int PatientId)
        {
            var VistId = _sessionManager.GetVisitId();
            bool status = await _templateService.DoctorPatientTemplate(DoctorPatientTemplateDTO, PatientId, VistId);
            return Json(status);
        }
        public async Task<IActionResult> CheckICD10(int Id)
        {
            var isExistdata = await _templateService.CheckICD10Exist(Id);
            
            var message = new { Success = isExistdata.Message, IsError = true };
            return Json(message);
        }
    }
}
