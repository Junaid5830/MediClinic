using AutoMapper;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.PatientCaseTypeDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.PatientCaseTypeInterface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.PatientCaseTypeService
{
    public class PatientCaseTypeService : IPatientCaseTypeService
    {
        private MediClinicContext _context;
        private IMapper _mapper;

        public PatientCaseTypeService(MediClinicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseDto<bool>> PatientCaseTypeCreate(PatientCaseTypeBasicDto patientCaseTypeBasicDto)
        {
            var result = false;
            var mapped = _mapper.Map<PatientCaseTypeBasicDto, PatientCaseType>(patientCaseTypeBasicDto);
            var data = await _context.PatientCaseType.AddAsync(mapped);
            _context.SaveChanges();
            if (!(data is null))
            {
                result = true;
            }
            var response = new ResponseDto<bool>();
            response.Data = result;
            return response;
        }

        public async Task<ResponseDto<bool>> PatientCaseTypeUpdate(PatientCaseTypeBasicDto patientCaseTypeBasicDto)
        {
            var mapped = _mapper.Map<PatientCaseTypeBasicDto, PatientCaseType>(patientCaseTypeBasicDto);
            var oldEntity = await _context.PatientCaseType.FindAsync(mapped.CaseTypeId);
            _context.Entry(oldEntity).CurrentValues.SetValues(mapped);
            await _context.SaveChangesAsync();
            var response = new ResponseDto<bool>();
            response.Data = true;
            return response;
        }
    }
}
