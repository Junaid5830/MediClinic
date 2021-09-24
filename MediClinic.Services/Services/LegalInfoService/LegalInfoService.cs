using AutoMapper;
using MediClinic.Models.DTOs;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.LegalInfoInterface;
using MediClinic.Services.Interfaces.SessionManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.LegalInfoService
{
    public class LegalInfoService : ILegalInfoService
    {
        private MediClinicContext _context;
        private IMapper _mapper;
        private ISessionManager _sessionManager;

        public LegalInfoService(MediClinicContext context, IMapper mapper, ISessionManager sessionManager)
        {
            _context = context;
            _mapper = mapper;
            _sessionManager = sessionManager;
        }
        public async Task<bool> Add(LegalInfoDto legalInfoDto)
        {
            var mapped = _mapper.Map<LegalInfo>(legalInfoDto);
            if (legalInfoDto.LegalInfoId == 0)
            {
                MediClinicContext context = new MediClinicContext();
                mapped.CreatedBy = Convert.ToInt32(_sessionManager.GetUserId());
                mapped.CreatedDate = DateTime.UtcNow;
                context.LegalInfo.Add(mapped);
                await context.SaveChangesAsync();
            }
            else
            {
                var oldEntity = _context.LegalInfo.Find(legalInfoDto.LegalInfoId);
                var mappedData = _mapper.Map<LegalInfo>(legalInfoDto);
                _context.Entry(oldEntity).CurrentValues.SetValues(mappedData);
                _context.SaveChanges();
            }
            return true;
        }
        public List<LegalInfoDto> GetLegalInfoList()
        {
            var list = _context.LegalInfo.ToList();
            var mapped = _mapper.Map<List<LegalInfo>, List<LegalInfoDto>>(list);
            return mapped;
        }
        public bool Delete(int legalid)
        {
            var id = _context.LegalInfo.Where(a => a.LegalInfoId == legalid).FirstOrDefault();
            _context.LegalInfo.Remove(id);
            _context.SaveChanges();
            return true;
        }
        public LegalInfoDto GetLegalInfoById(int legalid)
        {
            var id = _context.LegalInfo.Where(a => a.LegalInfoId == legalid).FirstOrDefault();
            var mapped = _mapper.Map<LegalInfo, LegalInfoDto>(id);
            return mapped;
        }
    }
}
