#pragma checksum "D:\SourceCode\CSJ Rubber\Authentication\Views\Shared\_ViewHeaderItemCategory.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "20d06a9a068e3a32b6f8d8d08d55ab9829f9ee040172e42349a00fa953ca146b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__ViewHeaderItemCategory), @"mvc.1.0.view", @"/Views/Shared/_ViewHeaderItemCategory.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"20d06a9a068e3a32b6f8d8d08d55ab9829f9ee040172e42349a00fa953ca146b", @"/Views/Shared/_ViewHeaderItemCategory.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"71bcce66d95c93940ae98c991a01a581406cd371ceec664c269b80da2797d35d", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared__ViewHeaderItemCategory : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\SourceCode\CSJ Rubber\Authentication\Views\Shared\_ViewHeaderItemCategory.cshtml"
 foreach (var item in ViewBag.Header)
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\SourceCode\CSJ Rubber\Authentication\Views\Shared\_ViewHeaderItemCategory.cshtml"
     switch (@item)
    {
        case "Active":

#line default
#line hidden
#nullable disable
            WriteLiteral("            <th style=\"min-width: 90px;\">");
#nullable restore
#line 6 "D:\SourceCode\CSJ Rubber\Authentication\Views\Shared\_ViewHeaderItemCategory.cshtml"
                                    Write(item);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n");
#nullable restore
#line 7 "D:\SourceCode\CSJ Rubber\Authentication\Views\Shared\_ViewHeaderItemCategory.cshtml"
            break;
        case "Create By":
        case "Create Date":
        case "Edit By":
        case "Edit Date":

#line default
#line hidden
#nullable disable
            WriteLiteral("            <th style=\"min-width: 130px;\">");
#nullable restore
#line 12 "D:\SourceCode\CSJ Rubber\Authentication\Views\Shared\_ViewHeaderItemCategory.cshtml"
                                     Write(item);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n");
#nullable restore
#line 13 "D:\SourceCode\CSJ Rubber\Authentication\Views\Shared\_ViewHeaderItemCategory.cshtml"
            break;
        case "Description":

#line default
#line hidden
#nullable disable
            WriteLiteral("            <th style=\"min-width: 150px;\">");
#nullable restore
#line 15 "D:\SourceCode\CSJ Rubber\Authentication\Views\Shared\_ViewHeaderItemCategory.cshtml"
                                     Write(item);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n");
#nullable restore
#line 16 "D:\SourceCode\CSJ Rubber\Authentication\Views\Shared\_ViewHeaderItemCategory.cshtml"
            break;
        case "Category Name":

#line default
#line hidden
#nullable disable
            WriteLiteral("            <th style=\"min-width: 160px;\">");
#nullable restore
#line 18 "D:\SourceCode\CSJ Rubber\Authentication\Views\Shared\_ViewHeaderItemCategory.cshtml"
                                     Write(item);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n");
#nullable restore
#line 19 "D:\SourceCode\CSJ Rubber\Authentication\Views\Shared\_ViewHeaderItemCategory.cshtml"
            break;
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "D:\SourceCode\CSJ Rubber\Authentication\Views\Shared\_ViewHeaderItemCategory.cshtml"
     
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
