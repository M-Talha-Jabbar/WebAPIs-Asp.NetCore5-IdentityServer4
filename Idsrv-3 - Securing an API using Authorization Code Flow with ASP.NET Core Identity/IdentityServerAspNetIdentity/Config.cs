// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityModel;
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
                new IdentityResources.Address(),
                new IdentityResource(
                    name: "roles",
                    displayName: "User role(s)",
                    userClaims: new List<string> { "role" }
                ),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope(
                    name: "api1", 
                    displayName: "My API", 
                    userClaims: new List<string> { "role" }
                ), // This scope definition tells the configuration system, that when a 'api1' scope is granted, the 'role' claim should be added to the access token.
                // It is independent of whether particular claim is in a scope or identity resource and then that scope is allowed via configuration and not denied via consent.
                // Also there is no involvement of UserInfo Endpoint here. Just when 'api1' scope will be granted (or accepted via consent from user), the 'role' claim will be added in the access token as a claim type 'role' while 'api1' will be added in the access token as a claim type 'scope'.

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
                    RedirectUris = { "https://localhost:44342/signin-oidc" }, // this will redirect us to a page where log in was prompt

                    // where to redirect to after logout
                    PostLogoutRedirectUris = { "https://localhost:44342/signout-callback-oidc" },

                    AllowOfflineAccess = true, // enabling support for refresh tokens.

                    RequireConsent = true, // enabling consent page for this client
                    
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Address,
                        "roles",
                        "api1"
                    }
                }
            };
    }
}