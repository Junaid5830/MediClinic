using System;
using System.Collections.Generic;
using System.Text;

namespace MedliClinic.Utilities.Utility.Enum
{
    public static class AzureConfigurations
    {
        public static readonly string AZURE_STORAGE_CONNECTION_STRING = "DefaultEndpointsProtocol=https;AccountName=thedocappstorage;AccountKey=CfygfJ6oro9c+brzivD0UQYUD/Gj/rj/U3Ylle4T07nJLWEv1VH1olKXNCZcyJXx+jWf4zJ1xRWrRS3kpCunJg==;EndpointSuffix=core.windows.net";
        public static readonly string AZURE_BLOB_CONTAINER = "mediclinic";
    }
    public static class RoleNames
    {
        public const string Patient = "1";
        public const string Doctor = "2";
        public const string Admin = "4";
        public const string MasterAdmin = "5";
        public const string Manager = "6";
        public const string Supervisor = "7";
        public const string Nurse = "8";
        public const string PIAttorney = "9";
        public const string IndependentContractor = "10";
        public const string CollectionAttorney = "11";
        public const string Biller = "12";
        public const string Assistant = "13";
        public const string Employees = "14";
        public const string EMSAbulance = "15";
        public const string Transportation = "16";
        public const string Receptionist = "17";
        public const string Driver = "21";
    }

    public static class SharedData
    {
        public const string dashes = "-----";
    }

    public static class ConnectionString
    {
        public static readonly string MediClinicApp = "Server=192.185.7.39;Database=techioid_mediC;User Id=techioid_mediC;password=@dmin123; Trusted_Connection=False;MultipleActiveResultSets=true";
    }

    public static class ConnectionString_Stagging
    {
        public static readonly string MediClinicApp = "Server=192.185.7.39;Database=techioid_mediC;User Id=techioid_mediC;password=@dmin123; Trusted_Connection=False;MultipleActiveResultSets=true";
    }

    public static class SessionTimes
    {
        public const string MorningStartTime = "07:00:00";
        public const string MorningEndTime = "12:00:00";
        public const string AfterNoonStartTime = "12:00:00";
        public const string AfterNoonEndTime = "17:00:00";
        public const string EveningStartTime = "17:00:00";
        public const string EveningEndTime = "22:00:00";
    }


    public static class DriverStatusKeys
    {
        public const int Active = 162;
        public const int Offline = 163;
        public const int Idol = 164;
    }

    public static class DriverStatuses
    {
        public const string Active = "Active";
        public const string Offline = "Offline";
        public const string Idol = "Idol";
    }

    public static class DriverRequestStatus
    {
        public const string PickingUp = "0";
        public const string Arrived = "1";
        public const string OnTheWay = "2";
        public const string Finished = "3";
    }
    
    public static class DriverRequestStatusTitles
    {
        public const string PickingUp = "PickingUp";
        public const string Arrived = "Arrived";
        public const string OnTheWay = "OnTheWay";
        public const string Finished = "Finished";
    }
    public static class DriverRequestStatusKeys
    {
        public const string PickingUp = "167";
        public const string Arrived = "169";
        public const string OnTheWay = "170";
        public const string Finished = "171";
    }

    public static class DeviceType
    {
        public const string Android = "1";
        public const string IOS = "2";
    }
    public static class DeviceTypeKeys
    {
        public const string Android = "165";
        public const string IOS = "166";
    }


    public static class ErrorMessages
    {
        public static readonly string AlreadyExist = "Already Exist";
        public static readonly string SessionTimeout = "Session Timeout";
        public static readonly string InvalidEmailPassword = "Invalid Email or password";
        public static readonly string EmailAlreadyExist = "Email Already Exist";
        public static readonly string ProjectWebsiteAlreadyExist = "Website URL Already Exist";
        public static readonly string ProjectAlreadyExist = "Project Name Already Exist";
        public static readonly string UsersInProjectsAlreadyExist = "User In Project Already Exist";
        public static readonly string AccountBlocked = "Currently you are blocked. Please contact with your customer care support.";
    }

    public static class NotificationTitle
    {
        public static readonly string PatientRequest = "NewRequest";
        public static readonly string NotifyAlertForAttendance = "AttendanceAlert";
        public static readonly string Title = "Hey you got a new job request, please open up and accept it";
        public static readonly string AttendanceAlert = "Hey you should check in to MediClinic-EMR";

        public static readonly string ArrivalMessage = "Hey {0}! your ambulance is in your pickup location, driver name is {1} and his phone number is this {2} ";
    }

    public static class NotificationType
    {
        public static readonly string DriverJob = "1";
        public static readonly string AttendanceAlert = "2";
    }

    public static class GenderKeys
    {
        public static readonly string Male = "34";
        public static readonly string Female = "35";
        public static readonly string Other = "36";
    }


    public static class AttendanceKeys
    {
        public const string CheckIn = "172";
        public const string CheckOut = "173";
    }

    public static class AttendanceStatus
    {
        public const string CheckIn = "1";
        public const string CheckOut = "2";
    }

}
