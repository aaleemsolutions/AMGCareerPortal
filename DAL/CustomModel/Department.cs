using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.CustomModel
{
    public class Department
    {

        public int Department_ID { get; set; }
        public int CostCenterID { get; set; }
        public string Department_Code { get; set; }
        public string Department_Name { get; set; }
        public string ManualCode { get; set; }
        public string Department_Color { get; set; }
        public long MaxStrength { get; set; }
        public bool isActive { get; set; }
        public bool AllowIncentive { get; set; }
        public int ExpenseGroupID { get; set; }






    }
}
