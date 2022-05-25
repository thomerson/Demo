using IdentityServer4.Models;
using System.Collections;
using System.Collections.Generic;

namespace Demo.IDS4.API
{
    public static class IdentityServerConfig
    {
        public static IEnumerable<ApiScope> Scopes => new List<ApiScope> {
            new ApiScope("api1"){ },
            //new ApiScope("shop.admin")
        };


        public static IEnumerable<Client> Clients => new List<Client> {
            new Client(){
                ClientId =  "ClientA",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes = new List<string> { "api1" },
                ClientSecrets  = { new Secret("secret".Sha256())}
            }
        };
    }
}
