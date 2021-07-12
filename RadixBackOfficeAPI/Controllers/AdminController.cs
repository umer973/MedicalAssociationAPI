



namespace RadixBackOfficeAPI.Controllers
{
    using BusinessLogic.Admin;
    using DataModel.Models;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Web.Http;

    public class AdminController : ApiController
    {
        private readonly IAdmin _IAdmin;

        public AdminController(IAdmin IAdmin)
        {
            _IAdmin = IAdmin;
        }

        [HttpPost]
        [Route("api/postLogin")]
        public IHttpActionResult Post(JObject request)
        {
            try
            {
                var user = JsonConvert.DeserializeObject<User>(request.ToString());
                if (user != null)
                {
                    //var response = _IAdmin.Login(user);
                    //if (response != null)
                    //{
                    //    return Ok(response);
                    //}
                    //else
                    //{
                    //    return Ok();
                    //}
                    return Ok();

                }
            }
            catch (Exception ex)
            {
                throw;
            }


            return Ok();
        }

    }
}
