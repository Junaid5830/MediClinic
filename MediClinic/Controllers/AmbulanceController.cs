using MediClinic.Models;
using MediClinic.Services.Interfaces.SessionManager;
using MediClinic.Services.Interfaces.TransportEmsInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediClinic.Controllers
{
    public class AmbulanceController : Controller
    {
        private readonly ILogger<AmbulanceController> _logger;
        private ISessionManager _sessionManager;
        private ITransportEmsService _TransportEmsService;
        public AmbulanceController(ILogger<AmbulanceController> logger,
            ISessionManager sessionManager,
            ITransportEmsService TransportEmsService)
        {
            _logger = logger;
            _sessionManager = sessionManager;
            _TransportEmsService = TransportEmsService;
        }
        public ILogger<AmbulanceController> Logger => _logger;
        public async Task<IActionResult> Index(int? Id)
        {
            AmbulanceAssignViewModel ambulanceAssignViewModel = new AmbulanceAssignViewModel();
            ambulanceAssignViewModel.availabeAmbulances = await _TransportEmsService.AvailabeAmbulance();
            //ambulanceAssignViewModel.DriversList = _TransportEmsService.SelectDriversForDropDow();

            return View(ambulanceAssignViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> AssignDriverToAddress(AmbulanceAssignViewModel ambulanceAssignViewModel)
        {
            var rec = await _TransportEmsService.AssignDriverToPickUpPoint(ambulanceAssignViewModel.driverJobRequestDto,string.Empty);
            ambulanceAssignViewModel.availabeAmbulances = await _TransportEmsService.AvailabeAmbulance();
            //ambulanceAssignViewModel.DriversList = _TransportEmsService.SelectDriversForDropDow();

            return PartialView("~/Views/Ambulance/PartialView/_AvailableDriver.cshtml", ambulanceAssignViewModel);
        }


        public IActionResult TrackAmbulance()
        {
            return View();
        }


        public async Task<IActionResult> AmbulanceAssign(int? Id)
        {
            var ambulanceAssignViewModel = new AmbulanceAssignViewModel();
            ambulanceAssignViewModel.ListAmbulanceDrivers = await _TransportEmsService.GetListOfDriverWithAssignedAmbulance();
            ambulanceAssignViewModel.AmbulanceList = _TransportEmsService.SelectAmbulacesForDropDow();
            //ambulanceAssignViewModel.DriversList = _TransportEmsService.SelectDriversForDropDow();
            return View(ambulanceAssignViewModel);
        }


        [HttpPost]
        public async Task<IActionResult> AmbulanceAssign(AmbulanceAssignViewModel ambulanceAssignViewModel)
        {
            if (ambulanceAssignViewModel.AmbulanceAssignDriver.Id == 0)
            {
                var IsAlreadyAssigned = await _TransportEmsService.AlreadyAssignedAmbulanceDriver(ambulanceAssignViewModel.AmbulanceAssignDriver);
                if (IsAlreadyAssigned.Data)
                {
                    var result = new { Messages = IsAlreadyAssigned.Message };
                    return Json(result);
                }
            }
          
            var response = await _TransportEmsService.AssignAmbulanceToDriver(ambulanceAssignViewModel.AmbulanceAssignDriver);
            var data = new { Messages = response.Message, Result = response.Data };
            return Json(data);
            
        }


        public async Task<IActionResult> DeleteAssigneAmbulance(int Id)
        {
             await  _TransportEmsService.DeleteAssignedAmbulance(Id);
            var data = new { Mesages = "Delete Successfully" };
            return Json(data);
        }

        public async Task<IActionResult> GetById(int Id)
        {
            var response = await _TransportEmsService.GetByIdAssignedAmbulance(Id);

            var data = new { Message = "Successfull" , Data=response.Data };
            return Json(data);
        }

    }
}
