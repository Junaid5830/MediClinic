using AutoMapper;
using MediClinic.Models.DTOs;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.CompanyBillsInterface;
using MediClinic.Services.Interfaces.SessionManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.CompanyBillsServices
{
    public class CompanyBillsService : ICompanyBillsServices
    {
        private MediClinicContext _context;
        private IMapper _mapper;
        private ISessionManager _sessionManager;

        public CompanyBillsService(MediClinicContext context, IMapper mapper, ISessionManager sessionManager)
        {
            _context = context;
            _mapper = mapper;
            _sessionManager = sessionManager;
        }

        public async Task<bool> Add(CompanyBillsDto companyBillsDto)
        {
            var mapped = _mapper.Map<CompanyBills>(companyBillsDto);
            if (companyBillsDto.BillId == 0)
            {
                MediClinicContext context = new MediClinicContext();
                mapped.CreatedBy = Convert.ToInt32(_sessionManager.GetUserId());
                mapped.CreatedDate = DateTime.UtcNow;
                context.CompanyBills.Add(mapped);
                await context.SaveChangesAsync();
            }
            else
            {
                var oldEntity = _context.CompanyBills.Find(companyBillsDto.BillId);
                var mappedData = _mapper.Map<CompanyBills>(companyBillsDto);
                _context.Entry(oldEntity).CurrentValues.SetValues(mappedData);
                _context.SaveChanges();
            }
            return true;
        }
        public List<CompanyBillsDto> GetBillsList()
        {
            var list = _context.CompanyBills.ToList();
            var mapped = _mapper.Map<List<CompanyBills>, List<CompanyBillsDto>>(list);
            return mapped;
        }
        public bool Delete(int billId)
        {
            var billid = _context.CompanyBills.Where(a => a.BillId == billId).FirstOrDefault();
            _context.CompanyBills.Remove(billid);
            _context.SaveChanges();
            return true;
        }
        public CompanyBillsDto GetBillById(int BillId)
        {
            var id = _context.CompanyBills.Where(a => a.BillId == BillId).FirstOrDefault();
            var mapped = _mapper.Map<CompanyBills, CompanyBillsDto>(id);
            return mapped;
        }
        
    }
}