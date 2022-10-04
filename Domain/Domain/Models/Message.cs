using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models
{
    public class Message
    {
        public int Id { get; set; }
        [Required]
        public int Sender_Id { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public int Reciever_Id { get; set; }
        public DateTime Updated_At { get; set; }
        [Required]
        public DateTime Created_At { get; set; }

    }
}
