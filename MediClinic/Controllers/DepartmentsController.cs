using MediClinic.Models.DTOs;
using MediClinic.Services.Interfaces.DepartmentsInterface;
using MediClinic.Services.Interfaces.SessionManager;
using MediClinic.Services.Services.DepartmentsService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediClinic.Controllers
{
    public class DepartmentsController : Controller
    {

        private readonly ILogger<DepartmentsController> _logger;
        private ISessionManager _sessionManager;
        private IDepartmentsService _DepartmentsService;

        public DepartmentsController(
            ILogger<DepartmentsController> logger,
            ISessionManager sessionManager,
            IDepartmentsService departmentsService
            )
        {
            _logger = logger;
            _sessionManager = sessionManager;
            _DepartmentsService = departmentsService;
        }

        public ILogger<DepartmentsController> Logger => _logger;
        public IActionResult Index()
        {
            List<DepartmentsDto> list = new List<DepartmentsDto>();
            list = _DepartmentsService.getlist();
            return View(list);
        }
        public IActionResult Add(int id)
        {
            DepartmentsDto departments = _DepartmentsService.GetDepartmentsById(id);
            return View(departments);
        }
        [HttpPost]
        public IActionResult Add(DepartmentsDto Pobj)
        {
            _DepartmentsService.Add(Pobj);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int depId)
        {
            var Id = _DepartmentsService.Delete(depId);
            return Redirect("Index");
        }
        public IActionResult DepartmentDutyroster()
        {
            return View();
        }
        public IActionResult Departments()
        {
            return View();
        }
        public IActionResult StaffDuty()
        {
            return View();
        }
    }
}
