using MediClinic.Models.DTOs.UsersDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediClinic.Services.Interfaces.SessionManager
{
    public interface ISessionManager
    {
        public void SetUserId(long userId);
        public void SetUserName(string userName);
        public void SetTimeZoneId(string timeZoneId);
        public void SetRoleId(int roleId);
        public void SetVisitId(int VisitId);
        public int GetVisitId();
        public string GetTimeZoneId();
        public long GetUserId();
        public string GetUserName();
        public int GetRoleId();
        public UsersBasicDto GetUser();
        public void SetUserSession(UsersBasicDto dto);
        public void SessionClear();
        public string GetMediClinicConnectionString();
        public void SetPatientUserId(long id);
        public int GetPatientUserId();

        public long GetPatientInfoId();

        public void SetPatientInfoId(long Id);
        public void SetProviderInfoId(long Id);
        public long GetProviderInfoId();
        public string GetPatientName();
        public void SetPatientName(string Name);

        public string GetPatientDOB();
        public void SetPatientDOB(DateTime DOB);

        public string GetProviderName();
        public void SetProviderName(string Name);

        public void SetPermisionPage(string Name);
        public string GetPermisionPage();

        public string GetEmployeeName();
        public void SetEmployeeName(string Name);

        public void SetEmployeeId(long Id);
        public long GetEmployeeId();

        public void SetEmployeeEmail(string Name);
        public string GetEmoloyeeEmail();
        public void SetEmployeeMobNo(string Name);
        public string GetEmoloyeeMobNo();

        public void SetProfilePic(string Name);
        public string GetPrfilePic();
    }
}
