using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.DTOs.PatientIdandSignatureDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.PatientIdandSignatureInterface
{
    public interface IPatientIdandSignatureService
    {
        public ResponseDto<bool> patientIdandSignature(PatientIdandSignatureBasicDto patientIdandSignatureBasicDto);
        public ResponseDto<bool> patientIdandSignatureUpdate(PatientIdandSignatureBasicDto patientIdandSignatureBasicDto);
        
    }
}
