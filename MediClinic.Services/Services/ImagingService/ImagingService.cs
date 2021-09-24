using AutoMapper;
using Dapper;
using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.PatientInfoDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.ImagingInterface;
using MediClinic.Services.Interfaces.SessionManager;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.ImagingService
{
    public class ImagingService : IImagingService
    {
        private MediClinicContext _context;
        private IMapper _mapper;
        private ISessionManager _sessionManager;

        public ImagingService(MediClinicContext context, IMapper mapper, ISessionManager sessionManager)
        {
            _context = context;
            _mapper = mapper;
            _sessionManager = sessionManager;
        }
        public async Task<bool> Add(ImagingDto imagingDto) 
        {

            var mapped = _mapper.Map<Imaging>(imagingDto);
            if (imagingDto.ImagingId == 0)
            {
                MediClinicContext context = new MediClinicContext();
                mapped.CreatedBy = Convert.ToInt32(_sessionManager.GetUserId());
                mapped.CreatedDate = DateTime.UtcNow;
                context.Imaging.Add(mapped);
                await context.SaveChangesAsync();
            }
            else 
            {
                var oldEntity = _context.Imaging.FirstOrDefault(x => x.ImagingId == imagingDto.ImagingId);
                oldEntity.DateOfImaging = imagingDto.DateOfImaging;
                oldEntity.ReportedBy = imagingDto.ReportedBy;
                oldEntity.TypeOfImage = imagingDto.TypeOfImage;
                oldEntity.ReportStatus = imagingDto.ReportStatus;
                oldEntity.ImageFilm = imagingDto.ImageFilm;
                oldEntity.Diagnosis = imagingDto.Diagnosis;
                mapped.UpdateBy = Convert.ToInt32(_sessionManager.GetUserId());
                mapped.UpdateDate = DateTime.UtcNow;
                _context.SaveChanges();
            }
            return true;
        }

        public async Task<List<PatientInfoBasicDto>> GetlistofPatients() 
        {
            var list = await _context.PatientInfo.ToListAsync();
            var mapped = _mapper.Map<List<PatientInfo>, List<PatientInfoBasicDto>>(list);
            return mapped;
        }

        public async Task<List<ImagingDto>> GetImagingList() 
        {
            using (var conn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                var result = await conn.QueryAsync<ImagingDto>(sql: "[spGetImagingLists]", 
                commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }

        public bool Delete(int imagingId)
        {
            var imgId = _context.Imaging.Where(a => a.ImagingId == imagingId).FirstOrDefault();
            _context.Imaging.Remove(imgId);
            _context.SaveChanges();
            return true;
        }

        public ImagingDto GetImagingById(int imgId) 
        {
            var id = _context.Imaging.Where(a => a.ImagingId == imgId).FirstOrDefault();
            var mapped = _mapper.Map<Imaging, ImagingDto>(id);
            return mapped;
        }

       
        public async Task<ResponseDto<List<ImagingDto>>> PatientGetImagingList(long Id)
        {
            var rec = await _context.Imaging.Include(p => p.Patient).Where(x => x.PatientId == Id).ToListAsync();
            var response = new ResponseDto<List<ImagingDto>>();
            response.Data = _mapper.Map<List<Imaging>, List<ImagingDto>>(rec);
            return response;
        }

        public async Task<ResponseDto<ImagingDto>> AddSurgeryImaging(ImagingDto imagingDto)
        {
            var mapped = _mapper.Map<ImagingDto, Imaging>(imagingDto);
            var data = await _context.Imaging.AddAsync(mapped);
            await _context.SaveChangesAsync();

            var entity = _mapper.Map<Imaging, ImagingDto>(mapped);
            var response = new ResponseDto<ImagingDto>();

            response.Data = entity;
            return response;
        }

        public async Task<List<ImagingDto>> ImagingVisitList(int Id)
        {
            var list = await _context.Imaging.Where(x => x.VisitId == Id).ToListAsync();
            var mapped = _mapper.Map<List<Imaging>, List<ImagingDto>>(list);
            return mapped;
        }

        public async Task<List<ImagingDto>> GetImagingListByVisits(long Id)
        {
            var joinData = await (from P in _context.PatientAppointments.Where(x => x.PatientInfoId == Id)
                                  join V in _context.Visits
                                  on P.AppointmentId equals V.AppoinmentId



                                  join I in _context.Imaging
                                  on V.VisitId equals I.VisitId

                                

                                  select new ImagingDto
                                  {
                                     DateOfImaging = I.DateOfImaging,
                                      TimmingOfImaging = I.TimmingOfImaging,
                                      ReportedBy = I.ReportedBy,
                                      TypeOfImage = I.TypeOfImage,
                                      ReportStatus = I.ReportStatus,
                                      ImageFilm = I.ReportStatus,
                                      ImagingId = I.ImagingId,
                                      VisitId = I.VisitId,
                                      Diagnosis = I.Diagnosis
                                  }).ToListAsync();

            return joinData;
        }
    }
}
