using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.TestsInterface
{
    public interface ITestsService
    {
        public Task<bool> Add(TestsDto testsDto);

        public bool Delete(int TestId);
        public TestsDto GetTestById(int TestId);
        //public List<TestsDto> GetTest();
        public List<TestsDto> GetAllTests();
        public Task<List<TestsDto>> TestListByVisit(long Id);

        public List<TestsDto> GetTest();

        public Task<ResponseDto<List<ProceduresDto>>> ProcedureList(long Id);

        public List<TestsDto> ProcedureVisitList(int VisitId);

        public Task<ResponseDto<ProceduresDto>> SurgeryProcedureAdd(ProceduresDto procedures);
    }
}