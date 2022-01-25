using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.CustomModel
{
	public class CV_InternShip
	{
		public int CV_IID { get; set; }
		public int CVID { get; set; }
		public string Company { get; set; }
		public string Department { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public string Duration { get; set; }


		public virtual CvMain CvMain { get; set; }
	}
}
