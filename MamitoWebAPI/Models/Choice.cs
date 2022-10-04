using System;
using System.Collections.Generic;
using System.Text;

namespace MamitoWebAPI.Models
{
    public class Choice
    {
        public int Id { get; set; }
        public int Catagory_Id { get; set; }
        public string Choice_Name { get; set; }
        public DateTime Updated_At { get; set; }
        public DateTime Created_At { get; set; }

    }
}
