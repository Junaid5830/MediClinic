using MediClinic.Models.DTOs.EmailDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.IO;
using MediClinic.Models.DTOs.SMSDto;
using MedliClinic.Utilities.Utility.Enum;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace MedliClinic.Utilities.Utility
{
    public static class CommonMethod
    {
        public static bool SendEmail(EmailBasicDto emailDto)
        {
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage
            {
                From = new System.Net.Mail.MailAddress("info@imedhealth.us")
            };
            System.Net.Mail.SmtpClient client;
            System.Net.NetworkCredential credentials;
            credentials = new System.Net.NetworkCredential();
            credentials = new System.Net.NetworkCredential("info@imedhealth.us", "infoimedtracker");

            client = new System.Net.Mail.SmtpClient
            {
                DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                EnableSsl = true,
                //client.Host = "smtp-mail.outlook.com";
                Host = "smtp.gmail.com",
                //Host = "smtp.sendgrid.net",

                Port = 587
            };
            client.UseDefaultCredentials = false;
            client.Credentials = credentials;

            if (emailDto.ToEmails is null)
            {
                return false;
            }

            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            mail.To.Add(new System.Net.Mail.MailAddress(emailDto.ToEmails));
            if (!(emailDto.attachmentFilename is null))
            {            
                string fileName = Path.GetFileName(emailDto.attachmentFilename.FileName);
                mail.Attachments.Add(new Attachment(emailDto.attachmentFilename.OpenReadStream(), fileName));
            }
            
            mail.Subject = emailDto.Subject;
            mail.IsBodyHtml = true;
            mail.Body = emailDto.Body;
            client.Send(mail);

            return true;
        }
        public static bool VerificationEmail(string email,long Id)
        {
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage
            {
                From = new System.Net.Mail.MailAddress("info@imedhealth.us")
            };
            System.Net.Mail.SmtpClient client;
            System.Net.NetworkCredential credentials;
            credentials = new System.Net.NetworkCredential();
            credentials = new System.Net.NetworkCredential("info@imedhealth.us", "infoimedtracker");

            client = new System.Net.Mail.SmtpClient
            {
                DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                EnableSsl = true,
                //client.Host = "smtp-mail.outlook.com";
                Host = "smtp.gmail.com",
                //Host = "smtp.sendgrid.net",

                Port = 587
            };
            client.UseDefaultCredentials = false;
            client.Credentials = credentials;

            if (email is null)
            {
                return false;
            }

            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            mail.To.Add(new System.Net.Mail.MailAddress(email));

            mail.Subject = "Welcone to Mediclinic";
            mail.IsBodyHtml = true;
            mail.Body = "https://mediclinicapp.azurewebsites.net/patientwidget/PatientInfoAdd/" + Id;
            client.Send(mail);

            return true;
        }

        public static bool SendSms(SmsDto smsDto)
        {
            try
            {
                TwilioClient.Init(SMSCredentials.testAccountSid2, SMSCredentials.testAuthToken2);

                var message = MessageResource.Create(
                    body: smsDto.TextMsg,
                    from: new Twilio.Types.PhoneNumber(SMSCredentials.senderPhoneNo2),
                    to: new Twilio.Types.PhoneNumber(smsDto.PhoneNo)
                );
                
                var msg = message.Sid;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static string SendVerificationCodeToPhoneNo(string PhoneNo,int code)
        {
            try
            {
                string accountSid = "ACb2edb42faa5c4ad252d82a400c3a6d5b";
                string authToken = "2e4ad8c7cec3802ff47ea3b74eecacc6";
                 var msg = "Your Verification Code is " + code;

                TwilioClient.Init(accountSid, authToken);
                var message = MessageResource.Create(
                body: msg,
                from: "MediClinic",
                to: new Twilio.Types.PhoneNumber("+"+ PhoneNo)
                );

                return message.Sid;
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        public static string SendMessageToPhoneNo(SmsDto smsDto)
        {
            try
            {
                string accountSid = "AC0ae8668e9ea1299074c9501356882464";
                string authToken = "e2f7adc17c76e3ce92d96aa0561a906e";
                //var msg = "Your Verification Code is " + code;

                TwilioClient.Init(accountSid, authToken);
                var message = MessageResource.Create(
                body: smsDto.TextMsg,
                from: "MediClinic",
                to: new Twilio.Types.PhoneNumber("+" + smsDto.PhoneNo)
                );

                return message.Sid;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public static string SendVerificationCodeForAppointment(string PhoneNo)
        {
            try
            {
                string accountSid = "ACb2edb42faa5c4ad252d82a400c3a6d5b";
                string authToken = "2e4ad8c7cec3802ff47ea3b74eecacc6";
                var msg = "Your Appointment has been booked";

                TwilioClient.Init(accountSid, authToken);
                var message = MessageResource.Create(
                body: msg,
                from: "MediClinic",
                to: new Twilio.Types.PhoneNumber("+" + PhoneNo)
                );

                return message.Sid;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public static bool SendVerificationCodeToEmail(string email, int code)
        {
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage
            {
                From = new System.Net.Mail.MailAddress("info@imedhealth.us")
            };
            System.Net.Mail.SmtpClient client;
            System.Net.NetworkCredential credentials;
            credentials = new System.Net.NetworkCredential();
            credentials = new System.Net.NetworkCredential("info@imedhealth.us", "infoimedtracker");

            client = new System.Net.Mail.SmtpClient
            {
                DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                EnableSsl = true,
                //client.Host = "smtp-mail.outlook.com";
                Host = "smtp.gmail.com",
                //Host = "smtp.sendgrid.net",

                Port = 587
            };
            client.UseDefaultCredentials = false;
            client.Credentials = credentials;

            if (email is null)
            {
                return false;
            }

            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;


            mail.To.Add(new System.Net.Mail.MailAddress(email));

            mail.Subject = "Mediclinic Verification";
            mail.IsBodyHtml = true;
            mail.Body = "Your Verifcation Code is " + code;
            client.Send(mail);


            return true;
        }
        public static bool EmployeeVerificationEmail(string email, long Id)
        {
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage
            {
                From = new System.Net.Mail.MailAddress("info@imedhealth.us")
            };
            System.Net.Mail.SmtpClient client;
            System.Net.NetworkCredential credentials;
            credentials = new System.Net.NetworkCredential();
            credentials = new System.Net.NetworkCredential("info@imedhealth.us", "infoimedtracker");

            client = new System.Net.Mail.SmtpClient
            {
                DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                EnableSsl = true,
                //client.Host = "smtp-mail.outlook.com";
                Host = "smtp.gmail.com",
                //Host = "smtp.sendgrid.net",

                Port = 587
            };
            client.UseDefaultCredentials = false;
            client.Credentials = credentials;

            if (email is null)
            {
                return false;
            }

            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;


            mail.To.Add(new System.Net.Mail.MailAddress(email));

            //if (!(emailDto.CCEmails is null))
            //{
            //    foreach (var emailCC in emailDto.CCEmails)
            //    {
            //        mail.CC.Add(new System.Net.Mail.MailAddress(emailCC));
            //    }
            //}

            //if (!(emailDto.attachmentFilename is null))
            //{
            //    string fileName = Path.GetFileName(emailDto.attachmentFilename.FileName);
            //    mail.Attachments.Add(new Attachment(emailDto.attachmentFilename.OpenReadStream(), fileName));
            //}
            //else
            //{

            //}
            mail.Subject = "Welcone to Mediclinic";
            mail.IsBodyHtml = true;
            mail.Body = "https://mediclinicapp.azurewebsites.net/patientwidget/EmployeeWidget/" + Id;
            client.Send(mail);


            return true;
        }

    }
}
