using MediClinic.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.LabInterface
{
    public interface ILabService
    {
        public bool Add(LabDto labDto);
        public  Task<List<LabDto>> GetLabList();
        public  Task<List<LabDto>> GetLabVisitList(int Id);
        public  Task<List<LabDto>> GetLabListByVisitId(int Id);
        public  Task<List<LabDto>> GetLabListByVisits(long Id);
        public bool Delete(int Labid);
        public LabDto GetLabById(int labId);
    }
}
