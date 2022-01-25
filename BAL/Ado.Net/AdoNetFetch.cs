using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.Utilities;
using DAL.CustomModel;

namespace BAL.Ado.Net
{
    public class AdoNetFetch
    {
        AdoDbClass ado;
        AdoDbClass ado1;
        public AdoNetFetch()
        {
            ado = new AdoDbClass();
            ado1 = new AdoDbClass();

        }

        public List<Division> GetAllDivision()
        {
            try
            {
                string query = "select * from Division";
                var reader = ado.GetReader(query, null); 
                List<Division> divisionList = new List<Division>();
                while (reader.Read())
                {
                    Division d = new Division();
                    d.DivisionID = (Int32)reader["DivisionID"];
                    d.DivisionName = reader["Division"].ToString();
                    d.isActive = (bool)reader["isActive"];

                    divisionList.Add(d);
                }

                return divisionList;
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                ado.CloseSqlConnection();
            }
          
        }

        public List<Category> GetAllCatgory()
        {
            try
            {
                string query = "select * from Category";
                var reader = ado.GetReader(query, null);
                List<Category> CategoryList = new List<Category>();
                while (reader.Read())
                {
                    Category c = new Category();
                    c.CategoryId = (Int32)reader["CategoryId"];
                    c.CategoryDesc = reader["CategoryDesc"].ToString();
                    c.Active = (bool)reader["Active"];

                    CategoryList.Add(c);
                }

                return CategoryList;
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                ado.CloseSqlConnection();
            }

        }

        public List<Department> GetAllDepartment()
        {
            try
            {
                string query = "select * from Department";
                var reader = ado.GetReader(query, null);
                List<Department> DepartmentList = new List<Department>();
                while (reader.Read())
                {
                    Department c = new Department();
                    c.Department_ID = (Int32)reader["Department_Id"];
                    c.Department_Name = reader["Department_Name"].ToString();
                    c.isActive = (bool)reader["isActive"];

                    DepartmentList.Add(c);
                }

                return DepartmentList;
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                ado.CloseSqlConnection();
            }

        }

        public List<Designation> GetAllDesignation()
        {
            try
            {
                string query = "select * from Designation";
                var reader = ado.GetReader(query, null);
                List<Designation> CategoryList = new List<Designation>();
                while (reader.Read())
                {
                    Designation c = new Designation();
                    c.Designation_ID = (Int32)reader["Designation_Id"];
                    c.Designation_Name = reader["Designation_Name"].ToString();
                    c.isActive = (bool)reader["isActive"];

                    CategoryList.Add(c);
                }

                return CategoryList;
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                ado.CloseSqlConnection();
            }

        }


        public List<CvMain> GetAllCVCandidate(int CvId = 0,bool withQlf = false,bool withExper = false,bool withSkils = false,bool withInternship = false)
        {
            try
            {
                string Condition = CvId.ToString()!="0"?" and cv.CVID = "+CvId:"";
                string query = "select distinct cv.CVID,cv.CategoryID,c.CategoryDesc,cv.DepartmentID,d.Department_Name,cv.CandidateName, cv.FatherHusbandName,cv.Relation,cv.Gender, cv.MaritalStatus,cv.CNIC,cv.CNICExpire,cv.DOB,cv.Mobile, cv.Email,cv.CurrentAddress,cv.DisabilityID,cv.LastUpdateDate,cv.DivisionID,ds.Designation_Name from CV_Main cv left outer join Department d on d.Department_ID = cv.DepartmentID left outer join Designation ds on ds.Designation_ID = cv.DesignationID left outer join Category c on c.CategoryID = cv.CategoryID where 1=1 "+Condition +" and cv.CandidateName <> '' ";
                var reader = ado.GetReader(query, null);
                List<CvMain> CategoryList = new List<CvMain>();
                while (reader.Read())
                {
                    CvMain c = new CvMain();
                    c.CVID = (int)reader["CVID"];
                    c.CategoryID = (int)reader["CategoryID"];
                    c.DepartmentID = reader["DepartmentID"].ToString()==""?0: (int)reader["DepartmentID"];
                    c.DepartmentName = Convert.ToString(reader["Department_Name"]);
                    c.CandidateName = Convert.ToString(reader["CandidateName"]);
                    c.FatherHusbandName = Convert.ToString(reader["FatherHusbandName"]);
                    c.Relation = Convert.ToString(reader["Relation"]);
                    c.Gender = Convert.ToString(reader["Gender"]);
                    c.MaritalStatus = Convert.ToString(reader["MaritalStatus"]);
                    c.CNIC = Convert.ToString(reader["CNIC"]);
                    c.CNICExpire = reader["CNICExpire"].ToString() =="" ? DateTime.Now:(DateTime)reader["CNICExpire"];
                    DateTime validDate;
                    if (DateTime.TryParse(reader["CNICExpire"].ToString(), out validDate))
                    {
                        c.LastUpdateDate = validDate;
                    }
                    else
                    {
                        // Aww.. :(
                    }

        
                    if (DateTime.TryParse(reader["CNICExpire"].ToString(), out validDate))
                    {

                        c.DOB = validDate;
                    }
                    else
                    {
                        // Aww.. :(
                    }

                    c.Mobile = Convert.ToString(reader["Mobile"]);
                    c.Email = Convert.ToString( reader["Email"]);
                    c.CurrentAddress = Convert.ToString(reader["CurrentAddress"]);
                    c.DisabilityID = (int)reader["DisabilityID"];
                    c.LastUpdateDate = reader["LastUpdateDate"].ToString() ==""?DateTime.Now: (DateTime)reader["LastUpdateDate"];
                    c.DivisionID = (int)reader["DivisionID"];
                    c.DesignationName = Convert.ToString(reader["Designation_Name"]);
                    c.CategoryName = Convert.ToString(reader["CategoryDesc"]);

                    if (withQlf == true)
                    {
                        c.CvQualifications = GetAllQualification(c.CVID);
                    }

                    if (withExper == true)
                    {
                        c.CvExperiences = GetAllExperince(c.CVID);
                    }

                    if (withSkils == true)
                    {
                        c.CvSkills = GetAllSkills(c.CVID);

                    }

                    if (withInternship == true)
                    {
                        c.CvInternships = GetAllInternship(c.CVID);
                    }




                    CategoryList.Add(c);
                }

                return CategoryList;
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                ado.CloseSqlConnection();
            }

        }


        public List<CV_Qualification> GetAllQualification(int CVID )
        {
            try
            {
                string query = "select cq.*,q.Qualification_Name,q.Degree from CV_Qualification cq inner join Qualification q  on q.Qualification_ID = cq.QualificationID where CVID = " + CVID+"";
                var reader = ado1.GetReader(query, null);
                List<CV_Qualification> CategoryList = new List<CV_Qualification>();
                while (reader.Read())
                {
                    CV_Qualification cq = new CV_Qualification();
                    cq.CVID = (int)reader["CVID"];
                    cq.CV_QID = (int)reader["CV_QID"];
                    cq.Duration = Convert.ToString (reader["Duration"]);
                    cq.StartDate = VariableCasting.ConvertToDatetime(reader["EndDate"]);
                    cq.EndDate = VariableCasting.ConvertToDatetime(reader["EndDate"]);
                    cq.Field = Convert.ToString(reader["Field"]);
                    cq.Grade = Convert.ToString(reader["Grade"]);
                    cq.Institute = Convert.ToString(reader["Institute"]);
                    cq.QType = Convert.ToString(reader["QType"]);
                    cq.Qualification_Name = Convert.ToString(reader["Qualification_Name"]);
                    cq.Degree = Convert.ToString(reader["Degree"]);
                    cq.QualificationID = VariableCasting.ConvertToInt(reader["QualificationID"]);

                    CategoryList.Add(cq);
                }

                return CategoryList;
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                ado1.CloseSqlConnection();
            }

        }



        public List<CvExperience> GetAllExperince(int CVID)
        {
            try
            {
                string query = "select * from CV_Experience where CVID = " + CVID + "";
                var reader = ado1.GetReader(query, null);
                List<CvExperience> CategoryList = new List<CvExperience>();
                while (reader.Read())
                {
                    CvExperience cq = new CvExperience();
                    cq.CVID = (int)reader["CVID"];
                    cq.CV_EID = (int)reader["CV_EID"];
                    cq.JobDuration = Convert.ToString(reader["JobDuration"]);
                    cq.EndDate = VariableCasting.ConvertToDatetime(reader["EndDate"]);
                    cq.StartDate = VariableCasting.ConvertToDatetime(reader["StartDate"]);
                    cq.LeavingReason = Convert.ToString(reader["LeavingReason"]);
                    cq.LastSalary = VariableCasting.ConvertToInt(reader["LastSalary"]);
                    cq.Department = Convert.ToString(reader["Department"]);
                    cq.Designation = Convert.ToString(reader["Designation"]);
                    cq.Company = Convert.ToString(reader["Company"]);


                    CategoryList.Add(cq);
                }

                return CategoryList;
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                ado1.CloseSqlConnection();
            }

        }

        public List<CV_Skills> GetAllSkills(int CVID)
        {
            try
            {
                string query = "select * from CV_Skills where CVID = " + CVID + "";
                var reader = ado1.GetReader(query, null);
                List<CV_Skills> CategoryList = new List<CV_Skills>();
                while (reader.Read())
                {
                    CV_Skills cq = new CV_Skills();
                    cq.CVID = (int)reader["CVID"];
                    cq.CV_SID = (int)reader["CV_SID"];
                    cq.Field = Convert.ToString(reader["Field"]);
                    cq.SkillDesc = Convert.ToString(reader["SkillDesc"]);


                    CategoryList.Add(cq);
                }

                return CategoryList;
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                ado1.CloseSqlConnection();
            }

        }

        public List<CV_InternShip> GetAllInternship(int CVID)
        {
            try
            {
                string query = "select * from CV_InternShip where CVID = " + CVID + "";
                var reader = ado1.GetReader(query, null);
                List<CV_InternShip> CategoryList = new List<CV_InternShip>();
                while (reader.Read())
                {
                    CV_InternShip cq = new CV_InternShip();
                    cq.CVID = (int)reader["CVID"];
                    cq.CV_IID = (int)reader["CV_IID"];
                    cq.Duration = Convert.ToString(reader["Duration"]);
                    cq.EndDate = VariableCasting.ConvertToDatetime(reader["EndDate"]);
                    cq.StartDate = VariableCasting.ConvertToDatetime(reader["StartDate"]);
                    cq.Department = Convert.ToString(reader["Department"]);
                    cq.Company = Convert.ToString(reader["Company"]);


                    CategoryList.Add(cq);
                }

                return CategoryList;
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                ado1.CloseSqlConnection();
            }

        }



    }
}
