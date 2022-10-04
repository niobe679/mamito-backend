using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models
{
    public class Catagory
    {
        public int Id { get; set; }
        [Required]
        public string Catagory_Name { get; set; }
        public DateTime Updated_At { get; set; }
        [Required]
        public DateTime Created_At { get; set; }

    }
}
