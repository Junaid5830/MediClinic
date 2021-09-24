using AutoMapper;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.InsuranceProviderNameBasicDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.InsuranceProviderNameInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.InsuranceProviderService
{

    public class InsuranceProviderNameService : IInsuranceProviderNameService
    {
        private MediClinicContext _context;
        private IMapper _mapper;

        public InsuranceProviderNameService(MediClinicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ResponseDto<int>> InsuranceProviderName(InsuranceProviderNameBasicDto insuranceProviderNameBasicDto)
        {
            if (!(insuranceProviderNameBasicDto.ProviderName is null))
            {
                insuranceProviderNameBasicDto.ProviderName = insuranceProviderNameBasicDto.ProviderName.Trim();
            }
            var mapped = _mapper.Map<InsuranceProviderNameBasicDto, InsuranceProviderName>(insuranceProviderNameBasicDto);
            var data = await _context.InsuranceProviderName.AddAsync(mapped);
            _context.SaveChanges();
            
            var response = new ResponseDto<int>();
            response.Data = mapped.ProviderId;
            return response;
        }

        public Task<ResponseDto<InsuranceProviderNameBasicDto>> InsuranceProviderNameById(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto<List<InsuranceProviderNameBasicDto>>> InsuranceProviderNameList()
        {
            var rec = await _context.InsuranceProviderName.ToListAsync();
            var response = new ResponseDto<List<InsuranceProviderNameBasicDto>>();
            response.Data = _mapper.Map<List<InsuranceProviderName>, List<InsuranceProviderNameBasicDto>>(rec);
            return response;
        }

        public async Task<ResponseDto<bool>> isExistorNot(string Name)
        {
            var isExist = false;
            var Value = await _context.InsuranceProviderName.Where(x=>x.ProviderName.ToLower() == Name.ToLower()).FirstOrDefaultAsync();
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
