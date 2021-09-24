using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediClinic.Models;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.InvoicesInterface;
using MediClinic.Services.Interfaces.SessionManager;
using MediClinic.Services.Interfaces.UserInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MediClinic.Controllers
{
    public class InvoicesController : Controller
    {
        private readonly ILogger<InvoicesController> _logger;
        private ISessionManager _sessionManager;
        private IInvoicesService _invoiceService;
        private InvoicesViewModel invoiceViewModel;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly MediClinicContext _context;

        public InvoicesController(
            ILogger<InvoicesController> logger,
            ISessionManager sessionManager, IInvoicesService invoiceService, MediClinicContext context,
            IHttpContextAccessor contextAccessor
            )
        {
            _logger = logger;
            _sessionManager = sessionManager;
            _invoiceService = invoiceService;
            invoiceViewModel = new InvoicesViewModel();
            _context = context;
            _contextAccessor = contextAccessor;
        }

        public async Task<IActionResult> Index()
        {
            var RoleId = _sessionManager.GetRoleId();
            try
            {
                if (RoleId == 1)
                {
                    var PatientId = _sessionManager.GetPatientInfoId();
                    invoiceViewModel.invoicesList = await _invoiceService.GetInvoicesListOfVisits(PatientId);
                }
                else
                {
                    invoiceViewModel.invoicesList = await _invoiceService.GetInvoicesList();

                }
               
                return View(invoiceViewModel);
            }
            catch (Exception ex)
            {
                throw ex;
            };
        }

        public async Task<IActionResult> ViewPrint(int id)
        {
            invoiceViewModel.invoices = _invoiceService.GetInvoiceById(id);
            invoiceViewModel.invoicesChargesList = await _invoiceService.GetInvoicesChargesList(id);
            return View(invoiceViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Add(int id) {
            invoiceViewModel.invoices = _invoiceService.GetInvoiceById(id);
            invoiceViewModel.invoicesChargesList = await _invoiceService.GetInvoicesChargesList(id);
            return View(invoiceViewModel);
        }

        public  IActionResult Add(InvoicesViewModel invoicesViewModel)
        {
            try
            {
                int invoiceId = _invoiceService.Add(invoicesViewModel.invoices);
                foreach (var item in invoicesViewModel.invoicesChargesList) {
                    item.InvoiceFId = invoiceId;
                }
                _invoiceService.AddCharges(invoicesViewModel.invoicesChargesList);
                return Redirect("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       
        public IActionResult GetPtientRecord(int id) {
            try
            {
                invoiceViewModel.patient = _invoiceService.GetPaitent(id);
                var pdata = invoiceViewModel.patient;
                return Json(pdata);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<IActionResult> PatientInvoiceListForReceptionlist(long? Id)
        {
            invoiceViewModel.invoicesList = await _invoiceService.GetInvoicesListOfVisits((long)Id);
            return View(invoiceViewModel);
        }
        public IActionResult Delete(int inv)
        {
            var Id = _invoiceService.Delete(inv);
            return Redirect("Index");
        }
    }
}
