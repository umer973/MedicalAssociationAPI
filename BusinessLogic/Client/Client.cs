

namespace BusinessLogic.Client
{
    using DataModel.Models;
    using DbHelper.DbContext;
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
   

    public class Client : IClient
    {
        public List<Register> GetClients()
        {
            try
            {
                using (var query = new SqlQuery())
                {
                    var result = query.ExecuteNonQuery<Register>("sp_GetClients", new Dictionary<string, object>
                    {
                        {"ProductId",1}
                       
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
        public int InsertClients(Register client)
        {
            try
            {
                using (var query = new SqlQuery())
                {
                    var result = query.ExecuteNonQuery("InsertUpdateClients", new Dictionary<string, object>
                    {

                        {"ClientId" ,client.ClientId },
                        {"ClientName",client.ClientName },
                        {"Logo",client.Logo },
                        {"ContactNo",client.ContactNo },
                        {"IsActive",client.IsActive }


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

                        {"TestimonialId" ,testimonial.TestimonialId },
                        {"Description",testimonial.Description },
                        {"Logo",testimonial.Logo },
                        {"ClientName",testimonial.ClientName },
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
