using AutoMapper;
using MediClinic.Models.DTOs;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.DepartmentsInterface;
using MediClinic.Services.Interfaces.SessionManager;
using MediClinic.Services.Services.SessionManager;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediClinic.Services.Services.DepartmentsService
{
    public class DepartmentsService : IDepartmentsService
    {
        private MediClinicContext _context;
        private IMapper _mapper;
        private ISessionManager _sessionManager;

        public DepartmentsService(MediClinicContext context, IMapper mapper, ISessionManager sessionManager)
        {
            _context = context;
            _mapper = mapper;
            _sessionManager = sessionManager;
        }
        public List<DepartmentsDto> getlist()
        {
            var list = _context.Departments.Where(x => x.Isdeleted ==false).ToList();
            var mapped = _mapper.Map<List<Departments>, List<DepartmentsDto>>(list);
            return mapped;
        }
        public bool Add(DepartmentsDto departmentsDto)
        {
            var mapped = _mapper.Map<DepartmentsDto, Departments>(departmentsDto);

            if (departmentsDto.DepartmentsID == 0)
            {
                mapped.CreatedBy = Convert.ToInt32(_sessionManager.GetUserId());
                mapped.CreatedDate = DateTime.UtcNow;
                mapped.Isdeleted = false;
                _context.Departments.AddAsync(mapped);
                _context.SaveChanges();
                return true;
            }
            else
            {
                mapped.ModifiedBy = Convert.ToInt32(_sessionManager.GetUserId());
                mapped.ModifiedDate = DateTime.UtcNow;
                _context.Departments.Update(mapped);
                _context.SaveChanges();
                return true;
            }
        }
        public bool Delete(int id)
        {
            Departments depart = _context.Departments.Where(a => a.DepartmentsID == id).FirstOrDefault();
            if (depart != null)
            {
                depart.Isdeleted = true;
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public DepartmentsDto GetDepartmentsById(int id)
        {
            var Dep = _context.Departments.Where(a => a.DepartmentsID == id).FirstOrDefault();
            var mapped = _mapper.Map<Departments, DepartmentsDto>(Dep);
            return mapped;
        }
    }
}
