using System;
using System.Collections.Generic;
using System.Text;

namespace MamitoWebAPI.Models
{
    public class Catagory
    {
        public int Id { get; set; }
        public string Catagory_Name { get; set; }
        public DateTime Updated_At { get; set; }
        public DateTime Created_At { get; set; }

    }
}
