using DbHelper.DbContext;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class GlobalData
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }

        public List<CommonData> GetCompanyDetails()
        {
            try
            {
                using (var query = new SqlQuery())
                {
                    var result = query.ExecuteNonQuery<CommonData>("GetCompanyMaster", new Dictionary<string, object>
                    {

                        {"PId","" }

                    }).ToList();

                    return result;
                }
            }
            catch (Exception ex)
            {
                //Logger.LogError("Admin:Login", ex.Message);
                throw;
            }

        }

    }

    public class CommonData
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
    }
}
