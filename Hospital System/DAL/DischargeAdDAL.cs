using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital_System.Models;


namespace Hospital_System.DAL
{
    public class DischargeAdDAL
    {
        string _connectionString;
        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataReader reader = null;

        public DischargeAdDAL()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Hospital"].ConnectionString;
            con = new SqlConnection(_connectionString);
        }

        //Discharge List
        public List<DischargeDo> DischargeListAd()
        {
            List<DischargeDo> dischargeDos = new List<DischargeDo>();

            {

                con.Open();
                cmd = new SqlCommand("select * from Discharge", con);
                SqlDataReader sdr;
                sdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(sdr);
                foreach (DataRow row in dt.Rows)
                    dischargeDos.Add(
                        new DischargeDo
                        {
                            PatientId = Convert.ToInt32(row["PatientId"]),
                            PatientName = row["PatientName"].ToString(),
                            Reason = row["Reason"].ToString(),
                            Findings = row["Findings"].ToString(),
                            Labreports = row["Labreports"].ToString(),
                            ProcedureandTreatment = row["ProcedureandTreatment"].ToString(),
                            FurtherInstruction = row["FurtherInstruction"].ToString(),
                            AdmissionDate = row["AdmissionDate"].ToString(),
                            DischargeDate = row["DischargeDate"].ToString(),
                            TreatmentDuration = row["TreatmentDuration"].ToString(),
                            //DischargeAmount = row["DischargeAmount"].ToString(),
                            FollowUp = row["FollowUp"].ToString(),
                           

                        });

                return dischargeDos;
            }
        }

        //Add Discharge

        public List<DischargeDo> AddDischarge(DischargeDo dischargeDo)
        {

            var ids = 0;
            con.Open();
            cmd = new SqlCommand("select * from Discharge where PatientId='" + dischargeDo.PatientId + "'", con);
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
                cmd = new SqlCommand("insert into Discharge(PatientId,PatientName,Reason,Findings,Labreports,ProcedureandTreatment,FurtherInstruction,AdmissionDate,DischargeDate,TreatmentDuration,DischargeAmount,FollowUp) values(" + dischargeDo.PatientId + ",'" + dischargeDo.PatientName + "','" + dischargeDo.Reason + "','" + dischargeDo.Findings + "','" + dischargeDo.Labreports + "','" + dischargeDo.ProcedureandTreatment + "','" + dischargeDo.FurtherInstruction + "','" + dischargeDo.AdmissionDate + "','" + dischargeDo.DischargeDate + "','" + dischargeDo.TreatmentDuration + "','" + dischargeDo.FollowUp + "')", con);

            }
            else
            {
                cmd = new SqlCommand("update Discharge set PatientName='" + dischargeDo.PatientName + "',Reason='" + dischargeDo.Reason + "',Findings='" + dischargeDo.Findings + "',Labreports='" + dischargeDo.Labreports + "',ProcedureandTreatment='" + dischargeDo.ProcedureandTreatment + "',FurtherInstruction='" + dischargeDo.FurtherInstruction + "',AdmissionDate='" + dischargeDo.AdmissionDate + "',DischargeDate='" + dischargeDo.DischargeDate + "',TreatmentDuration='" + dischargeDo.TreatmentDuration + "',FollowUp='" + dischargeDo.FollowUp + "' where PatientId=" + dischargeDo.PatientId + "", con);
            }
            cmd.ExecuteNonQuery();
            con.Close();


            List<DischargeDo> dischargeDos = new List<DischargeDo>();
            dischargeDos = DischargeListAd();
            return dischargeDos;
        }

        //discharge edit

        public DischargeDo DischargeEdit(int PatientId)
        {
            DischargeDo dischargeDo = new DischargeDo();


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
                    dischargeDo.FollowUp = reader["FollowUp"].ToString();
                 

                }
                reader.Close();
                con.Close();

            }
            return dischargeDo;
        }
        // delete discharge

        public List<DischargeDo> DischargeDelete(int PatientId)
        {
            con.Open();
            cmd = new SqlCommand("Delete from Discharge where PatientId='" + PatientId + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();

            List<DischargeDo> dischargeDos = new List<DischargeDo>();

            con.Open();
            cmd = new SqlCommand("select * from Discharge", con);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                DischargeDo dischargeDo = new DischargeDo();

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
                dischargeDo.FollowUp = reader["FollowUp"].ToString();


                dischargeDos.Add(dischargeDo);

            }

            reader.Close();
            con.Close();
            return dischargeDos;
        }




        //Discharge Id Increment

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