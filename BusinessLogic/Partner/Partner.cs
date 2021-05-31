using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel.Models;
using DbHelper.DbContext;

namespace BusinessLogic.Partner
{
    public class Partner : IPartner
    {
        public List<PartnerModel> GetPartners()
        {
            try
            {
                using (var query = new SqlQuery())
                {
                    var result = query.ExecuteNonQuery<PartnerModel>("sp_GetPartners", new Dictionary<string, object>
                    {
                        {"PId",2 }

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
    }
}
