using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediClinic.Models.DTOs;
using MediClinic.Services.Interfaces.EUOInterface;
using MediClinic.Services.Interfaces.LookupInteface;
using MediClinic.Services.Interfaces.PharmacyInterface;
using MediClinic.Services.Interfaces.SessionManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MediClinic.Controllers
{
    public class PharmacyController : Controller
    {
        private readonly ILogger<PharmacyController> _logger;
        private ISessionManager _sessionManager;
        private IPharmacyService _pharmacyservice;

        

        public PharmacyController(
            ILogger<PharmacyController> logger,
            ISessionManager sessionManager,
            IPharmacyService pharmacyservice
            )
            {
                _logger = logger;
                _sessionManager = sessionManager;
                _pharmacyservice = pharmacyservice;
            }

        public ILogger<PharmacyController> Logger => _logger;


        public async Task<IActionResult> Index() 
        {
            try
            {
                List<PharmacyDto> list = new List<PharmacyDto>();
                list = await _pharmacyservice.getlist();

                return View(list);
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        
        }


        [HttpGet]
        public IActionResult Add(int id)
        {
            try
            {
                PharmacyDto pharmacy = _pharmacyservice.GetPharById(id);
                return View(pharmacy);
            }
            catch (Exception ex) 
            {
                throw ex;
            }
            
        }
        [HttpPost]
        public async Task<IActionResult> Add(PharmacyDto Pobj)
        {
            await _pharmacyservice.Add(Pobj);
            //var list = await _pharmacyservice.getlist();
            return Redirect("Index");
        }

        public IActionResult Delete(int pharId)
        {
            var Id = _pharmacyservice.Delete(pharId);
            return Json(Id);
        }

    }
}
