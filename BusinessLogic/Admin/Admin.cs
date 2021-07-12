



namespace BusinessLogic.Admin
{
    using DataModel.Models;
    using DbHelper.DbContext;
 
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Admin : IAdmin
    {
        public User Login(User user)
        {
            try
            {
                using (var query = new SqlQuery())
                {
                    var result = query.ExecuteNonQuery<User>("GetLogin", new Dictionary<string, object>
                    {
                         //{"UserName",user.UserName },
                        {"Email",user.Email},
                        {"ContactNo",user.ContactNo}

                    }).FirstOrDefault();
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
}

