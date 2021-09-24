using System;
using System.Collections.Generic;

namespace MediClinic.Models.EntityModels
{
    public partial class SettingAttorney
    {
        public int AttorneyId { get; set; }
        public string FirmName { get; set; }
        public string TypeOFAttorney { get; set; }
        public string FirmAssociatedAttorney { get; set; }
        public string FirmAssociatedParalegal { get; set; }
        public string FirmAssociatedCaseManager { get; set; }
        public string FirmAssociatedCaseSecretries { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public string AuthenticationCode { get; set; }
        public string AuthorizedReferClient { get; set; }
        public string AuthorizedOtherRecord { get; set; }
        public string AuthorizedViewRecord { get; set; }
        public string AuthorizedEditProfile { get; set; }
        public bool AuthorizedSendMessage { get; set; }
        public string MedicalRecordFee { get; set; }
        public string Status { get; set; }
        public bool FaceIdRecognization { get; set; }
        public bool BioMetricRecognization { get; set; }
        public string AttornyPhoto { get; set; }
        public string AttornySignature { get; set; }
        public string Balance { get; set; }
    }
}
