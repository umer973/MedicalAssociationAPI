using DataModel.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using BusinessLogic.Partner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RadixBackOfficeAPI.Controllers
{
    using Filters;

    public class PartnerController : ApiController
    {
        private readonly IPartner _IPartner;

        public PartnerController(IPartner IPartner)
        {
            _IPartner = IPartner;
        }

        [HttpGet]
        [Route("api/GetPartners")]
        public IHttpActionResult GET()
        {


            var result = _IPartner.GetPartners();

            return Ok(result);

        }

        [HttpPost]
        [Route("api/SavePartners")]
        public IHttpActionResult PostPartners(JObject request)
        {
            try
            {
                var partners = JsonConvert.DeserializeObject<PartnerModel>(request.ToString());
                if (partners != null)
                {
                    var response = _IPartner.InsertPartners(partners);

                    return Ok(response);
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
