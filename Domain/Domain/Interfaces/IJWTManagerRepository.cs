using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IJWTManagerRepository
    {
        Tokens Authenticate(string username,string password);
    }
}
