using DbHelper.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class CommonHelper
    {
        public int? DeleteData(string tableNmae, string columname, string PkId)
        {
            try
            {
                using (var query = new SqlQuery())
                {
                    var result = query.ExecuteNonQuery("DeleteData", new Dictionary<string, object>
                    {
                        {"TableName",tableNmae },
                          {"ColumnName",columname },
                            {"PkId",PkId }

                    });

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
