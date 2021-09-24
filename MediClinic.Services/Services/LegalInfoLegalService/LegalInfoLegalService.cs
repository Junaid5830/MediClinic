using AutoMapper;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.LegalInfolegealStatusDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.LegalInfoLegalInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.LegalInfoLegalService
{
    public class LegalInfoLegalService : ILegalInfolegalService
    {
        private MediClinicContext _context;
        private IMapper _mapper;

        public LegalInfoLegalService(MediClinicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseDto<bool>> isExistorNot(string Name)
        {
            var isExist = false;
            var Value = await _context.LegalInfoLegalStatus.Where(x => x.LegalStatus.ToLower() == Name.ToLower()).FirstOrDefaultAsync();
            if (!(Value is null))
            {
                isExist = true;
            }
            var response = new ResponseDto<bool>();
            response.Data = isExist;
            return response;
        }

        public async Task<ResponseDto<List<legalInfoLegalBasicDto>>> LegalInfolegalStatusList()
        {
            var rec = await _context.LegalInfoLegalStatus.ToListAsync();
            var response = new ResponseDto<List<legalInfoLegalBasicDto>>();
            response.Data = _mapper.Map<List<LegalInfoLegalStatus>, List<legalInfoLegalBasicDto>>(rec);
            return response;
        }

        public  async Task<ResponseDto<int>> Legalinfostatus(legalInfoLegalBasicDto legalInfoLegalBasicDto)
        {
            if (!(legalInfoLegalBasicDto.LegalStatus is null))
            {
                legalInfoLegalBasicDto.LegalStatus = legalInfoLegalBasicDto.LegalStatus.Trim();
            }
            var mapped = _mapper.Map<legalInfoLegalBasicDto, LegalInfoLegalStatus>(legalInfoLegalBasicDto);
            var data = await _context.LegalInfoLegalStatus.AddAsync(mapped);
            _context.SaveChanges();
            
            var response = new ResponseDto<int>();
            response.Data = mapped.legalStatusId;
            return response;
        }
    }
}
