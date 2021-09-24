
using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.PatientAppointmentsDto;
using MediClinic.Models.DTOs.PatientInfoDto;
using MediClinic.Models.DTOs.PatientInfoListDto;
using MediClinic.Models.DTOs.PrescriptionDto;
using MediClinic.Models.DTOs.ProviderInfoDto;
using MediClinic.Models.DTOs.VitalBasicDto;
using MediClinic.Models.EntityModels;
using System;
using System.Collections.Generic;

namespace MediClinic.Models
{
    public class AppointmentViewModel
    {
        public PatientAppointmentBasicDto patientAppointmentBasicDto { get; set; }
        public List<PatientAppointmentBasicDto> patientAppointmentBasicsList { get; set; }
        public PatientInfoListDto patientCompleteInfo { get; set; }

        public RecurringAppoinmentDto RecurringAppoinmentDto { get; set; }
        public List<RecurringAppoinmentDto> RecurringList { get; set; }

        public List<ProviderInfoBasicDto> ProviderList { get; set; }

        public PatientInfoBasicDto Patient { get; set; }
        public List<PatientInfoBasicDto> PatientList { get; set; }

        public List<PatientInfoListDto> patientListWithUsers { get; set; }

        public List<AppointmentQueueDto> AppointmentQueue { get; set; }
        public List<ProviderSessionTypeDto> ProviderSessionTypeList { get; set; }
        public List<ProviderWorkHrsDto> ScheduleList { get; set; }

        public ProviderSlotsDto Slots { get; set; }
        public List<ProviderSlotsDto> SlotsList { get; set; }

        public List<AppointmentListForReceptionist> AppoinmentListforRecep { get; set; }
        public List<PrescriptionBasicDto> prescriptionBasicsList { get; set; }

        public List<VitalDto> Vitallist { get; set; }
        public List<ImmunizationBasicDto> Listimmunization { get; set; }

        public List<TemplateForPatientViewDto> TemplateList { get; set; }
        public List<VisitsDto> visitsDtosList { get; set; }
        public List<GrowthChartDto> growthChartList { get; set; }
        public List<LabDto> getLabList { get; set; }
        public List<ImagingDto> getImagingDto { get; set; }
        public List<DMESupplyEquipment> DMEVisitList { get; set; }
        public List<InvoicesDto> invoicesList { get; set; }

        public List<TestsDto> TestsDtoList { get; set; }
        public List<AllergyDto> AlergyList { get; set; }
        public List<AllergyTypeDto> AlergyTypeList { get; set; }

        public List<MessagesDto> receiveMessages { get; set; }

        public CalendarSettingDto calendarSettingDto { get; set; }
        public UserEventsDto UserEvents { get; set; }

    }
}
