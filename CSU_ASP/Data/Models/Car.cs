using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSU_ASP.Data.Models
{
    public class Car
    {
        public int id { get; set; }

        public string name { get; set; }

        public string shortDesc { get; set; }

        public string lonDesc { get; set; }
        
        public string img { get; set; }

        public int price { get; set; }

        public bool isFavourite { get; set; }

        public bool available { get; set; }

        public int categoryID { get; set; }

        public virtual Category Category { get; set; }
    }
}
