using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;
using Hospital_System.Models;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.DynamicData;



namespace Hospital_System.DAL
{
    public class DoctorDAL
    {

        string _connectionString;
        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataReader reader = null;

        public string Department { get; private set; }
        public string Id { get; private set; }

        public DoctorDAL()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Hospital"].ConnectionString;
            con = new SqlConnection(_connectionString);
        }


        public string NewDoctor(Doctors doctors)
        {

            var ids = 0;
            con.Open();
            cmd = new SqlCommand("select * from Ward where Id='" + doctors.Id + "'", con);
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
                cmd = new SqlCommand("insert into Ward(Id,Name,Department,Designation,Education,PhoneNumber,Gender,Status) values(" + doctors.Id + ",'" + doctors.Name + "','" + doctors.Department + "','" + doctors.Designation + "','" + doctors.Education + "','" + doctors.PhoneNumber + "','" + doctors.Gender + "','" + doctors.Status + "')", con);

            }
            else
            {
                cmd = new SqlCommand("update Ward set Name='" + doctors.Name + "',Department='" + doctors.Department + "',Designation='" + doctors.Designation + "',Education='" + doctors.Education + "',PhoneNumber='" + doctors.PhoneNumber + "',Gender='" + doctors.Gender + "',Status='" + doctors.Status + "' where Id='" + doctors.Id + "'", con);
            }
            cmd.ExecuteNonQuery();
            con.Close();
            return "NewDoctor";



            //con.Open();
            //cmd = new SqlCommand("insert into Ward values('" + doctors.Name + "','" + doctors.Department + "','" + doctors.Department + "','" + doctors.PhoneNumber + "','" + doctors.Education + "','" + doctors.Gender + "','" + doctors.Status + "')", con);
            //cmd.ExecuteNonQuery();
            //con.Close();

        }

       

        public List<Doctors> DoctorList(string Sagar)
        {
            List<Doctors> doctors = new List<Doctors>();
            
            {
                
                con.Open();
                cmd = new SqlCommand("select * from Ward where Department like'%" + Sagar +"%'", con);
                SqlDataReader sdr;
                sdr=cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(sdr);
                foreach (DataRow row in dt.Rows)
                    doctors.Add(
                        new Doctors
                        {
                            Id = Convert.ToInt32(row["ID"]),
                            Name = row["Name"].ToString(),
                            Department = row["Department"].ToString(),
                            Designation = row["Designation"].ToString(),
                            PhoneNumber = row["PhoneNumber"].ToString(),
                            Education = row["Education"].ToString(),
                            Gender = row["Gender"].ToString(),
                            Status = row["Status"].ToString(),

                        });

                return doctors;
            }



        }

        //[HttpPost]
        public Doctors DEdit(int Id)
        {
            Doctors doctors = new Doctors();

            SqlCommand cmd = new SqlCommand("Select * from Ward where Id='" + Id + "'", con);
            {
                
                    con.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                if (reader.Read())
                {
                    

                    doctors.Id = Convert.ToInt32(reader["Id"]);
                    doctors.Name = reader["Name"].ToString();
                    doctors.Department=reader["Department"].ToString();
                    doctors.Designation = reader["Designation"].ToString();
                    doctors.Education = reader["Education"].ToString();
                    doctors.PhoneNumber = reader["PhoneNumber"].ToString();
                    doctors.Gender = reader["Gender"].ToString();
                    doctors.Status = reader["Status"].ToString();

                }
                reader.Close();
                con.Close();
               
            }
            return doctors;
        }

        private string HttpNotFound()
        {
            throw new NotImplementedException();
        }

        public List<Doctors> DDelete(int Id)
        {
            con.Open();
            cmd = new SqlCommand("Delete from Ward where Id='" + Id + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();

            List<Doctors> doctors1 = new List<Doctors>();

            con.Open();
            cmd = new SqlCommand("select * from Ward", con);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Doctors doctors = new Doctors();

                doctors.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                doctors.Name = reader.GetString(reader.GetOrdinal("Name"));
                doctors.Department = reader.GetString(reader.GetOrdinal("Department"));
                doctors.Designation = reader.GetString(reader.GetOrdinal("Designation"));
                doctors.Education = reader.GetString(reader.GetOrdinal("Education"));
                doctors.PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber"));
                doctors.Gender = reader.GetString(reader.GetOrdinal("Gender"));
                doctors.Status = reader.GetString(reader.GetOrdinal("Status"));
                
                doctors1.Add(doctors);

            }

            reader.Close();
            con.Close();
            return doctors1;
        }


        public List<MPrescription> GetPrecList()
        {
            List<MPrescription> mPrescriptions = new List<MPrescription>();
            {
                con.Open();
                cmd = new SqlCommand("select * from Prec", con);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                { 
                    MPrescription mPrescription = new MPrescription();

                    mPrescription.PatientName=reader.GetString(reader.GetOrdinal("PatientName"));
                    mPrescription.DoctorName = reader.GetString(reader.GetOrdinal("DoctorName"));
                    mPrescription.Problem = reader.GetString(reader.GetOrdinal("Problem"));
                    mPrescription.Medicine = reader.GetString(reader.GetOrdinal("Medicine"));
                    mPrescription.Morning = reader.GetString(reader.GetOrdinal("Morning"));
                    mPrescription.Afternoon = reader.GetString(reader.GetOrdinal("Afternoon"));
                    mPrescription.Night = reader.GetString(reader.GetOrdinal("Night"));

                    mPrescriptions.Add(mPrescription);
                }

                reader.Close();
                con.Close();
                return mPrescriptions;
                
            }
        }


        public List<MAppointment> GetAppointmentList(string searchvalue)
        {
            List<MAppointment> mAppointments = new List<MAppointment>();
            {
                con.Open();
                cmd = new SqlCommand("select * from Appointment where Speciality like'%" + searchvalue + "%'", con);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    MAppointment mAppointment = new MAppointment();

                    mAppointment.DoctorName = reader.GetString(reader.GetOrdinal("DoctorName"));
                    mAppointment.Speciality = reader.GetString(reader.GetOrdinal("Speciality"));
                    mAppointment.Education = reader.GetString(reader.GetOrdinal("Education"));
                    mAppointment.Timings = reader.GetString(reader.GetOrdinal("Timings"));
                    mAppointment.Status = reader.GetString(reader.GetOrdinal("Status"));
                  
                    

                    mAppointments.Add(mAppointment);
                }

                reader.Close();
                con.Close();
                return mAppointments;

            }
        }

        public string BookAppointment(MAppointment mAppointment)
        {
            con.Open();
            cmd = new SqlCommand("insert into BookApp values('" + mAppointment.PatientName + "','" + mAppointment.PatientType + "','" + mAppointment.Problem + "','" + mAppointment.PhoneNumber + "','" + mAppointment.Address + "','" + mAppointment.Date + "','"+mAppointment.Time+"')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            return "BookAppointment";
        }


        public string RegistrationPage(MRegistration mRegistration)
        {
            con.Open();
            cmd = new SqlCommand("insert into Registration values('" + mRegistration.UserName + "','" + mRegistration.FirstName + "','" + mRegistration.LastName + "','" + mRegistration.Password + "','" + mRegistration.Email + "','" + mRegistration.PhoneNumber + "','" + mRegistration.Gender + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            return "Login";
        }

    }
}