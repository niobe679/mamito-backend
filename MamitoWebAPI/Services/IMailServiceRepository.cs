using MamitoWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MamitoWebAPI.Services
{
    public interface IMailServiceRepository
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
