
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
                    var result = query.ExecuteNonQuery<User>("sp_Login", new Dictionary<string, object>
                    {
                         //{"UserName",user.UserName },
                        {"UserName",user.UserName},
                        {"Password",user.Password},
                        {"UseRole",user.UseRole},

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


        public User AuthenticateUser(string userName, string password)
        {
            try
            {
                using (var query = new SqlQuery())
                {
                    var result = query.ExecuteNonQuery<User>("sp_Login", new Dictionary<string, object>
                    {
                         //{"UserName",user.UserName },
                        {"UserName",userName},
                        {"Password",password},
                        {"UseRole",""},

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

