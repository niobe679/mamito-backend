using Domain.Interfaces;
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
    [Route("api/Register")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserInfoRepository _userInfoRepository;
        private readonly IMailServiceRepository _mailService;
        Response response = new Response();
        public UserInfoController(IUnitOfWork unitOfWork, IMailServiceRepository mailService)
        {
            _mailService = mailService;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route("Add1")]
        public void Add()
        {
            Console.WriteLine("dfv");
        }
            //register user
        [HttpPost]
        [Route("Add")]
        public Response AddUser([FromBody] UserInfo user)
        {
            //UserInfo user = new UserInfo();
            if (!ModelState.IsValid)
            {
                return response.BadRequest(null);
            }
            MailService send = new MailService();
            MailRequest mail = new MailRequest();
            mail.ToEmail = user.Email;
            mail.Subject = "Mamito Verification";
            int pincode = GenerateRandomNo();
            mail.Body = pincode.ToString();
            send.SendMail(mail);


            Domain.Models.Account account = new Domain.Models.Account();
            string userId = Guid.NewGuid().ToString();
            string accountId = Guid.NewGuid().ToString();
            account.Id = accountId;
            account.User_Id = userId;
            account.Email = user.Email;
            account.First_Name = user.FirstName;
            account.Last_Name = user.LastName;
            account.Password = user.Password;
            account.Last_Login = new DateTime();
            account.Created_At = new DateTime();
            account.verified = false;
            Domain.Models.UserInfo userInfo = new Domain.Models.UserInfo();
            userInfo.Id = userId;
            userInfo.DOB = user.DOB;
            userInfo.Gender = user.Gender;
            userInfo.Religion = user.Religion;
            userInfo.Address = user.Address;
            userInfo.Education = user.Education;
            userInfo.Employment = user.Employment;
            userInfo.Bio = user.Bio;
            userInfo.Email_PinCode = pincode;


            _unitOfWork.Users.Add(userInfo);
            _unitOfWork.Complete();
            _unitOfWork.Accounts.Add(account);
            _unitOfWork.Complete();

            return response.OK(null);

        }
        //email verification
        [HttpPost]
        [Route("VerifyPinCode")]
        public Response verfiyNewUser([FromBody] PinCred pinCred) {
            if (_unitOfWork.Users.GetById(pinCred.userId).Email_PinCode == pinCred.pincode)
            {
                _unitOfWork.Accounts.Find(x => x.User_Id == pinCred.userId).FirstOrDefault().verified = true;
                return response.OK("verified");
            }
            else return response.error("not verified");
        }

        //get users
        [Authorize]
        [HttpGet]
        [Route("/GetUsers")]
        public List<Domain.Models.UserInfo> getUsers()
        {
            return (_unitOfWork.Users.GetAll()).ToList();
        }
        //get user info by id
        [Authorize]
        [HttpGet]
        [Route("/GetUser/{id}")]
        public Domain.Models.UserInfo getUserInfo(int id) {
            return (_unitOfWork.Users.GetById(id));
        }
        //delete user
        [Authorize]
        [HttpDelete]
        [Route("/DeleteUser/{id}")]
        public Response deletetUserInfo(int id)
        {
            try { 
                _unitOfWork.Users.Remove(_unitOfWork.Users.GetById(id));
                return response.OK("user sucessfully removed!");
            }
            catch (Exception e) {
                return response.error(e.Message);
            }
        }
       
        public async Task<IActionResult> SendMail( MailRequest request)
        {
            try
            {
                await _mailService.SendEmailAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        [HttpPost]
        public bool /*void*/ VerifyNewUser(string firstName, string lastName, string email)
        {
            try
            {
                return (EmailExists(email));
            }
            catch (Exception e) {

                return false;
            }
        }

        private bool UserExists(string firstName, string lastName)
        {
            if ((_unitOfWork.Accounts.Find(x => x.First_Name == firstName && x.Last_Name == lastName)).Count() == 0)
            {
                return false;
            }
            else return true;
        }

        private bool EmailExists(string email)
        {
            if ((_unitOfWork.Accounts.Find(x => x.Email == email)).Count() == 0)
            {
                return false;
            }
            else return true;
        }
        public int GenerateRandomNo()
        {
            int _min = 1000;
            int _max = 9999;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max);
        }
    }
}
