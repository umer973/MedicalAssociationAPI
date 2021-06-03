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
                        {"Trade",enquiry.Trade },
                        {"Comments",enquiry.Comments },
                        {"ExistingUser",enquiry.ExistingUser }

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
