using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel.Models;
using DbHelper.DbContext;
using System.Data.SqlClient;
using System.Data;

namespace BusinessLogic.Enquiry
{
    public class Enquiry : IEnquiry
    {

        private readonly SqlQuery query;
        private readonly SqlConnection con;
        DataSet result = new DataSet();
        Dictionary<string, object> resultSet = new Dictionary<string, object>();

        public Enquiry()
        {
            query = new SqlQuery();
            con = new SqlConnection(query.Database.Connection.ConnectionString);
        }

        public object GetAllRegistrations()
        {
            try
            {
                

                SqlCommand cmd = new SqlCommand("GetAllRegistrations", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(result); 
                
                if(result.Tables.Count>0)
                {
                    resultSet.Add("Registration", result.Tables[0].Rows.Count > 0 ? result.Tables[0] : null);
                }             

            }
            catch (Exception ex)
            {
                //Logger.LogError("Admin:Login", ex.Message);
                throw;
            }
            return resultSet;
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
            int myRandomNo = rnd.Next(10000000, 99999999);
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
