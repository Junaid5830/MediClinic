using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediClinic.Controllers
{
    public class DriverAttendanceAlertController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


    }
}
