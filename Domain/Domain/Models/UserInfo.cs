using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Domain.Validations;
namespace Domain.Models
{
    public class UserInfo
    {
        public string Id { get; set; }
        [Required]
        [DOBValidation]
        public DateTime DOB { get; set; }  
        [Required]
        [StringLength(1, ErrorMessage = "Gender length can't be more than 1.")]
        public string Gender { get; set; }
        [Required]
        public string Religion { get; set; }
        public int Email_PinCode { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Education { get; set; }
        [Required]
        public string Employment { get; set; }
        [Required]
        [StringLength(250, ErrorMessage = "Bio length can't be more than 250.")]
        public string Bio { get; set; }
        public DateTime Updated_At { get; set; }
        [Required]
        public DateTime Created_At { get; set; }
    }
}
