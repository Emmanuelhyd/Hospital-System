using AdminPages.Models;
using Hospital_System.Models;
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
using System.Net;
using System.Net.Mail;
using System.Drawing;
using Hospital_System.Viewmodel;
using System.Web.UI;
using System.Net.Cache;




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
            var sqlq = "select  PatientId, UserName, Password,Email,Type from profiles where UserName='"+ patients.UserNameOrEmail + "' or Email ='"+patients.UserNameOrEmail+"' and Password='"+ patients.Password+"'";
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
                string Email = reader.GetString(reader.GetOrdinal("Email"));
                int Type = Convert.ToInt32(reader["Type"]);


                if (!reader.IsDBNull(reader.GetOrdinal("Type")))
                {
                    patients.Type = reader.GetInt32(reader.GetOrdinal("Type")); 
                }

                if ( (patients.UserNameOrEmail ==dbUserName|| patients.UserNameOrEmail == Email) && patients.Password==dbPassword)
                {
                   
                    res="success";
                    patients.Email = Email;

                   
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



        //public void SendOTPtoMail(string Email, string OTP)
        //{
        //    var subject = $"Your One Time Password";
        //    var Body = $" Your OTP is :{OTP}. It is valid only for 5 minutes." +
        //        $"Please do not reply";
        //    con.Open();
        //    MailMessage mail = new MailMessage();
        //    mail.From = new MailAddress("softwares910@gmail.com");
        //    mail.To.Add(Email);
        //    mail.Subject = subject;
        //    mail.Body = Body;

        //    var smtp = new SmtpClient("smtp.gmail.com", 587);

        //    smtp.EnableSsl = true;
        //    smtp.Credentials = new NetworkCredential("softwares910@gmail.com", "hmnr gpko jlsr advg");
        //    smtp.Send(mail);
        //    con.Close();

        //}




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

            patients.Type = 3;
            con.Open();
            var sqlq = "insert into profiles values('" + patients.UserName + "','" + patients.FirstName + "','" + patients.LastName + "','" + patients.Email + "','" + patients.Password + "','" + patients.BloodGroup + "','" + patients.Gender + "','" + patients.Age + "','" + patients.PhoneNo + "','" + patients.Address + "','" + patients.EmergencyContact + "' ,"+patients.Type+")";
            cmd = new SqlCommand(sqlq, con);
            res = cmd.ExecuteNonQuery().ToString();
            con.Close();
            return res;
        }

        public string Updateprofile(Patients patients)
        {   string res = "";

           

            con.Open();
           
            cmd = new SqlCommand("update profiles set UserName='"+patients.UserName+"'," +
                " FirstName='" + patients.FirstName + "'," +
                "LastName='" + patients.LastName + "'," +
                "Email='" + patients.Email + "'," +
                "BloodGroup='" + patients.BloodGroup + "'," +
                "Gender='" + patients.Gender + "'," +
                "Age='" + patients.Age + "'," +
                "PhoneNo='" + patients.PhoneNo + "'," +
                "Address='" + patients.Address + "'," +
                " EmergencyContact='" + patients.EmergencyContact + "' where PatientId= "+ patients.PatientId+" ", con);
            res = cmd.ExecuteNonQuery().ToString();
            con.Close();
            return res;


        }

       



        public List<Ambulance> GetAmbulances()
        {
           
                List<Ambulance> ambulances1 = new List<Ambulance>();

                {

                    con.Open();
                    cmd = new SqlCommand("select* from amb", con);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Ambulance ambulance2 = new Ambulance();
                        {
                            ambulance2.Id = Convert.ToInt32(reader["Id"]);
                        
                            ambulance2.Name = reader.GetString(reader.GetOrdinal("Name"));
                            ambulance2.AmbulanceId = Convert.ToInt32(reader["AmbulanceId"]); ;
                            ambulance2.AmbulanceStatus = reader.GetString(reader.GetOrdinal("AmbulanceStatus"));
                            ambulance2.DriverName = reader.GetString(reader.GetOrdinal("DriverName"));
                            ambulance2.DriverId = Convert.ToInt32(reader["DriverId"]);
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
            string query = "SELECT COUNT(*) FROM DepartmentAd";
            return ExecuteCountQuery(query);
        }

        public int GetDoctorCount()
        {
            string query = "SELECT COUNT(*) FROM Doctors";
            return ExecuteCountQuery(query);
        }

        public int GetPatientCount()
        {
            string query = "SELECT COUNT(*) FROM Bookapp";
            return ExecuteCountQuery(query);
        }

        public int GetAmbulanceCount()
        {
            string query = "SELECT COUNT(*) FROM Amb";
            return ExecuteCountQuery(query);
        }

        public int GetDriverCount()
        {
            string query = "SELECT COUNT(*) FROM Drivers";
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
            //string query = "SELECT COUNT(*) FROM Bookapp WHERE Status = @Status";
            //SqlParameter statusParameter = new SqlParameter("@Status", SqlDbType.Bit) { Value = true };
            //return ExecuteCountQuery(query, statusParameter);
            string query = "SELECT COUNT(*) FROM Bookapp";
            return ExecuteCountQuery(query);


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
            cmd = new SqlCommand("select*from drivers", con);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                AmbulanceDriver driver = new AmbulanceDriver();

                driver.Id = Convert.ToInt32(reader["Id"]);
                driver.DriverName=reader.GetString(reader.GetOrdinal("DriverName"));
                driver.Contact =reader. GetString(reader.GetOrdinal("Contact"));
                driver.Address=reader.GetString(reader.GetOrdinal("address"));
                driver.CNIC = reader.GetString(reader.GetOrdinal("CNIC"));

                drivers.Add(driver);
            }
            reader.Close() ;
            con.Close();
            return drivers;
            
        }


        
        public AmbulanceDriver GetdriverId(int Id)
        {
            AmbulanceDriver ambulanceDriver = null;
            string res = "";
            con.Open();
            cmd = new SqlCommand("select* from drivers where Id=" + Id + "", con);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                ambulanceDriver= new AmbulanceDriver()
                {
                    Id = Convert.ToInt32(reader.GetOrdinal("Id")),
                    DriverName = reader.GetString(reader.GetOrdinal("DriverName")),
                    Contact = reader.GetString(reader.GetOrdinal("Contact")),
                    Address = reader.GetString(reader.GetOrdinal("Address")),
                    CNIC = reader.GetString(reader.GetOrdinal("CNIC")),
                   
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
            cmd = new SqlCommand("select * from doctors where Status ='Active'", con);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Doctor doctor = new Doctor();
                doctor.DoctorId = reader.IsDBNull(reader.GetOrdinal("DoctorId")) ? 0 : Convert.ToInt32(reader["DoctorId"]);
                doctor.FullName = reader.IsDBNull(reader.GetOrdinal("FullName")) ? string.Empty : reader["FullName"].ToString();
                doctor.Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? string.Empty : reader["Email"].ToString();
                doctor.Department = reader.IsDBNull(reader.GetOrdinal("Department")) ? string.Empty : reader["Department"].ToString();
                doctor.Education = reader.IsDBNull(reader.GetOrdinal("Education")) ? string.Empty : reader["Education"].ToString();
                doctor.Designation = reader.IsDBNull(reader.GetOrdinal("Designation")) ? string.Empty : reader["Designation"].ToString();
                doctor.PhoneNo = reader.IsDBNull(reader.GetOrdinal("PhoneNo")) ? string.Empty : reader["PhoneNo"].ToString();
                doctor.Status = reader.IsDBNull(reader.GetOrdinal("Status")) ? string.Empty : reader["Status"].ToString();

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
            cmd = new SqlCommand("select * from doctors where DoctorId="+DoctorId+"", con);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                doctor1 = new Doctor
                {

                    DoctorId = reader.IsDBNull(reader.GetOrdinal("DoctorId")) ? 0 : Convert.ToInt32(reader.GetValue(reader.GetOrdinal("DoctorId"))),
                    FullName = reader.GetString(reader.GetOrdinal("FullName")),
                    Email = reader.GetString(reader.GetOrdinal("Email")),
                    Department = reader.GetString(reader.GetOrdinal("Department")),
                    Education = reader.GetString(reader.GetOrdinal("Education")),
                    Designation = reader.GetString(reader.GetOrdinal("Designation")),
                    Status = reader.GetString(reader.GetOrdinal("Status")),
                    //PhotoUrl = reader.IsDBNull(reader.GetOrdinal("PhotoUrl")) ? null : reader.GetString(reader.GetOrdinal("PhotoUrl")) 
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


        
          
        public string Changepassword( Patients patients )

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


        public bool UsernameExists(string username)
        {
             int count = 0;
             con.Open();
             cmd = new SqlCommand("select * from profiles where UserName='" + username + "'", con);
             reader = cmd.ExecuteReader();
              if(reader.Read())
             {
                Patients patients = new Patients();
                patients.UserName = reader.GetString(reader.GetOrdinal("UserName"));
             }
              reader.Close();
               con.Close(); 
               return count > 0; 
                
            
        }

        
      



    }


}




    














        










