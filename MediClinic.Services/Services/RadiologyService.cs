using AutoMapper;
using MediClinic.Models.DTOs;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.RadiologyInterface;
using MediClinic.Services.Interfaces.SessionManager;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace MediClinic.Services.Services
{
    public class RadiologyService : IRadiologyService
    {
        private MediClinicContext _context;
        private IMapper _mapper;
        private ISessionManager _sessionManager;

        public RadiologyService(MediClinicContext context, IMapper mapper, ISessionManager sessionManager)
        {
            _context = context;
            _mapper = mapper;
            _sessionManager = sessionManager;
        }

        public bool Add(RadiologyDto radiologyDto)
        {
            MediClinicContext context = new MediClinicContext();
            {
                var mapped = _mapper.Map<RadiologyDto, Radiology>(radiologyDto);
                if(radiologyDto.Id==0)
                    { 
                    mapped.CreatedBy = Convert.ToInt32(_sessionManager.GetUserId());
                    mapped.CreatedDate = DateTime.UtcNow;
                    context.Radiology.Add(mapped);
                    context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    mapped.ModifiedBy= Convert.ToInt32(_sessionManager.GetUserId());
                    mapped.ModifiedDate= DateTime.UtcNow;
                    context.Radiology.Update(mapped);
                    context.SaveChangesAsync();
                    return true;
                }
            }

        }

        public  List<RadiologyDto> getlist()
        {
            var list =  _context.Radiology.ToList();
            var mapped =  _mapper.Map<List<Radiology>, List<RadiologyDto>>(list);
            return mapped;
        }

        public bool Delete(int radiologyId)
        {
            Radiology radiol = _context.Radiology.Where(a =>a.Id == radiologyId).FirstOrDefault();
            if (radiol != null)
            {
                _context.Radiology.Remove(radiol);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
           
        }
        public RadiologyDto GetRadiolById(int radiolId)
        {
            var radiol = _context.Radiology.Where(a => a.Id == radiolId).FirstOrDefault();
            var mapped = _mapper.Map<Radiology, RadiologyDto>(radiol);
            return mapped;
        }
    }
}
