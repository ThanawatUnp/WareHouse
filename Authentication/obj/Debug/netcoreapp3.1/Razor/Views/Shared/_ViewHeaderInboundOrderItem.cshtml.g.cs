#pragma checksum "D:\Project\WareHouse\Authentication\Views\Shared\_ViewHeaderInboundOrderItem.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c146d1e4d6e12f49f28ba99ff469bf4cb244f7a3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__ViewHeaderInboundOrderItem), @"mvc.1.0.view", @"/Views/Shared/_ViewHeaderInboundOrderItem.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c146d1e4d6e12f49f28ba99ff469bf4cb244f7a3", @"/Views/Shared/_ViewHeaderInboundOrderItem.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"acdb2e1b339642545d0bc56e1deb0ca293ad13ea", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__ViewHeaderInboundOrderItem : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewHeaderInboundOrderItem.cshtml"
 foreach (var item in ViewBag.HeaderSubMenu)
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewHeaderInboundOrderItem.cshtml"
     switch (@item)
    {
        case "Cost":

#line default
#line hidden
#nullable disable
            WriteLiteral("            <th style=\"min-width: 110px;\">");
#nullable restore
#line 6 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewHeaderInboundOrderItem.cshtml"
                                     Write(item);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n");
#nullable restore
#line 7 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewHeaderInboundOrderItem.cshtml"
            break;
        case "Item Status":
        case "Create By":
        case "Create Date":
        case "Edit By":
        case "Edit Date":

#line default
#line hidden
#nullable disable
            WriteLiteral("            <th style=\"min-width: 130px;\">");
#nullable restore
#line 13 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewHeaderInboundOrderItem.cshtml"
                                     Write(item);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n");
#nullable restore
#line 14 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewHeaderInboundOrderItem.cshtml"
            break;
        case "Quantity Order":
        case "Remain Quantity":

#line default
#line hidden
#nullable disable
            WriteLiteral("            <th style=\"min-width: 150px;\">");
#nullable restore
#line 17 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewHeaderInboundOrderItem.cshtml"
                                     Write(item);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n");
#nullable restore
#line 18 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewHeaderInboundOrderItem.cshtml"
            break;
        case "Line Number":
        case "Item Type":

#line default
#line hidden
#nullable disable
            WriteLiteral("            <th style=\"min-width: 160px;\">");
#nullable restore
#line 21 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewHeaderInboundOrderItem.cshtml"
                                     Write(item);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n");
#nullable restore
#line 22 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewHeaderInboundOrderItem.cshtml"
            break;
        case "Item Name":

#line default
#line hidden
#nullable disable
            WriteLiteral("            <th style=\"min-width: 180px;\">");
#nullable restore
#line 24 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewHeaderInboundOrderItem.cshtml"
                                     Write(item);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n");
#nullable restore
#line 25 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewHeaderInboundOrderItem.cshtml"
            break;
        default:

#line default
#line hidden
#nullable disable
            WriteLiteral("            <th>");
#nullable restore
#line 27 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewHeaderInboundOrderItem.cshtml"
           Write(item);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n");
#nullable restore
#line 28 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewHeaderInboundOrderItem.cshtml"
            break;
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 29 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewHeaderInboundOrderItem.cshtml"
     
}

#line default
#line hidden
#nullable disable
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
