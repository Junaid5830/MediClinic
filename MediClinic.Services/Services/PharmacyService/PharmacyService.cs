using AutoMapper;
using MediClinic.Models.DTOs;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.PharmacyInterface;
using MediClinic.Services.Interfaces.SessionManager;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.PharmacyService
{
    public class PharmacyService : IPharmacyService
    {
        private MediClinicContext _context;
        private IMapper _mapper;
        private ISessionManager _sessionManager;

        public PharmacyService(MediClinicContext context, IMapper mapper, ISessionManager sessionManager)
        {
            _context = context;
            _mapper = mapper;
            _sessionManager = sessionManager;
        }

        public async Task<bool> Add(PharmacyDto pharDto)
        {
            MediClinicContext context= new MediClinicContext();
            try
            {
                var mapped = _mapper.Map<PharmacyDto, Pharmacy>(pharDto);

                if (pharDto.P_ID == 0)
                {
                    mapped.CreatedBy = Convert.ToInt32(_sessionManager.GetUserId());
                    pharDto.CreatedBy = mapped.CreatedBy;
                    mapped.CreatedDate = DateTime.UtcNow;
                    pharDto.CreatedDate = mapped.CreatedDate;
                    context.Pharmacy.Add(mapped);
                    await context.SaveChangesAsync();
                }

                else
                {
                    var oldEntity = _context.Pharmacy.FirstOrDefault(x => x.P_ID == pharDto.P_ID);
                    oldEntity.PharmacyName = pharDto.PharmacyName;
                    oldEntity.Name = pharDto.Name;
                    oldEntity.Phone = pharDto.Phone;
                    oldEntity.Email = pharDto.Email;
                    oldEntity.AddressLine1 = pharDto.AddressLine1;
                    oldEntity.AddressLine2 = pharDto.AddressLine2;
                    oldEntity.AddressLine3 = pharDto.AddressLine3;
                    mapped.ModifiedBy = Convert.ToInt32(_sessionManager.GetUserId());
                    mapped.ModifiedDate = DateTime.UtcNow;
                    _context.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
             
            return true;

        }


        public async Task<List<PharmacyDto>> getlist()
        {

            try
            {
                var list = await _context.Pharmacy.ToListAsync();
                var mapped = _mapper.Map<List<Pharmacy>, List<PharmacyDto>>(list);

                return mapped;
            }
            catch (Exception ex) 
            {
                throw ex;
            }
            

        }


        public bool Delete(int pharID) 
        {
            Pharmacy phar = _context.Pharmacy.Where(a => a.P_ID == pharID).FirstOrDefault();
            if (phar != null) 
            {
                _context.Pharmacy.Remove(phar);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public PharmacyDto GetPharById(int pharId)
        {
            var phar = _context.Pharmacy.Where(a => a.P_ID == pharId).FirstOrDefault();
            var mapped = _mapper.Map<Pharmacy, PharmacyDto>(phar);
            return mapped;
        }
    }
}
