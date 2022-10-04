using System;
using System.Collections.Generic;
using System.Text;

namespace MamitoWebAPI.Models
{
    public class Question
    {
        public int Id { get; set; }
        public int Catagory_Id { get; set; }
        public string Question_Content { get; set; }
        public DateTime Updated_At { get; set; }
        public DateTime Created_At { get; set; }

    }
}
