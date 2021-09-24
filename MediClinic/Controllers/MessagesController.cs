using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediClinic.Models;
using MediClinic.Models.DTOs;
using MediClinic.Services.Interfaces.Assistant;
using MediClinic.Services.Interfaces.SessionManager;
using MediClinic.Services.Interfaces.UserInterface;
using MediClinic.Services.Services.MessagesService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Data;
using MediClinic.Models.EntityModels;
using Microsoft.AspNetCore.Http;
using MediClinic.Services.Interfaces.ProviderInfoInterface;
using MediClinic.Services.Interfaces.PatientInfoInterface;

namespace MediClinic.Controllers
{
    public class MessagesController : Controller
    {
        private readonly ILogger<MessagesController> _logger;
        private ISessionManager _sessionManager;
        private IMessagesService _messagesService;
        private MessageViewModel messageViewModel;
        private IHttpContextAccessor contextAccessor;
        private object assistantViewModel;
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly MediClinicContext _context;
        private IProviderInfoService _providerInfoService;
        private readonly IPatientInfoService _patientInfoService;

        public MessagesController(
            ILogger<MessagesController> logger,
            ISessionManager sessionManager, IMessagesService messagesService, MediClinicContext context,
            IHttpContextAccessor contextAccessor , IProviderInfoService providerInfoService, IPatientInfoService patientInfoService
            )
        {
            _logger = logger;
            _sessionManager = sessionManager;
            _messagesService = messagesService;
            messageViewModel = new MessageViewModel();
            _context = context;
            _contextAccessor = contextAccessor;
            _providerInfoService = providerInfoService;
            _patientInfoService = patientInfoService;

            _contextAccessor.HttpContext.Session.SetString("_Name", "MyStore");
            string SessionId = _contextAccessor.HttpContext.Session.Id;
        }

        public IActionResult Index()
        {

            try
            {
                var roleId = _sessionManager.GetRoleId();
                int id = (int)((_sessionManager.GetUserId() == 0) ? 0 : _sessionManager.GetUserId());

                if (roleId == 5 || roleId == 4 || roleId > 5)
                {
                    messageViewModel.list = _messagesService.GetSendMasterMessageList(id);
                    messageViewModel.receiveMessages = _messagesService.GetReceiveMessageListForRoles(id);

                }
                else
                {
                    messageViewModel.receiveMessages = _messagesService.GetReceiveMessageList(id);
                    messageViewModel.list = _messagesService.GetMessageList(id);
                }

              
                return View(messageViewModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Add(int id)
        {

            try
            {
                messageViewModel.Faciltylist = await _messagesService.GetFacilityList();
                messageViewModel.userList = await _messagesService.Getlist();
                messageViewModel.ProviderList = await _providerInfoService.GetProviderList();
                messageViewModel.patientListWithUsers = await _patientInfoService.GetPatientListWithDetails();

                messageViewModel.message = (_messagesService.GetMesgById(id) == null) ? new MessagesDto() : _messagesService.GetMesgById(id);

                messageViewModel.message.FromId = (_sessionManager.GetUserId() == 0) ? 0 : _sessionManager.GetUserId();
                return View(messageViewModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        public async Task<IActionResult> Add(MessageViewModel messageViewModel)
        {
            var RoleId = _sessionManager.GetRoleId();
            if (RoleId == 1)
            {
                var PatientId = _sessionManager.GetPatientInfoId();
                var rec = _patientInfoService.GetPatientInfoById(PatientId);
                messageViewModel.message.FromId = rec.UserId;

                var recTO = _providerInfoService.GetProviderUserId((long)messageViewModel.message.ToId);
                messageViewModel.message.ToId = recTO.UserId;
            }
            else if (RoleId == 2)
            {
                var ProviderId = _sessionManager.GetProviderInfoId();
                var rec = _providerInfoService.GetProviderUserId(ProviderId);
                messageViewModel.message.FromId = rec.UserId;
                var recTo = _patientInfoService.GetPatientInfoById((long)messageViewModel.message.ToId);
                messageViewModel.message.ToId = recTo.UserId;
            }
            else
            {
                var UserId = _sessionManager.GetUserId();
                messageViewModel.message.FromId = UserId;
                var recTo = _messagesService.FaciltyDetail((long)messageViewModel.message.ToId);
                messageViewModel.message.ToId = recTo.UserId;

            }
            await _messagesService.Add(messageViewModel.message);
            return Redirect("Index");
        }


        public IActionResult Delete(int mesgId)
        {
            var Id = _messagesService.Delete(mesgId);
            return Redirect("Index");
        }
    }
}
