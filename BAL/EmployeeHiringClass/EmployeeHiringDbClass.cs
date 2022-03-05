using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.CustomModel;

namespace BAL.EmployeeHiringClass
{
    public class EmployeeHiringDbClass
    {


        public int Employee_Add(DAL.CustomModel.EmployeeHiringClass emp, int UserId, string connectionstrong = "")
        {

            int NewEmpCode = 0;

            SqlConnection conc = new SqlConnection(connectionstrong);
            SqlCommand cmd = new SqlCommand("Employee_SP", conc);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.AddWithValue("@SolidLineRemoteDB", emp.SolidLineReportToRemoteDB);
                cmd.Parameters.AddWithValue("@DottedLineRemoteDB", emp.DottedLineReportToRemoteDB);
                cmd.Parameters.AddWithValue("@EmployeeID", emp.EmployeeID);
                cmd.Parameters.AddWithValue("@EmployeeCode", emp.EmployeeCode);
                cmd.Parameters.AddWithValue("@CardNo", emp.CardNo);
                cmd.Parameters.AddWithValue("@EmployeeName", emp.EmployeeName);
                cmd.Parameters.AddWithValue("@Relation", emp.Relation);
                cmd.Parameters.AddWithValue("@FatherName", emp.FatherName);
                cmd.Parameters.AddWithValue("@GradeID", emp.GradeID);
                cmd.Parameters.AddWithValue("@Designation_ID", emp.Designation_ID);
                cmd.Parameters.AddWithValue("@Department_ID", emp.Department_ID);
                cmd.Parameters.AddWithValue("@SectionID", emp.SectionID);
                cmd.Parameters.AddWithValue("@UnitID", emp.UnitID);
//                cmd.Parameters.AddWithValue("@SubDeptID", emp.SubDeptID);
                cmd.Parameters.AddWithValue("@BranchID", emp.BranchID);
                cmd.Parameters.AddWithValue("@CompanyID", emp.CompanyID);
                cmd.Parameters.AddWithValue("@EmployeeGroupID", emp.EmployeeGroupID);
                //cmd.Parameters.AddWithValue("@EnableGarmentAttendance", emp.EnableGarmentAttendance);
                cmd.Parameters.AddWithValue("@NIC", emp.NIC);
                cmd.Parameters.AddWithValue("@Phone", emp.Phone);
                cmd.Parameters.AddWithValue("@Mobile", emp.Mobile);
                cmd.Parameters.AddWithValue("@Address", emp.Address);
                cmd.Parameters.AddWithValue("@Address2", emp.Address2);
                cmd.Parameters.AddWithValue("@Gender", emp.Gender);
                cmd.Parameters.AddWithValue("@MeritalStatus", emp.MeritalStatus);
                cmd.Parameters.AddWithValue("@Qualification", emp.Qualification);
                cmd.Parameters.AddWithValue("@ReligionID", emp.ReligionID);
                cmd.Parameters.AddWithValue("@DateOfBirth", emp.DateOfBirth);
                cmd.Parameters.AddWithValue("@DateOfJoining", emp.DateOfJoining);
                cmd.Parameters.AddWithValue("@cDateOfJoining", emp.DateOfJoining);
                cmd.Parameters.AddWithValue("@ConfirmDate", emp.ConfirmDate);
                cmd.Parameters.AddWithValue("@Reference1", emp.Reference1);
                cmd.Parameters.AddWithValue("@Ref1Phone", emp.Ref1Phone);
                cmd.Parameters.AddWithValue("@Reference2", emp.Reference2);
                cmd.Parameters.AddWithValue("@Ref2Phone", emp.Ref2Phone);
                cmd.Parameters.AddWithValue("@EmployeeTypeID", emp.EmployeeTypeID);
                cmd.Parameters.AddWithValue("@Salary", emp.Salary);
                cmd.Parameters.AddWithValue("@PayMode", emp.PayMode);
                cmd.Parameters.AddWithValue("@BankID", emp.BankID);
                cmd.Parameters.AddWithValue("@AccountNo", emp.AccountNo);
                cmd.Parameters.AddWithValue("@ConveyanceID", emp.ConveyanceID);
                cmd.Parameters.AddWithValue("@OTType", emp.OTType);
                cmd.Parameters.AddWithValue("@AttAllowance", emp.AttAllowance);
                cmd.Parameters.AddWithValue("@SpclAllowance", emp.SpclAllowance);
                cmd.Parameters.AddWithValue("@SpecialAllowanceManagement", emp.SpecialAllowanceManagement);
                cmd.Parameters.AddWithValue("@OffPayroll", emp.OffPayroll);
                cmd.Parameters.AddWithValue("@SkillID", emp.SimAllowanceID);
                cmd.Parameters.AddWithValue("@EOBINo", emp.EOBINo);
                cmd.Parameters.AddWithValue("@EOBIDate", emp.EOBIDate);
                cmd.Parameters.AddWithValue("@SESSINo", emp.SESSINo);
                cmd.Parameters.AddWithValue("@SESSIDate", emp.SESSIDate);
                cmd.Parameters.AddWithValue("@TaxNo", emp.TaxNo);
                cmd.Parameters.AddWithValue("@ShiftID", emp.ShiftID);
                cmd.Parameters.AddWithValue("@OffDayID", emp.OffDayID);
                cmd.Parameters.AddWithValue("@isOnJob", emp.isOnJob);
                cmd.Parameters.AddWithValue("@UserID", UserId);
                cmd.Parameters.AddWithValue("@AllowLateComming", emp.AllowLateComming);
                cmd.Parameters.AddWithValue("@ReportToEmployeeID", emp.ReportToEmployeeID);
                cmd.Parameters.AddWithValue("@DisabilityID", emp.PhysicalDisablityID);
                cmd.Parameters.AddWithValue("@NoPayroll", emp.NoPayroll);
                cmd.Parameters.AddWithValue("@NoAttendance", emp.NoAttendance);
                cmd.Parameters.AddWithValue("@EmployeePic", emp.EmployeePic);
                cmd.Parameters.AddWithValue("@FamilyCode", emp.FamilyCode);
                cmd.Parameters.AddWithValue("@MotherName", emp.MotherName);
                cmd.Parameters.AddWithValue("@CNICExpire", emp.CNICExpire);
                cmd.Parameters.AddWithValue("@Nationality", emp.Nationality);
                cmd.Parameters.AddWithValue("@Email", emp.Email);
                cmd.Parameters.AddWithValue("@TrialID", emp.TrialID);
                cmd.Parameters.AddWithValue("@NTN", emp.NTN);
                cmd.Parameters.AddWithValue("@Passport", emp.Passport);
                cmd.Parameters.AddWithValue("@ReplaceOf", emp.ReplaceOf);
                //cmd.Parameters.AddWithValue("@SubSectionID", emp.SubSectionID);
                cmd.Parameters.AddWithValue("@RoutID", emp.BusRouteID);
                //cmd.Parameters.AddWithValue("@ChangeOTLimit", emp.ChangeOTLimit);
               // cmd.Parameters.AddWithValue("@OTMinLimitNormal", emp.OTMinLimitNormal);
               // cmd.Parameters.AddWithValue("@OTMinLimitOffday", emp.OTMinLimitOffday);
                //cmd.Parameters.AddWithValue("@OTMinLimitGazday", emp.OTMinLimitGazday);
                cmd.Parameters.AddWithValue("@NadraDeduction", emp.NadraDeduction);
                //cmd.Parameters.AddWithValue("@BloodGroup", emp.BloodGroup);
                //cmd.Parameters.AddWithValue("@isColonyResident", emp.IsColonyResident);
                cmd.Parameters.AddWithValue("@Facebook", emp.Facebook);
                cmd.Parameters.AddWithValue("@LinkedIn", emp.LinkedIn);
                cmd.Parameters.AddWithValue("@Twitter", emp.Twitter);
                cmd.Parameters.AddWithValue("@Instagram", emp.Instagram);
             //   cmd.Parameters.AddWithValue("@WhatsappNo", emp.WhatsappNo);
                //cmd.Parameters.AddWithValue("@OfficialMobile", emp.OfficialMobile);
          //      cmd.Parameters.AddWithValue("@LanguageID", emp.LanguageID);
                //cmd.Parameters.AddWithValue("@ICENumber", emp.ICENumber);
                cmd.Parameters.AddWithValue("@PersonalEmail", emp.PersonalEmail);
                //cmd.Parameters.AddWithValue("@TaxAdjustment", emp.TaxAdjustment);
                cmd.Parameters.AddWithValue("@DottedLineReportTo", emp.DottedlineReportedTo);
                cmd.Parameters.AddWithValue("@nType", 1);
                cmd.Parameters.AddWithValue("@IsCareerPortal", true);
                SqlParameter NewID = cmd.Parameters.Add("@NewCode", SqlDbType.BigInt);
                NewID.Direction = ParameterDirection.Output;
                //NewID.Size = 50;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                
                
                  NewEmpCode = Convert.ToInt32(cmd.Parameters["@NewCode"].Value);
                if (2 == 1)
                {
                  //  msg.Description = "Unable to save. Please contact system administrator.";
                //msg.isError = true;
                }
                else
                {
                    //if (emp.Experience1 != null)
                    //{
                    //    emp.Experience1.EmployeeID = Convert.ToInt32(cmd.Parameters["@NewCode"].Value);
                    //    //EmployeeExperience_Update(emp.Experience1);
                    //}
                    //if (emp.Experience2 != null)
                    //{
                    //    emp.Experience2.EmployeeID = Convert.ToInt32(cmd.Parameters["@NewCode"].Value);
                    //    EmployeeExperience_Update(emp.Experience2);
                    //}
                    //if (emp.Reference != null)
                    //{
                    //    emp.Reference.EmployeeID = Convert.ToInt32(cmd.Parameters["@NewCode"].Value);
                    ////    EmployeeReference_Update(emp.Reference);
                    //}
                    //if (emp.CriminalRecord != null)
                    //{
                    //    emp.CriminalRecord.EmployeeID = Convert.ToInt32(cmd.Parameters["@NewCode"].Value);
                    //  //  EmployeeCriminalRecord_Update(emp.CriminalRecord);
                    //}
                }
                //msg = new Messages(Convert.ToInt32(cmd.Parameters["@NewCode"].Value), "Record Created with Following ID" + "\n" + cmd.Parameters["@NewCode"].Value.ToString(), "", false);
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                conc.Dispose();
                cmd.Dispose();
            }
            return NewEmpCode;
        }

        //private void SaveRecord()
        //{
        //    byte[] pic = null;
        //    //if (picEmployee.Image != null)
        //    //    pic = sbsCore.ImageClass.ImageToByteArray(picEmployee.Image);
        //    //else { pic = null; }
        //    //if (cmbBusRoute.SelectedValue == null)
        //    //    cmbBusRoute.SelectedValue = 0;

        //    DAL.CustomModel.EmployeeHiringClass emp = new DAL.CustomModel.EmployeeHiringClass();
        //    emp.EmployeeID = empid;
        //    emp.TrialID = this.TrialID;
        //    emp.EmployeeCode = txtEmployeeCode.Text.Trim();
        //    emp.CardNo = txtCardNo.Text.Trim();
        //    emp.EmployeeName = txtName.Text;
        //    emp.Relation = cmbRelation.Text;
        //    emp.FatherName = sbsCore.General.NVL_string(txtFatherName.Text);
        //    emp.GradeID = Convert.ToInt32(cmbGrade.SelectedValue);
        //    emp.Designation_ID = (int)cmbDesignation.SelectedValue;
        //    emp.Department_ID = (int)cmbDepartment.SelectedValue;
        //    emp.SectionID = (int)cmbSection.SelectedValue;
        //    emp.SubSectionID = (int)cmbSubSection.SelectedValue;
        //    emp.UnitID = Convert.ToInt32(cmbUnit.SelectedValue);
        //    emp.PersonalEmail = sbsCore.General.NVL_string(txtPersonalEmail.Text);
        //    emp.ICENumber = sbsCore.General.NVL_string(txtICENumber.Text);
        //    if (Convert.ToInt32(cmbNativeLang.SelectedValue ?? 0) > 0)
        //        emp.LanguageID = sbsCore.General.NVL_int(cmbNativeLang.SelectedValue.ToString());
        //    else
        //        emp.LanguageID = null;
        //    emp.OfficialMobile = sbsCore.General.NVL_string(mskOfficialMob.Text);
        //    emp.WhatsappNo = sbsCore.General.NVL_string(mskWhatsappNo.Text);
        //    emp.LinkedIn = sbsCore.General.NVL_string(txtLinkedIn.Text);
        //    emp.Twitter = sbsCore.General.NVL_string(txtTwitter.Text);
        //    emp.Instagram = sbsCore.General.NVL_string(txtInstagram.Text);
        //    emp.EnableGarmentAttendance = Convert.ToBoolean(tglEnableGarmentAttendance.Value);
        //    if (txttaxAdjustment.Text.Trim() == "")
        //        emp.TaxAdjustment = null;
        //    else
        //        emp.TaxAdjustment = Convert.ToDouble(txttaxAdjustment.Text);
        //    if (DottedLineID > 0)
        //    {
        //        emp.DottedlineReportedTo = DottedLineID;
        //        emp.DottedLineReportToRemoteDB = DottedLineRemoteDB;
        //    }
        //    else
        //    {
        //        emp.DottedlineReportedTo = null;
        //        emp.DottedLineReportToRemoteDB = false;
        //    }
        //    if (ReportToID > 0)
        //    {
        //        emp.ReportToEmployeeID = ReportToID;
        //        emp.SolidLineReportToRemoteDB = SolidLineRemoteDB;
        //    }
        //    else
        //    {
        //        emp.ReportToEmployeeID = 0;
        //        emp.SolidLineReportToRemoteDB = SolidLineRemoteDB;
        //    }
        //    if (cmbBloodGroup.SelectedIndex > 0)
        //    {
        //        if (cmbBloodGroup.SelectedIndex == 1)
        //            emp.BloodGroup = "A positive (A+)";
        //        else if (cmbBloodGroup.SelectedIndex == 2)
        //            emp.BloodGroup = "A negative (A-)";
        //        else if (cmbBloodGroup.SelectedIndex == 3)
        //            emp.BloodGroup = "B positive (B+)";
        //        else if (cmbBloodGroup.SelectedIndex == 4)
        //            emp.BloodGroup = "B negative (B-)";
        //        else if (cmbBloodGroup.SelectedIndex == 5)
        //            emp.BloodGroup = "O positive (O+)";
        //        else if (cmbBloodGroup.SelectedIndex == 6)
        //            emp.BloodGroup = "O negative (O-)";
        //        else if (cmbBloodGroup.SelectedIndex == 7)
        //            emp.BloodGroup = "AB positive (AB+)";
        //        else if (cmbBloodGroup.SelectedIndex == 8)
        //            emp.BloodGroup = "AB negative (AB+)";
        //    }
        //    else
        //        emp.BloodGroup = null;


        //    emp.IsColonyResident = tglYesBtn.Value;


        //    if ((int)cmbSubDept.SelectedValue > 0)
        //        emp.SubDeptID = (int)cmbSubDept.SelectedValue;
        //    else
        //        emp.SubDeptID = 0;
        //    emp.BusRouteID = (int)cmbBusRoute.SelectedValue;
        //    emp.BranchID = sbsCore.LoginInfo.BranchID;
        //    emp.CompanyID = sbsCore.LoginInfo.CompanyID;
        //    emp.EmployeeGroupID = (int)cmbEmployeeGroup.SelectedValue;
        //    emp.NIC = sbsCore.General.NVL_string(mskCNIC.Text);
        //    if (mskNTN.Text == "_______-_")
        //        emp.NTN = null;
        //    else
        //        emp.NTN = mskNTN.Text;
        //    if (txtPassport.Text.Trim() == "")
        //        emp.Passport = null;
        //    else
        //        emp.Passport = txtPassport.Text.Trim();
        //    emp.Phone = sbsCore.General.NVL_string(mskPhone.Text);
        //    emp.Mobile = sbsCore.General.NVL_string(mskMobile.Text);
        //    emp.Email = sbsCore.General.NVL_string(txtEmail.Text);
        //    emp.Address = sbsCore.General.NVL_string(txtAddress.Text);
        //    emp.Address2 = sbsCore.General.NVL_string(txtAddress2.Text);
        //    emp.Gender = cmbGender.Text;
        //    emp.MeritalStatus = cmbMaritalStatus.Text;
        //    emp.Qualification = (int)cmbQualification.SelectedValue;
        //    emp.ReligionID = (int)cmbReligion.SelectedValue;
        //    emp.DateOfBirth = dtDOB.Value.Date;
        //    emp.DateOfJoining = dtDOJ.Value.Date;
        //    emp.cDateOfJoining = dtcDOJ.Value.Date;
        //    emp.PersonalEmail = sbsCore.General.NVL_string(txtPersonalEmail.Text);
        //    emp.ICENumber = sbsCore.General.NVL_string(txtICENumber.Text);
        //    emp.OfficialMobile = sbsCore.General.NVL_string(mskOfficialMob.Text);
        //    emp.WhatsappNo = sbsCore.General.NVL_string(mskWhatsappNo.Text);
        //    emp.LinkedIn = sbsCore.General.NVL_string(txtLinkedIn.Text);
        //    emp.Twitter = sbsCore.General.NVL_string(txtTwitter.Text);
        //    emp.Instagram = sbsCore.General.NVL_string(txtInstagram.Text);
        //    emp.Facebook = sbsCore.General.NVL_string(txtFacebook.Text);

        //    if (Convert.ToInt32(cmbNativeLang.SelectedValue ?? 0) > 0)
        //        emp.LanguageID = sbsCore.General.NVL_int(cmbNativeLang.SelectedValue.ToString());
        //    else
        //        emp.LanguageID = null;


        //    //emp.cDateOfJoining = cDOJ.Date;
        //    emp.ConfirmDate = dtDOC.Value.Date;
        //    emp.Reference1 = sbsCore.General.NVL_string(txtRef1Name.Text);
        //    emp.Ref1Phone = sbsCore.General.NVL_string(txtRef1Phone.Text);
        //    emp.Reference2 = sbsCore.General.NVL_string(txtRef2Name.Text);
        //    emp.Ref2Phone = sbsCore.General.NVL_string(txtRef2Phone.Text);
        //    emp.EmployeeTypeID = (int)cmbEmployeeType.SelectedValue;
        //    emp.Salary = sbsCore.General.NVL_int(txtSalary.Text);
        //    emp.SpecialAllowanceManagement = sbsCore.General.NVL_int(txtSpclAllowMgm.Text);
        //    emp.OffPayroll = sbsCore.General.NVL_int(txtOffPayroll.Text);
        //    emp.PayMode = cmbPayMode.Text;
        //    if (sbsCore.bParam.OTLimit)
        //    {
        //        if (isFound)
        //        {
        //            if (mskOTLimitNormal.Value.ToString() == txtOTLimitNormal.Text && mskOTLimitOffday.Value.ToString() == txtOTLimitOffday.Text && mskOTLimitGazday.Value.ToString() == txtOTLimitGazday.Text)
        //            {
        //                emp.ChangeOTLimit = false;
        //            }
        //            else
        //            {
        //                emp.ChangeOTLimit = true;
        //                emp.OTMinLimitNormal = sbsCore.General.TimeToMin(mskOTLimitNormal.Value.ToString());
        //                emp.OTMinLimitOffday = sbsCore.General.TimeToMin(mskOTLimitOffday.Value.ToString());
        //                emp.OTMinLimitGazday = sbsCore.General.TimeToMin(mskOTLimitGazday.Value.ToString());
        //            }
        //        }
        //        else
        //        {
        //            emp.ChangeOTLimit = true;
        //            emp.OTMinLimitNormal = sbsCore.General.TimeToMin(mskOTLimitNormal.Value.ToString());
        //            emp.OTMinLimitOffday = sbsCore.General.TimeToMin(mskOTLimitOffday.Value.ToString());
        //            emp.OTMinLimitGazday = sbsCore.General.TimeToMin(mskOTLimitGazday.Value.ToString());
        //        }
        //    }
        //    else
        //    {
        //        emp.ChangeOTLimit = false;
        //    }
        //    if (!tglNewEmployee.Value)
        //    {
        //        emp.ReplaceOf = eInfoReplace.EmployeeID;
        //    }
        //    else
        //    {
        //        emp.ReplaceOf = null;
        //    }
        //    emp.BankID = (int)cmbBank.SelectedValue;
        //    if (emp.BankID == 0)
        //    {
        //        emp.BankID = null;
        //        emp.AccountNo = null;
        //    }
        //    else
        //    {
        //        emp.AccountNo = sbsCore.General.NVL_string(txtAccountNo.Text);
        //    }
        //    emp.Nationality = cmbNationality.Text.Trim();
        //    emp.ConveyanceID = (int)cmbConveyance.SelectedValue;
        //    emp.OTType = cmbOTType.Text;
        //    emp.SimAllowanceID = (int)cmbSimAllow.SelectedValue;
        //    emp.AttAllowance = sbsCore.General.NVL_int(txtAttnAllow.Text);
        //    emp.SpclAllowance = sbsCore.General.NVL_int(txtSpclAllow.Text);
        //    emp.EOBINo = sbsCore.General.NVL_string(txtEOBINo.Text);
        //    emp.EOBIDate = dtEOBIDate.Value.Date;
        //    if (dtEOBIDate.Value.Date == dtEOBIDate.NullDate) emp.EOBIDate = null; else emp.EOBIDate = dtEOBIDate.Value.Date;
        //    emp.SESSINo = sbsCore.General.NVL_string(txtSESSINo.Text);
        //    if (dtSESSIDate.Value.Date == dtSESSIDate.NullDate) emp.SESSIDate = null; else emp.SESSIDate = dtSESSIDate.Value.Date;
        //    emp.TaxNo = Convert.ToInt32(cmbCPLOTHours.Text.Trim());
        //    emp.ShiftID = Convert.ToInt32(cmbShift.SelectedValue);
        //    emp.OffDayID = Convert.ToInt32(cmbOffDay.SelectedValue);
        //    emp.isOnJob = true;
        //    emp.AllowLateComming = tglAllowLateComing.Value;
        //    //emp.NoAttendance = chkNoAttendance.Checked;
        //    emp.NoAttendance = Convert.ToBoolean(tglNoAttendance.Value);
        //    emp.NoPayroll = tglNoPayroll.Value;
        //    emp.PhysicalDisablityID = (int)cmbDisability.SelectedValue;
        //    emp.EmployeePic = pic;
        //    if (txtFamilyCode.Text.Trim() != "")
        //        emp.FamilyCode = txtFamilyCode.Text.Trim();
        //    else
        //        emp.FamilyCode = null;
        //    if (txtMotherName.Text.Trim() != "")
        //        emp.MotherName = txtMotherName.Text.Trim();
        //    else
        //        emp.MotherName = null;
        //    emp.CNICExpire = dtCNICExpire.Value.Date;
        //    emp.UserID = sbsCore.LoginInfo.UserID;
        //    emp.EntryDate = DateTime.Now;
        //    if (txtExpCmp1.Tag != null)
        //    {
        //        emp.Experience1 = new EmployeeExperience();
        //        emp.Experience1.EmployeeID = emp.EmployeeID;
        //        emp.Experience1.ExpID = (int)txtExpCmp1.Tag;
        //        if (txtExpCmp1.Text.Trim() == "")
        //        {
        //            emp.Experience1.iDel = true;
        //        }
        //        else
        //        {
        //            emp.Experience1.iDel = false;
        //            if (txtExpDept1.Text.Trim() == "")
        //                emp.Experience1.Department = null;
        //            else
        //                emp.Experience1.Department = txtExpDept1.Text.Trim();
        //            if (txtExpDesig1.Text.Trim() == "")
        //                emp.Experience1.Designation = null;
        //            else
        //                emp.Experience1.Designation = txtExpDesig1.Text.Trim();
        //            if (txtExpDuration1.Text.Trim() == "")
        //                emp.Experience1.Duration = null;
        //            else
        //                emp.Experience1.Duration = txtExpDuration1.Text.Trim();
        //            if (txtExpLoc1.Text.Trim() == "")
        //                emp.Experience1.Location = null;
        //            else
        //                emp.Experience1.Location = txtExpLoc1.Text.Trim();
        //            if (txtExpCmp1.Text.Trim() == "")
        //                emp.Experience1.CompanyName = null;
        //            else
        //                emp.Experience1.CompanyName = txtExpCmp1.Text.Trim();
        //        }
        //    }
        //    else
        //    {
        //        if (txtExpCmp1.Text.Trim() != "")
        //        {
        //            emp.Experience1 = new EmployeeExperience();
        //            emp.Experience1.EmployeeID = emp.EmployeeID;
        //            emp.Experience1.ExpID = 0;
        //            emp.Experience1.iDel = false;
        //            if (txtExpDept1.Text.Trim() == "")
        //                emp.Experience1.Department = null;
        //            else
        //                emp.Experience1.Department = txtExpDept1.Text.Trim();
        //            if (txtExpDesig1.Text.Trim() == "")
        //                emp.Experience1.Designation = null;
        //            else
        //                emp.Experience1.Designation = txtExpDesig1.Text.Trim();
        //            if (txtExpDuration1.Text.Trim() == "")
        //                emp.Experience1.Duration = null;
        //            else
        //                emp.Experience1.Duration = txtExpDuration1.Text.Trim();
        //            if (txtExpLoc1.Text.Trim() == "")
        //                emp.Experience1.Location = null;
        //            else
        //                emp.Experience1.Location = txtExpLoc1.Text.Trim();
        //            if (txtExpCmp1.Text.Trim() == "")
        //                emp.Experience1.CompanyName = null;
        //            else
        //                emp.Experience1.CompanyName = txtExpCmp1.Text.Trim();
        //        }
        //        else
        //        {
        //            emp.Experience1 = null;
        //        }
        //    }
        //    if (txtExpCmp2.Tag != null)
        //    {
        //        emp.Experience2 = new EmployeeExperience();
        //        emp.Experience2.EmployeeID = emp.EmployeeID;
        //        emp.Experience2.ExpID = (int)txtExpCmp2.Tag;
        //        if (txtExpCmp2.Text.Trim() == "")
        //        {
        //            emp.Experience2.iDel = true;
        //        }
        //        else
        //        {
        //            emp.Experience2.iDel = false;
        //            if (txtExpDept2.Text.Trim() == "")
        //                emp.Experience2.Department = null;
        //            else
        //                emp.Experience2.Department = txtExpDept2.Text.Trim();
        //            if (txtExpDesig2.Text.Trim() == "")
        //                emp.Experience2.Designation = null;
        //            else
        //                emp.Experience2.Designation = txtExpDesig2.Text.Trim();
        //            if (txtExpDuration2.Text.Trim() == "")
        //                emp.Experience2.Duration = null;
        //            else
        //                emp.Experience2.Duration = txtExpDuration2.Text.Trim();
        //            if (txtExpLoc2.Text.Trim() == "")
        //                emp.Experience2.Location = null;
        //            else
        //                emp.Experience2.Location = txtExpLoc2.Text.Trim();
        //            if (txtExpCmp2.Text.Trim() == "")
        //                emp.Experience2.CompanyName = null;
        //            else
        //                emp.Experience2.CompanyName = txtExpCmp2.Text.Trim();
        //        }
        //    }
        //    else
        //    {
        //        if (txtExpCmp2.Text.Trim() != "")
        //        {
        //            emp.Experience2 = new EmployeeExperience();
        //            emp.Experience2.EmployeeID = emp.EmployeeID;
        //            emp.Experience2.ExpID = 0;
        //            emp.Experience2.iDel = false;
        //            if (txtExpDept2.Text.Trim() == "")
        //                emp.Experience2.Department = null;
        //            else
        //                emp.Experience2.Department = txtExpDept2.Text.Trim();
        //            if (txtExpDesig2.Text.Trim() == "")
        //                emp.Experience2.Designation = null;
        //            else
        //                emp.Experience2.Designation = txtExpDesig2.Text.Trim();
        //            if (txtExpDuration2.Text.Trim() == "")
        //                emp.Experience2.Duration = null;
        //            else
        //                emp.Experience2.Duration = txtExpDuration2.Text.Trim();
        //            if (txtExpLoc2.Text.Trim() == "")
        //                emp.Experience2.Location = null;
        //            else
        //                emp.Experience2.Location = txtExpLoc2.Text.Trim();
        //            if (txtExpCmp2.Text.Trim() == "")
        //                emp.Experience2.CompanyName = null;
        //            else
        //                emp.Experience2.CompanyName = txtExpCmp2.Text.Trim();
        //        }
        //        else
        //        {
        //            emp.Experience2 = null;
        //        }
        //    }
        //    if (grpRef.Tag != null)
        //    {
        //        emp.Reference = new EmployeeReference();
        //        emp.Reference.EmployeeID = emp.EmployeeID;
        //        emp.Reference.ReferenceID = (int)grpRef.Tag;
        //        if (txtRefName.Text.Trim() == "")
        //        {
        //            emp.Reference.iDel = true;
        //        }
        //        else
        //        {
        //            emp.Reference.iDel = false;
        //            if (txtRefHowKnow.Text.Trim() == "")
        //                emp.Reference.HowKnow = null;
        //            else
        //                emp.Reference.HowKnow = txtRefHowKnow.Text.Trim();
        //            if (txtRefAddress.Text.Trim() == "")
        //                emp.Reference.PersonAddress = null;
        //            else
        //                emp.Reference.PersonAddress = txtRefAddress.Text.Trim();
        //            if (txtRefName.Text.Trim() == "")
        //                emp.Reference.PersonName = null;
        //            else
        //                emp.Reference.PersonName = txtRefName.Text.Trim();
        //            if (txtRefRelation.Text.Trim() == "")
        //                emp.Reference.Relation = null;
        //            else
        //                emp.Reference.Relation = txtRefRelation.Text.Trim();
        //            if (txtRefWhenKnow.Text.Trim() == "")
        //                emp.Reference.WhenKnow = null;
        //            else
        //                emp.Reference.WhenKnow = txtRefWhenKnow.Text.Trim();
        //        }
        //    }
        //    else
        //    {
        //        if (txtRefName.Text.Trim() == "")
        //        {
        //            emp.Reference = null;
        //        }
        //        else
        //        {
        //            emp.Reference = new EmployeeReference();
        //            emp.Reference.EmployeeID = emp.EmployeeID;
        //            emp.Reference.ReferenceID = 0;
        //            emp.Reference.iDel = false;
        //            if (txtRefHowKnow.Text.Trim() == "")
        //                emp.Reference.HowKnow = null;
        //            else
        //                emp.Reference.HowKnow = txtRefHowKnow.Text.Trim();
        //            if (txtRefAddress.Text.Trim() == "")
        //                emp.Reference.PersonAddress = null;
        //            else
        //                emp.Reference.PersonAddress = txtRefAddress.Text.Trim();
        //            if (txtRefName.Text.Trim() == "")
        //                emp.Reference.PersonName = null;
        //            else
        //                emp.Reference.PersonName = txtRefName.Text.Trim();
        //            if (txtRefRelation.Text.Trim() == "")
        //                emp.Reference.Relation = null;
        //            else
        //                emp.Reference.Relation = txtRefRelation.Text.Trim();
        //            if (txtRefWhenKnow.Text.Trim() == "")
        //                emp.Reference.WhenKnow = null;
        //            else
        //                emp.Reference.WhenKnow = txtRefWhenKnow.Text.Trim();
        //        }
        //    }
        //    if (grpCriminalRecord.Tag != null)
        //    {
        //        emp.CriminalRecord = new EmployeeCriminalRecord();
        //        emp.CriminalRecord.EmployeeID = emp.EmployeeID;
        //        emp.CriminalRecord.CrimeID = (int)grpCriminalRecord.Tag;
        //        if (txtCrime.Text.Trim() == "")
        //        {
        //            emp.CriminalRecord.iDel = true;
        //        }
        //        else
        //        {
        //            emp.CriminalRecord.iDel = false;
        //            if (txtCrime.Text.Trim() == "")
        //                emp.CriminalRecord.CrimeDec = null;
        //            else
        //                emp.CriminalRecord.CrimeDec = txtCrime.Text.Trim();
        //            if (txtCrimeDetail.Text.Trim() == "")
        //                emp.CriminalRecord.CrimeDetail = null;
        //            else
        //                emp.CriminalRecord.CrimeDetail = txtCrimeDetail.Text.Trim();
        //        }
        //    }
        //    else
        //    {
        //        if (txtCrime.Text.Trim() == "")
        //        {
        //            emp.CriminalRecord = null;
        //        }
        //        else
        //        {
        //            emp.CriminalRecord = new EmployeeCriminalRecord();
        //            emp.CriminalRecord.EmployeeID = emp.EmployeeID;
        //            emp.CriminalRecord.CrimeID = 0;
        //            emp.CriminalRecord.iDel = false;
        //            if (txtCrime.Text.Trim() == "")
        //                emp.CriminalRecord.CrimeDec = null;
        //            else
        //                emp.CriminalRecord.CrimeDec = txtCrime.Text.Trim();
        //            if (txtCrimeDetail.Text.Trim() == "")
        //                emp.CriminalRecord.CrimeDetail = null;
        //            else
        //                emp.CriminalRecord.CrimeDetail = txtCrimeDetail.Text.Trim();
        //        }


        //    }
        //    using (PayrollDB db = new PayrollDB())
        //    {
        //        if (EmpOtherLanguage.Count > 0)
        //        {
        //            foreach (Employee_OtherLanguage eol in EmpOtherLanguage)
        //            {
        //                eol.MessageNo = msg.Msg_Number;
        //            }
        //            msg = PayrollDAL.PayrollDB.SaveOtherLanguages(EmpOtherLanguage);
        //            if (msg.isError)
        //            {
        //                RadMessageBox.Show(msg.Description, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
        //                //return;
        //            }
        //        }
        //        if (!isFound)
        //        {
        //            emp.NadraDeduction = chkNadraDeduction.Checked;
        //            if (sbsCore.bParam.AutoCode)
        //            {
        //                emp.EmployeeCode = null;
        //                emp.CardNo = null;
        //            }
        //            msg = db.Employee_Add(emp);
        //            if (msg.isError)
        //            {
        //                RadMessageBox.Show(msg.Description, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
        //                return;
        //            }
        //            else
        //            {
        //                if (Quali_List.Count > 0)
        //                {
        //                    foreach (EmployeeQualification eq in Quali_List)
        //                    {
        //                        eq.EmployeeID = msg.Msg_Number;
        //                    }
        //                    msg = db.EmpQualification_Update(Quali_List);
        //                    if (msg.isError)
        //                    {
        //                        RadMessageBox.Show(msg.Description, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
        //                        //return;
        //                    }
        //                }
        //                //if (NextOfKin_List.Count > 0 && NextOfKin_List.Count < 3)
        //                if (NextOfKin_List.Count > 0)
        //                {
        //                    foreach (EmployeeNextOfKin enk in NextOfKin_List)
        //                    {
        //                        enk.EmployeeID = msg.Msg_Number;
        //                    }
        //                    int sumPercent = NextOfKin_List.Sum(a => a.SharePercent);
        //                    if (sumPercent > 100)
        //                    {
        //                        RadMessageBox.Show("Warning", "Share Pecent in next of kin exceeded than 100", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
        //                        return;
        //                    }
        //                    msg = db.EmpNextOfKin_Update(NextOfKin_List);
        //                    if (msg.isError)
        //                    {
        //                        RadMessageBox.Show(msg.Description, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
        //                        //return;
        //                    }
        //                }
        //                if (Family_List.Count > 0)
        //                {
        //                    foreach (EmployeeFamily eq in Family_List)
        //                    {
        //                        eq.EmployeeID = msg.Msg_Number;
        //                    }
        //                    msg = db.EmpFamily_Update(Family_List);

        //                    //if (msg.isError)
        //                    //{
        //                    //   .. RadMessageBox.Show(msg.Description, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
        //                    //    //return;
        //                    //}
        //                }



        //            }

        //        }


        //    }
        //}

    }
}
