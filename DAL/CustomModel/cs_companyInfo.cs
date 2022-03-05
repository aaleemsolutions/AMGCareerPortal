using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.CustomModel
{
    public class cs_companyInfo
    {
        public int CompanyID { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public string ReportName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Web { get; set; }
        public bool isActive { get; set; }
        public string UCompanyName { get; set; }
        public string UCompanyAddress { get; set; }
        public int MaximumStrength { get; set; }
        public string SMTPServer { get; set; }
        public string SMTPUser { get; set; }
        public string SMTPPassword { get; set; }
        public string AttendanceTable { get; set; }
    }

    public class CS_Branch
    {
        public int BranchID { get; set; }
        public int CompanyID { get; set; }
        public string BranchCode { get; set; }
        public string EmpPostCode { get; set; }
        public string BranchType { get; set; }
        public string BranchName { get; set; }
        public string BranchDivision { get; set; }
        public string CardName { get; set; }
        public string BranchAddress { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string UBranchName { get; set; }
        public string UBranchAddress { get; set; }
        public string RegCode { get; set; }
        public string SubCode { get; set; }
        public bool isActive { get; set; }
        public int MaximumStrength { get; set; }
        public string ReportName { get; set; }
        public int VendorID { get; set; }
        public int ApprovalAuthority { get; set; }
    }
}
