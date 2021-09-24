using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediClinic.Models;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.LegalInfoInterface;
using MediClinic.Services.Interfaces.SessionManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MediClinic.Controllers
{
    public class LegalInfoController : Controller
    {
        private readonly ILogger<LegalInfoController> _logger;
        private ISessionManager _sessionManager;
        private ILegalInfoService _legalInfoServices;
        private LegalInfoViewModel legalInfoViewModel;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly MediClinicContext _context;

        public LegalInfoController(
            ILogger<LegalInfoController> logger,
            ISessionManager sessionManager, ILegalInfoService legalInfoServices, MediClinicContext context,
            IHttpContextAccessor contextAccessor
            )
        {
            _logger = logger;
            _sessionManager = sessionManager;
            _legalInfoServices = legalInfoServices;
            legalInfoViewModel = new LegalInfoViewModel();
            _context = context;
            _contextAccessor = contextAccessor;
        }
        public IActionResult LegalInfoGrid()
        {
            legalInfoViewModel.getLegalInfoList = _legalInfoServices.GetLegalInfoList();
            return View(legalInfoViewModel);
        }
        public IActionResult Add(int id)
        {
            legalInfoViewModel.legalInfoDto = _legalInfoServices.GetLegalInfoById(id);
            return View(legalInfoViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Add(LegalInfoViewModel legalInfoViewModel)
        {
            await _legalInfoServices.Add(legalInfoViewModel.legalInfoDto);
            return Redirect("LegalInfoGrid");
        }
        public IActionResult Delete(int billId)
        {
            var Id = _legalInfoServices.Delete(billId);
            return Redirect("Index");
        }
    }
}
