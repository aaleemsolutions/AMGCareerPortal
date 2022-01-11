using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.CustomModel
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryDesc { get; set; }

        public bool Active { get; set; }
    }
}
