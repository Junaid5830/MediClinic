using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.TemplateDto;
using MediClinic.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.PrescriptionTemplateService
{
    public interface IMediTemplateService
    {
        public Task<ResponseDto<TemplateBasicDto>> SaveMedicationTemplate(TemplateBasicDto templateDto);
        public Task<ResponseDto<PrescriptionTemplateDto>> SaveTemplatesPrescriptions(PrescriptionTemplateDto templateDto);

        public Task<List<TemplateBasicDto>> ProviderTemplateList();

        public bool DeleteTemplate(int TempId);
        public Task<List<PrescriptionTemplateDto>> patientTemplateList(long Id);

        public Task<ResponseDto<bool>> isTemplateExistOrNot(string title);
        public Task<List<MedicationTemplateDto>> GetTemplatesMedicinesById(long Id);
        public Task<TemplateBasicDto> GetTemplateById(long Id);

        public Task<PrescriptionTemplateDto> GetTemplatePrescriptionById(long Id);
        public bool DeleteTemplatePrescriptionById(long Id);
        public Task<ResponseDto<bool>> UpdateTemplatePrescription(PrescriptionTemplateDto templateDto);
    }
}
