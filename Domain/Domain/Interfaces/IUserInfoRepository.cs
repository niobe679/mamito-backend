using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IUserInfoRepository : IGenericRepository<UserInfo>
    {
        //public IEnumerable<UserInfo> GetRecentUsers(int count);
    }
}
