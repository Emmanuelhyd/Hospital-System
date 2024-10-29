using Hospital_System.Models;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace Hospital_System.DAL
{
    public class NurseAdDAL
    {
        string _connectionString;
        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataReader reader = null;

        public NurseAdDAL()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Hospital"].ConnectionString;
            con = new SqlConnection(_connectionString);
        }

        //list

        public List<NurseDo> NurseList()
        {
            List<NurseDo> nurseDos = new List<NurseDo>();

            {

                con.Open();
                cmd = new SqlCommand("select * from Nurse", con);
                SqlDataReader sdr;
                sdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(sdr);
                foreach (DataRow row in dt.Rows)
                    nurseDos.Add(
                        new NurseDo
                        {
                            NurseId = Convert.ToInt32(row["NurseId"]),
                            Name = row["Name"].ToString(),
                            DOB = row["DOB"].ToString(),
                            Contact = row["Contact"].ToString(),
                            Email = row["Email"].ToString(),
                            Address = row["Address"].ToString(),
                            DateOfJoining = row["DateOfJoining"].ToString(),
                            Specialization = row["Specialization"].ToString(),
                            ShiftType = row["ShiftType"].ToString(),
                            Education = row["Education"].ToString(),
                            EmployeeStatus = row["EmployeeStatus"].ToString(),


                        });

                return nurseDos;
            }
        }

        //Add outpatient details

        public List<NurseDo> AddNurse(NurseDo nurseDo)
        {

            var ids = 0;
            con.Open();
            cmd = new SqlCommand("select * from Nurse where NurseId='" + nurseDo.NurseId + "'", con);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                ids = Convert.ToInt32(reader["NurseId"]);
            }

            reader.Close();
            con.Close();



            con.Open();
            if (ids == 0)
            {
                cmd = new SqlCommand("insert into Nurse(NurseId,Name,DOB,Contact,Email,Address,DateOfJoining,Specialization,ShiftType,Education,EmployeeStatus) values(" + nurseDo.NurseId + ",'" + nurseDo.Name + "','" + nurseDo.DOB + "','" + nurseDo.Contact + "','" + nurseDo.Email + "','" + nurseDo.Address + "','" + nurseDo.DateOfJoining + "','" + nurseDo.Specialization + "','" + nurseDo.ShiftType + "','" + nurseDo.Education + "','" + nurseDo.EmployeeStatus + "')", con);

            }
            else
            {
                cmd = new SqlCommand("update Nurse set Name='" + nurseDo.Name + "',DOB='" + nurseDo.DOB + "',Contact='" + nurseDo.Contact + "',Email='" + nurseDo.Email + "',Address='" + nurseDo.Address + "',DateOfJoining='" + nurseDo.DateOfJoining + "',Specialization='" + nurseDo.Specialization + "' ,ShiftType='" + nurseDo.ShiftType + "',Education='" + nurseDo.Education + "',EmployeeStatus='" + nurseDo.EmployeeStatus + "' where NurseId=" + nurseDo.NurseId + "", con);
            }
            cmd.ExecuteNonQuery();
            con.Close();


            List<NurseDo> nurseDos = new List<NurseDo>();
            nurseDos = NurseList();
            return nurseDos;
        }
        //outPatient Auto Increment Id
        public int NursesId()
        {
            int id = 0;
            con.Open();
            cmd = new SqlCommand("SELECT MAX(NurseId) FROM Nurse", con);
            var result = cmd.ExecuteScalar();

            if (result != DBNull.Value)
            {
                id = Convert.ToInt32(result);
            }
            con.Close();
            return id;
        }

        //Nurse Edit

        public NurseDo NurseEdit(int NurseId)
        {
            NurseDo nurseDo = new NurseDo();


            SqlCommand cmd = new SqlCommand("Select * from Nurse where NurseId='" + NurseId + "'", con);
            {

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                if (reader.Read())
                {
                    nurseDo.NurseId = Convert.ToInt32(reader["NurseId"]);
                    nurseDo.Name = reader["Name"].ToString();
                    nurseDo.DOB = reader["DOB"].ToString();
                    nurseDo.Contact = reader["Contact"].ToString();
                    nurseDo.Email = reader["Email"].ToString();
                    nurseDo.Address = reader["Address"].ToString();
                    nurseDo.DateOfJoining = reader["DateOfJoining"].ToString();
                    nurseDo.Specialization = reader["Specialization"].ToString();
                    nurseDo.ShiftType = reader["ShiftType"].ToString();
                    nurseDo.Education = reader["Education"].ToString();
                    nurseDo.EmployeeStatus = reader["EmployeeStatus"].ToString();


                }
                reader.Close();
                con.Close();

            }
            return nurseDo;
        }

        //Nurse delete

        public List<NurseDo> NurseDelete(int NurseId)
        {
            con.Open();
            cmd = new SqlCommand("Delete from Nurse where NurseId='" + NurseId + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();

            List<NurseDo> nurseDos = new List<NurseDo>();

            con.Open();
            cmd = new SqlCommand("select * from Nurse", con);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                NurseDo nurseDo = new NurseDo();

                nurseDo.NurseId = Convert.ToInt32(reader["NurseId"]);
                nurseDo.Name = reader["Name"].ToString();
                nurseDo.DOB = reader["DOB"].ToString();
                nurseDo.Contact = reader["Contact"].ToString();
                nurseDo.Email = reader["Email"].ToString();
                nurseDo.Address = reader["Address"].ToString();
                nurseDo.DateOfJoining = reader["DateOfJoining"].ToString();
                nurseDo.Specialization = reader["Specialization"].ToString();
                nurseDo.ShiftType = reader["ShiftType"].ToString();
                nurseDo.Education = reader["Education"].ToString();
                nurseDo.EmployeeStatus = reader["EmployeeStatus"].ToString();

                nurseDos.Add(nurseDo);

            }

            reader.Close();
            con.Close();
            return nurseDos;
        }


    }
}