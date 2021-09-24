using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.UserInRolesDto;
using MediClinic.Models.DTOs.UsersDto;
using MediClinic.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.MessagesService
{
    public interface IMessagesService
    {
        
        public Task<bool> Add(MessagesDto mesgDto);

        public List<MessagesDto> GetMessageList(int id);
        public  Task<List<MessagesDto>> GetFacilityList();

        public Employee FaciltyDetail(long Id);
        public List<MessagesDto> GetReceiveMessageList(int id);
        public List<MessagesDto> GetSendMasterMessageList(int id);
        public List<MessagesDto> GetReceiveMessageListForRoles(int id);

        public bool Delete(int mesgId);

        public MessagesDto GetMesgById(int mesgId);
        public Task<List<UsersBasicDto>> Getlist();
        public  Task<ResponseDto<MessagesDto>> messageInfoGetId(int Id);
    }
}