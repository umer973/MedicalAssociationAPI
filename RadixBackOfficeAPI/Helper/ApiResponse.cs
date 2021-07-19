

namespace MedicalAssociationAPI.Helper
{

    using System.Net;
    using System.Net.Http;
    using System.Text;

    public class ApiResponse
    {

        public int StatusCode { get; set; }


        // public string ErrorMessage { get; set; }


        // public int ValidationMessageType { get; set; }


        public object Result { get; set; }

        public string Message { get; set; }

        public string Version
        {
            get
            {
                StringBuilder VersionData = new StringBuilder();
                VersionData.Append(System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Major.ToString());
                VersionData.Append(".");
                VersionData.Append(System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Minor.ToString());
                return VersionData.ToString();

            }
        }

        //  Api Response///

        public ApiResponse(HttpStatusCode statusCode, object result,
            HttpRequestMessage requestMessage, HttpResponseMessage response) //  string errorMessage = null,
        {
            StatusCode = (int)statusCode;


            switch (statusCode)
            {
                case HttpStatusCode.OK: // 200
                    Result = result;
                    if (requestMessage.Method.ToString().Equals("POST"))
                    {
                        // this.Message = MessageLib.Save;
                    }
                    else if (requestMessage.Method.ToString().Equals("PUT"))
                    {
                        // this.Message = MessageLib.Update;
                    }
                    else if (requestMessage.Method.ToString().Equals("DELETE"))
                    {
                        // this.Message = MessageLib.Delete;
                    }
                    Message = "Success";
                    break;
                case HttpStatusCode.Accepted: //202
                    Result = "";
                    this.Message = result.ToString();
                    break;
                case HttpStatusCode.Unauthorized: //401
                    //ValidationMessageType = 2;
                    response.StatusCode = HttpStatusCode.Accepted;
                    StatusCode = (int)HttpStatusCode.Accepted;
                    Result = "";
                    this.Message = "Authorization has been denied for this request.(Token session validity is expired)"; //result.ToString();
                    break;
                //
                case HttpStatusCode.NotFound:
                    response.StatusCode = HttpStatusCode.Accepted;
                    StatusCode = (int)HttpStatusCode.Accepted;
                    Result = "";
                    Message = "Internal Server Error";
                    break;
                case HttpStatusCode.InternalServerError:
                    response.StatusCode = HttpStatusCode.InternalServerError;
                    StatusCode = (int)HttpStatusCode.InternalServerError;
                    Result = "";
                    Message = "Internal Server Error";
                    Result = result;
                    break;
                default:
                    break;
            }
        }

    }
}
