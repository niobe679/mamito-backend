using MamitoWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MamitoWebAPI.Services
{
    public class MailService
    {
        private readonly IMailServiceRepository _mailService;
        Response response = new Response();
        public Response SendMail(MailRequest request)
        {
            try
            {
                _mailService.SendEmailAsync(request);
                return response.OK(null);
            }
            catch (Exception ex)
            {
                return response.error(null);
            }

        }

    }
}
