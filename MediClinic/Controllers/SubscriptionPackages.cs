using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediClinic.Models;
using MediClinic.Services.Interfaces.SubscriptionPackageInterface;
using Microsoft.AspNetCore.Mvc;

namespace MediClinic.Controllers
{
    public class SubscriptionPackages : Controller
    {
        private ISubscriptionPackageService _subscriptionPackageService;

        public SubscriptionPackages(ISubscriptionPackageService subscriptionPackageService)
        {
            _subscriptionPackageService = subscriptionPackageService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreatePackage(int? Id)
        {
            PackageViewModel package = new PackageViewModel();
            if (package.subsriptionPackageDto != null)
            {
                if (package.subsriptionPackageDto.UserLimit != null)
                {
                    ViewBag.UserLimit = true;
                }
            }

            else
            {
                ViewBag.UserLimit = string.Empty;
            }
            return View(package);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePackage(PackageViewModel packageViewModel)
        {
            var data =await _subscriptionPackageService.CreateSubScription(packageViewModel.subsriptionPackageDto);
            return RedirectToAction("CreatePackage");
        }
    }
}
