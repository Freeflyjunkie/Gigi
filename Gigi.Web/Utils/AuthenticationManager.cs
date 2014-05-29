using System;
using System.Collections.Generic;
using System.IdentityModel.Services;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Security;

namespace Gigi.Web.Utils
{
    public class AuthenticationManager : ClaimsAuthenticationManager
    {
        public override ClaimsPrincipal Authenticate(string resourceName, ClaimsPrincipal incomingPrincipal)
        {
            if (!incomingPrincipal.Identity.IsAuthenticated)
            {
                return base.Authenticate(resourceName, incomingPrincipal);
            }

            //incomingPrincipal.Identities.First().AddClaim(new Claim("http://customclaim", "customclaim"));

            var principal = CreatePrincipal(incomingPrincipal);
            EstablishSession(principal);

            return principal;           
        }

        private void EstablishSession(ClaimsPrincipal principal)
        {
            var sessionToken = new SessionSecurityToken(principal, TimeSpan.FromHours(8))
            {
                IsPersistent = false, // make persistent
                IsReferenceMode = false // cache on server
            };
            FederatedAuthentication.SessionAuthenticationModule.WriteSessionTokenToCookie(sessionToken);
        }

        private ClaimsPrincipal CreatePrincipal(ClaimsPrincipal principal)
        {            
            return principal;

            //var userName = principal.Identity.Name;
            //if (userName == "dom")
            //{                                            
            //    var p = Principal.Create("Application",
            //        new Claim(ClaimTypes.Name, userName),
            //        new Claim(ClaimTypes.GivenName, "Dominick"));

            //    Roles.GetRolesForUser(userName).ToList().ForEach(role => p.Identities.First().AddClaim(new Claim(ClaimTypes.Role, role)));

            //    return p;
            //}
            //else
            //{
            //    return Principal.Create("Application",
            //        new Claim(ClaimTypes.Name, userName),
            //        new Claim(ClaimTypes.GivenName, userName));
            //}
        }
    }
}