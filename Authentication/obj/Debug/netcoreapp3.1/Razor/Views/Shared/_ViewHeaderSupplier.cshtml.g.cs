#pragma checksum "D:\SourceCode\CSJ Rubber\Authentication\Views\Shared\_ViewHeaderSupplier.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "74f2272478536f86ecfb212cd9174c687829fb54295a3d08f102e8082ac3d726"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__ViewHeaderSupplier), @"mvc.1.0.view", @"/Views/Shared/_ViewHeaderSupplier.cshtml")]
namespace AspNetCore
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\SourceCode\CSJ Rubber\Authentication\Views\_ViewImports.cshtml"
using Authentication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\SourceCode\CSJ Rubber\Authentication\Views\_ViewImports.cshtml"
using Authentication.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"74f2272478536f86ecfb212cd9174c687829fb54295a3d08f102e8082ac3d726", @"/Views/Shared/_ViewHeaderSupplier.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"71bcce66d95c93940ae98c991a01a581406cd371ceec664c269b80da2797d35d", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared__ViewHeaderSupplier : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\SourceCode\CSJ Rubber\Authentication\Views\Shared\_ViewHeaderSupplier.cshtml"
 foreach (var item in ViewBag.Header)
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\SourceCode\CSJ Rubber\Authentication\Views\Shared\_ViewHeaderSupplier.cshtml"
     switch (@item)
    {
        case "Zipcode":
        case "Active":

#line default
#line hidden
#nullable disable
            WriteLiteral("            <th style=\"min-width: 90px;\">");
#nullable restore
#line 7 "D:\SourceCode\CSJ Rubber\Authentication\Views\Shared\_ViewHeaderSupplier.cshtml"
                                    Write(item);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n");
#nullable restore
#line 8 "D:\SourceCode\CSJ Rubber\Authentication\Views\Shared\_ViewHeaderSupplier.cshtml"
            break;
        case "Create By":
        case "Create Date":
        case "Edit By":
        case "Edit Date":
        case "Contact":

#line default
#line hidden
#nullable disable
            WriteLiteral("            <th style=\"min-width: 130px;\">");
#nullable restore
#line 14 "D:\SourceCode\CSJ Rubber\Authentication\Views\Shared\_ViewHeaderSupplier.cshtml"
                                     Write(item);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n");
#nullable restore
#line 15 "D:\SourceCode\CSJ Rubber\Authentication\Views\Shared\_ViewHeaderSupplier.cshtml"
            break;
        case "Province":
        case "District":
        case "Sub-District":
        case "Phone":
        case "Mobile":
        case "Fax":

#line default
#line hidden
#nullable disable
            WriteLiteral("            <th style=\"min-width: 140px;\">");
#nullable restore
#line 22 "D:\SourceCode\CSJ Rubber\Authentication\Views\Shared\_ViewHeaderSupplier.cshtml"
                                     Write(item);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n");
#nullable restore
#line 23 "D:\SourceCode\CSJ Rubber\Authentication\Views\Shared\_ViewHeaderSupplier.cshtml"
            break;
        case "Supplier Code":
        case "Description":

#line default
#line hidden
#nullable disable
            WriteLiteral("            <th style=\"min-width: 150px;\">");
#nullable restore
#line 26 "D:\SourceCode\CSJ Rubber\Authentication\Views\Shared\_ViewHeaderSupplier.cshtml"
                                     Write(item);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n");
#nullable restore
#line 27 "D:\SourceCode\CSJ Rubber\Authentication\Views\Shared\_ViewHeaderSupplier.cshtml"
            break;
        case "Address1":
        case "Address2":
        case "Address3":

#line default
#line hidden
#nullable disable
            WriteLiteral("            <th style=\"min-width: 160px;\">");
#nullable restore
#line 31 "D:\SourceCode\CSJ Rubber\Authentication\Views\Shared\_ViewHeaderSupplier.cshtml"
                                     Write(item);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n");
#nullable restore
#line 32 "D:\SourceCode\CSJ Rubber\Authentication\Views\Shared\_ViewHeaderSupplier.cshtml"
            break;
        case "E-mail":

#line default
#line hidden
#nullable disable
            WriteLiteral("            <th style=\"min-width: 200px;\">");
#nullable restore
#line 34 "D:\SourceCode\CSJ Rubber\Authentication\Views\Shared\_ViewHeaderSupplier.cshtml"
                                     Write(item);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n");
#nullable restore
#line 35 "D:\SourceCode\CSJ Rubber\Authentication\Views\Shared\_ViewHeaderSupplier.cshtml"
            break;
        case "Supplier Name":

#line default
#line hidden
#nullable disable
            WriteLiteral("            <th style=\"min-width: 210px;\">");
#nullable restore
#line 37 "D:\SourceCode\CSJ Rubber\Authentication\Views\Shared\_ViewHeaderSupplier.cshtml"
                                     Write(item);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n");
#nullable restore
#line 38 "D:\SourceCode\CSJ Rubber\Authentication\Views\Shared\_ViewHeaderSupplier.cshtml"
            break;
        default:

#line default
#line hidden
#nullable disable
            WriteLiteral("            <th>");
#nullable restore
#line 40 "D:\SourceCode\CSJ Rubber\Authentication\Views\Shared\_ViewHeaderSupplier.cshtml"
           Write(item);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n");
#nullable restore
#line 41 "D:\SourceCode\CSJ Rubber\Authentication\Views\Shared\_ViewHeaderSupplier.cshtml"
            break;
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 42 "D:\SourceCode\CSJ Rubber\Authentication\Views\Shared\_ViewHeaderSupplier.cshtml"
     
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
