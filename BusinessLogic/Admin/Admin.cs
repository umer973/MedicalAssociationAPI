



namespace BusinessLogic.Admin
{
    using DataModel.Models;
    using DbHelper.DbContext;
    using Helper;
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
                    var result = query.ExecuteNonQuery<User>("sp_GetLogin", new Dictionary<string, object>
                    {
                        {"UserName",user.UserName },
                        {"Password",user.Password},
                        {"UserType",user.UserType}
                    }).FirstOrDefault();
                    return result;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Admin:Login", ex.Message);
                throw;
            }

        }
    }
}

