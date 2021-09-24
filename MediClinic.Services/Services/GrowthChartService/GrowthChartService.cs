using AutoMapper;
using MediClinic.Models.DTOs;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.GrowthChartInterface;
using MediClinic.Services.Interfaces.SessionManager;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.GrowthChartService
{
    public class GrowthChartService : IGrowthChartService
    {
        private MediClinicContext _context;
        private IMapper _mapper;
        private ISessionManager _sessionManager;

        public GrowthChartService(MediClinicContext context, IMapper mapper, ISessionManager sessionManager)
        {
            _context = context;
            _mapper = mapper;
            _sessionManager = sessionManager;
        }
        public bool Add(GrowthChartDto growthChartDto)
        {
            var mapped = _mapper.Map<GrowthChartDto, GrowthChart>(growthChartDto);
            if (growthChartDto.GrowthId == 0)
            {
                growthChartDto.CreatedBy = Convert.ToInt32(_sessionManager.GetUserId());
                growthChartDto.CreatedDate = DateTime.UtcNow;
                _context.GrowthChart.Add(mapped);
                _context.SaveChanges();
            }
            else
            {
                var oldEntity = _context.GrowthChart.FirstOrDefault(x => x.GrowthId == growthChartDto.GrowthId);
                oldEntity.DOB = growthChartDto.DOB;
                oldEntity.TodayDate = growthChartDto.TodayDate;
                oldEntity.Weight = growthChartDto.Weight;
                oldEntity.Height = growthChartDto.Height;
                oldEntity.Length = growthChartDto.Length;
                oldEntity.HeadDiameter = growthChartDto.HeadDiameter;
                oldEntity.NeckDiameter = growthChartDto.NeckDiameter;
                oldEntity.WaistDiameter = growthChartDto.WaistDiameter;
                oldEntity.ShoulderWidth = growthChartDto.ShoulderWidth;
                mapped.UpdatedBy = Convert.ToInt32(_sessionManager.GetUserId());
                mapped.UpdatedDate = DateTime.UtcNow;
                _context.SaveChanges();
            }
            return true;
        }

        public async Task<List<GrowthChartDto>> GetGrowthChartList(int? Id = null)
        {
            var list = new List<GrowthChart>();
            if (Id == null)
            {
                list = await _context.GrowthChart.Where(x=>x.VisitId != null).ToListAsync();
            }
            else
            {
                list = await _context.GrowthChart.Where(x => x.VisitId == Id).ToListAsync();
            }
            var mapped = _mapper.Map<List<GrowthChart>, List<GrowthChartDto>>(list);

            return mapped;
        }
        public bool Delete(int id)
        {
            var imgId = _context.GrowthChart.Where(a => a.GrowthId == id).FirstOrDefault();
            _context.GrowthChart.Remove(imgId);
            _context.SaveChanges();
            return true;
        }
        public GrowthChartDto GetImagingById(int gId)
        {
            var id = _context.GrowthChart.Where(a => a.GrowthId == gId).FirstOrDefault();
            var mapped = _mapper.Map<GrowthChart, GrowthChartDto>(id);
            return mapped;
        }

        public async Task<List<GrowthChartDto>> GetGrowthChartListByVisits(long Id)
        {
            var joinData = await (from P in _context.PatientAppointments.Where(x => x.PatientInfoId == Id)
                                  join V in _context.Visits
                                  on P.AppointmentId equals V.AppoinmentId



                                  join G in _context.GrowthChart
                                  on V.VisitId equals G.VisitId

                                  select new GrowthChartDto
                                  {
                                      GrowthId = G.GrowthId,
                                      DOB = G.DOB,
                                      Weight = G.Weight,
                                      Height = G.Height,
                                      Length = G.Length,
                                      HeadDiameter = G.HeadDiameter,
                                      NeckDiameter = G.NeckDiameter,
                                      WaistDiameter = G.WaistDiameter,
                                      ShoulderWidth = G.ShoulderWidth,
                                      VisitId = G.VisitId
                                  }).ToListAsync();

            return joinData;
        }
    }
}
