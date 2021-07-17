using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel.Models;
using DbHelper.DbContext;

namespace BusinessLogic.Enquiry
{
    public class Enquiry : IEnquiry
    {
        public List<Registration> GetRegistration()
        {
            try
            {
                using (var query = new SqlQuery())
                {
                    var result = query.ExecuteNonQuery<Registration>("GetAllEnquiry", new Dictionary<string, object>
                    {
                        {"PId",1 }

                    }).ToList();
                    return result;
                }
            }
            catch (Exception ex)
            {
                //Logger.LogError("Client:GetClients", ex.Message);
                throw;
            }
        }

        public int InsertRegistration(Registration registration)
        {
            try
            {
                using (var query = new SqlQuery())
                {
                    var result = query.ExecuteNonQuery("sp_InsertRegistration", new Dictionary<string, object>
                    {

                        { "RegistrationNo", getRandoM()},
                        { "FirstName", registration.PersonalDetails.FirstName},
                         { "LastName", registration.PersonalDetails.LastName},
                        { "MiddleName", registration.PersonalDetails.MiddleName},                      
                        { "FatherName", registration.PersonalDetails.FatherName},
                        { "FatherFirstName", registration.PersonalDetails.FatherFirstName},
                        { "FatherMiddleName", registration.PersonalDetails.FatherMiddleName},
                        { "CompanyId", registration.PersonalDetails.CompanyId},
                        { "DivisionId", registration.PersonalDetails.DivisionId},
                        { "DesignationId", registration.PersonalDetails.DesignationId},
                        { "EmpCode", registration.PersonalDetails.EmpCode},
                        { "DateofJoining", registration.PersonalDetails.DateofJoining},
                        { "ProfilePic", registration.PersonalDetails.ProfilePic},
                        { "Country", registration.AddressDetails.Country},
                        { "State", registration.AddressDetails.State},
                        { "District", registration.AddressDetails.District},
                        { "PoliceStation", registration.AddressDetails.PoliceStation},
                        { "Street", registration.AddressDetails.Street},
                        { "Lane", registration.AddressDetails.Lane},
                        { "HouseNo", registration.AddressDetails.HouseNo},
                        { "EmailId", registration.ContactDetails.EmailId},                      
                        { "ContactNo", registration.ContactDetails.ContactNo},
                        { "LandlineNo", registration.ContactDetails.LandlineNo },


                    });
                    return result;
                }
            }
            catch (Exception ex)
            {
                //Logger.LogError("Admin:Login", ex.Message);
                string msg = ex.ToString();
                throw;
            }
        }

        private object getRandoM()
        {
            Random rnd = new Random();
            int myRandomNo= rnd.Next(10000000, 99999999);
            string regno = "Reg" + Convert.ToString(myRandomNo);
            return regno;
        }

        public int InsertDownloads(DownloadModel download)
        {
            try
            {
                using (var query = new SqlQuery())
                {
                    var result = query.ExecuteNonQuery("InsertDownloads", new Dictionary<string, object>
                    {
                        {"Name",download.Name },
                        {"Email",download.Email},
                        {"ConatcNo",download.ContactNo},
                        {"Source",download.Source },
                        {"FilePath",download.Filepath }

                    });
                    return result;
                }
            }
            catch (Exception ex)
            {
                //Logger.LogError("Admin:Login", ex.Message);
                string msg = ex.ToString();
                throw;
            }
        }
    }
}
