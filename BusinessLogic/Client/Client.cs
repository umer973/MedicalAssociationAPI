

namespace BusinessLogic.Client
{
    using DataModel.Models;
    using DbHelper.DbContext;
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
   

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
                //Logger.LogError("Client:GetClients", ex.Message);
                throw;
            }

        }


        public List<TestimonialsModel> GetTestimonials()
        {
            try
            {
                using (var query = new SqlQuery())
                {
                    var result = query.ExecuteNonQuery<TestimonialsModel>("GetTestimonials", new Dictionary<string, object>
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

        public int InsertTestimonial (TestimonialsModel testimonial)
        {
            try
            {
                using (var query = new SqlQuery())
                {
                    var result = query.ExecuteNonQuery("InsertUpdateTestimonials", new Dictionary<string, object>
                    {
                        {"ClientName",testimonial.ClientName},
                        {"Logo",testimonial.Logo},
                        {"Description",testimonial.Description },
                        {"IsActive",testimonial.IsActive }

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
