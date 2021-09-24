using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using MediClinic.Models;
using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.DMESuppliesDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces;
using MediClinic.Services.Interfaces.DMEInterface;
using MediClinic.Services.Interfaces.LookupInteface;
using MediClinic.Services.Interfaces.ProviderInfoInterface;
using MediClinic.Services.Interfaces.SessionManager;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediClinic.Controllers
{
    //[AuthFilter(RoleNames.Doctor,RoleNames.Admin)]
    public class DMEController : Controller
    {
        private DMEViewModal viewModal;
        private ISessionManager _sessionManager;
        private IDMESuppliesService _dMESuppliesService;
        private IProviderInfoService _providerInfoService;
        private IWebHostEnvironment _webHostEnvironment;
        private IDMEService _dmeService;
        private ILookupService _lookupService;

        public DMEController(ISessionManager sessionManager, IDMESuppliesService dMESuppliesService, IProviderInfoService providerInfoService, IWebHostEnvironment webHostEnvironment, ILookupService lookupService, IDMEService dmeService)
        {
            _sessionManager = sessionManager;
            _dMESuppliesService = dMESuppliesService;
            _providerInfoService = providerInfoService;
            _webHostEnvironment = webHostEnvironment;
            _dmeService = dmeService;
            _lookupService = lookupService;
            viewModal = new DMEViewModal();
        }


        #region DME CRUD
        public async Task<IActionResult> DMESupplies()
        {
            var list = new List<DMESupplyEquipment>();
            var patientId = _sessionManager.GetPatientInfoId();
            var RoleId = _sessionManager.GetRoleId();
            if (RoleId == 5)
            {
               list = await _dMESuppliesService.GetAllDMESupplyList();

            }
            else
            {
                list = await _dMESuppliesService.GetDMESupplyListByPatientId(patientId);

            }
            
            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> DMESuppliesEdit(int? DMESupplyId)
        {
            var dtoObj = new DMESupplieDto();
            ViewBag.Image = string.Empty;

            if (!(DMESupplyId is null))
            {
                dtoObj = await _dMESuppliesService.GetDMESupplyById(DMESupplyId.Value);
                ViewBag.Image = dtoObj.ImageUrl;
                ViewBag.ActionType = "Update";
            }
            else
            {
                ViewBag.ActionType = "Save";
            }

            dtoObj.ICDList = await _dMESuppliesService.GetAllICDCodes(true);
            dtoObj.CPTList = await _dMESuppliesService.GetAllCPTCodes();
            dtoObj.ItemList = await _dMESuppliesService.GetAllItemsGroup();
            dtoObj.PrescriberList = await _providerInfoService.GetProviderList();

            ViewBag.DMEsupplies = "nav-active";
            return View(dtoObj);
        }


        [HttpPost]
        public async Task<IActionResult> DMESuppliesEdit(DMESupplieDto dMESupplieDto)
        {
            try
            {
                //var patientId = _sessionManager.GetPatientInfoId();
                var loginUserId = _sessionManager.GetUserId();
                var prescriberId = _sessionManager.GetProviderInfoId();
                var fileName = string.Empty;
                var files = Request.Form.Files;
                var delpath = "wwwroot" + dMESupplieDto.QRCodeImageUrl;
                if (dMESupplieDto.QRCodeImageUrl != null)
                {
                    System.IO.File.Delete(delpath);
                }
                var path = _dMESuppliesService.SaveImage(dMESupplieDto.QRCodeImage.Replace("data:image/jpeg;base64,", string.Empty));
                dMESupplieDto.QRCodeImageUrl = path;
                if (files.Count > 0)
                {
                    foreach (IFormFile source in files)
                    {
                        fileName = ContentDispositionHeaderValue.Parse(source.ContentDisposition).FileName.Trim('"');
                        fileName = "DME" + Path.GetFileName(fileName);
                        string extension = Path.GetExtension(fileName);

                        using (FileStream output = System.IO.File.Create(this.GetFullPath(fileName)))
                            await source.CopyToAsync(output);
                    }
                }
                else
                {
                    fileName = dMESupplieDto.ImageUrlHidden;
                }
                dMESupplieDto.IsActive = true;
                //dMESupplieDto.PrescriptionDate = DateTime.Now;
                //dMESupplieDto.PatientId = patientId;
                dMESupplieDto.UserId = loginUserId;
                dMESupplieDto.ImageUrl = fileName;
                dMESupplieDto.PrescriberId = prescriberId;

                if (dMESupplieDto.DMEEquipSupId > 0)
                {
                    _dMESuppliesService.UpdateDMESupplyEquipment(dMESupplieDto);
                }
                else
                {
                    _dMESuppliesService.SaveDMESupplyEquipment(dMESupplieDto);
                }
                return RedirectToAction("DMESupplies");
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        public IActionResult DeleteDMESupplies(int DMESupplyId)
        {
            var result = _dMESuppliesService.DeleteDMESupplyEquipment(DMESupplyId);
            return Json(result);
        }
        #endregion
        #region DME Referal Template
        public async Task<IActionResult> DmeReferalPrint(int? DMEId)
        {
            var patientId = _sessionManager.GetPatientInfoId();
            var doctorId = _sessionManager.GetProviderInfoId();
            var rec = await _dMESuppliesService.GetDMESupplyById(DMEId);
            var UserRec = await _providerInfoService.providerInfoGetByUserId((int)rec.UserId);
            var model = await _dMESuppliesService.GetReferalTemplateData(patientId, UserRec.Data.ProviderInfoId, DMEId);
            return View(model);
        }
        public async Task<IActionResult> DmeReferalBatchPrint(string DMEIds)
        {
            var model = new DMEReferalTemplateDto();
                
            var arrayList = new ArrayList();
            var patientId = _sessionManager.GetPatientInfoId();
            var doctorId = _sessionManager.GetProviderInfoId();
            var data = DMEIds.Split(',');
            foreach (var item in data)
            {
                var rec = await _dMESuppliesService.GetDMESupplyById(Convert.ToInt32(item));
                var UserRec = await _providerInfoService.providerInfoGetByUserId((int)rec.UserId);
                arrayList.Add(UserRec.Data.ProviderInfoId);
            }                
            model = await _dMESuppliesService.GetReferalTemplateBatchData(patientId, Convert.ToInt32(arrayList[0]), data);        
            ViewBag.Items = model.ItemsNames; 
            return View(model);
        }
        #endregion
        public async Task<IActionResult> DmeDelivery(int? DMEIds)
        {
            var patientId = _sessionManager.GetPatientInfoId();
            var doctorId = _sessionManager.GetProviderInfoId();
            var rec = await _dMESuppliesService.GetDMESupplyById(Convert.ToInt32(DMEIds));
            var UserRec = await _providerInfoService.providerInfoGetByUserId((int)rec.UserId);
            var model = await _dMESuppliesService.GetDMEDeliveryTemplateData(patientId, UserRec.Data.ProviderInfoId);
            return View(model);
        }
        public async Task<IActionResult> DmeAobPickup(int? DMEIds)
        {
            var patientId = _sessionManager.GetPatientInfoId();
            var doctorId = _sessionManager.GetProviderInfoId();
            var rec = await _dMESuppliesService.GetDMESupplyById(Convert.ToInt32(DMEIds));
            var UserRec = await _providerInfoService.providerInfoGetByUserId((int)rec.UserId);
            var data = await _dMESuppliesService.GetDMEAOBTemplateData(patientId, UserRec.Data.ProviderInfoId, DMEIds);
            if (!(DMEIds is null))
            {
                ViewBag.IsForSingleTemplate = true;
            }
            else
            {
                ViewBag.IsForSingleTemplate = false;
            }
            return View(data);
        }

        public async Task<IActionResult> DmeAobBatchPickup(string DMEIds)
        {
            var arrayList = new ArrayList();
            var patientId = _sessionManager.GetPatientInfoId();
            var doctorId = _sessionManager.GetProviderInfoId();
            var splitData = DMEIds.Split(',');
            foreach (var item in splitData)
            {
                var rec = await _dMESuppliesService.GetDMESupplyById(Convert.ToInt32(item));
                var UserRec = await _providerInfoService.providerInfoGetByUserId((int)rec.UserId);
                arrayList.Add(UserRec.Data.ProviderInfoId);
            }
            
            var data = await _dMESuppliesService.GetDMEAOBBatchData(patientId, Convert.ToInt32(arrayList[0]), splitData);
            if (data.ItemsNames != null)
            {
                ViewBag.Items = data.ItemsNames;
            }
            return View(data);
        }

        public async Task<IActionResult> SupplyReturnRecipt(int? DMEId)
        {
            var patientId = _sessionManager.GetPatientInfoId();
            var rec = await _dMESuppliesService.GetDMESupplyById(Convert.ToInt32(DMEId));
            var UserRec = await _providerInfoService.providerInfoGetByUserId((int)rec.UserId);
            var data = await _dMESuppliesService.GetSupplyReturnTemplateData(patientId,DMEId);
            if (!(DMEId is null))
            {
                ViewBag.IsForSingleTemplate = true;
            }
            else
            {
                ViewBag.IsForSingleTemplate = false;
            }
            return View(data);
        }

        public async Task<IActionResult> DmeSupplyReturnBatch(string DMEIds)
        {
            var patientId = _sessionManager.GetPatientInfoId();
            var splitData = DMEIds.Split(',');

            var data = await _dMESuppliesService.GetSupplyReturnBatchData(patientId, splitData);
            if (data.ItemsNames != null)
            {
                ViewBag.Items = data.ItemsNames;
            }
            return View(data);
        }


        #region RxOrder Template
        public async Task<IActionResult> RxeOrder(int? DMEId)
        {
            var patientId = _sessionManager.GetPatientInfoId();
            var data = await _dMESuppliesService.GetRXOrderTemplateData(patientId, DMEId);
            return View(data);
        }

        public async Task<IActionResult> DmeRxeOrderBatchPrint(string DMEIds)
        {
            var patientId = _sessionManager.GetPatientInfoId();
            var data = DMEIds.Split(',');
            var model = await _dMESuppliesService.GetRXOrderBatchData(patientId, data);
            ViewBag.Items = model.ItemsNames;
            return View(model);
        }
        #endregion


        private string GetFullPath(string filename)
        {
            return this._webHostEnvironment.WebRootPath + "\\images\\" + filename;
        }
        #region DME
        [HttpGet]
        public async Task<IActionResult> DME(int? Id)
        {
            viewModal.DMEDtoList =await _dmeService.GetDME();
            return View(viewModal);
        }
        [HttpGet]
        public IActionResult AddDME(int? DMEId)
        {
            if (DMEId != 0)
            {
                viewModal.DMEDto = _dmeService.GetDMEById(Convert.ToInt32(DMEId));
            }
            viewModal.ItemGroupName = _lookupService.GetClinicalNotelist("ItemGroupName");
            viewModal.CTP = _lookupService.GetClinicalNotelist("CTP");
            viewModal.ICD = _lookupService.GetClinicalNotelist("ICD");
            viewModal.Prescriber = _lookupService.GetClinicalNotelist("Prescriber");
            viewModal.RefNo = _lookupService.GetClinicalNotelist("RefNo");
            viewModal.Status = _lookupService.GetClinicalNotelist("Status");
            return View(viewModal);
        }
        [HttpGet]
        public IActionResult DeleteDME(int DMEId)
        {
            _dmeService.DeleteDME(DMEId);
            return RedirectToAction("DME");
        }
        [HttpPost]
        public async Task<IActionResult> AddDME(DMEDto DMEDto)
        {
            await _dmeService.AddDME(DMEDto);
            viewModal.DMEDtoList =await _dmeService.GetDME();
            //return View(viewModal);
            return RedirectToAction("DME");
            //return RedirectToAction("DME", new { Id = patientId });
        }
        #endregion
    }
}