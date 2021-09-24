using AutoMapper;
using Dapper;
using MediClinic.Models.DTOs.VitalBasicDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.PatientVitalInterface;
using MedliClinic.Utilities.Utility.Enum;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.PatientVitalService
{
    public class PatientVitalService : IPatientVitalService
    {
        private MediClinicContext _context;
        private IMapper _mapper;
        public PatientVitalService(MediClinicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool SavePatientVital(VitalDto vitalDto)
        {
            try
            {
                if (vitalDto.PatientVitalId > 0)
                {
                    var oldEntity = _context.PatientVitals.FirstOrDefault(x => x.PatientVitalId == vitalDto.PatientVitalId);
                    if (!(oldEntity is null))
                    {
                        var mappedData = _mapper.Map<PatientVitals>(vitalDto);
                        _context.Entry(oldEntity).CurrentValues.SetValues(mappedData);
                        _context.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    var mappedData = _mapper.Map<PatientVitals>(vitalDto);
                    _context.PatientVitals.Add(mappedData);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }

        public VitalDto GetVitalById(int patientVitalId)
        {
            var record = _context.PatientVitals.FirstOrDefault(x => x.PatientVitalId == patientVitalId);
            if (!(record is  null))
            {
                return _mapper.Map<VitalDto>(record);
            }
            else
            {
                return new VitalDto();
            }
        }

        public bool RemoveVitalById(int patientVitalId)
        {
            var record = _context.PatientVitals.FirstOrDefault(x => x.PatientVitalId == patientVitalId);
            if (record != null)
            {
                _context.Remove(record);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
 
        }

        public List<VitalDto> GetAllVitalByPatientInfoId(long patientInfoId)
        {
            var record = _context.PatientVitals.Include(x => x.Examiner).Include(x=>x.ReasonForExam).Where(x => x.PatientInfoId == patientInfoId).OrderByDescending(x=>x.PatientVitalId).ToList();
            if (!(record is null))
            {
                return _mapper.Map<List<VitalDto>>(record);
            }
            else
            {
                return new List<VitalDto>();
            }
        }

        //public List<VitalDto> GetVitalSummaryByPatientInfoId(long patientInfoId)
        //{
        //    var record = _context.PatientVitals.Include(x => x.ReasonForExam).Where(x => x.PatientInfoId == patientInfoId).ToList();
        //    if (!(record is null))
        //    {
        //        return _mapper.Map<List<VitalDto>>(record);
        //    }
        //    else
        //    {
        //        return new List<VitalDto>();
        //    }
        //}


        public VitalDto GetVitalSummaryByPatientInfoId(long patientinfoId)
        {
            using (var conn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                var result = conn.Query<VitalDto>(sql: "[getPatientVitalsByPatientId]", param: new { patientId = patientinfoId },
                commandType: CommandType.StoredProcedure);
                var data = result.FirstOrDefault();

                if (!(data is null))
                {

                    if (data.ExamTime.Date == DateTime.Today)
                    {
                        data.IsEditableOrNot = true;
                    }
                    else
                    {
                        data.IsEditableOrNot = false;
                    }
                    return data;
                }
                else
                {
                    return new VitalDto() {
                      Temprature = SharedData.dashes,
                      BloodPressure = SharedData.dashes,
                      Pulse = SharedData.dashes,
                      Respiration = SharedData.dashes,
                      Height = SharedData.dashes,
                      Weight = SharedData.dashes,
                      TempMethod = SharedData.dashes,
                      BMIStatus = SharedData.dashes,
                      BMI = SharedData.dashes,
                      OxygenSaturation = SharedData.dashes,
                      Allergies = SharedData.dashes,
                };
                }
            }
        }

        public List<VitalDto> GetAllVital()
        {
            var record = _context.PatientVitals.Include(x => x.Examiner).Include(x => x.ReasonForExam).OrderByDescending(x => x.PatientVitalId).ToList();
            if (!(record is null))
            {
                return _mapper.Map<List<VitalDto>>(record);
            }
            else
            {
                return new List<VitalDto>();
            }
        }

        public List<VitalDto> GetAllVitalListForVIsits(int VisitId)
        {
            var record = _context.PatientVitals.Include(x => x.Examiner).Include(x => x.ReasonForExam).Where(x => x.VisitId == VisitId).OrderByDescending(x => x.PatientVitalId).ToList();
            if (!(record is null))
            {
                return _mapper.Map<List<VitalDto>>(record);
            }
            else
            {
                return new List<VitalDto>();
            }
        }

        public async Task<List<VitalDto>> GetVitalListByVisits(long Id)
        {
            var joinData = await(from P in _context.PatientAppointments.Where(x => x.PatientInfoId == Id)
                                 join V in _context.Visits
                                 on P.AppointmentId equals V.AppoinmentId



                                 join PV in _context.PatientVitals
                                 on V.VisitId equals PV.VisitId

                                 join ER in _context.ExamReason
                                 on PV.ReasonForExamId equals ER.ExamReasonId

                                 join PI in _context.ProviderInfo
                                 on PV.ExaminerId equals PI.ProviderInfoId

                                 select new VitalDto
                                 {
                                     PatientVitalId = PV.PatientVitalId,
                                     Temprature = PV.Temprature,
                                     BloodPressure = PV.BloodPressure,
                                     Pulse = PV.Pulse,
                                     Respiration = PV.Respiration,
                                     Height = PV.Height,
                                     Weight = PV.Weight,
                                     TempMethod = PV.TempMethod,
                                     BMIStatus = PV.TempMethod,
                                     BMI = PV.BMI,
                                     OxygenSaturation = PV.OxygenSaturation,
                                     VisitId = PV.VisitId,
                                     ExamTime = (DateTime)PV.ExamTime,
                                     Examiner = new ProviderInfo() {FirstName = PI.FirstName,LastName = PI.LastName},
                                     ReasonForExam = new ExamReason() { ReasonName = ER.ReasonName}
                                 }).ToListAsync();

            return joinData;
        }
    }
}
