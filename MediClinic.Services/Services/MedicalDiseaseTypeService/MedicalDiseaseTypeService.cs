using AutoMapper;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.MedicalDiseaseTypeDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.MedicalDiseaseTypeInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.MedicalDiseaseTypeService
{
    public class MedicalDiseaseTypeService : IMedicalDiseaseTypeService
    {
        private MediClinicContext _context;
        private IMapper _mapper;

        public MedicalDiseaseTypeService(MediClinicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ResponseDto<bool>> isExistorNot(string Name)
        {
            var isExist = false;
            var value = await _context.MedicalDiseaseType.Where(x => x.DiseaseTypeName.ToLower() == Name.ToLower()).FirstOrDefaultAsync();
            if (!(value is null))
            {
                isExist = true;
            }
            var response = new ResponseDto<bool>();
            response.Data = isExist;
            return response;
        }

        public async Task<ResponseDto<List<MedicalDiseaseTypeBasicDto>>> MedicalDiseaseList()
        {
            var rec = await _context.MedicalDiseaseType.ToListAsync();
            var response = new ResponseDto<List<MedicalDiseaseTypeBasicDto>>();
            response.Data = _mapper.Map<List<MedicalDiseaseType>, List<MedicalDiseaseTypeBasicDto>>(rec);
            return response;
        }

        public async Task<ResponseDto<int>> MedicalDiseaseType(MedicalDiseaseTypeBasicDto medicalDiseaseTypeBasicDto)
        {
            if (!(medicalDiseaseTypeBasicDto.DiseaseTypeName is null))
            {
                medicalDiseaseTypeBasicDto.DiseaseTypeName = medicalDiseaseTypeBasicDto.DiseaseTypeName.Trim();
            }
            var mapped = _mapper.Map<MedicalDiseaseTypeBasicDto, MedicalDiseaseType>(medicalDiseaseTypeBasicDto);
            var data = await _context.MedicalDiseaseType.AddAsync(mapped);
            _context.SaveChanges();

            var response = new ResponseDto<int>();
            response.Data = mapped.DiseaseTypeId;
            return response;
        }
    }
}
