using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediClinic.Models;
using MediClinic.Models.DTOs;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.SessionManager;
using MediClinic.Services.Interfaces.SoapNotesInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace MediClinic.Controllers
{
    public class SoapNotes : Controller
    {
        private readonly ILogger<SoapNotes> _logger;
        private ISessionManager _sessionManager;
        private ISoapNotesService _soapNotesService;

        public SoapNotes(ILogger<SoapNotes> logger, ISessionManager sessionManager, ISoapNotesService soapNotesService)
        {
            _logger = logger;
            _sessionManager = sessionManager;
            _soapNotesService = soapNotesService;
        }
       
        public  IActionResult SoapNotesList(int? Id)
        {
            var list = _soapNotesService.SoapNotesList();

            ViewBag.result = list;
            return View(list);

        }
        public async Task<IActionResult> AddSoapNotes(int? Id)
        {
            SoapNotesViewModal soapViewModal = new SoapNotesViewModal();
            soapViewModal.ICDList =await _soapNotesService.ICDCodeList(true);
            List<string> Names = new List<string>();

            if (soapViewModal.ICDList.Count > 0)
            {
                Names = soapViewModal.ICDList.Select(x => x.Name).Take(500).ToList();
                soapViewModal.ICDNameList = Names;
            }
            return View(soapViewModal);
        }
        [HttpPost]
        public async Task<IActionResult> AddSoapNotes(string surveyText)
        {
            SoapNotesViewModal soapViewModal = new SoapNotesViewModal();
            soapViewModal.soapNotesBasicDto.SurveyTest = surveyText;
            await _soapNotesService.SoapNotesCreate(soapViewModal.soapNotesBasicDto);
            var Data =  "Sucessfull" ;
            return Json(Data);
        }

        public async Task<IActionResult> EditSoapNotes(int? Id)
        {
            SoapNotesViewModal soapViewModal = new SoapNotesViewModal();
            var Rec = await _soapNotesService.SoapNotesById((int)Id);
            ViewBag.result = Rec.Data;
            return View(Rec);
        }
        [HttpPost]
        public async Task<IActionResult> EditSoapNotes(string surveyText,int? Id)
        {
            SoapNotesViewModal soapViewModal = new SoapNotesViewModal();
            

            soapViewModal.soapNotesBasicDto.SurveyNoteId = (int)Id;
            soapViewModal.soapNotesBasicDto.SurveyTest = surveyText;
            var Rec = await _soapNotesService.SoapNotesUpdate(soapViewModal.soapNotesBasicDto);
            ViewBag.result = Rec.Data;
            var Data = "Sucessfull";
            return Json(Data);
        }
        public async Task<IActionResult> SoapNotesDelete(int Id)
        {
            var PatById = await _soapNotesService.SoapNotesDeleteById(Id);
            //return RedirectToAction("PatientList", "PatientSide");
            return Json(PatById.Data);
        }
        public async  Task<IActionResult> SoapNoteSurvay(int? Id)
        {
            var Rec = await _soapNotesService.SoapNotesById((int)Id);
            ViewBag.result = Rec.Data;
            return View(Rec);
        }
      
    }
}
