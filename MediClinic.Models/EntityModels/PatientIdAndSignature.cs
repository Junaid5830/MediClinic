using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class PatientIdAndSignature
    {
        public long PatientSignatureId { get; set; }
        public string PassportNumber { get; set; }
        public int? TypeId { get; set; }
        public string IdNumber { get; set; }
        public long UserId { get; set; }
        public string ElectronicSignature { get; set; }
        public string WriteSignature { get; set; }
        public bool IsSMSNotified { get; set; }
        public bool IsEmailNotified { get; set; }
        public bool IsFaceRecognition { get; set; }
        public bool IsBiometricRecognition { get; set; }
        public bool IsComunicationSMS { get; set; }
        public bool IsComunicationPhone { get; set; }
        public bool IsComunicationEmail { get; set; }
        public string PaitentImage { get; set; }
        public string SignatureImage { get; set; }
        public string IdFrontPictureUrl { get; set; }
        public string IdBackPictureUrl { get; set; }

        public virtual PatientSignatureIdType Type { get; set; }
        public virtual Users User { get; set; }
    }
}
