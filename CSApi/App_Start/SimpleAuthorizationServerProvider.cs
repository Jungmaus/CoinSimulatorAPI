using CSApi.Data.Entities;
using CSApi.Service;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace CSApi.App_Start
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private ServiceProvider Service;

        public SimpleAuthorizationServerProvider()
        {
            this.Service = new ServiceProvider();
        }

        public override async System.Threading.Tasks.Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });


            //User user = Service.User.FirstOrDefault(x => x.Username == context.UserName && x.Password == context.Password);
            //if(user != null)
            //{
            //    var identity = new ClaimsIdentity(context.Options.AuthenticationType);

            //    identity.AddClaim(new Claim("sub", context.UserName));
            //    identity.AddClaim(new Claim("role", "user"));

            //    context.Validated(identity);
            //}
            //else
            //{
            //    context.SetError("invalid_grant", "Wrong username or password.");
            //}

            if (context.UserName == "CoinSimulator" && context.Password == "123!213!321!")
            {
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);

                identity.AddClaim(new Claim("sub", context.UserName));
                identity.AddClaim(new Claim("role", "user"));

                context.Validated(identity);
            }
            else
            {
                context.SetError("invalid_grant", "Wrong username or password.");
            }

        }
    }
}