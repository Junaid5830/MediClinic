using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediClinic.Models;
using MediClinic.Services.Interfaces.DMEInterface;
using MediClinic.Services.Interfaces.SessionManager;
using Microsoft.AspNetCore.Mvc;

namespace MediClinic.Controllers
{
    public class DMEitemgroupController : Controller
    {
        private IDMEService _iDMEService;
        private ISessionManager _sessionManager;
        public DMEitemgroupController(IDMEService dMEService,ISessionManager sessionManager)
        {
            _iDMEService = dMEService;
            _sessionManager = sessionManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddItemGroup()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AdditemGroup(DMEGroupItemViewModel dMEGroupItemViewModel)
        {
            if (dMEGroupItemViewModel.dMEGroupDto.DMEGroupId == 0)
            {
                dMEGroupItemViewModel.dMEGroupDto.CreatedId = _sessionManager.GetUserId();
                dMEGroupItemViewModel.dMEGroupDto.CreatedDate = DateTime.UtcNow;
            }
            else
            {
                dMEGroupItemViewModel.dMEGroupDto.ModifiedId = _sessionManager.GetUserId();
                dMEGroupItemViewModel.dMEGroupDto.ModifiedDate = DateTime.UtcNow;
            }
            var rec = await _iDMEService.CreateGroupName(dMEGroupItemViewModel.dMEGroupDto);
            if (dMEGroupItemViewModel.groupItemList.Count>0)
            {
                
                dMEGroupItemViewModel.groupItemList.ForEach(x => x.DMEGroupId = rec.Data.DMEGroupId);
            }
            await _iDMEService.CreateGroupItem(dMEGroupItemViewModel.groupItemList);
            var data = new { Success = "Successfully Save", IsError = true };

            return Json(data);
        }
        [HttpPost]
        public async Task<IActionResult> groupitemList(int Id)
        {
            DmeInvetoryViewModel dmeInvetoryViewModel = new DmeInvetoryViewModel();
            var groupitemList = await _iDMEService.GroupItemList(Id);
            dmeInvetoryViewModel.groupItemList = groupitemList.Data;
            return PartialView("~/Views/DMEitemgroup/PartialViews/_GroupItemViews.cshtml", dmeInvetoryViewModel);

        }
    }
}
