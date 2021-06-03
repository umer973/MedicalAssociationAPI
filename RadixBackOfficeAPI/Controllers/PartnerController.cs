using BusinessLogic.Partner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RadixBackOfficeAPI.Controllers
{
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


    }
}
