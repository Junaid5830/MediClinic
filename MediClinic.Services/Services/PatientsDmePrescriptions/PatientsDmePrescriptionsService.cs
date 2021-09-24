using AutoMapper;
using Dapper;
using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.PatientsDmePrescription;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.PatientsDmePrescriptions
{
    public class PatientsDmePrescriptionsService : IPatientsDmePrescriptions
    {
        private MediClinicContext _context;
        private IMapper _mapper;

        public PatientsDmePrescriptionsService(MediClinicContext mediClinicContext, IMapper mapper)
        {
            _context = mediClinicContext;
            _mapper = mapper;
        }
        public async Task<ResponseDto<List<DmePatientsPrescriptionDto>>> AddListDmePrescription(List<DmePatientsPrescriptionDto> saveList)
        {
            try
            {
                var mapper = _mapper.Map<List<DmePatientsPrescriptionDto>, List<DmePatientsPrescription>>(saveList);
                var data =   _context.DmePatientsPrescription.AddRangeAsync(mapper);
                await _context.SaveChangesAsync();
                foreach (var item in mapper)
                {
                    var entity = _context.DmeInventory.Where(x => x.CPTCode == item.IcdCodeId).FirstOrDefault();
                    entity.ExistingQuantity = entity.ExistingQuantity - 1;
                    _context.SaveChanges();
                }
                var response = new ResponseDto<List<DmePatientsPrescriptionDto>>();
                
                return response;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Task<ResponseDto<DmePatientsPrescriptionDto>> AddUpdateDmePrescription(DmePatientsPrescriptionDto dmePatientsPrescriptionDto)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<bool>> DeleteDmePrescription(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto<DmeRentalFormDto>> DmeRentalFormCreate(DmeRentalFormDto dmeRentalForm)
        {
            try
            {
                var mapper = _mapper.Map<DmeRentalFormDto, DmeRentalForm>(dmeRentalForm);
                var data =await _context.DmeRentalForm.AddAsync(mapper);
                await _context.SaveChangesAsync();
                var mapped = _mapper.Map<DmeRentalFormDto>(data.Entity);
                var response = new ResponseDto<DmeRentalFormDto>();
                response.Data = mapped;
                return response;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Task<ResponseDto<DmeRentalFormDto>> DmeRentalFormGetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<DmePatientsPrescriptionDto>> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto<List<DmePatientsPrescriptionDto>>> GetGeneralList()
        {
            var list = await _context.DmePatientsPrescription.Include(x => x.Patient).Include(x => x.Prescriber).ToListAsync();
            var mapper = _mapper.Map<List<DmePatientsPrescriptionDto>>(list);
            var response = new ResponseDto<List<DmePatientsPrescriptionDto>>();
            if (mapper.Count > 0)
            {
                response.Data = mapper;
            }
            return response;
        }

        public async Task<ResponseDto<List<DmePatientsPrescriptionDto>>> GetLsitByPatientId(long PatientId)
        {
            try
            {
                var list = await _context.DmePatientsPrescription.Include(x=>x.Patient).Include(x=>x.Prescriber).Where(x => x.PatientId == PatientId).ToListAsync();
                var mapper = _mapper.Map<List<DmePatientsPrescriptionDto>>(list);
                var response = new ResponseDto<List<DmePatientsPrescriptionDto>>();
                if (mapper.Count > 0)
                {
                    response.Data = mapper;
                }
                return response;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<ResponseDto<bool>> StatusChange(int itemId, int statusId)
        {
            try
            {
                var response = new ResponseDto<bool>();
                var Entity = await _context.DmePatientsPrescription.Where(x => x.DmePatientId == itemId).FirstOrDefaultAsync();
                Entity.StatusId = statusId;
                await _context.SaveChangesAsync();
                response.Data = true;
                return response;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<ResponseDto<List<SupplierAssignedDmeDto>>> SuuplierAssignedDme(long supplierId)
        {
            //spPatientLatestVisitId
            try
            {
                using (var conn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
                {
                    var result = await conn.QueryAsync<SupplierAssignedDmeDto>(sql: "[spGetSupplierListAssignedDme]", param: new { UserId = supplierId },
                    commandType: CommandType.StoredProcedure);
                    var response = new ResponseDto<List<SupplierAssignedDmeDto>>();
                    response.Data = result.ToList();
                    return response;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
