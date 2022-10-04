using System;
using System.Collections.Generic;
using System.Text;

namespace MamitoWebAPI.Models
{
    public class GeneratedQuestion
    {
        public int Id { get; set; }
        public int Question_Id { get; set; }
        public int Choice_Id_One { get; set; }
        public int Choice_Id_Two { get; set; }
        public DateTime Updated_At { get; set; }
        public DateTime Created_At { get; set; }

    }
}
