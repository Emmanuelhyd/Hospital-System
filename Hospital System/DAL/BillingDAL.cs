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

        public List<Billing> AddBill(Billing Billing)
        {

            var ids = 0;



            con.Open();
            cmd = new SqlCommand("select * from Bill where PatientId='" + Billing.PatientId + "'", con);
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
                cmd = new SqlCommand("insert into Bill(PatientId,PatientName,Problem,BillingDate,DoctorFee,TreatmentDuration,TreatmentCharges,MedicineCharges,RoomFee,Others,OthersCost,TotalBill,GST,TotalAmount,InsuranceClaimed,PaidBill,Status,MethodOfPayment) values(" + Billing.PatientId + ",'" + Billing.PatientName + "','" + Billing.Problem + "','" + Billing.BillingDate + "','" + Billing.DoctorFee + "','" + Billing.TreatmentDuration + "','" + Billing.TreatmentCharges + "','" + Billing.MedicineCharges + "','" + Billing.RoomFee + "','" + Billing.Others + "','" + Billing.OthersCost + "','" + Billing.TotalBill + "','" + Billing.GST + "','" + Billing.TotalAmount + "','" + Billing.InsuranceClaimed + "','" + Billing.PaidBill + "','" + Billing.Status + "','" + Billing.MethodOfPayment + "')", con);

            }
            else
            {
                cmd = new SqlCommand("update Bill set PatientName='" + Billing.PatientName + "',Problem='" + Billing.Problem + "',BillingDate='" + Billing.BillingDate + "',DoctorFee='" + Billing.DoctorFee + "',TreatmentDuration='" + Billing.TreatmentDuration + "',TreatmentCharges='" + Billing.TreatmentCharges + "',MedicineCharges='" + Billing.MedicineCharges + "',RoomFee='" + Billing.RoomFee + "',Others='" + Billing.Others + "',OthersCost='" + Billing.OthersCost + "',TotalBill='" + Billing.TotalBill + "',GST='" + Billing.GST + "',TotalAmount='" + Billing.TotalAmount + "',InsuranceClaimed='" + Billing.InsuranceClaimed + "',PaidBill='" + Billing.PaidBill + "',Status='" + Billing.Status + "',MethodOfPayment='" + Billing.MethodOfPayment + "' where PatientId=" + Billing.PatientId + "", con);
            }
            cmd.ExecuteNonQuery();
            con.Close();


            List<Billing> billAds = new List<Billing>();
            billAds = GetBillings();
            return billAds;
        }

        //Auto increment Id
        public int BillId()
        {
            int id = 0;
            con.Open();
            cmd = new SqlCommand("SELECT MAX(PatientId) FROM Bill", con);
            var result = cmd.ExecuteScalar();


            if (result != DBNull.Value)
            {
                id = Convert.ToInt32(result);
            }
            con.Close();
            return id;
        }



        //Bill Edit

        public Billing BillE(int PatientId)
        {
            Billing billAd = new Billing();


            SqlCommand cmd = new SqlCommand("Select * from Bill where PatientId='" + PatientId + "'", con);
            {

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                if (reader.Read())
                {
                    billAd.PatientId = Convert.ToInt32(reader["PatientId"]);
                    billAd.PatientName = reader["PatientName"].ToString();
                    billAd.Problem = reader["Problem"].ToString();
                    billAd.BillingDate = reader["BillingDate"].ToString();
                    billAd.DoctorFee = Convert.ToInt32(reader["DoctorFee"]);
                    billAd.TreatmentDuration = Convert.ToInt32(reader["TreatmentDuration"]);
                    billAd.TreatmentCharges = Convert.ToInt32(reader["TreatmentCharges"]);
                    billAd.MedicineCharges = Convert.ToInt32(reader["MedicineCharges"]);
                    billAd.RoomFee = Convert.ToInt32(reader["RoomFee"]);
                    billAd.Others = reader["Others"].ToString();
                    billAd.OthersCost = Convert.ToInt32(reader["OthersCost"]);
                    billAd.TotalBill = Convert.ToInt32(reader["TotalBill"]);
                    billAd.GST = Convert.ToInt32(reader["GST"]);
                    billAd.TotalAmount = Convert.ToInt32(reader["TotalAmount"]);
                    billAd.InsuranceClaimed = Convert.ToInt32(reader["InsuranceClaimed"]);
                    billAd.PaidBill = Convert.ToInt32(reader["PaidBill"]);
                    billAd.Status = reader["Status"].ToString();
                    billAd.MethodOfPayment = reader["MethodOfPayment"].ToString();


                }
                reader.Close();
                con.Close();

            }
            return billAd;
        }

    }
}