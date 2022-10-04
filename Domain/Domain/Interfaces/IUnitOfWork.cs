using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IAccountRepository Accounts { get; }
        public IUserInfoRepository Users { get; }
        int Complete();
    }
}
