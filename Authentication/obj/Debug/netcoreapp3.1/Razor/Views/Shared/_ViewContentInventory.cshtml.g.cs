#pragma checksum "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentInventory.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "315b7223cd13e3cf6ace01f913e17923c16d6173"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__ViewContentInventory), @"mvc.1.0.view", @"/Views/Shared/_ViewContentInventory.cshtml")]
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
#line 1 "D:\Project\WareHouse\Authentication\Views\_ViewImports.cshtml"
using Authentication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Project\WareHouse\Authentication\Views\_ViewImports.cshtml"
using Authentication.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"315b7223cd13e3cf6ace01f913e17923c16d6173", @"/Views/Shared/_ViewContentInventory.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"acdb2e1b339642545d0bc56e1deb0ca293ad13ea", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__ViewContentInventory : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<tbody id=\"view-content\">\r\n");
#nullable restore
#line 8 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentInventory.cshtml"
       int i = ViewBag.FirstRec;
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentInventory.cshtml"
         if (Model.Count == 0)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr class=\"no-data\">\r\n                <td colspan=\"7\">Not Found Data</td>\r\n            </tr>\r\n");
#nullable restore
#line 14 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentInventory.cshtml"
        }
        

#line default
#line hidden
#nullable disable
            WriteLiteral("</tbody>\r\n");
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
