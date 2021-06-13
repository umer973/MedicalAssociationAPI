using DataModel.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;


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
                //GlobalCaching.CacheData(productId.ToString(),result, System.DateTimeOffset.UtcNow.AddDays(1));
                _IClient.GetClients(productId);
            }



            return Ok(result);

        }


        [HttpPost]
        [Route("api/SaveTestimonials")]
        public IHttpActionResult PostTestimonials(JObject request)
        {
            try
            {
                var testimonials = JsonConvert.DeserializeObject<TestimonialsModel>(request.ToString());
                if (testimonials != null)
                {
                    var response = _IClient.InsertTestimonial(testimonials);

                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return Ok();
        }

        [HttpGet]
        [Route("api/GetTestimonials")]
        public IHttpActionResult Get()
        {
            try
            {
                var response = _IClient.GetTestimonials();
                return Ok(response);

            }
            catch (Exception ex)
            {
                throw;
            }

        }

    }
}
