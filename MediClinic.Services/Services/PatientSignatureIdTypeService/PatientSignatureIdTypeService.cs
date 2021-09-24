using AutoMapper;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.PatientSignatureIdTypeBasicDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.PatientSignatureIdTypeInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.PatientSignatureIdTypeService
{
    public class PatientSignatureIdTypeService : IPatientSignatureIdTypeService
    {
        private MediClinicContext _context;
        private IMapper _mapper;

        public PatientSignatureIdTypeService(MediClinicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseDto<bool>> isExistorNot(string name)
        {
            var isExist = false;
            var value = await _context.PatientSignatureIdType.Where(x => x.TypeName.ToLower() == name.ToLower()).FirstOrDefaultAsync();
            if (!(value is null))
            {
                isExist = true;
            }
            var response = new ResponseDto<bool>();
            response.Data = isExist;
            return response;
        }

        public async Task<ResponseDto<int>> PatientSignatureIdType(PatientSignatureIdTypeDto patientSignatureIdTypeBasicDto)
        {
            if (!(patientSignatureIdTypeBasicDto.TypeName is null))
            {
                patientSignatureIdTypeBasicDto.TypeName = patientSignatureIdTypeBasicDto.TypeName.Trim();
            }
            var mapped = _mapper.Map<PatientSignatureIdTypeDto, PatientSignatureIdType>(patientSignatureIdTypeBasicDto);
            var data = await _context.PatientSignatureIdType.AddAsync(mapped);
            _context.SaveChanges();
         
            var response = new ResponseDto<int>();
            response.Data = mapped.TypeId;
            return response;
        }

        public Task<ResponseDto<PatientSignatureIdTypeDto>> PatientSignatureIdTypeById(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto<List<PatientSignatureIdTypeDto>>> PatientSignatureIdTypeList()
        {
            var rec = await _context.PatientSignatureIdType.ToListAsync();
            var response = new ResponseDto<List<PatientSignatureIdTypeDto>>();
            response.Data = _mapper.Map<List<PatientSignatureIdType>, List<PatientSignatureIdTypeDto>>(rec);
            return response;
        }
    }
}
