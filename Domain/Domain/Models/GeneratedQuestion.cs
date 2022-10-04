using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models
{
    public class GeneratedQuestion
    {
        public int Id { get; set; }
        [Required]
        public int Question_Id { get; set; }
        [Required]
        public int Choice_Id_One { get; set; }
        [Required]
        public int Choice_Id_Two { get; set; }
        public DateTime Updated_At { get; set; }
        [Required]
        public DateTime Created_At { get; set; }

    }
}
