using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security.OAuth;
using ServerTaxi.Utilites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace ServerTaxi.Providers
{
    public class CustomOAuthProvider : OAuthAuthorizationServerProvider
    {
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            // Resource owner password credentials does not provide a client ID.
            if (context.ClientId == null)
            {
                context.Validated();
            }

            return Task.FromResult<object>(null);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            using (AuthRepository authRepo = new AuthRepository())
            {
                IdentityUser user = await authRepo.FindUser(context.UserName, context.Password);

                if (user == null)
                {
                    context.SetError("invalid_grant", "The user name or password is incorrect.");
                    return;
                }
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
            identity.AddClaim(new Claim(ClaimTypes.Role, "Administrator"));
            identity.AddClaim(new Claim(ClaimTypes.Role, "Client"));
            identity.AddClaim(new Claim(ClaimTypes.Role, "Driver"));


            context.Validated(identity);
        }
    }
}