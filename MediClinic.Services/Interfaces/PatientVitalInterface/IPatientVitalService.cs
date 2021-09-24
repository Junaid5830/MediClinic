using MediClinic.Models.DTOs.VitalBasicDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.PatientVitalInterface
{
    public interface IPatientVitalService
    {
        public bool SavePatientVital(VitalDto vitalDto);
        public VitalDto GetVitalById(int patientVitalId);
        public List<VitalDto> GetAllVitalByPatientInfoId(long patientInfoId);
        public List<VitalDto> GetAllVital();
        public List<VitalDto> GetAllVitalListForVIsits(int VisitId);

        public Task<List<VitalDto>> GetVitalListByVisits(long Id);
        public bool RemoveVitalById(int patientVitalId);
        //public List<VitalDto> GetVitalSummaryByPatientInfoId(long patientInfoId);
        public VitalDto GetVitalSummaryByPatientInfoId(long patientinfoId);
    }
}
