using AutoMapper;
using MediClinic.Models.DTOs;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces;
using MediClinic.Services.Interfaces.SessionManager;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services
{
    public class AdministrativeService : IAdministrativeService
    {
        private MediClinicContext _context;
        private IMapper _mapper;
        private ISessionManager _sessionManager;

        public AdministrativeService(MediClinicContext context, IMapper mapper, ISessionManager sessionManager)
        {
            _context = context;
            _mapper = mapper;
            _sessionManager = sessionManager;
        }

        public async Task<List<AdministrativeDto>> AdministrativeList()
        {
            var rec = await _context.Administrative.OrderByDescending(x => x.AdministrativeID).ToListAsync();
            var response = new List<AdministrativeDto>();
            response = _mapper.Map<List<Administrative>, List<AdministrativeDto>>(rec);
            return response;
        }

        public async Task<bool> AddAdministrative(AdministrativeDto administrativeDto)
        {
            var result = true;
            if (administrativeDto.AdministrativeID > 0)
            {
                var oldEntity = _context.Administrative.Find(administrativeDto.AdministrativeID);
                var mappedData = _mapper.Map<AdministrativeDto>(administrativeDto);

                _context.Entry(oldEntity).CurrentValues.SetValues(mappedData);
                var data = await _context.SaveChangesAsync();

                if (data == 0)
                {
                    return false;
                }
            }
            else
            {
                var record = _mapper.Map<AdministrativeDto, Administrative>(administrativeDto);
                record.IsActive = true;
                await _context.Administrative.AddAsync(record);
                var data = _context.SaveChanges();
                if (data == 0)
                {
                    return false;
                }
            }
            return result;
        }


        public async Task<bool> DeleteAdministrative(int administrativeId)
        {
            var oldEntity = await _context.Administrative.Where(x => x.AdministrativeID == administrativeId).FirstOrDefaultAsync();
            if (oldEntity != null)
            {
                oldEntity.IsActive = false;
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<AdministrativeDto> GetAdministrativeById(int Id)
        {
            var entity = await _context.Administrative.Where(x => x.AdministrativeID == Id).FirstOrDefaultAsync();
            var mappedData = _mapper.Map<AdministrativeDto>(entity);
            return mappedData;
        }
    }
}
