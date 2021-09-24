using AutoMapper;
using Dapper;
using MediClinic.Models.DTOs;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.UserRolePageInterface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClinic.Services.Services.UserRolePageService
{
    public class UserRolePageService : IUserRolePageService
    {
        private MediClinicContext _context;
        private IMapper _mapper;

        public UserRolePageService(MediClinicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<UserRolePagesBasicDto>> pageListOnUserRoleId(int Id)
        {
            try
            {
                using (var conn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
                {
                    var result = await conn.QueryAsync<UserRolePagesBasicDto>(sql: "[spGetPagesOnUserRoleId]", param: new { UserRoleId = Id },
                    commandType: CommandType.StoredProcedure);
                    StringBuilder stringBuilder = new StringBuilder();
                    foreach (var rec in result)
                    {
                        if (!(rec.SubMenuRole is null))
                        {
                            foreach (var item in rec.SubMenuRole)
                            {
                                stringBuilder.Append(item);
                            }
                        }
                        else
                        {
                            string name = null;
                            stringBuilder.Append(name);

                        }
                        rec.SubRolePage = JsonConvert.DeserializeObject<List<SubRolePage>>(Convert.ToString(stringBuilder));
                        stringBuilder.Length = 0;
                        stringBuilder.Capacity = 0;

                    }


                    return result.ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            

        }

        public async Task<List<UserRolePagesBasicDto>> PagesList()
        {
            //var Rec = await _context.MainMenuPages.ToListAsync();

            using (var conn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                var result = await conn.QueryAsync<string>(sql: "[spGetAllPageList]",
                commandType: CommandType.StoredProcedure);
                StringBuilder stringBuilder = new StringBuilder();
                foreach (var rec in result)
                {
                    stringBuilder.Append(rec);
                }
                return JsonConvert.DeserializeObject<List<UserRolePagesBasicDto>>(Convert.ToString(stringBuilder));
            }
            //return _mapper.Map<List<MainMenuPages>, List<UserRolePagesBasicDto>>(Rec); ;

        }
        public bool AdduserRolePage(int PageId, int RoleId)
        {
            UserRolePages userRolePages = new UserRolePages();
            
            userRolePages.MainMenuId = PageId;
            userRolePages.UserRoleId = RoleId;
            var data = _context.UserRolePages.Add(userRolePages);
            if (!(data is null))
            {
                _context.SaveChangesAsync();

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteuserRolePage(int PageId, int RoleId)
        {
            var Rec = _context.UserRolePages.FirstOrDefault(x => x.MainMenuId == PageId && x.UserRoleId == RoleId);
            if (!(Rec is null))
            {
                _context.Remove(Rec);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool PageActive(int Id)
        {
            var Rec = _context.MainMenuPages.FirstOrDefault(x => x.MainMenuId == Id);
            if (!(Rec is null))
            {
                Rec.IsActive = true;
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool PageInActive(int Id)
        {
            var Rec = _context.MainMenuPages.FirstOrDefault(x => x.MainMenuId == Id);
            if (!(Rec is null))
            {
                Rec.IsActive = false;
                 _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<string> GetSideBarList(int Id)
        {
            using (var conn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                var result = await conn.QueryAsync<string>(sql: "[spGetSidebarList]", param: new { UserRoleId = Id },
                commandType: CommandType.StoredProcedure);
                StringBuilder stringBuilder = new StringBuilder();
                foreach (var rec in result)
                {
                    stringBuilder.Append(rec);
                }
                return stringBuilder.ToString();
            }
        }
    }
}
