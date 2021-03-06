using BusinessLogic;
using MedicalAssociationAPI.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace MedicalAssociationAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
       

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            LoadInitailAppData();        
         
        }

        private void LoadInitailAppData()
        {
            GlobalData global = new GlobalData();


            if (CachingData.GetDataFromCache("MasterDataCache") == null)
            {
                var result = global.GetInitialData();
                CachingData.AddCache("MasterDataCache", result);
                
            }
           
        }
    }
}
;