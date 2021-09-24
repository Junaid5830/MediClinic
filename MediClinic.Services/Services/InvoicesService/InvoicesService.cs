using AutoMapper;
using Dapper;
using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.PatientInfoDto;
using MediClinic.Models.DTOs.UsersDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.InvoicesInterface;
using MediClinic.Services.Interfaces.SessionManager;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.InvoicesService
{
    public class InvoicesService : IInvoicesService
    {
        private MediClinicContext _context;
        private IMapper _mapper;
        private ISessionManager _sessionManager;

        public InvoicesService(MediClinicContext context, IMapper mapper, ISessionManager sessionManager)
        {
            _context = context;
            _mapper = mapper;
            _sessionManager = sessionManager;
        }


        public  int Add(InvoicesDto invDto)
        {
            try
            {
                var mapped = _mapper.Map<InvoicesDto, Invoices>(invDto);

                if (invDto.InvoiceId == 0)
                {
                    invDto.CreatedById = Convert.ToInt32(_sessionManager.GetUserId());
                    invDto.CreatedDate = DateTime.UtcNow;
                    _context.Invoices.Add(mapped);
                    _context.SaveChanges();
                    var id = _context.Invoices.Max(i => i.InvoiceId);
                    return id;
                }
                else
                {
                    var oldEntity = _context.Invoices.FirstOrDefault(x => x.InvoiceId == invDto.InvoiceId);
                    oldEntity.Terms = invDto.Terms;
                    oldEntity.Crew = invDto.Crew;
                    oldEntity.MessageOnInvoice = invDto.MessageOnInvoice;
                    oldEntity.MessageOnStatement = invDto.MessageOnStatement;
                    mapped.ModifiedById = Convert.ToInt32(_sessionManager.GetUserId());
                    mapped.ModifiedDate = DateTime.UtcNow;
                    var chargesNew = _context.InvoiceCharges.Where(x => x.InvoiceFId == invDto.InvoiceId).ToList();
                    _context.InvoiceCharges.RemoveRange(chargesNew);
                    _context.SaveChanges();
                    return invDto.InvoiceId;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool  AddCharges(List<InvoiceChargesDto> charges)
        {
            try
            {
                var mapped = _mapper.Map<List<InvoiceCharges>>(charges);
                 _context.InvoiceCharges.AddRange(mapped);
                 _context.SaveChanges();
                    return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public PatientInfoBasicDto GetPaitent(int id)
        {
            var pat = _context.PatientInfo.Where(x => x.PatientInfoId == id).FirstOrDefault();
            var mapped = _mapper.Map<PatientInfo, PatientInfoBasicDto>(pat);
            return mapped;
        }
        public async Task<List<InvoicesDto>> GetInvoicesList() {
            try
            {
                var list = await _context.Invoices.ToListAsync();
                var mapped = _mapper.Map<List<Invoices>, List<InvoicesDto>>(list);

                return mapped;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<List<InvoiceChargesDto>> GetInvoicesChargesList(int invChargId) 
        {
            var list = await _context.InvoiceCharges.Where(a => a.InvoiceFId == invChargId).ToListAsync();
            var mapped = _mapper.Map<List<InvoiceCharges>, List<InvoiceChargesDto>>(list);
            return mapped;
        }

        private object Include(Func<object, object> p)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int invoiceId)
        {
            var inv = _context.Invoices.Where(a => a.InvoiceId == invoiceId).FirstOrDefault();
            if (inv != null)
            {
                var removeCharges = _context.InvoiceCharges.Where(x => x.InvoiceFId == inv.InvoiceId).ToList();
                _context.InvoiceCharges.RemoveRange(removeCharges);
                _context.Invoices.Remove(inv);
                _context.SaveChanges();
            }
            return true;
        }

        public InvoicesDto GetInvoiceById(int invId)
        {
            var id = _context.Invoices.Where(a => a.InvoiceId == invId).FirstOrDefault();
            var mapped = _mapper.Map<Invoices, InvoicesDto>(id);
            return mapped;
        }

        public bool ChargesDelete(int invoiceCId) 
        {
            var id = _context.InvoiceCharges.Where(a => a.InvoiceChargesId == invoiceCId).FirstOrDefault();
            if (id != null)
            {
                _context.InvoiceCharges.RemoveRange(id);
                _context.SaveChanges();
            }
            return true;
        }

        public async Task<List<InvoicesDto>> GetInvoicesVisitList(int Id)
        {
            try
            {
                var list = await _context.Invoices.Where(x => x.VisitId == Id).ToListAsync();
                var mapped = _mapper.Map<List<Invoices>, List<InvoicesDto>>(list);

                return mapped;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<InvoicesDto>> GetInvoicesListOfVisits(long Id)
        {
            var joinData = await(from P in _context.PatientAppointments.Where(x => x.PatientInfoId == Id)
                                 join V in _context.Visits
                                 on P.AppointmentId equals V.AppoinmentId

                                 join I in _context.Invoices
                                 on V.VisitId equals I.VisitId

                                 join IC in _context.InvoiceCharges
                                 on I.InvoiceId equals IC.InvoiceFId

                                 select new InvoicesDto
                                 {
                                     Crew = I.Crew,
                                     MessageOnInvoice = I.MessageOnInvoice,
                                     Product = IC.Product,
                                     Description = IC.Description,
                                     Ammount = IC.Amount,
                                     InvoiceId = I.InvoiceId
                                 }).ToListAsync();

            return joinData;
        }
    }
}
