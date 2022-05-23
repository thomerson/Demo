using IdentityServer4.Models;
using System.Collections;
using System.Collections.Generic;

namespace Demo.IDS4.API
{
    public static class Config
    {
        public static IEnumerable<ApiResource> Apis => new List<ApiResource> {
            new ApiResource("IDS4.api")
        };

        public static IEnumerable<Client> Clients => new List<Client> {
            new Client(){
                ClientId =  "ClientA",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes = new List<string> { "IDS4.api" },
                ClientSecrets  = { new Secret("secret".Sha256())}
            }
        };
    }
}
