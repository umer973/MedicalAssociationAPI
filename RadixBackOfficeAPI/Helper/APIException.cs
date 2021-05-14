using RadixBackOfficeAPI.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RadixBackOfficeAPI.Helper
{
    public class APIException : Exception
    {
        public APIException()
        {
            //MessageType = ValidationMessageType.Info;
        }
        public ExceptionType MessageType { get; set; }

        public APIException(string message) : base(MessageLib.GetMessage(message)) { MessageType = ExceptionType.Info; }
        public APIException(ExceptionType messageType, string message) : base(MessageLib.GetMessage(message))
        {
            MessageType = messageType;
        }
    }

    public static class MessageLib
    {
        public static string Save { get; set; } //= "CmnMsgSave";// Saved Successfully";
        public static string Update { get; set; }//= "CmnMsgUpdate";//"Updated Successfully";
        public static string Delete { get; set; } //= "CmnMsgDelete";// "Deleted Successfully";
        public static string Error { get; set; }


        static MessageLib()
        {


            Save = "Success";
            Update = "Updated";
            Delete = "Deleted";
            Error = "Error";
        }

        public static string GetMessage(string message)
        {

            return message;
        }
    }


}