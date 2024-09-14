using Hospital_System.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
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



            _connectionString = ConfigurationManager.ConnectionStrings["abc"].ConnectionString;
            con = new SqlConnection(_connectionString);
        }


        //public string Loginn(Patients patients)
        //{
        //    con.Open();

        //    cmd = new SqlCommand("insert into patients values('" + patients.UserName + "','" + patients.Password + "')", con);
        //    cmd.ExecuteNonQuery();
        //    con.Close();


        //    return "Added Successfully";
        //}


        // }


        public string Login(Custom custom)
        {



            string res = "Invalid UserId or Pass";
            con.Open();
            cmd = new SqlCommand("select *from manage where UserName='"+custom.UserName+"' and Password='"+custom.Password+"' ", con);
            reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                if(custom.UserName==reader.GetString(0) && custom.Password==reader.GetString(1))
                {
                   res="success";
                }
               

            }
            reader.Close();
            con.Close();
            return res;
        }


        public string Updateprofilee(Patients patients)
        {
            string res = "";

            con.Open();
            cmd = new SqlCommand("update profile set FirstName='" + patients.FirstName + "',LastName='" + patients.LastName + "',Password='" + patients.Password + "',BloodGroup='" + patients.BloodGroup + "',Gender='" + patients.Gender + "',Age='" + patients.Age + "',PhoneNo='" + patients.PhoneNo + "',Address='" + patients.Address + "', EmergencyContact='" + patients.EmergencyContact + "' where Email='" + patients.Email + "'", con);
            cmd.ExecuteNonQuery();
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

        public int GetMedicineCount()
        {
            string query = "SELECT COUNT(*) FROM Medicine";
            return ExecuteCountQuery(query);
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


        public List<Department> GetDepartments()
        {
           
                List<Department> department1 = new List<Department>();
                {
                    
                    con.Open();
                    cmd = new SqlCommand("select*from department", con);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Department departments = new Department();

                        departments.Id = reader.GetString(reader.GetOrdinal("id")); ;
                        departments.Name = reader.GetString(reader.GetOrdinal("Name"));
                        departments.Description = reader.GetString(reader.GetOrdinal("description"));
                        departments.Status = reader.GetString(reader.GetOrdinal("Status"));

                    department1.Add(departments);
                }

                    
                    
                }

                   reader.Close();
                   con.Close();
                   return department1;



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

                driver.Id = reader.GetString(reader.GetOrdinal("id"));
                driver.Name=reader.GetString(reader.GetOrdinal("Name"));
                driver.Contact = reader.GetString(reader.GetOrdinal("Contact"));
                driver.Address=reader.GetString(reader.GetOrdinal("address"));
                driver.Cnic = reader.GetString(reader.GetOrdinal("cnic"));

                drivers.Add(driver);
            }
            reader.Close() ;
            con.Close();
            return drivers;
            
        }

            public List<Doctor>GetDoctors()
        {
            List<Doctor> doctors= new List<Doctor>();
            con.Open();
            cmd = new SqlCommand("select* from doctors", con);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Doctor doctor = new Doctor();

                doctor.FullName = reader.GetString(reader.GetOrdinal("FullName"));
                doctor.Email = reader.GetString(reader.GetOrdinal("Email"));
                doctor.Department = reader.GetString(reader.GetOrdinal("department"));
                doctor.Specialization = reader.GetString(reader.GetOrdinal("specialization"));
                doctor.Designation = reader.GetString(reader.GetOrdinal("designation"));
                doctor.Status = reader.GetString(reader.GetOrdinal("status"));
                doctors.Add(doctor);



            }

            reader.Close();
            con.Close();
            return doctors;
        }

        //public List<Patients>GetPatients()
        //{
        //    List<Patients> patients = new List<Patients>();
        //    con.Open();
        //    cmd = new SqlCommand("select *from patients", con);
        //    reader = cmd.ExecuteReader();
        //    while(reader.Read())
        //    {
        //        Patients patients2 = new Patients();

        //        patients2.FirstName = reader.GetString(reader.GetOrdinal("FirstName"));




        //    }
        //    con.Close();

        //}
            public List<Medicine> GetMedicines()
        {

            List<Medicine> medicines = new List<Medicine>();
            con.Open();
            cmd = new SqlCommand("select*from medicine", con);
            reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                Medicine medicine = new Medicine();

                medicine.Name = reader.GetString(reader.GetOrdinal("name"));
                medicine.Description = reader.GetString(reader.GetOrdinal("Description"));

                medicines.Add(medicine);



            }

            reader.Close();
            con.Close();
            return medicines;
        }


        public string Complaint(Complain complain)

        {
            con.Open();
            cmd = new SqlCommand("insert into complaintt values('"+complain.Id+"','" + complain.Complaint + "','"+complain.Reply+"','"+complain.ComplainDate+"')", con);
            cmd.ExecuteNonQuery();
            con.Close();

            return "Added Complain";
        }

        public List<Complain> GetComplains( string searchvalue)
        {

            List<Complain> complains = new List<Complain>();
            con.Open();
            cmd = new SqlCommand("select*from complaintt where complaint like '%" +searchvalue+"%'", con);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Complain complain = new Complain();

                complain.Complaint = reader.GetString(reader.GetOrdinal("Complaint"));
               



                complains.Add(complain);



            }

            reader.Close();
            con.Close();
            return complains;
        }


        public string Changepassword(Custom custom )

        {
            con.Open();
            cmd = new SqlCommand("update passwords set Newpassword='" + custom.NewPassword + "', ConfirmPassword='" + custom.NewPassword + "'where Oldpassword='" + custom.Password + "'", con);
           

            cmd.ExecuteNonQuery();
            con.Close();
            return "Updated";
        }

        public string EditComplain(Complain complain)
        {
           
            List<Complain> complains = new List<Complain>();
            con.Open();
            cmd = new SqlCommand("select * from complaintt where complaint  = '"+ complain.Complaint  + "'", con);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Complain complain1 = new Complain();

                complain1.Complaint = reader.GetString(reader.GetOrdinal("Complaint"));
                return "success";

            }

           
                else
                {
                    return "No record found";
                }
            
            
        }


    }
}



    














        










