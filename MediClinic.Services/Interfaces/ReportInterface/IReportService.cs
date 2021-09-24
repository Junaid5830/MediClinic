using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.CommonDto;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.ReportInterface
{
    public interface IReportService
    {
        public Task<ResponseDto<bool>> CreatePatientinformaton(ReportPatientDto reportPatientDto);
        public Task<ResponseDto<bool>> CreateEmployeeinformaton(ReportEmployeeDto reportEmployeeDto);
        public Task<ResponseDto<bool>> CreateDoctorinformaton(ReportDoctorInfoDto reportDoctorInfoDto);
        public Task<ResponseDto<bool>> CreateHistory(ReportHistoryDto reportHistory);
        public Task<ResponseDto<bool>> CreateExamInformation(ReportExamInfromationDto reportExamInformation);
        public Task<ResponseDto<ReportExamInfromationDto>> GetExamInformationById(int Id);
        public Task<ResponseDto<bool>> CreateDoctorOpinion(ReportDoctorOpinionDto reportDoctorOpinion);
        public Task<ResponseDto<bool>> CreatePlanOfCare(ReportPlanCareDto reportPlaneOfCare);
        public Task<ResponseDto<bool>> CreateWorkStatus(ReportWorkStatusDto reportWorkStatus);
        public IEnumerable<SelectListItem> GetListIncomeCategory();



        public Task<ResponseDto<ReportBillingInfoDto>> CreateBillingInformation(ReportBillingInfoDto reportBilling);

        public Task<ResponseDto<bool>> CreateBillingCode(ReportBillingCodeDto reportBillingCodeDto);
        public Task<ResponseDto<ReportBillingInvoiceDto>> CreateBillingInvoice(List<ReportBillingInvoiceDto> reportBillingInvoiceDtos);

        public Task<ResponseDto<NF2AobDto>> Createnf2Aob(NF2AobDto nF2AobDto);
        public Task<ResponseDto<IncomeExpenceCategoryDto>> CreateCategory(IncomeExpenceCategoryDto category);
        public Task<ResponseDto<IncomeExpenceCategoryDto>> GetCategoryPriceById(int Id);

        public Task<List<CheckInOutDto>> checkInoutList(DateTime date);

        public Task<ResponseDto<bool>> checkInCreate(int CheckId,long Id);
        public Task<ResponseDto<bool>> checkOutCreate(int CheckId, long Id);

        public Task<ResponseDto<ReportIncomeDto>> CreateIncome(List<ReportIncomeDto> reportIncome);
        public Task<List<ReportIncomeDto>> GetIncomeListForPatient(long? Id);
        public Task<ResponseDto<ReportExpenceDto>> CreateExpence(List<ReportExpenceDto> reportIncome);
        public Task<ResponseDto<bool>> CheckInOutDelete(long Id);
        public Task<List<ReportExamInfromationDto>> GetReportInfoList(long Id);
        public Task<bool> DeleteExamInformation(int Id);
    }
}
