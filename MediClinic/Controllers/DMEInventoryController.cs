using MediClinic.Models;
using MediClinic.Services.Interfaces.DMEInterface;
using MediClinic.Services.Interfaces.SessionManager;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediClinic.Controllers
{
    public class DMEInventoryController : Controller
    {
        private readonly IDMEService _dmeService;
        private ISessionManager _sessionManager;
        public DMEInventoryController(IDMEService dMEService,ISessionManager sessionManager)
        {
            _dmeService = dMEService;
            _sessionManager = sessionManager;
        }
        public IActionResult Index()
        {
            return View();
        }


        #region DME Inventory
        public async Task<IActionResult> AddDMEInventory(int? Id)
        {
            var dMEViewModel = new DmeInvetoryViewModel();
            var roleId = _sessionManager.GetRoleId();
            var userId = _sessionManager.GetUserId();
            if (!(Id is null))
            {
                var response = await _dmeService.GetByIdDmeInventory((int)Id);
                dMEViewModel.DmeInventory = response.Data;
            }
            
            if (roleId == 5)
            {
                dMEViewModel.SelectListItemForManufacture = _dmeService.SelectListForManufacture(null);
                dMEViewModel.SelectListItemsForMakeNameModel = _dmeService.SelectListForMakeNameModel(null);
                dMEViewModel.InvertoryDMEGroupList = _dmeService.GroupNameListForDMEInventory(null);
                dMEViewModel.InvertoryDMEGroupItemList = _dmeService.GroupItemNameListForDMEInventory(null);
            }
            else
            {
                dMEViewModel.SelectListItemForManufacture = _dmeService.SelectListForManufacture(userId);
                dMEViewModel.SelectListItemsForMakeNameModel = _dmeService.SelectListForMakeNameModel(userId);
                dMEViewModel.InvertoryDMEGroupList = _dmeService.GroupNameListForDMEInventory(userId);
                dMEViewModel.InvertoryDMEGroupItemList = _dmeService.GroupItemNameListForDMEInventory(userId);
            }

            return View(dMEViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> AddDMEInventory(DmeInvetoryViewModel dmeInvetoryViewModel)
        {
            var isExistdata = await _dmeService.isExistInventory((int)dmeInvetoryViewModel.DmeInventory.CPTCode);
            if (isExistdata.Data)
            {
                var message = new { Message = isExistdata.Message, IsError = true };
                return Json(message);
            }
            if (dmeInvetoryViewModel.DmeInventory.Id > 0)
            {
                dmeInvetoryViewModel.DmeInventory.ModifiedBy = _sessionManager.GetUserId();
                dmeInvetoryViewModel.DmeInventory.ModifiedDate = DateTime.UtcNow;
            }
            else
            {
                dmeInvetoryViewModel.DmeInventory.CreatedBy = _sessionManager.GetUserId();
                dmeInvetoryViewModel.DmeInventory.CreatedDate = DateTime.UtcNow;
            }
            var response = await _dmeService.AddUpdateDmeInventory(dmeInvetoryViewModel.DmeInventory);
            var data = new { Data = response.Data, Message = "Successfully Created", IsError = false };
            return Json(data);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteInventory(int Id)
        {
            var Message = "";
            var result = await _dmeService.DeleteDmeInventory(Id);
            if (result.Data)
            {
                Message = "Deleted Succefully";
            }
            else
            {
                Message = "There is some error";
            }
            var data = new { Result = result.Data, Message = Message };
            return Json(data);
        }

        [HttpPost]
        public async Task<IActionResult> GetModelByMakeNameValue(int Id)
        {
            var response = await _dmeService.GetByIdMakeNameModel(Id);
            var data = new { Model = response.Data.Model };
            return Json(data);
        }
        [HttpPost]
        public IActionResult GetCptCodeByGroupName(int Id)
        {
            var data = _dmeService.CptCodeByGroupNameSelect(Id);
            return Json(data);
        }
        [HttpPost]
        public async Task<IActionResult> GetGroupNameByCptCode(int Id)
        {
            var result = await _dmeService.GroupNameBycptCodeSelet(Id);
            var data = new { value = result.Data.DMEGroupId, text = result.Data.GroupName };
            return Json(data);
        }
        #endregion
        public IActionResult DMEInventory()
        {
            return View();
        }


        public IActionResult InventoryList()
        {
            return View();
        }


        public IActionResult ApplyForRent(long patId,long providerId)
        {
            return PartialView("~/Views/DMEInventory/PartialViews/_ApplyForRentForm.cshtml");
        }

        [HttpPost]
        public IActionResult ApplyForRent()
        {
            var data = new { Error=false};
            return Json(data);
        }
        public IActionResult ApplyForRentList()
        {
            return View();
        }


        #region Payment
        public IActionResult VenderPaymentAdd()
        {
            return View();
        }
        public IActionResult VenderPaymentList()
        {
            return View();
        }
        #endregion  Payment
    }
}
