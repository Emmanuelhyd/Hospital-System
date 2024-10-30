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
                cmd = new SqlCommand("select * from ambulance", con);
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
                            AmbulanceDriver = row["AmbulanceDriver"].ToString(),
                            AmbulanceDriverId = Convert.ToInt32(row["AmbulanceDriverId"]),


                        });

                return ambulanceDos;
            }
        }
        //add ambulance admin
        public List<AmbulanceDo> AddAmb(AmbulanceDo ambulanceDo)
        {

            var ids = 0;
            con.Open();
            cmd = new SqlCommand("select * from ambulance where Id='" + ambulanceDo.Id + "'", con);
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
                cmd = new SqlCommand("insert into ambulance(Id,Name,AmbulanceId,AmbulanceStatus,AmbulanceDriver,AmbulanceDriverId) values(" + ambulanceDo.Id + ",'" + ambulanceDo.Name + "','" + ambulanceDo.AmbulanceId + "','" + ambulanceDo.AmbulanceStatus + "','" + ambulanceDo.AmbulanceDriver + "','" + ambulanceDo.AmbulanceDriverId + "')", con);

            }
            else
            {
                cmd = new SqlCommand("update ambulance set Name='" + ambulanceDo.Name + "',AmbulanceId='" + ambulanceDo.AmbulanceId + "',AmbulanceStatus='" + ambulanceDo.AmbulanceStatus + "',AmbulanceDriver='" + ambulanceDo.AmbulanceDriver + "',AmbulanceDriverId='" + ambulanceDo.AmbulanceDriverId + "' where Id=" + ambulanceDo.Id + "", con);
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


            SqlCommand cmd = new SqlCommand("Select * from ambulance where Id='" + Id + "'", con);
            {

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                if (reader.Read())
                {
                    ambulanceDo.Id = Convert.ToInt32(reader["Id"]);
                    ambulanceDo.Name = reader["Name"].ToString();
                    ambulanceDo.AmbulanceId = Convert.ToInt32(reader["AmbulanceId"]);
                    ambulanceDo.AmbulanceStatus = reader["AmbulanceStatus"].ToString();
                    ambulanceDo.AmbulanceDriver = reader["AmbulanceDriver"].ToString();
                    ambulanceDo.AmbulanceDriverId = Convert.ToInt32(reader["AmbulanceDriverId"]);


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
            cmd = new SqlCommand("Delete from ambulance where Id='" + Id + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();

            List<AmbulanceDo> ambulanceDos = new List<AmbulanceDo>();

            con.Open();
            cmd = new SqlCommand("select * from ambulance", con);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                AmbulanceDo ambulanceDo = new AmbulanceDo();

                ambulanceDo.Id = Convert.ToInt32(reader["Id"]);
                ambulanceDo.Name = reader["Name"].ToString();
                ambulanceDo.AmbulanceId = Convert.ToInt32(reader["AmbulanceId"]);
                ambulanceDo.AmbulanceStatus = reader["AmbulanceStatus"].ToString();
                ambulanceDo.AmbulanceDriver = reader["AmbulanceDriver"].ToString();
                ambulanceDo.AmbulanceDriverId = Convert.ToInt32(reader["AmbulanceDriverId"]);


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
            cmd = new SqlCommand("SELECT MAX(Id) FROM ambulance", con);
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