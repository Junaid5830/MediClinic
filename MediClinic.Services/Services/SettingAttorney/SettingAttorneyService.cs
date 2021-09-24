using AutoMapper;
using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.SeetingAttorney;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.SettingAttorney
{
    public class SettingAttorneyService : ISettingAttorney
    {

        private MediClinicContext _context;
        private IMapper _mapper;

        public SettingAttorneyService(MediClinicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ResponseDto<SettingAttorneyDto>> AddSettingAttorney(SettingAttorneyDto settingAttorney)
        {
            try
            {
                var mapped = _mapper.Map<SettingAttorneyDto, MediClinic.Models.EntityModels.SettingAttorney>(settingAttorney);
                _context.SettingAttorney.Add(mapped);
                await _context.SaveChangesAsync();
                var response = new ResponseDto<SettingAttorneyDto>();
                response.Data = settingAttorney;
                return response;
            }
            catch (System.Exception ex)
            {
                throw;

            }
         
        }

        public async Task<bool> Delete(int Id)
        {
            try
            {
                  var result = false;
                  var data= await _context.SettingAttorney.Where(x => x.AttorneyId == Id).FirstOrDefaultAsync();
                 _context.SettingAttorney.Remove(data);
                  await   _context.SaveChangesAsync();
                  return result;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task<ResponseDto<SettingAttorneyDto>> GetById(int Id)
        {
            try
            {
                var data = await _context.SettingAttorney.Where(x => x.AttorneyId == Id).FirstOrDefaultAsync();
                var mapper = _mapper.Map<MediClinic.Models.EntityModels.SettingAttorney,SettingAttorneyDto>(data);
                var response = new ResponseDto<SettingAttorneyDto>();
                response.Data = mapper;
                return response;
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }

        public async Task<List<SettingAttorneyDto>> GetList()
        {
           
            try
            {

                var List = await _context.SettingAttorney.ToListAsync();
                var mapped = _mapper.Map <List<MediClinic.Models.EntityModels.SettingAttorney> ,List<SettingAttorneyDto>>(List);
                return mapped;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task<ResponseDto<SettingAttorneyDto>> UpdateSettingAttorney(SettingAttorneyDto settingAttorney)
        {
            try
            {
                var mapped = _mapper.Map<SettingAttorneyDto, MediClinic.Models.EntityModels.SettingAttorney>(settingAttorney);
                var oldEntity = await _context.SettingAttorney.FindAsync(mapped.AttorneyId);
               _context.Entry(oldEntity).CurrentValues.SetValues(mapped);
               await _context.SaveChangesAsync();
                var response = new ResponseDto<SettingAttorneyDto>();
                response.Data = settingAttorney;
                return response;
            }
            catch (System.Exception ex)
            {

                throw;
            }
        
        }
    }
}
