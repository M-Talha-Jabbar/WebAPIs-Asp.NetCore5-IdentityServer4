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

                    options.Scope.Add("profile"); // So we’re requesting the 'profile' scope, but it could be any scope (or scopes) that the client is authorized to access.
                    // We’ve configured the client to be allowed to retrieve the 'profile' identity scope in Config.Clients.
                    options.GetClaimsFromUserInfoEndpoint = true; // And then getting user claims associated with 'profile' scope from UserInfo Endpoint through access_token and setting it in User.Claims.
                    // The claims associated with 'profile' scope are name, given_name, family_name, website, etc.
                    
                    // Similarly, requesting other scopes.
                    options.Scope.Add("api1"); 
                    options.Scope.Add("offline_access");
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
