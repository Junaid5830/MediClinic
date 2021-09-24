using MediClinic.Models.DTOs;
using MediClinic.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Interfaces.UserRolePageInterface
{
    public interface IUserRolePageService
    {
        public Task<List<UserRolePagesBasicDto>> PagesList();

        public Task<List<UserRolePagesBasicDto>> pageListOnUserRoleId(int Id);

        public bool PageActive(int Id);
        public bool PageInActive(int Id);

        public bool AdduserRolePage(int PageId, int RoleId);

        public bool DeleteuserRolePage(int PageId, int RoleId);

        public Task<string> GetSideBarList(int Id);


    }
}
