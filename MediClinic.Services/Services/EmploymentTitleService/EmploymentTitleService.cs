using AutoMapper;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.EmploymentTitleDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.EmploymentTitleInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.EmploymentTitleService
{
    public class EmploymentTitleService : IEmploymentTitleService
    {
        private MediClinicContext _context;
        private IMapper _mapper;

        public EmploymentTitleService(MediClinicContext context,  IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ResponseDto<int>> EmploymentTitle(EmploymentTitleBasicDto employmentTitleBasicDto)
        {
            if (!(employmentTitleBasicDto.EmploymentTitle1 is null))
            {
                employmentTitleBasicDto.EmploymentTitle1 = employmentTitleBasicDto.EmploymentTitle1.Trim();
            }
            var mapped = _mapper.Map<EmploymentTitleBasicDto, EmploymentTitle>(employmentTitleBasicDto);
            var data = await _context.EmploymentTitle.AddAsync(mapped);
                _context.SaveChanges();
            var response = new ResponseDto<int>();
            response.Data = mapped.EmploymentTitleId;
            return response;
        }

        public Task<ResponseDto<bool>> EmploymentTitleDeleteId(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<EmploymentTitleBasicDto>> EmploymentTitleId(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto<List<EmploymentTitleBasicDto>>> EmploymentTitleList()
        {
            var rec = await _context.EmploymentTitle.ToListAsync();
            var response = new ResponseDto<List<EmploymentTitleBasicDto>>();
            response.Data = _mapper.Map<List<EmploymentTitle>, List<EmploymentTitleBasicDto>>(rec);
            return response;
            
         }

        public Task<ResponseDto<bool>> EmploymentTitleUpdate(EmploymentTitleBasicDto employmentTitleBasicDto)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto<bool>> isExistorNot(string Name)
        {
            var isExist = false;
            var value = await _context.EmploymentTitle.Where(x => x.EmploymentTitle1.ToLower() == Name.ToLower()).FirstOrDefaultAsync();
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
