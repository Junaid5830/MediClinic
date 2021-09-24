using AutoMapper;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.PatientLanguageDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.PatientLanguageInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.PatientLanguageService
{
    public class PatientLanguageService : IPatientLanguageService
    {
        private MediClinicContext _context;
        private IMapper _mapper;

        public PatientLanguageService(MediClinicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ResponseDto<bool>> isExistorNot(string Name)
        {
            var isExist = false;
            var value = await _context.PatientLanguage.Where(x => x.LanguageName.ToLower() == Name.ToLower()).FirstOrDefaultAsync();
            if (!(value is null))
            {
                isExist = true;
            }
            var response = new ResponseDto<bool>();
            response.Data = isExist;
            return response;
        }

        public async Task<ResponseDto<int>> patientLanguage(PatientLanguageBasicDto patientLanguageBasicDto)
        {
            if (!(patientLanguageBasicDto.LanguageName is null))
            {
                patientLanguageBasicDto.LanguageName = patientLanguageBasicDto.LanguageName.Trim();
            }
            var mapped = _mapper.Map<PatientLanguageBasicDto, PatientLanguage>(patientLanguageBasicDto);
            var data = await _context.PatientLanguage.AddAsync(mapped);
            _context.SaveChanges();

            var response = new ResponseDto<int>();
            response.Data = mapped.LanguageId;
            return response;
        }

        public Task<ResponseDto<PatientLanguageBasicDto>> patientLanguageById(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto<List<PatientLanguageBasicDto>>> patientLanguageList()
        {
            var rec = await _context.PatientLanguage.ToListAsync();
            var response = new ResponseDto<List<PatientLanguageBasicDto>>();
            response.Data = _mapper.Map<List<PatientLanguage>, List<PatientLanguageBasicDto>>(rec);
            return response;
        }
    }
}
