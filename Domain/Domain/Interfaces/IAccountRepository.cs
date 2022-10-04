using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
     public interface IAccountRepository : IGenericRepository<Account>
    {
        public IEnumerable<Account> GetRecentUsers(int count);
    }
}
