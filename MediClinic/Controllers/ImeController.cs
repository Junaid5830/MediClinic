using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediClinic.Models;
using MediClinic.Services.Interfaces.IMEInterface;
using MediClinic.Services.Interfaces.SessionManager;
using Microsoft.AspNetCore.Mvc;

namespace MediClinic.Controllers
{
    public class ImeController : Controller
    {
        private ISessionManager _sessionManager;
        private IimeInterface _iimeInterface;
        private IMEViewModel ImeViewModel;

        public ImeController(ISessionManager sessionManager, IimeInterface iimeInterface)
        {
            _sessionManager = sessionManager;
            _iimeInterface = iimeInterface;
            ImeViewModel = new IMEViewModel();
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> IMEList(long? Id)
        {
            var roleId = _sessionManager.GetRoleId();
            var PatientId = _sessionManager.GetPatientInfoId();
            if (roleId == 1)
            {
                ImeViewModel.getimeList = await _iimeInterface.GetIMEListByVisits(PatientId);

            }
            else
            {
                if (PatientId == 0)
                {
                    var List = await _iimeInterface.GetImeList();
                    ImeViewModel.getimeList = List.Data;
                }
                else
                {
                    ImeViewModel.getimeList = await _iimeInterface.GetIMEListByVisits(PatientId);
                }
            }
            return View(ImeViewModel);
        }
        public IActionResult AddIME(int? Id)
        {
            if (!(Id is null))
            {
                ImeViewModel.imeDto = _iimeInterface.GetIMEById((int)Id);

            }

            return View(ImeViewModel);
        }
        [HttpPost]
        public IActionResult AddIME(IMEViewModel ImeModel)
        {
            var VisitID = _sessionManager.GetVisitId();
            ImeModel.imeDto.VisitId = VisitID;
            _iimeInterface.Add(ImeModel.imeDto);
            var PatientId = _sessionManager.GetPatientInfoId();
            return RedirectToAction("IMEList", "IME", new { Id = PatientId });
        }
        public IActionResult ImeDelete(int Id)
        {
            var PatById = _iimeInterface.Delete(Id);
            //return RedirectToAction("PatientList", "PatientSide");
            return Json(PatById);
        }
    }
}
