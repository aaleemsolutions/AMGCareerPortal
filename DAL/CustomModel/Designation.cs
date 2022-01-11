using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.CustomModel
{
   public class Designation
    {

		public int Designation_ID { get; set; }
		public int? GradeID { get; set; }
		public string Designation_Code { get; set; }
		public string Designation_Name { get; set; }
		public int? PreDefSalary { get; set; }
		public int? PreDefAttnAllow { get; set; }
		public int? PreDefSpclAllow { get; set; }
		public bool? isActive { get; set; }
		public bool? AllowIncentive { get; set; }
		public decimal IncentiveRate { get; set; }
		public decimal BaseRate { get; set; }
		public decimal MinEff { get; set; }
		public decimal MaxEff { get; set; }
		public decimal Increment { get; set; }
		public decimal BaseRateDHU { get; set; }
		public decimal MinEffDHU { get; set; }
		public decimal MaxEffDHU { get; set; }
		public decimal IncrementDHU { get; set; }

		 
	}
}
