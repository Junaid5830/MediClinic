using AutoMapper;
using Dapper;
using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.ReportInterface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.ReportService
{
    public class ReportService : IReportService
    {
        private MediClinicContext _context;
        private IMapper _mapper;

        public ReportService(MediClinicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseDto<bool>> checkInCreate(int CheckId, long Id)
        {
            var result = false;
            CheckInOut check = new CheckInOut();
            var timeSpan = DateTime.Now.TimeOfDay;
            DateTime today = DateTime.Today;
            check.UserId = Id;
            check.CheckInTime = timeSpan;
            check.Date = today;
            var rec = await _context.CheckInOut.AddAsync(check);

            if (!(rec is null))
            {
                result = true;
                await _context.SaveChangesAsync();
            }
            var response = new ResponseDto<bool>();
            response.Data = result;
            return response;
        }

        public async Task<ResponseDto<bool>> CheckInOutDelete(long Id)
        {
            var result = false;
            DateTime todayList = DateTime.Today;
            var Record = await _context.CheckInOut.FirstOrDefaultAsync(x => x.UserId == Id && x.Date == todayList);
            _context.Remove(Record);
            _context.SaveChanges();
            var response = new ResponseDto<bool>();
            response.Data = true;
            return response;
        }

        public async Task<List<CheckInOutDto>> checkInoutList(DateTime date)
        {
            try
            {
                using (var conn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
                {
                    var result = await conn.QueryAsync<CheckInOutDto>(sql: "[spGetCheckInOutList]", param: new { date = date },
                    commandType: CommandType.StoredProcedure);

                    return result.ToList();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ResponseDto<bool>> checkOutCreate(int CheckId, long Id)
        {
            var result = false;
            DateTime todayList = DateTime.Today;
            var Record = await _context.CheckInOut.FirstOrDefaultAsync(x => x.UserId == Id && x.Date == todayList);
            CheckInOut check = new CheckInOut();
            var timeSpan = DateTime.Now.TimeOfDay;
            DateTime today = DateTime.Today;
            check.UserId = Record.UserId;
            check.CheckInTime = Record.CheckInTime;
            check.CheckOutTime = timeSpan;
            check.CheckInOutId = Record.CheckInOutId;
            check.Date = today;
            _context.Entry(Record).CurrentValues.SetValues(check);

            await _context.SaveChangesAsync();

            if (!(Record is null))
            {
                result = true;
            }
            var response = new ResponseDto<bool>();
            response.Data = result;
            return response;
        }

        public async Task<ResponseDto<bool>> CreateBillingCode(ReportBillingCodeDto reportBillingCodeDto)
        {
            try
            {
                var result = false;
                var mapped = _mapper.Map<ReportBillingCodeDto, ReportBillingCode>(reportBillingCodeDto);
                var data = await _context.ReportBillingCode.AddAsync(mapped);
                if (!(data is null))
                {
                    result = true;
                }
                await _context.SaveChangesAsync();

                var response = new ResponseDto<bool>();
                response.Data = result;
                return response;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<ResponseDto<ReportBillingInfoDto>> CreateBillingInformation(ReportBillingInfoDto reportBilling)
        {
            try
            {
               
                var mapped = _mapper.Map<ReportBillingInfoDto, ReportBillingInformation>(reportBilling);
                var data = await _context.ReportBillingInformation.AddAsync(mapped);
             
                var rec = await _context.SaveChangesAsync();
                var Entity = _mapper.Map<ReportBillingInformation, ReportBillingInfoDto>(mapped);
                var response = new ResponseDto<ReportBillingInfoDto>();
                response.Data = Entity;
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<ResponseDto<IncomeExpenceCategoryDto>> CreateCategory(IncomeExpenceCategoryDto category)
        {
            try
            {
               
                var mapped = _mapper.Map<IncomeExpenceCategoryDto, IncomeExpenceCategory>(category);
                var data = await _context.IncomeExpenceCategory.AddAsync(mapped);
                var rec = await _context.SaveChangesAsync();
                var Entity = _mapper.Map<IncomeExpenceCategory, IncomeExpenceCategoryDto>(mapped);
                var response = new ResponseDto<IncomeExpenceCategoryDto>();
                response.Data = Entity;
                return response;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<ResponseDto<ReportBillingInvoiceDto>> CreateBillingInvoice(List<ReportBillingInvoiceDto> reportBillingInvoiceDtos)
        {
            var mapped = _mapper.Map<List<ReportBillingInvoiceDto>, List<ReportBillingInvoice>>(reportBillingInvoiceDtos);
            await _context.ReportBillingInvoice.AddRangeAsync(mapped);
            _context.SaveChanges();
            var response = new ResponseDto<ReportBillingInvoiceDto>();
            return response;
        }

        public async Task<ResponseDto<bool>> CreateDoctorinformaton(ReportDoctorInfoDto reportDoctorInfoDto)
        {
            try
            {
                var result = false;
                var mapped = _mapper.Map<ReportDoctorInfoDto, ReportDoctorInformation>(reportDoctorInfoDto);
                var data = await _context.ReportDoctorInformation.AddAsync(mapped);
                if (!(data is null))
                {
                    result = true;
                }
                await _context.SaveChangesAsync();

                var response = new ResponseDto<bool>();
                response.Data = result;
                return response;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<ResponseDto<bool>> CreateDoctorOpinion(ReportDoctorOpinionDto reportDoctorOpinion)
        {
            try
            {
                var result = false;
                var mapped = _mapper.Map<ReportDoctorOpinionDto, ReportDoctorOpinion>(reportDoctorOpinion);
                var data = await _context.ReportDoctorOpinion.AddAsync(mapped);
                if (!(data is null))
                {
                    result = true;
                }
                await _context.SaveChangesAsync();

                var response = new ResponseDto<bool>();
                response.Data = result;
                return response;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<ResponseDto<bool>> CreateEmployeeinformaton(ReportEmployeeDto reportEmployeeDto)
        {
            try
            {
                var result = false;
                var mapped = _mapper.Map<ReportEmployeeDto, ReportEmployeeInfo>(reportEmployeeDto);
                var data = await _context.ReportEmployeeInfo.AddAsync(mapped);
                if (!(data is null))
                {
                    result = true;
                }
                await _context.SaveChangesAsync();

                var response = new ResponseDto<bool>();
                response.Data = result;
                return response;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<ResponseDto<bool>> CreateExamInformation(ReportExamInfromationDto reportExamInformation)
        {
            try
            {
                var result = false;
                var mapped = _mapper.Map<ReportExamInfromationDto, ReportExamInformation>(reportExamInformation);
                if (reportExamInformation.ExamInformationId > 0)
                {
                    var oldEntity = await _context.ReportExamInformation.FindAsync(reportExamInformation.ExamInformationId);
                    _context.Entry(oldEntity).CurrentValues.SetValues(mapped);
                }
                else
                {
                    var data = await _context.ReportExamInformation.AddAsync(mapped);
                    if (!(data is null))
                    {
                        result = true;
                    }
                }
                await _context.SaveChangesAsync();

                var response = new ResponseDto<bool>();
                response.Data = result;
                return response;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<ResponseDto<ReportExpenceDto>> CreateExpence(List<ReportExpenceDto> reportExpence)
        {
            var mapped = _mapper.Map<List<ReportExpenceDto>, List<ReportExpence>>(reportExpence);
            await _context.ReportExpence.AddRangeAsync(mapped);
            _context.SaveChanges();
            var response = new ResponseDto<ReportExpenceDto>();
            return response;

        }

        public async Task<ResponseDto<bool>> CreateHistory(ReportHistoryDto reportHistory)
        {
            try
            {
                var result = false;
                var mapped = _mapper.Map<ReportHistoryDto, ReportHistory>(reportHistory);
                var data = await _context.ReportHistory.AddAsync(mapped);
                if (!(data is null))
                {
                    result = true;
                }
                await _context.SaveChangesAsync();

                var response = new ResponseDto<bool>();
                response.Data = result;
                return response;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<ResponseDto<ReportIncomeDto>> CreateIncome(List<ReportIncomeDto> reportIncome)
        {
            var mapped = _mapper.Map<List<ReportIncomeDto>, List<ReportIncome>>(reportIncome);
            await _context.ReportIncome.AddRangeAsync(mapped);
            _context.SaveChanges();
            var response = new ResponseDto<ReportIncomeDto>();
            return response;


        }



        public async Task<ResponseDto<NF2AobDto>> Createnf2Aob(NF2AobDto nF2AobDto)
        {
            try
            {
                
                var mapped = _mapper.Map<NF2AobDto, NF2AOBClaim>(nF2AobDto);
                var data = await _context.NF2AOBClaim.AddAsync(mapped);
               
                var rec = await _context.SaveChangesAsync();
                var Entity = _mapper.Map<NF2AOBClaim, NF2AobDto>(mapped);
                var response = new ResponseDto<NF2AobDto>();
                response.Data = Entity;
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ResponseDto<bool>> CreatePatientinformaton(ReportPatientDto reportPatientDto)
        {
            try
            {
                var result = false;
                var mapped = _mapper.Map<ReportPatientDto, ReportPatientInformation>(reportPatientDto);
                var data = await _context.ReportPatientInformation.AddAsync(mapped);
                if (!(data is null))
                {
                    result = true;
                }
                await _context.SaveChangesAsync();

                var response = new ResponseDto<bool>();
                response.Data = result;
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<ResponseDto<bool>> CreatePlanOfCare(ReportPlanCareDto reportPlaneOfCare)
        {
            try
            {
                var result = false;
                var mapped = _mapper.Map<ReportPlanCareDto, ReportPlanCare>(reportPlaneOfCare);
                var data = await _context.ReportPlanCare.AddAsync(mapped);
                if (!(data is null))
                {
                    result = true;
                }
                await _context.SaveChangesAsync();

                var response = new ResponseDto<bool>();
                response.Data = result;
                return response;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<ResponseDto<bool>> CreateWorkStatus(ReportWorkStatusDto reportWorkStatus)
        {
            try
            {
                var result = false;
                var mapped = _mapper.Map<ReportWorkStatusDto, ReportWorkStatus>(reportWorkStatus);
                var data = await _context.ReportWorkStatus.AddAsync(mapped);
                if (!(data is null))
                {
                    result = true;
                }
                await _context.SaveChangesAsync();

                var response = new ResponseDto<bool>();
                response.Data = result;
                return response;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<ResponseDto<IncomeExpenceCategoryDto>> GetCategoryPriceById(int Id)
        {
            var Price = await _context.IncomeExpenceCategory.Where(x => x.CategoryId == Id).FirstOrDefaultAsync();
            var Entity = _mapper.Map<IncomeExpenceCategory, IncomeExpenceCategoryDto>(Price);
            var response = new ResponseDto<IncomeExpenceCategoryDto>();
            response.Data = Entity;
            return response;


        }

        public IEnumerable<SelectListItem> GetListIncomeCategory()
        {
            return _context.IncomeExpenceCategory.Select(a =>
                                  new SelectListItem
                                  {
                                      Value = a.CategoryId.ToString(),
                                      Text = a.CategoryName
                                  }).ToList();
        }

        public async Task<List<ReportIncomeDto>> GetIncomeListForPatient(long? Id)
        {
            var rec = await _context.ReportIncome.Include(x => x.Category).Where(x => x.PatientId == Id).ToListAsync();
            var mapped = _mapper.Map<List<ReportIncome>, List<ReportIncomeDto>>(rec);
            return mapped;

        }



        public async Task<List<ReportExamInfromationDto>> GetReportInfoList(long Id)
        {
            var joinData = await (from P in _context.PatientAppointments.Where(x => x.PatientInfoId == Id)
                                  join V in _context.Visits
                                  on P.AppointmentId equals V.AppoinmentId

                                  join R in _context.ReportExamInformation
                                  on V.VisitId equals R.VisitId


                                  select new ReportExamInfromationDto
                                  {
                                      ExamInformationId=R.ExamInformationId,
                                      DateOfExam = R.DateOfExam,
                                      Swelling = R.Swelling == null ? "N/A" : R.Swelling,
                                      Burns = R.Burns == null ? "N/A" : R.Burns,
                                      Pain = R.Pain == null ? "N/A" : R.Pain,
                                      Weakness = R.Weakness == null ? "N/A" : R.Weakness,
                                      VisitId=R.VisitId
                                  }).ToListAsync();

            return joinData;
        }

        public async Task<bool> DeleteExamInformation(int Id)
        {
            var result = false;
            var entity = await _context.ReportExamInformation.Where(x => x.ExamInformationId == Id).FirstOrDefaultAsync();
            _context.ReportExamInformation.Remove(entity);
           await _context.SaveChangesAsync();
            result = true;
            return result;
        }

        public async Task<ResponseDto<ReportExamInfromationDto>> GetExamInformationById(int Id)
        {
            try
            {
                var data = await _context.ReportExamInformation.Where(x => x.ExamInformationId == Id).FirstOrDefaultAsync();
                var mapper = _mapper.Map<ReportExamInformation, ReportExamInfromationDto>(data);
                var response = new ResponseDto<ReportExamInfromationDto>();
                response.Data = mapper;
                return response;
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }
    }


}

