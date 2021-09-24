using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.PatientAppointmentsDto;
using MediClinic.Models.DTOs.ProviderInfoDto;
using MediClinic.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.PatientAppointmentInterface
{
    public interface IPatientAppointmentService
    {
        public Task<ResponseDto<bool>> AppointmentCreate(PatientAppointmentBasicDto appointmentBasicDto);
        public Task<ResponseDto<PatientAppointmentBasicDto>> AppointmentUpdate(PatientAppointmentBasicDto appointmentBasicDto);

        public Task<PatientAppointmentBasicDto> AppointmentGetById(int Id);

        public bool AppointmentDeleteById(int Id);

        public bool AppointmentDeleteByRecId(int Id);

        public Task<List<PatientAppointmentBasicDto>> AppointmentList(int? Id);

        public Task<List<PatientAppointmentBasicDto>> AppointmentListByProviderId(int Id);

        public Task<ResponseDto<List<PatientAppointmentBasicDto>>> AppointmentFilterByDocName(int DocId,int PatId);
        public Task<List<PatientAppointmentBasicDto>> AppointmentListForCentral();

        public Task<List<PatientAppointmentBasicDto>> AppointmentCentralByPatient(ICollection<long?> Id);
        public Task<List<PatientAppointmentBasicDto>> AppointmentCentralByDoctor(ICollection<long?> Id);

        public Task<List<PatientAppointmentBasicDto>> AppointmentCentralByDoctorPatient(ICollection<long?> PatId,ICollection<long?> DocId);

        public Task<List<AppointmentQueueDto>> TodayAppointmentQueue(long Id);
        public Task<List<AppointmentQueueDto>> AllTodayAppointmentQueue();

        public Task<bool> CompleteAppointment(long Id);

        public long? GetLatestRecursionNo();

        public Task<ResponseDto<bool>> isExistorNot(DateTime? time);

        public List<PatientAppointments> GetAppointmentDetailByPatientId(long Id);

        public Task<List<AppointmentDetailDto>> AppointmentDetails(int Id);

        public Task<List<ProviderInfoBasicDto>> AvailableProviderListOnDate(DateTime dateTime);

        public Task<List<ProviderSlotsDto>> AvailableSlots(DateTime dateTime, long providerId);
        public Task<List<ProviderSlotsDto>> AvailableSlotsView(long providerId, DateTime date, string dpt);

        public PatientAppointments GetSlotsDetailByIdAndAppointmentSave(long Id, long PatientId,string ActionMethod);

        public Task<List<AppointmentListForReceptionist>> AppointmentListForReceptionlist(DateTime dateTime,long? Id);

        public Task<List<PatientAppointmentBasicDto>> OTAndOPDListForReceptionist(DateTime dateTime);
        public bool AppointmentStatus(long Id, int statusId);

        public bool RescheduleAppointment(long slotId, long AppId);

        public Task<List<PatientAppointmentBasicDto>> OTAppointmentListByProviderId(int Id);
        public Task<List<PatientAppointmentBasicDto>> OPDAppointmentListByProviderId(int Id);

        public  Task<bool> AddVisits(VisitsDto vst);
        public Task<List<VisitsDto>> GetVisitsList(int patientId);

        public long getVisitDetail(int Id);
        public Task<int> GetPatientLatestVisitId(long PaatientId);

        public bool SaveCalendarViewSetting(CalendarSettingDto calendarSettingDto);

        public CalendarSettingDto GetCalendarViewSet();
        public Task<List<AppointmentQueueDto>> AppointmentsForQueue(string date,long? Id);

        public Task<ResponseDto<PatientAppointmentBasicDto>> AppointmentCheck(PatientAppointmentBasicDto patientAppointmentBasicDto);
    }
}
