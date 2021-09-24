using AutoMapper;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.LegalInfoFirmNameDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.LeagalInfoFirmNameInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.LegalInfoFirmNameService
{
    public class LegalInfoFirmNameService : ILegalInfoFirmNameService
    {
        private MediClinicContext _context;
        private IMapper _mapper;

        public LegalInfoFirmNameService(MediClinicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseDto<bool>> isExistorNot(string Name)
        {
            var isExist = false;
            var Value = await _context.LegalInfoFirmName.Where(x => x.FirmName.ToLower() == Name.ToLower()).FirstOrDefaultAsync();
            if (!(Value is null))
            {
                isExist = true;
            }
            var response = new ResponseDto<bool>();
            response.Data = isExist;
            return response;
        }

        public async Task<ResponseDto<int>> LegalInfoFirmName(LegalInfoFirmNameBasicDto legalInfoFirmNameBasicDto)
        {
            if (!(legalInfoFirmNameBasicDto.FirmName is null))
            {
                legalInfoFirmNameBasicDto.FirmName = legalInfoFirmNameBasicDto.FirmName.Trim();
            }
            var mapped = _mapper.Map<LegalInfoFirmNameBasicDto, LegalInfoFirmName>(legalInfoFirmNameBasicDto);
            var data = await _context.LegalInfoFirmName.AddAsync(mapped);
            _context.SaveChanges();
            
            var response = new ResponseDto<int>();
            response.Data = mapped.FirmId;
            return response;
        }

        public Task<ResponseDto<LegalInfoFirmNameBasicDto>> LegalInfoFirmNameId(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto<List<LegalInfoFirmNameBasicDto>>> LegalInfoFirmNameList()
        {
            var rec = await _context.LegalInfoFirmName.ToListAsync();
            var response = new ResponseDto<List<LegalInfoFirmNameBasicDto>>();
            response.Data = _mapper.Map<List<LegalInfoFirmName>, List<LegalInfoFirmNameBasicDto>>(rec);
            return response;
        }

        public Task<ResponseDto<bool>> LegalInfoFirmNameUpdte(LegalInfoFirmNameBasicDto legalInfoFirmNameBasicDto)
        {
            throw new NotImplementedException();
        }

        
    }
}
