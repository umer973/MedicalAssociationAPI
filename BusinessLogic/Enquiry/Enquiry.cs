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
        public List<EnquiryModel> GetEnquiry()
        {
            try
            {
                using (var query = new SqlQuery())
                {
                    var result = query.ExecuteNonQuery<EnquiryModel>("GetAllEnquiry", new Dictionary<string, object>
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

        public int InsertEnquiry(EnquiryModel enquiry)
        {
            try
            {
                using (var query = new SqlQuery())
                {
                    var result = query.ExecuteNonQuery("InsertEnquiry", new Dictionary<string, object>
                    {
                        {"FullName",enquiry.FullName },
                        {"Email",enquiry.Email},
                        {"ContactNo",enquiry.ContactNo},
                        {"Comments",enquiry.Comments },
                        {"ExistingUser",enquiry.ExistingUser },
                        {"Trade",enquiry.Trade }


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
