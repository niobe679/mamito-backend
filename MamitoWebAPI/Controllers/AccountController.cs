using Domain.Interfaces;
using Domain.Models;
using MamitoWebAPI.Models;
using MamitoWebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MamitoWebAPI.Controllers
{
    [Route("api/Login")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJWTManagerRepository _jWTManager;
        Response response = new Response();

        public AccountController(IUnitOfWork unitOfWork,IJWTManagerRepository jWTManager)
        {
            _unitOfWork = unitOfWork;
            _jWTManager = jWTManager;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [Route("authenticate")]
        public Tokens Authenticate([FromBody] Credentials user)
        {
            Tokens token = _jWTManager.Authenticate(user.Email, user.Password);

            if (token == null)
            {
                return null;// Unauthorized().StatusCode.ToString();
            }

            return token;// response.OK(token.Token);
        }
        [Authorize]
        [HttpGet]
        [Route("GetUser")]
        public Domain.Models.UserInfo getUserInfo()
        {
            return null;
        }
        //forgot password
        [Authorize]
        [HttpPost]
        [Route("NewPassword")]
        public Response setNewPassword([FromBody] PassCred passCred)
        {
            try
            {
                _unitOfWork.Accounts.Find(x => x.User_Id == passCred.userId).FirstOrDefault().Password = passCred.newPassword;
                return response.OK("new password succesfully set");
            }
            catch (Exception e) {
                return response.error(null);
            }
               // return null;
        }

        //reset password
        [HttpGet]
        [Route("ForgotPassword")]
        public Response forgotPassword([FromBody] string email)
        {
            try
            {
                if (_unitOfWork.Accounts.Find(x => x.Email == email).Count() != 0)
                {
                    NumberGenerator random = new NumberGenerator();
                    MailService send = new MailService();
                    MailRequest mail = new MailRequest();
                    mail.ToEmail = email;
                    mail.Subject = "Mamito Forgot Password Verification";
                    int pincode = random.GenerateRandomNo();
                    mail.Body = pincode.ToString();
                    send.SendMail(mail);
                    _unitOfWork.Accounts.Find(x => x.Email == email).FirstOrDefault().PswrdPinCode = pincode;
                    return response.OK("verification code sent to email");
                }
                else return response.error("email not found");
            }
            catch (Exception e)
            {
                return response.error(null);
            }
            // return null;
        }
        //verify pswrd pimcode
        [HttpPost]
        [Route("VerifyPinCode")]
        public Response verfiyNewUser([FromBody] PinCred pinCred)
        {
            if (_unitOfWork.Accounts.GetById(pinCred.userId).PswrdPinCode == pinCred.pincode)
            {
                return response.OK("verified");
            }
            else return response.error("not verified");
        }
    }
}
