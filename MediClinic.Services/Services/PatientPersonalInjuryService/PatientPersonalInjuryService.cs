using AutoMapper;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.PatientPIPersonalInjury;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.PatientPersonalInjuryInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.PatientPersonalInjuryService
{
    public class PatientPersonalInjuryService : IPatientPersonalInjuryService
    {
        private MediClinicContext _context;
        private IMapper _mapper;

        public PatientPersonalInjuryService (MediClinicContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public async Task<ResponseDto<bool>> patientPersonalInjury(PatientPersonalInjuryBasicDto patientPersonalInjuryBasicDto)
        {
            var result = false;
            var mapped = _mapper.Map<PatientPersonalInjuryBasicDto, PatientPersonalInjury>(patientPersonalInjuryBasicDto);
            var data = await _context.PatientPersonalInjury.AddAsync(mapped);
            _context.SaveChanges();
            if (!(data is null))
            {
                result = true;
            }
            var response = new ResponseDto<bool>();
            response.Data = result;
            return response;
        }

        public async Task<ResponseDto<PatientPersonalInjuryBasicDto>> patientPersonalInjuryId(int Id)
        {
            var oldEntity = await _context.PatientPersonalInjury.FirstOrDefaultAsync(x => x.PersonalInjuryId == Id);
            var mapped = _mapper.Map<PatientPersonalInjury, PatientPersonalInjuryBasicDto>(oldEntity);
            var response = new ResponseDto<PatientPersonalInjuryBasicDto>();
            response.Data = mapped;
            return response;
        }

        public async Task<ResponseDto<bool>> patientPersonalInjuryUpdae(PatientPersonalInjuryBasicDto patientPersonalInjuryBasicDto)
        {
            var mapped = _mapper.Map<PatientPersonalInjuryBasicDto, PatientPersonalInjury>(patientPersonalInjuryBasicDto);
            var oldEntity = await _context.PatientPersonalInjury.FindAsync(mapped.PersonalInjuryId);
            _context.Entry(oldEntity).CurrentValues.SetValues(mapped);
            await _context.SaveChangesAsync();
            var response = new ResponseDto<bool>();
            response.Data = true;
            return response;
        }
    }
}
