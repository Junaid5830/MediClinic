using MediClinic.Models.DTOs.PatientExamDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Services.Interfaces
{
    public interface IPatientExamService
    {
        public int CreateExamType(PatientExamTypeDto patientExamType);
        public int CreateExamReason(PatientExamReasonDto patientExamReason);
        public bool isReasonExistOrNot(string Name);
        public bool isTypeExistOrNot(string Name);
        public List<PatientExamReasonDto> GetExamReasonlist();
        public List<PatientExamTypeDto> GetExamTypelist();


    }
}
