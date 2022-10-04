using System;
using System.Collections.Generic;
using System.Text;

namespace MamitoWebAPI.Models
{
    public class Message
    {
        public int Id { get; set; }
        public int Sender_Id { get; set; }
        public string Content { get; set; }
        public int Reciever_Id { get; set; }
        public DateTime Updated_At { get; set; }
        public DateTime Created_At { get; set; }

    }
}
