using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using MedicalAssociationAPI.Attributes;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using MedicalAssociationAPI;
using BusinessLogic.Admin;

[assembly: OwinStartup(typeof(RadixBackOfficeAPI.App_Start.Startup))]

namespace RadixBackOfficeAPI.App_Start
{
    public class Startup
    {
        private readonly IAdmin _IAdmin;

        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            //app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

           

            var myProvider = new AppOAuthProvider(_IAdmin);

            OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/api/Login"),
                Provider = myProvider,
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                AllowInsecureHttp = true
            };
            app.UseOAuthAuthorizationServer(options);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);

        }
    }
}
