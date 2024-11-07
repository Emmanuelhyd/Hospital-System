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
        //SqlCommand cmd = null;
        //SqlDataReader reader = null;
        SqlCommand cmd;
        SqlDataReader reader;

        public AmbulanceRDAL()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Hospital"].ConnectionString;
            con = new SqlConnection(_connectionString);
        }


        //Ambulanace List admin

        public List<AmbulanceDo> AmbList(String And)
        {
            List<AmbulanceDo> ambulanceDos = new List<AmbulanceDo>();

            {

                con.Open();

               

                cmd = new SqlCommand("select * from Amb where Name like'%" + And + "%'", con);

                SqlDataReader sdr;
                sdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(sdr);
                foreach (DataRow row in dt.Rows)
                    ambulanceDos.Add(
                        new AmbulanceDo
                        {
                            Id = Convert.ToInt32(row["Id"]),
                            Name = row["Name"] != DBNull.Value ? row["Name"].ToString() : string.Empty,
                            AmbulanceId = row["AmbulanceId"] != DBNull.Value ? Convert.ToInt32(row["AmbulanceId"]) : 0,
                            AmbulanceStatus = row["AmbulanceStatus"] != DBNull.Value ? row["AmbulanceStatus"].ToString() : string.Empty,
                            DriverName = row["DriverName"] != DBNull.Value ? row["DriverName"].ToString() : string.Empty,
                            DriverId = row["DriverId"] != DBNull.Value ? Convert.ToInt32(row["DriverId"]) : 0



                        });

                return ambulanceDos;
            }
        }
        //add ambulance admin
        public List<AmbulanceDo> AddAmb(AmbulanceDo ambulanceDo)
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


                List<AmbulanceDo> ambulanceDos = new List<AmbulanceDo>();
                ambulanceDos = AmbList("");
                return ambulanceDos;
            
        }

        //outpatient Edit

        public AmbulanceDo AmbEdit(int Id)
        {
            AmbulanceDo ambulanceDo = new AmbulanceDo();



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
                    ambulanceDo.DriverId = reader["DriverId"] != DBNull.Value ? Convert.ToInt32(reader["DriverId"]) : 0;







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

            cmd = new SqlCommand("Delete from Amb where Id='" + Id + "'", con);

         

            cmd.ExecuteNonQuery();
            con.Close();

            List<AmbulanceDo> ambulanceDos = new List<AmbulanceDo>();

            con.Open();

            cmd = new SqlCommand("select * from Amb", con);

        

            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                AmbulanceDo ambulanceDo = new AmbulanceDo();

                ambulanceDo.Id = Convert.ToInt32(reader["Id"]);
                ambulanceDo.Name = reader["Name"] != DBNull.Value ? reader["Name"].ToString() : string.Empty;
                ambulanceDo.AmbulanceId = reader["AmbulanceId"] != DBNull.Value ? Convert.ToInt32(reader["AmbulanceId"]) : 0;
                ambulanceDo.AmbulanceStatus = reader["AmbulanceStatus"] != DBNull.Value ? reader["AmbulanceStatus"].ToString() : string.Empty;

                ambulanceDo.DriverName = reader["DriverName"] != DBNull.Value ? reader["DriverName"].ToString() : string.Empty;
                ambulanceDo.DriverId = reader["DriverId"] != DBNull.Value ? Convert.ToInt32(reader["DriverId"]) : 0;






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

            cmd = new SqlCommand("SELECT MAX(Id) FROM Amb", con);

            

            var result = cmd.ExecuteScalar();

            if (result != DBNull.Value)
            {
                id = Convert.ToInt32(result);
            }
            con.Close();
            return id;
        }




        //Driver  List admin

        public List<DriverDo> DriveList(string Dri)
        {
            List<DriverDo> driverDos = new List<DriverDo>();

            {

                con.Open();



                cmd = new SqlCommand("select * from Drivers where DriverName like'%" + Dri + "%'", con);

                SqlDataReader sdr;
                sdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(sdr);
                foreach (DataRow row in dt.Rows)
                    driverDos.Add(
                        new DriverDo
                        {
                            Id = Convert.ToInt32(row["Id"]),
                            DriverName = row["DriverName"] != DBNull.Value ? row["DriverName"].ToString() : string.Empty,
                            DriverId = row["DriverId"] != DBNull.Value ? Convert.ToInt32(row["DriverId"]) : 0,
                             Contact = row["Contact"] != DBNull.Value ? row["Contact"].ToString() : string.Empty,
                            Address = row["Address"] != DBNull.Value ? row["Address"].ToString() : string.Empty,
                            CNIC = row["CNIC"] != DBNull.Value ? row["CNIC"].ToString() : string.Empty,


                        });

                return driverDos;
            }
        }

        //add Driver
        public List<DriverDo> AddDrive(DriverDo driverDo)
        {
            var ids = 0;
            con.Open();
            cmd = new SqlCommand("select * from Drivers where Id='" + driverDo.Id + "'", con);
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
                cmd = new SqlCommand("insert into Drivers(Id,DriverName,DriverId,Contact,Address,CNIC) values(" + driverDo.Id + ",'" + driverDo.DriverName + "','" + driverDo.DriverId + "','" + driverDo.Contact + "','" + driverDo.Address + "','" + driverDo.CNIC + "')", con);

            }
            else
            {
                cmd = new SqlCommand("update Drivers set DriverName='" + driverDo.DriverName + "',DriverId='" + driverDo.DriverId + "',Contact='" + driverDo.Contact + "',Address='" + driverDo.Address + "',CNIC='" + driverDo.CNIC + "' where Id=" + driverDo.Id + "", con);
            }
            cmd.ExecuteNonQuery();
            con.Close();


            List<DriverDo> driverDos = new List<DriverDo>();
            driverDos = DriveList("");
            return driverDos;
        }


        //Id Increment
        public int DriverRId()
        {
            int id = 0; // Default to 1 in case there are no records
            con.Open();
            cmd = new SqlCommand("SELECT MAX(Id) FROM Drivers", con);
            var result = cmd.ExecuteScalar(); // Use ExecuteScalar for a single value

            // Check if result is null
            if (result != DBNull.Value)
            {
                id = Convert.ToInt32(result); // Increment the maximum ID
            }

            con.Close();
            return id;
        }

        //Edit driver

        public DriverDo DriveREdit(int Id)
        {
            DriverDo driverDo = new DriverDo();

            SqlCommand cmd = new SqlCommand("Select * from Drivers where Id='" + Id + "'", con);
            {

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                if (reader.Read())
                {
                    driverDo.Id = Convert.ToInt32(reader["Id"]);
                    driverDo.DriverName = reader["DriverName"].ToString();
                    driverDo.DriverId = Convert.ToInt32(reader["DriverId"]);
                    driverDo.Contact = reader["Contact"].ToString();
                    driverDo.Address = reader["Address"].ToString();
                    driverDo.CNIC = reader["CNIC"].ToString();

                }
                reader.Close();
                con.Close();

            }
            return driverDo;
        }

        //delete driver
        public List<DriverDo> DriveRDelete(int Id)
        {
            con.Open();
            cmd = new SqlCommand("Delete from Drivers where Id='" + Id + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();

            List<DriverDo> driverDos = new List<DriverDo>();

            con.Open();
            cmd = new SqlCommand("select * from Drivers", con);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                DriverDo driverDo = new DriverDo();

                driverDo.Id = Convert.ToInt32(reader["Id"]);
                driverDo.DriverName = reader["DriverName"].ToString();
                driverDo.DriverId = Convert.ToInt32(reader["DriverId"]);
                driverDo.Contact = reader["Contact"].ToString();
                driverDo.Address = reader["Address"].ToString();
                driverDo.CNIC = reader["CNIC"].ToString();


                driverDos.Add(driverDo);

            }

            reader.Close();
            con.Close();
            return driverDos;
        }
    }
}