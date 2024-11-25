using Hospital_System.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Hospital_System.DAL
{
    public class AmbulanceDAL
    {

        string _connectionString = null;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;

        public AmbulanceDAL()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Hospital"].ConnectionString;
            con = new SqlConnection(_connectionString);
        }

        public List<AmbulanceDetails> GetAmbulanceDetails()
        {
            List<AmbulanceDetails>ambulanceDetails = new List<AmbulanceDetails>();

            con.Open();
            cmd= new SqlCommand("select * from Amb",con);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                AmbulanceDetails ambulanceDetails1 = new AmbulanceDetails();

                ambulanceDetails1.Id = Convert.ToInt32(reader["Id"]);
                ambulanceDetails1.Name = reader.GetString(reader.GetOrdinal("Name"));
                ambulanceDetails1.AmbulanceId = Convert.ToInt32(reader["AmbulanceId"]);
                ambulanceDetails1.AmbulanceStatus = reader.GetString(reader.GetOrdinal("AmbulanceStatus"));
                ambulanceDetails1.DriverName = reader.GetString(reader.GetOrdinal("DriverName"));
                ambulanceDetails1.DriverId = reader.GetString(reader.GetOrdinal("DriverId"));

                ambulanceDetails.Add(ambulanceDetails1);
            }

            reader.Close();
            con.Close();
            return ambulanceDetails;
        }

        //Add
        public List<AmbulanceDetails> AddAmbulance(AmbulanceDetails ambulanceDo)
        {

            var ids = 0;
            con.Open();
            cmd = new SqlCommand("select * from Amb where Id='" + ambulanceDo.Id + "'", con);
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

                cmd = new SqlCommand("insert into Amb(Id,Name,AmbulanceId,AmbulanceStatus,DriverName,DriverId) values(" + ambulanceDo.Id + ",'" + ambulanceDo.Name + "','" + ambulanceDo.AmbulanceId + "','" + ambulanceDo.AmbulanceStatus + "','" + ambulanceDo.DriverName + "','" + ambulanceDo.DriverId + "')", con);



            }
            else
            {

                cmd = new SqlCommand("update Amb set Name='" + ambulanceDo.Name + "',AmbulanceId='" + ambulanceDo.AmbulanceId + "',AmbulanceStatus='" + ambulanceDo.AmbulanceStatus + "',DriverName='" + ambulanceDo.DriverName + "',DriverId='" + ambulanceDo.DriverId + "'  where Id=" + ambulanceDo.Id + "", con);


            }
            cmd.ExecuteNonQuery();
            con.Close();


            List<AmbulanceDetails> ambulanceDos = new List<AmbulanceDetails>();
            ambulanceDos = GetAmbulanceDetails();
            return ambulanceDos;

        }

        // Edit

        public AmbulanceDetails AmbE(int Id)
        {
            AmbulanceDetails ambulanceDo = new AmbulanceDetails();



            SqlCommand cmd = new SqlCommand("Select * from Amb where Id='" + Id + "'", con);


            {

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                if (reader.Read())
                {
                    ambulanceDo.Id = Convert.ToInt32(reader["Id"]);
                    ambulanceDo.Name = reader["Name"] != DBNull.Value ? reader["Name"].ToString() : string.Empty;
                    ambulanceDo.AmbulanceId = reader["AmbulanceId"] != DBNull.Value ? Convert.ToInt32(reader["AmbulanceId"]) : 0;
                    ambulanceDo.AmbulanceStatus = reader["AmbulanceStatus"] != DBNull.Value ? reader["AmbulanceStatus"].ToString() : string.Empty;

                    ambulanceDo.DriverName = reader["DriverName"] != DBNull.Value ? reader["DriverName"].ToString() : string.Empty;
                    ambulanceDo.DriverId = reader["DriverId"] != DBNull.Value ? reader["DriverId"].ToString() : string.Empty;







                }
                reader.Close();
                con.Close();

            }
            return ambulanceDo;
        }

        public int AmbId()
        {
            int id = 0;
            con.Open();

            cmd = new SqlCommand("SELECT MAX(Id) FROM Amb", con);



            var result = cmd.ExecuteScalar();

            if (result != DBNull.Value)
            {
                id = Convert.ToInt32(result);
            }
            con.Close();
            return id;
        }

        public AmbulanceDetails AmbulanceId(int Id)
        {
            AmbulanceDetails Ambulance = null;
            string res = "";
            con.Open();
            cmd = new SqlCommand("select * from Amb where Id=" + Id + "", con);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Ambulance = new AmbulanceDetails
                {
                   Id = Convert.ToInt32(reader["Id"]),
                   Name = reader.GetString(reader.GetOrdinal("Name")),
                   AmbulanceId = Convert.ToInt32(reader["AmbulanceId"]),
                   AmbulanceStatus = reader.GetString(reader.GetOrdinal("AmbulanceStatus")),
                   DriverName = reader.GetString(reader.GetOrdinal("DriverName")),
                   DriverId = reader.GetString(reader.GetOrdinal("DriverId")),

                };
            }


            reader.Close();
            con.Close();
            return Ambulance;
        }

    }
}