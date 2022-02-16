using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.CustomModel
{
    public class EmployeeView
    {
		public int CustomTbId { get; set; }
		public string DB { get; set; }
		public int EmployeeID { get; set; }
		public string EmployeeCode { get; set; }
		public string EmployeenameWithCode { get; set; }
		public string EmployeeName { get; set; }
		public int GradeID { get; set; }
		public DateTime DateOfJoining { get; set; }
		public DateTime DateOfBirth { get; set; }
		public string Address { get; set; }
		public int Salary { get; set; }
		public int OffPayroll { get; set; }
		public int SpecialAllowManagement { get; set; }
		public int SpclAllowance { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public string Mobile { get; set; }
		public string MeritalStatus { get; set; }
		public string NIC { get; set; }
		public DateTime CNICExpire { get; set; }
		public string Relation { get; set; }
		public string FatherName { get; set; }
		public string Gender { get; set; }
		public string Qualification_Name { get; set; }
		public string ReligionName { get; set; }
		public string AccountNo { get; set; }
		public string BankName { get; set; }
		public string ConveyanceDesc { get; set; }
		public string Nationality { get; set; }
		public string Division { get; set; }
		public int CompanyID { get; set; }
		public string CompanyName { get; set; }
		public int Department_ID { get; set; }
		public string Department_Name { get; set; }
		public int Designation_ID { get; set; }
		public string Designation_Name { get; set; }
		public string BranchName { get; set; }
		public int BranchID { get; set; }
		public int ReportToEmployeeID { get; set; }
		public int DottedLineReportTo { get; set; }
		public string SolidLineDB { get; set; }
		public string DottedLineDB { get; set; }
		public string EOBINo { get; set; }
		public DateTime EOBIDate { get; set; }
		public string SESSINo { get; set; }
		public DateTime SESSIDate { get; set; }
		public DateTime OriginalDOJ { get; set; }
	}
}
