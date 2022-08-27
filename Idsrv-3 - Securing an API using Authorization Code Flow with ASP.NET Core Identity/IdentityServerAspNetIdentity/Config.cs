// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServerAspNetIdentity
{
    // Scope is a collection of claims.
    // Scopes are also known as resources.
    public static class Config
    {
        // Identity Resource is a named group of claims that can be requested using the 'scope' parameter.
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(), // it is mandatory and it tells the provider to return sub(subject id) claim (i.e an unique identifier of a user) in the identity token(id_token).
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("api1", "My API"),
                new ApiScope("api2", "MY API2")
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId = "client",
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    // api scopes that client has access to
                    AllowedScopes = { "api1", "api2" }
                },

                new Client
                {
                    ClientId = "mvc",
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    AllowedGrantTypes = GrantTypes.Code,

                    // where to redirect to after login
                    RedirectUris = { "https://localhost:44342/signin-oidc" }, // this will redirect us to a page where log in was prompt.

                    // where to redirect to after logout
                    PostLogoutRedirectUris = { "https://localhost:44342/signout-callback-oidc" },

                    AllowOfflineAccess = true, // Enabling support for refresh tokens.

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "api1"
                    }
                }
            };
    }
}