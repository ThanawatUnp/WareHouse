#pragma checksum "D:\Project\WareHouse\Authentication\Views\Shared\_ViewHeaderLocationCategory.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2da08300a02ff5df4662e3eff2aaf0eb5360025e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__ViewHeaderLocationCategory), @"mvc.1.0.view", @"/Views/Shared/_ViewHeaderLocationCategory.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2da08300a02ff5df4662e3eff2aaf0eb5360025e", @"/Views/Shared/_ViewHeaderLocationCategory.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"acdb2e1b339642545d0bc56e1deb0ca293ad13ea", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__ViewHeaderLocationCategory : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewHeaderLocationCategory.cshtml"
 foreach (var item in ViewBag.Header)
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewHeaderLocationCategory.cshtml"
     switch (@item)
    {
        case "Create By":
        case "Create Date":
        case "Edit By":
        case "Edit Date":

#line default
#line hidden
#nullable disable
            WriteLiteral("            <th style=\"min-width: 130px;\">");
#nullable restore
#line 9 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewHeaderLocationCategory.cshtml"
                                     Write(item);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n");
#nullable restore
#line 10 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewHeaderLocationCategory.cshtml"
            break;
        case "Description":

#line default
#line hidden
#nullable disable
            WriteLiteral("            <th style=\"min-width: 150px;\">");
#nullable restore
#line 12 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewHeaderLocationCategory.cshtml"
                                     Write(item);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n");
#nullable restore
#line 13 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewHeaderLocationCategory.cshtml"
            break;
        case "Category Name":

#line default
#line hidden
#nullable disable
            WriteLiteral("            <th style=\"min-width: 160px;\">");
#nullable restore
#line 15 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewHeaderLocationCategory.cshtml"
                                     Write(item);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n");
#nullable restore
#line 16 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewHeaderLocationCategory.cshtml"
            break;
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewHeaderLocationCategory.cshtml"
     
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