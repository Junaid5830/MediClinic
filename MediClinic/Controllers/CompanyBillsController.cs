using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediClinic.Models;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.CompanyBillsInterface;
using MediClinic.Services.Interfaces.ImagingInterface;
using MediClinic.Services.Interfaces.SessionManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MediClinic.Controllers
{
    public class CompanyBillsController : Controller
    {
        private readonly ILogger<CompanyBillsController> _logger;
        private ISessionManager _sessionManager;
        private ICompanyBillsServices _companyBillsServices;
        private CompanyBillsViewModel companyBillsViewModel;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly MediClinicContext _context;

        public CompanyBillsController(
            ILogger<CompanyBillsController> logger,
            ISessionManager sessionManager, ICompanyBillsServices companyBillsServices , MediClinicContext context,
            IHttpContextAccessor contextAccessor
            )
        {
            _logger = logger;
            _sessionManager = sessionManager;
            _companyBillsServices = companyBillsServices;
            companyBillsViewModel = new CompanyBillsViewModel();
            _context = context;
            _contextAccessor = contextAccessor;
        }
        public IActionResult BillList()
        {
            companyBillsViewModel.companyBillsList = _companyBillsServices.GetBillsList();
            return View(companyBillsViewModel);
        }
        public IActionResult Add(int id)
        {
            companyBillsViewModel.companyBillsDto = _companyBillsServices.GetBillById(id);
            return View(companyBillsViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Add(CompanyBillsViewModel companyBillsViewModel)
        {
            await _companyBillsServices.Add(companyBillsViewModel.companyBillsDto);
            return Redirect("BillList");
        }
        public IActionResult Delete(int legalId)
        {
            var Id = _companyBillsServices.Delete(legalId);
            return Redirect("Index");
        }
    }
}
