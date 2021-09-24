using AutoMapper;
using MediClinic.Models.DTOs.PatientExamDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediClinic.Services.Services.PatientExamService
{
    public class PatientExamService : IPatientExamService
    {
        private MediClinicContext _context;
        private IMapper _mapper;
        public PatientExamService(MediClinicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int CreateExamType(PatientExamTypeDto patientExamType)
        {
            if (!(patientExamType.ExamName is null))
            {
                patientExamType.ExamName = patientExamType.ExamName.Trim();
            }
            var mappedData = _mapper.Map<ExamType>(patientExamType);
            _context.ExamType.Add(mappedData);
            _context.SaveChanges();

            return mappedData.ExamTypeId;
        }

        public int CreateExamReason(PatientExamReasonDto patientExamReason)
        {
            if (!(patientExamReason.ReasonName is null))
            {
                patientExamReason.ReasonName = patientExamReason.ReasonName.Trim();
            }
            var mappedData = _mapper.Map<ExamReason>(patientExamReason);
            _context.ExamReason.Add(mappedData);
            _context.SaveChanges();

            return mappedData.ExamReasonId;
        }

        public bool isReasonExistOrNot(string Name)
        {
            var isExist = false;
            var Value = _context.ExamReason.Where(x => x.ReasonName.ToLower() == Name.ToLower()).FirstOrDefault();
            if (!(Value is null))
            {
                isExist = true;
            }
            return isExist;
        }

        public bool isTypeExistOrNot(string Name)
        {
            var isExist = false;
            var Value = _context.ExamType.Where(x => x.ExamName.ToLower() == Name.ToLower()).FirstOrDefault();
            if (!(Value is null))
            {
                isExist = true;
            }
            return isExist;
        }

        public List<PatientExamTypeDto> GetExamTypelist()
        {
            var list = _context.ExamType.ToList();
            if (!(list is null))
            {
                var mappedData = _mapper.Map<List<PatientExamTypeDto>>(list);
                return mappedData;
            }
            else
            {
                return new List<PatientExamTypeDto>();
            }
        }

        public List<PatientExamReasonDto> GetExamReasonlist()
        {
            var list = _context.ExamReason.ToList();
            if (!(list is null))
            {
                var mappedData = _mapper.Map<List<PatientExamReasonDto>>(list);
                return mappedData;
            }
            else
            {
                return new List<PatientExamReasonDto>();
            }
        }
    }
}
