using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Utilities
{
    public class SenJsonResponse
    {
        public object data{ get; set; } 
        public bool status { get; set; } = true;
        public string message { get; set; }
        public string title { get; set; }
        public string errorMsg { get; set; }
    }
}
