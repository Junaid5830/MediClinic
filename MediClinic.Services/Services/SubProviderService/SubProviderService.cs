using AutoMapper;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.SubProviderDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.SubProviderInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.SubProviderService
{
    public class SubProviderService: ISubProviderService
    {
        private MediClinicContext _context;
        private IMapper _mapper;

        public SubProviderService(MediClinicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ResponseDto<List<SubProviderBasicDto>>> subProvider()
        {
            var rec = await _context.SubProviders.ToListAsync();
            var response = new ResponseDto<List<SubProviderBasicDto>>();
            response.Data = _mapper.Map<List<SubProviders>, List<SubProviderBasicDto>>(rec);
            return response;
        }

        public async Task<ResponseDto<bool>> subProviderCreate(SubProviderBasicDto subProviderBasicDto)
        {
            var result = false;
            var mapped = _mapper.Map<SubProviderBasicDto, SubProviders>(subProviderBasicDto);
            var data = await _context.SubProviders.AddAsync(mapped);
            _context.SaveChanges();
            if (!(data is null))
            {
                result = true;
            }
            var response = new ResponseDto<bool>();
            response.Data = result;
            return response;
        }

        public async Task<ResponseDto<bool>> subProviderDeleteById(int Id)
        {
            var oldEntity = await _context.SubProviders.FirstOrDefaultAsync(x => x.SubProviderId == Id);
            _context.Remove(oldEntity);
            _context.SaveChanges();
            var response = new ResponseDto<bool>();
            response.Data = true;
            return response;
        }

        public async Task<ResponseDto<SubProviderBasicDto>> subProviderGetId(int Id)
        {
            var oldEntity = await _context.SubProviders.FirstOrDefaultAsync(x => x.SubProviderId == Id);
            var mapped = _mapper.Map<SubProviders, SubProviderBasicDto>(oldEntity);
            var response = new ResponseDto<SubProviderBasicDto>();
            response.Data = mapped;
            return response;
        }

        public async Task<ResponseDto<bool>> subProviderUpdate(SubProviderBasicDto subProviderBasicDto)
        {
            var mapped = _mapper.Map<SubProviderBasicDto, SubProviders>(subProviderBasicDto);
            var oldEntity = await _context.SubProviders.FindAsync(mapped.SubProviderId);
            _context.Entry(oldEntity).CurrentValues.SetValues(mapped);
            await _context.SaveChangesAsync();
            var response = new ResponseDto<bool>();
            response.Data = true;
            return response;
        }
    }
}
