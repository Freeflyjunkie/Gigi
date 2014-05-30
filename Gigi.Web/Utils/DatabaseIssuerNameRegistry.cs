using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Hosting;
using System.Xml.Linq;
using Gigi.Web.Models;

namespace Gigi.Web.Utils
{
    public class DatabaseIssuerNameRegistry : ValidatingIssuerNameRegistry
    {
        public static bool ContainsTenant(string tenantId)
        {
            using (var context = new TenantDbContext())
            {
                return context.Tenants.Any(tenant => tenant.Id == tenantId);
            }
        }

        public static bool ContainsKey(string thumbprint)
        {
            using (var context = new TenantDbContext())
            {
                return context.IssuingAuthorityKeys.Any(key => key.Id == thumbprint);
            }
        }

        public static void RefreshKeys(string metadataLocation)
        {
            IssuingAuthority issuingAuthority = ValidatingIssuerNameRegistry.GetIssuingAuthority(metadataLocation);

            bool newKeys = issuingAuthority.Thumbprints.Any(thumbprint => !ContainsKey(thumbprint));

            if (newKeys)
            {
                using (var context = new TenantDbContext())
                {
                    context.IssuingAuthorityKeys.RemoveRange(context.IssuingAuthorityKeys);
                    foreach (string thumbprint in issuingAuthority.Thumbprints)
                    {
                        context.IssuingAuthorityKeys.Add(new IssuingAuthorityKey { Id = thumbprint });
                    }
                    foreach (string issuer in issuingAuthority.Issuers)
                    {
                        context.Tenants.Add(new Tenant { Id = issuer.TrimEnd('/').Split('/').Last() });
                    }
                    context.SaveChanges();
                }
            }
        }

        protected override bool IsThumbprintValid(string thumbprint, string issuer)
        {
            var issuerId = issuer.TrimEnd('/').Split('/').Last();

            return ContainsTenant(issuerId)
                && ContainsKey(thumbprint);
        }
    }
}
