using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Web.Mvc;

namespace Domain.Models
{
   public class Account
    {
        public string Id { get; set; }
        [Required]
        public string User_Id { get; set; }
        /* [Required(ErrorMessage = "New Password is required.")]
         [Remote("VerifyNewPassword", "Account", ErrorMessage = "Error")]*/
        [Required]
        public string First_Name { get; set; }
        [Required]
        public string Last_Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public bool verified { get; set; }
        public int PswrdPinCode { get; set; }
        public DateTime Last_Login { get; set; }
        public DateTime Updated_At { get; set; }
        [Required]
        public DateTime Created_At { get; set; }
    }
}
