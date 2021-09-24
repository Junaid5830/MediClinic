using AutoMapper;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.PatientLegalStatusDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.PatientLegalStatusInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.PatientLegalStatusService
{
    public class PatientLegalStatusService : IPatientLegalStatusService
    {
        private MediClinicContext _context;
        private IMapper _mapper;

        public PatientLegalStatusService(MediClinicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseDto<List<PatientLegalStatusBasicDto>>> patientlegalStatus()
        {
            var rec = await _context.PatientLegalStatus.ToListAsync();
            var response = new ResponseDto<List<PatientLegalStatusBasicDto>>();
            response.Data = _mapper.Map<List<PatientLegalStatus>, List<PatientLegalStatusBasicDto>>(rec);
            return response;
        }

        public List<PatientLegalStatus> patientLegalStatusList(string legalName)
        {
            var rec = _context.PatientLegalStatus.ToList();
            return rec;
        }

        public async Task<ResponseDto<int>> patientLegalStatusCreate(PatientLegalStatusBasicDto patientLegalStatusBasicDto)
        {
            if (!(patientLegalStatusBasicDto.PatientLegalStatus1 is null))
            {
                patientLegalStatusBasicDto.PatientLegalStatus1 = patientLegalStatusBasicDto.PatientLegalStatus1.Trim();
            }
            var mapped = _mapper.Map<PatientLegalStatusBasicDto, PatientLegalStatus>(patientLegalStatusBasicDto);
            var data = await _context.PatientLegalStatus.AddAsync(mapped);
            _context.SaveChanges();
            
            var response = new ResponseDto<int>();
            response.Data = mapped.PatientLegalId;
            return response;
        }
        public async Task<ResponseDto<bool>> patientLegalStatusDeleteById(int Id)
        {
            var oldEntity = await _context.PatientLegalStatus.FirstOrDefaultAsync(x => x.PatientLegalId == Id);
            _context.Remove(oldEntity);
            _context.SaveChanges();
            var response = new ResponseDto<bool>();
            response.Data = true;
            return response;
        }

        public async Task<ResponseDto<PatientLegalStatusBasicDto>> patientLegalStatusGetId(int Id)
        {
            var oldEntity = await _context.PatientLegalStatus.FirstOrDefaultAsync(x => x.PatientLegalId == Id);
            var mapped = _mapper.Map<PatientLegalStatus, PatientLegalStatusBasicDto>(oldEntity);
            var response = new ResponseDto<PatientLegalStatusBasicDto>();
            response.Data = mapped;
            return response;
        }

        public async Task<ResponseDto<bool>> patientLegalStatusUpdate(PatientLegalStatusBasicDto patientLegalStatusBasicDto)
        {
            var mapped = _mapper.Map<PatientLegalStatusBasicDto, PatientLegalStatus>(patientLegalStatusBasicDto);
            var oldEntity = await _context.PatientLegalStatus.FindAsync(mapped.PatientLegalId);
            _context.Entry(oldEntity).CurrentValues.SetValues(mapped);
            await _context.SaveChangesAsync();
            var response = new ResponseDto<bool>();
            response.Data = true;
            return response;
        }

        public async Task<ResponseDto<bool>> IsExitorNot(string Name)
        {
            var isExist = false;
            var Value = await _context.PatientLegalStatus.Where(x => x.PatientLegalStatus1.ToLower() == Name.ToLower()).FirstOrDefaultAsync();
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
