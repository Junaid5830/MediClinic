using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MediClinic.Controllers
{
    public class ADTController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ADTApproval()
        {
            return View();
        }
    }
}
