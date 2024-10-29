using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using Hospital_System.Models;


namespace Hospital_System.DAL
{
    public class BillDAL
    {
        string _connectionString;
        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataReader reader = null;

        public BillDAL()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Hospital"].ConnectionString;
            con = new SqlConnection(_connectionString);
        }

        //Billing List
        public List<BillAd> BillList()
        {
            List<BillAd> billAds = new List<BillAd>();

            {

                con.Open();
                cmd = new SqlCommand("select * from bill", con);
                SqlDataReader sdr;
                sdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(sdr);
                foreach (DataRow row in dt.Rows)
                    billAds.Add(
                        new BillAd
                        {
                            PatientId = Convert.ToInt32(row["PatientId"]),
                            PatientName = row["PatientName"].ToString(),
                            Problem = row["Problem"].ToString(),
                            BillingDate = row["BillingDate"].ToString(),
                            DoctorFee = Convert.ToInt32(row["DoctorFee"]),
                            TreatmentDuration = Convert.ToInt32(row["TreatmentDuration"]),
                            TreatmentCharges = Convert.ToInt32(row["TreatmentCharges"]),
                            RoomFee = Convert.ToInt32(row["RoomFee"]),
                            Others = row["Others"].ToString(),
                            OthersCost = Convert.ToInt32(row["OthersCost"]),
                            TotalBill = Convert.ToInt32(row["TotalBill"]),
                            GST = Convert.ToInt32(row["GST"]),
                            TotalAmount=Convert.ToInt32(row["TotalAmount"]),
                            InsuranceClaimed = Convert.ToInt32(row["InsuranceClaimed"]),
                            PaidBill = Convert.ToInt32(row["PaidBill"]),
                            Status = row["Status"].ToString(),
                            MethodOfPayment = row["MethodOfPayment"].ToString(),


                        });

                return billAds;
            }
        }

        //Add Attendance

        public List<BillAd> AddBill(BillAd billAd)
        {

            var ids = 0;



            con.Open();
            cmd = new SqlCommand("select * from Bill where PatientId='" + billAd.PatientId + "'", con);
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
                cmd = new SqlCommand("insert into Bill(PatientId,PatientName,Problem,BillingDate,DoctorFee,TreatmentDuration,TreatmentCharges,MedicineCharges,RoomFee,Others,OthersCost,TotalBill,GST,TotalAmount,InsuranceClaimed,PaidBill,Status,MethodOfPayment) values(" + billAd.PatientId + ",'" + billAd.PatientName + "','" + billAd.Problem + "','" + billAd.BillingDate + "','" + billAd.DoctorFee + "','" + billAd.TreatmentDuration + "','" + billAd.TreatmentCharges + "','" + billAd.MedicineCharges + "','" + billAd.RoomFee + "','" + billAd.Others + "','" + billAd.OthersCost + "','" + billAd.TotalBill + "','" + billAd.GST + "','" + billAd.TotalAmount + "','" + billAd.InsuranceClaimed + "','" + billAd.PaidBill + "','" + billAd.Status + "','" + billAd.MethodOfPayment + "')", con);

            }
            else
            {
                cmd = new SqlCommand("update Bill set PatientName='" + billAd.PatientName + "',Problem='" + billAd.Problem + "',BillingDate='" + billAd.BillingDate + "',DoctorFee='" + billAd.DoctorFee + "',TreatmentDuration='" + billAd.TreatmentDuration + "',TreatmentCharges='" + billAd.TreatmentCharges + "',MedicineCharges='" + billAd.MedicineCharges + "',RoomFee='" + billAd.RoomFee + "',Others='" + billAd.Others + "',OthersCost='" + billAd.OthersCost + "',TotalBill='" + billAd.TotalBill + "',GST='" + billAd.GST + "',TotalAmount='" + billAd.TotalAmount + "',InsuranceClaimed='" + billAd.InsuranceClaimed + "',PaidBill='" + billAd.PaidBill + "',Status='" + billAd.Status + "',MethodOfPayment='" + billAd.MethodOfPayment + "' where PatientId=" + billAd.PatientId + "", con);
            }
            cmd.ExecuteNonQuery();
            con.Close();


            List<BillAd> billAds = new List<BillAd>();
            billAds = BillList();
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

        public BillAd BillEdit(int PatientId)
        {
            BillAd billAd = new BillAd();


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

        //Bill delete

        public List<BillAd> BillDelete(int PatientId)
        {
            con.Open();
            cmd = new SqlCommand("Delete from Bill where PatientId='" + PatientId + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();

            List<BillAd> billAds = new List<BillAd>();

            con.Open();
            cmd = new SqlCommand("select * from Bill", con);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                BillAd billAd = new BillAd();

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

                billAds.Add(billAd);

            }

            reader.Close();
            con.Close();
            return billAds;
        }



        public BillAd Billing1(int PatientId)
        {
            BillAd billAd = null;
            con.Open();
            cmd = new SqlCommand("select * from Bill where PatientId=" + PatientId + "", con);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                billAd = new BillAd();

                billAd.PatientId = Convert.ToInt32(reader["PatientId"]);
                billAd.PatientName = reader.GetString(reader.GetOrdinal("PatientName"));
                billAd.Problem = reader.GetString(reader.GetOrdinal("Problem"));
                billAd.BillingDate = reader.GetString(reader.GetOrdinal("BillingDate"));
                billAd.DoctorFee = Convert.ToDecimal(reader["DoctorFee"]);
                billAd.TreatmentDuration = Convert.ToInt32(reader["TreatmentDuration"]);
                billAd.TreatmentCharges = Convert.ToDecimal(reader["TreatmentCharges"]);
                billAd.RoomFee = Convert.ToDecimal(reader["RoomFee"]);
                billAd.Others = reader.GetString(reader.GetOrdinal("Others"));
                billAd.OthersCost = Convert.ToInt32(reader["OthersCost"]);
                billAd.TotalBill = Convert.ToInt32(reader["TotalBill"]);
                billAd.GST = Convert.ToInt32(reader["GST"]);
                billAd.TotalAmount = Convert.ToInt32(reader["TotalAmount"]);
                billAd.InsuranceClaimed = Convert.ToInt32(reader["InsuranceClaimed"]);
                billAd.PaidBill = Convert.ToInt32(reader["PaidBill"]);
                billAd.Status = reader.GetString(reader.GetOrdinal("Status"));
                billAd.MethodOfPayment = reader.GetString(reader.GetOrdinal("MethodOfPayment"));


            }


            reader.Close();
            con.Close();
            return billAd;
        }

    }

    //public MInPatient GetMInPatient(int PatientId)
    //{
    //    MInPatient mInPatient = new MInPatient();
    //    con.Open();
    //    cmd = new SqlCommand("select * from bookapp  where PatientId='" + PatientId + "' ", con);
    //    reader = cmd.ExecuteReader();
    //    if (reader.Read())
    //    {
    //        mInPatient.PatientId = Convert.ToInt32(reader["PatientId"]);
    //        mInPatient.TreatmentDuration = Convert.ToInt32(reader["TreatmentDuration"]);
    //        mInPatient.PatientName = reader["PatientName"].ToString();
    //    }
    //    reader.Close();
    //    con.Close();
    //    return mInPatient;
    //}
}
