using Hospital_System.DAL;
using Hospital_System.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Hospital_System.Controllers
{
    public class UserController : Controller
    {
        SqlConnection con = new SqlConnection("Uid=sa;Password=123;Initial Catalog=Hospital;Data Source=DESKTOP-OUCP9Q2");
        SqlCommand cmd = null;
        SqlDataReader reader = null;
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UserHome()
        {
            var bloodGroups = new List<string> { "A+", "A-", "B+", "B-", "AB+", "AB-", "O+", "O-" };
            var users = new List<UserModel>();

            var connectionString = "Uid=sa;Password=123;Initial Catalog=Hospital;Data Source=DESKTOP-OUCP9Q2";
            using (var con = new SqlConnection(connectionString))
            {
                con.Open();
                foreach (var bloodGroup in bloodGroups)
                {
                    var cmd = new SqlCommand(@"
                SELECT SUM(CASE
                    WHEN CHARINDEX('L', Quantity) > 0 AND TRY_CAST(SUBSTRING(Quantity, 1, LEN(Quantity) - 1) AS DECIMAL(5, 2)) IS NOT NULL THEN 
                        TRY_CAST(SUBSTRING(Quantity, 1, LEN(Quantity) - 1) AS DECIMAL(5, 2))
                    WHEN CHARINDEX('mL', Quantity) > 0 AND TRY_CAST(SUBSTRING(Quantity, 1, LEN(Quantity) - 2) AS DECIMAL(5, 2)) IS NOT NULL THEN 
                        TRY_CAST(SUBSTRING(Quantity, 1, LEN(Quantity) - 2) AS DECIMAL(5, 2)) / 1000
                    ELSE 0
                END) 
                FROM DonorInfo 
                WHERE BloodGroup = @BloodGroup", con);
                    cmd.Parameters.AddWithValue("@BloodGroup", bloodGroup);

                    var result = cmd.ExecuteScalar();
                    var quantity = result != DBNull.Value
                        ? (Convert.ToDecimal(result)).ToString("F2") + "L" 
                        : "0.00L"; 
                    users.Add(new UserModel
                    {
                        BloodGroup = bloodGroup,
                        Quantity = quantity
                    });
                }
                con.Close();
            }
            return View(users);
        }
        // For User LogIn.....
        public ActionResult UserLogIn(BloodLogin blood)
        {
          
            con.Open();
            cmd = new SqlCommand("select Id,FirstName,LastName,EmailId,Password from userinfo where EmailId ='" + blood.EmailId + "' and Password='" + blood.Password + "'", con);
            reader = cmd.ExecuteReader();
            if(reader.Read())
            {

                if (!reader.IsDBNull(reader.GetOrdinal("Id")))
                {

                    decimal bloodId = reader.GetInt32(reader.GetOrdinal("Id"));
                    blood.Id = Convert.ToInt32(bloodId);
                }
                string Email = reader.GetString(reader.GetOrdinal("EmailId"));
                string Pass = reader.GetString(reader.GetOrdinal("Password"));

                string FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
                string LastName = reader.GetString(reader.GetOrdinal("LastName"));
                if(blood.EmailId ==Email  && blood.Password== Pass)
                {

                   
                        Session["Id"] = blood.Id;
                        Session["EmailId"] = blood.EmailId;
                        blood.FirstName = FirstName;
                        Session["FirstName"] = blood.FirstName;
                        blood.LastName = LastName;
                        Session["LastName"] = blood.LastName;
                        return RedirectToAction("UserHome");
                    
                }
            }
            else
            {
                TempData["Error"] = "Invalid UserName or Password";
            }
            return View();



        }
        private string connectionString = "Uid=sa;Password=123;Initial Catalog=Hospital;Data Source=DESKTOP-OUCP9Q2";

        [HttpGet]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassword(UserModel user)
        {
            if (string.IsNullOrEmpty(user.EmailId) || string.IsNullOrEmpty(user.Password))
            {
                ModelState.AddModelError("", "Email ID and Password are required.");
                return View();
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM UserInfo WHERE emailid = @EmailId", con))
                {
                    cmd.Parameters.AddWithValue("@EmailId", user.EmailId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Close();
                            using (SqlCommand updateCmd = new SqlCommand("UPDATE UserInfo SET Password = @Password WHERE emailid = @EmailId", con))
                            {
                                updateCmd.Parameters.AddWithValue("@Password", user.Password);
                                updateCmd.Parameters.AddWithValue("@EmailId", user.EmailId);

                                int rowsAffected = updateCmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    ViewBag.SuccessMessage = "Your password has been reset successfully.";
                                }
                                else
                                {
                                    ModelState.AddModelError("", "Failed to update the password. Please try again.");
                                }
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("", "User not found.");
                        }
                    }
                }
            }
            return View(); 
        }
        // For User Registration.....
        public ActionResult RegisterForm(UserModel user)
        {
            if (user.EmailId != null)
            {
                con.Open();
                cmd = new SqlCommand("insert into userinfo values ('" + user.FirstName + "','" + user.LastName + "','" + user.EmailId + "','" + user.Password + "','" + user.DateOfBirth + "','" + user.PhoneNumber + "','" + user.Address + "')", con);
                cmd.ExecuteNonQuery();
                con.Close();
                //ViewData["SuccessMessage"] = "Registration Successfull";
                return RedirectToAction("UserLogin");
            }
            return View();
        }
        public BloodLogin GetLogin(int Id)
        {
            BloodLogin blood = new BloodLogin();
            con.Open();
            cmd = new SqlCommand("select * from userinfo where Id= " + Id+"", con);
            reader = cmd.ExecuteReader();
            if(reader.Read())
            {
                blood.Id = Convert.ToInt32(reader["Id"]);
                blood.FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
                blood.LastName = reader.GetString(reader.GetOrdinal("LastName"));
                blood.EmailId = reader.GetString(reader.GetOrdinal("EmailId"));
                blood.Password = reader.GetString(reader.GetOrdinal("Password"));
                blood.PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber"));
                blood.DateOfBirth = reader.GetString(reader.GetOrdinal("DateOfBirth"));
                blood.Address = reader.GetString(reader.GetOrdinal("Address"));
            }
            reader.Close();
            con.Close();
            return blood;
        }
        public ActionResult DonationForm(UserModel user)
        {
            if (decimal.TryParse(user.Quantity?.Replace("mL", "").Trim(), out decimal quantityInML))
            {
                decimal quantityInLiters = quantityInML / 1000;
                user.Quantity = quantityInLiters.ToString("F3") + " L";
            }

            int loggedInUserId = Convert.ToInt32(Session["Id"]);

            BloodLogin blood = GetLogin(loggedInUserId);
            user.Id = blood.Id;
            if (user.EmailId != null)
            {
                user.IsApproved = "pending";
                con.Open();
                cmd = new SqlCommand("Insert into DonorInfo values("+user.Id+",'" + user.FirstName + "','" + user.LastName + "','" + user.EmailId + "','" + user.DateOfBirth + "','" + user.PhoneNumber + "','" + user.Gender + "','" + user.BloodGroup + "','" + user.Quantity + "','" + user.Decease + "','" + user.StreetAddress + "','" + user.City + "','" + user.State + "','" + user.ZipCode + "','" + user.Country + "','"+user.IsApproved+"')", con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return View(user);
        }
        public ActionResult RelativeInfo(UserModel user)
        {
            int loggedInUserId = Convert.ToInt32(Session["Id"]);

            BloodLogin blood = GetLogin(loggedInUserId);

            user.ReferenceId = blood.Id;


            if (user.EmailId != null)
            {
                con.Open();
                var id = "";
                cmd = new SqlCommand("select*from DetailsOfFamilyRelatives where EmailId='" + user.EmailId + "' ", con);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    id = reader.GetString(reader.GetOrdinal("EmailId"));
                }
                reader.Close();

               
                if (id != user.EmailId)
                {

                    cmd = new SqlCommand("INSERT INTO DetailsOfFamilyRelatives (ReferenceId, Name, PhoneNumber, EmailId, Gender, RelationWithDonor, StreetAddress, City, State, ZipCode, Country) " +
                                 "VALUES (" + user.ReferenceId + ", '" +
                                 user.Name.Replace("'", "''") + "', '" +
                                 user.PhoneNumber.Replace("'", "''") + "', '" +
                                 user.EmailId.Replace("'", "''") + "', '" +
                                 user.Gender.Replace("'", "''") + "', '" +
                                 user.RelationWithDonor.Replace("'", "''") + "', '" +
                                 user.StreetAddress.Replace("'", "''") + "', '" +
                                 user.City.Replace("'", "''") + "', '" +
                                 user.State.Replace("'", "''") + "', '" +
                                 user.ZipCode.Replace("'", "''") + "', '" +
                                 user.Country.Replace("'", "''") + "')", con);

                }

                else
                {
                    cmd = new SqlCommand("update DetailsOfFamilyRelatives set ReferenceId=" + user.ReferenceId + ",Name ='" + user.Name + "',PhoneNumber ='" + user.PhoneNumber + "',Gender='" + user.Gender + "',RelationWithDonor='" + user.RelationWithDonor + "',StreetAddress='" + user.StreetAddress + "',City='" + user.City + "',State='" + user.State + "' ,ZipCode ='" + user.ZipCode + "',Country ='" + user.Country + "' where EmailId='" + user.EmailId + "'  ", con);
                }
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return View(user);
        }
        public ActionResult BloodRequestForm(UserModel user)
        {
            if (decimal.TryParse(user.Quantity?.Replace("mL", "").Trim(), out decimal quantityInML))
            {
                decimal quantityInLiters = quantityInML / 1000;
                user.Quantity = quantityInLiters.ToString("F3") + " L";
            }

            int loggedInUserId = Convert.ToInt32(Session["Id"]);

            BloodLogin blood = GetLogin(loggedInUserId);
            user.Id = blood.Id;

            if (user.EmailId != null)
            {
                user.IsApproved = "pending";
                con.Open();
                cmd = new SqlCommand("Insert Into PatientInfo Values ('" + user.Id + "','" + user.FirstName + "','" + user.LastName + "','" + user.EmailId + "','" + user.PhoneNumber + "','" + user.Gender + "','" + user.BloodGroup + "','" + user.Quantity + "','" + user.Decease + "','" + user.StreetAddress + "','" + user.City + "','" + user.State + "','" + user.ZipCode + "','" + user.Country + "','"+user.IsApproved+"')", con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return View(user);
        }

        public ActionResult DonationHistory(UserModel user) 
        {
            con.Open();
            List<UserModel> users = new List<UserModel>();
            cmd = new SqlCommand("Select * from DonorInfo where EmailId='" + Session["EmailId"] +"'", con);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                user = new UserModel();
                user.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                user.FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
                user.LastName = reader.GetString(reader.GetOrdinal("LastName"));
                user.EmailId = reader.GetString(reader.GetOrdinal("EmailId"));
                user.DateOfBirth = reader.GetString(reader.GetOrdinal("DateOfBirth"));
                user.PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber"));
                user.Gender = reader.GetString(reader.GetOrdinal("Gender"));
                user.BloodGroup = reader.GetString(reader.GetOrdinal("BloodGroup"));
                user.Quantity = reader.GetString(reader.GetOrdinal("Quantity"));
                user.Decease = reader.GetString(reader.GetOrdinal("Decease"));
                user.StreetAddress = reader.GetString(reader.GetOrdinal("StreetAddress"));
                user.City = reader.GetString(reader.GetOrdinal("City"));
                user.State = reader.GetString(reader.GetOrdinal("State"));
                user.ZipCode = reader.GetString(reader.GetOrdinal("ZipCode"));
                user.Country = reader.GetString(reader.GetOrdinal("Country"));
                user.IsApproved = reader.GetString(reader.GetOrdinal("IsApproved"));
                users.Add(user);
            }
            reader.Close();
            con.Close();
            return View(users);
        }
        public ActionResult BloodRequestHistory(UserModel user)
        {
            con.Open();
            List<UserModel> users = new List<UserModel>();
            cmd = new SqlCommand("Select * from DonorInfo where EmailId='" + Session["EmailId"] + "'", con);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                user = new UserModel();
                user.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                user.FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
                user.LastName = reader.GetString(reader.GetOrdinal("LastName"));
                user.EmailId = reader.GetString(reader.GetOrdinal("EmailId"));
                user.PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber"));
                user.Gender = reader.GetString(reader.GetOrdinal("Gender"));
                user.BloodGroup = reader.GetString(reader.GetOrdinal("BloodGroup"));
                user.Quantity = reader.GetString(reader.GetOrdinal("Quantity"));
                user.Decease = reader.GetString(reader.GetOrdinal("Decease"));
                user.StreetAddress = reader.GetString(reader.GetOrdinal("StreetAddress"));
                user.City = reader.GetString(reader.GetOrdinal("City"));
                user.State = reader.GetString(reader.GetOrdinal("State"));
                user.ZipCode = reader.GetString(reader.GetOrdinal("ZipCode"));
                user.Country = reader.GetString(reader.GetOrdinal("Country"));
                user.IsApproved = reader.GetString(reader.GetOrdinal("IsApproved"));
                users.Add(user);
            }
            reader.Close();
            con.Close();
            return View(users);
        }
    }
}