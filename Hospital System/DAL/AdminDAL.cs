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
using System.Collections;

namespace Hospital_System.DAL
{
    public class AdminDAL
    {
        string _connectionString;
        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataReader reader = null;

        public AdminDAL()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Hospital"].ConnectionString;
            con = new SqlConnection(_connectionString);
        }

        private int ExecuteCountQuery(string query, params SqlParameter[] parameters)
        {
            try
            {
                cmd = new SqlCommand(query, con);

               
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                con.Open(); // Open the connection manually
                return (int)cmd.ExecuteScalar(); // Execute the count query
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., log them)
                throw; // Rethrow or handle as needed
            }
            finally
            {
                con.Close(); // Ensure the connection is closed
            }
        }

        public int GetMDepartmentCount()
        {
            string query = "SELECT COUNT(*) FROM DepartmentAd";
            return ExecuteCountQuery(query);
        }

        public int GetMDoctorCount()
        {
            string query = "SELECT COUNT(*) FROM doctors";
            return ExecuteCountQuery(query);
        }

        public int GetMPatientCount()
        {
            string query = "SELECT COUNT(*) FROM PatientAd";
            return ExecuteCountQuery(query);
        }

        public int GetMAmbulanceCount()
        {
            string query = "SELECT COUNT(*) FROM Ambulance";
            return ExecuteCountQuery(query);
        }

        public int GetMAnnouncementCount()
        {
            string query = "SELECT COUNT(*) FROM AnnouncementAd";
            return ExecuteCountQuery(query);
        }
        public int GetMAppointmentCount()
        {
            string query = "SELECT COUNT(*) FROM bookapp";
            return ExecuteCountQuery(query);
        }
        public int GetMComplaintAdCount()
        {
            string query = "SELECT COUNT(*) FROM complaints";
            return ExecuteCountQuery(query);
        }
        public int GetMDriverAdCount()
        {
            string query = "SELECT COUNT(*) FROM driver";
            return ExecuteCountQuery(query);
        }
        public int GetMMedicineAdCount()
        {
            string query = "SELECT COUNT(*) FROM medicine";
            return ExecuteCountQuery(query);
        }
        public int GetMSheduleCount()
        { 
            string query = "SELECT COUNT(*) FROM SheduleAd";
            return ExecuteCountQuery(query);
        }

        //public int GetMedicineCount(decimal patientId)
        //{
        //    string query = "SELECT COUNT(*) FROM Medicine WHERE PatientId = @PatientId";
        //    SqlParameter patientIdParameter = new SqlParameter("@PatientId", SqlDbType.Decimal) { Value = patientId };
        //    return ExecuteCountQuery(query, patientIdParameter);
        //}

        //public int GetActiveAppointmentsCount()
        //{
        //    string query = "SELECT COUNT(*) FROM Appointments WHERE Status = @Status";
        //    SqlParameter statusParameter = new SqlParameter("@Status", SqlDbType.Bit) { Value = true };
        //    return ExecuteCountQuery(query, statusParameter);
        //}

        //public int GetPendingAppointmentsCount()
        //{
        //    string query = "SELECT COUNT(*) FROM Appointments WHERE Status = @Status";
        //    SqlParameter statusParameter = new SqlParameter("@Status", SqlDbType.Bit) { Value = false };
        //    return ExecuteCountQuery(query, statusParameter);
        //}



        //UpdateProfile List
        public List<UpdateDO> UpdateList()
        {
            List<UpdateDO> updateDOs = new List<UpdateDO>();

            {

                con.Open();
                cmd = new SqlCommand("select * from profiles", con);
                SqlDataReader sdr;
                sdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(sdr);
                foreach (DataRow row in dt.Rows)
                    updateDOs.Add(
                        new UpdateDO
                        {
                            PatientId = Convert.ToInt32(row["PatientId"]),
                            UserName = row["UserName"].ToString(),
                            FirstName = row["FirstName"].ToString(),
                            LastName = row["LastName"].ToString(),
                            Email = row["Email"].ToString(),
                            Password = row["Password"].ToString(),
                            BloodGroup = row["BloodGroup"].ToString(),
                            Gender = row["Gender"].ToString(),
                            Age = row["Age"].ToString(),
                            PhoneNo = row["PhoneNo"].ToString(),
                            EmergencyContact = row["EmergencyContact"].ToString(),
                            Address = row["Address"].ToString(),
                            Type = Convert.ToInt32(row["Type"]),


                        });

                return updateDOs;
            }
        }

        //add profile

        public List<UpdateDO> AddProfile(UpdateDO updateDO)
        {

            var ids = 0;
            con.Open();
            cmd = new SqlCommand("select * from profiles where PatientId='" + updateDO.PatientId + "'", con);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                ids = Convert.ToInt32(reader["PatientId"]);
            }

            reader.Close();
            con.Close();



            con.Open();
            if (ids == 0)
            {
                cmd = new SqlCommand("insert into profiles(PatientId,UserName,FirstName,LastName,Email,BloodGroup,Gender,Age,PhoneNo,EmergencyContact,Address,Type) values(" + updateDO.PatientId + ",'" + updateDO.UserName + "','" + updateDO.FirstName + "','" + updateDO.LastName + "','" + updateDO.Email + "','" + updateDO.BloodGroup + "','" + updateDO.Gender + "','" + updateDO.Age + "','" + updateDO.PhoneNo + "','" + updateDO.Age + "','" + updateDO.Address + "'," + updateDO.Type + ")", con);

            }
            else
            {
                cmd = new SqlCommand("update profiles set UserName='" + updateDO.UserName + "',FirstName='" + updateDO.FirstName + "',LastName='" + updateDO.LastName + "',Email='" + updateDO.Email + "',BloodGroup='" + updateDO.BloodGroup + "',Gender='" + updateDO.Gender + "',Age='" + updateDO.Age + "',PhoneNo='" + updateDO.PhoneNo + "',EmergencyContact='" + updateDO.EmergencyContact + "',Address='" + updateDO.Address + "',Type='" + updateDO.Type + "' where PatientId=" + updateDO.PatientId + "", con);
            }
            cmd.ExecuteNonQuery();
            con.Close();


            List<UpdateDO> updateDOs = new List<UpdateDO>();
            updateDOs = UpdateList();
            return updateDOs;
        }

        //increment ProfileId

        public int ProfileId()
        {
            int id = 0; // Default to 1 in case there are no records
            con.Open();
            cmd = new SqlCommand("SELECT MAX(PatientId) FROM profiles", con);
            var result = cmd.ExecuteScalar(); // Use ExecuteScalar for a single value

            // Check if result is null
            if (result != DBNull.Value)
            {
                id = Convert.ToInt32(result); // Increment the maximum ID
            }

            con.Close();
            return id;
        }

        // Profile Edit

        public UpdateDO ProfileEdit(int PatientId)
        {
            UpdateDO updateDO = new UpdateDO();


            SqlCommand cmd = new SqlCommand("Select * from profiles where PatientId='" + PatientId + "'", con);
            {

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                if (reader.Read())
                {
                    updateDO.PatientId = Convert.ToInt32(reader["PatientId"]);
                    updateDO.UserName = reader["UserName"].ToString();
                    updateDO.FirstName = reader["FirstName"].ToString();
                    updateDO.LastName = reader["LastName"].ToString();
                    updateDO.Email = reader["Email"].ToString();
                    updateDO.BloodGroup = reader["BloodGroup"].ToString();
                    updateDO.Gender = reader["Gender"].ToString();
                    updateDO.Age = reader["Age"].ToString();
                    updateDO.PhoneNo = reader["PhoneNo"].ToString();
                    updateDO.EmergencyContact = reader["EmergencyContact"].ToString();
                    updateDO.Address = reader["Address"].ToString();
                    updateDO.Type = Convert.ToInt32(reader["Type"]);

                }
                reader.Close();
                con.Close();

            }
            return updateDO;
        }
        // profile department

        public List<UpdateDO> ProfileDelete(int PatientId)
        {
            con.Open();
            cmd = new SqlCommand("Delete from Profiles where PatientId='" + PatientId + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();

            List<UpdateDO> updateDOs = new List<UpdateDO>();

            con.Open();
            cmd = new SqlCommand("select * from Profiles", con);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                UpdateDO updateDO = new UpdateDO();


                updateDO.PatientId = Convert.ToInt32(reader["PatientId"]);
                updateDO.UserName = reader["UserName"].ToString();
                updateDO.FirstName = reader["FirstName"].ToString();
                updateDO.LastName = reader["LastName"].ToString();
                updateDO.Email = reader["Email"].ToString();
                updateDO.BloodGroup = reader["BloodGroup"].ToString();
                updateDO.Gender = reader["Gender"].ToString();
                updateDO.Age = reader["Age"].ToString();
                updateDO.PhoneNo = reader["PhoneNo"].ToString();
                updateDO.EmergencyContact = reader["EmergencyContact"].ToString();
                updateDO.Address = reader["Address"].ToString();
                updateDO.Type = Convert.ToInt32(reader["Type"]);

                updateDOs.Add(updateDO);

            }

            reader.Close();
            con.Close();
            return updateDOs;
        }








        //departmentList
        public List<MDepartment> DepartmentList(string dep)
        {
            List<MDepartment> mDepartments = new List<MDepartment>();

            {

                con.Open();
                cmd = new SqlCommand("select * from DepartmentAd where DepartmentName like'%" + dep + "%'", con);
                SqlDataReader sdr;
                sdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(sdr);
                foreach (DataRow row in dt.Rows)
                    mDepartments.Add(
                        new MDepartment
                        {
                            Id = Convert.ToInt32(row["Id"]),
                            DepartmentName = row["DepartmentName"].ToString(),
                            Description = row["Description"].ToString(),
                            Status = row["Status"].ToString(),

                        });

                return mDepartments;
            }
        }

        //add department

        public List<MDepartment> AddDepartment(MDepartment mDepartment)
        {

            var ids = 0;
            con.Open();
            cmd = new SqlCommand("select * from DepartmentAd where Id='" + mDepartment.Id + "'", con);
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
                cmd = new SqlCommand("insert into DepartmentAd(Id,DepartmentName,Description,Status) values(" + mDepartment.Id + ",'" + mDepartment.DepartmentName + "','" + mDepartment.Description + "','" + mDepartment.Status + "')", con);

            }
            else
            {
                cmd = new SqlCommand("update DepartmentAd set DepartmentName='" + mDepartment.DepartmentName + "',Description='" + mDepartment.Description + "',Status='" + mDepartment.Status + "' where Id=" + mDepartment.Id + "", con);
            }
            cmd.ExecuteNonQuery();
            con.Close();


            List<MDepartment> mDepartments = new List<MDepartment>();
            mDepartments = DepartmentList("");
            return mDepartments;
        }

        //department edit

        public MDepartment DLEdit(int Id)
        {
            MDepartment mDepartment = new MDepartment();

           
            SqlCommand cmd = new SqlCommand("Select * from DepartmentAd where Id='" + Id + "'", con);
            {

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                if (reader.Read())
                {
                    mDepartment.Id = Convert.ToInt32(reader["Id"]);
                    mDepartment.DepartmentName = reader["DepartmentName"].ToString();
                    mDepartment.Description = reader["Description"].ToString();
                    mDepartment.Status = reader["Status"].ToString();

                }
                reader.Close();
                con.Close();

            }
            return mDepartment;
        }
        // delete department

        public List<MDepartment> DLDelete(int Id)
        {
            con.Open();
            cmd = new SqlCommand("Delete from DepartmentAd where Id='" + Id + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();

            List<MDepartment> mDepartments = new List<MDepartment>();

            con.Open();
            cmd = new SqlCommand("select * from DepartmentAd", con);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                MDepartment mDepartment = new MDepartment();

                mDepartment.Id = Convert.ToInt32(reader["Id"]);
                mDepartment.DepartmentName = reader["DepartmentName"].ToString();
                mDepartment.Description = reader["Description"].ToString();
                mDepartment.Status = reader["Status"].ToString();

                mDepartments.Add(mDepartment);

            }

            reader.Close();
            con.Close();
            return mDepartments;
        }


        ////Doctor List
        public List<MDoctorAd> DoctorListAd(string doc)
        {
            List<MDoctorAd> mDoctors = new List<MDoctorAd>();

            {

                con.Open();
                cmd = new SqlCommand("select * from doctors where FullName like'%" + doc + "%'", con);
                SqlDataReader sdr;
                sdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(sdr);
                foreach (DataRow row in dt.Rows)
                    mDoctors.Add(
                        new MDoctorAd
                        {
                            DoctorId = Convert.ToInt32(row["DoctorId"]),
                            FullName = row["FullName"].ToString(),
                            Firstname = row["Firstname"].ToString(),
                            LastName = row["LastName"].ToString(),
                            Email = row["Email"].ToString(),
                            Department = row["Department"].ToString(),
                            Designation = row["Designation"].ToString(),
                            PhoneNo = row["PhoneNo"].ToString(),
                            ContactNo = row["ContactNo"].ToString(),
                            Education = row["Education"].ToString(),
                            //Gender = row["Gender"].ToString(),
                            Status = row["Status"].ToString(),

                        });

                return mDoctors;
            }
        }

        //Add doctor
       
        public List<MDoctorAd> AddDoctorAd(MDoctorAd mDoctorAd)
        {


            var ids = 0;
            con.Open();
            cmd = new SqlCommand("select * from doctors where DoctorId='" + mDoctorAd.DoctorId + "'", con);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                ids = Convert.ToInt32(reader["DoctorId"]);
            }

            reader.Close();
            con.Close();

            con.Open();
            if (ids == 0)
            {
                cmd = new SqlCommand("insert into doctors(DoctorId,FullName,FirstName,LastName,Email,Department,Designation,PhoneNo,ContactNo,Education,Status) values(" + mDoctorAd.DoctorId + ",'" + mDoctorAd.FullName + "','" + mDoctorAd.Firstname + "','" + mDoctorAd.LastName+ "','" + mDoctorAd.Email + "','" + mDoctorAd.Department + "','" + mDoctorAd.Designation + "','" + mDoctorAd.PhoneNo + "','" + mDoctorAd.ContactNo +"','" + mDoctorAd.Education + "','" + mDoctorAd.Status + "')", con);

            }
            else
            {
                cmd = new SqlCommand("update doctors set FullName='" + mDoctorAd.FullName + "',FirstName='" + mDoctorAd.Firstname + "',LastName='" + mDoctorAd.LastName + "',Email='" + mDoctorAd.Email + "',Department='" + mDoctorAd.Department + "',Designation='" + mDoctorAd.Designation + "',PhoneNo='" + mDoctorAd.PhoneNo + "',ContactNo='" + mDoctorAd.ContactNo + "',Education='" + mDoctorAd.Education + "',Status='" + mDoctorAd.Status + "' where DoctorId=" + mDoctorAd.DoctorId + "", con);
            }
                cmd.ExecuteNonQuery();
            con.Close();
            

            List<MDoctorAd> mDoctors = new List<MDoctorAd>();
            //mDoctors = DoctorListAd("");
            //return mDoctors;

            return DoctorListAd("");

        }


        //Edit Doctor
        public MDoctorAd DAEdit(int DoctorId)
        {
            MDoctorAd mDoctor = new MDoctorAd();

            SqlCommand cmd = new SqlCommand("Select * from doctors where DoctorId='" + DoctorId + "'", con);
            {

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                if (reader.Read())
                {
                    mDoctor.DoctorId = Convert.ToInt32(reader["DoctorId"]);
                    mDoctor.FullName = reader["FullName"].ToString();
                    mDoctor.Firstname = reader["Firstname"].ToString();
                    mDoctor.LastName = reader["LastName"].ToString();
                    mDoctor.Email = reader["Email"].ToString();
                    mDoctor.Department = reader["Department"].ToString();
                    mDoctor.Designation = reader["Designation"].ToString();
                    mDoctor.PhoneNo = reader["PhoneNo"].ToString();
                    mDoctor.ContactNo = reader["ContactNo"].ToString();
                    mDoctor.Education = reader["Education"].ToString();
                    //mDoctor.Gender = reader["Gender"].ToString();
                    mDoctor.Status = reader["Status"].ToString();

                }
                reader.Close();
                con.Close();

            }
            return mDoctor;
        }
        //Delete Doctor

        public List<MDoctorAd> DADelete(int DoctorId)
        {
            con.Open();
            cmd = new SqlCommand("Delete from doctors where DoctorId='" + DoctorId + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();

            List<MDoctorAd> mDoctors = new List<MDoctorAd>();

            con.Open();
            cmd = new SqlCommand("select * from doctors", con);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                MDoctorAd mDoctor = new MDoctorAd();

                mDoctor.DoctorId = Convert.ToInt32(reader["DoctorId"]);
                mDoctor.FullName = reader.GetString(reader.GetOrdinal("FullName"));
                mDoctor.Firstname = reader.GetString(reader.GetOrdinal("Firstname"));
                mDoctor.LastName = reader.GetString(reader.GetOrdinal("LastName"));
                mDoctor.Email = reader.GetString(reader.GetOrdinal("Email"));
                mDoctor.Department = reader.GetString(reader.GetOrdinal("Department"));
                mDoctor.Designation = reader.GetString(reader.GetOrdinal("Designation"));
                mDoctor.PhoneNo = reader.GetString(reader.GetOrdinal("PhoneNo"));
                mDoctor.ContactNo = reader.GetString(reader.GetOrdinal("ContactNo"));
                mDoctor.Education = reader.GetString(reader.GetOrdinal("Education"));
                //mDoctor.Gender = reader.GetString(reader.GetOrdinal("Gender"));
                mDoctor.Status = reader.GetString(reader.GetOrdinal("Status"));

                mDoctors.Add(mDoctor);

            }

            reader.Close();
            con.Close();
            return mDoctors;
        }


        //patient list

        public List<MPatient> PatientList(string patient)
        {
            List<MPatient> mPatients = new List<MPatient>();

            {

                con.Open();
                cmd = new SqlCommand("select * from PatientAd where Name like'%" + patient +"%'", con);
                SqlDataReader sdr;
                sdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(sdr);
                foreach (DataRow row in dt.Rows)
                    mPatients.Add(
                        new MPatient
                        {
                            Id = Convert.ToInt32(row["Id"]),
                            Name = row["Name"].ToString(),
                            PhoneNumber = Convert.ToInt64(row["PhoneNumber"]),
                            BloodGroup = row["BloodGroup"].ToString(),
                            Gender = row["Gender"].ToString(),
                           

                        });

                return mPatients;
            }
        }
        //add patient
        public List<MPatient> AddPatientAd(MPatient mPatient)
        {

            var ids = 0;
            con.Open();
            cmd = new SqlCommand("select * from PatientAd where Id='" + mPatient.Id + "'", con);
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
                cmd = new SqlCommand("insert into PatientAd(Id,Name,PhoneNumber,BloodGroup,Gender) values(" + mPatient.Id + ",'" + mPatient.Name + "','" + mPatient.PhoneNumber + "','" + mPatient.BloodGroup + "','"+ mPatient .Gender+ "')", con);

            }
            else
            {
                cmd = new SqlCommand("update PatientAd set Name='" + mPatient.Name + "',PhoneNumber='" + mPatient.PhoneNumber + "',BloodGroup='" + mPatient.BloodGroup + "',Gender='" + mPatient.Gender+"' where Id=" + mPatient.Id + "", con);
            }
            cmd.ExecuteNonQuery();
            con.Close();


            List<MPatient> mPatients = new List<MPatient>();
            mPatients = PatientList("");
            return mPatients;
        }

        //edit patient

        public MPatient PatientEdit(int Id)
        {
            MPatient mPatient = new MPatient();

            SqlCommand cmd = new SqlCommand("Select * from PatientAd where Id='" + Id + "'", con);
            {

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                if (reader.Read())
                {
                    mPatient.Id = Convert.ToInt32(reader["Id"]);
                    mPatient.Name = reader["Name"].ToString();
                    mPatient.PhoneNumber = Convert.ToInt64(reader["PhoneNumber"]);
                    mPatient.BloodGroup = reader["BloodGroup"].ToString();
                    mPatient.Gender = reader["Gender"].ToString();

                }
                reader.Close();
                con.Close();

            }
            return mPatient;
        }

        //delete patient

        public List<MPatient> PatientDelete(int Id)
        {
            con.Open();
            cmd = new SqlCommand("Delete from PatientAd where Id='" + Id + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();

            List<MPatient> mPatients = new List<MPatient>();

            con.Open();
            cmd = new SqlCommand("select * from PatientAd", con);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                MPatient mPatient = new MPatient();

                mPatient.Id = Convert.ToInt32(reader["Id"]);
                mPatient.Name = reader["Name"].ToString();
                mPatient.PhoneNumber = Convert.ToInt64(reader["PhoneNumber"]);
                mPatient.BloodGroup = reader["BloodGroup"].ToString();
                mPatient.Gender = reader["Gender"].ToString();

                mPatients.Add(mPatient);

            }

            reader.Close();
            con.Close();
            return mPatients;
        }


        



        //shedule list

        public List<MShedule> SheduleList(string Shedule)
        {
            List<MShedule> mShedules = new List<MShedule>();

            {

                con.Open();
                cmd = new SqlCommand("select * from SheduleAd where DoctorName like'%" + Shedule + "%'", con);
                SqlDataReader sdr;
                sdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(sdr);
                foreach (DataRow row in dt.Rows)
                    mShedules.Add(
                        new MShedule
                        {
                            Id = Convert.ToInt32(row["Id"]),
                            DoctorName = row["DoctorName"].ToString(),
                            StartTime = row["StartTime"].ToString(),
                            EndTime = row["EndTime"].ToString(),
                            status = row["status"].ToString(),

                        });

                return mShedules;
            }
        }
        //add shedule

        public List<MShedule> AddSheduleAd(MShedule mShedule)
        {

            var ids = 0;
            con.Open();
            cmd = new SqlCommand("select * from SheduleAd where Id='" + mShedule.Id + "'", con);
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
                cmd = new SqlCommand("insert into SheduleAd(Id,DoctorName,StartTime,EndTime,status) values(" + mShedule.Id + ",'" + mShedule.DoctorName + "','" + mShedule.StartTime + "','" + mShedule.EndTime + "','" + mShedule.status + "')", con);
            }
            else
            {
                cmd = new SqlCommand("update SheduleAd set DoctorName='" + mShedule.DoctorName + "',StartTime='" + mShedule.StartTime + "',EndTime='" + mShedule.EndTime + "',status='" + mShedule.status + "' where Id=" + mShedule.Id + "", con);
            }
            cmd.ExecuteNonQuery();
            con.Close();

          
            List<MShedule> mShedules = new List<MShedule>();
            mShedules = SheduleList("");
            return mShedules;
        }



        //edit shedule

        public MShedule SLEdit(int Id)
        {
            MShedule mShedule = new MShedule();
            SqlCommand cmd = new SqlCommand("Select * from SheduleAd where Id='" + Id + "'", con);
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    mShedule.Id = Convert.ToInt32(reader["Id"]);
                    mShedule.DoctorName = reader["DoctorName"].ToString();
                    mShedule.StartTime = reader["StartTime"].ToString();
                    mShedule.EndTime = reader["EndTime"].ToString();
                    mShedule.status = reader["status"].ToString();
                }
                reader.Close();
                con.Close();
            }
            return mShedule;
        }

        //delete shedule
        public List<MShedule> SheduleDelete(int Id)
        {
            con.Open();
            cmd = new SqlCommand("Delete from SheduleAd where Id='" + Id + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            List<MShedule> mShedules = new List<MShedule>();
            con.Open();
            cmd = new SqlCommand("select * from SheduleAd", con);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                MShedule mShedule = new MShedule();
                mShedule.Id = Convert.ToInt32(reader["Id"]);
                mShedule.DoctorName = reader["DoctorName"].ToString();
                mShedule.StartTime = reader["StartTime"].ToString();
                mShedule.EndTime = reader["EndTime"].ToString();
                mShedule.status = reader["status"].ToString();
                mShedules.Add(mShedule);
            }
            reader.Close();
            con.Close();
            return mShedules;
        }


        //Announcement List

        public List<MAnnouncement> AnnouncementList(string announcement )
        {
            List<MAnnouncement> mAnnouncements = new List<MAnnouncement>();
            {
                con.Open();
                cmd = new SqlCommand("select * from AnnouncementAd where Announcement like'%" + announcement +"%'", con);
                SqlDataReader sdr;
                sdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(sdr);
                foreach (DataRow row in dt.Rows)
                    mAnnouncements.Add(
                    new MAnnouncement
                    {
                        Id = Convert.ToInt32(row["Id"]),
                        Announcement = row["Announcement"].ToString(),
                        AnnouncementFor = row["AnnouncementFor"].ToString(),
                        EndDate = row["EndDate"].ToString(),
                    });
                return mAnnouncements;
            }
        }

        //add announcement

        public List<MAnnouncement> AddAnnouncementAd(MAnnouncement mAnnouncement)
        {


           
            var ids = 0;
            con.Open();
            cmd = new SqlCommand("select * from AnnouncementAd where Id='"+mAnnouncement.Id+"'",  con);
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
                cmd = new SqlCommand("insert into AnnouncementAd(Id,Announcement,AnnouncementFor,EndDate) values(" + mAnnouncement.Id + ",'" + mAnnouncement.Announcement + "','" + mAnnouncement.AnnouncementFor + "','" + mAnnouncement.EndDate + "')", con);

            }
            else
            {
                cmd = new SqlCommand("update AnnouncementAd set Announcement='" + mAnnouncement.Announcement + "',AnnouncementFor='" + mAnnouncement.AnnouncementFor + "',EndDate='" + mAnnouncement.EndDate + "' where Id=" + mAnnouncement.Id + "", con);
            }
            cmd.ExecuteNonQuery();
            con.Close();
            

            List<MAnnouncement> mAnnouncements = new List<MAnnouncement>();
            mAnnouncements = AnnouncementList("");
            return mAnnouncements;
        }



        //edit announcement

        public MAnnouncement ALEdit(int Id)
        {
            MAnnouncement mAnnouncement = new MAnnouncement();

            SqlCommand cmd = new SqlCommand("Select * from AnnouncementAd where Id='" + Id + "'", con);
            {

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                if (reader.Read())
                {
                    mAnnouncement.Id = Convert.ToInt32(reader["Id"]);
                    mAnnouncement.Announcement = reader["Announcement"].ToString();
                    mAnnouncement.AnnouncementFor = reader["AnnouncementFor"].ToString();
                    mAnnouncement.EndDate = reader["EndDate"].ToString();

                }
                reader.Close();
                con.Close();

            }
            return mAnnouncement;
        }


        //delete announcement

        public List<MAnnouncement> AnnouncementDelete(int Id)
        {
            con.Open();
            cmd = new SqlCommand("Delete from AnnouncementAd where Id='" + Id + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();

            List<MAnnouncement> mAnnouncements = new List<MAnnouncement>();

            con.Open();
            cmd = new SqlCommand("select * from AnnouncementAd", con);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                MAnnouncement mAnnouncement = new MAnnouncement();

                mAnnouncement.Id = Convert.ToInt32(reader["Id"]);
                mAnnouncement.Announcement = reader["Announcement"].ToString();
                mAnnouncement.AnnouncementFor = reader["AnnouncementFor"].ToString();
                mAnnouncement.EndDate = reader["EndDate"].ToString();

                mAnnouncements.Add(mAnnouncement);

            }

            reader.Close();
            con.Close();
            return mAnnouncements;
        }

        //AppointmentList

        public List<MAppointmentAd> AppointmentList(string app)
        {
            List<MAppointmentAd> mAppointmentAds = new List<MAppointmentAd>();

            {

                con.Open();
                cmd = new SqlCommand("select * from bookapp where PatientName like'%" + app + "%'", con);
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


                        });

                return mAppointmentAds;
            }
        }

        //>>>>>>>>>>>>>>////add Appointment



        public List<MAppointmentAd> AddAppointmentAd(MAppointmentAd mAppointmentAd)
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
                cmd = new SqlCommand("insert into bookapp(Id,PatientName,PatientType,Gender,Problem,PhoneNumber,Address,Date,Time,Description) values(" + mAppointmentAd.Id + ",'" + mAppointmentAd.PatientName + "','" + mAppointmentAd.PatientType + "','" + mAppointmentAd.Gender + "','"+mAppointmentAd.Problem+"','"+mAppointmentAd.PhoneNumber + "','"+mAppointmentAd.Address +"','"+mAppointmentAd.Date + "','"+mAppointmentAd.Time + "','"+mAppointmentAd.Description + "')", con);

            }
            else
            {
                cmd = new SqlCommand("update bookapp set PatientName='" + mAppointmentAd.PatientName + "',PatientType='" + mAppointmentAd.PatientType + "',Gender='" + mAppointmentAd.Gender + "',Problem='"+mAppointmentAd.Problem+ "',PhoneNumber='" + mAppointmentAd.PhoneNumber + "',Address='" + mAppointmentAd.Address + "',Date='" + mAppointmentAd.Date + "',Time='" + mAppointmentAd.Time + "',Description='" + mAppointmentAd.Description + "' where Id=" + mAppointmentAd.Id + "", con);
            }
            cmd.ExecuteNonQuery();
            con.Close();


            List<MAppointmentAd> mAppointmentAds = new List<MAppointmentAd>();
            mAppointmentAds = AppointmentList("");
            return mAppointmentAds;
        }




        // >>>>>>>>>>>>>>//Appointment edit



        public MAppointmentAd AppointmentEdit(int Id)
        {
            MAppointmentAd mAppointmentAd = new MAppointmentAd();

            SqlCommand cmd = new SqlCommand("Select * from bookapp where Id='" + Id + "'", con);
            {

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                if (reader.Read())
                {
                    mAppointmentAd.Id = Convert.ToInt32(reader["Id"]);
                    mAppointmentAd.PatientName = reader["PatientName"].ToString();
                    mAppointmentAd.PatientType = reader["PatientType"].ToString();
                    mAppointmentAd.Gender = reader["Gender"].ToString();
                    mAppointmentAd.Problem = reader["Problem"].ToString();
                    mAppointmentAd.PhoneNumber = reader["PhoneNumber"].ToString();
                    mAppointmentAd.Address = reader["Address"].ToString();
                    mAppointmentAd.Date = reader["Date"].ToString();
                    mAppointmentAd.Time = reader["Time"].ToString();
                    mAppointmentAd.Description = reader["Description"].ToString();

                }
                reader.Close();
                con.Close();

            }
            return mAppointmentAd;
        }


        //delete appoitment

        public List<MAppointmentAd> AppointmentAdDelete(int Id)
        {
            con.Open();
            cmd = new SqlCommand("Delete from bookapp where Id='" + Id + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();

            List<MAppointmentAd> mAppointmentAds = new List<MAppointmentAd>();

            con.Open();
            cmd = new SqlCommand("select * from bookapp", con);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                MAppointmentAd mAppointmentAd = new MAppointmentAd();

                mAppointmentAd.Id = Convert.ToInt32(reader["Id"]);
                mAppointmentAd.PatientName = reader["PatientName"].ToString();
                mAppointmentAd.PatientType = reader["PatientType"].ToString();
                mAppointmentAd.Gender = reader["Gender"].ToString();
                mAppointmentAd.Problem = reader["Problem"].ToString();
                mAppointmentAd.PhoneNumber = reader["PhoneNumber"].ToString();
                mAppointmentAd.Address = reader["Address"].ToString();
                mAppointmentAd.Date = reader["Date"].ToString();
                mAppointmentAd.Time = reader["Time"].ToString();
                mAppointmentAd.Description = reader["Description"].ToString();

                mAppointmentAds.Add(mAppointmentAd);

            }

            reader.Close();
            con.Close();
            return mAppointmentAds;
        }

        //Complaint List

        public List<MComplaintAd> ComplaintAdList()
        {
            List<MComplaintAd> mComplaintAds = new List<MComplaintAd>();

            {

                con.Open();
                cmd = new SqlCommand("select * from complaints ", con);
                SqlDataReader sdr;
                sdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(sdr);
                foreach (DataRow row in dt.Rows)
                    mComplaintAds.Add(
                        new MComplaintAd
                        {
                            Id = Convert.ToInt32(row["Id"]),
                            Name = row["Name"].ToString(),
                            Complaint = row["Complaint"].ToString(),
                            PhoneNumber = row["PhoneNumber"].ToString(),
                            Replay = row["Replay"].ToString(),
                           

                        });

                return mComplaintAds;
            }
        }

        //>>>>>>>>>>>>>>////add Complaint



        public List<MComplaintAd> AddComplaintAd(MComplaintAd mComplaintAd)
        {

            var ids = 0;
            con.Open();
            cmd = new SqlCommand("select * from complaints where Id='" + mComplaintAd.Id + "'", con);
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
                cmd = new SqlCommand("insert into complaints(Id,Name,Complaint,PhoneNumber,Replay) values('" + mComplaintAd.Id + "','" + mComplaintAd.Name + "','" + mComplaintAd.Complaint + "','" + mComplaintAd.PhoneNumber + "','" + mComplaintAd.Replay + "')", con);

            }
            else
            {
                cmd = new SqlCommand("update complaints set Name='" + mComplaintAd.Name + "',Complaint='" + mComplaintAd.Complaint + "',PhoneNumber='" + mComplaintAd.PhoneNumber + "',Replay='" + mComplaintAd.Replay + "' where Id=" + mComplaintAd.Id + "", con);
            }
            cmd.ExecuteNonQuery();
            con.Close();


            List<MComplaintAd> mComplaintAds = new List<MComplaintAd>();
            mComplaintAds = ComplaintAdList();
            return mComplaintAds;
        }




        // >>>>>>>>>>>>>>//complaint edit



        public MComplaintAd ComplaintEdit(int Id)
        {
            MComplaintAd mComplaintAd = new MComplaintAd();

            SqlCommand cmd = new SqlCommand("Select * from complaints where Id='" + Id + "'", con);
            {

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                if (reader.Read())
                {
                    mComplaintAd.Id = Convert.ToInt32(reader["Id"]);
                    mComplaintAd.Name = reader["Name"].ToString();
                    mComplaintAd.Complaint= reader["Complaint"].ToString();
                    mComplaintAd.PhoneNumber = reader["PhoneNumber"].ToString();
                    mComplaintAd.Replay = reader["Replay"].ToString();
                   
                }
                reader.Close();
                con.Close();

            }
            return mComplaintAd;
        }
        //delete complaint
        public List<MComplaintAd> ComplaintDelete(int Id)
        {
            con.Open();
            cmd = new SqlCommand("Delete from complaints where Id='" + Id + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();

            List<MComplaintAd> mComplaintAds = new List<MComplaintAd>();

            con.Open();
            cmd = new SqlCommand("select * from complaints", con);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                MComplaintAd mComplaintAd = new MComplaintAd();

                mComplaintAd.Id = Convert.ToInt32(reader["Id"]);
                mComplaintAd.Name = reader["Name"].ToString();
                mComplaintAd.Complaint = reader["Complaint"].ToString();
                mComplaintAd.PhoneNumber = reader["PhoneNumber"].ToString();
                mComplaintAd.Replay = reader["Replay"].ToString();

                mComplaintAds.Add(mComplaintAd);

            }

            reader.Close();
            con.Close();
            return mComplaintAds;
        }



        //Medicine List

        public List<MMedicineAd> MedicineAdList(string med)
        {
            List<MMedicineAd> mMedicineAds = new List<MMedicineAd>();

            {

                con.Open();
                cmd = new SqlCommand("select * from medicine where Problem like'%" + med + "%'", con);
                SqlDataReader sdr;
                sdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(sdr);
                foreach (DataRow row in dt.Rows)
                    mMedicineAds.Add(
                        new MMedicineAd
                        {
                            PatientId = Convert.ToInt32(row["PatientId"]),
                            PatientName = row["PatientName"].ToString(),
                            DoctorName = row["DoctorName"].ToString(),
                            Problem = row["Problem"].ToString(),
                            MedicineName = row["MedicineName"].ToString(),
                            Description = row["Description"].ToString(),
                            Morning = row["Morning"].ToString(),
                            Afternoon = row["Afternoon"].ToString(),
                            Night = row["Night"].ToString(),


                        });

                return mMedicineAds;
            }
        }
        //Add medicine

        public List<MMedicineAd> AddMedicineAd(MMedicineAd mMedicineAd)
        {

            var ids = 0;
            con.Open();
            cmd = new SqlCommand("select * from medicine where PatientId='" + mMedicineAd.PatientId + "'", con);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                ids = Convert.ToInt32(reader["PatientId"]);
            }

            reader.Close();
            con.Close();



            con.Open();
            if (ids == 0)
            {
                cmd = new SqlCommand("insert into medicine(PatientId,PatientName,DoctorName,Problem,MedicineName,Description,Morning,Afternoon,Night) values(" + mMedicineAd.PatientId + ",'" + mMedicineAd.PatientName + "','" + mMedicineAd.DoctorName + "','" + mMedicineAd.Problem + "','" + mMedicineAd.MedicineName + "','"+mMedicineAd.Description+"','" + mMedicineAd.Morning + "','" + mMedicineAd.Afternoon + "','" + mMedicineAd.Night + "')", con);

            }
            else
            {
                cmd = new SqlCommand("update medicine set PatientName='" + mMedicineAd.PatientName + "',DoctorName='" + mMedicineAd.DoctorName + "',Problem='" + mMedicineAd.Problem + "',MedicineName='" + mMedicineAd.MedicineName + "',Description='"+mMedicineAd.Description+"',Morning='" + mMedicineAd.Morning + "',Afternoon='" + mMedicineAd.Afternoon + "',Night='" + mMedicineAd.Night + "' where PatientId=" + mMedicineAd.PatientId + "", con);
            }
            cmd.ExecuteNonQuery();
            con.Close();


            List<MMedicineAd> mMedicineAds = new List<MMedicineAd>();
            mMedicineAds = MedicineAdList("");
            return mMedicineAds;
        }

        //Edit medicine

        public MMedicineAd MedicineEdit(int PatientId)
        {
            MMedicineAd mMedicineAd = new MMedicineAd();

            SqlCommand cmd = new SqlCommand("Select * from medicine where PatientId='" + PatientId + "'", con);
            {

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                if (reader.Read())
                {
                    mMedicineAd.PatientId = Convert.ToInt32(reader["PatientId"]);
                    mMedicineAd.PatientName = reader["PatientName"].ToString();
                    mMedicineAd.DoctorName = reader["DoctorName"].ToString();
                    mMedicineAd.Problem = reader["Problem"].ToString();
                    mMedicineAd.MedicineName = reader["MedicineName"].ToString();
                    mMedicineAd.Description = reader["Description"].ToString();
                    mMedicineAd.Morning = reader["Morning"].ToString();
                    mMedicineAd.Afternoon = reader["Afternoon"].ToString();
                    mMedicineAd.Night = reader["Night"].ToString();
                }
                reader.Close();
                con.Close();

            }
            return mMedicineAd;
        }

        //delete medicine
        public List<MMedicineAd> MedicineDelete(int PatientId)
        {
            con.Open();
            cmd = new SqlCommand("Delete from medicine where PatientId='" + PatientId + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();

            List<MMedicineAd> mMedicineAds = new List<MMedicineAd>();

            con.Open();
            cmd = new SqlCommand("select * from medicine", con);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                MMedicineAd mMedicineAd = new MMedicineAd();

                mMedicineAd.PatientId = Convert.ToInt32(reader["PatientId"]);
                mMedicineAd.PatientName = reader["PatientName"].ToString();
                mMedicineAd.DoctorName = reader["DoctorName"].ToString();
                mMedicineAd.Problem = reader["Problem"].ToString();
                mMedicineAd.MedicineName = reader["MedicineName"].ToString();
                mMedicineAd.Description = reader["Description"].ToString();
                mMedicineAd.Morning = reader["Morning"].ToString();
                mMedicineAd.Afternoon = reader["Afternoon"].ToString();
                mMedicineAd.Night = reader["Night"].ToString();

                mMedicineAds.Add(mMedicineAd);

            }

            reader.Close();
            con.Close();
            return mMedicineAds;
        }


        //Ambulance List

        public List<MAmbulance> AmbulanceListAd()
        {
            List<MAmbulance> mAmbulances = new List<MAmbulance>();

            {

                con.Open();
                cmd = new SqlCommand("select * from Ambulance", con);
                SqlDataReader sdr;
                sdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(sdr);
                foreach (DataRow row in dt.Rows)
                    mAmbulances.Add(
                        new MAmbulance
                        {
                            Id = Convert.ToInt32(row["Id"]),
                            Name = row["Name"].ToString(),
                            AmbulanceId = Convert.ToInt32(row["AmbulanceId"]),
                            AmbulanceStatus = row["AmbulanceStatus"].ToString(),
                            AmbulanceDriver = row["AmbulanceDriver"].ToString(),
                            AmbulanceDriverId = Convert.ToInt32(row["AmbulanceDriverId"]),

                        });

                return mAmbulances;
            }
        }


        //Add Ambulance

        public List<MAmbulance> AddAmbulanceAd(MAmbulance mAmbulance)
        {
            var ids = 0;
            con.Open();
            cmd = new SqlCommand("select * from Ambulance where Id='" + mAmbulance.Id + "'", con);
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
                cmd = new SqlCommand("insert into Ambulance(Id,Name,AmbulanceId,AmbulanceStatus,AmbulanceDriver,AmbulanceDriverId) values(" + mAmbulance.Id + ",'" + mAmbulance.Name + "','" + mAmbulance.AmbulanceId + "','" + mAmbulance.AmbulanceStatus + "','" + mAmbulance.AmbulanceDriver + "','" + mAmbulance.AmbulanceDriverId + "')", con);

            }
            else
            {
                cmd = new SqlCommand("update Ambulance set Name='" + mAmbulance.Name + "',AmbulanceId='" + mAmbulance.AmbulanceId + "',AmbulanceStatus='" + mAmbulance.AmbulanceStatus + "',AmbulanceDriver='" + mAmbulance.AmbulanceDriver + "',AmbulanceDriverId='" + mAmbulance.AmbulanceDriverId + "' where Id=" + mAmbulance.Id + "", con);
            }
            cmd.ExecuteNonQuery();
            con.Close();
            List<MAmbulance> mAmbulances = new List<MAmbulance>();
            mAmbulances = AmbulanceListAd();
            return mAmbulances;
        }

        //Edit Ambulance

        public MAmbulance AmbulanceEdit(int Id)
        {
            MAmbulance mAmbulance = new MAmbulance();

            SqlCommand cmd = new SqlCommand("Select * from Ambulance where Id='" + Id + "'", con);
            {

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                if (reader.Read())
                {
                    mAmbulance.Id = Convert.ToInt32(reader["Id"]);
                    mAmbulance.Name = reader["Name"].ToString();
                    mAmbulance.AmbulanceId = Convert.ToInt32(reader["AmbulanceId"]);
                    mAmbulance.AmbulanceStatus = reader["AmbulanceStatus"].ToString();
                    mAmbulance.AmbulanceDriver = reader["AmbulanceDriver"].ToString();
                    mAmbulance.AmbulanceDriverId = Convert.ToInt32(reader["AmbulanceDriverId"]);

                }
                reader.Close();
                con.Close();

            }
            return mAmbulance;
        }
        //delete Ambulance

        public List<MAmbulance> AmbulanceDelete(int Id)
        {
            con.Open();
            cmd = new SqlCommand("Delete from Ambulance where Id='" + Id + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();

            List<MAmbulance> mAmbulances = new List<MAmbulance>();

            con.Open();
            cmd = new SqlCommand("select * from AmbulanceAd", con);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                MAmbulance mAmbulance = new MAmbulance();

                mAmbulance.Id = Convert.ToInt32(reader["Id"]);
                mAmbulance.Name = reader["Name"].ToString();
                mAmbulance.AmbulanceId = Convert.ToInt32(reader["AmbulanceId"]);
                mAmbulance.AmbulanceStatus = reader["AmbulanceStatus"].ToString();
                mAmbulance.AmbulanceDriver = reader["AmbulanceDriver"].ToString();
                mAmbulance.AmbulanceDriverId = Convert.ToInt32(reader["AmbulanceDriverId"]);

                mAmbulances.Add(mAmbulance);

            }

            reader.Close();
            con.Close();
            return mAmbulances;
        }


        //Ambulance view details

        public MAmbulance Ambulance(int Id)
        {
            MAmbulance mAmbulance = null;
            con.Open();
            cmd = new SqlCommand("select * from  Ambulance where Id =" + Id + "", con);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {


                mAmbulance = new MAmbulance();

                mAmbulance.Id = Convert.ToInt32(reader["Id"]);
                mAmbulance.Name = reader.GetString(reader.GetOrdinal("Name"));
                mAmbulance.AmbulanceId = Convert.ToInt32(reader["AmbulanceId"]);
                mAmbulance.AmbulanceStatus = reader.GetString(reader.GetOrdinal("AmbulanceStatus"));
                mAmbulance.AmbulanceDriver = reader.GetString(reader.GetOrdinal("AmbulanceDriver"));
                mAmbulance.AmbulanceDriverId = Convert.ToInt32(reader["AmbulanceDriverId"]);


            }
            reader.Close();
            con.Close();
            return mAmbulance;
        }


        //Ambulance driver List

        public List<MDriverAd> AmbulanceDriverAd(string Driver)
        {
            List<MDriverAd> mDriverAds = new List<MDriverAd>();

            {

                con.Open();
                cmd = new SqlCommand("select * from driver where Name like'%" + Driver + "%'", con);
                SqlDataReader sdr;
                sdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(sdr);
                foreach (DataRow row in dt.Rows)
                    mDriverAds.Add(
                        new MDriverAd
                        {
                            Id = Convert.ToInt32(row["Id"]),
                            Name = row["Name"].ToString(),
                            Contact = row["Contact"].ToString(),
                            Address = row["Address"].ToString(),
                            CNIC = row["CNIC"].ToString(),
                           

                        });

                return mDriverAds;
            }
        }

        //Add Driver

        public List<MDriverAd> AddDriverAd(MDriverAd mDriverAd)
        {
            var ids = 0;
                con.Open();
                cmd = new SqlCommand("select * from driver where Id='" + mDriverAd.Id + "'", con);
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
                cmd = new SqlCommand("insert into driver(Id,Name,Contact,Address,CNIC) values(" + mDriverAd.Id+",'" + mDriverAd.Name + "','" + mDriverAd.Contact + "','"+mDriverAd.Address+"','" + mDriverAd.CNIC + "')", con);

            }
            else
            {
                cmd = new SqlCommand("update driver set Name='" + mDriverAd.Name + "',Contact='" + mDriverAd.Contact + "',Address='" + mDriverAd.Address + "',CNIC='"+mDriverAd.CNIC+"' where Id=" + mDriverAd.Id + "", con);
            }
            cmd.ExecuteNonQuery();
            con.Close();


            List<MDriverAd> mDepartments = new List<MDriverAd>();
            mDepartments = AmbulanceDriverAd("");
            return mDepartments;
        }

        //Edit driver

        public MDriverAd DriverEdit(int Id)
        {
            MDriverAd mDepartment = new MDriverAd();

            SqlCommand cmd = new SqlCommand("Select * from driver where Id='" + Id + "'", con);
            {

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                if (reader.Read())
                {
                    mDepartment.Id = Convert.ToInt32(reader["Id"]);
                    mDepartment.Name = reader["Name"].ToString();
                    mDepartment.Contact = reader["Contact"].ToString();
                    mDepartment.Address = reader["Address"].ToString();
                    mDepartment.CNIC = reader["CNIC"].ToString();

                }
                reader.Close();
                con.Close();

            }
            return mDepartment;
        }

        //delete driver
        public List<MDriverAd> DriverDelete(int Id)
        {
            con.Open();
            cmd = new SqlCommand("Delete from driver where Id='" + Id + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();

            List<MDriverAd> mDriverAds = new List<MDriverAd>();

            con.Open();
            cmd = new SqlCommand("select * from driver", con);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                MDriverAd mDriverAd = new MDriverAd();

                mDriverAd.Id = Convert.ToInt32(reader["Id"]);
                mDriverAd.Name = reader["Name"].ToString();
                mDriverAd.Contact = reader["Contact"].ToString();
                mDriverAd.Address = reader["Address"].ToString();
                mDriverAd.CNIC = reader["CNIC"].ToString();


                mDriverAds.Add(mDriverAd);

            }

            reader.Close();
            con.Close();
            return mDriverAds;
        }

        //driver details

        public MDriverAd Ambulancedriver(int Id)
        {
            MDriverAd mDriverAd = null;
            con.Open();
            cmd = new SqlCommand("select * from  driver where Id =" + Id + "", con);
            reader = cmd.ExecuteReader();
            if(reader.Read())
            {


               mDriverAd = new MDriverAd();
                mDriverAd.Id = Convert.ToInt32(reader["Id"]);
                mDriverAd.Name = reader.GetString(reader.GetOrdinal("Name"));
                mDriverAd.Contact = reader.GetString(reader.GetOrdinal("Contact"));
                mDriverAd.Address = reader.GetString(reader.GetOrdinal("Address"));
                mDriverAd.CNIC = reader.GetString(reader.GetOrdinal("CNIC"));

                
            }
            reader.Close() ;
            con.Close();
            return mDriverAd;
        }





        //DriverId increment
        public int DynamicId()
        {
            int id = 0; // Default to 1 in case there are no records
            con.Open();
            cmd = new SqlCommand("SELECT MAX(Id) FROM driver", con);
            var result = cmd.ExecuteScalar(); // Use ExecuteScalar for a single value

            // Check if result is null
            if (result != DBNull.Value)
            {
                id = Convert.ToInt32(result); // Increment the maximum ID
            }

            con.Close();
            return id;
        }

        //AmbulanceId Auto Increment Id
        public int AmbulanceAdId()
        {
            int id = 0; // Default to 1 in case there are no records
            con.Open();
            cmd = new SqlCommand("SELECT MAX(Id) FROM Ambulance", con);
            var result = cmd.ExecuteScalar(); // Use ExecuteScalar for a single value

            // Check if result is null
            if (result != DBNull.Value)
            {
                id = Convert.ToInt32(result); // Increment the maximum ID
            }

            con.Close();
            return id;
        }


        //AnnouncementId Auto Increment Id
        public int AnnouncementId()
        {
            int id = 0; // Default to 1 in case there are no records
            con.Open();
            cmd = new SqlCommand("SELECT MAX(Id) FROM AnnouncementAd", con);
            var result = cmd.ExecuteScalar(); // Use ExecuteScalar for a single value

            // Check if result is null
            if (result != DBNull.Value)
            {
                id = Convert.ToInt32(result); // Increment the maximum ID
            }

            con.Close();
            return id;
        }


        //AppointmentId Auto Increment Id
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


        //ComplaintId Auto Increment Id
        public int ComplaintId()
        {
            int id = 0; // Default to 1 in case there are no records
            con.Open();
            cmd = new SqlCommand("SELECT MAX(Id) FROM complaints", con);
            var result = cmd.ExecuteScalar(); // Use ExecuteScalar for a single value

            // Check if result is null
            if (result != DBNull.Value)
            {
                id = Convert.ToInt32(result); // Increment the maximum ID
            }

            con.Close();
            return id;
        }



        //DepatmentId Auto Increment Id
        public int DepartmentId()
        {
            int id = 0; // Default to 1 in case there are no records
            con.Open();
            cmd = new SqlCommand("SELECT MAX(Id) FROM DepartmentAd", con);
            var result = cmd.ExecuteScalar(); // Use ExecuteScalar for a single value

            // Check if result is null
            if (result != DBNull.Value)
            {
                id = Convert.ToInt32(result); // Increment the maximum ID
            }

            con.Close();
            return id;
        }



        //DoctorId Auto Increment Id
        public int DoctorId()
        {
            int id = 0; // Default to 1 in case there are no records
            con.Open();
            cmd = new SqlCommand("SELECT MAX(DoctorId) FROM doctors", con);
            var result = cmd.ExecuteScalar(); // Use ExecuteScalar for a single value

            // Check if result is null
            if (result != DBNull.Value)
            {
                id = Convert.ToInt32(result); // Increment the maximum ID
            }

            con.Close();
            return id;
        }


        //MedicineId Auto Increment Id
        public int MedicineId()
        {
            int id = 0; // Default to 1 in case there are no records
            con.Open();
            cmd = new SqlCommand("SELECT MAX(PatientId) FROM medicine", con);
            var result = cmd.ExecuteScalar(); // Use ExecuteScalar for a single value

            // Check if result is null
            if (result != DBNull.Value)
            {
                id = Convert.ToInt32(result); // Increment the maximum ID
            }

            con.Close();
            return id;
        }


        //PatientId Auto Increment Id
        public int PatientId()
        {
            int id = 0; // Default to 1 in case there are no records
            con.Open();
            cmd = new SqlCommand("SELECT MAX(Id) FROM PatientAd", con);
            var result = cmd.ExecuteScalar(); // Use ExecuteScalar for a single value

            // Check if result is null
            if (result != DBNull.Value)
            {
                id = Convert.ToInt32(result); // Increment the maximum ID
            }

            con.Close();
            return id;
        }



        //SheduleId Auto Increment Id
        public int SheduleId()
        {
            int id = 0; // Default to 1 in case there are no records
            con.Open();
            cmd = new SqlCommand("SELECT MAX(Id) FROM SheduleAd", con);
            var result = cmd.ExecuteScalar(); // Use ExecuteScalar for a single value

            // Check if result is null
            if (result != DBNull.Value)
            {
                id = Convert.ToInt32(result); // Increment the maximum ID
            }

            con.Close();
            return id;
        }

        public List<Adminmenu> GetAdminmenus()
        {
            List<Adminmenu> adminmenus = new List<Adminmenu>();
            string  query = "select * from adminmenu";
            using (var con = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(query, con))
            {
                con.Open();

                using (var reader = cmd.ExecuteReader()) 
                {
                    while (reader.Read())
                    {
                        Adminmenu adminmenu = new Adminmenu();

                        adminmenu.Id = Convert.ToInt32(reader["id"]);
                        adminmenu.Name = reader.GetString(reader.GetOrdinal("Name"));
                        adminmenu.Url = reader.GetString(reader.GetOrdinal("Url"));
                        adminmenu.ParentId = reader.IsDBNull(reader.GetOrdinal("ParentId")) ? (int?)null : Convert.ToInt32(reader["ParentId"]);
                        adminmenu.Isactive = reader.GetByte(reader.GetOrdinal("Isactive"));

                        adminmenus.Add(adminmenu);
                    }
                }
            }

            //reader.Close();
            //con.Close();
            return adminmenus;


        }

     

    }
}