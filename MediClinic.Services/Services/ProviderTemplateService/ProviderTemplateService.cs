using AutoMapper;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.ProviderTemplateDto;
using MediClinic.Models.DTOs.TemplateDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.ProviderTemplateInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.ProviderTemplateService
{
    public class ProviderTemplateService : IProviderTemplateService
    {
        private MediClinicContext _context;
        private IMapper _mapper;

        public ProviderTemplateService(MediClinicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ResponseDto<List<ProviderTemplateBasicDto>>> providerTemplate()
        {
            var rec = await _context.ProviderTemplates.ToListAsync();
            var response = new ResponseDto<List<ProviderTemplateBasicDto>>();
            response.Data = _mapper.Map<List<ProviderTemplates>, List<ProviderTemplateBasicDto>>(rec);
            return response;
        }
        public List<ProviderTemplates> providerTemplateByname(string name)
        {
            dynamic rec = null;
            if (name != null)
            {
                rec = _context.ProviderTemplates.Where(x => x.ProviderTemplate.Contains(name)).ToList();
            }
            else
            {
                rec = _context.ProviderTemplates.ToList();
            }
            return rec;
        }

        public async Task<ResponseDto<bool>> providerTemplateCreate(ProviderTemplateBasicDto providerTemplateBasicDto)
        {
            var result = false;
            var mapped = _mapper.Map<ProviderTemplateBasicDto, ProviderTemplates>(providerTemplateBasicDto);
            var data = await _context.ProviderTemplates.AddAsync(mapped);
            _context.SaveChanges();
            if (!(data is null))
            {
                result = true;
            }
            var response = new ResponseDto<bool>();
            response.Data = result;
            return response;
        }

        public async Task<ResponseDto<bool>> providerTemplateDeleteById(int Id)
        {
            var oldEntity = await _context.ProviderTemplates.FirstOrDefaultAsync(x => x.ProviderTemplateId == Id);
            _context.Remove(oldEntity);
            _context.SaveChanges();
            var response = new ResponseDto<bool>();
            response.Data = true;
            return response;
        }

        public async Task<ResponseDto<ProviderTemplateBasicDto>> providerTemplateGetId(int Id)
        {
            var oldEntity = await _context.ProviderTemplates.FirstOrDefaultAsync(x => x.ProviderTemplateId == Id);
            var mapped = _mapper.Map<ProviderTemplates, ProviderTemplateBasicDto>(oldEntity);
            var response = new ResponseDto<ProviderTemplateBasicDto>();
            response.Data = mapped;
            return response;
        }

        public async Task<ResponseDto<bool>> providerTemplateUpdate(ProviderTemplateBasicDto providerTemplateBasicDto)
        {
            var mapped = _mapper.Map<ProviderTemplateBasicDto, ProviderTemplates>(providerTemplateBasicDto);
            var oldEntity = await _context.ProviderTemplates.FindAsync(mapped.ProviderTemplateId);
            _context.Entry(oldEntity).CurrentValues.SetValues(mapped);
            await _context.SaveChangesAsync();
            var response = new ResponseDto<bool>();
            response.Data = true;
            return response;
        }

        
    }
}
