using MediClinic.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.ClinicalReminderInterface
{
    public interface IClinicalReminderService
    {
        public List<ClinicalReminderDto> getlist();
        public bool Add(ClinicalReminderDto clinicalReminderDto);
        public ClinicalReminderDto GetClinicalReminderById(int id);
        public Task<List<ClinicalReminderDto>> ClinicalReminderListbyVists(long Id);
        public bool Delete(int Id);

    }
}
