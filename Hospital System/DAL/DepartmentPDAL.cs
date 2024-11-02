using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital_System.Models;
namespace Hospital_System.DAL
{
    public class DepartmentPDAL
    {
        string _connectionString;
        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataReader reader = null;

        public DepartmentPDAL()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Hospital"].ConnectionString;
            con = new SqlConnection(_connectionString);
        }

        //departmentList
        public List<MDepartment> DepList()
        {
            List<MDepartment> mDepartments = new List<MDepartment>();
            {

                con.Open();
                cmd = new SqlCommand("select * from DepartmentAd", con);
                SqlDataReader sdr;
                sdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(sdr);
                foreach (DataRow row in dt.Rows)
                    mDepartments.Add(
                        new MDepartment
                        {
                            Id = Convert.ToInt32(row["Id"]),
                            DepartmentName = row["DepartmentName"].ToString(),
                            DoctorName = row["DoctorName"].ToString(),
                            Education = row["Education"].ToString(),
                            Description = row["Description"].ToString(),
                            Gender = row["Gender"].ToString(),
                            Status = row["Status"].ToString(),

                        });

                return mDepartments;
            }
        }
    }
}