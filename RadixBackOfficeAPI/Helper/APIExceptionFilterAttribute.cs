

using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace RadixBackOfficeAPI.Helper
{
    public class APIExceptionFilterAttribute: ExceptionFilterAttribute, IExceptionFilter
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {

            if (actionExecutedContext.Exception is APIException)
            {
                APIException exceptionData = (APIException)actionExecutedContext.Exception;

                //The Response Message Set by the Action During Ececution
                var res = exceptionData.Message;

                //Define the Response Message

                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    Content = new StringContent(exceptionData.ToString()),
                    StatusCode = HttpStatusCode.Accepted,
                    ReasonPhrase = res
                };

               // response.Headers.Add("ValidationMessageType", ((byte)exceptionData.MessageType).ToString());

                //Create the Error Response

                actionExecutedContext.Response = response;

                string exception = actionExecutedContext.Exception.ToString();
               // ErrorLogDL.InsertErrorLog(exception, actionExecutedContext.Exception.Message.ToString());
            }
            else
            {

                ///exception loging

                string exception = actionExecutedContext.Exception.ToString();
               // ErrorLogDL.InsertErrorLog(exception, actionExecutedContext.Exception.Message.ToString());

                var res = actionExecutedContext.Exception.Message;
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(res),
                    StatusCode = HttpStatusCode.InternalServerError,
                    ReasonPhrase = res
                };

                //Create the Error Response
                actionExecutedContext.Response = response;


            }
        }
    }
}