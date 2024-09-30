﻿using Hospital_System.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml.Linq;



namespace Hospital_System.DAL
{


    public class Patient1
    {

        string _connectionString = "";
        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataReader reader = null;
        SqlDataAdapter adapter = null;


        public Patient1()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Hospital"].ConnectionString;
            con = new SqlConnection(_connectionString);
        }


        
        public string Login(Patients patients)
        {
            string res = " ";
            con.Open();
            var sqlq = "select  PatientId, UserName, Password from profiles where UserName='"+ patients.UserName+"' and Password='"+ patients.Password+"'";
            cmd = new SqlCommand(sqlq, con);
            reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                if (!reader.IsDBNull(reader.GetOrdinal("PatientId")))
                    {
                       
                        decimal patientIdValues = reader.GetDecimal(reader.GetOrdinal("PatientId"));
                        patients.PatientId = Convert.ToInt32(patientIdValues); 
                    }
                string dbUserName = reader.GetString(reader.GetOrdinal("UserName"));
                string dbPassword = reader.GetString(reader.GetOrdinal("Password")); //


                if ( patients.UserName ==dbUserName && patients.Password==dbPassword)
                {
                   
                    res="success";
                }
                else
                {
                    res = "Invalid UserName or Password";
                }
               

            }
            reader.Close();
            con.Close();
            return res;
        }


        public string Insertprofile(Patients patients)
        {
            string res = " ";
            if (string.IsNullOrWhiteSpace(patients.UserName) ||
                string.IsNullOrWhiteSpace(patients.FirstName) ||
                string.IsNullOrWhiteSpace(patients.LastName) ||
                string.IsNullOrWhiteSpace(patients.Email) ||
                string.IsNullOrWhiteSpace(patients.Password) ||
                string.IsNullOrWhiteSpace(patients.PhoneNo) )
            
            {
                return "Enter All the details";
            }
            con.Open();
            var sqlq = "insert into profiles values('" + patients.UserName + "','" + patients.FirstName + "','" + patients.LastName + "','" + patients.Email + "','" + patients.Password + "','" + patients.BloodGroup + "','" + patients.Gender + "','" + patients.Age + "','" + patients.PhoneNo + "','" + patients.Address + "','" + patients.EmergencyContact + "')";
            cmd = new SqlCommand(sqlq, con);
            res = cmd.ExecuteNonQuery().ToString();
            con.Close();
            return res;
        }

        public string Updateprofile(Patients patients )
        {
            

                string res = "";

            if (string.IsNullOrWhiteSpace(patients.UserName) ||
               string.IsNullOrWhiteSpace(patients.FirstName) ||
               string.IsNullOrWhiteSpace(patients.Email) ||
               string.IsNullOrWhiteSpace(patients.BloodGroup) ||
               string.IsNullOrWhiteSpace(patients.Gender) ||
               string.IsNullOrWhiteSpace(patients.Age)||
                string.IsNullOrWhiteSpace(patients.PhoneNo) ||
                 string.IsNullOrWhiteSpace(patients.Address))
            {
                return "Enter All the Details ";
            }

                con.Open();
            cmd = new SqlCommand("update profiles set FirstName='" + patients.FirstName + "',LastName='" + patients.LastName + "',Email='" + patients.Email + "',BloodGroup='" + patients.BloodGroup + "',Gender='" + patients.Gender + "',Age='" + patients.Age + "',PhoneNo='" + patients.PhoneNo + "',Address='" + patients.Address + "', EmergencyContact='" + patients.EmergencyContact + "' where UserName='" + patients.UserName + "'", con);
            res = cmd.ExecuteNonQuery().ToString();
            con.Close();
            return res;


        }


        public List<Ambulance> GetAmbulances()
        {
           
                List<Ambulance> ambulances1 = new List<Ambulance>();

                {

                    con.Open();
                    cmd = new SqlCommand("select* from ambulance", con);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Ambulance ambulance2 = new Ambulance();
                        {
                            ambulance2.Id = Convert.ToInt32(reader["Id"]);
                        
                            ambulance2.Name = reader.GetString(reader.GetOrdinal("Name"));
                            ambulance2.AmbulanceId = Convert.ToInt32(reader["AmbulanceId"]); ;
                            ambulance2.AmbulanceStatus = reader.GetString(reader.GetOrdinal("AmbulanceStatus"));
                            ambulance2.AmbulanceDriver = reader.GetString(reader.GetOrdinal("AmbulanceDriver"));
                            ambulance2.AmbulanceDriverId = Convert.ToInt32(reader["AmbulanceDriverId"]);
                    };
                        ambulances1.Add(ambulance2);
                    }
                    reader.Close();
                    con.Close();
                    return ambulances1;
                }
            
        }

        private int ExecuteCountQuery(string query, params SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddRange(parameters);

                connection.Open();
                return (int)command.ExecuteScalar();
            }
        }

        public int GetDepartmentCount()
        
        {
            string query = "SELECT COUNT(*) FROM Department";
            return ExecuteCountQuery(query);
        }

        public int GetDoctorCount()
        {
            string query = "SELECT COUNT(*) FROM Doctors";
            return ExecuteCountQuery(query);
        }

        public int GetPatientCount()
        {
            string query = "SELECT COUNT(*) FROM Patients";
            return ExecuteCountQuery(query);
        }

        public int GetAmbulanceCount()
        {
            string query = "SELECT COUNT(*) FROM Ambulance";
            return ExecuteCountQuery(query);
        }

        public int GetDriverCount()
        {
            string query = "SELECT COUNT(*) FROM Driver";
            return ExecuteCountQuery(query);
        }

        public int GetMedicineCount(decimal patientId)
        {
            string query = "SELECT COUNT(*) FROM Medicine WHERE PatientId = @PatientId";
            SqlParameter patientIdParameter = new SqlParameter("@PatientId", SqlDbType.Decimal) { Value = patientId };

            return ExecuteCountQuery(query, patientIdParameter);

        }

        public int GetActiveAppointmentsCount()
        {
            string query = "SELECT COUNT(*) FROM Appointments WHERE Status = @Status";
            SqlParameter statusParameter = new SqlParameter("@Status", SqlDbType.Bit) { Value = true };
            return ExecuteCountQuery(query, statusParameter);
        }

        public int GetPendingAppointmentsCount()
        {
            string query = "SELECT COUNT(*) FROM Appointments WHERE Status = @Status";
            SqlParameter statusParameter = new SqlParameter("@Status", SqlDbType.Bit) { Value = false };
            return ExecuteCountQuery(query, statusParameter);
        }


        public List<AmbulanceDriver> GetAmbulanceDrivers()

        {
            List<AmbulanceDriver>drivers= new List<AmbulanceDriver>();
            con.Open();
            cmd = new SqlCommand("select*from driver", con);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                AmbulanceDriver driver = new AmbulanceDriver();

                driver.DriverId = Convert.ToInt32(reader["DriverId"]);
                driver.Name=reader.GetString(reader.GetOrdinal("Name"));
                driver.Contact =reader. GetString(reader.GetOrdinal("Name"));
                driver.Address=reader.GetString(reader.GetOrdinal("address"));
                driver.Cnic = reader.GetString(reader.GetOrdinal("Cnic"));

                drivers.Add(driver);
            }
            reader.Close() ;
            con.Close();
            return drivers;
            
        }



        public AmbulanceDriver GetdriverId(int DriverId)
        {
            AmbulanceDriver ambulanceDriver = null;
            string res = "";
            con.Open();
            cmd = new SqlCommand("select* from driver where DriverId=" + DriverId + "", con);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                ambulanceDriver= new AmbulanceDriver()
                {
                    DriverId = (int)reader.GetDecimal(reader.GetOrdinal("DriverId")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    Contact = reader.GetString(reader.GetOrdinal("Contact")),
                    Address = reader.GetString(reader.GetOrdinal("Address")),
                    Cnic = reader.GetString(reader.GetOrdinal("Cnic")),
                   
                };
            }


            reader.Close();
            con.Close();
            return ambulanceDriver;
        }



        public List<Doctor>GetDoctors( )
        {
            List<Doctor> doctors= new List<Doctor>();
            con.Open();
            cmd = new SqlCommand("select* from doctors", con);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Doctor doctor = new Doctor();
                doctor. DoctorId =(int) reader.GetDecimal(reader.GetOrdinal("DoctorId"));
                doctor.FullName = reader.GetString(reader.GetOrdinal("FullName"));
                doctor.Email = reader.GetString(reader.GetOrdinal("Email"));
                doctor.Department = reader.GetString(reader.GetOrdinal("department"));
                doctor.Education = reader.GetString(reader.GetOrdinal("Education"));
                doctor.Designation = reader.GetString(reader.GetOrdinal("designation"));
                doctor.Status = reader.GetString(reader.GetOrdinal("status"));
                doctor. PhotoUrl = reader.IsDBNull(reader.GetOrdinal("PhotoUrl")) ? null : reader.GetString(reader.GetOrdinal("PhotoUrl"));
                doctors.Add(doctor);

            }

            reader.Close();
            con.Close();
            return doctors;
        }


     

        public Doctor GetDoctorsId( int DoctorId)
        {
            Doctor doctor1 = null;
            string res = "";
            con.Open();
            cmd = new SqlCommand("select* from doctors where DoctorId="+DoctorId+"", con);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                doctor1 = new Doctor
                {
                    DoctorId = (int)reader.GetDecimal(reader.GetOrdinal("DoctorId")),
                    FullName = reader.GetString(reader.GetOrdinal("FullName")),
                    Email = reader.GetString(reader.GetOrdinal("Email")),
                    Department = reader.GetString(reader.GetOrdinal("Department")),
                    Education = reader.GetString(reader.GetOrdinal("Education")),
                    Designation = reader.GetString(reader.GetOrdinal("Designation")),
                    Status = reader.GetString(reader.GetOrdinal("Status")),
                    PhotoUrl = reader.IsDBNull(reader.GetOrdinal("PhotoUrl")) ? null : reader.GetString(reader.GetOrdinal("PhotoUrl")) 
                };
            }

           
            reader.Close();
            con.Close();
            return doctor1;
        }






        public List<Medicine> GetMedicines(decimal patientId )
        {

            List<Medicine> medicines = new List<Medicine>();
            con.Open();
            cmd = new SqlCommand("select *from medicine where PatientId=" +patientId + "", con);
            reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                Medicine medicinee = new Medicine();

                medicinee.PatientId = Convert.ToInt32(reader.GetOrdinal("PatientId"));
                medicinee.PatientName = reader.GetString(reader.GetOrdinal("PatientName"));
                medicinee.DoctorName = reader.GetString(reader.GetOrdinal("DoctorName"));
                medicinee.Description = reader.GetString(reader.GetOrdinal("Description"));
                medicinee.Problem = reader.GetString(reader.GetOrdinal("Problem"));
                medicinee.MedicineName = reader.GetString(reader.GetOrdinal("MedicineName"));
                medicinee.Morning = reader.GetString(reader.GetOrdinal("Morning"));
                medicinee.Afternoon = reader.GetString(reader.GetOrdinal("Afternoon"));
                medicinee.Night = reader.GetString(reader.GetOrdinal("Night"));

                medicines.Add(medicinee);



            }

            reader.Close();
            con.Close();
            return medicines;
        }


        
          
        public string Changepassword(Patients patients )

        {
            string res = "";
            con.Open();
            cmd = new SqlCommand("Update profiles set Password='" + patients.Password + "' where UserName='" + patients.UserName + "'", con);
            res = cmd.ExecuteNonQuery().ToString();
            con.Close();
            return res;
           
        }
        public string Forgotpassword(Patients patients)

        {
            string res = "";
            if (string.IsNullOrWhiteSpace(patients.UserName) ||
             string.IsNullOrWhiteSpace(patients.Password) ||
             string.IsNullOrWhiteSpace(patients.ConfirmPassword))
             {
                return "Enter All the details";
            }
          con.Open();
            cmd = new SqlCommand("Update profiles set Password='" + patients.Password + "' where UserName='" + patients.UserName + "'", con);
            res = cmd.ExecuteNonQuery().ToString();
            con.Close();
            return res;

        }



     
            
     }


}




    














        










