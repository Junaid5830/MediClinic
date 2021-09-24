using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.CommonDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.PatientsDmePrescription
{
    public interface IPatientsDmePrescriptions
    {
        public Task<ResponseDto<DmePatientsPrescriptionDto>> GetById(int Id);
        public Task<ResponseDto<DmePatientsPrescriptionDto>> AddUpdateDmePrescription(DmePatientsPrescriptionDto dmePatientsPrescriptionDto);
        public Task<ResponseDto<List<DmePatientsPrescriptionDto>>> AddListDmePrescription(List<DmePatientsPrescriptionDto> saveList);
        public Task<ResponseDto<bool>> DeleteDmePrescription(int Id);
        public Task<ResponseDto<List<DmePatientsPrescriptionDto>>> GetLsitByPatientId(long PatientId);
        public Task<ResponseDto<List<DmePatientsPrescriptionDto>>> GetGeneralList();
        public Task<ResponseDto<bool>> StatusChange(int itemId,int statusId);
        public Task<ResponseDto<List<SupplierAssignedDmeDto>>> SuuplierAssignedDme(long supplierId);
        public Task<ResponseDto<DmeRentalFormDto>> DmeRentalFormCreate(DmeRentalFormDto dmeRentalForm);
        public Task<ResponseDto<DmeRentalFormDto>> DmeRentalFormGetById(int Id);




    }
}
