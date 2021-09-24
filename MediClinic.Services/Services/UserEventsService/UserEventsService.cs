using AutoMapper;
using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.UserEventInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.UserEventsService
{
    public class UserEventsService : IUserEvents
    {
        private MediClinicContext _context;
        private IMapper _mapper;

        public UserEventsService(MediClinicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseDto<UserEventsDto>> CreateUpdateEvent(UserEventsDto userEventsDto)
        {
            try
            {
                var response = new ResponseDto<UserEventsDto>();
                var mapper = _mapper.Map<UserEvents>(userEventsDto);
                if (userEventsDto.EventId > 0)
                {
                    var oldEntity = await _context.UserEvents.FindAsync(userEventsDto.EventId);
                    
                    _context.Entry(oldEntity).CurrentValues.SetValues(mapper);
                    await _context.SaveChangesAsync();
                    
                    response.Data = userEventsDto;

                }
                else
                {
                    var rec = await _context.UserEvents.AddAsync(mapper);
                    await _context.SaveChangesAsync();
                    var mapped = _mapper.Map<UserEventsDto>(rec.Entity);
                    response.Data = mapped;



                }
                return response;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<ResponseDto<bool>> DeleteEvent(int eventId)
        {
            try
            {
                var response = new ResponseDto<bool>();
                var oldEntity = await _context.UserEvents.FindAsync(eventId);
                _context.UserEvents.Remove(oldEntity);
                await _context.SaveChangesAsync();
                response.Data = true;
                return response;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<ResponseDto<UserEventsDto>> GetEventsistById(int eventId)
        {
            try
            {
                var response = new ResponseDto<UserEventsDto>();
                var events = await _context.UserEvents.Where(x => x.EventId == eventId).FirstOrDefaultAsync();
                var mapper = _mapper.Map<UserEventsDto>(events);
                response.Data = mapper;
                return response;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<ResponseDto<List<UserEventsDto>>> GetEventsistByUserId(long userId)
        {
            try
            {
                var response = new ResponseDto<List<UserEventsDto>>();
                var events = await _context.UserEvents.Where(x => x.UserId == userId).ToListAsync();
                var mapper = _mapper.Map<List<UserEventsDto>>(events);
                response.Data = mapper;
                return response;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
