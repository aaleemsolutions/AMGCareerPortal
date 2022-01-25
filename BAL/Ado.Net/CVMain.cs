using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Ado.Net
{
	public class CVMain
	{
		public int CVID { get; set; }
		public int CategoryID { get; set; }
		public int DepartmentID { get; set; }
		public int DesignationID { get; set; }
		public string CandidateName { get; set; }
		public string FatherHusbandName { get; set; }
		public string Relation { get; set; }
		public int ReligionID { get; set; }
		public string Gender { get; set; }
		public string MaritalStatus { get; set; }
		public string Nationality { get; set; }
		public string FamilyCode { get; set; }
		public string CNIC { get; set; }
		public DateTime CNICExpire { get; set; }
		public DateTime DOB { get; set; }
		public string Phone { get; set; }
		public string Mobile { get; set; }
		public string Email { get; set; }
		public string CurrentAddress { get; set; }
		public string PermenantAddress { get; set; }
		public int DisabilityID { get; set; }
		public DateTime LastUpdateDate { get; set; }
		public int LastUpdateBy { get; set; }
		public int DivisionID { get; set; }
	}
}
