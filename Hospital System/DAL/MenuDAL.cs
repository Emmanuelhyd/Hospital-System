using Hospital_System.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Hospital_System.DAL
{
    public class MenuDAL
    {
        string _connectionString = null;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;


        public MenuDAL()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Hospital"].ConnectionString;
            con = new SqlConnection(_connectionString);
        }

        
        public List<Menu> GetMenus()
        {
            List<Menu> menus = new List<Menu>();
            con.Open();
            cmd = new SqlCommand("select * from menu ", con);
            reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                Menu menu = new Menu();
                menu.Id = Convert.ToInt32(reader["Id"]);
                menu.Name = reader.GetString(reader.GetOrdinal("Name"));
                menu.Url = reader.GetString(reader.GetOrdinal("Url"));
                menu.ParentId = reader.IsDBNull(reader.GetOrdinal("ParentId")) ? (int?)null : Convert.ToInt32(reader["ParentId"]);
                menu.Isactive = reader.GetByte(reader.GetOrdinal("Isactive"));

                menus.Add(menu);
                 
            }

            reader.Close();
            con.Close();
            return menus;
        }
    }
}