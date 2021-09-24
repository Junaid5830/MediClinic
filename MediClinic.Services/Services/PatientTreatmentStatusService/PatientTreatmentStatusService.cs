using AutoMapper;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.PatientTreatmentStatusDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.PatientTreatmentStatusInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.PatientTreatmentStatusService
{
    public class PatientTreatmentStatusService : IPatientTreatmentStatusService
    {
        private MediClinicContext _context;
        private IMapper _mapper;

        public PatientTreatmentStatusService(MediClinicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseDto<bool>> IsExistOrNot(string Name)
        {
            var isExist = false;
            var value = await _context.PatientTreatmentStatus.Where(x => x.PatientTreatmentStatus1.ToLower() == Name.ToLower()).FirstOrDefaultAsync();
            if (!(value is null))
            {
                isExist = true;
            }
            var response = new ResponseDto<bool>();
            response.Data = isExist;
            return response ;
        }

        public List<PatientTreatmentStatus> patientTreatmentlist(dynamic name)
        {
            var rec = _context.PatientTreatmentStatus.ToList();
            return rec;
            
        }
        public async Task<ResponseDto<List<PatientTreatmentStatusBasicDto>>> patientTreatmentStatus()
        {
            var rec = await _context.PatientTreatmentStatus.ToListAsync();
            var response = new ResponseDto<List<PatientTreatmentStatusBasicDto>>();
            response.Data = _mapper.Map<List<PatientTreatmentStatus>, List<PatientTreatmentStatusBasicDto>>(rec);
            return response;
        }
        public async Task<ResponseDto<int>> patientTreatmentStatusCreate(PatientTreatmentStatusBasicDto patientTreatmentStatusBasicDto)
        {
            if (!(patientTreatmentStatusBasicDto.PatientTreatmentStatus1 is null))
            {
                patientTreatmentStatusBasicDto.PatientTreatmentStatus1 = patientTreatmentStatusBasicDto.PatientTreatmentStatus1.Trim();
            }
            var mapped = _mapper.Map<PatientTreatmentStatusBasicDto, PatientTreatmentStatus>(patientTreatmentStatusBasicDto);
            var data = await _context.PatientTreatmentStatus.AddAsync(mapped);
            _context.SaveChanges();
            
            var response = new ResponseDto<int>();
            response.Data = mapped.PatientTreatmentId;
            return response;
        }
        public async Task<ResponseDto<bool>> patientTreatmentStatusDeleteById(int Id)
        {
            var oldEntity = await _context.PatientTreatmentStatus.FirstOrDefaultAsync(x => x.PatientTreatmentId == Id);
            _context.Remove(oldEntity);
            _context.SaveChanges();
            var response = new ResponseDto<bool>();
            response.Data = true;
            return response;
        }

        public async Task<ResponseDto<PatientTreatmentStatusBasicDto>> patientTreatmentStatusGetId(int Id)
        {
            var oldEntity = await _context.PatientTreatmentStatus.FirstOrDefaultAsync(x => x.PatientTreatmentId == Id);
            var mapped = _mapper.Map<PatientTreatmentStatus, PatientTreatmentStatusBasicDto>(oldEntity);
            var response = new ResponseDto<PatientTreatmentStatusBasicDto>();
            response.Data = mapped;
            return response;
        }

        public async Task<ResponseDto<bool>> patientTreatmentStatusUpdate(PatientTreatmentStatusBasicDto patientTreatmentStatusBasicDto)
        {
            var mapped = _mapper.Map<PatientTreatmentStatusBasicDto, PatientTreatmentStatus>(patientTreatmentStatusBasicDto);
            var oldEntity = await _context.PatientTreatmentStatus.FindAsync(mapped.PatientTreatmentId);
            _context.Entry(oldEntity).CurrentValues.SetValues(mapped);
            await _context.SaveChangesAsync();
            var response = new ResponseDto<bool>();
            response.Data = true;
            return response;
        }
    }
}
