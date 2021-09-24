using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Web;

namespace MediClinic.Models.DTOs.PatientIdandSignatureDto
{
    public class PatientIdandSignatureBasicDto
    {
        public long PatientSignatureId { get; set; }
        
        public string PassportNumber { get; set; }
        public int? TypeId { get; set; }
        public string IdNumber { get; set; }
        public long UserId { get; set; }
        [Required]
        [DataType(DataType.Password)]       
        [Display(Name = "Password")]
        [RegularExpression(@"(?=^.{8,}$)(?=.*\d)(?=.*[!@#$%^&*]+)(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$", ErrorMessage = "Enter minimum 8 character (at least one uppercase and one lowercase) and number or punctuation marks (such as ! and &).")]

        public string ElectronicSignature { get; set; }
        [Required]
        [Display(Name = "Electronic Signature")]

        [Compare("ElectronicSignature")]
        public string ConfirmElectronicSignature { get; set; }
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
        public IFormFile FrontPicture{ get; set; }
        public IFormFile BackPicture { get; set; }

        public string HiddenimagePath { get; set; }

        public string HiddenSignImg { get; set; }

        public string HidddentWriteSigniamge { get; set; }
    }
}
