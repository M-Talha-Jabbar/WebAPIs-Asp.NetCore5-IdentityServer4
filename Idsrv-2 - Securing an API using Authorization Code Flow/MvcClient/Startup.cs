using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace MvcClient
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            JwtSecurityTokenHandler.DefaultMapInboundClaims = false;

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";

                options.DefaultChallengeScheme = "oidc";
                // When an authentication scheme is challenged, the scheme should prompt the user to authenticate themselves.
                // This could for example mean that the user gets redirected to a login form, or that there will be a redirect to an external authentication provider.
            })
                .AddCookie("Cookies")
                // For the user, the normal interaction is through the cookie authentication scheme. When they access the web application, the cookie authentication scheme will attempt to authenticate them using their cookie. 
                // So using the cookie authentication scheme as the default scheme for all operations.

                .AddOpenIdConnect("oidc", options =>
                {
                    options.Authority = "https://localhost:5001";

                    options.ClientId = "mvc";
                    options.ClientSecret = "secret";
                    options.ResponseType = "code";

                    options.SaveTokens = true; // It is used to persist the tokens(i.e. id_token, access_token & refresh_token) from IdentityServer in the cookie or we can say in the authentication session.
                    // The id_token helps us with the authentication process.
                    // While the access_token helps us with the authorization process because it authorizes a web client application to communicate with the web api.

                    // Requesting access to Identity Resources
                    options.Scope.Add("profile"); // So we’re requesting the 'profile' scope, but it could be any scope (or scopes) that the client is authorized to access OR We can say that,
                                                  // When a client asks for a scope (and that scope is allowed via configuration and not denied via consent), the value of that scope will be included in the resulting access token as a claim type 'scope'.
                    options.Scope.Add("address");

                    // Requesting acesss to API Resources
                    options.Scope.Add("api1");

                    // Requesting refresh token so that it can be used by client to access user resources even when he is offline.
                    options.Scope.Add("offline_access");

                    // Remember, scopes are purely for authorizing clients to have access to user data on behalf of them.

                    options.GetClaimsFromUserInfoEndpoint = true;
                    // Since client have requested both 'profile' and 'address' identity resources, and it is allowed to the client (to request) via configuration and if not denied via consent, they will be added in the access token as a claim type 'scope'.
                    // Remember, through UserInfo Endpoint only client can get the user Identity Resources (only that identity resources which are in the access token).

                    // So here client will be getting user's Identity Resources which are in the access token from UserInfo Endpoint.
                    // Basically client get user/identity claims which are associated with those Identity Resources which are in the access token. In our case the access token contain access to 'profile' and 'address' Identity Resources. 
                    // Then after getting those claims, they will be set in User.Claims.

                    // The claims associated with 'profile' identity resource or scope are name, given_name, family_name, website, etc.
                    // The claim associated with 'address' identity resource or scope is address.

                    // Note: Identity Resource is a named group of claims that can be requested using the 'scope' parameter.

                    // Now if we inspect the Privacy page, we won’t be able to find the address claim there. That’s because we didn’t map it to our claims (User.Claims).
                    // See client will get all claims which are associated with identity resources which are in the access token from UserInfo Endpoint but by default only 'profile' identity resource or scope claims are mapped in our claims (User.Claims).
                    // See Identity Server logs and you will see that all claims were returned by Identity Server but only claims associated with 'profile' identity resource or scope were mapped in our claims (User.Claims).
                    // And even from 'profile' identity resource or scope claims you will see that only name, given_name and family_name are mapped. Others remain unmapped.
                    // So if we want to map other claims associated with identity resources or scopes which were returned to us by Identity Server, we can do this like:
                    options.ClaimActions.MapUniqueJsonKey("website", "website"); // website claim was associated with 'profile' scope
                    options.ClaimActions.MapUniqueJsonKey("address", "address"); // address claim was associated with 'address' scope
                });
                // When we need the user to login, we challenge the authentication. In that case, we want the user to be redirected to the OIDC provider, so they can log in there and return with an identity.
                // So we set the default challenge scheme to the OIDC scheme.
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
