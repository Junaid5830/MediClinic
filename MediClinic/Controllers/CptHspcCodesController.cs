using MediClinic.Models;
using MediClinic.Services.Interfaces.CptHspcCodesInterface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediClinic.Controllers
{
    public class CptHspcCodesController : Controller
    {
        private ICptHspcCodes _cptHspcCodes;
        public CptHspcCodesController(ICptHspcCodes cptHspcCodes)
        {
            _cptHspcCodes = cptHspcCodes;
        }
        public IActionResult Index()
        {
            var viewModel = new CptHspcCodesViewModel();
            

            return View(viewModel);
        }

        public IActionResult AddCptHspcCode(int? Id)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCptHspcCode(CptHspcCodesViewModel cptHspcCodesViewModel)
        {
           await _cptHspcCodes.AddUpdateCptHspcCode(cptHspcCodesViewModel.CptHspcCodes);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> AddCptCodeGroup(int? Id)
        {
            var viewModel = new CptHspcCodesViewModel();
            if (Id != null)
            {
                
            }
            var data =await _cptHspcCodes.ListCptHspcCode();
            viewModel.CptHspcCodesList = data.Data;
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddCptCodeGroup(CptHspcCodesViewModel cptHspcCodesViewModel) 
        {
            cptHspcCodesViewModel.CptCodeGroupListDto.CptCodes = String.Join(",", cptHspcCodesViewModel.CptCodeGroupListDto.CptCodesLArray);
            return RedirectToAction("Index");
        }
    }
}
