using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.CommonDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.UserEventInterface
{
    public interface IUserEvents
    {
        public Task<ResponseDto<UserEventsDto>> CreateUpdateEvent(UserEventsDto userEventsDto);
        public Task<ResponseDto<List<UserEventsDto>>> GetEventsistByUserId(long userId);
        public Task<ResponseDto<UserEventsDto>> GetEventsistById(int eventId);
        public Task<ResponseDto<bool>> DeleteEvent(int eventId);
    }
}
