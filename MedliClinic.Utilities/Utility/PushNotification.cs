using MediClinic.Models.DTOs;
using MedliClinic.Utilities.Utility.Enum;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MedliClinic.Utilities.Utility
{
    public static class PushNotification
    {
        public static PushResponseDto Send(string deviceId, int deviceTypeId, dynamic message, string title, string senderName = null)
        {
            string applicationID = PushNotificationConfiguration.firebaseServerKey;
            string senderId = PushNotificationConfiguration.firebaseSenderId;
            WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
            tRequest.Method = "post";
            tRequest.ContentType = "application/json";
            var json = "";
            dynamic notificationData;
            if (senderName is null)
            {
                notificationData = new
                {
                    body = message,
                    title = "MediClinic-EMR",
                    type = 1,
                    badge = 1
                };
            }
            else
            {
                notificationData = new
                {
                    body = message,
                    title = "MediClinic-EMR",
                    badge = 1,
                    type = 1,
                    sendername = senderName
                };
            }
            
            var payload = new
            {
                to = deviceId,
                priority = "high",
                content_available = true,
                notification = notificationData,
                data = new
                {
                    body = message,
                    title = "MediClinic-EMR",
                    type = 1
                }
            };
            json = JsonConvert.SerializeObject(payload).ToString();

            Byte[] byteArray = Encoding.UTF8.GetBytes(json);
            tRequest.Headers.Add(string.Format("Authorization: key={0}", applicationID));
            tRequest.Headers.Add(string.Format("Sender: id={0}", senderId));
            tRequest.ContentLength = byteArray.Length;
            string str = "";
            using (Stream dataStream = tRequest.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
                using (WebResponse tResponse = tRequest.GetResponse())
                {
                    using (Stream dataStreamResponse = tResponse.GetResponseStream())
                    {
                        using (StreamReader tReader = new StreamReader(dataStreamResponse))
                        {
                            String sResponseFromServer = tReader.ReadToEnd();
                            str = sResponseFromServer;
                        }
                    }
                }
            }
            return new PushResponseDto() { RequestString = json, Status = str };
        }


        public static PushResponseDto SendToMultiple(List<string> deviceId, dynamic message, string title, int type, string senderName = null)
        {
            string applicationID = PushNotificationConfiguration.firebaseServerKey;
            string senderId = PushNotificationConfiguration.firebaseSenderId;
            WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
            tRequest.Method = "post";
            tRequest.ContentType = "application/json";
            var json = "";
            dynamic notificationData;
            if (senderName is null)
            {
                notificationData = new
                {
                    body = message,
                    title = "MediClinic-EMR",
                    type = type,
                    badge = 1
                };
            }
            else
            {
                notificationData = new
                {
                    body = message,
                    title = "MediClinic-EMR",
                    badge = 1,
                    type = type,
                    sendername = senderName
                };
            }

            var payload = new
            {
                registration_ids = deviceId,
                priority = "high",
                content_available = true,
                notification = notificationData,
                data = new
                {
                    body = message,
                    title = "MediClinic-EMR",
                    type = type
                }
            };
            json = JsonConvert.SerializeObject(payload).ToString();

            Byte[] byteArray = Encoding.UTF8.GetBytes(json);
            tRequest.Headers.Add(string.Format("Authorization: key={0}", applicationID));
            tRequest.Headers.Add(string.Format("Sender: id={0}", senderId));
            tRequest.ContentLength = byteArray.Length;
            string str = "";
            using (Stream dataStream = tRequest.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
                using (WebResponse tResponse = tRequest.GetResponse())
                {
                    using (Stream dataStreamResponse = tResponse.GetResponseStream())
                    {
                        using (StreamReader tReader = new StreamReader(dataStreamResponse))
                        {
                            String sResponseFromServer = tReader.ReadToEnd();
                            str = sResponseFromServer;
                        }
                    }
                }
            }
            return new PushResponseDto() { RequestString = json, Status = str };
        }
    }
}
