using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.CustomModel
{
	public class CV_Skills
	{
		public int CV_SID { get; set; }
		public int CVID { get; set; }
		public string Field { get; set; }
		public string SkillDesc { get; set; }


		public virtual CvMain CvMain { get; set; }
	}
}
