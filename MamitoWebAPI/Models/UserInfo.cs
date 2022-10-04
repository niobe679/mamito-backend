using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Domain.Validations;
using System.Web.Mvc;

namespace MamitoWebAPI.Models
{
    public class UserInfo
    {
        /*        public int Id { get; set; }*/
        /*[DOBValidation]*/
        public DateTime DOB { get; set; }
        [Required]
        [StringLength(1, ErrorMessage = "Gender length can't be more than 1.")]
        public string Gender { get; set; }
        [Required]
        public string Religion { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Education { get; set; }
        [Required]
        public string Employment { get; set; }
        [Required]
        [StringLength(250, ErrorMessage = "Bio length can't be more than 250.")]
      //account part joint
        public string Bio { get; set; }
        [Required(ErrorMessage = "New Password is required.")]
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [EmailAddress]
/*        [Remote("VerifyNewUser", "UserInfo", HttpMethod = "POST", ErrorMessage = "Error")]*/
        public string Email { get; set; }
        public string Password { get; set; }
/*        public DateTime Last_Login { get; set; }*/
/*        public DateTime Updated_At { get; set; }
        public DateTime Created_At { get; set; }*/

    }
}
