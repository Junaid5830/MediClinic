using AutoMapper;
using Dapper;
using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.ClinicalNotesDto;
using MediClinic.Models.DTOs.SMSDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.ClinicalNotesInterface;
using MediClinic.Services.Interfaces.PatientIdandSignatureInterface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.ClinicalNotesService
{
    public class ClinicalNoteService : IClinicalNoteInterface
    {
        private MediClinicContext _context;
        private IMapper _mapper;
        private IPatientIdandSignatureService _patientIdandSignature;
        public ClinicalNoteService(MediClinicContext context, IMapper mapper, IPatientIdandSignatureService patientIdandSignature)
        {
            _context = context;
            _mapper = mapper;
            _patientIdandSignature = patientIdandSignature;
        }


        public List<ClinicalNoteDto> GetClinicalNoteList(long PatientId)
        {
            using (var conn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                var result = conn.Query<ClinicalNoteDto>(sql: "[spGetClinicalNotesListByPatientId]", param: new { patientId = PatientId },
                commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }

        public bool CreateClinicalNote(ClinicalNoteDto clinicalNote)
        {
            try
            {
                var mappedData = _mapper.Map<PatientClinicalNotes>(clinicalNote);
                 mappedData.IsSigned = false;
                _context.PatientClinicalNotes.Add(mappedData);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool UpdateClinicalNote(ClinicalNoteDto clinicalNote)
        {
            try
            {
                var mappedData = _mapper.Map<PatientClinicalNotes>(clinicalNote);
                var oldEntity = _context.PatientClinicalNotes.Find(mappedData.ClinicalNoteId);
                _context.Entry(oldEntity).CurrentValues.SetValues(mappedData);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool DeleteClinicalNotes(int clinicalNoteId)
        {
            var oldEntity = _context.PatientClinicalNotes.Where(x => x.ClinicalNoteId == clinicalNoteId).FirstOrDefault();
            if (oldEntity != null)
            {
                oldEntity.IsActive = false;
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public ClinicalNoteDto GetClinicalNoteById(int clinicalId)
        {
            var entity = _context.PatientClinicalNotes.Include(x => x.NoteByNavigation).Where(x => x.ClinicalNoteId == clinicalId).FirstOrDefault();
            if (!(entity is null))
            {
                return _mapper.Map<ClinicalNoteDto>(entity);
            }
            else
            {
                return new ClinicalNoteDto();
            }
        }

        public async Task<bool> SignedNote(int clinicalNoteId)
        {
            var oldEntity = await _context.PatientClinicalNotes.Where(x => x.ClinicalNoteId == clinicalNoteId).FirstOrDefaultAsync();
            if (oldEntity != null)
            {
                oldEntity.IsSigned = true;
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> IsPasswordMatched(string electronicPassword , long providerId)
        {
            var oldEntity = await _context.ProviderInfo.Where(x => x.ElectronicSignPassword == electronicPassword && x.ProviderInfoId == providerId).FirstOrDefaultAsync();
            if (oldEntity != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<ClinicalNoteDto>> ClinicalNoteListByVisit(long Id)
        {
            var joinData = await(from P in _context.PatientAppointments.Where(x => x.PatientInfoId == Id) 
                                 join V in _context.Visits
                                 on P.AppointmentId equals V.AppoinmentId

                             

                                 join CA in _context.PatientClinicalNotes.Where(x=> x.IsActive == true)
                                 on V.VisitId equals CA.VisitId

                                 join LU in _context.Lookups
                                 on CA.NoteType equals LU.LookupId

                                 join PI in _context.ProviderInfo
                                 on CA.NoteBy equals PI.ProviderInfoId

                                 select new ClinicalNoteDto
                                 {  
                                     ClinicalNoteId = CA.ClinicalNoteId,
                                     NoteDate = (DateTime)CA.NoteDate,
                                     NoteNo = CA.NoteNo,
                                     WriteNote = CA.WriteNote,
                                     PatientId = P.PatientInfoId,
                                     NoteType = LU.LookupId,
                                     NoteTypeValue = LU.LookupValue,
                                     WriterName = PI.FirstName + ' '+ PI.LastName,
                                     VisitId = CA.VisitId


                                 }).ToListAsync();

            return joinData;
        }

        public async Task<List<ICDDto>> GetAllICDCodes(bool withDetail)
        {
            using (var conn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                var result = await conn.QueryAsync<ICDDto>(sql: "[GetAllICDCodes]",
                param: new { withDescription = withDetail },
                commandType: CommandType.StoredProcedure);

                var response = result.ToList();
                if (response.Any())
                {
                    return result.ToList();
                }
                else
                {
                    return new List<ICDDto>();
                }

            }
        }



        #region ROS Section
        public int CreateROS(ClincalROSDto rOSDto)
        {
            try
            {
                var mappedData = _mapper.Map<ClincalROS>(rOSDto);
                
                _context.ClincalROS.Add(mappedData);
                _context.SaveChanges();
                return mappedData.RosId;
            }
            catch (Exception ex)
            {

                return 0;
            }
        }

        public bool UpdateROS(ClincalROSDto rOSDto)
        { 
            try
            {
                var mappedData = _mapper.Map<ClincalROS>(rOSDto);
                var oldEntity = _context.ClincalROS.Find(mappedData.RosId);
                _context.Entry(oldEntity).CurrentValues.SetValues(mappedData);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
        #endregion



        #region History OF Illness Section
        public int CreateHistoryOfIllness(HistoryOfillnessDto  historyOfillnessDto)
        {
            try
            {
                var mappedData = _mapper.Map<ClinicalHistoryOfillness>(historyOfillnessDto);
                _context.ClinicalHistoryOfillness.Add(mappedData);
                _context.SaveChanges();
                return mappedData.HistoryOfillnessId;
            }
            catch (Exception ex)
            {

                return 0;
            }
        }

        public bool UpdateHistoryOfIllness(HistoryOfillnessDto historyOfillnessDto)
        {
            try
            {
                var mappedData = _mapper.Map<ClinicalHistoryOfillness>(historyOfillnessDto);
                var oldEntity = _context.ClinicalHistoryOfillness.Find(mappedData.HistoryOfillnessId);
                _context.Entry(oldEntity).CurrentValues.SetValues(mappedData);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
        #endregion
    }
}
