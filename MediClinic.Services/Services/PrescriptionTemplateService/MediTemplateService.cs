using AutoMapper;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.TemplateDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.PrescriptionTemplateService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.PrescriptionTemplateService
{
    public class MediTemplateService : IMediTemplateService
    {
        private MediClinicContext _context;
        private IMapper _mapper;

        public MediTemplateService(MediClinicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool DeleteTemplate(int TempId)
        {
            var oldEntity = _context.PrescriptionTemplates.FirstOrDefault(x => x.TemplateId == TempId);
            if (oldEntity != null)
            {
                oldEntity.IsActive = false;
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool DeleteTemplatePrescriptionById(long Id)
        {
            var oldEntity = _context.PatientMedicationsTemplate.FirstOrDefault(x => x.Id == Id);
            if (oldEntity != null)
            {
                _context.Remove(oldEntity);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        public async Task<List<PrescriptionTemplateDto>> patientTemplateList(long Id)
        {
            var rec = await _context.PatientMedicationsTemplate.Where(p => p.TemplateId == Id).ToListAsync();
            var response = new List<PrescriptionTemplateDto>();
            response = _mapper.Map<List<PatientMedicationsTemplate>, List<PrescriptionTemplateDto>>(rec);
            return response;
        }

        public async Task<List<TemplateBasicDto>> ProviderTemplateList()
        {
            var joinData = await (from PMT in _context.PrescriptionTemplates
                                  join M in _context.ProviderInfo
                                  on PMT.ProviderInfoId equals M.ProviderInfoId

                                  select new TemplateBasicDto
                                  {
                                      TemplateId = PMT.TemplateId,
                                      Name = PMT.Name,
                                      ProviderInfoId = PMT.ProviderInfoId,
                                      ProviderName = M.FirstName + " " + M.LastName,
                                  }).ToListAsync();
            return joinData;

        }

        public async Task<TemplateBasicDto> GetTemplateById(long Id)
        {
            var rec = await _context.PrescriptionTemplates.Where(p => p.TemplateId == Id).FirstOrDefaultAsync();
            var response = new TemplateBasicDto();
            response = _mapper.Map<PrescriptionTemplates, TemplateBasicDto>(rec);
            return response;
        }

        public async Task<PrescriptionTemplateDto> GetTemplatePrescriptionById(long Id)
        {
            var rec = await _context.PatientMedicationsTemplate.Where(p => p.Id == Id).FirstOrDefaultAsync();
            var response = new PrescriptionTemplateDto();
            response = _mapper.Map<PatientMedicationsTemplate, PrescriptionTemplateDto>(rec);
            return response;
        }



        public async Task<ResponseDto<TemplateBasicDto>> SaveMedicationTemplate(TemplateBasicDto templateDto)
        {
            try
            {
                var mapped = _mapper.Map<TemplateBasicDto, PrescriptionTemplates>(templateDto);
                mapped.CreatedDate = DateTime.UtcNow;
                mapped.IsActive = true;
                var data = await _context.PrescriptionTemplates.AddAsync(mapped);
                _context.SaveChanges();
                var entity = _mapper.Map<PrescriptionTemplates, TemplateBasicDto>(mapped);
                var response = new ResponseDto<TemplateBasicDto>();
                response.Data = entity;
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ResponseDto<PrescriptionTemplateDto>> SaveTemplatesPrescriptions(PrescriptionTemplateDto templateDto)
        {
            try
            {
                var mapped = _mapper.Map<PrescriptionTemplateDto, PatientMedicationsTemplate>(templateDto);
                var data = await _context.PatientMedicationsTemplate.AddAsync(mapped);
                _context.SaveChanges();
                var entity = _mapper.Map<PatientMedicationsTemplate, PrescriptionTemplateDto>(mapped);
                var response = new ResponseDto<PrescriptionTemplateDto>();
                response.Data = entity;
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ResponseDto<bool>> UpdateTemplatePrescription(PrescriptionTemplateDto templateDto)
        {
            try
            {
                var mapped = _mapper.Map<PrescriptionTemplateDto, PatientMedicationsTemplate>(templateDto);

                var oldEntity = await _context.PatientMedicationsTemplate.FindAsync(mapped.Id);

                _context.Entry(oldEntity).CurrentValues.SetValues(mapped);
                await _context.SaveChangesAsync();

                var response = new ResponseDto<bool>();
                response.Data = true;
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public async Task<ResponseDto<bool>> isTemplateExistOrNot(string title)
        {
            var isExist = false;
            var value = await _context.PrescriptionTemplates.Where(x => x.Name == title).FirstOrDefaultAsync();
            if (!(value is null))
            {
                isExist = true;
            }
            var response = new ResponseDto<bool>();
            response.Data = isExist;
            return response;
        }

        public async Task<List<MedicationTemplateDto>> GetTemplatesMedicinesById(long Id)
        {
            var joinData = await (from PMT in _context.PatientMedicationsTemplate.Where(x => x.TemplateId == Id)
                                  join M in _context.Medicines
                                  on PMT.MedicineId equals M.Id

                                  select new MedicationTemplateDto
                                  {
                                      Id = PMT.Id,
                                      MedicineId = PMT.MedicineId,                         
                                      Name = M.Name,
                                      Quantity = PMT.Quantity,
                                      FrequencyId = PMT.FrequencyId,
                                      Dose = PMT.Dose,
                                      Unit = PMT.Unit,
                                      StartDate = PMT.StartDate,
                                      EndDate = PMT.EndDate,
                                      Notes = PMT.Notes
                                  }).ToListAsync();
            return joinData;
        }
    }
}
