using Hospital_System.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Hospital_System.DAL
{
    public class BillingDAL
    {

        string _connectionString = null;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;

        public BillingDAL()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Hospital"].ConnectionString;
            con = new SqlConnection(_connectionString);
        }

       


      public List<Billing> GetBillings()
        {
            List<Billing> billings = new List<Billing>();
            con.Open();
            cmd = new SqlCommand("select * from  bill ", con);
            reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                Billing billing = new Billing();

                billing.PatientId = Convert.ToInt32(reader["PatientId"]);
                billing.PatientName = reader.GetString(reader.GetOrdinal("PatientName"));
                billing.Problem = reader.GetString(reader.GetOrdinal("Problem"));
                billing.BillingDate = reader.GetString(reader.GetOrdinal("BillingDate"));
                billing.DoctorFee = Convert.ToDecimal(reader["DoctorFee"]);
                billing.TreatmentDuration = Convert.ToInt32(reader["TreatmentDuration"]);
                billing.TreatmentCharges = Convert.ToDecimal(reader["TreatmentCharges"]);
                billing.MedicineCharges = Convert.ToDecimal(reader["MedicineCharges"]);
                billing.RoomFee = Convert.ToDecimal(reader["RoomFee"]);
                billing.Others = reader.GetString(reader.GetOrdinal("Others"));
                billing.OthersCost = Convert.ToInt32(reader["OthersCost"]);
                billing.TotalBill = Convert.ToInt32(reader["TotalBill"]);
                billing.GST = Convert.ToInt32(reader["GST"]);
                billing.TotalAmount = Convert.ToInt32(reader["TotalAmount"]);
                //billing.InsuranceClaimed = Convert.ToInt32(reader["InsuranceClaimed"]);
                billing.PaidBill = Convert.ToInt32(reader["PaidBill"]);
                billing.Status = reader.GetString(reader.GetOrdinal("Status"));
                billing.MethodOfPayment = reader.GetString(reader.GetOrdinal("MethodOfPayment"));


                billings.Add(billing);
            }

            reader.Close();
            con.Close();
            return billings;
        }


        public Billing Billing1( int PatientId)
        {
            Billing billing = null;
            con.Open();
            cmd = new SqlCommand("select * from bill where PatientId="+PatientId+"", con);
            reader = cmd.ExecuteReader();
            if(reader.Read())
            {
                billing = new Billing();

                billing.PatientId = Convert.ToInt32(reader["PatientId"]);
                billing.PatientName = reader.GetString(reader.GetOrdinal("PatientName"));
                billing.Problem = reader.GetString(reader.GetOrdinal("Problem"));
                billing.BillingDate = reader.GetString(reader.GetOrdinal("BillingDate"));
                billing.DoctorFee = Convert.ToDecimal(reader["DoctorFee"]);
                billing.TreatmentDuration = Convert.ToInt32(reader["TreatmentDuration"]);
                billing.TreatmentCharges = Convert.ToDecimal(reader["TreatmentCharges"]);
                billing.RoomFee = Convert.ToDecimal(reader["RoomFee"]);
                billing.Others = reader.GetString(reader.GetOrdinal("Others"));
                billing.OthersCost = Convert.ToInt32(reader["OthersCost"]);
                billing.TotalBill = Convert.ToInt32(reader["TotalBill"]);
                billing.GST = Convert.ToInt32(reader["GST"]);
                billing.TotalAmount = Convert.ToInt32(reader["TotalAmount"]);
                billing.InsuranceClaimed = Convert.ToInt32(reader["InsuranceClaimed"]);
                billing.PaidBill = Convert.ToInt32(reader["PaidBill"]);
                billing.Status = reader.GetString(reader.GetOrdinal("Status"));
                billing.MethodOfPayment = reader.GetString(reader.GetOrdinal("MethodOfPayment"));
                //billing.BalanceAmount = Convert.ToDecimal(reader["BalanceAmount"]);


            }


            reader.Close();
            con.Close();
            return billing;
        }
       
    }
}