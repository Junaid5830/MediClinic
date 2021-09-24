using AutoMapper;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.InsuranceGroupNumberBasicDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.InsuranceGroupNumberInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.InsuranceGroupNumberService
{
    public class InsuranceGroupNumberService : IInsuranceGroupNumberService
    {
        private MediClinicContext _context;
        private IMapper _mapper;

        public InsuranceGroupNumberService(MediClinicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ResponseDto<int>> InsuranceGroupNumber(InsuranceGroupNumberBasicDto insuranceGroupNumberBasicDto)
        {
            if (!(insuranceGroupNumberBasicDto.GroupName is null))
            {
                insuranceGroupNumberBasicDto.GroupName = insuranceGroupNumberBasicDto.GroupName.Trim();
            }
            var mapped = _mapper.Map<InsuranceGroupNumberBasicDto, InsuranceGroupNumber>(insuranceGroupNumberBasicDto);
            var data = await _context.InsuranceGroupNumber.AddAsync(mapped);
            _context.SaveChanges();
            
            var response = new ResponseDto<int>();
            response.Data = mapped.GroupId;
            return response;
        }

        public Task<ResponseDto<InsuranceGroupNumberBasicDto>> InsuranceGroupNumberById(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto<List<InsuranceGroupNumberBasicDto>>> InsuranceGroupNumberList()
        {
            var rec = await _context.InsuranceGroupNumber.ToListAsync();
            var response = new ResponseDto<List<InsuranceGroupNumberBasicDto>>();
            response.Data = _mapper.Map<List<InsuranceGroupNumber>, List<InsuranceGroupNumberBasicDto>>(rec);
            return response;
        }

        public async Task<ResponseDto<bool>> isExistorNot(string Name)
        {
            var isExist = false;
            var value = await _context.InsuranceGroupNumber.Where(x => x.GroupName.ToLower() == Name.ToLower()).FirstOrDefaultAsync();
            if (!(value is null))
            {
                isExist = true;
            }
            var response = new ResponseDto<bool>();
            response.Data = isExist;
            return response;
        }
    }
}
