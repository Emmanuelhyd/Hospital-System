using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;
using Hospital_System.Models;
using System.Data;

namespace Hospital_System.DAL
{
    public class AmbulanceRDAL
    {
        string _connectionString;
        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataReader reader = null;

        public AmbulanceRDAL()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Hospital"].ConnectionString;
            con = new SqlConnection(_connectionString);
        }


        //Ambulanace List admin

        public List<AmbulanceDo> AmbList()
        {
            List<AmbulanceDo> ambulanceDos = new List<AmbulanceDo>();

            {

                con.Open();
                cmd = new SqlCommand("select * from Ambulance", con);
                SqlDataReader sdr;
                sdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(sdr);
                foreach (DataRow row in dt.Rows)
                    ambulanceDos.Add(
                        new AmbulanceDo
                        {
                            Id = Convert.ToInt32(row["Id"]),
                            Name = row["Name"].ToString(),
                            AmbulanceId = Convert.ToInt32(row["AmbulanceId"]),
                            AmbulanceStatus = row["AmbulanceStatus"].ToString(),
                            DriverName = row["DriverName"].ToString(),
                            DriverId = Convert.ToInt32(row["DriverId"]),


                        });

                return ambulanceDos;
            }
        }
        //add ambulance admin
        public List<AmbulanceDo> AddAmb(AmbulanceDo ambulanceDo)
        {

            var ids = 0;
            con.Open();
            cmd = new SqlCommand("select * from Ambulance where Id='" + ambulanceDo.Id + "'", con);
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
                cmd = new SqlCommand("insert into Ambulance(Id,Name,AmbulanceId,AmbulanceStatus,DriverName,DriverId) values(" + ambulanceDo.Id + ",'" + ambulanceDo.Name + "','" + ambulanceDo.AmbulanceId + "','" + ambulanceDo.AmbulanceStatus + "','" + ambulanceDo.DriverName + "','" + ambulanceDo.DriverId + "')", con);

            }
            else
            {
                cmd = new SqlCommand("update Ambulance set Name='" + ambulanceDo.Name + "',AmbulanceId='" + ambulanceDo.AmbulanceId + "',AmbulanceStatus='" + ambulanceDo.AmbulanceStatus + "',DriverName='" + ambulanceDo.DriverName + "',DriverId='" + ambulanceDo.DriverId + "' where Id=" + ambulanceDo.Id + "", con);
            }
            cmd.ExecuteNonQuery();
            con.Close();


            List<AmbulanceDo> ambulanceDos = new List<AmbulanceDo>();
            ambulanceDos = AmbList();
            return ambulanceDos;
        }

        //outpatient Edit

        public AmbulanceDo AmbEdit(int Id)
        {
            AmbulanceDo ambulanceDo = new AmbulanceDo();


            SqlCommand cmd = new SqlCommand("Select * from Ambulance where Id='" + Id + "'", con);
            {

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                if (reader.Read())
                {
                    ambulanceDo.Id = Convert.ToInt32(reader["Id"]);
                    ambulanceDo.Name = reader["Name"].ToString();
                    ambulanceDo.AmbulanceId = Convert.ToInt32(reader["AmbulanceId"]);
                    ambulanceDo.AmbulanceStatus = reader["AmbulanceStatus"].ToString();
                    ambulanceDo.DriverName = reader["DriverName"].ToString();
                    ambulanceDo.DriverId = Convert.ToInt32(reader["DriverId"]);


                }
                reader.Close();
                con.Close();

            }
            return ambulanceDo;
        }

        //outpatient delete

        public List<AmbulanceDo> AmbDelete(int Id)
        {
            con.Open();
            cmd = new SqlCommand("Delete from Ambulance where Id='" + Id + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();

            List<AmbulanceDo> ambulanceDos = new List<AmbulanceDo>();

            con.Open();
            cmd = new SqlCommand("select * from Ambulance", con);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                AmbulanceDo ambulanceDo = new AmbulanceDo();

                ambulanceDo.Id = Convert.ToInt32(reader["Id"]);
                ambulanceDo.Name = reader["Name"].ToString();
                ambulanceDo.AmbulanceId = Convert.ToInt32(reader["AmbulanceId"]);
                ambulanceDo.AmbulanceStatus = reader["AmbulanceStatus"].ToString();
                ambulanceDo.DriverName = reader["DriverName"].ToString();
                ambulanceDo.DriverId = Convert.ToInt32(reader["DriverId"]);


                ambulanceDos.Add(ambulanceDo);

            }

            reader.Close();
            con.Close();
            return ambulanceDos;
        }



        //outPatient Auto Increment Id
        public int AmbId()
        {
            int id = 0;
            con.Open();
            cmd = new SqlCommand("SELECT MAX(Id) FROM Ambulance", con);
            var result = cmd.ExecuteScalar();

            if (result != DBNull.Value)
            {
                id = Convert.ToInt32(result);
            }
            con.Close();
            return id;
        }
    }
}