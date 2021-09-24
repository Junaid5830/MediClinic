using MediClinic.Models.DTOs.DMESuppliesDto;
using MediClinic.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MediClinic.Services.Interfaces
{
    public interface IDMESuppliesService
    {
        public Task<bool> SaveICDCode(string ICDName);
        public bool SaveCPTCodes(CommonFieldsDMECodesDto dMECodesDto);
        public bool SaveDMESupplyEquipment(DMESupplieDto dMESupplieDto);
        public bool UpdateDMESupplyEquipment(DMESupplieDto dMESupplieDto);
        public bool DeleteDMESupplyEquipment(int dMESupplyId);
        public Task<List<DMESupplyEquipment>> GetDMESupplyListByPatientId(long patientId);
        public Task<List<DMESupplyEquipment>> GetDMESupplyVIsitList(int Id);
        public Task<List<DMESupplyEquipment>> GetAllDMESupplyList();
        public Task<List<ICDDto>> GetAllICDCodes(bool withDetail);
        public Task<List<CPTCodeDto>> GetAllCPTCodes();
        public Task<List<DMESupEquipItemsDto>> GetAllItemsGroup();
        public Task<DMESupplieDto> GetDMESupplyById(int? dMEId);
        public Task<DMEReferalTemplateDto> GetReferalTemplateData(long PatientId, long ProviderId, int? DMEId);
        public Task<DMEReferalTemplateDto> GetReferalTemplateBatchData(long PatientId, long ProviderId, string[] DMEIds);
        public Task<DMEDeliveryTemplateDto> GetDMEDeliveryTemplateData(long PatientId, long ProviderId);
        public Task<DMEAOBDeliveryTemplateDto> GetDMEAOBTemplateData(long PatientId, long ProviderId, int? DMEId);
        public Task<DMEAOBDeliveryTemplateDto> GetDMEAOBBatchData(long PatientId, long ProviderId, string[] DMEIds);
        public Task<DMERxOrderTemplateDto> GetRXOrderTemplateData(long patientId,int? DMEId);
        public Task<DMERxOrderTemplateDto> GetRXOrderBatchData(long patientId, string[] DMEIds);

        public Task<DMESupplyReturnTemplateDto> GetSupplyReturnTemplateData(long patientId, int? DMEId);
        public Task<DMESupplyReturnTemplateDto> GetSupplyReturnBatchData(long patientId, string[] DMEIds);
        public string SaveImage(string img);
    }
}
