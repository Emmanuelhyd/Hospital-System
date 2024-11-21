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

        public List<DischargPatient> GetdischargPatients()
        {
            List<DischargPatient> dischargPatients = new List<DischargPatient>();
            DischargPatient dischargPatients1 = null;
            con.Open();
            cmd = new SqlCommand("select * from discharge ", con);

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

        //Add Discharge

        public List<DischargPatient> AddDischarge(DischargPatient discharge)
        {

            var ids = 0;
            con.Open();
            cmd = new SqlCommand("select * from Discharge where PatientId='" + discharge.PatientId + "'", con);
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
                cmd = new SqlCommand("insert into Discharge(PatientId,PatientName,Reason,Findings,Labreports,ProcedureandTreatment,FurtherInstruction,AdmissionDate,DischargeDate,TreatmentDuration,FollowUp) values(" + discharge.PatientId + ",'" + discharge.PatientName + "','" + discharge.Reason + "','" + discharge.Findings + "','" + discharge.Labreports + "','" + discharge.ProcedureandTreatment + "','" + discharge.FurtherInstruction + "','" + discharge.AdmissionDate + "','" + discharge.DischargeDate + "','" + discharge.TreatmentDuration + "','" + discharge.Followup + "')", con);


            }
            else
            {
                cmd = new SqlCommand("update Discharge set PatientName='" + discharge.PatientName + "',Reason='" + discharge.Reason + "',Findings='" + discharge.Findings + "',Labreports='" + discharge.Labreports + "',ProcedureandTreatment='" + discharge.ProcedureandTreatment + "',FurtherInstruction='" + discharge.FurtherInstruction + "',AdmissionDate='" + discharge.AdmissionDate + "',DischargeDate='" + discharge.DischargeDate + "',TreatmentDuration='" + discharge.TreatmentDuration + "',FollowUp='" + discharge.Followup + "' where PatientId=" + discharge.PatientId + "", con);
            }
            cmd.ExecuteNonQuery();
            con.Close();


            List<DischargPatient> dischargeDos = new List<DischargPatient>();
            dischargeDos = GetdischargPatients();
            return dischargeDos;
        }

        //discharge edit

        public DischargPatient DischargeE(int PatientId)
        {
            DischargPatient dischargeDo = new DischargPatient();


            SqlCommand cmd = new SqlCommand("Select * from Discharge where PatientId='" + PatientId + "'", con);
            {

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                if (reader.Read())
                {
                    dischargeDo.PatientId = Convert.ToInt32(reader["PatientId"]);
                    dischargeDo.PatientName = reader["PatientName"].ToString();
                    dischargeDo.Reason = reader["Reason"].ToString();
                    dischargeDo.Findings = reader["Findings"].ToString();
                    dischargeDo.Labreports = reader["Labreports"].ToString();
                    dischargeDo.ProcedureandTreatment = reader["ProcedureandTreatment"].ToString();
                    dischargeDo.FurtherInstruction = reader["FurtherInstruction"].ToString();
                    dischargeDo.AdmissionDate = reader["AdmissionDate"].ToString();
                    dischargeDo.DischargeDate = reader["DischargeDate"].ToString();
                    dischargeDo.TreatmentDuration = reader["TreatmentDuration"].ToString();
                    //dischargeDo.DischargeAmount = reader["DischargeAmount"].ToString();
                    dischargeDo.Followup = reader["FollowUp"].ToString();


                }
                reader.Close();
                con.Close();

            }
            return dischargeDo;
        }
        public int DischargeId()
        {
            int id = 0;
            con.Open();
            cmd = new SqlCommand("SELECT MAX(PatientId) FROM Discharge", con);
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