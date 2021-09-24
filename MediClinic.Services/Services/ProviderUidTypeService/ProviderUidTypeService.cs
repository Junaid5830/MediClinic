using AutoMapper;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.ProviderUidTypeDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.ProviderUidTypeInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.ProviderUidTypeService
{
    public class ProviderUidTypeService: IProviderUidTypeService
    {
        private MediClinicContext _context;
        private IMapper _mapper;

        public ProviderUidTypeService(MediClinicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ResponseDto<List<ProviderUidTypeBasicDto>>> providerUidType()
        {
            var rec = await _context.ProviderUIDTypes.ToListAsync();
            var response = new ResponseDto<List<ProviderUidTypeBasicDto>>();
            response.Data = _mapper.Map<List<ProviderUIDTypes>, List<ProviderUidTypeBasicDto>>(rec);
            return response;
        }
        public List<ProviderUIDTypes> providerUidTypeBasicDto()
        {
            var rec = _context.ProviderUIDTypes.ToList();
            return rec;
        }
        public List<ProviderUIDTypes> providerUidTypeByName(string name)
        {
            dynamic rec = null;
            if (name != null)
            {
                rec = _context.ProviderUIDTypes.Where(x => x.ProviderUIDType.Contains(name)).ToList();
            }
            else
            {
                rec = _context.ProviderUIDTypes.ToList();
            }
            return rec;
        }
        public async Task<ResponseDto<bool>> providerUidTypeCreate(ProviderUidTypeBasicDto providerUidTypeBasicDto)
        {
            var result = false;
            var mapped = _mapper.Map<ProviderUidTypeBasicDto, ProviderUIDTypes>(providerUidTypeBasicDto);
            var data = await _context.ProviderUIDTypes.AddAsync(mapped);
            _context.SaveChanges();
            if (!(data is null))
            {
                result = true;
            }
            var response = new ResponseDto<bool>();
            response.Data = result;
            return response;
        }

        public async Task<ResponseDto<bool>> providerUidTypeDeleteById(int Id)
        {
            var oldEntity = await _context.ProviderUIDTypes.FirstOrDefaultAsync(x => x.ProviderUIDTypeId == Id);
            _context.Remove(oldEntity);
            _context.SaveChanges();
            var response = new ResponseDto<bool>();
            response.Data = true;
            return response;
        }

        public async Task<ResponseDto<ProviderUidTypeBasicDto>> providerUidTypeGetId(int Id)
        {
            var oldEntity = await _context.ProviderUIDTypes.FirstOrDefaultAsync(x => x.ProviderUIDTypeId == Id);
            var mapped = _mapper.Map<ProviderUIDTypes, ProviderUidTypeBasicDto>(oldEntity);
            var response = new ResponseDto<ProviderUidTypeBasicDto>();
            response.Data = mapped;
            return response;
        }

        public async Task<ResponseDto<bool>> providerUidTypeUpdate(ProviderUidTypeBasicDto providerUidTypeBasicDto)
        {
            var mapped = _mapper.Map<ProviderUidTypeBasicDto, ProviderUIDTypes>(providerUidTypeBasicDto);
            var oldEntity = await _context.ProviderUIDTypes.FindAsync(mapped.ProviderUIDTypeId);
            _context.Entry(oldEntity).CurrentValues.SetValues(mapped);
            await _context.SaveChangesAsync();
            var response = new ResponseDto<bool>();
            response.Data = true;
            return response;
        }
    }
}
