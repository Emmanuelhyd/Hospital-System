using Hospital_System.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
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

            using (var con = new SqlConnection("Uid=sa;Password=123;Initial Catalog=Hospital;Data Source=DESKTOP-OUCP9Q2"))
            {
                con.Open();
                foreach (var bloodGroup in bloodGroups)
                {
                    var cmd = new SqlCommand("SELECT SUM(CAST(SUBSTRING(Quantity, 1, LEN(Quantity) - 1) AS DECIMAL(5, 2))) FROM ApprovedDonations WHERE BloodGroup = @BloodGroup", con);
                    cmd.Parameters.AddWithValue("@BloodGroup", bloodGroup);
                    var result = cmd.ExecuteScalar();

                    var quantity = result != DBNull.Value
                        ? (Convert.ToDecimal(result)).ToString("F1") + "L"
                        : "0.0L";
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
        // For Admin LogIn.....
        public ActionResult UserLogIn(AdminModel admin)
        {

            con.Open();
            cmd = new SqlCommand("Select*from userinfo where EmailId='" + admin.EmailId + "' and Password='" + admin.Password + "'", con);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                if (admin.EmailId == reader.GetString(3) && admin.Password == reader.GetString(4))
                {
                    return RedirectToAction("UserHome");
                }
            }
            else if (admin.EmailId != null && admin.Password != null)
            {
                ViewData["ErrorMessage"] = "Incorrect email Id or password.";
            }
            reader.Close();
            con.Close();
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
            }
            return View();
        }
        public ActionResult DonationForm(UserModel user)
        {
            if (user.EmailId != null)
            {
                con.Open();
                cmd = new SqlCommand("Insert into DonorInfo values('" + user.FirstName + "','" + user.LastName + "','" + user.EmailId + "','" + user.DateOfBirth + "','" + user.PhoneNumber + "','" + user.Gender + "','" + user.BloodGroup + "','" + user.Quantity + "','" + user.Decease + "','" + user.StreetAddress + "','" + user.City + "','" + user.State + "','" + user.ZipCode + "','" + user.Country + "')", con);
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
                if (id != user.EmailId)
                {
                    cmd = new SqlCommand("Insert into DetailsOfFamilyRelatives values('" + user.Name + "','" + user.PhoneNumber + "','" + user.EmailId + "','" + user.Gender + "','" + user.RelationWithDonor + "','" + user.StreetAddress + "','" + user.City + "','" + user.State + "','" + user.ZipCode + "','" + user.Country + "')", con);
                }
                else
                {
                    cmd = new SqlCommand("update DetailsOfFamilyRelatives set Name ='" + user.Name + "',PhoneNumber ='" + user.PhoneNumber + "',Gender='" + user.Gender + "',RelationWithDonor='" + user.RelationWithDonor + "',StreetAddress='" + user.StreetAddress + "',City='" + user.City + "',State='" + user.State + "' ,ZipCode ='" + user.ZipCode + "',Country ='" + user.Country + "' where EmailId='" + user.EmailId + "'  ", con);
                }
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return View();
        }
        public ActionResult BloodRequestForm(UserModel user)
        {
            if (user.EmailId != null)
            {
                con.Open();
                cmd = new SqlCommand("Insert Into PatientInfo Values ('" + user.FirstName + "','" + user.LastName + "','" + user.EmailId + "','" + user.PhoneNumber + "','" + user.Gender + "','" + user.BloodGroup + "','" + user.Quantity + "','" + user.Decease + "','" + user.StreetAddress + "','" + user.City + "','" + user.State + "','" + user.ZipCode + "','" + user.Country + "')", con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return View();
        }
    }
}