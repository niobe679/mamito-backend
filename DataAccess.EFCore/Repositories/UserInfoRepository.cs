using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.EFCore.Repositories
{
    public class UserInfoRepository : GenericRepository<UserInfo>, IUserInfoRepository
    {
        public UserInfoRepository(ApplicationContext context) : base(context)
        {
        }
       /* public IEnumerable<UserInfo> GetRecentUsers(int count)
        {
            return _context.UserInfo.OrderByDescending(d => d.Last_Login).Take(count).ToList();
        }*/
    }
}
