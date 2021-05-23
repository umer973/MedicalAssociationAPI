﻿

namespace BusinessLogic.Client
{
    using DataModel.Models;
    using DbHelper.DbContext;
    using Helper;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Client : IClient
    {
        public List<ClientModel> GetClients(int productId)
        {
            try
            {
                using (var query = new SqlQuery())
                {
                    var result = query.ExecuteNonQuery<ClientModel>("sp_GetClients", new Dictionary<string, object>
                    {
                        {"ProductId",productId }
                       
                       //  {"ProuctId",user.ProductId}
                    }).ToList();
                    return result;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Client:GetClients", ex.Message);
                throw;
            }

        }
    }
}