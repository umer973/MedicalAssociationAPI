using BusinessLogic.Admin;
using DataModel.Models;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace MedicalAssociationAPI.Attributes
{
    public class AppOAuthProvider : OAuthAuthorizationServerProvider
    {

        private readonly IAdmin _IAdmin;
        private readonly string _publicClientId;
        private static DataTable LoginDetails = null;

        User _user = new User();

       

        public AppOAuthProvider(IAdmin IAdmin)
        {
            _IAdmin = IAdmin;
        }
        
        /// <returns>Returns validation of client authentication</returns>  
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            // Resource owner password credentials does not provide a client ID.  
            
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {


            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            var user = new User
            {
                UserName = context.UserName,
                Password = context.Password,

            };

            Admin _admin = new Admin();
            User userData = _admin.AuthenticateUser(user.UserName,user.Password);

            if (userData != null)
            {
                identity.AddClaim(new Claim("Role", userData.UseRole));
                identity.AddClaim(new Claim("Id", Convert.ToString(userData.UserId)));
               

                ClaimsIdentity oAuthIdentity = new ClaimsIdentity(context.Options.AuthenticationType);
                ClaimsIdentity cookiesIdentity = new ClaimsIdentity(context.Options.AuthenticationType);
                AuthenticationProperties properties = CreateProperties(context.UserName, userData);
                AuthenticationTicket ticket = new AuthenticationTicket(oAuthIdentity, properties);
                context.Validated(ticket);
                context.Request.Context.Authentication.SignIn(cookiesIdentity);
            }
            else
            {
                context.SetError("Invalid credentials");
                return;
            }
        }
        public static AuthenticationProperties CreateProperties(string userName, User _user)
        {
            IDictionary<string, string> data = new Dictionary<string, string>();
            data.Add("Username", userName);
            if (_user != null )
            {
                data.Add("UserId", _user.UserId.ToString());
                data.Add("Role", _user.UseRole.ToString());
                data.Add("Password", _user.Password.ToString());
                
            }
            return new AuthenticationProperties(data);
        }
        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                // Adding.  
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            // Return info.  
            return Task.FromResult<object>(LoginDetails);

        }

        /// <summary>  
        /// Validate Client authntication override method  
        /// </summary>  
        /// <param name="context">Contect parameter</param>  



        #region Validate client redirect URI override method  

        /// <summary>  
        /// Validate client redirect URI override method  
        /// </summary>  
        /// <param name="context">Context parmeter</param>  
        /// <returns>Returns validation of client redirect URI</returns>  
        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            // Verification.  
            if (context.ClientId == _publicClientId)
            {
                // Initialization.  
                Uri expectedRootUri = new Uri(context.Request.Uri, "/");

                // Verification.  
                if (expectedRootUri.AbsoluteUri == context.RedirectUri)
                {
                    // Validating.  
                    context.Validated();
                }
            }

            // Return info.  
            return Task.FromResult<object>(null);
        }

        #endregion

        #region Create Authentication properties method.  

        /// <summary>  
        /// Create Authentication properties method.  
        /// </summary>  
        /// <param name="userName">User name parameter</param>  
        /// <returns>Returns authenticated properties.</returns>  
        public static AuthenticationProperties CreateProperties(string userName)
        {
            // Settings.  
            IDictionary<string, string> data = new Dictionary<string, string>
                                               {
                                                   { "userName", userName }
                                               };

            // Return info.  
            return new AuthenticationProperties(data);
        }

        #endregion

    }
}