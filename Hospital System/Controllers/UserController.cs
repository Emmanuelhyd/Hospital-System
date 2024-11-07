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
                FROM ApprovedDonations 
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
        public ActionResult UserLogIn(UserModel user)
        {
            if (string.IsNullOrEmpty(user.EmailId) || string.IsNullOrEmpty(user.Password))
            {
                ViewData["ErrorMessage"] = "Please enter both email and password.";
                return View();
            }
            try
            {
                using (var con = new SqlConnection("Uid=sa;Password=123;Initial Catalog=Hospital;Data Source=DESKTOP-OUCP9Q2"))
                {
                    con.Open();
                    string query = "SELECT * FROM userinfo WHERE EmailId = @EmailId AND Password = @Password";

                    using (var cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@EmailId", user.EmailId);
                        cmd.Parameters.AddWithValue("@Password", user.Password);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Session["Id"] = reader.GetValue(0);
                                Session["EmailId"] = reader.GetValue(3);
                                Session["FirstName"] = reader.GetValue(1);
                                Session["LastName"] = reader.GetValue(2);
                                return RedirectToAction("UserHome");
                            }
                            else
                            {
                                ViewData["ErrorMessage"] = "Incorrect email or password.";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = "An error occurred while processing your request. Please try again later.";
                Console.WriteLine(ex.Message);
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
        public ActionResult DonationForm(UserModel user)
        {
            if (decimal.TryParse(user.Quantity?.Replace("mL", "").Trim(), out decimal quantityInML))
            {
                decimal quantityInLiters = quantityInML / 1000;
                user.Quantity = quantityInLiters.ToString("F3") + " L";
            }
            if (user.EmailId != null)
            {
                con.Open();
                cmd = new SqlCommand("Insert into DonorInfo values("+user.Id+",'" + user.FirstName + "','" + user.LastName + "','" + user.EmailId + "','" + user.DateOfBirth + "','" + user.PhoneNumber + "','" + user.Gender + "','" + user.BloodGroup + "','" + user.Quantity + "','" + user.Decease + "','" + user.StreetAddress + "','" + user.City + "','" + user.State + "','" + user.ZipCode + "','" + user.Country + "')", con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return View();
        }
        public ActionResult RelativeInfo(UserModel user)
        {
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
                //if (id != user.EmailId)
                //{
                //    cmd = new SqlCommand("Insert into DetailsOfFamilyRelatives values(" + user.ReferenceId + ",'" + user.Name + "','" + user.PhoneNumber + "','" + user.EmailId + "','" + user.Gender + "','" + user.RelationWithDonor + "','" + user.StreetAddress + "','" + user.City + "','" + user.State + "','" + user.ZipCode + "','" + user.Country + "')", con);
                //}

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
            return View();
        }
        public ActionResult BloodRequestForm(UserModel user)
        {
            if (decimal.TryParse(user.Quantity?.Replace("mL", "").Trim(), out decimal quantityInML))
            {
                decimal quantityInLiters = quantityInML / 1000;
                user.Quantity = quantityInLiters.ToString("F3") + " L";
            }
            if (user.EmailId != null)
            {
                con.Open();
                cmd = new SqlCommand("Insert Into PatientInfo Values ('" + user.FirstName + "','" + user.LastName + "','" + user.EmailId + "','" + user.PhoneNumber + "','" + user.Gender + "','" + user.BloodGroup + "','" + user.Quantity + "','" + user.Decease + "','" + user.StreetAddress + "','" + user.City + "','" + user.State + "','" + user.ZipCode + "','" + user.Country + "')", con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return View();
        }

        public ActionResult DonationHistory(UserModel user) 
        {
            con.Open();
            List<UserModel> users = new List<UserModel>();
            cmd = new SqlCommand("Select * from ApprovedDonations where EmailId='" + Session["EmailId"] +"'", con);
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
            cmd = new SqlCommand("Select * from ApproveBloodRequests where EmailId='" + Session["EmailId"] + "'", con);
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
                users.Add(user);
            }
            reader.Close();
            con.Close();
            return View(users);
        }
    }
}