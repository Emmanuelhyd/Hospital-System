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
using Hospital_System.BAL;
using Hospital_System.Viewmodel;



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



        public List<MAppointment> GetAppointmentList(string searchvalue)
        {
            List<MAppointment> mAppointments = new List<MAppointment>();
            {
                con.Open();
                cmd = new SqlCommand("select * from bookapp where PatientName like'%" + searchvalue + "%'", con);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    MAppointment mAppointment = new MAppointment();


                    mAppointment.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                    mAppointment.PatientName = reader.GetString(reader.GetOrdinal("PatientName"));
                    mAppointment.PatientType = reader.GetString(reader.GetOrdinal("PatientType"));
                    mAppointment.Gender = reader.GetString(reader.GetOrdinal("Gender"));
                    mAppointment.Problem = reader.GetString(reader.GetOrdinal("Problem"));
                    mAppointment.PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber"));
                    mAppointment.Address = reader.GetString(reader.GetOrdinal("Address"));
                    mAppointment.Date = reader.GetString(reader.GetOrdinal("Date"));
                    mAppointment.Time = reader.GetString(reader.GetOrdinal("Time"));
                    mAppointment.Description = reader.GetString(reader.GetOrdinal("Description"));
                   



                    mAppointments.Add(mAppointment);
                }

                reader.Close();
                con.Close();
                return mAppointments;

            }
        }

        public string BookAppointment(MAppointment mAppointment)
        {
            string res = "Booked successfully";
            if (string.IsNullOrWhiteSpace(mAppointment.PatientName) ||
                string.IsNullOrWhiteSpace(mAppointment.PatientType) ||
                string.IsNullOrWhiteSpace(mAppointment.Problem) ||
                string.IsNullOrWhiteSpace(mAppointment.PhoneNumber.ToString()) ||
                string.IsNullOrWhiteSpace(mAppointment.Address) )
               
                
                //mAppointment.Date == default(DateTime) ||
                //mAppointment.Time == default(TimeSpan))
            {
                return "Enter All the details";
            }

            var ids = 0;
            con.Open();
            cmd = new SqlCommand("select * from bookapp where Id='" + mAppointment.Id + "'", con);
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
                cmd = new SqlCommand("insert into bookapp(Id,PatientName,PatientType,Gender,Problem,PhoneNumber,Address,Date,Time,Description) values(" + mAppointment.Id + ",'" + mAppointment.PatientName + "','" + mAppointment.PatientType + "','" + mAppointment.Gender + "','" + mAppointment.Problem + "','" + mAppointment  .PhoneNumber + "','" + mAppointment.Address + "','" + mAppointment.Date + "','" + mAppointment.Time + "','" + mAppointment.Description + "')", con);

            }
            cmd.ExecuteNonQuery();
            con.Close();

            List<MAppointment> mAppointments = new List<MAppointment>();
            //mAppointment = GetAppointmentList();
            return res;

            // con.Open();
            // cmd = new SqlCommand("insert into bookapp(Id,PatientName,PatientType,Gender,Problem,PhoneNumber,Address,Date,Time,Description) values("+mAppointment.Id+",'" + mAppointment.PatientName + "','" + mAppointment.PatientType + "','"+mAppointment.Gender+"','" + mAppointment.Problem + "'," + mAppointment.PhoneNumber + ",'" + mAppointment.Address + "','" + mAppointment.Date + "','"+mAppointment.Time+"','"+mAppointment.Description+"')", con);
            //cmd.ExecuteNonQuery();
            // con.Close();
            // return res;
        }

        public int AppointmentId()
        {
            int id = 0; // Default to 1 in case there are no records
            con.Open();
            cmd = new SqlCommand("SELECT MAX(Id) FROM bookapp", con);
            var result = cmd.ExecuteScalar(); // Use ExecuteScalar for a single value

            // Check if result is null
            if (result != DBNull.Value)
            {
                id = Convert.ToInt32(result); // Increment the maximum ID
            }

            con.Close();
            return id;
        }


        public List<MComplaint> RegisterComplaint(MComplaint mComplaint)
        {

            var ids = 0;
            con.Open();
            cmd = new SqlCommand("select * from complaints where Id='" + mComplaint.Id + "'", con);
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
                cmd = new SqlCommand("insert into complaints(Id,Name,Complaint,PhoneNumber) values(" + mComplaint.Id+",'" + mComplaint.Name + "','" + mComplaint.Complaint + "','" + mComplaint.PhoneNumber + "')", con);

            }
            else
            {
                cmd = new SqlCommand("update complaints set Name='" + mComplaint.Name + "',Complaint='" + mComplaint.Complaint + "',PhoneNumber='" + mComplaint.PhoneNumber + "' where Id='" + mComplaint.Id + "'", con);
            }
            cmd.ExecuteNonQuery();
            con.Close();
            List<MComplaint> mComplaints = new List<MComplaint>();
            mComplaints = ComplaintList();
            return mComplaints;
        }

        public List<MComplaint> ComplaintList()
        {
            List<MComplaint> mComplaints = new List<MComplaint>();

            {

                con.Open();
                cmd = new SqlCommand("select * from complaints ", con);
                SqlDataReader sdr;
                sdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(sdr);
                foreach (DataRow row in dt.Rows)
                    mComplaints.Add(
                        new MComplaint
                        {
                            Id = Convert.ToInt32(row["Id"]),
                            Name = row["Name"].ToString(),
                            Complaint = row["Complaint"].ToString(),
                            PhoneNumber = row["PhoneNumber"].ToString(),
                            Replay = row["Replay"].ToString(),

                        });

                return mComplaints;
            }
        }

        public MComplaint CEdit(int Id)
        {
            MComplaint mComplaint = new MComplaint();

            SqlCommand cmd = new SqlCommand("Select * from complaints where Id='" + Id + "'", con);
            {

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                if (reader.Read())
                {
                    mComplaint.Id = Convert.ToInt32(reader["Id"]);
                    mComplaint.Name = reader["Name"].ToString();
                    mComplaint.Complaint = reader["Complaint"].ToString();
                    mComplaint.PhoneNumber = reader["PhoneNumber"].ToString();

                }
                reader.Close();
                con.Close();

            }
            return mComplaint;
        }


        public List<Doctor> GetDoctors( string searchvalue)
        {
            List<Doctor> doctors = new List<Doctor>();
            con.Open();
            cmd = new SqlCommand("select* from doctors where Department like '%" + searchvalue + "%'  or FullName like '%" +searchvalue+"%' or PhoneNo like'%"+searchvalue+"%'" , con);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Doctor doctor = new Doctor();

                doctor.FullName = reader.GetString(reader.GetOrdinal("FullName"));
                doctor.Email = reader.GetString(reader.GetOrdinal("Email"));
                doctor.Education = reader.GetString(reader.GetOrdinal("Education"));
                doctor.Department = reader.GetString(reader.GetOrdinal("Department"));
                doctor.PhoneNo = reader.GetString(reader.GetOrdinal("PhoneNo"));
                doctor.Status = reader.GetString(reader.GetOrdinal("status"));

                doctors.Add(doctor);

            }

            reader.Close();
            con.Close();
            return doctors;
        }

        public int dynamicint()
        {
                int id = 0; 
                con.Open();
                cmd = new SqlCommand("SELECT MAX(Id) FROM complaints", con);
           
                var result = cmd.ExecuteScalar(); 

                
                if (result != DBNull.Value)
                {
                    id = Convert.ToInt32(result); 
                }

                con.Close();
                return id;
            
        }

        //AppointmentList

        public List<MAppointmentAd> BookList()
        {
            List<MAppointmentAd> mAppointmentAds = new List<MAppointmentAd>();

            {

                con.Open();
                cmd = new SqlCommand("select * from bookapp", con);
                SqlDataReader sdr;
                sdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(sdr);
                foreach (DataRow row in dt.Rows)
                    mAppointmentAds.Add(
                        new MAppointmentAd
                        {
                            Id = Convert.ToInt32(row["Id"]),
                            PatientName = row["PatientName"].ToString(),
                            PatientType = row["PatientType"].ToString(),
                            Gender = row["Gender"].ToString(),
                            Problem = row["Problem"].ToString(),
                            PhoneNumber = row["PhoneNumber"].ToString(),
                            Address = row["Address"].ToString(),
                            Date = row["Date"].ToString(),
                            Time = row["Time"].ToString(),
                            Description = row["Description"].ToString(),
                            Department= row["Department"].ToString()


                        });

                return mAppointmentAds;
            }
        }

        //>>>>>>>>>>>>>>////add Appointment



        public List<MAppointmentAd> AddBook(MAppointmentAd mAppointmentAd)
        {

            var ids = 0;
            con.Open();
            cmd = new SqlCommand("select * from bookapp where Id='" + mAppointmentAd.Id + "'", con);
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
                cmd = new SqlCommand("INSERT INTO bookapp (Id, PatientName, PatientType, Gender, Problem, PhoneNumber, Address, Date, Time, Description, Department) VALUES (" +
                             mAppointmentAd.Id + ", '" +
                             mAppointmentAd.PatientName + "', '" +
                             mAppointmentAd.PatientType + "', '" +
                             mAppointmentAd.Gender + "', '" +
                             mAppointmentAd.Problem + "', '" +
                             mAppointmentAd.PhoneNumber + "', '" +
                             mAppointmentAd.Address + "', '" +
                             mAppointmentAd.Date + "', '" +
                             mAppointmentAd.Time + "', '" +
                             mAppointmentAd.Description + "', '" +
                             mAppointmentAd.Department + "')", con);

            }
            else
            {
                cmd = new SqlCommand("update bookapp set PatientName='" + mAppointmentAd.PatientName + "',PatientType='" + mAppointmentAd.PatientType + "',Gender='" + mAppointmentAd.Gender + "',Problem='" + mAppointmentAd.Problem + "',PhoneNumber='" + mAppointmentAd.PhoneNumber + "',Address='" + mAppointmentAd.Address + "',Date='" + mAppointmentAd.Date + "',Time='" + mAppointmentAd.Time + "',Description='" + mAppointmentAd.Description + "',Department= '"+mAppointmentAd.Department+"' where Id=" + mAppointmentAd.Id + "", con);
            }
            cmd.ExecuteNonQuery();
            con.Close();


            List<MAppointmentAd> mAppointmentAds = new List<MAppointmentAd>();
            mAppointmentAds = BookList();
            return mAppointmentAds;
        }


        //AppointmentId Auto Increment Id
        public int BookId()
        {
            int id = 0; // Default to 1 in case there are no records
            con.Open();
            cmd = new SqlCommand("SELECT MAX(Id) FROM bookapp", con);
            var result = cmd.ExecuteScalar(); // Use ExecuteScalar for a single value

            // Check if result is null
            if (result != DBNull.Value)
            {
                id = Convert.ToInt32(result); // Increment the maximum ID
            }

            con.Close();
            return id;
        }

    }
}