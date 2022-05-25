using IdentityModel.Client;
using System;
using System.Net.Http;

namespace Demo.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Hello World!");

                var client = new HttpClient();

                var result = client.GetDiscoveryDocumentAsync("http://localhost:5600/").Result;

                if (result.IsError)
                {
                    Console.WriteLine($"result:{result.Error}");
                    //Console.ReadLine();
                }

                //请求token
                var resultWithToken = client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
                {
                    Address = result.TokenEndpoint,
                    ClientId = "ClientA",
                    ClientSecret = "secret",
                    Scope = "api1"
                }).Result;

                if (resultWithToken.IsError)
                {
                    Console.WriteLine($"resultWithToken:{resultWithToken.Error}");
                }

                Console.WriteLine($"token:{resultWithToken.Json}");

                //调用认证api
                var apiClient = new HttpClient();
                apiClient.SetBearerToken(resultWithToken.AccessToken);

                var response = apiClient.GetAsync("http://localhost:31773/identity").Result;
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"response:{response.StatusCode}");
                }
                else
                {
                    var content = response.Content.ReadAsStringAsync().Result;
                    Console.WriteLine($"content:{content}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ex:{ex.Message}");
            }
            Console.ReadLine();
        }
    }
}
