namespace Persona.API.Configurations
{
    using IdentityServer4.Models;
    using System.Collections.Generic;
    public class Config
    {
        public static IEnumerable<ApiResource> GetApiResources() => new List<ApiResource>
        {
            new ApiResource("api", "Perona API")
        };

        public static IEnumerable<IdentityResource> GetIdentityResources() => new List<IdentityResource> { 
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Phone(),
            new IdentityResources.Profile()
        };

        public static IEnumerable<Client> GetClients(Dictionary<string, string> clientUrls) => new List<Client> { 
            new Client()
            {
                ClientId = "admin",
                ClientName = "Admin Client",
                AllowedGrantTypes = GrantTypes.Code,
                AllowAccessTokensViaBrowser = true,
                IncludeJwtId = true,
                AllowedCorsOrigins = true,
                req
                
            }
        }
    }
}
