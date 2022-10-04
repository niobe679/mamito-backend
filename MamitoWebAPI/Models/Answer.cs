using System;
using System.Collections.Generic;
using System.Text;

namespace MamitoWebAPI.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public int User_Id { get; set; }
        public int GQ_Id { get; set; }
        public int Choice_Id { get; set; }
        public DateTime Updated_At { get; set; }
        public DateTime Created_At { get; set; }

    }
}
