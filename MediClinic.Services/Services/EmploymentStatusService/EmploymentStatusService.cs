using AutoMapper;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.EmploymentStatusDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.EmploymentStatusInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.EmploymentStatusService
{
    public class EmploymentStatusService : IEmploymentStatusService
    {
        private MediClinicContext _context;
        private IMapper _mapper;

        public EmploymentStatusService(MediClinicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ResponseDto<int>> EmploymentStatus(EmploymentStatusBasicDto employmentStatusBasicDto)
        {
            if (!(employmentStatusBasicDto.EmploymentStatus1 is null))
            {
                employmentStatusBasicDto.EmploymentStatus1 = employmentStatusBasicDto.EmploymentStatus1.Trim();
            }
            var mapped = _mapper.Map<EmploymentStatusBasicDto, EmploymentStatus>(employmentStatusBasicDto);
            var data = await _context.EmploymentStatus.AddAsync(mapped);
            _context.SaveChanges();
            
            var response = new ResponseDto<int>();
            response.Data = mapped.EmploymentStatusId;
            return response;
        }

        public Task<ResponseDto<bool>> EmploymentStatusDeleteId(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<EmploymentStatusBasicDto>> EmploymentStatusId(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto<List<EmploymentStatusBasicDto>>> EmploymentStatusList()
        {
            var rec = await _context.EmploymentStatus.ToListAsync();
            var response = new ResponseDto<List<EmploymentStatusBasicDto>>();
            response.Data = _mapper.Map<List<EmploymentStatus>, List<EmploymentStatusBasicDto>>(rec);
            return response;
        }

        public Task<ResponseDto<bool>> EmploymentStatusUpdate(EmploymentStatusBasicDto employmentStatusBasicDto)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto<bool>> isExistorNot(string Name)
        {
            var isExist = false;
            var value = await _context.EmploymentStatus.Where(x => x.EmploymentStatus1.ToLower() == Name.ToLower()).FirstOrDefaultAsync();
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
