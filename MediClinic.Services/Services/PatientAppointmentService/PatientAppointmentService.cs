using AutoMapper;
using Dapper;
using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.PatientAppointmentsDto;
using MediClinic.Models.DTOs.ProviderInfoDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.PatientAppointmentInterface;
using MediClinic.Services.Interfaces.SessionManager;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio.Http;
using Twilio.Rest.Trunking.V1;

namespace MediClinic.Services.Services.PatientAppointmentService
{
    public class PatientAppointmentService : IPatientAppointmentService
    {
        private MediClinicContext _context;
        private IMapper _mapper;
        private ISessionManager _sessionManager;

        public PatientAppointmentService(MediClinicContext context, IMapper mapper, ISessionManager sessionManager)
        {
            _context = context;
            _mapper = mapper;
            _sessionManager = sessionManager;
        }

        public async Task<List<PatientAppointmentBasicDto>> AppointmentCentralByDoctor(ICollection<long?> Id)
        {
            //var joinData;
            //List<PatientAppointmentBasicDto> joinData = new List<PatientAppointmentBasicDto>();
            var Data = await (from PA in _context.PatientAppointments.Where(x => Id.Contains(x.ProviderInfoId))
                              join M in _context.PatientInfo
                              on PA.PatientInfoId equals M.PatientInfoId

                              join P in _context.ProviderInfo
                              on PA.ProviderInfoId equals P.ProviderInfoId


                              select new PatientAppointmentBasicDto
                              {
                                  PatientFullName = M.FirstName + ' ' + M.LastName,
                                  DocFullName = P.FirstName + ' ' + P.LastName,
                                  AppointmentId = PA.AppointmentId,
                                  PatientInfoId = PA.PatientInfoId,
                                  AppointmentType = PA.AppointmentType,
                                  ExactTime = PA.ExactTime,
                                  Date = PA.Date,
                                  EndDate = PA.EndDate,
                                  StartTime = PA.StartTime,
                                  EndTime = PA.EndTime,
                                  ProviderInfoId = PA.ProviderInfoId

                              }).ToListAsync();

            //foreach (var item in Id)
            //{

            //}

            return Data;
        }


        public async Task<List<PatientAppointmentBasicDto>> AppointmentCentralByPatient(ICollection<long?> Id)
        {
            var joinData = await (from PA in _context.PatientAppointments.Where(x => Id.Contains(x.PatientInfoId))
                                  join M in _context.PatientInfo
                                  on PA.PatientInfoId equals M.PatientInfoId

                                  join P in _context.ProviderInfo
                                  on PA.ProviderInfoId equals P.ProviderInfoId


                                  select new PatientAppointmentBasicDto
                                  {
                                      PatientFullName = M.FirstName + ' ' + M.LastName,
                                      DocFullName = P.FirstName + ' ' + P.LastName,
                                      AppointmentId = PA.AppointmentId,
                                      PatientInfoId = PA.PatientInfoId,
                                      AppointmentType = PA.AppointmentType,
                                      ExactTime = PA.ExactTime,
                                      Date = PA.Date,
                                      EndDate = PA.EndDate,
                                      StartTime = PA.StartTime,
                                      EndTime = PA.EndTime,
                                      ProviderInfoId = PA.ProviderInfoId

                                  }).ToListAsync();

            return joinData;
        }

        public async Task<ResponseDto<bool>> AppointmentCreate(PatientAppointmentBasicDto appointmentBasicDto)
        {
            try
            {
                var result = false;
                var mapped = _mapper.Map<PatientAppointmentBasicDto, PatientAppointments>(appointmentBasicDto);
                var data = await _context.PatientAppointments.AddAsync(mapped);
                await _context.SaveChangesAsync();
                if (!(data is null))
                {
                    result = true;
                }
                var response = new ResponseDto<bool>();
                response.Data = result;
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public bool AppointmentDeleteById(int Id)
        {
            try
            {
                var rec = _context.PatientAppointments.FirstOrDefault(x => x.AppointmentId == Id);

                if (!(rec is null))
                {
                    var SlotRec = _context.ProviderSlots.FirstOrDefault(s => s.SlotId == rec.SlotId);
                    if (!(SlotRec is null))
                    {
                        SlotRec.IsBook = false;
                        SlotRec.PatientInfoId = null;
                        _context.SaveChanges();
                    }
                    _context.Remove(rec);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public bool AppointmentDeleteByRecId(int Id)
        {
            var rec = _context.PatientAppointments.Where(x => x.RecursionNo == Id).ToList();

            if (!(rec is null))
            {
                foreach (var item in rec)
                {
                    _context.Remove(item);
                    _context.SaveChanges();

                }
                return true;
            }
            else
            {
                return false;
            }

        }

        public async Task<ResponseDto<List<PatientAppointmentBasicDto>>> AppointmentFilterByDocName(int DocId, int PatId)
        {
            var rec = await _context.PatientAppointments.Include(x => x.ProviderInfo).Include(p => p.PatientInfo).Where(x => x.ProviderInfoId == DocId && x.PatientInfoId == PatId).OrderByDescending(x => x.AppointmentId).ToListAsync();
            var response = new ResponseDto<List<PatientAppointmentBasicDto>>();
            response.Data = _mapper.Map<List<PatientAppointments>, List<PatientAppointmentBasicDto>>(rec);
            return response;
        }


        public async Task<PatientAppointmentBasicDto> AppointmentGetById(int Id)
        {

            var joinData = await (from PA in _context.PatientAppointments.Where(x => x.AppointmentId == Id)
                                  join M in _context.PatientInfo
                                  on PA.PatientInfoId equals M.PatientInfoId

                                  join P in _context.ProviderInfo
                                  on PA.ProviderInfoId equals P.ProviderInfoId


                                  select new PatientAppointmentBasicDto
                                  {
                                      PatientFullName = M.FirstName + ' ' + M.LastName,
                                      DocFullName = P.FirstName + ' ' + P.LastName,
                                      AppointmentId = PA.AppointmentId,
                                      PatientInfoId = PA.PatientInfoId,
                                      AppointmentType = PA.AppointmentType,
                                      ExactTime = PA.ExactTime,
                                      Date = PA.Date,
                                      EndDate = PA.EndDate,
                                      StartTime = PA.StartTime,
                                      EndTime = PA.EndTime,
                                      ProviderInfoId = PA.ProviderInfoId,
                                      DepartmentType = PA.DepartmentType

                                  }).FirstOrDefaultAsync();
            return joinData;
        }
        //public async Task<ResponseDto<PatientAppointmentBasicDto>> AppointmentGetById(int Id)
        //{
        //    var OldEntity = await _context.PatientAppointments.FirstOrDefaultAsync(x => x.AppointmentId == Id);
        //    var mapped = _mapper.Map<PatientAppointments, PatientAppointmentBasicDto>(OldEntity);
        //    var response = new ResponseDto<PatientAppointmentBasicDto>();
        //    response.Data = mapped;
        //    return response;
        //}
        public List<PatientAppointments> GetAppointmentDetailByPatientId(long Id)
        {
            return _context.PatientAppointments.Where(x => x.PatientInfoId == Id).ToList();
        }
        public async Task<List<PatientAppointmentBasicDto>> AppointmentList(int? Id)
        {
            var joinData = await (from PA in _context.PatientAppointments.Where(x => x.PatientInfoId == Id)
                                  join M in _context.PatientInfo
                                  on PA.PatientInfoId equals M.PatientInfoId

                                  join P in _context.ProviderInfo
                                  on PA.ProviderInfoId equals P.ProviderInfoId
                                  select new PatientAppointmentBasicDto
                                  {
                                      PatientFullName = M.FirstName + ' ' + M.LastName,
                                      DocFullName = P.FirstName + ' ' + P.LastName,
                                      AppointmentId = PA.AppointmentId,
                                      PatientInfoId = PA.PatientInfoId,
                                      AppointmentType = PA.AppointmentType,
                                      ExactTime = PA.ExactTime,
                                      Date = PA.Date,
                                      EndDate = PA.EndDate,
                                      StartTime = PA.StartTime,
                                      EndTime = PA.EndTime,
                                      ProviderInfoId = PA.ProviderInfoId,
                                      PatFirstName = M.FirstName,
                                      DocFirstName = P.FirstName,
                                      StatusId = PA.StatusId,
                                      DepartmentType = PA.DepartmentType

                                  }).ToListAsync();
            return joinData;
        }
        public async Task<List<PatientAppointmentBasicDto>> AppointmentListByProviderId(int Id)
        {
            var joinData = await (from PA in _context.PatientAppointments.Where(x => x.ProviderInfoId == Id && x.DepartmentType == 1)
                                  join M in _context.PatientInfo
                                  on PA.PatientInfoId equals M.PatientInfoId
                                  join P in _context.ProviderInfo
                                  on PA.ProviderInfoId equals P.ProviderInfoId
                                  select new PatientAppointmentBasicDto
                                  {
                                      PatientFullName = M.FirstName + ' ' + M.LastName,
                                      DocFullName = P.FirstName + ' ' + P.LastName,
                                      AppointmentId = PA.AppointmentId,
                                      PatientInfoId = PA.PatientInfoId,
                                      AppointmentType = PA.AppointmentType,
                                      ExactTime = PA.ExactTime,
                                      Date = PA.Date,
                                      EndDate = PA.EndDate,
                                      StartTime = PA.StartTime,
                                      EndTime = PA.EndTime,
                                      ProviderInfoId = PA.ProviderInfoId,
                                      PatFirstName = M.FirstName,
                                      DocFirstName = P.FirstName,
                                      StatusId = PA.StatusId,
                                      DepartmentType = PA.DepartmentType

                                  }).ToListAsync();

            return joinData;
        }
        public async Task<List<PatientAppointmentBasicDto>> AppointmentListForCentral()
        {
            var joinData = await (from PA in _context.PatientAppointments
                                  join M in _context.PatientInfo
                                  on PA.PatientInfoId equals M.PatientInfoId
                                  join P in _context.ProviderInfo.Where(x=>x.IsActive == true)
                                  on PA.ProviderInfoId equals P.ProviderInfoId
                                  select new PatientAppointmentBasicDto
                                  {
                                      PatientFullName = M.FirstName + ' ' + M.LastName,
                                      DocFullName = P.FirstName + ' ' + P.LastName,
                                      AppointmentId = PA.AppointmentId,
                                      PatientInfoId = PA.PatientInfoId,
                                      AppointmentType = PA.AppointmentType,
                                      ExactTime = PA.ExactTime,
                                      Date = PA.Date,
                                      EndDate = PA.EndDate,
                                      StartTime = PA.StartTime,
                                      EndTime = PA.EndTime,
                                      ProviderInfoId = PA.ProviderInfoId,
                                      StatusId = PA.StatusId
                                  }).ToListAsync();

            return joinData;
        }
        public async Task<ResponseDto<PatientAppointmentBasicDto>> AppointmentUpdate(PatientAppointmentBasicDto appointmentBasicDto)
        {
            try
            {
                var mapped = _mapper.Map<PatientAppointmentBasicDto, PatientAppointmentBasicDto>(appointmentBasicDto);
                var OldEntity = await _context.PatientAppointments.FindAsync(mapped.AppointmentId);
                _context.Entry(OldEntity).CurrentValues.SetValues(mapped);
                await _context.SaveChangesAsync();
                var response = new ResponseDto<PatientAppointmentBasicDto>();
                var Entity = _mapper.Map<PatientAppointments, PatientAppointmentBasicDto>(OldEntity);
                response.Data = Entity;
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        #region Appointment Queue
        public async Task<List<AppointmentQueueDto>> TodayAppointmentQueue(long Id)
        {
            var dateNow = DateTime.UtcNow.Date;
            var joinData = await (from PA in _context.PatientAppointments.Where(x => x.ProviderInfoId == Id && x.AppointmentType == "Exact" && x.IsCompleted == false).OrderBy(x => x.Date)
                                  join M in _context.PatientInfo
                                  on PA.PatientInfoId equals M.PatientInfoId

                                  join P in _context.ProviderInfo
                                  on PA.ProviderInfoId equals P.ProviderInfoId

                                  join Sp in _context.ProviderSpecialities on P.Speciality equals Sp.ProviderSpecialityId

                                  select new AppointmentQueueDto
                                  {
                                      PatientName = M.FirstName + ' ' + M.LastName,
                                      DoctorName = P.FirstName + ' ' + P.LastName,
                                      AppointmentId = PA.AppointmentId,
                                      PatientInfoId = PA.PatientInfoId,
                                      AppointmentType = PA.AppointmentType,
                                      Date = PA.Date,
                                      StartTime = PA.StartTime,
                                      EndTime = PA.EndTime,
                                      IsCompleted = PA.IsCompleted,
                                      ProviderInfoId = PA.ProviderInfoId,
                                      Speciality = Sp.ProviderSpeciality,
                                      ExactAppointmentTime = PA.ExactTime,
                                      ProviderProfilePic = P.ProviderProfilePic
                                  }).ToListAsync();

            return joinData;
        }


        public async Task<bool> CompleteAppointment(long Id)
        {
            var OldEntity = await _context.PatientAppointments.FirstOrDefaultAsync(x => x.AppointmentId == Id);
            OldEntity.IsCompleted = true;
            _context.Entry(OldEntity).CurrentValues.SetValues(OldEntity);
            await _context.SaveChangesAsync();
            return true;

        }

        public long? GetLatestRecursionNo()
        {

            var rec = _context.PatientAppointments.Max(x => x.RecursionNo);
            if (rec is null)
            {
                rec = 1;
            }
            else
            {
                rec += 1;
            }

            return rec;
        }
        #endregion

        public async Task<ResponseDto<bool>> isExistorNot(DateTime? time)
        {
            var isExist = false;
            var Value = await _context.PatientAppointments.Where(x => x.ExactTime == time).FirstOrDefaultAsync();
            if (!(Value is null))
            {
                isExist = true;
            }
            var response = new ResponseDto<bool>();
            response.Data = isExist;
            return response;
        }


        public async Task<List<AppointmentDetailDto>> AppointmentDetails(int Id)
        {
            var joinData = await (from PA in _context.PatientAppointments.Where(x => x.AppointmentId == Id)
                                  join M in _context.PatientInfo
                                  on PA.PatientInfoId equals M.PatientInfoId

                                  join P in _context.ProviderInfo
                                  on PA.ProviderInfoId equals P.ProviderInfoId


                                  select new AppointmentDetailDto
                                  {
                                      PatientFullName = M.FirstName + ' ' + M.LastName,
                                      DocFullName = P.FirstName + ' ' + P.LastName,
                                      AppointmentId = PA.AppointmentId,
                                      PatientInfoId = PA.PatientInfoId,
                                      AppointmentType = PA.AppointmentType,
                                      ExactTime = PA.ExactTime,
                                      Date = PA.Date,
                                      EndDate = PA.EndDate,
                                      StartTime = PA.StartTime,
                                      EndTime = PA.EndTime,

                                  }).ToListAsync();

            return joinData;
        }

        public async Task<List<PatientAppointmentBasicDto>> AppointmentCentralByDoctorPatient(ICollection<long?> PatId, ICollection<long?> DocId)
        {
            var Data = await (from PA in _context.PatientAppointments.Where(x => DocId.Contains(x.ProviderInfoId) && PatId.Contains(x.PatientInfoId))
                              join M in _context.PatientInfo
                              on PA.PatientInfoId equals M.PatientInfoId

                              join P in _context.ProviderInfo
                              on PA.ProviderInfoId equals P.ProviderInfoId


                              select new PatientAppointmentBasicDto
                              {
                                  PatientFullName = M.FirstName + ' ' + M.LastName,
                                  DocFullName = P.FirstName + ' ' + P.LastName,
                                  AppointmentId = PA.AppointmentId,
                                  PatientInfoId = PA.PatientInfoId,
                                  AppointmentType = PA.AppointmentType,
                                  ExactTime = PA.ExactTime,
                                  Date = PA.Date,
                                  EndDate = PA.EndDate,
                                  StartTime = PA.StartTime,
                                  EndTime = PA.EndTime,
                                  ProviderInfoId = PA.ProviderInfoId,
                                  PatFirstName = M.FirstName,
                                  DocFirstName = P.FirstName

                              }).ToListAsync();

            //foreach (var item in Id)
            //{

            //}

            return Data;
        }

        public async Task<List<ProviderInfoBasicDto>> AvailableProviderListOnDate(DateTime dateTime)
        {
            var Data = await (from PA in _context.ProviderSlots.Where(x => x.DayOfWeek == dateTime)
                              join M in _context.ProviderInfo
                              on PA.ProviderInfoId equals M.ProviderInfoId



                              select new ProviderInfoBasicDto
                              {
                                  ProviderInfoId = (long)PA.ProviderInfoId,
                                  FullName = "Dr" + " " + M.FirstName + " " + M.LastName

                              }).Distinct().ToListAsync();
            return Data;
        }

        public async Task<List<ProviderSlotsDto>> AvailableSlots(DateTime dateTime, long providerId)
        {
            var Data = await (from PA in _context.ProviderSlots.Where(x => x.DayOfWeek == dateTime && x.ProviderInfoId == providerId && x.IsBook == false)

                              select new ProviderSlotsDto
                              {
                                  ProviderInfoId = (long)PA.ProviderInfoId,
                                  SlotId = PA.SlotId,
                                  StartTime = PA.StartTime,
                                  EndTime = PA.EndTime,


                              }).ToListAsync();
            return Data;
        }

        public PatientAppointments GetSlotsDetailByIdAndAppointmentSave(long Id, long PatientId, string ActionMethod)
        {
            var rec = _context.ProviderSlots.FirstOrDefault(x => x.SlotId == Id);
            if (!(rec is null))
            {
                TimeSpan a = (TimeSpan)rec.StartTime;
                DateTime dt = DateTime.Now + a;
                rec.IsBook = true;
                rec.PatientInfoId = PatientId;
                _context.SaveChanges();
                PatientAppointments patientAppointments = new PatientAppointments();
                if (ActionMethod == "Patient")
                {
                    patientAppointments.AppointmentType = "Exact";

                }
                else
                {
                    patientAppointments.AppointmentType = "Walk In";
                }
                patientAppointments.ProviderInfoId = rec.ProviderInfoId;
                patientAppointments.PatientInfoId = PatientId;
                patientAppointments.Date = rec.DayOfWeek;
                patientAppointments.StartTime = rec.StartTime;
                patientAppointments.EndTime = rec.EndTime;
                patientAppointments.SlotId = rec.SlotId;
                patientAppointments.DepartmentType = 1;
                _context.PatientAppointments.Add(patientAppointments);
                _context.SaveChanges();
                return patientAppointments;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> AddVisits(VisitsDto visitsDto)
        {
            MediClinicContext context = new MediClinicContext();
            var mapped = _mapper.Map<Visits>(visitsDto);
            mapped.CreatedBy = Convert.ToInt32(_sessionManager.GetUserId());
            mapped.CreatedDate = DateTime.UtcNow;
            context.Visits.Add(mapped);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<List<VisitsDto>> GetVisitsList(int patientId)
        {
            if (patientId == 5)
            {
                using (var conn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
                {
                    var result = await conn.QueryAsync<VisitsDto>(sql: "[spGetVisitsListsForAdmin]",
                    commandType: CommandType.StoredProcedure);

                    return result.ToList();
                }

            }
            else
            {
                using (var conn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
                {
                    var result = await conn.QueryAsync<VisitsDto>(sql: "[spGetVisitsLists]", param: new { patientid = patientId },
                    commandType: CommandType.StoredProcedure);

                    return result.ToList();
                }
            }
        }

        public async Task<List<AppointmentListForReceptionist>> AppointmentListForReceptionlist(DateTime dateTime,long? Id)
        {
            using (var conn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                var result = await conn.QueryAsync<AppointmentListForReceptionist>(sql: "[spGetAppointMentOfBookedSlots]", param: new { date = dateTime, ProviderInfoId = Id },
                commandType: CommandType.StoredProcedure);

                return result.ToList();
            }

        }

        public bool AppointmentStatus(long Id, int statusId)
        {
            var rec = _context.PatientAppointments.FirstOrDefault(x => x.AppointmentId == Id);
            if (!(rec is null))
            {

                rec.StatusId = statusId;
                _context.SaveChanges();

                return true;

            }
            else
            {
                return false;
            }
        }

        public bool RescheduleAppointment(long slotId, long AppId)
        {
            var AppRec = _context.PatientAppointments.FirstOrDefault(p => p.AppointmentId == AppId);
            var OldSlotRec = _context.ProviderSlots.FirstOrDefault(x => x.SlotId == AppRec.SlotId);
            if (!(OldSlotRec is null))
            {
                OldSlotRec.PatientInfoId = null;
                OldSlotRec.IsBook = false;
                _context.SaveChanges();
                var NewSlot = _context.ProviderSlots.FirstOrDefault(s => s.SlotId == slotId);
                NewSlot.PatientInfoId = AppRec.PatientInfoId;
                NewSlot.IsBook = true;
                _context.SaveChanges();
                AppRec.StartTime = NewSlot.StartTime;
                AppRec.EndTime = NewSlot.EndTime;
                AppRec.SlotId = NewSlot.SlotId;
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        public async Task<List<PatientAppointmentBasicDto>> OTAndOPDListForReceptionist(DateTime dateTime)
        {
            var joinData = await (from PA in _context.PatientAppointments.Where(x => x.Date == dateTime && x.DepartmentType != 1)
                                  join M in _context.PatientInfo
                                  on PA.PatientInfoId equals M.PatientInfoId

                                  join P in _context.ProviderInfo
                                  on PA.ProviderInfoId equals P.ProviderInfoId


                                  select new PatientAppointmentBasicDto
                                  {
                                      PatientFullName = M.FirstName + ' ' + M.LastName,
                                      DocFullName = P.FirstName + ' ' + P.LastName,
                                      AppointmentId = PA.AppointmentId,
                                      PatientInfoId = PA.PatientInfoId,
                                      AppointmentType = PA.AppointmentType,
                                      ExactTime = PA.ExactTime,
                                      Date = PA.Date,
                                      EndDate = PA.EndDate,
                                      StartTime = PA.StartTime,
                                      EndTime = PA.EndTime,
                                      ProviderInfoId = PA.ProviderInfoId,
                                      DepartmentType = PA.DepartmentType,
                                      StatusId = PA.StatusId

                                  }).ToListAsync();

            return joinData;
        }

        public async Task<List<PatientAppointmentBasicDto>> OTAppointmentListByProviderId(int Id)
        {
            var joinData = await (from PA in _context.PatientAppointments.Where(x => x.ProviderInfoId == Id && x.DepartmentType == 2)
                                  join M in _context.PatientInfo
                                  on PA.PatientInfoId equals M.PatientInfoId

                                  join P in _context.ProviderInfo
                                  on PA.ProviderInfoId equals P.ProviderInfoId


                                  select new PatientAppointmentBasicDto
                                  {
                                      PatientFullName = M.FirstName + ' ' + M.LastName,
                                      DocFullName = P.FirstName + ' ' + P.LastName,
                                      AppointmentId = PA.AppointmentId,
                                      PatientInfoId = PA.PatientInfoId,
                                      AppointmentType = PA.AppointmentType,
                                      ExactTime = PA.ExactTime,
                                      Date = PA.Date,
                                      EndDate = PA.EndDate,
                                      StartTime = PA.StartTime,
                                      EndTime = PA.EndTime,
                                      ProviderInfoId = PA.ProviderInfoId,
                                      PatFirstName = M.FirstName,
                                      DocFirstName = P.FirstName,
                                      StatusId = PA.StatusId

                                  }).ToListAsync();

            return joinData;
        }

        public async Task<List<PatientAppointmentBasicDto>> OPDAppointmentListByProviderId(int Id)
        {
            var joinData = await (from PA in _context.PatientAppointments.Where(x => x.ProviderInfoId == Id && x.DepartmentType == 3)
                                  join M in _context.PatientInfo
                                  on PA.PatientInfoId equals M.PatientInfoId

                                  join P in _context.ProviderInfo
                                  on PA.ProviderInfoId equals P.ProviderInfoId


                                  select new PatientAppointmentBasicDto
                                  {
                                      PatientFullName = M.FirstName + ' ' + M.LastName,
                                      DocFullName = P.FirstName + ' ' + P.LastName,
                                      AppointmentId = PA.AppointmentId,
                                      PatientInfoId = PA.PatientInfoId,
                                      AppointmentType = PA.AppointmentType,
                                      ExactTime = PA.ExactTime,
                                      Date = PA.Date,
                                      EndDate = PA.EndDate,
                                      StartTime = PA.StartTime,
                                      EndTime = PA.EndTime,
                                      ProviderInfoId = PA.ProviderInfoId,
                                      PatFirstName = M.FirstName,
                                      DocFirstName = P.FirstName,
                                      StatusId = PA.StatusId

                                  }).ToListAsync();

            return joinData;
        }

        public async Task<List<AppointmentQueueDto>> AllTodayAppointmentQueue()
        {
            var dateNow = DateTime.UtcNow.Date;
            var joinData = await (from PA in _context.PatientAppointments.Where(x => x.AppointmentType == "Exact" && x.IsCompleted == false).OrderBy(x => x.Date)
                                  join M in _context.PatientInfo
                                  on PA.PatientInfoId equals M.PatientInfoId

                                  join P in _context.ProviderInfo
                                  on PA.ProviderInfoId equals P.ProviderInfoId

                                  join Sp in _context.ProviderSpecialities on P.Speciality equals Sp.ProviderSpecialityId

                                  select new AppointmentQueueDto
                                  {
                                      PatientName = M.FirstName + ' ' + M.LastName,
                                      DoctorName = P.FirstName + ' ' + P.LastName,
                                      AppointmentId = PA.AppointmentId,
                                      PatientInfoId = PA.PatientInfoId,
                                      AppointmentType = PA.AppointmentType,
                                      Date = PA.Date,
                                      StartTime = PA.StartTime,
                                      EndTime = PA.EndTime,
                                      IsCompleted = PA.IsCompleted,
                                      ProviderInfoId = PA.ProviderInfoId,
                                      Speciality = Sp.ProviderSpeciality,
                                      ExactAppointmentTime = PA.ExactTime,
                                      ProviderProfilePic = P.ProviderProfilePic
                                  }).ToListAsync();

            return joinData;
        }

        public long getVisitDetail(int Id)
        {
            var OldEntity =  _context.Visits.FirstOrDefault(x => x.VisitId == Id);
            var AppRec = _context.PatientAppointments.FirstOrDefault(x => x.AppointmentId == OldEntity.AppoinmentId);
            return (long)AppRec.PatientInfoId;
           
        }

        public bool SaveCalendarViewSetting(CalendarSettingDto calendarSettingDto)
        {
            var oldEntity = _context.CalendarSetting.FirstOrDefault();
            if (!(oldEntity is null))
            {
                var mappedData = _mapper.Map<CalendarSetting>(calendarSettingDto);
                mappedData.CalendarSettingId = oldEntity.CalendarSettingId;
                _context.Entry(oldEntity).CurrentValues.SetValues(mappedData);
                _context.SaveChanges();
                return true;
            }
            else
            {
                var mappedData = _mapper.Map<CalendarSetting>(calendarSettingDto);
                _context.CalendarSetting.Add(mappedData);
                _context.SaveChanges();
                return true;
            }
        }

        public CalendarSettingDto GetCalendarViewSet()
        {
            var entity = _context.CalendarSetting.FirstOrDefault();
            if (!(entity is null))
            {
                var mappedData = _mapper.Map<CalendarSettingDto>(entity);
                return mappedData;
            }
            else
            {
                var entityData = new CalendarSetting
                {
                    CalViewDay = false,
                    CalViewMonth = false,
                    CalViewWeek = false,
                   

                };
               
                var mappedData = _mapper.Map<CalendarSettingDto>(entityData);
                return mappedData;
            }
        }

        public async Task<List<ProviderSlotsDto>> AvailableSlotsView(long providerId, DateTime date, string dpt)
        {
            var Data = await(from PA in _context.ProviderSlots.OrderBy(x=>x.StartTime).Where(x => x.ProviderInfoId == providerId && x.DayOfWeek == date)
                             
                             join PS in _context.ProviderSessions.Where(x=>x.DepartmentName == dpt)
                             on PA.ProviderSessionId equals PS.ProviderSessionId
                             select new ProviderSlotsDto
                             {
                                 ProviderInfoId = (long)PA.ProviderInfoId,
                                 SlotId = PA.SlotId,
                                 StartTime = PA.StartTime,
                                 EndTime = PA.EndTime,
                                 DayOfWeek = PA.DayOfWeek,
                                 IsBook = PA.IsBook
                             }).ToListAsync();
            return Data;
        }

        public async Task<ResponseDto<PatientAppointmentBasicDto>> AppointmentCheck(PatientAppointmentBasicDto patientAppointmentBasicDto)
        {
            var rec = await _context.PatientAppointments.FirstOrDefaultAsync(x => x.StartTime == patientAppointmentBasicDto.StartTime && x.Date == patientAppointmentBasicDto.Date && x.ProviderInfoId == patientAppointmentBasicDto.ProviderInfoId);
            var Entity = _mapper.Map<PatientAppointmentBasicDto>(rec);
            if (!(Entity is null))
            {
                return new ResponseDto<PatientAppointmentBasicDto>()
                {
                    Data = Entity,
                    Message = "1"
                };
            }
            else
            {
                return new ResponseDto<PatientAppointmentBasicDto>()
                {
                    Data = Entity,
                    Message = "0"
                };
            }
        }

        public async Task<List<AppointmentQueueDto>> AppointmentsForQueue(string date, long? Id)
        {
            try
            {
                using (var conn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
                {
                    var result = await conn.QueryAsync<string>(sql: "[spGetBookAppointmentQueue]", param: new { DateToday = date, ProviderInfo = Id },
                    commandType: CommandType.StoredProcedure);
                    var builder = new StringBuilder();
                    var list = result.ToList();
                    if (list.Count > 0)
                    {
                        foreach (var r in result)
                        {

                            builder.Append(r);
                        }
                        var response = JsonConvert.DeserializeObject<List<AppointmentQueueDto>>(builder.ToString());
                        return response.ToList();
                    }
                    else
                    {
                        return new List<AppointmentQueueDto>();
                    }
                    //var rec = result.ToList();
                    
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<int> GetPatientLatestVisitId(long PaatientId)
        {
            //spPatientLatestVisitId
            try
            {
                using (var conn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
                {
                    var result = await conn.QueryAsync<int>(sql: "[spPatientLatestVisitId]", param: new { PatientId = PaatientId },
                    commandType: CommandType.StoredProcedure);

                    return result.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
