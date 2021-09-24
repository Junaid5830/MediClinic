using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediClinic.Filters;
using MediClinic.Models;
using MediClinic.Services.Interfaces.ClinicalNotesInterface;
using MediClinic.Services.Interfaces.LookupInteface;
using MediClinic.Services.Interfaces.SessionManager;
using MediClinic.Services.Interfaces.Template;
using MedliClinic.Utilities.Utility.Enum;
using Microsoft.AspNetCore.Mvc;

namespace MediClinic.Controllers
{
    //[AuthFilter(RoleNames.Doctor,RoleNames.Admin)]

    public class ClinicalNoteController : Controller
    {
        private ISessionManager _sessionManager;
        private IClinicalNoteInterface _clinicalNoteService;
        private ILookupService _lookupService;

        private ITemplateService _templateService;

        public ClinicalNoteController(ISessionManager sessionManager, IClinicalNoteInterface clinicalNoteInterface, 
            ILookupService lookupService, ITemplateService templateService)
        {
            _sessionManager = sessionManager;
            _clinicalNoteService = clinicalNoteInterface;
            _lookupService = lookupService;
            _templateService = templateService;
        }
       
        [HttpGet]
        public async Task<IActionResult> ClinicalNotes(int? clinicalNoteId, bool isEditable)
        {
            ClinicalViewModel model = new ClinicalViewModel();

            if (!(clinicalNoteId is null))
            {
                ViewBag.ActionType = "Update";
                model.ClinicalNoteDto = _clinicalNoteService.GetClinicalNoteById(clinicalNoteId.Value);
                if (!(model.ClinicalNoteDto is null) && model.ClinicalNoteDto.NoteType == 49)
                {
                    ViewBag.IsVoiceToTextRecord = true;
                }
            }
            else
            {
                ViewBag.ActionType = "Save";
            }
            ViewBag.IsEditable = isEditable;
            model.NoteTypes = _lookupService.GetClinicalNotelist("NoteType");
            model.ICDList = await _clinicalNoteService.GetAllICDCodes(true);

            return View(model);
        }


        [HttpPost]
        public IActionResult ClinicalNotes(ClinicalViewModel model)
        {
            var patientId = _sessionManager.GetPatientInfoId();
            var notesWriterId = _sessionManager.GetProviderInfoId();
            var VisitId = _sessionManager.GetVisitId();
            model.ClinicalNoteDto.NoteDate = DateTime.Now;
            model.ClinicalNoteDto.PatientId = patientId;
            model.ClinicalNoteDto.NoteBy = notesWriterId;
            model.ClinicalNoteDto.IsActive = true;
            model.ClinicalNoteDto.VisitId = VisitId;
            if (model.ClinicalNoteDto.ClinicalNoteId > 0)
            {
                _clinicalNoteService.UpdateROS(model.ClincalROSDto);
                _clinicalNoteService.UpdateHistoryOfIllness(model.HistoryOfillnessDto);
                _clinicalNoteService.UpdateClinicalNote(model.ClinicalNoteDto);
            }
            else
            {
                //var historyId = _clinicalNoteService.CreateHistoryOfIllness(model.HistoryOfillnessDto);
                //var rosId = _clinicalNoteService.CreateROS(model.ClincalROSDto);
                //if (rosId > 0)
                //{
                //    model.ClinicalNoteDto.RosId = rosId;
                //}
                //if (historyId > 0)
                //{
                //    model.ClinicalNoteDto.HistoryOfIllnessId = historyId;
                //}

                _clinicalNoteService.CreateClinicalNote(model.ClinicalNoteDto);
            }

            return RedirectToAction("ClinicalNotesList",new { Id = patientId });
        }

        public IActionResult GetNoteTypes()
        {
            var data = _lookupService.GetClinicalNotelist("NoteType");
            return Json(data);
        }

        public IActionResult DeleteClinicalNotes(int clinicalNoteId)
        {
            var result = _clinicalNoteService.DeleteClinicalNotes(clinicalNoteId);
            return Json(result);
        }

        public async Task<IActionResult> ClinicalNotesList(long? Id)
        {
            //ClinicalViewModel model = new ClinicalViewModel();
            TemplateViewModal templateViewModal = new TemplateViewModal();

            var PatientId = _sessionManager.GetPatientInfoId();
            templateViewModal.GetAllTemplate = await _templateService.TemplateListForPatient(PatientId);

            //model.ClinicalNotesList = _clinicalNoteService.GetClinicalNoteList(patientId);
            //model.ClinicalNotesList = await _clinicalNoteService.ClinicalNoteListByVisit((long)Id);
            ViewBag.clinicalnotes = "nav-active";
            return View(templateViewModal);
        }

        public async Task<IActionResult> MarkNoteAsSigned(string electronicPass, int clinicalNoteId)
        {
            var providerId = _sessionManager.GetProviderInfoId();
            var result = await _clinicalNoteService.IsPasswordMatched(electronicPass, providerId);
            if (result)
            {
                await _clinicalNoteService.SignedNote(clinicalNoteId);
            }
            return Json(result);
        }

        public IActionResult ClinicalListData(long patientId)
        {
            ClinicalViewModel model = new ClinicalViewModel();
            model.ClinicalNotesList = _clinicalNoteService.GetClinicalNoteList(patientId);

            return PartialView("~/Views/ClinicalNote/_ClinicalListPartialView.cshtml",model);
        }
        public async Task<IActionResult> CLinicVisitDetail(int Id)
        {
            TemplateViewModal templateViewModal = new TemplateViewModal();
            templateViewModal.TemplateList = await _templateService.TemplateDetailForPatient(Id);
            var PatientId = _sessionManager.GetPatientInfoId();

            templateViewModal.GetAllTemplate = await _templateService.TemplateListForPatient(PatientId);

            return PartialView("~/Views/ClinicalNote/_ClinicVisitDetail.cshtml", templateViewModal);

        }
    }
}