﻿using Hospital_System.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Hospital_System.DAL
{
    public class NurseDAL
    {
        string _connectionString;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;

        public NurseDAL()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Hospital"].ConnectionString;
            con = new SqlConnection(_connectionString);
        }
        //list of nurse
        public List<Nurse> GetNurses()
        {
            List<Nurse> nurses = new List<Nurse>();
            con.Open();
            cmd = new SqlCommand("select * from nurse", con);
            reader=cmd.ExecuteReader();
            while (reader.Read())
            {
                Nurse nurse = new Nurse();

                nurse.NurseId = Convert.ToInt32(reader["NurseId"]);
                nurse.Name = reader.GetString(reader.GetOrdinal("Name"));
                //nurse.DOB = reader.GetString(reader.GetOrdinal("DOB"));
                nurse.Contact = reader.GetString(reader.GetOrdinal("Contact"));
                nurse.Email = reader.GetString(reader.GetOrdinal("Email"));
                nurse.ShiftType = reader.GetString(reader.GetOrdinal("ShiftType"));
                nurse.EmployeeStatus = reader.GetString(reader.GetOrdinal("EmployeeStatus"));

                nurses.Add(nurse);
            }
            reader.Close();
            con.Close();
            return nurses;

        }
        //nurse details based on Id 
        public Nurse NurseDetails( int NurseId)
        {
            Nurse nurse = null;
            con.Open();
            cmd = new SqlCommand("select * from nurse where NurseId="+NurseId+"", con);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                 nurse = new Nurse();

                nurse.NurseId = Convert.ToInt32(reader["NurseId"]);
                nurse.Name = reader.GetString(reader.GetOrdinal("Name"));
                nurse.DOB = reader.GetString(reader.GetOrdinal("DOB"));
                nurse.Contact = reader.GetString(reader.GetOrdinal("Contact"));
                nurse.Email = reader.GetString(reader.GetOrdinal("Email"));
                nurse.Education = reader.GetString(reader.GetOrdinal("Education"));
                nurse.DateOfJoining = reader.GetString(reader.GetOrdinal("DateOfJoining"));
                nurse.Address = reader.GetString(reader.GetOrdinal("Address"));
                nurse.Specialization = reader.GetString(reader.GetOrdinal("Specialization"));
                nurse.ShiftType = reader.GetString(reader.GetOrdinal("ShiftType"));
                nurse.EmployeeStatus = reader.GetString(reader.GetOrdinal("EmployeeStatus"));
  
            }
            reader.Close();
            con.Close();
            return nurse;

        }
        //Add Nurse

        public List<Nurse> AddNurse(Nurse nurse)
        {

            var ids = 0;
            con.Open();
            cmd = new SqlCommand("select * from Nurse where NurseId='" + nurse.NurseId + "'", con);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                ids = Convert.ToInt32(reader["NurseId"]);
            }

            reader.Close();
            con.Close();



            con.Open();
            if (ids == 0)
            {
                cmd = new SqlCommand("insert into Nurse(NurseId,Name,DOB,Contact,Email,Address,DateOfJoining,Specialization,ShiftType,Education,EmployeeStatus) values(" + nurse.NurseId + ",'" + nurse.Name + "','" + nurse.DOB + "','" + nurse.Contact + "','" + nurse.Email + "','" + nurse.Address + "','" + nurse.DateOfJoining + "','" + nurse.Specialization + "','" + nurse.ShiftType + "','" + nurse.Education + "','" + nurse.EmployeeStatus + "')", con);

            }
            else
            {
                cmd = new SqlCommand("update Nurse set Name='" + nurse.Name + "',DOB='" + nurse.DOB + "',Contact='" + nurse.Contact + "',Email='" + nurse.Email + "',Address='" + nurse.Address + "',DateOfJoining='" + nurse.DateOfJoining + "',Specialization='" + nurse.Specialization + "' ,ShiftType='" + nurse.ShiftType + "',Education='" + nurse.Education + "',EmployeeStatus='" + nurse.EmployeeStatus + "' where NurseId=" + nurse.NurseId + "", con);
            }
            cmd.ExecuteNonQuery();
            con.Close();


            List<Nurse> nurses= new List<Nurse>();
            nurses = GetNurses();
            return nurses;
        }



        public int NurseId()
        {
            int id = 0;
            con.Open();
            cmd = new SqlCommand("SELECT MAX(NurseId) FROM Nurse", con);
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