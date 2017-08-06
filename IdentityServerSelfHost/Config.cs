using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServerSelfHost
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("clinical_research_api", "Clinical Research API")
            };
        }
                
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "clinical-research-mvc-client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials, //becasue this is server to server 

                    ClientSecrets =
                    {
                        new Secret("clinical-research-mvc-client-secret".Sha256())
                    },
                    AllowedScopes = { "clinical_research_api" }
                }
            };
        }
    }
}
