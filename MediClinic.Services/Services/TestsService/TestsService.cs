using AutoMapper;
using Dapper;
using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.SessionManager;
using MediClinic.Services.Interfaces.TestsInterface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedliClinic.Utilities;


namespace MediClinic.Services.Services.TestsService
{
    public class TestsService : ITestsService

    {
        private MediClinicContext _context;
        private IMapper _mapper;
        private ISessionManager _sessionManager;

        public TestsService(MediClinicContext context, IMapper mapper, ISessionManager sessionManager)
        {
            _context = context;
            _mapper = mapper;
            _sessionManager = sessionManager;

        }

        public async Task<bool> Add(TestsDto testsDto)
        {
            var mapped = _mapper.Map<TestsDto, Tests>(testsDto);
            await _context.Tests.AddAsync(mapped);

            if (testsDto.TestId == 0)
            {
                mapped.CreatedBy = Convert.ToInt32(_sessionManager.GetUserId());
                testsDto.CreatedBy = mapped.CreatedBy;
                mapped.CreatedDate = DateTime.UtcNow;
                testsDto.CreatedDate = mapped.CreatedDate;
                await _context.Tests.AddAsync(mapped);
            }

            else
            {
                mapped.ModifiedBy = Convert.ToInt32(_sessionManager.GetUserId());
                mapped.ModifiedDate = DateTime.UtcNow;
                _context.Tests.Update(mapped);
            }
            _context.SaveChanges();
            return false;
        }


        public bool Delete(int TestId)
        {
            Tests tests = _context.Tests.Where(a => a.TestId == TestId).FirstOrDefault();
            if (tests != null)
            {
                _context.Tests.Remove(tests);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<TestsDto> GetAllTests()
        {
            using (var conn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                try
                {
                    var result = conn.Query<TestsDto>(sql: "[spGetTests]",
             commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
                catch (Exception ex)
                {

                    throw;
                }
             
            }
        }

        //public List<TestsDto> GetTest()
        //{
        //    List<Tests> TestsList = _context.Tests.ToList();
        //    List<TestsDto> TestsDtoList = _mapper.Map<List<Tests>, List<TestsDto>>(TestsList);
        //    return TestsDtoList;
        //}

        public List<TestsDto> GetTest()
        {
            List<Tests> TestsList = _context.Tests.ToList();
            List<TestsDto> TestsDtoList = _mapper.Map<List<Tests>, List<TestsDto>>(TestsList);
            return TestsDtoList;
        }

        public TestsDto GetTestById(int TestId)
        {
            Tests Tests = _context.Tests.Where(a => a.TestId == TestId).FirstOrDefault();
            TestsDto TestsDto = _mapper.Map<Tests, TestsDto>(Tests);
            return TestsDto;
        }

        public async Task<ResponseDto<List<ProceduresDto>>> ProcedureList(long Id)
        {
            var rec = await _context.Procedures.Include(x => x.Provider).Include(p => p.Patient).Where(x=>x.PatientId == Id).ToListAsync();
            var response = new ResponseDto<List<ProceduresDto>>();
            response.Data = _mapper.Map<List<Procedures>, List<ProceduresDto>>(rec);
            return response;
        }

        public List<TestsDto> ProcedureVisitList(int VisitId)
        {
            using (var conn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                try
                {
                    var result = conn.Query<TestsDto>(sql: "[spGetTestForVisit]", param: new { VisitId = VisitId },
                     commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
                catch (Exception ex)
                {

                    throw;
                }
              
            }
        }

        public async Task<ResponseDto<ProceduresDto>> SurgeryProcedureAdd(ProceduresDto procedures)
        {
            var mapped = _mapper.Map<ProceduresDto, Procedures>(procedures);
            var data = await _context.Procedures.AddAsync(mapped);
            await _context.SaveChangesAsync();
          
            var entity = _mapper.Map<Procedures, ProceduresDto>(mapped);
            var response = new ResponseDto<ProceduresDto>();
        
            response.Data = entity;
            return response;
        }

        public async Task<List<TestsDto>> TestListByVisit(long Id)
        {
            var joinData = await(from P in _context.PatientAppointments.Where(x => x.PatientInfoId == Id)
                                 join V in _context.Visits
                                 on P.AppointmentId equals V.AppoinmentId



                                 join T in _context.Tests
                                 on V.VisitId equals T.VisitId

                                 join L in _context.Lookups
                                on T.VisitProcedureCategory equals L.LookupId
                                 
                                 join CPT in _context.CPTCodes
                                on T.CPTCodeId equals CPT.CPTCodeId

                                 join ICD in _context.ICDCodes
                                on T.ICDCodeId equals ICD.ICDCodeId

                                join PI in _context.ProviderInfo
                                on T.ProviderInfoId equals PI.ProviderInfoId

                                 select new TestsDto
                                 {
                                    VPCategory = L.LookupValue,
                                    TestId = T.TestId,
                                     DateTime = T.DateTime,
                                     DescriptionICD = ICD.Description,
                                     DescriptionCPT = CPT.Description,
                                     VisitId = T.VisitId,
                                     DoctorName = PI.FirstName + ' ' + PI.LastName
                                 }).ToListAsync();

            return joinData;
        }

        //public async Task<List<DoctorsInfoDto>> GetAllDoctorsNames()
        //{
        //    using (var conn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
        //    {
        //        var result = await conn.QueryAsync<DoctorsInfoDto>(sql: "[GetAllDoctorsNames]",
        //        commandType: CommandType.StoredProcedure);

        //        var response = result.ToList();
        //        if (response.Any())
        //        {
        //            return result.ToList();
        //        }
        //        else
        //        {
        //            return new List<DoctorsInfoDto>();
        //        }

        //    }
        //}

        //public Task<ResponseDto<List<TestsDto>>> TestsDtolist(string lookupType)
        //{
        //    throw new NotImplementedException();
        //}
    }
}