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
            string res = "";
            if (string.IsNullOrWhiteSpace(mAppointment.PatientName) ||
                string.IsNullOrWhiteSpace(mAppointment.PatientType) ||
                string.IsNullOrWhiteSpace(mAppointment.Problem) ||
                string.IsNullOrWhiteSpace(mAppointment.PhoneNumber.ToString()) || 
                string.IsNullOrWhiteSpace(mAppointment.Address) ||
                mAppointment.Date == default(DateTime) ||
                mAppointment.Time == default(TimeSpan)) 
            {
                return "Enter All the details"; 
            }

            con.Open();
            cmd = new SqlCommand("insert into BookApp values('" + mAppointment.PatientName + "','" + mAppointment.PatientType + "','" + mAppointment.Problem + "'," + mAppointment.PhoneNumber + ",'" + mAppointment.Address + "','" + mAppointment.Date + "','"+mAppointment.Time+"','"+mAppointment.Description+"')", con);
            res = cmd.ExecuteNonQuery().ToString();
            con.Close();
            return res;
        }


        
        public List<MComplaint> RegisterComplaint(MComplaint mComplaint)
        {

            var ids = 0;
            con.Open();
            cmd = new SqlCommand("select * from Complaints where Id='" + mComplaint.Id + "'", con);
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
                cmd = new SqlCommand("insert into Complaints(Id,Name,Complaint,PhoneNumber) values("+mComplaint.Id+",'" + mComplaint.Name + "','" + mComplaint.Complaint + "','" + mComplaint.PhoneNumber + "')", con);

            }
            else
            {
                cmd = new SqlCommand("update Complaints set Name='" + mComplaint.Name + "',Complaint='" + mComplaint.Complaint + "',PhoneNumber='" + mComplaint.PhoneNumber + "' where Id='" + mComplaint.Id + "'", con);
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
                            Reply = row["reply"].ToString()


                        });

                return mComplaints;
            }
        }

        public MComplaint CEdit(int Id)
        {
            MComplaint mComplaint = new MComplaint();

            SqlCommand cmd = new SqlCommand("Select * from Complaints where Id='" + Id + "'", con);
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
            cmd = new SqlCommand("select* from doctors where Department like '%" + searchvalue + "%'", con);
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
        
    }
}