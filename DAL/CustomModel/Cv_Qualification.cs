using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.CustomModel
{
	public partial class CV_Qualification
	{
		public int CV_QID { get; set; }
		public int CVID { get; set; }
		public string QType { get; set; }
		public string Institute { get; set; }
		public string Field { get; set; }
		public int QualificationID { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public string Duration { get; set; }
		public string Grade { get; set; }
		public string Qualification_Name { get; set; }
		public string Degree { get; set; }
		public virtual CvMain CvMain { get; set; }
	}
}
