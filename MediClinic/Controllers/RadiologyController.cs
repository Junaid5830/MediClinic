using MediClinic.Models.DTOs;
using MediClinic.Services.Interfaces.RadiologyInterface;
using MediClinic.Services.Interfaces.SessionManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediClinic.Controllers
{
    public class RadiologyController : Controller
    {
        private readonly ILogger<RadiologyController> _logger;
        private ISessionManager _sessionManager;
        private IRadiologyService _radiologyService;



        public RadiologyController(
            ILogger<RadiologyController> logger,
            ISessionManager sessionManager,
            IRadiologyService radiologyService
            )
        {
            _logger = logger;
            _sessionManager = sessionManager;
            _radiologyService = radiologyService;
        }

        public ILogger<RadiologyController> Logger => _logger;


        public IActionResult Index()
        { 
            
            List<RadiologyDto> list = new List<RadiologyDto>();
            list =  _radiologyService.getlist();
            return View(list);
            
            
        }
        [HttpGet]
        public IActionResult Add(int id)
        {
            RadiologyDto radiology = _radiologyService.GetRadiolById(id);
            return View(radiology);
        }

        [HttpPost]
        public  IActionResult Add(RadiologyDto Pobj)
        {
               _radiologyService.Add(Pobj);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int RadiolId)
        {
            var Id = _radiologyService.Delete(RadiolId);
            return Json(Id);
        }
    }
}
