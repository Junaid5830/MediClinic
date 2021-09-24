using AutoMapper;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.RelatedFacilityDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.RelatedFacilityInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.RelatedFacilityService
{
    public class RelatedFacilityService: IRelatedFacilityService
    {
        private MediClinicContext _context;
        private IMapper _mapper;

        public RelatedFacilityService(MediClinicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseDto<bool>> isExistorNot(string Name)
        {
            var isExist = false;
            var value = await _context.RelatedFacilities.Where(x => x.RelatedFacility.ToLower() == Name.ToLower()).FirstOrDefaultAsync();
            if (!(value is null))
            {
                isExist = true;
            }
            var response = new ResponseDto<bool>();
            response.Data = isExist;
            return response;
        }

        public async Task<ResponseDto<List<RelatedFacilityBasicDto>>> relatedFacility()
        {
            var rec = await _context.RelatedFacilities.ToListAsync();
            var response = new ResponseDto<List<RelatedFacilityBasicDto>>();
            response.Data = _mapper.Map<List<RelatedFacilities>, List<RelatedFacilityBasicDto>>(rec);
            return response;
        }
        
        public List<RelatedFacilities> RelatedFacilityByName(string name)
        {
            dynamic rec = null;
            if (name != null)
            {
                rec = _context.RelatedFacilities.Where(x => x.RelatedFacility.Contains(name)).ToList();
            }
            else
            {
                rec = _context.RelatedFacilities.ToList();
            }
            return rec;
        }
        public async Task<ResponseDto<int>> relatedFacilityCreate(RelatedFacilityBasicDto relatedFacilityBasicDto)
        {
            if (!(relatedFacilityBasicDto.RelatedFacility is null))
            {
                relatedFacilityBasicDto.RelatedFacility = relatedFacilityBasicDto.RelatedFacility.Trim();
            }
            var mapped = _mapper.Map<RelatedFacilityBasicDto, RelatedFacilities>(relatedFacilityBasicDto);
            var data = await _context.RelatedFacilities.AddAsync(mapped);
            _context.SaveChanges();
            
            var response = new ResponseDto<int>();
            response.Data = mapped.RelatedFacilityId;
            return response;
        }

        public async Task<ResponseDto<bool>> relatedFacilityDeleteById(int Id)
        {
            var oldEntity = await _context.RelatedFacilities.FirstOrDefaultAsync(x => x.RelatedFacilityId == Id);
            _context.Remove(oldEntity);
            _context.SaveChanges();
            var response = new ResponseDto<bool>();
            response.Data = true;
            return response;
        }

        public async Task<ResponseDto<RelatedFacilityBasicDto>> relatedFacilityGetId(int Id)
        {
            var oldEntity = await _context.RelatedFacilities.FirstOrDefaultAsync(x => x.RelatedFacilityId == Id);
            var mapped = _mapper.Map<RelatedFacilities, RelatedFacilityBasicDto>(oldEntity);
            var response = new ResponseDto<RelatedFacilityBasicDto>();
            response.Data = mapped;
            return response;
        }

        public async Task<ResponseDto<bool>> relatedFacilityUpdate(RelatedFacilityBasicDto relatedFacilityBasicDto)
        {
            var mapped = _mapper.Map<RelatedFacilityBasicDto, RelatedFacilities>(relatedFacilityBasicDto);
            var oldEntity = await _context.RelatedFacilities.FindAsync(mapped.RelatedFacilityId);
            _context.Entry(oldEntity).CurrentValues.SetValues(mapped);
            await _context.SaveChangesAsync();
            var response = new ResponseDto<bool>();
            response.Data = true;
            return response;
        }
    }
}
