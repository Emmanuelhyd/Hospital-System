using Hospital_System.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Hospital_System.DAL
{
    public class InpatientsDAL
    {
        string _connectionString = null;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;


        public InpatientsDAL()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Hospital"].ConnectionString;
            con = new SqlConnection(_connectionString);
        }

        public List<HospPatient> HospPatients()

        {
            List<HospPatient> hospPatients = new List<HospPatient>();
            HospPatient hospPatient = null;
            con.Open();
           string res=

                "select  Id, PatientName, Problem,AdmissionDate, DischargeDate, " +
                " CASE WHEN AdmissionDate is not null AND DischargeDate is not null AND TRY_CAST(TreatmentDuration AS INT) > 0 THEN 'Inpatient' " +
                " When AdmissionDate is null AND DischargeDate is null AND TRY_CAST(TreatmentDuration AS INT) = 0 THEN 'Outpatient' " +
                "Else 'Outpatient'END AS TypeName," +
                "TreatmentDuration,Date,Status from Bookapp ";


            cmd= new SqlCommand(res,con);
            reader = cmd.ExecuteReader();
            while (reader.Read())

            {

                hospPatient = new HospPatient();

                int ordinalId = reader.GetOrdinal("Id");
                hospPatient.Id = reader.IsDBNull(ordinalId) ? 0 : Convert.ToInt32(reader.GetValue(ordinalId));

                hospPatient.PatientName = reader.GetString(reader.GetOrdinal("PatientName"));
                hospPatient.Problem = reader.GetString(reader.GetOrdinal("Problem"));
                int ordinalAdmissionDate = reader.GetOrdinal("AdmissionDate");
                hospPatient.AdmissionDate = reader.IsDBNull(ordinalAdmissionDate) ? null : reader.GetString(ordinalAdmissionDate);

                int ordinalDischargedate = reader.GetOrdinal("Dischargedate");
                hospPatient.DischargeDate = reader.IsDBNull(ordinalDischargedate) ? null : reader.GetString(ordinalDischargedate);

                int ordinalTreatmentDuration = reader.GetOrdinal("TreatmentDuration");
                hospPatient.TreatmentDuration = reader.IsDBNull(ordinalTreatmentDuration) ? 0 : Convert.ToInt32(reader.GetValue(ordinalTreatmentDuration));
                hospPatient.TypeName = reader.GetString(reader.GetOrdinal("TypeName"));
                hospPatient.Date = reader.GetString(reader.GetOrdinal("Date"));
                hospPatient.Status = reader.IsDBNull(reader.GetOrdinal("Status")) ? null : reader.GetString(reader.GetOrdinal("Status"));

                hospPatients.Add(hospPatient);
            }


            reader.Close();
            con.Close();
            return hospPatients.Where(h => h.TypeName == "Inpatient").ToList();
        }



     

        public HospPatient GetHospPatient(int Id)
        {
            HospPatient hospPatient = null;
            con.Open();
            cmd = new SqlCommand("select * from bookapp where Id=" + Id + "", con);
            reader = cmd.ExecuteReader();
            if(reader.Read())
            {
                hospPatient = new HospPatient
                {

                    Id = Convert.ToInt32(reader["Id"]),
                    PatientName = reader.GetString(reader.GetOrdinal("PatientName")),
                    AdmissionDate = reader.GetString(reader.GetOrdinal("AdmissionDate")),
                    DischargeDate = reader.GetString(reader.GetOrdinal("DischargeDate")),
                    TreatmentDuration = Convert.ToInt32(reader["TreatmentDuration"]),
                    Problem = reader.GetString(reader.GetOrdinal("Problem")),
                    Status = reader.IsDBNull(reader.GetOrdinal("Status")) ? null : reader.GetString(reader.GetOrdinal("Status")),

                };
            }

            reader.Close();
            con.Close();
            return hospPatient;
        }



        public List<Doctor> GetDoctors()
        {
            List<Doctor> doctors = new List<Doctor>();
            con.Open();
            cmd = new SqlCommand("SELECT * FROM doctors where Status = 'Active'", con);
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
                doctor.PhoneNo  = reader.IsDBNull(reader.GetOrdinal("PhoneNo"))? string.Empty : reader["PhoneNo"].ToString() ;
                doctor.Status = reader.IsDBNull(reader.GetOrdinal("Status")) ? string.Empty : reader["Status"].ToString();



                doctors.Add(doctor);
            }

            reader.Close();
            con.Close();
            return doctors;
        }

    }






}
