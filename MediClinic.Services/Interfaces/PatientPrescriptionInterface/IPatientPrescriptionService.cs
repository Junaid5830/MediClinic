using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.DMESuppliesDto;
using MediClinic.Models.DTOs.PrescriptionDto;
using MediClinic.Models.EntityModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.PatientPrescriptionInterface
{
    public interface IPatientPrescriptionService
    {
        public Medicines GetMedicineById(long? id);
        public Task<ResponseDto<bool>> prescriptionCreate(PrescriptionBasicDto prescriptionBasicDto);
        public Task<ResponseDto<bool>> prescriptionUpdate(PrescriptionBasicDto patientInfoBasicDto);
        public Task<ResponseDto<PrescriptionBasicDto>> prescriptionGetId(int Id);
        public Task<ResponseDto<bool>> isPrescriptionExistorNot(long Id, long patientd);
        public bool prescriptionDeleteById(int Id);
        public SelectList GetMedicine();
        public Task<ResponseDto<List<PrescriptionBasicDto>>> prescriptionList(long Id);
        public Task<List<PrescriptionBasicDto>> prescriptionListByVisits(long Id);
        public Task<ResponseDto<List<PrescriptionBasicDto>>> AllprescriptionList();
        public Task<ResponseDto<bool>> isUpdatePrescriptionExistorNot(long Id, long MedicineId, long patientd);
        public Task<DMESupplieDto> GetDMESupplyById(int? presId);
        public Task<DMESupEquipItemsDto> GetItemGroupById(int? id);
        public Task<ResponseDto<List<PrescriptionBasicDto>>> prescriptionListForVisitsDetail(int Id);

    }
}
