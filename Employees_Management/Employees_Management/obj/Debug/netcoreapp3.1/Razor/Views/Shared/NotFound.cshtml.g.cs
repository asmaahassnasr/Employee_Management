#pragma checksum "E:\Employee_Management\Employees_Management\Employees_Management\Views\Shared\NotFound.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c9d6c9efa4ae915c93ee0c6dde915aaaeaead5de"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_NotFound), @"mvc.1.0.view", @"/Views/Shared/NotFound.cshtml")]
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
#line 1 "E:\Employee_Management\Employees_Management\Employees_Management\Views\_ViewImports.cshtml"
using Employees_Management.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Employee_Management\Employees_Management\Employees_Management\Views\_ViewImports.cshtml"
using Employees_Management.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c9d6c9efa4ae915c93ee0c6dde915aaaeaead5de", @"/Views/Shared/NotFound.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3c18d1d497ca8eea1932814a0a2f2de74d5d5003", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_NotFound : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "E:\Employee_Management\Employees_Management\Employees_Management\Views\Shared\NotFound.cshtml"
  
    ViewBag.Title = "Not Found";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<hr />\r\n<hr />\r\n<hr />\r\n<h1>  ");
#nullable restore
#line 8 "E:\Employee_Management\Employees_Management\Employees_Management\Views\Shared\NotFound.cshtml"
 Write(ViewBag.ErrorMessage);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n\r\n<hr /><hr /><hr />\r\n<p>");
#nullable restore
#line 11 "E:\Employee_Management\Employees_Management\Employees_Management\Views\Shared\NotFound.cshtml"
Write(ViewBag.Path);

#line default
#line hidden
#nullable disable
            WriteLiteral(" // ");
#nullable restore
#line 11 "E:\Employee_Management\Employees_Management\Employees_Management\Views\Shared\NotFound.cshtml"
               Write(ViewBag.QS);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>");
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
