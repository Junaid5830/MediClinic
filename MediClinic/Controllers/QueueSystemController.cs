using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MediClinic.Controllers
{
    public class QueueSystemController : Controller
    {
        public IActionResult PatientQueue()
        {
            return View();
        }
    }
}