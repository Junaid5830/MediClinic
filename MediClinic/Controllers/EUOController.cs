using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediClinic.Models;
using MediClinic.Models.DTOs;
using MediClinic.Services.Interfaces.EUOInterface;
using MediClinic.Services.Interfaces.LookupInteface;
using MediClinic.Services.Interfaces.SessionManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MediClinic.Controllers
{
    public class EUOController : Controller
    {
        private readonly ILogger<EUOController> _logger;
        private ISessionManager _sessionManager;
        private IEUOService _euoService;
        private ILookupService _lookupService;
        private EUOViewModel viewModel;
        public EUOController(
            ILogger<EUOController> logger,
            ISessionManager sessionManager,
            ILookupService lookupService,
            IEUOService euoService
            )
        {
            _logger = logger;
            _sessionManager = sessionManager;
            _euoService = euoService;
            _lookupService = lookupService;
            viewModel = new EUOViewModel();
        }
        [HttpGet]
        public async Task<IActionResult> Index(int? Id)
        {
            var RoleId = _sessionManager.GetRoleId();
            var PatientId = _sessionManager.GetPatientInfoId();
            if (RoleId == 1)
            {
                viewModel.EUODtoList = await _euoService.GetEUOByPatientId(PatientId);
            }
            else
            {
                if (PatientId == 0)
                {
                   
                    viewModel.EUODtoList = _euoService.GetEUO();
                }
                else
                {
                    viewModel.EUODtoList = await _euoService.GetEUOByPatientId(PatientId);

                }
            }
            return View(viewModel);
        }


        [HttpGet]
        public IActionResult Add(int? EUOId)
        {
            if (EUOId != 0)
            {
                viewModel.EUODto = _euoService.GetEUOById(Convert.ToInt32(EUOId));
            }
            var placeList = _lookupService.lookupByTypeBasicDto("Place");
            viewModel.PlaceList = placeList.Data;
            var representedByList = _lookupService.lookupByTypeBasicDto("RepresentedBy");
            viewModel.RepresentedByList = representedByList.Data;
            var statusList = _lookupService.lookupByTypeBasicDto("Status");
            viewModel.StatusList = statusList.Data;
            var reasonList = _lookupService.lookupByTypeBasicDto("Reason");
            viewModel.ReasonList = reasonList.Data;
            var transcriptList = _lookupService.lookupByTypeBasicDto("Transcript");
            viewModel.TranscriptsList = transcriptList.Data;

            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Delete(int EUOId)
        {
            var Id =  _euoService.Delete(EUOId);
            return Json(Id);
        }
        [HttpPost]
        public async Task<IActionResult> Add(EUODto euoDto)
        {
            var PatientId = _sessionManager.GetPatientInfoId();
            await _euoService.Add(euoDto);
            viewModel.EUODtoList = await _euoService.GetEUOByPatientId(PatientId);
            return RedirectToAction("Index",new { Id=PatientId });
        }
    }
}
