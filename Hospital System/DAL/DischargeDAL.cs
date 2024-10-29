using Hospital_System.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace Hospital_System.DAL
{
    public class DischargeDAL
    {

        string _connectionString = null;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;


        public DischargeDAL()
        {

            _connectionString = ConfigurationManager.ConnectionStrings["Hospital"].ConnectionString;
            con = new SqlConnection(_connectionString);
        }

        public List<DischargPatient> GetdischargPatients(DateTime? date, int? patientId)
        {
            List<DischargPatient> dischargPatients = new List<DischargPatient>();
            DischargPatient dischargPatients1 = null;
            con.Open();
            cmd = new SqlCommand("select * from discharge where AdmissionDate is null or  AdmissionDate  like'%" + date + "%' and patientId = 0 or patientId like'%" + patientId + "%'", con);

            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                dischargPatients1 = new DischargPatient();

                int ordinalPatientId = reader.GetOrdinal("PatientId");
                dischargPatients1.PatientId = reader.IsDBNull(ordinalPatientId) ? 0 : Convert.ToInt32(reader.GetValue(ordinalPatientId));

                dischargPatients1.PatientName = reader.GetString(reader.GetOrdinal("PatientName"));
                dischargPatients1.Reason = reader.GetString(reader.GetOrdinal("Reason"));
                dischargPatients1.AdmissionDate = reader.GetString(reader.GetOrdinal("AdmissionDate"));
                dischargPatients1.ProcedureandTreatment = reader.GetString(reader.GetOrdinal("ProcedureandTreatment"));
                dischargPatients1.TreatmentDuration = reader.GetString(reader.GetOrdinal("TreatmentDuration"));
                dischargPatients1.DischargeDate = reader.GetString(reader.GetOrdinal("DischargeDate"));


                dischargPatients.Add(dischargPatients1);

            }

            reader.Close();
            con.Close();
            return dischargPatients;

        }

        public DischargPatient DischargeId(int patientId)
        {

            DischargPatient dischargPatient = null;
            con.Open();
            cmd = new SqlCommand("select * from discharge where PatientId=" + patientId + "", con);
           
            reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                dischargPatient = new DischargPatient
                {

                    PatientId = Convert.ToInt32(reader.GetOrdinal("PatientId")),
                    PatientName = reader.GetString(reader.GetOrdinal("PatientName")),
                    Reason = reader.GetString(reader.GetOrdinal("reason")),
                    Findings = reader.GetString(reader.GetOrdinal("Findings")),
                    Labreports=reader.GetString(reader.GetOrdinal("Labreports")),
                    AdmissionDate = reader.GetString(reader.GetOrdinal("AdmissionDate")),
                    ProcedureandTreatment = reader.GetString(reader.GetOrdinal("ProcedureandTreatment")),
                    TreatmentDuration = reader.GetString(reader.GetOrdinal("TreatmentDuration")),
                    DischargeDate = reader.GetString(reader.GetOrdinal("DischargeDate")),
                    FurtherInstruction = reader.GetString(reader.GetOrdinal("FurtherInstruction")),
                    Followup = reader.GetString(reader.GetOrdinal("Followup")),

                };
            }

            reader.Close();
            con.Close();
            return dischargPatient;
        }

    }


}