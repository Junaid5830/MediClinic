using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.ClinicalNotesDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.ClinicalNotesInterface
{
    public interface IClinicalNoteInterface
    {
        public List<ClinicalNoteDto> GetClinicalNoteList(long patientId);
        public Task<List<ClinicalNoteDto>> ClinicalNoteListByVisit(long Id);
        public bool CreateClinicalNote(ClinicalNoteDto clinicalNotelist);
        public bool UpdateClinicalNote(ClinicalNoteDto clinicalNotelist);
        public bool DeleteClinicalNotes(int clinicalNoteId);
        public ClinicalNoteDto GetClinicalNoteById(int clinicalId);
        public Task<bool> SignedNote(int clinicalNoteId);
        public Task<bool> IsPasswordMatched(string electronicPassword, long providerId);
        Task<List<ICDDto>> GetAllICDCodes(bool withDetail);

        public int CreateHistoryOfIllness(HistoryOfillnessDto historydto);
        public int CreateROS(ClincalROSDto rOSDto);
        public bool UpdateROS(ClincalROSDto rOSDto);
        public bool UpdateHistoryOfIllness(HistoryOfillnessDto historyOfillnessDto);
    }
}
