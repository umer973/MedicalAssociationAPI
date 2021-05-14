

namespace RadixBackOfficeAPI.Controllers
{
    using System.Web.Http;
    public class TestController : ApiController
    {
        public IHttpActionResult GET()
        {
            return Ok("api is running");
        }
    }
}
