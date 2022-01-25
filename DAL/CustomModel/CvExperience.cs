using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.CustomModel
{
   public class CvExperience
    {
	 
			public int CV_EID { get; set; }
			public int CVID { get; set; }
			public string Company { get; set; }
			public string Department { get; set; }
			public string Designation { get; set; }
			public DateTime StartDate { get; set; }
			public DateTime EndDate { get; set; }
			public int LastSalary { get; set; }
			public string JobDuration { get; set; }
			public string LeavingReason { get; set; }

		public virtual CvMain CvMain { get; set; }

	}
}
