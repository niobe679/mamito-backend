using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Web.Mvc;

namespace MamitoWebAPI.Models
{
   public class Account
    {
        public String Id { get; set; }
        public int User_Id { get; set; }
        [Required(ErrorMessage = "New Password is required.")]
        [Remote("VerifyNewPassword", "Account", ErrorMessage = "Error")]
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
       
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }

        public int PswrdPinCode { get; set; }
        public DateTime Last_Login { get; set; }
        public DateTime Updated_At { get; set; }
        public DateTime Created_At { get; set; }
    }
}
