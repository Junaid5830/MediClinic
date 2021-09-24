using AutoMapper;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.PatientRelationshipDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.PatientRelationshipInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.PatientRelationshipService
{
    public class PatientRelationshipService: IPatientRelationshipService
    {
        private MediClinicContext _context;
        private IMapper _mapper;

        public PatientRelationshipService(MediClinicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseDto<bool>> isExistorNot(string Name)
        {
            var isExist = false;
            var Value = await _context.PatientRelationship.Where(x => x.RelationshipName.ToLower() == Name.ToLower()).FirstOrDefaultAsync();
            if (!(Value is null))
            {
                isExist = true;
            }
            var response = new ResponseDto<bool>();
            response.Data = isExist;
            return response;
        }

        public async Task<ResponseDto<List<PatientRelationshipBasicDto>>> patientRelationship()
        {
            var rec = await _context.PatientRelationship.ToListAsync();
            var response = new ResponseDto<List<PatientRelationshipBasicDto>>();
            response.Data = _mapper.Map<List<PatientRelationship>, List<PatientRelationshipBasicDto>>(rec);
            return response;
        }

        public async Task<ResponseDto<bool>> patientRelationshipCreate(PatientRelationshipBasicDto patientRelationshipBasicDto)
        {
            var result = false;
            var mapped = _mapper.Map<PatientRelationshipBasicDto, PatientRelationship>(patientRelationshipBasicDto);
            var data = await _context.PatientRelationship.AddAsync(mapped);
            _context.SaveChanges();
            if (!(data is null))
            {
                result = true;
            }
            var response = new ResponseDto<bool>();
            response.Data = result;
            return response;
        }

        public async Task<ResponseDto<bool>> patientRelationshipDeleteById(int Id)
        {
            var oldEntity = await _context.PatientRelationship.FirstOrDefaultAsync(x => x.RelationshipId == Id);
            _context.Remove(oldEntity);
            _context.SaveChanges();
            var response = new ResponseDto<bool>();
            response.Data = true;
            return response;
        }

        public async Task<ResponseDto<PatientRelationshipBasicDto>> patientRelationshipGetId(int Id)
        {
            var oldEntity = await _context.PatientRelationship.FirstOrDefaultAsync(x => x.RelationshipId == Id);
            var mapped = _mapper.Map<PatientRelationship, PatientRelationshipBasicDto>(oldEntity);
            var response = new ResponseDto<PatientRelationshipBasicDto>();
            response.Data = mapped;
            return response;
        }

        public async Task<ResponseDto<bool>> patientRelationshipUpdate(PatientRelationshipBasicDto patientRelationshipBasicDto)
        {
            var mapped = _mapper.Map<PatientRelationshipBasicDto, PatientRelationship>(patientRelationshipBasicDto);
            var oldEntity = await _context.PatientRelationship.FindAsync(mapped.RelationshipId);
            _context.Entry(oldEntity).CurrentValues.SetValues(mapped);
            await _context.SaveChangesAsync();
            var response = new ResponseDto<bool>();
            response.Data = true;
            return response;
        }

        public async Task<ResponseDto<int>> relationShip(PatientRelationshipBasicDto patientRelationshipBasicDto)
        {
            if (!(patientRelationshipBasicDto.RelationshipName is null))
            {
                patientRelationshipBasicDto.RelationshipName = patientRelationshipBasicDto.RelationshipName.Trim();
            }
            var mapped = _mapper.Map<PatientRelationshipBasicDto, PatientRelationship>(patientRelationshipBasicDto);
            var data = await _context.PatientRelationship.AddAsync(mapped);
            _context.SaveChanges();

            var response = new ResponseDto<int>();
            response.Data = mapped.RelationshipId;
            return response;
        }
    }
}
