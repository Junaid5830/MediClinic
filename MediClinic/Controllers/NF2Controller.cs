using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MediClinic.Controllers
{
    public class NF2Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AssignementOfBenefitsForm()
        {
            ViewBag.AssignementOfBenefitsForm = "nav-active";
            return View();
        }
        public IActionResult ElectionOfOption()
        {
            ViewBag.ElectionOfOption = "nav-active";
            return View();
        }
        public IActionResult LumpSumSettlementAggreement()
        {
            ViewBag.LumpSumSettlementAggreement = "nav-active";
            return View();
        }
        public IActionResult CoverLetter()
        {
            ViewBag.CoverLetter = "nav-active";
            return View();
        }
        public IActionResult NoFaultBenefits()
        {
            ViewBag.NoFaultBenefits = "nav-active";
            return View();
        }
        public IActionResult VerificationOfTreatment()
        {
            ViewBag.VerificationOfTreatment = "nav-active";
            return View();
        }
        public IActionResult VerificationOfHospitalTreatment()
        {
            ViewBag.VerificationOfHospitalTreatment = "nav-active";
            return View();
        }
        public IActionResult HospitalFacilityForm()
        {
            ViewBag.HospitalFacilityForm = "nav-active";
            return View();
        }
        public IActionResult EmployerWageVerificationReport()
        {
            ViewBag.EmployerWageVerificationReport = "nav-active";
            return View();
        }
        public IActionResult VerificationOfSelfEmploymentIncome()
        {
            ViewBag.VerificationOfSelfEmploymentIncome = "nav-active";
            return View();
        }
        public IActionResult SocialSecurityDisabilityBenefits()
        {
            ViewBag.SocialSecurityDisabilityBenefits = "nav-active";
            return View();
        }
        public IActionResult NYSDisabilityBenefit()
        {
            ViewBag.NYSDisabilityBenefit = "nav-active";
            return View();
        }
        public IActionResult DenialOfClaimForm()
        {
            ViewBag.DenialOfClaimForm = "nav-active";
            return View();
        } 
        public IActionResult PIPSubrogationAgreement()
        {
            ViewBag.PIPSubrogationAgreement = "nav-active";
            return View();
        }
        
    }
}
