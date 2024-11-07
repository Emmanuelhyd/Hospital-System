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
            if (string.IsNullOrEmpty(admin.EmailId) || string.IsNullOrEmpty(admin.Password))
            {
                ViewData["ErrorMessage"] = "Please enter both email and password.";
                return View();
            }
            if (admin.EmailId == "Admin@gmail.com" && admin.Password == "123")
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
        public ActionResult Reject(AdminModel admin)
        {
            try
            {
                con.Open();
                string selectQuery = "SELECT * FROM DonorInfo WHERE Id = @Id";
                cmd = new SqlCommand(selectQuery, con);
                cmd.Parameters.AddWithValue("@Id", admin.Id);
                SqlDataReader reader = cmd.ExecuteReader();

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
                }
                reader.Close();
                string insertQuery = "INSERT INTO RejectedDonors (FirstName, LastName, EmailId, BloodGroup, Quantity) " +
                                     "VALUES (@FirstName, @LastName, @EmailId, @BloodGroup, @Quantity)";

                cmd = new SqlCommand(insertQuery, con);
                cmd.Parameters.AddWithValue("@FirstName", admin.FirstName);
                cmd.Parameters.AddWithValue("@LastName", admin.LastName);
                cmd.Parameters.AddWithValue("@EmailId", admin.EmailId);
                cmd.Parameters.AddWithValue("@BloodGroup", admin.BloodGroup);
                cmd.Parameters.AddWithValue("@Quantity", admin.Quantity);

                cmd.ExecuteNonQuery();

                string deleteQuery = "DELETE FROM DonorInfo WHERE Id = @Id";
                cmd = new SqlCommand(deleteQuery, con);
                cmd.Parameters.AddWithValue("@Id", admin.Id);
                cmd.ExecuteNonQuery(); 

                con.Close();

                return RedirectToAction("DonationRequests");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "An error occurred: " + ex.Message;
                return View();
            }
        }
        public ActionResult RejectedDonors(AdminModel admin)
        {
            con.Open();
            List<AdminModel> admins = new List<AdminModel>();
            cmd = new SqlCommand("select*from RejectedDonors", con);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                admin = new AdminModel();
                admin.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                admin.FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
                admin.LastName = reader.GetString(reader.GetOrdinal("LastName"));
                admin.EmailId = reader.GetString(reader.GetOrdinal("EmailId"));
                admin.BloodGroup = reader.GetString(reader.GetOrdinal("BloodGroup"));
                admin.Quantity = reader.GetString(reader.GetOrdinal("Quantity"));
                admins.Add(admin);
            }
            reader.Close();
            con.Close();
            return View(admins);
        }
        //Approve Donor
        public ActionResult ApproveDonor(AdminModel admin)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("SELECT * FROM DonorInfo WHERE Id = @Id", con);
                cmd.Parameters.AddWithValue("@Id", admin.Id);
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
                }
                reader.Close();
                string insertQuery = "INSERT INTO ApprovedDonations (FirstName, LastName, EmailId, DateOfBirth, PhoneNumber, Gender, BloodGroup, Quantity, Decease, StreetAddress, City, State, ZipCode, Country) " +
                                     "VALUES (@FirstName, @LastName, @EmailId, @DateOfBirth, @PhoneNumber, @Gender, @BloodGroup, @Quantity, @Decease, @StreetAddress, @City, @State, @ZipCode, @Country)";

                cmd = new SqlCommand(insertQuery, con);
                cmd.Parameters.AddWithValue("@FirstName", admin.FirstName);
                cmd.Parameters.AddWithValue("@LastName", admin.LastName);
                cmd.Parameters.AddWithValue("@EmailId", admin.EmailId);
                cmd.Parameters.AddWithValue("@DateOfBirth", admin.DateOfBirth);
                cmd.Parameters.AddWithValue("@PhoneNumber", admin.PhoneNumber);
                cmd.Parameters.AddWithValue("@Gender", admin.Gender);
                cmd.Parameters.AddWithValue("@BloodGroup", admin.BloodGroup);
                cmd.Parameters.AddWithValue("@Quantity", admin.Quantity);
                cmd.Parameters.AddWithValue("@Decease", admin.Decease);
                cmd.Parameters.AddWithValue("@StreetAddress", admin.StreetAddress);
                cmd.Parameters.AddWithValue("@City", admin.City);
                cmd.Parameters.AddWithValue("@State", admin.State);
                cmd.Parameters.AddWithValue("@ZipCode", admin.ZipCode);
                cmd.Parameters.AddWithValue("@Country", admin.Country);

                cmd.ExecuteNonQuery(); 
                string deleteQuery = "DELETE FROM DonorInfo WHERE Id = @Id";
                cmd = new SqlCommand(deleteQuery, con);
                cmd.Parameters.AddWithValue("@Id", admin.Id);
                cmd.ExecuteNonQuery();

                con.Close();
                return RedirectToAction("DonationRequests");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "An error occurred: " + ex.Message;
                return View();
            }
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
                admin.ReferenceId = reader.GetInt32(reader.GetOrdinal("ReferenceId"));
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
        public ActionResult REdit(int Id)
        {

            if (Id <= 0)
                return HttpNotFound();

            con.Open();
            
            cmd = new SqlCommand("Select * from DetailsOfFamilyRelatives where Id ='" + Id+ "' ", con);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {

                AdminModel admin = new AdminModel();

                admin.Id = Convert.ToInt32(reader["id"]);
                admin.ReferenceId = reader.GetInt32(reader.GetOrdinal("ReferenceId"));
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
                return View("AddRelativeInfo", admin);
            }
            else
            {
                return HttpNotFound();
            }
        }
        public ActionResult AddRelativeInfo(AdminModel admin)
        {
            if (admin.EmailId != null)
            {
                con.Open();
                var id = "";
                cmd = new SqlCommand("select*from DetailsOfFamilyRelatives where EmailId='" + admin.EmailId + "' ", con);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    id = reader.GetString(reader.GetOrdinal("EmailId"));
                }
                reader.Close();
                if (id != admin.EmailId)
                {
                    cmd = new SqlCommand("Insert into DetailsOfFamilyRelatives values(" + admin.ReferenceId + ",'" + admin.Name + "','" + admin.PhoneNumber + "','" + admin.EmailId + "','" + admin.Gender + "','" + admin.RelationWithDonor + "','" + admin.StreetAddress + "','" + admin.City + "','" + admin.State + "','" + admin.ZipCode + "','" + admin.Country + "')", con);
                }
                else
                {
                    cmd = new SqlCommand("update DetailsOfFamilyRelatives set ReferenceId="+ admin.ReferenceId +",Name ='" + admin.Name + "',PhoneNumber ='" + admin.PhoneNumber + "',Gender='" + admin.Gender + "',RelationWithDonor='" + admin.RelationWithDonor + "',StreetAddress='" + admin.StreetAddress + "',City='" + admin.City + "',State='" + admin.State + "' ,ZipCode ='" + admin.ZipCode + "',Country ='" + admin.Country + "' where EmailId='" + admin.EmailId + "'  ", con);
                }
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return View();
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
            try
            {
                con.Open();
                string selectQuery = "SELECT * FROM PatientInfo WHERE Id = @Id";
                cmd = new SqlCommand(selectQuery, con);
                cmd.Parameters.AddWithValue("@Id", admin.Id);

                SqlDataReader reader = cmd.ExecuteReader();

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
                }
                reader.Close();
                string insertQuery = "INSERT INTO RejectedBloodRequests (FirstName, LastName, EmailId, BloodGroup, Quantity) " +
                                     "VALUES (@FirstName, @LastName, @EmailId, @BloodGroup, @Quantity)";

                cmd = new SqlCommand(insertQuery, con);
                cmd.Parameters.AddWithValue("@FirstName", admin.FirstName);
                cmd.Parameters.AddWithValue("@LastName", admin.LastName);
                cmd.Parameters.AddWithValue("@EmailId", admin.EmailId);
                cmd.Parameters.AddWithValue("@BloodGroup", admin.BloodGroup);
                cmd.Parameters.AddWithValue("@Quantity", admin.Quantity);
                cmd.ExecuteNonQuery();
                string deleteQuery = "DELETE FROM PatientInfo WHERE Id = @Id";
                cmd = new SqlCommand(deleteQuery, con);
                cmd.Parameters.AddWithValue("@Id", admin.Id);
                cmd.ExecuteNonQuery();
                con.Close();
                return RedirectToAction("BloodRequests");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "An error occurred: " + ex.Message;
                return View();
            }
        }
        public ActionResult RejectedBloodRequests(AdminModel admin)
        {
            con.Open();
            List<AdminModel> admins = new List<AdminModel>();
            cmd = new SqlCommand("select*from RejectedBloodRequests", con);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                admin = new AdminModel();
                admin.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                admin.FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
                admin.LastName = reader.GetString(reader.GetOrdinal("LastName"));
                admin.EmailId = reader.GetString(reader.GetOrdinal("EmailId"));
                admin.BloodGroup = reader.GetString(reader.GetOrdinal("BloodGroup"));
                admin.Quantity = reader.GetString(reader.GetOrdinal("Quantity"));
                admins.Add(admin);
            }
            reader.Close();
            con.Close();
            return View(admins);
        }
        //Approve BloodRequest
        public ActionResult ApproveBloodRequest(AdminModel admin)
        {
            try
            {
                con.Open();
                string selectQuery = "SELECT * FROM PatientInfo WHERE Id = @Id";
                cmd = new SqlCommand(selectQuery, con);
                cmd.Parameters.AddWithValue("@Id", admin.Id);
                SqlDataReader reader = cmd.ExecuteReader();
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
                }
                reader.Close();
                string insertQuery = "INSERT INTO ApproveBloodRequests (FirstName, LastName, EmailId, PhoneNumber, Gender, BloodGroup, Quantity, Decease, StreetAddress, City, State, ZipCode, Country) " +
                                     "VALUES (@FirstName, @LastName, @EmailId, @PhoneNumber, @Gender, @BloodGroup, @Quantity, @Decease, @StreetAddress, @City, @State, @ZipCode, @Country)";

                cmd = new SqlCommand(insertQuery, con);
                cmd.Parameters.AddWithValue("@FirstName", admin.FirstName);
                cmd.Parameters.AddWithValue("@LastName", admin.LastName);
                cmd.Parameters.AddWithValue("@EmailId", admin.EmailId);
                cmd.Parameters.AddWithValue("@PhoneNumber", admin.PhoneNumber);
                cmd.Parameters.AddWithValue("@Gender", admin.Gender);
                cmd.Parameters.AddWithValue("@BloodGroup", admin.BloodGroup);
                cmd.Parameters.AddWithValue("@Quantity", admin.Quantity);
                cmd.Parameters.AddWithValue("@Decease", admin.Decease);
                cmd.Parameters.AddWithValue("@StreetAddress", admin.StreetAddress);
                cmd.Parameters.AddWithValue("@City", admin.City);
                cmd.Parameters.AddWithValue("@State", admin.State);
                cmd.Parameters.AddWithValue("@ZipCode", admin.ZipCode);
                cmd.Parameters.AddWithValue("@Country", admin.Country);
                cmd.ExecuteNonQuery();
                string deleteQuery = "DELETE FROM PatientInfo WHERE Id = @Id";
                cmd = new SqlCommand(deleteQuery, con);
                cmd.Parameters.AddWithValue("@Id", admin.Id);
                cmd.ExecuteNonQuery();
                con.Close();
                return RedirectToAction("BloodRequests");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "An error occurred: " + ex.Message;
                return View();
            }
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
            decimal totalBloodUnitsInLiters = 0m;

            using (var con = new SqlConnection("Uid=sa;Password=123;Initial Catalog=Hospital;Data Source=DESKTOP-OUCP9Q2"))
            {
                con.Open();

                foreach (var bloodGroup in bloodGroups)
                {
                    var cmd = new SqlCommand(@"
                SELECT SUM(CASE 
                    WHEN CHARINDEX('L', Quantity) > 0 AND TRY_CAST(SUBSTRING(Quantity, 1, LEN(Quantity) - 1) AS DECIMAL(10, 2)) IS NOT NULL THEN 
                        TRY_CAST(SUBSTRING(Quantity, 1, LEN(Quantity) - 1) AS DECIMAL(10, 2))
                    WHEN CHARINDEX('mL', Quantity) > 0 AND TRY_CAST(SUBSTRING(Quantity, 1, LEN(Quantity) - 2) AS DECIMAL(10, 2)) IS NOT NULL THEN 
                        TRY_CAST(SUBSTRING(Quantity, 1, LEN(Quantity) - 2) AS DECIMAL(10, 2)) / 1000 -- Convert mL to L
                    ELSE 0
                END)
                FROM ApprovedDonations 
                WHERE BloodGroup = @BloodGroup", con);

                    cmd.Parameters.AddWithValue("@BloodGroup", bloodGroup);
                    var result = cmd.ExecuteScalar();
                    decimal totalQuantityInLiters = result != DBNull.Value ? Convert.ToDecimal(result) : 0m;
                    string quantityFormatted = totalQuantityInLiters.ToString("0.0") + "L"; 
                    admins.Add(new AdminModel
                    {
                        BloodGroup = bloodGroup,
                        Quantity = quantityFormatted
                    });
                    totalBloodUnitsInLiters += totalQuantityInLiters; 
                }
                using (var donorCmd = new SqlCommand("SELECT COUNT(DISTINCT Id) FROM ApprovedDonations", con))
                {
                    totalDonors = (int)donorCmd.ExecuteScalar();
                }
                ViewBag.TotalDonors = totalDonors;
                ViewBag.TotalBloodUnitsInLiters = totalBloodUnitsInLiters.ToString("0.0") + "L";
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
        public ActionResult LatestDonations()
        {
            var admins = new List<AdminModel>();

            using (var con = new SqlConnection("Uid=sa;Password=123;Initial Catalog=Hospital;Data Source=DESKTOP-OUCP9Q2"))
            {
                con.Open();
                using (var cmd = new SqlCommand("SELECT * FROM DonorInfo", con))
                {
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
            }
            return View(admins);
        }

    }
}
