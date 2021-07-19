

namespace MedicalAssociationAPI.Controllers
{
    using System.Web.Http;
    public class TestController : ApiController
    {
        [Authorize]
        public IHttpActionResult GET()
        {
            return Ok("api is running");
        }
    }
}
