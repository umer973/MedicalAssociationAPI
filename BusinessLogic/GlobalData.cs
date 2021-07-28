using DbHelper.DbContext;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class GlobalData
    {
        private readonly SqlQuery query;
        private readonly SqlConnection con;
        DataSet result = new DataSet();


        public GlobalData()
        {
            query = new SqlQuery();
            con = new SqlConnection(query.Database.Connection.ConnectionString);

        }


        public object GetInitialData()
        {
            Dictionary<string, object> resultData = new Dictionary<string, object>();

            DataSet ds = GetMasterData();

            if (ds.Tables[0].Rows.Count > 0)
            {
                resultData.Add("Company", ds.Tables[0]);
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                resultData.Add("Designation", ds.Tables[1]);
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                resultData.Add("Country", ds.Tables[2]);
            }
            if (ds.Tables[3].Rows.Count > 0)
            {
                resultData.Add("State", ds.Tables[3]);
            }
            if (ds.Tables[4].Rows.Count > 0)
            {
                resultData.Add("District", ds.Tables[4]);
            }
            if (ds.Tables[5].Rows.Count > 0)
            {
                resultData.Add("Division", ds.Tables[5]);
            }



            return resultData;

        }

        private DataSet GetMasterData()
        {

            try
            {
                SqlCommand cmd = new SqlCommand("GetMasterData", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(result);

            }
            catch (Exception ex)
            {
                //Logger.LogError("Admin:Login", ex.Message);
                throw;
            }
            return result;


        }

    }

}
