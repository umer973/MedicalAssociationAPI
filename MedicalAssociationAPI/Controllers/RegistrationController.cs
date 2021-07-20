using BusinessLogic;
using BusinessLogic.Enquiry;
using DataModel.Models;
using MedicalAssociationAPI.Filters;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Runtime.Caching;
using System.Web.Http;

namespace MedicalAssociationAPI.Controllers
{
    public class RegistrationController : ApiController
    {
        private readonly IEnquiry _IEnquiry;
        private readonly CommonHelper _helper;


        public RegistrationController(IEnquiry _IEnquiry)
        {
            this._IEnquiry = _IEnquiry;
            _helper = new CommonHelper();
        }

        [HttpPost]
        [Route("api/Registration")]
        public IHttpActionResult Post(JObject request)
        {
            try
            {
                var registration = JsonConvert.DeserializeObject<Registration>(request.ToString());
                if (registration != null)
                {
                    var response = _IEnquiry.InsertRegistration(registration);
                    if (response != null)
                    {
                        return Ok(response);
                    }
                    else
                    {
                        return Ok();
                    }

                }
            }
            catch (Exception ex)
            {
                throw;
            }


            return Ok();
        }


        [HttpGet]
        [Route("api/GetCompany")]

        //[WebApiOutputCache(120, 60, false)]
        public IHttpActionResult Get()
        {

            var data = new GlobalData();

            if (CachingData.GetDataFromCache("Company") == null)
            {
                var result = data.GetCompanyDetails();
                CachingData.AddCache("Company", result); 
                return Ok(result);
            }
            else
            {
                return Ok(CachingData.GetDataFromCache("Company"));
            }

        }

    }
}

