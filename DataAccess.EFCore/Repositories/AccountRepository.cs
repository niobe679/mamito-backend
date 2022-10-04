using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.EFCore.Repositories
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        public AccountRepository(ApplicationContext context) : base(context)
        {
        }
        public IEnumerable<Account> GetRecentUsers(int count)
        {
            return _context.Accounts.OrderByDescending(d => d.Last_Login).Take(count).ToList();
        }
    }
}
