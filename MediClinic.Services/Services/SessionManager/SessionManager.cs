using MediClinic.Models.DTOs.UsersDto;
using MediClinic.Services.Interfaces.SessionManager;
using MedliClinic.Utilities.Utility.Enum;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Services.Services.SessionManager
{
    public class SessionManager : ISessionManager
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISession _session;
        public SessionManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _session = _httpContextAccessor.HttpContext?.Session;
        }
        public long GetUserId()
        {
            return Convert.ToInt64(_session.GetString(SessionNames.UserId));
        }

        public string GetUserName()
        {
            return _session.GetString(SessionNames.UserName);
        }

        public int GetRoleId()
        {
            return Convert.ToInt32(_session.GetString(SessionNames.RoleId));
        }

        public void SetUserId(long userId)
        {
            _session.SetString(SessionNames.UserId, Convert.ToString(userId));
        }

        public void SetUserName(string userName)
        {
            _session.SetString(SessionNames.UserName, userName);
        }

        public void SetPatientUserId(long id)
        {
            _session.SetString(SessionNames.PatientUserId, Convert.ToString(id));
        }
        public int GetPatientUserId()
        {
            return Convert.ToInt32(_session.GetString(SessionNames.PatientUserId));
        }

        public void SetRoleId(int roleId)
        {
            _session.SetString(SessionNames.RoleId, Convert.ToString(roleId));
        }
        public void SetUserSession(UsersBasicDto dto)
        {
            _session.SetString(SessionNames.UserId, Convert.ToString(dto.UserId));
            _session.SetString(SessionNames.UserName, dto.UserName);
            //_session.SetString(SessionNames.TimeZoneId, Convert.ToString(dto.TimeZoneId));
            
        }

        public string GetMediClinicConnectionString()
        {
            if (_session is null)
                //return ConnectionString_Stagging.MediClinicApp;
            return ConnectionString_Stagging.MediClinicApp;
            return ConnectionString_Stagging.MediClinicApp;
        }

        public void SessionClear()
        {
            _session.Clear();
        }

        public void SetTimeZoneId(string timeZoneId)
        {
            _session.SetString(SessionNames.TimeZoneId, timeZoneId);
        }

        public string GetTimeZoneId()
        {
            return _session.GetString(SessionNames.TimeZoneId);
        }

        public string GetOrganization()
        {
            return _session.GetString(SessionNames.Organization);
        }

        public UsersBasicDto GetUser()
        {
            throw new NotImplementedException();
        }

        public long GetPatientInfoId()
        {
            return Convert.ToInt32(_session.GetString(SessionNames.PatientInfotId));
        }

        public void SetPatientInfoId(long Id)
        {
            _session.SetString(SessionNames.PatientInfotId, Convert.ToString(Id));
        }

        public long GetProviderInfoId()
        {
            return Convert.ToInt32(_session.GetString(SessionNames.ProviderInfoId));
        }

        public void SetProviderInfoId(long Id)
        {
            _session.SetString(SessionNames.ProviderInfoId, Convert.ToString(Id));
        }
        public string GetPatientName()
        {
            return _session.GetString(SessionNames.PatientName);
        }
        public void SetPatientName(string Name)
        {
            _session.SetString(SessionNames.PatientName, Name);
        }

        public string GetPatientDOB()
        {
            return _session.GetString(SessionNames.PatientDOB);
        }

        public void SetPatientDOB(DateTime DOB)
        {
            _session.SetString(SessionNames.PatientDOB,Convert.ToString(DOB.ToString("MM/dd/yyyy")));
        }

        public string GetProviderName()
        {
            return _session.GetString(SessionNames.ProviderName);
        }
        public void SetProviderName(string Name)
        {
            _session.SetString(SessionNames.ProviderName, Name);
        }

        public void SetPermisionPage(string Name)
        {
            _session.SetString(SessionNames.PermisionPages, Name);
        }

        public string GetPermisionPage()
        {
            return _session.GetString(SessionNames.PermisionPages);
        }

        public string GetEmployeeName()
        {
            return _session.GetString(SessionNames.EmployeeName);

        }

        public void SetEmployeeName(string Name)
        {
            _session.SetString(SessionNames.EmployeeName, Name);
        }

        public void SetEmployeeId(long Id)
        {
            _session.SetString(SessionNames.EmployeeId, Convert.ToString(Id));
        }

        public long GetEmployeeId()
        {
            return Convert.ToInt32(_session.GetString(SessionNames.EmployeeId));
        }

        public void SetEmployeeEmail(string Name)
        {
            _session.SetString(SessionNames.EmployeeEmail, Name);
        }

        public string GetEmoloyeeEmail()
        {
            return _session.GetString(SessionNames.EmployeeEmail);
        }

        public void SetEmployeeMobNo(string Name)
        {
            _session.SetString(SessionNames.EmployeeMobNo, Name);
        }

        public string GetEmoloyeeMobNo()
        {
            return _session.GetString(SessionNames.EmployeeMobNo);
        }

        public void SetProfilePic(string Name)
        {
            _session.SetString(SessionNames.ProfilePic, Name);
        }

        public string GetPrfilePic()
        {
            return _session.GetString(SessionNames.ProfilePic);
        }

        public void SetVisitId(int VisitId)
        {
            _session.SetString(SessionNames.VisitId,VisitId.ToString());
        }

        public int GetVisitId()
        {
            return Convert.ToInt32(_session.GetString(SessionNames.VisitId));
        }
    }
}
