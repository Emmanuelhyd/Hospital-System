using Hospital_System.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Hospital_System.DAL
{
    public class RoleDAL
    {

        string _connectionString = null;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;

        public RoleDAL()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Hospital"].ConnectionString;
            con = new SqlConnection(_connectionString);
        }

        public List<RoleDO> RolesList()
        {
            List<RoleDO> roleDOs = new List<RoleDO>();

            {

                con.Open();
                cmd = new SqlCommand("select * from Usertypes", con);
                SqlDataReader sdr;
                sdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(sdr);
                foreach (DataRow row in dt.Rows)
                    roleDOs.Add(
                        new RoleDO
                        {
                            Id = Convert.ToInt32(row["Id"]),
                            Roles = row["Roles"].ToString(),
                            Type = Convert.ToInt32(row["Type"]),

                        });

                return roleDOs;
            }
        }

        //Add roles

        //add department

        public List<RoleDO> AddRole(RoleDO roleDO)
        {

            var ids = 0;
            con.Open();
            cmd = new SqlCommand("select * from Usertypes where Id='" + roleDO.Id + "'", con);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                ids = Convert.ToInt32(reader["Id"]);
            }

            reader.Close();
            con.Close();



            con.Open();
            if (ids == 0)
            {
                cmd = new SqlCommand("insert into Usertypes(Id,Roles,Type) values(" + roleDO.Id + ",'" + roleDO.Roles + "','" + roleDO.Type + "')", con);

            }
            else
            {
                cmd = new SqlCommand("update Usertypes set Roles='" + roleDO.Roles + "',Type='" + roleDO.Type + "' where Id=" + roleDO.Id + "", con);
            }
            cmd.ExecuteNonQuery();
            con.Close();


            List<RoleDO> roleDOs = new List<RoleDO>();
            roleDOs = RolesList();
            return roleDOs;
        }




        //DoctorId Auto Increment Id
        public int RoleId()
        {
            int id = 0; // Default to 1 in case there are no records
            con.Open();
            cmd = new SqlCommand("SELECT MAX(Id) FROM Usertypes", con);
            var result = cmd.ExecuteScalar(); // Use ExecuteScalar for a single value

            // Check if result is null
            if (result != DBNull.Value)
            {
                id = Convert.ToInt32(result); // Increment the maximum ID
            }

            con.Close();
            return id;
        }


        //Role edit

        public RoleDO RoleEdit(int Id)
        {
            RoleDO roleDO = new RoleDO();


            SqlCommand cmd = new SqlCommand("Select * from Usertypes where Id='" + Id + "'", con);
            {

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                if (reader.Read())
                {
                    roleDO.Id = Convert.ToInt32(reader["Id"]);
                    roleDO.Roles = reader["Roles"].ToString();
                    roleDO.Type = Convert.ToInt32(reader["Type"]);


                }
                reader.Close();
                con.Close();

            }
            return roleDO;
        }
        // delete Role

        public List<RoleDO> RoleDelete(int Id)
        {
            con.Open();
            cmd = new SqlCommand("Delete from Usertypes where Id='" + Id + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();

            List<RoleDO> roleDOs = new List<RoleDO>();

            con.Open();
            cmd = new SqlCommand("select * from Usertypes", con);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                RoleDO roleDO = new RoleDO();

                roleDO.Id = Convert.ToInt32(reader["Id"]);
                roleDO.Roles = reader["Roles"].ToString();
                roleDO.Type = Convert.ToInt32(reader["Type"]);
               
                roleDOs.Add(roleDO);

            }

            reader.Close();
            con.Close();
            return roleDOs;
        }

    }
}