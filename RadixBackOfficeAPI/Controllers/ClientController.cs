using DataModel.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;


namespace MedicalAssociationAPI.Controllers
{
    using BusinessLogic;
    using BusinessLogic.Client;
    using Filters;
    using System.Web.Http;
    public class ClientController : ApiController
    {
        private readonly IClient _IClient;

        private readonly CommonHelper _helper;

        public ClientController(IClient iClient)
        {
            _IClient = iClient;
            _helper = new CommonHelper();
        }

        [HttpGet]
        [Route("api/Client")]

        public IHttpActionResult GET()
        {

            var result = _IClient.GetClients();

            return Ok(result);

        }

        [HttpGet]
        [Route("api/DeleteClient")]
        public IHttpActionResult DELClient(int clientId)
        {

            var response = _helper.DeleteData("Clients", "ClientId", clientId.ToString());
            return Ok(response);

        }

        [HttpPost]
        [Route("api/SaveClients")]
        public IHttpActionResult PostClients(JObject request)
        {
            try
            {
                var clients = JsonConvert.DeserializeObject<Register>(request.ToString());
                if (clients != null)
                {
                    var response = _IClient.InsertClients(clients);

                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return Ok();
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


        [HttpGet]
        [Route("api/DeleteTestimonial")]
        public IHttpActionResult DELTestimonial(int testimonialId)
        {

            var response = _helper.DeleteData("Testimonials", "TestimonialId", testimonialId.ToString());
            return Ok(response);

        }



    }
}
