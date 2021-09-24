using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediClinic.Models;
using MediClinic.Services.Interfaces.Patient;
using MediClinic.Services.Interfaces.TransportEmsInterface;
using MedliClinic.Utilities.Utility.Enum;
using Microsoft.AspNetCore.Mvc;

namespace MediClinic.Controllers
{
    public class ClinicOverViewController : Controller
    {
        private IPatientService _patientService;
        private ITransportEmsService _TransportEmsService;

        public ClinicOverViewController(IPatientService patientService, ITransportEmsService transportEmsService)
        {
            _patientService = patientService;
            _TransportEmsService = transportEmsService;
        }
        public async Task<IActionResult> Index(long? DriverId)
        {
            ClinicalViewModel viewModel = new ClinicalViewModel();
            viewModel.Clinicviewcount = _patientService.GetClinicView();

            //Not assigned job yet, only get current location
            var response = await _TransportEmsService.DriverCurrentLocationForMap(DriverId);
            //Assigned jobs of driver location
            var DirectRec = await _TransportEmsService.DriverDirectionForMap(DriverId);
            ViewBag.MapDirection = DirectRec.Data;
            ViewBag.MapMarkLocationOfDriver = response.Data;
            return View(viewModel);
        }
    }
}
