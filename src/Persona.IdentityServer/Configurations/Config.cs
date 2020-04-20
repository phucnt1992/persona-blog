using System.Collections.Generic;
using IdentityServer4.Models;

namespace Persona.IdentityServer.Configurations
{
    public class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new List<ApiResource>
        {
        };

        public static IEnumerable<IdentityResource> IdentityResources => new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
        };

        public static IEnumerable<Client> Clients => new List<Client>
        {
        };
    }
}
