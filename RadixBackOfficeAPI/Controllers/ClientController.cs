


namespace RadixBackOfficeAPI.Controllers
{
    using BusinessLogic.Client;
    using Filters;
    using System.Web.Http;
    public class ClientController : ApiController
    {
        private readonly IClient _IClient;

        public ClientController(IClient iClient)
        {
            _IClient = iClient;
        }

        [HttpGet]
        [Route("api/Client")]

        public IHttpActionResult GET(int productId)
        {


            var result = _IClient.GetClients(productId);

            if (result != null)
            {
                // GlobalCaching.CacheData(productId.ToString(),result, System.DateTimeOffset.UtcNow.AddDays(1));
                _IClient.GetClients(productId);
            }



            return Ok(result);

        }

    }
}
