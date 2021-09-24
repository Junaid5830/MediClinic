using MediClinic.Models;
using MediClinic.Services.Interfaces.InsuranceCompaniesInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediClinic.Controllers
{
    public class InsuranceCompaniesController : Controller
    {
        private readonly ILogger<InsuranceCompaniesController> _logger;
        private IInsuranceCompanies _insuranceCompaniesService;
        public InsuranceCompaniesController(ILogger<InsuranceCompaniesController> logger,IInsuranceCompanies insuranceCompanies)
        {
            _logger = logger;
            _insuranceCompaniesService = insuranceCompanies;
        }
        public async Task<IActionResult> Index()
        {
            var viewModel = new InsuranceCompaniesViewModel();
            var lisData = await _insuranceCompaniesService.GetListOfCompanies();
            if (lisData.Data != null)
            {
                viewModel.InsuranceCompaniesList = lisData.Data;
            }
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewCompany(InsuranceCompaniesViewModel insuranceCompaniesViewModel)
        {
            var response= await _insuranceCompaniesService.AddUpdateCompany(insuranceCompaniesViewModel.InsuranceCompany);
            var data = new { Company =response.Data};
            return Json(data);
        }

        public async Task<IActionResult> GetById(int Id)
        {
            var response = await _insuranceCompaniesService.GetCompanyById(Id);
            var data = new { Company = response.Data };
            return Json(data);
        }
        public async Task<IActionResult> Delete(int Id)
        {
           var response= await _insuranceCompaniesService.DeleteCompany(Id);
            var data = new { IsDelete = response.Data };
            return Json(data);
        }
    }
}
