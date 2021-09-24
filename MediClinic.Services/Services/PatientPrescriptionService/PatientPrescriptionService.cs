using AutoMapper;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.DMESuppliesDto;
using MediClinic.Models.DTOs.PrescriptionDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.PatientPrescriptionInterface;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.PatientPrescriptionService
{
    public class PatientPrescriptionService : IPatientPrescriptionService
    {
        private MediClinicContext _context;
        private IMapper _mapper;

        public PatientPrescriptionService(MediClinicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public bool prescriptionDeleteById(int Id)
        {
            var record = _context.PatientPrescriptions.Where(x => x.Id == Id).FirstOrDefault();
            if (record != null)
            {
                record.IsActive = false;
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        public async Task<ResponseDto<bool>> prescriptionCreate(PrescriptionBasicDto prescriptionBasicDto)
        {
            var result = false;
            var mapped = _mapper.Map<PrescriptionBasicDto, PatientPrescriptions>(prescriptionBasicDto);
            mapped.IsActive = true;
            mapped.CreatedDate = DateTime.UtcNow;
            var data = await _context.PatientPrescriptions.AddAsync(mapped);
            _context.SaveChanges();
            if (!(data is null))
            {
                result = true;
            }
            var response = new ResponseDto<bool>();
            response.Data = result;
            return response;
        }
        public async Task<ResponseDto<bool>> isPrescriptionExistorNot(long Id, long patientd)
        {
            var isExist = false;
            var value = await _context.PatientPrescriptions.Where(x => x.MedicationId == Id && x.PatientInfoId == patientd && x.IsActive == true).FirstOrDefaultAsync();
            if (!(value is null))
            {
                isExist = true;
            }
            var response = new ResponseDto<bool>();
            response.Data = isExist;
            return response;
        }
        public async Task<ResponseDto<bool>> isUpdatePrescriptionExistorNot(long Id, long MedicineId, long patientd)
        {
            var isExist = false;
            var value = await _context.PatientPrescriptions.Where(x => x.Id != Id && x.MedicationId == MedicineId && x.PatientInfoId == patientd && x.IsActive == true).FirstOrDefaultAsync();
            if (!(value is null))
            {
                isExist = true;
            }
            var response = new ResponseDto<bool>();
            response.Data = isExist;
            return response;
        }
        public async Task<ResponseDto<PrescriptionBasicDto>> prescriptionGetId(int Id)
        {
            var oldEntity = await _context.PatientPrescriptions.FirstOrDefaultAsync(x => x.Id == Id);
            var mapped = _mapper.Map<PatientPrescriptions, PrescriptionBasicDto>(oldEntity);
            var response = new ResponseDto<PrescriptionBasicDto>();
            response.Data = mapped;
            return response;
        }
        public async Task<DMESupplieDto> GetDMESupplyById(int? presId)
        {
            var entity = await _context.DMESupplyEquipment.Where(x => x.DMEEquipSupId == presId).FirstOrDefaultAsync();
            if (!(entity is null))
            {
                var mappedData = _mapper.Map<DMESupplieDto>(entity);
                return mappedData;
            }
            else
            {
                return new DMESupplieDto();
            }
        }

        public async Task<ResponseDto<bool>> prescriptionUpdate(PrescriptionBasicDto patientInfoBasicDto)
        {
            try
            {
                var mapped = _mapper.Map<PrescriptionBasicDto, PatientPrescriptions>(patientInfoBasicDto);
                mapped.IsActive = true;
                mapped.CreatedDate = DateTime.UtcNow;
                var oldEntity = await _context.PatientPrescriptions.FindAsync(mapped.Id);
                _context.Entry(oldEntity).CurrentValues.SetValues(mapped);
                await _context.SaveChangesAsync();
                var response = new ResponseDto<bool>();
                response.Data = true;
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public SelectList GetMedicine()
        {
            var Medicines = _context.Medicines.ToList();
            List<SelectListItem> MedicineList = new List<SelectListItem>();
            foreach (var item in Medicines)
            {
                MedicineList.Add(new SelectListItem { Selected = false, Text = item.Name, Value = item.Id.ToString() });
            }
            return new SelectList(MedicineList, "Value", "Text", null);
        }
        public Medicines GetMedicineById(long? id)
        {
            var Medicines = _context.Medicines.Where(x=> x.Id==id).FirstOrDefault();
            
            return Medicines;
        }
        public async Task<DMESupEquipItemsDto> GetItemGroupById(int? id)
        {
            var item = await _context.DMESupEquipItems.Where(x=> x.DMESupEquipId==id).FirstOrDefaultAsync();
            
                var mappedData = _mapper.Map<DMESupEquipItemsDto>(item);
                return mappedData;
        }

        public async Task<ResponseDto<List<PrescriptionBasicDto>>> prescriptionList(long Id)
        {

            var rec = await _context.PatientPrescriptions.Include(p => p.Medication).Where(x => x.PatientInfoId == Id && x.IsActive == true).OrderByDescending(x => x.Id).ToListAsync();
            var response = new ResponseDto<List<PrescriptionBasicDto>>();
            response.Data = _mapper.Map<List<PatientPrescriptions>, List<PrescriptionBasicDto>>(rec);
            return response;
        }

        public async Task<ResponseDto<List<PrescriptionBasicDto>>> AllprescriptionList()
        {
            var rec = await _context.PatientPrescriptions.Include(p => p.Medication).Where(x => x.IsActive == true && x.VisitId != null).OrderByDescending(x => x.Id).ToListAsync();
            var response = new ResponseDto<List<PrescriptionBasicDto>>();
            response.Data = _mapper.Map<List<PatientPrescriptions>, List<PrescriptionBasicDto>>(rec);
            return response;
        }

        public async Task<ResponseDto<List<PrescriptionBasicDto>>> prescriptionListForVisitsDetail(int Id)
        {
            var rec = await _context.PatientPrescriptions.Include(p => p.Medication).Where(x => x.VisitId == Id && x.IsActive == true).OrderByDescending(x => x.Id).ToListAsync();
            var response = new ResponseDto<List<PrescriptionBasicDto>>();
            response.Data = _mapper.Map<List<PatientPrescriptions>, List<PrescriptionBasicDto>>(rec);
            return response;
        }

        public async Task<List<PrescriptionBasicDto>> prescriptionListByVisits(long Id)
        {
            var joinData = await(from P in _context.PatientAppointments.Where(x => x.PatientInfoId == Id)
                                 join V in _context.Visits
                                 on P.AppointmentId equals V.AppoinmentId

                                 join PP in _context.PatientPrescriptions
                                 on V.VisitId equals PP.VisitId

                                 join M in _context.Medicines
                                 on PP.MedicationId equals M.Id

                                 select new PrescriptionBasicDto
                                 {
                                    Id = PP.Id,
                                     Medication = new Medicines() { Name = M.Name},
                                     Quantity = PP.Quantity,
                                     FrequencyId = PP.FrequencyId,
                                     Dose = PP.Dose,
                                     Unit = PP.Unit,
                                     StartDate = (DateTime)PP.StartDate,
                                     EndDate = (DateTime)PP.EndDate,
                                     Notes = PP.Notes,
                                     VisitId = PP.VisitId

                                 }).ToListAsync();

            return joinData;
        }
    }
}
