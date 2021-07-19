//using BusinessLogic.Enquiry;
//using DataModel.Models;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;

//namespace MedicalAssociationAPI.Controllers
//{
//    public class EnquiryController : ApiController
//    {
//        private readonly IEnquiry _IEnquiry;


//        public EnquiryController(IEnquiry _IEnquiry)
//        {
//            this._IEnquiry = _IEnquiry;
//        }

//        [HttpPost]
//        [Route("api/SaveEnquiry")]
//        public IHttpActionResult POST(JObject request)
//        {
//            try
//            {
//                var enquiry = JsonConvert.DeserializeObject<EnquiryModel>(request.ToString());
//                if (enquiry != null)
//                {
//                    var response = _IEnquiry.InsertEnquiry(enquiry);

//                    return Ok(response);
//                }
//            }
//            catch (Exception ex)
//            {
//                throw;
//            }
//            return Ok();
//        }


//        [HttpGet]
//        [Route("api/GetEnquiry")]
//        public IHttpActionResult Get()
//        {
//            try
//            {
//                var response = _IEnquiry.GetEnquiry();
//                return Ok(response);

//            }
//            catch (Exception ex)
//            {
//                throw;
//            }

//        }


//        [HttpPost]
//        [Route("api/SaveDownloads")]
//        public IHttpActionResult PostDownload(JObject request)
//        {
//            try
//            {
//                var download = JsonConvert.DeserializeObject<DownloadModel>(request.ToString());
//                if (download != null)
//                {
//                    var response = _IEnquiry.InsertDownloads(download);

//                    return Ok(response);
//                }
//            }
//            catch (Exception ex)
//            {
//                throw;
//            }
//            return Ok();
//        }


//    }
//}
