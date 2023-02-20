using IdentityServer4.Models;
using IdentityServer4.Test;

namespace Demo.identityServer4.api
{
    public static class IdentityServerConfig
    {
        public static IEnumerable<ApiResource> ApiResources => new List<ApiResource> {
            new ApiResource("customer.api"),
            new ApiResource("product.api")

        };

        public static IEnumerable<ApiScope> Scopes => new List<ApiScope> {
            new ApiScope("customer.api"){ },
            new ApiScope("product.api")
        };


        public static IEnumerable<Client> Clients => new List<Client> {
            new Client(){
                ClientId =  "client.ocelot",
                AllowedGrantTypes = GrantTypes.ClientCredentials, // 客户端模式
                AllowedScopes = new List<string> { "customer.api","product.api" },
                ClientSecrets  = { new Secret("secret".Sha256())}
            }
        };


        public static IEnumerable<TestUser> Users => new List<TestUser> {
            new TestUser
            {
                SubjectId="1",
                Username="tom",
                Password="password"
            },
            new TestUser
            {
                SubjectId="2",
                Username="jerry",
                Password="password"
            }
        };
    }
}
