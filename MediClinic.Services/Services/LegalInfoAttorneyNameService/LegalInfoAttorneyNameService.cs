using AutoMapper;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.LegalInfoAttorneyNameDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.LegalInfoAttorneyNameInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.LegalInfoAttorneyNameService
{
    public class LegalInfoAttorneyNameService : ILegalInfoAttorneyNameService
    {
        private MediClinicContext _context;
        private IMapper _mapper;

        public LegalInfoAttorneyNameService(MediClinicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ResponseDto<List<LegalInfoAttorneyNameBasicDto>>> LegalInfoAttorneyList()
        {
            var rec = await _context.LegalInfoAttorneyName.ToListAsync();
            var response = new ResponseDto<List<LegalInfoAttorneyNameBasicDto>>();
            response.Data = _mapper.Map<List<LegalInfoAttorneyName>, List<LegalInfoAttorneyNameBasicDto>>(rec);
            return response;
        }

        public async Task<ResponseDto<int>> LegalInfoAttorneyName(LegalInfoAttorneyNameBasicDto legalInfoAttorneyNameBasicDto)
        {
            if (!(legalInfoAttorneyNameBasicDto.AttorneyName is null))
            {
                legalInfoAttorneyNameBasicDto.AttorneyName = legalInfoAttorneyNameBasicDto.AttorneyName.Trim();
            }
            var mapped = _mapper.Map<LegalInfoAttorneyNameBasicDto, LegalInfoAttorneyName>(legalInfoAttorneyNameBasicDto);
            var data = await _context.LegalInfoAttorneyName.AddAsync(mapped);
            _context.SaveChanges();
            
            var response = new ResponseDto<int>();
            response.Data = mapped.AttorneyId;
            return response;
        }

        public Task<ResponseDto<LegalInfoAttorneyNameBasicDto>> LegalInfoAttorneyNameId(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<bool>> LegalInfoAttorneyNameUpdate(LegalInfoAttorneyNameBasicDto legalInfoFirmNameBasicDto)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto<bool>> IsExistorNot(string Name)
        {
            var isExist = false;
            var Value = await _context.LegalInfoAttorneyName.Where(x => x.AttorneyName.ToLower() == Name.ToLower()).FirstOrDefaultAsync();
            if (!(Value is null))
            {
                isExist = true;
            }
            var response = new ResponseDto<bool>();
            response.Data = isExist;
            return response;
        }
    }
}
