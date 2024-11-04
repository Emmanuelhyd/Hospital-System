using Hospital_System.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hospital_System.Controllers
{
    public class AdminController : Controller
    {
        SqlConnection con = new SqlConnection("Uid=sa;Password=123;Initial Catalog=Hospital;Data Source=DESKTOP-OUCP9Q2");
        SqlCommand cmd = null;
        SqlDataReader reader = null;
       
        // For Admin LogIn.....
        public ActionResult AdminLogIn(AdminModel admin)
        {
            if (admin.EmailId == "Admin" && admin.Password == "123")
            {
                return RedirectToAction("AdminHome");
            }
            else
            {
              ViewData["ErrorMessage"] = "Incorrect email Id or password.";
            }
            return View();
        }
        // For Donor......
        public ActionResult DonationRequests(AdminModel admin)
        {
            con.Open();
            List<AdminModel> admins = new List<AdminModel>();
            cmd = new SqlCommand("Select*from DonorInfo", con);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                admin = new AdminModel();
                admin.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                admin.FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
                admin.LastName = reader.GetString(reader.GetOrdinal("LastName"));
                admin.EmailId = reader.GetString(reader.GetOrdinal("EmailId"));
                admin.DateOfBirth = reader.GetString(reader.GetOrdinal("DateOfBirth"));
                admin.PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber"));
                admin.Gender = reader.GetString(reader.GetOrdinal("Gender"));
                admin.BloodGroup = reader.GetString(reader.GetOrdinal("BloodGroup"));
                admin.Quantity = reader.GetString(reader.GetOrdinal("Quantity"));
                admin.Decease = reader.GetString(reader.GetOrdinal("Decease"));
                admin.StreetAddress = reader.GetString(reader.GetOrdinal("StreetAddress"));
                admin.City = reader.GetString(reader.GetOrdinal("City"));
                admin.State = reader.GetString(reader.GetOrdinal("State"));
                admin.ZipCode = reader.GetString(reader.GetOrdinal("ZipCode"));
                admin.Country = reader.GetString(reader.GetOrdinal("Country"));
                admins.Add(admin);
            }
            reader.Close();
            con.Close();
            return View(admins);
        }
        //Reject Donor 
        public ActionResult RReject(AdminModel admin)
        {
            con.Open();
            cmd = new SqlCommand("Delete From DonorInfo Where Id = '" + admin.Id + "'",con);
            cmd.ExecuteNonQuery();
            con.Close();
            return RedirectToAction("DonationRequests");
        }
        //Approve Donor
        public ActionResult ApproveDonor(AdminModel admin)
        {
            con.Open();
            cmd = new SqlCommand("select * from DonorInfo where Id='" + admin.Id + "'", con);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                admin.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                admin.FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
                admin.LastName = reader.GetString(reader.GetOrdinal("LastName"));
                admin.EmailId = reader.GetString(reader.GetOrdinal("EmailId"));
                admin.DateOfBirth = reader.GetString(reader.GetOrdinal("DateOfBirth"));
                admin.PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber"));
                admin.Gender = reader.GetString(reader.GetOrdinal("Gender"));
                admin.BloodGroup = reader.GetString(reader.GetOrdinal("BloodGroup"));
                admin.Quantity = reader.GetString(reader.GetOrdinal("Quantity"));
                admin.Decease = reader.GetString(reader.GetOrdinal("Decease"));
                admin.StreetAddress = reader.GetString(reader.GetOrdinal("StreetAddress"));
                admin.City = reader.GetString(reader.GetOrdinal("City"));
                admin.State = reader.GetString(reader.GetOrdinal("State"));
                admin.ZipCode = reader.GetString(reader.GetOrdinal("ZipCode"));
                admin.Country = reader.GetString(reader.GetOrdinal("Country"));

                cmd = new SqlCommand("Insert into ApprovedDonations values('" + admin.FirstName + "','" + admin.LastName + "','" + admin.EmailId + "','" + admin.DateOfBirth + "','" + admin.PhoneNumber + "','" + admin.Gender + "','" + admin.BloodGroup + "','" + admin.Quantity + "','" + admin.Decease + "','" + admin.StreetAddress + "','" + admin.City + "','" + admin.State + "','" + admin.ZipCode + "','" + admin.Country + "')", con);
            }
            reader.Close();
            cmd.ExecuteNonQuery();
            con.Close();
            return RedirectToAction("DonationRequests");
        }
        public ActionResult ApprovedDonations(AdminModel admin)
        {
            con.Open();
            List<AdminModel> admins = new List<AdminModel>();
            cmd = new SqlCommand("select*from ApprovedDonations", con);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                admin = new AdminModel();
                admin.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                admin.FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
                admin.LastName = reader.GetString(reader.GetOrdinal("LastName"));
                admin.EmailId = reader.GetString(reader.GetOrdinal("EmailId"));
                admin.DateOfBirth = reader.GetString(reader.GetOrdinal("DateOfBirth"));
                admin.PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber"));
                admin.Gender = reader.GetString(reader.GetOrdinal("Gender"));
                admin.BloodGroup = reader.GetString(reader.GetOrdinal("BloodGroup"));
                admin.Quantity = reader.GetString(reader.GetOrdinal("Quantity"));
                admin.Decease = reader.GetString(reader.GetOrdinal("Decease"));
                admin.StreetAddress = reader.GetString(reader.GetOrdinal("StreetAddress"));
                admin.City = reader.GetString(reader.GetOrdinal("City"));
                admin.State = reader.GetString(reader.GetOrdinal("State"));
                admin.ZipCode = reader.GetString(reader.GetOrdinal("ZipCode"));
                admin.Country = reader.GetString(reader.GetOrdinal("Country"));
                admins.Add(admin);
            }
            reader.Close();
            con.Close();
            return View(admins);
        }
        //Remove Donation Approvals
        public ActionResult ERemove(AdminModel admin)
        {
            con.Open();
            cmd = new SqlCommand("Delete from ApprovedDonations where Id='" + admin.Id + "' ", con);
            cmd.ExecuteNonQuery();
            con.Close();
            return RedirectToAction("ApprovedDonations");
        }
        // For Donor Family.....
        [HttpGet]
        public ActionResult FamilyDetails(AdminModel admin)
        {
            con.Open();
            List<AdminModel> admins = new List<AdminModel>();
            cmd = new SqlCommand("Select*from DetailsOfFamilyRelatives", con);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                admin = new AdminModel();
                admin.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                admin.Name = reader.GetString(reader.GetOrdinal("Name"));
                admin.PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber"));
                admin.EmailId = reader.GetString(reader.GetOrdinal("EmailId"));
                admin.Gender = reader.GetString(reader.GetOrdinal("Gender"));
                admin.RelationWithDonor = reader.GetString(reader.GetOrdinal("RelationWithDonor"));
                admin.StreetAddress = reader.GetString(reader.GetOrdinal("StreetAddress"));
                admin.City = reader.GetString(reader.GetOrdinal("City"));
                admin.State = reader.GetString(reader.GetOrdinal("State"));
                admin.ZipCode = reader.GetString(reader.GetOrdinal("ZipCode"));
                admin.Country = reader.GetString(reader.GetOrdinal("Country"));
                admins.Add(admin);
            }
            reader.Close();
            con.Close();
            return View(admins);
        }
        //Edit Family Details
        public ActionResult BEdit(string id)
        {
            con.Open();
            AdminModel admin = new AdminModel();
            cmd = new SqlCommand("Select * from DetailsOfFamilyRelatives where EmailId ='" + id + "' ", con);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                admin.Name = reader.GetString(reader.GetOrdinal("Name"));
                admin.PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber"));
                admin.EmailId = reader.GetString(reader.GetOrdinal("EmailId"));
                admin.Gender = reader.GetString(reader.GetOrdinal("Gender"));
                admin.RelationWithDonor = reader.GetString(reader.GetOrdinal("RelationWithDonor"));
                admin.StreetAddress = reader.GetString(reader.GetOrdinal("StreetAddress"));
                admin.City = reader.GetString(reader.GetOrdinal("City"));
                admin.State = reader.GetString(reader.GetOrdinal("State"));
                admin.ZipCode = reader.GetString(reader.GetOrdinal("ZipCode"));
                admin.Country = reader.GetString(reader.GetOrdinal("Country"));
                reader.Close();
                con.Close();
                return View("RelativeInfo", admin);
            }
            else
            {
                return HttpNotFound();
            }
        }
        //Delete Family Details
        public ActionResult BDelete(AdminModel admin)
        {
            con.Open();
            cmd = new SqlCommand("Delete from DetailsOfFamilyRelatives where Id='" + admin.Id + "' ", con);
            cmd.ExecuteNonQuery();
            con.Close();
            return RedirectToAction("FamilyDetails");
        }
        // For User Blood Request..... 
        [HttpGet]
        public ActionResult BloodRequests(AdminModel admin)
        {
            con.Open();
            List<AdminModel> Admins = new List<AdminModel>();
            cmd = new SqlCommand("Select*from PatientInfo", con);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                admin = new AdminModel();
                admin.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                admin.FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
                admin.LastName = reader.GetString(reader.GetOrdinal("LastName"));
                admin.EmailId = reader.GetString(reader.GetOrdinal("EmailId"));
                admin.PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber"));
                admin.Gender = reader.GetString(reader.GetOrdinal("Gender"));
                admin.BloodGroup = reader.GetString(reader.GetOrdinal("BloodGroup"));
                admin.Quantity = reader.GetString(reader.GetOrdinal("Quantity"));
                admin.Decease = reader.GetString(reader.GetOrdinal("Decease"));
                admin.StreetAddress = reader.GetString(reader.GetOrdinal("StreetAddress"));
                admin.City = reader.GetString(reader.GetOrdinal("City"));
                admin.State = reader.GetString(reader.GetOrdinal("State"));
                admin.ZipCode = reader.GetString(reader.GetOrdinal("ZipCode"));
                admin.Country = reader.GetString(reader.GetOrdinal("Country"));
                Admins.Add(admin);
            }
            reader.Close();
            con.Close();
            return View(Admins);
        }
        //Reject BloodRequest
        public ActionResult EReject(AdminModel admin)
        {
            con.Open();
            cmd = new SqlCommand("Delete from PatientInfo where Id='" + admin.Id + "' ", con);
            cmd.ExecuteNonQuery();
            con.Close();
            return RedirectToAction("BloodRequests");
        }
        //Approve BloodRequest
        public ActionResult ApproveBloodRequest(AdminModel admin)
        {

            con.Open();
            cmd = new SqlCommand("select*from PatientInfo where id=" + admin.Id + "", con);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                admin.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                admin.FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
                admin.LastName = reader.GetString(reader.GetOrdinal("LastName"));
                admin.EmailId = reader.GetString(reader.GetOrdinal("EmailId"));
                admin.PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber"));
                admin.Gender = reader.GetString(reader.GetOrdinal("Gender"));
                admin.BloodGroup = reader.GetString(reader.GetOrdinal("BloodGroup"));
                admin.Quantity = reader.GetString(reader.GetOrdinal("Quantity"));
                admin.Decease = reader.GetString(reader.GetOrdinal("Decease"));
                admin.StreetAddress = reader.GetString(reader.GetOrdinal("StreetAddress"));
                admin.City = reader.GetString(reader.GetOrdinal("City"));
                admin.State = reader.GetString(reader.GetOrdinal("State"));
                admin.ZipCode = reader.GetString(reader.GetOrdinal("ZipCode"));
                admin.Country = reader.GetString(reader.GetOrdinal("Country"));
                cmd = new SqlCommand("Insert Into ApproveBloodRequests Values ('" + admin.FirstName + "','" + admin.LastName + "','" + admin.EmailId + "','" + admin.PhoneNumber + "','" + admin.Gender + "','" + admin.BloodGroup + "','" + admin.Quantity + "','" + admin.Decease + "','" + admin.StreetAddress + "','" + admin.City + "','" + admin.State + "','" + admin.ZipCode + "','" + admin.Country + "')", con);
            }
            reader.Close();
            cmd.ExecuteNonQuery();
            con.Close();
            return RedirectToAction("BloodRequests");
        }
        public ActionResult ApprovedBloodRequests(AdminModel admin)
        {
            con.Open();
            List<AdminModel> Admins = new List<AdminModel>();
            cmd = new SqlCommand("Select*from ApproveBloodRequests", con);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                admin = new AdminModel();
                admin.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                admin.FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
                admin.LastName = reader.GetString(reader.GetOrdinal("LastName"));
                admin.EmailId = reader.GetString(reader.GetOrdinal("EmailId"));
                admin.PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber"));
                admin.Gender = reader.GetString(reader.GetOrdinal("Gender"));
                admin.BloodGroup = reader.GetString(reader.GetOrdinal("BloodGroup"));
                admin.Quantity = reader.GetString(reader.GetOrdinal("Quantity"));
                admin.Decease = reader.GetString(reader.GetOrdinal("Decease"));
                admin.StreetAddress = reader.GetString(reader.GetOrdinal("StreetAddress"));
                admin.City = reader.GetString(reader.GetOrdinal("City"));
                admin.State = reader.GetString(reader.GetOrdinal("State"));
                admin.ZipCode = reader.GetString(reader.GetOrdinal("ZipCode"));
                admin.Country = reader.GetString(reader.GetOrdinal("Country"));
                Admins.Add(admin);
            }
            reader.Close();
            con.Close();
            return View(Admins);
        }
        //Remove BloodApprovals
        public ActionResult DRemove(AdminModel admin)
        {
            con.Open();
            cmd = new SqlCommand("Delete from ApproveBloodRequests where Id='" + admin.Id + "' ", con);
            cmd.ExecuteNonQuery();
            con.Close();
            return RedirectToAction("ApprovedBloodRequests");
        }
        public ActionResult AdminHome()
        {
            var bloodGroups = new List<string> { "A+", "A-", "B+", "B-", "AB+", "AB-", "O+", "O-" };
            var admins = new List<AdminModel>();
            int totalDonors = 0;
            decimal totalBloodUnits = 0;

            using (var con = new SqlConnection("Uid=sa;Password=123;Initial Catalog=Hospital;Data Source=DESKTOP-OUCP9Q2"))
            {
                con.Open();

                // Calculate total blood units per blood group
                foreach (var bloodGroup in bloodGroups)
                {
                    using (var cmd = new SqlCommand("SELECT SUM(CAST(SUBSTRING(Quantity, 1, LEN(Quantity) - 1) AS DECIMAL(10, 2))) FROM ApprovedDonations WHERE BloodGroup = @BloodGroup", con))
                    {
                        cmd.Parameters.AddWithValue("@BloodGroup", bloodGroup);
                        var result = cmd.ExecuteScalar();
                        decimal totalQuantity = result != DBNull.Value ? Convert.ToDecimal(result) : 0m;
                        string quantity = totalQuantity.ToString("0.0") + "L";

                        admins.Add(new AdminModel
                        {
                            BloodGroup = bloodGroup,
                            Quantity = quantity,
                        });

                        totalBloodUnits += totalQuantity * 1000;
                    }
                }

                // Get total donors
                using (var donorCmd = new SqlCommand("Select Count(*) From ApprovedDonations", con))
                {
                    totalDonors = (int)donorCmd.ExecuteScalar();
                }

                ViewBag.TotalDonors = totalDonors;
                ViewBag.TotalBloodUnits = totalBloodUnits;

                // Get latest donor information
                using (var cmd = new SqlCommand("Select * From DonorInfo", con))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var admin = new AdminModel
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                            LastName = reader.GetString(reader.GetOrdinal("LastName")),
                            EmailId = reader.GetString(reader.GetOrdinal("EmailId")),
                            DateOfBirth = reader.GetString(reader.GetOrdinal("DateOfBirth")),
                            PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber")),
                            Gender = reader.GetString(reader.GetOrdinal("Gender")),
                            BloodGroup = reader.GetString(reader.GetOrdinal("BloodGroup")),
                            Quantity = reader.GetString(reader.GetOrdinal("Quantity")),
                            Decease = reader.GetString(reader.GetOrdinal("Decease")),
                            StreetAddress = reader.GetString(reader.GetOrdinal("StreetAddress")),
                            City = reader.GetString(reader.GetOrdinal("City")),
                            State = reader.GetString(reader.GetOrdinal("State")),
                            ZipCode = reader.GetString(reader.GetOrdinal("ZipCode")),
                            Country = reader.GetString(reader.GetOrdinal("Country")),
                        };
                        admins.Add(admin);
                    }
                }
            }
            return View(admins);
        }

        public ActionResult Details(AdminModel admin)
        {
            con.Open();
            List<AdminModel> admins = new List<AdminModel>();
            cmd = new SqlCommand("Select*from ApprovedDonations where BloodGroup='" + admin.BloodGroup + "'", con);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                admin = new AdminModel();
                admin.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                admin.FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
                admin.LastName = reader.GetString(reader.GetOrdinal("LastName"));
                admin.EmailId = reader.GetString(reader.GetOrdinal("EmailId"));
                admin.DateOfBirth = reader.GetString(reader.GetOrdinal("DateOfBirth"));
                admin.PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber"));
                admin.Gender = reader.GetString(reader.GetOrdinal("Gender"));
                admin.BloodGroup = reader.GetString(reader.GetOrdinal("BloodGroup"));
                admin.Quantity = reader.GetString(reader.GetOrdinal("Quantity"));
                admin.Decease = reader.GetString(reader.GetOrdinal("Decease"));
                admin.StreetAddress = reader.GetString(reader.GetOrdinal("StreetAddress"));
                admin.City = reader.GetString(reader.GetOrdinal("City"));
                admin.State = reader.GetString(reader.GetOrdinal("State"));
                admin.ZipCode = reader.GetString(reader.GetOrdinal("ZipCode"));
                admin.Country = reader.GetString(reader.GetOrdinal("Country"));
                admins.Add(admin);
            }
            reader.Close();
            con.Close();
            return View(admins);
        }
        public ActionResult TotalDonors(AdminModel admin) 
        {
            con.Open();
            List<AdminModel> admins = new List<AdminModel>();
            cmd = new SqlCommand("Select*from ApprovedDonations", con);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                admin = new AdminModel();
                admin.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                admin.FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
                admin.LastName = reader.GetString(reader.GetOrdinal("LastName"));
                admin.EmailId = reader.GetString(reader.GetOrdinal("EmailId"));
                admin.DateOfBirth = reader.GetString(reader.GetOrdinal("DateOfBirth"));
                admin.PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber"));
                admin.Gender = reader.GetString(reader.GetOrdinal("Gender"));
                admin.BloodGroup = reader.GetString(reader.GetOrdinal("BloodGroup"));
                admin.Quantity = reader.GetString(reader.GetOrdinal("Quantity"));
                admin.Decease = reader.GetString(reader.GetOrdinal("Decease"));
                admin.StreetAddress = reader.GetString(reader.GetOrdinal("StreetAddress"));
                admin.City = reader.GetString(reader.GetOrdinal("City"));
                admin.State = reader.GetString(reader.GetOrdinal("State"));
                admin.ZipCode = reader.GetString(reader.GetOrdinal("ZipCode"));
                admin.Country = reader.GetString(reader.GetOrdinal("Country"));
                admins.Add(admin);
            }
            reader.Close();
            con.Close();
            return View(admins);
        }
        public ActionResult LatestDonorInfo(AdminModel admin) 
        {
            con.Open();
            List<AdminModel> admins = new List<AdminModel>();
            cmd = new SqlCommand("select*from DonorInfo where Id='"+ admin.Id+ "'",con);
            reader = cmd.ExecuteReader();
            while (reader.Read()) 
            {
                admin = new AdminModel();
                admin.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                admin.FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
                admin.LastName = reader.GetString(reader.GetOrdinal("LastName"));
                admin.EmailId = reader.GetString(reader.GetOrdinal("EmailId"));
                admin.DateOfBirth = reader.GetString(reader.GetOrdinal("DateOfBirth"));
                admin.PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber"));
                admin.Gender = reader.GetString(reader.GetOrdinal("Gender"));
                admin.BloodGroup = reader.GetString(reader.GetOrdinal("BloodGroup"));
                admin.Quantity = reader.GetString(reader.GetOrdinal("Quantity"));
                admin.Decease = reader.GetString(reader.GetOrdinal("Decease"));
                admin.StreetAddress = reader.GetString(reader.GetOrdinal("StreetAddress"));
                admin.City = reader.GetString(reader.GetOrdinal("City"));
                admin.State = reader.GetString(reader.GetOrdinal("State"));
                admin.ZipCode = reader.GetString(reader.GetOrdinal("ZipCode"));
                admin.Country = reader.GetString(reader.GetOrdinal("Country"));
                admins.Add(admin);
            }
            reader.Close();
            con.Close();
            return View(admins);
        }
    }
}
