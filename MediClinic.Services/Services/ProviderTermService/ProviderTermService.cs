using AutoMapper;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.ProviderTermDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.ProviderTermInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.ProviderTermService
{
    public class ProviderTermService: IProviderTermService
    {
        private MediClinicContext _context;
        private IMapper _mapper;

        public ProviderTermService(MediClinicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ResponseDto<List<ProviderTermBasicDto>>> providerTerm()
        {
            var rec = await _context.ProviderTerms.ToListAsync();
            var response = new ResponseDto<List<ProviderTermBasicDto>>();
            response.Data = _mapper.Map<List<ProviderTerms>, List<ProviderTermBasicDto>>(rec);
            return response;
        }

        public List<ProviderTerms> providerTermByName(string name)
        {
            dynamic rec = null;
            if (name != null)
            {
                rec = _context.ProviderTerms.Where(x => x.ProviderTerm.Contains(name)).ToList();
            }
            else
            {
                rec = _context.ProviderTerms.ToList();
            }
            return rec;
        }
        public async Task<ResponseDto<bool>> providerTermCreate(ProviderTermBasicDto providerTermBasicDto)
        {
            var result = false;
            var mapped = _mapper.Map<ProviderTermBasicDto, ProviderTerms>(providerTermBasicDto);
            var data = await _context.ProviderTerms.AddAsync(mapped);
            _context.SaveChanges();
            if (!(data is null))
            {
                result = true;
            }
            var response = new ResponseDto<bool>();
            response.Data = result;
            return response;
        }

        public async Task<ResponseDto<bool>> providerTermDeleteById(int Id)
        {
            var oldEntity = await _context.ProviderTerms.FirstOrDefaultAsync(x => x.ProviderTermId == Id);
            _context.Remove(oldEntity);
            _context.SaveChanges();
            var response = new ResponseDto<bool>();
            response.Data = true;
            return response;
        }

        public async Task<ResponseDto<ProviderTermBasicDto>> providerTermGetId(int Id)
        {
            var oldEntity = await _context.ProviderTerms.FirstOrDefaultAsync(x => x.ProviderTermId == Id);
            var mapped = _mapper.Map<ProviderTerms, ProviderTermBasicDto>(oldEntity);
            var response = new ResponseDto<ProviderTermBasicDto>();
            response.Data = mapped;
            return response;
        }

        public async Task<ResponseDto<bool>> providerTermUpdate(ProviderTermBasicDto providerTermBasicDto)
        {
            var mapped = _mapper.Map<ProviderTermBasicDto, ProviderTerms>(providerTermBasicDto);
            var oldEntity = await _context.ProviderTerms.FindAsync(mapped.ProviderTermId);
            _context.Entry(oldEntity).CurrentValues.SetValues(mapped);
            await _context.SaveChangesAsync();
            var response = new ResponseDto<bool>();
            response.Data = true;
            return response;
        }
    }
}
