using Duende.IdentityServer.Models;

namespace eShop.IdentityServer.Configuration
{
    public static class IdentityConfiguration
    {
        public const string Admin = "Admin";
        public const string Client = "Client";

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
            new ApiScope("eShop", "e-Shop Server"),
            new ApiScope(name: "read", "Read Data"),
            new ApiScope(name: "write", "Write Data"),
            new ApiScope(name: "delete", "Delete Data"),
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {

            new Client
            {
                ClientId = "client",
                ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },

                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes = { "read", "write", "profile" }
            },

            new Client
            {
                ClientId = "eShop",
                ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },

                AllowedGrantTypes = GrantTypes.Code,

                RedirectUris = { "https://localhost:4430/signin-oidc" },
                PostLogoutRedirectUris = { "https://localhost:4430/signout-callback-oidc" },

                AllowOfflineAccess = true,
                AllowedScopes = { "openid", "profile", "email", "eShop" }
            },
            };

    }
}
