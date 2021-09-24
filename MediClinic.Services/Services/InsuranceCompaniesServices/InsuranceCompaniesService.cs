using AutoMapper;
using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.InsuranceCompaniesInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.InsuranceCompaniesServices
{
    public class InsuranceCompaniesService : IInsuranceCompanies
    {
        private MediClinicContext _context;
        private IMapper _mapper;
        public InsuranceCompaniesService(MediClinicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ResponseDto<InsuranceCompaniesDto>> AddUpdateCompany(InsuranceCompaniesDto insuranceCompaniesDto)
        {
            try
            {
                var mapper = _mapper.Map<InsuranceCompaniesDto, InsuranceCompanies>(insuranceCompaniesDto);
                var response = new ResponseDto<InsuranceCompaniesDto>();
                if (insuranceCompaniesDto.ComapnyID > 0)
                {
                    var OldEntity = await _context.InsuranceCompanies.FindAsync(insuranceCompaniesDto.ComapnyID);
                    _context.Entry(OldEntity).CurrentValues.SetValues(mapper);
                    await _context.SaveChangesAsync();
                    response.Data = insuranceCompaniesDto;
                }
                else
                {
                    var record =  _context.InsuranceCompanies.Add(mapper);
                    _context.SaveChanges();
                    response.Data = insuranceCompaniesDto;
                }
                return response;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<ResponseDto<bool>> DeleteCompany(int Id)
        {
            try
            {
                var result = false;
                var oldEntity = await _context.InsuranceCompanies.FindAsync(Id);
                _context.InsuranceCompanies.Remove(oldEntity);
                _context.SaveChanges();
                result = true;
                var response = new ResponseDto<bool>();
                response.Data = result;
                return response;
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        public async Task<ResponseDto<InsuranceCompaniesDto>> GetCompanyById(int Id)
        {
            try
            {
                var record = await _context.InsuranceCompanies.Where(x => x.ComapnyID == Id).FirstOrDefaultAsync();
                var mapper = _mapper.Map<InsuranceCompanies, InsuranceCompaniesDto>(record);
                var response = new ResponseDto<InsuranceCompaniesDto>();
                response.Data = mapper;
                return response;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<ResponseDto<List<InsuranceCompaniesDto>>> GetListOfCompanies()
        {
            try
            {
                var list = await _context.InsuranceCompanies.ToListAsync();
                var data = _mapper.Map<List<InsuranceCompaniesDto>>(list);
                var response = new ResponseDto<List<InsuranceCompaniesDto>>();
                response.Data = data;
                return response;
                
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
