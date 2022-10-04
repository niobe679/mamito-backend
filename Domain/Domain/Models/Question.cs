using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models
{
    public class Question
    {
        public int Id { get; set; }
        [Required]
        public int Catagory_Id { get; set; }
        [Required]
        public string Question_Content { get; set; }
        public DateTime Updated_At { get; set; }
        [Required]
        public DateTime Created_At { get; set; }

    }
}
