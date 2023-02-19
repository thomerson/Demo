using IdentityServer4.Models;
using IdentityServer4.Test;
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
                AllowedGrantTypes = GrantTypes.ClientCredentials, // 客户端模式
                AllowedScopes = new List<string> { "api1" },
                ClientSecrets  = { new Secret("secret".Sha256())}
            },
            new Client(){
                ClientId = "ClientB",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,  // 资源所有者模式
                AllowedScopes = new List<string> { "api1" },
                ClientSecrets  = { new Secret("secret".Sha256())}
            }
        };


        public static IEnumerable<TestUser> Users => new List<TestUser> {
            new TestUser
            {
                SubjectId="1",
                Username="爱丽丝",
                Password="password"
            },
            new TestUser
            {
                SubjectId="2",
                Username="博德",
                Password="password"
            }
        };
    }
}
