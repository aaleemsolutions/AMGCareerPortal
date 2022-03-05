using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.CustomModel
{
    public class EmployeeHiringClass
    {
        public int EmployeeID { get; set; }
        public int TrialID { get; set; }
        public string EmployeeCode { get; set; }
        public string CardNo { get; set; }
        public string EmployeeName { get; set; }
        public string Relation { get; set; }
        public string FatherName { get; set; }
        public int? GradeID { get; set; }
        public int Designation_ID { get; set; }
        public int Department_ID { get; set; }
        public int SectionID { get; set; }
        public int? UnitID { get; set; }
        public int SubDeptID { get; set; }
        public int BranchID { get; set; }
        public int CompanyID { get; set; }
        public int BusRouteID { get; set; }
        public int EmployeeGroupID { get; set; }
        public string NIC { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string Gender { get; set; }
        public string MeritalStatus { get; set; }
        public int Qualification { get; set; }
        public int ReligionID { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfJoining { get; set; }
        public DateTime cDateOfJoining { get; set; }
        public DateTime ConfirmDate { get; set; }
        public DateTime OriginalDOJ { get; set; }
        public DateTime? DateLeft { get; set; }
        public bool isBlackListed { get; set; }
        public string Reference1 { get; set; }
        public string Ref1Phone { get; set; }
        public string Reference2 { get; set; }
        public string Ref2Phone { get; set; }
        public int EmployeeTypeID { get; set; }
        public int? Salary { get; set; }
        public string PayMode { get; set; }
        public int? BankID { get; set; }
        public string AccountNo { get; set; }
        public int? ConveyanceID { get; set; }
        public string OTType { get; set; }
        public int? AttAllowance { get; set; }
        public int? SpclAllowance { get; set; }
        //public int? SkillID { get; set; }
        public int? SimAllowanceID { get; set; }
        public string EOBINo { get; set; }
        public DateTime? EOBIDate { get; set; }
        public string SESSINo { get; set; }
        public DateTime? SESSIDate { get; set; }
        public int? TaxNo { get; set; }
        public int ShiftID { get; set; }
        public int? OffDayID { get; set; }
        public bool isOnJob { get; set; }
        public int? UserID { get; set; }
        public DateTime? EntryDate { get; set; }
        public bool AllowLateComming { get; set; }
        public byte[] EmployeePic { get; set; }
        public int ReportToEmployeeID { get; set; }
        public int PhysicalDisablityID { get; set; }
        public bool NoPayroll { get; set; }
        public bool NoAttendance { get; set; }
        public string FamilyCode { get; set; }
        public string MotherName { get; set; }
        public DateTime? CNICExpire { get; set; }
        public bool AllowGazDay { get; set; }
        public int? OffPayroll { get; set; }
        public int? SpecialAllowanceManagement { get; set; }
        public string Nationality { get; set; }
        public bool NadraDeduction { get; set; }
        public string Passport { get; set; }
        public string NTN { get; set; }
        //public EmployeeExperience Experience1 { get; set; }
        //public EmployeeExperience Experience2 { get; set; }
        //public EmployeeReference Reference { get; set; }
        //public EmployeeCriminalRecord CriminalRecord { get; set; }
        public int? ReplaceOf { get; set; }
        public int SubSectionID { get; set; }
        public int OTMinLimitNormal { get; set; }
        public int OTMinLimitOffday { get; set; }
        public int OTMinLimitGazday { get; set; }
        public bool ChangeOTLimit { get; set; }
        public string BloodGroup { get; set; }
        public bool IsColonyResident { get; set; }
        public bool FingerPrintStatus { get; set; }
        public byte[] FingerPrint { get; set; }
        public string PersonalEmail { get; set; }
        public string ICENumber { get; set; }
        public int? LanguageID { get; set; }
        public string OfficialMobile { get; set; }
        public string WhatsappNo { get; set; }
        public string Facebook { get; set; }
        public string LinkedIn { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }
        public bool EnableGarmentAttendance { get; set; }
        public double? TaxAdjustment { get; set; }
        public int? DottedlineReportedTo { get; set; }
        public bool SolidLineReportToRemoteDB { get; set; }
        public bool DottedLineReportToRemoteDB { get; set; }
    }
}
