using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.CustomModel
{
    public partial class CvMain
	{
        public CvMain()
        {
			this.CvExperiences = new HashSet<CvExperience>();
			this.CvQualifications = new HashSet<CV_Qualification>();
			this.CvInternships = new HashSet<CV_InternShip>();
			this.CvSkills = new HashSet<CV_Skills>();
		}
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
		public DateTime? LastUpdateDate { get; set; }
		public int LastUpdateBy { get; set; }
		public int DivisionID { get; set; }

		public string DepartmentName { get; set; }
		public string DesignationName { get; set; }
		public string CategoryName{ get; set; }


		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<CvExperience> CvExperiences { get; set; }
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<CV_Qualification> CvQualifications { get; set; }
		public virtual ICollection<CV_InternShip> CvInternships { get; set; }
		public virtual ICollection<CV_Skills> CvSkills { get; set; }
	}
}
