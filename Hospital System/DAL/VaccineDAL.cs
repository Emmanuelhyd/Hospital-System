﻿using Hospital_System.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Hospital_System.DAL
{
    public class VaccineDAL
    {
        string _connectionString;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;

        public VaccineDAL()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Hospital"].ConnectionString;
            con = new SqlConnection(_connectionString);
        }

        public string Vaccination(Vaccines vaccines)
        {
            string res = "";
            con.Open();
            cmd= new SqlCommand("insert into Vaccine values('"+vaccines.PatientName+"','"+vaccines.Age+"','"+vaccines.DoctorName+"','"+vaccines.VaccineType+"','"+vaccines.VaccineId+"','"+vaccines.DateOfVaccination+"','"+vaccines.Dosage+"','"+vaccines.FollowupDate+"','"+vaccines.NextDueDate+"','"+vaccines.ReactionType+"','"+vaccines.Status+"')",con);
            cmd.ExecuteNonQuery();
            return "Slot Booked";

        }


        public List<Vaccines> VaccinesList( string searchvalue)
        {
            List<Vaccines> vaccines= new List<Vaccines>();
            con.Open();
            cmd = new SqlCommand("select * from vaccine where VaccineType like'%"+ searchvalue+"%'", con);
            reader=cmd.ExecuteReader();
            while(reader.Read())
            {
                Vaccines vaccines1 = new Vaccines();
                vaccines1.VaccineId = reader.GetString(reader.GetOrdinal("VaccineId"));
                vaccines1.PatientName = reader.GetString(reader.GetOrdinal("PatientName"));
                vaccines1.DoctorName = reader.GetString(reader.GetOrdinal("DoctorName"));
                vaccines1.Age = reader.GetString(reader.GetOrdinal("Age"));
                vaccines1.VaccineType = reader.GetString(reader.GetOrdinal("VaccineType"));
                vaccines1.Dosage = reader.GetString(reader.GetOrdinal("Dosage"));
                vaccines1.DateOfVaccination = reader.GetString(reader.GetOrdinal("DateOfVaccination"));
                //vaccines1.FollowupDate = reader.GetString(reader.GetOrdinal("FollowupDate"));
                vaccines1.NextDueDate = reader.GetString(reader.GetOrdinal("NextDueDate"));
                vaccines1.Status = reader.GetString(reader.GetOrdinal("Status"));
              
                vaccines.Add(vaccines1 );
            }

            reader.Close();
            con.Close();
            return vaccines;

        }




        public Vaccines vac( string vaccineId )
        {
            Vaccines vaccines = null;
            con.Open();
            cmd = new SqlCommand("select *  from vaccine where VaccineId ='" + vaccineId + "'", con);
            reader = cmd.ExecuteReader();
            if(reader.Read())
            {
                vaccines = new Vaccines();

                vaccines.PatientId = Convert.ToInt32(reader["PatientId"]);
                vaccines.VaccineId = reader.GetString(reader.GetOrdinal("VaccineId"));
                vaccines.PatientName = reader.GetString(reader.GetOrdinal("PatientName"));
                vaccines.DoctorName = reader.GetString(reader.GetOrdinal("DoctorName"));
                vaccines.Age = reader.GetString(reader.GetOrdinal("Age"));
                vaccines.VaccineType = reader.GetString(reader.GetOrdinal("VaccineType"));
                vaccines.Dosage = reader.GetString(reader.GetOrdinal("Dosage"));
                vaccines.DateOfVaccination = reader.GetString(reader.GetOrdinal("DateOfVaccination"));
                vaccines.FollowupDate = reader.GetString(reader.GetOrdinal("FollowupDate"));
                vaccines.NextDueDate = reader.GetString(reader.GetOrdinal("NextDueDate"));
                vaccines.Status = reader.GetString(reader.GetOrdinal("Status"));

            }

            reader.Close();
            con.Close();
            return vaccines;
        }


        public List<Vaccines> AddVaccine(Vaccines vaccine)
        {

            var ids = 0;
            con.Open();
            cmd = new SqlCommand("select * from Vaccine where PatientId='" + vaccine.PatientId + "'", con);
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
                cmd = new SqlCommand("insert into Vaccine(PatientName,DoctorName,Age,VaccineId,VaccineType,Dosage,DateOfVaccination,FollowupDate,NextDueDate,ReactionType,Status) values('" + vaccine.PatientName + "','" + vaccine.DoctorName + "','" + vaccine.Age + "','" + vaccine.VaccineId + "','" + vaccine.VaccineType + "','" + vaccine.Dosage + "','" + vaccine.DateOfVaccination + "','" + vaccine.FollowupDate + "','" + vaccine.NextDueDate + "','" + vaccine.ReactionType + "','" + vaccine.Status + "')", con);

            }
            else
            {
                cmd = new SqlCommand("update Vaccine set PatientName='" + vaccine.PatientName + "',DoctorName='" + vaccine.DoctorName + "',Age='" + vaccine.Age + "',VaccineId='" + vaccine.VaccineId + "',VaccineType='" + vaccine.VaccineType + "',Dosage='" + vaccine.Dosage + "',DateOfVaccination='" + vaccine.DateOfVaccination + "',FollowupDate='" + vaccine.FollowupDate + "',NextDueDate='" + vaccine.NextDueDate + "',ReactionType='" + vaccine.ReactionType + "',Status='" + vaccine.Status + "' where PatientId=" + vaccine.PatientId + "", con);
            }
            cmd.ExecuteNonQuery();
            con.Close();


            List<Vaccines> vaccines = new List<Vaccines>();
            vaccines = VaccinesList("searchvalue");
            return vaccines;
        }

        //Vaccine Id Increment

        public int VaccineId()
        {
            int id = 0;
            con.Open();
            cmd = new SqlCommand("SELECT MAX(PatientId) FROM Vaccine", con);
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