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
                    var result = query.ExecuteNonQuery("Registration", new Dictionary<string, object>
                    {
                        { "Logo", registration.PersonalDetails.Logo},
                        { "UserName", registration.PersonalDetails.UserName},
                        { "MidName", registration.PersonalDetails.MidName},
                        { "LastName", registration.PersonalDetails.LastName},
                        { "FUserName", registration.PersonalDetails.FUserName},
                        { "FMiddleName", registration.PersonalDetails.FMiddleName},
                        { "FLastName", registration.PersonalDetails.FLastName},
                        { "address", registration.AddressDetails.address},
                        { "country", registration.AddressDetails.country},
                        { "state", registration.AddressDetails.state},
                        { "district", registration.AddressDetails.district},
                        { "policestation", registration.AddressDetails.policestation},
                        { "street", registration.AddressDetails.street},
                        { "houseno", registration.AddressDetails.houseno},
                        { "Laneno", registration.AddressDetails.Laneno},
                        { "company", registration.PersonalDetails.company},
                        { "division", registration.PersonalDetails.division},
                        { "designation", registration.PersonalDetails.designation},
                        { "employeecode", registration.PersonalDetails.employeecode},
                        { "joining", registration.PersonalDetails.joining},
                        { "Email", registration.PersonalDetails.Email},
                        { "ContactNo", registration.ContactDetails.ContactNo},
                        { "Comments", registration.ContactDetails.LandlineNo }
                      

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
