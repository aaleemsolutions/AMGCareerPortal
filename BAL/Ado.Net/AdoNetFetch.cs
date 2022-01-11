using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.CustomModel;

namespace BAL.Ado.Net
{
    public class AdoNetFetch
    {
        AdoDbClass ado;
        public AdoNetFetch()
        {
            ado = new AdoDbClass();

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

    }
}
