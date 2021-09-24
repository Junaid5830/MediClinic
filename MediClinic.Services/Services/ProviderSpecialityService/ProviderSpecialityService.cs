using AutoMapper;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.ProviderSpecialityDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.ProviderSpecialityInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.ProviderSpecialityService
{
    public class ProviderSpecialityService: IProviderSpecialityService
    {
        private MediClinicContext _context;
        private IMapper _mapper;

        public ProviderSpecialityService(MediClinicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ResponseDto<List<ProviderSpecialityBasicDto>>> providerSpeciality()
        {
            var rec = await _context.ProviderSpecialities.ToListAsync();
            var response = new ResponseDto<List<ProviderSpecialityBasicDto>>();
            response.Data = _mapper.Map<List<ProviderSpecialities>, List<ProviderSpecialityBasicDto>>(rec);
            return response;
        }
        public async Task<ResponseDto<bool>> IsSpecialityExistOrNot(string Name)
        {
            var isExist = false;
            var value = await _context.ProviderSpecialities.Where(x => x.ProviderSpeciality.ToLower() == Name.ToLower()).FirstOrDefaultAsync();
            if (!(value is null))
            {
                isExist = true;
            }
            var response = new ResponseDto<bool>();
            response.Data = isExist;
            return response;
        }
        public List<ProviderSpecialities> providerSpecialityByName(string name)
        {
            dynamic rec = null;
            if (name != null)
            {
                rec = _context.ProviderSpecialities.Where(x => x.ProviderSpeciality.Contains(name)).ToList();
            }
            else
            {
                rec = _context.ProviderSpecialities.ToList();
            }
            return rec;
        }
        public async Task<ResponseDto<int>> providerSpecialityCreate(ProviderSpecialityBasicDto providerSpecialityBasicDto)
        { 
            var mapped = _mapper.Map<ProviderSpecialityBasicDto, ProviderSpecialities>(providerSpecialityBasicDto);
            await _context.ProviderSpecialities.AddAsync(mapped);
            _context.SaveChanges();
        
            var response = new ResponseDto<int>();
            response.Data = mapped.ProviderSpecialityId;
            return response;
        }

        public async Task<ResponseDto<bool>> providerSpecialityDeleteById(int Id)
        {
            var oldEntity = await _context.ProviderSpecialities.FirstOrDefaultAsync(x => x.ProviderSpecialityId == Id);
            _context.Remove(oldEntity);
            _context.SaveChanges();
            var response = new ResponseDto<bool>();
            response.Data = true;
            return response;
        }

        public async Task<ResponseDto<ProviderSpecialityBasicDto>> providerSpecialityGetId(int Id)
        {
            var oldEntity = await _context.ProviderSpecialities.FirstOrDefaultAsync(x => x.ProviderSpecialityId == Id);
            var mapped = _mapper.Map<ProviderSpecialities, ProviderSpecialityBasicDto>(oldEntity);
            var response = new ResponseDto<ProviderSpecialityBasicDto>();
            response.Data = mapped;
            return response;
        }

        public async Task<ResponseDto<bool>> providerSpecialityUpdate(ProviderSpecialityBasicDto providerSpecialityBasicDto)
        {
            var mapped = _mapper.Map<ProviderSpecialityBasicDto, ProviderSpecialities>(providerSpecialityBasicDto);
            var oldEntity = await _context.ProviderSpecialities.FindAsync(mapped.ProviderSpecialityId);
            _context.Entry(oldEntity).CurrentValues.SetValues(mapped);
            await _context.SaveChangesAsync();
            var response = new ResponseDto<bool>();
            response.Data = true;
            return response;
        }
    }
}
