#pragma checksum "C:\Users\Huzaifa\Desktop\WebAPIs-Asp.NetCore5-IdentityServer4\Idsrv-3 - Securing an API using Authorization Code Flow with ASP.NET Core Identity\MvcClient\Views\Home\Privacy.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8ab2ea5c874960665152a229abac571d9281d655"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Privacy), @"mvc.1.0.view", @"/Views/Home/Privacy.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Huzaifa\Desktop\WebAPIs-Asp.NetCore5-IdentityServer4\Idsrv-3 - Securing an API using Authorization Code Flow with ASP.NET Core Identity\MvcClient\Views\_ViewImports.cshtml"
using MvcClient;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Huzaifa\Desktop\WebAPIs-Asp.NetCore5-IdentityServer4\Idsrv-3 - Securing an API using Authorization Code Flow with ASP.NET Core Identity\MvcClient\Views\_ViewImports.cshtml"
using MvcClient.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Huzaifa\Desktop\WebAPIs-Asp.NetCore5-IdentityServer4\Idsrv-3 - Securing an API using Authorization Code Flow with ASP.NET Core Identity\MvcClient\Views\Home\Privacy.cshtml"
using Microsoft.AspNetCore.Authentication;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8ab2ea5c874960665152a229abac571d9281d655", @"/Views/Home/Privacy.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d8143d1835352feeef7cd3c50c0d2dc4c14dbed3", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Privacy : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Huzaifa\Desktop\WebAPIs-Asp.NetCore5-IdentityServer4\Idsrv-3 - Securing an API using Authorization Code Flow with ASP.NET Core Identity\MvcClient\Views\Home\Privacy.cshtml"
  
    ViewData["Title"] = "Privacy Policy";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h1>");
#nullable restore
#line 4 "C:\Users\Huzaifa\Desktop\WebAPIs-Asp.NetCore5-IdentityServer4\Idsrv-3 - Securing an API using Authorization Code Flow with ASP.NET Core Identity\MvcClient\Views\Home\Privacy.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n\r\n");
            WriteLiteral("\r\n<p>Use this page to detail your site\'s privacy policy.</p>\r\n\r\n<h2>Claims</h2>\r\n\r\n<dl>\r\n");
#nullable restore
#line 13 "C:\Users\Huzaifa\Desktop\WebAPIs-Asp.NetCore5-IdentityServer4\Idsrv-3 - Securing an API using Authorization Code Flow with ASP.NET Core Identity\MvcClient\Views\Home\Privacy.cshtml"
     foreach (var claim in User.Claims)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <dt>");
#nullable restore
#line 15 "C:\Users\Huzaifa\Desktop\WebAPIs-Asp.NetCore5-IdentityServer4\Idsrv-3 - Securing an API using Authorization Code Flow with ASP.NET Core Identity\MvcClient\Views\Home\Privacy.cshtml"
       Write(claim.Type);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dt>\r\n        <dd>");
#nullable restore
#line 16 "C:\Users\Huzaifa\Desktop\WebAPIs-Asp.NetCore5-IdentityServer4\Idsrv-3 - Securing an API using Authorization Code Flow with ASP.NET Core Identity\MvcClient\Views\Home\Privacy.cshtml"
       Write(claim.Value);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n");
#nullable restore
#line 17 "C:\Users\Huzaifa\Desktop\WebAPIs-Asp.NetCore5-IdentityServer4\Idsrv-3 - Securing an API using Authorization Code Flow with ASP.NET Core Identity\MvcClient\Views\Home\Privacy.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</dl>\r\n\r\n<h2>Properties</h2>\r\n\r\n<dl>\r\n");
#nullable restore
#line 23 "C:\Users\Huzaifa\Desktop\WebAPIs-Asp.NetCore5-IdentityServer4\Idsrv-3 - Securing an API using Authorization Code Flow with ASP.NET Core Identity\MvcClient\Views\Home\Privacy.cshtml"
     foreach (var prop in (await Context.AuthenticateAsync()).Properties.Items)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <dt>");
#nullable restore
#line 25 "C:\Users\Huzaifa\Desktop\WebAPIs-Asp.NetCore5-IdentityServer4\Idsrv-3 - Securing an API using Authorization Code Flow with ASP.NET Core Identity\MvcClient\Views\Home\Privacy.cshtml"
       Write(prop.Key);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dt>\r\n        <dd>");
#nullable restore
#line 26 "C:\Users\Huzaifa\Desktop\WebAPIs-Asp.NetCore5-IdentityServer4\Idsrv-3 - Securing an API using Authorization Code Flow with ASP.NET Core Identity\MvcClient\Views\Home\Privacy.cshtml"
       Write(prop.Value);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n");
#nullable restore
#line 27 "C:\Users\Huzaifa\Desktop\WebAPIs-Asp.NetCore5-IdentityServer4\Idsrv-3 - Securing an API using Authorization Code Flow with ASP.NET Core Identity\MvcClient\Views\Home\Privacy.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</dl>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
