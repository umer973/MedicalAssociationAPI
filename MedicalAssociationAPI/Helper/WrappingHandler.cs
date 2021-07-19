


namespace MedicalAssociationAPI.Helper
{
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public class WrappingHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);
            return BuildApiResponse(request, response, true);

        }

        private static HttpResponseMessage BuildApiResponse(HttpRequestMessage request, HttpResponseMessage response, bool isLicenseValid)
        {
            object content="";
            ///string errorMessage = null;
            //HttpError error = null;
               
            bool IsAPIException = false;

            if (isLicenseValid == false)
            {
               // ValidationMessageType = (int)KI.RIS.Enumerators.Common.ValidationMessageType.Blocking; // enum ValidationMessageType    
                                                                                                       //  response = new HttpResponseMessage(HttpStatusCode.Accepted);
                response.StatusCode = HttpStatusCode.Accepted;
               // content = GlobalCaching.LicenseExpiredMessage;
                IsAPIException = true;
              //  response.Headers.Add("ValidationMessageType", ((byte)KI.RIS.Enumerators.Common.ValidationMessageType.Blocking).ToString());
            }
            else
            {
              

                IEnumerable<string> values = null;


                if (response.TryGetContentValue(out content)) //  && !response.IsSuccessStatusCode
                {
                    ///it will if the Controller handle the exact HttpStatusCodes eg: Resource -  public IHttpActionResult Delete(Int64 resourceMasterId, int categoryType) 
                    if (content is APIException)
                    {
                        APIException objException = (APIException)content;
                        IsAPIException = true;
                       
                        content = objException.Message;
                    }
                }

                if (response.StatusCode == HttpStatusCode.InternalServerError)
                {
                    //content = MessageLib.Error; // "Please contact technical support team..............."; /// This message hardcode in client side
                                                //content = MessageLib.Error;
                }
                else if (!IsAPIException && response.StatusCode == HttpStatusCode.Accepted)
                {
                    content = response.ReasonPhrase;
                    HttpHeaders headers = response.Headers;
               
                  //  ValidationMessageType = Convert.ToInt16(((string[])values)[0]);
                }
            }
            var newResponse = request.CreateResponse(response.StatusCode
                , new ApiResponse(response.StatusCode, content, response.RequestMessage, response));

            foreach (var header in response.Headers)
            {
                newResponse.Headers.Add(header.Key, header.Value);
            }

            return newResponse;
        }
    }


    
}