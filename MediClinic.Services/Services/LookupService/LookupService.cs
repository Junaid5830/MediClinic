using AutoMapper;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.LookupDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.LookupInteface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.LookupServices
{
    public class LookupService: ILookupService
    {
        private MediClinicContext _context;
        private IMapper _mapper;

        public LookupService(MediClinicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseDto<List<LookupBasicDto>>> LookupDtolist(string lookupType)
        {
            var rec = await _context.Lookups.Where(x=>x.LookupType.Trim().ToLower() == lookupType.Trim().ToLower()).ToListAsync();
            var response = new ResponseDto<List<LookupBasicDto>>();
            response.Data = _mapper.Map<List<Lookups>, List<LookupBasicDto>>(rec);
            return response;
        }

        public List<Lookups> lookupsByType(string lookupType, string name)
        {
            dynamic rec = null;
            if(name != null)
            {
                rec = _context.Lookups.Where(x => x.LookupType == lookupType && x.LookupValue.Contains(name)).ToList();
            }
            else
            {
                rec = _context.Lookups.Where(x => x.LookupType == lookupType).ToList();
            }
            return rec;
        }
        public ResponseDto<List<LookupBasicDto>> lookupByTypeBasicDto(string lookupType)
        {
            var rec = _context.Lookups.Where(x => x.LookupType == lookupType).ToList();
            var response = new ResponseDto<List<LookupBasicDto>>();
            response.Data = _mapper.Map<List<Lookups>, List<LookupBasicDto>>(rec);
            return response;
        }

        public async Task<ResponseDto<bool>> IsLookUpValueExists(string value, string type) {
            var rec = await _context.Lookups.FirstOrDefaultAsync(x=>x.LookupValue.ToLower()==value.ToLower() && x.LookupType.ToLower()==type.ToLower());
            var response = new ResponseDto<bool>();
            if (rec is null)
            {
                response.Data = false;
            }
            else
            {
                response.Data = true;
            }
            return response;
        }
        public async Task<ResponseDto<int>> SaveLookUpValue(LookupBasicDto entity) { 
            var rec = _context.Lookups.Where(x => x.LookupType.ToLower() == entity.LookupType.ToLower()).Max(x => x.SortOrder);
            entity.SortOrder = rec + 1;
            var mapped = _mapper.Map<LookupBasicDto, Lookups>(entity);
            await _context.Lookups.AddAsync(mapped);
            await _context.SaveChangesAsync();
            return new ResponseDto<int>() {
                Data = mapped.LookupId 
            };
            

        }
        public List<LookupBasicDto> GetClinicalNotelist(string lookupType)
        {
            var rec =  _context.Lookups.Where(x => x.LookupType.ToLower() == lookupType.ToLower()).ToList();
            var response = _mapper.Map<List<LookupBasicDto>>(rec);
            return response;
        }
    }
}
