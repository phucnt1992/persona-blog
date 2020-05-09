using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;

namespace Persona.IdentityServer.Configurations
{
    public class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new List<ApiResource>
        {
            new ApiResource("identity-server", "Identity Server")
        };

        public static IEnumerable<IdentityResource> IdentityResources => new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile(),
        };

        public static IEnumerable<Client> Clients => new List<Client>
        {
            new Client {
                ClientId = "mvc",
                ClientName = "MVC Client",
                AllowedGrantTypes = GrantTypes.Hybrid,
                ClientSecrets =
                {
                    new Secret("secret".Sha256())
                },

                RedirectUris           = { "http://localhost:5000/signin-oidc" },
                PostLogoutRedirectUris = { "http://localhost:5000/signout-callback-oidc" },
                AllowAccessTokensViaBrowser = true,
                AllowedScopes =
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email,
                },
                AllowOfflineAccess = true
            }
        };
    }
}
