#pragma checksum "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\Shared\_Btn_Group_Sub_Resource.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1c5d5044d2a8156d29daea7e6633ec6812c29e89"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Btn_Group_Sub_Resource), @"mvc.1.0.view", @"/Views/Shared/_Btn_Group_Sub_Resource.cshtml")]
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
#line 1 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\_ViewImports.cshtml"
using Authentication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\_ViewImports.cshtml"
using Authentication.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1c5d5044d2a8156d29daea7e6633ec6812c29e89", @"/Views/Shared/_Btn_Group_Sub_Resource.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"acdb2e1b339642545d0bc56e1deb0ca293ad13ea", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Btn_Group_Sub_Resource : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div class=""ml-2 my-2"" style=""width: 50%; display: inline-block;"">
    <div class=""btn-group"">
        <div id=""btn-group-sub-resource"" class=""btn-group"" role=""group"">
            <button id=""btn-perpage-sub-resource"" class=""btn dropdown-toggle text-white custom-dropdown-toggle btn-group-submenu btn-group-hide-filter"" style=""margin-left: 4px!important; padding-left: 7px;"" data-toggle=""dropdown"">Limit ");
#nullable restore
#line 4 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\Shared\_Btn_Group_Sub_Resource.cshtml"
                                                                                                                                                                                                                                       Write(ViewBag.PerPageSubItm);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</button>
            <div class=""dropdown-menu"">
                <a id=""custom-dropdown-item"" class=""dropdown-item"" rel=""0"" href=""#"">Limit 10</a>
                <a id=""custom-dropdown-item"" class=""dropdown-item"" rel=""1"" href=""#"">Limit 20</a>
                <a id=""custom-dropdown-item"" class=""dropdown-item"" rel=""2"" href=""#"">Limit 30</a>
            </div>
        </div>
    </div>
</div>
<div id=""page-number-sub-resource"" class=""ml-2 my-2"" style=""width: 50%; display: inline-block;"">
    <div style=""display: flex; justify-content: flex-end; margin-right: 30px;"">
        <span class=""page-detail"">
            ");
#nullable restore
#line 16 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\Shared\_Btn_Group_Sub_Resource.cshtml"
       Write(ViewBag.FirstRecSubItm);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <span class=\"label-ext\" id=\"LabelTo_labSubResource\">&nbsp;to&nbsp;</span>\r\n            ");
#nullable restore
#line 18 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\Shared\_Btn_Group_Sub_Resource.cshtml"
       Write(ViewBag.LastRecSubItm);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            [\r\n            <span class=\"label-ext\" id=\"LabelOf_labSubResource\">&nbsp;Page&nbsp;</span>\r\n            ");
#nullable restore
#line 21 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\Shared\_Btn_Group_Sub_Resource.cshtml"
       Write(ViewBag.PageNoSubItm);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <span class=\"label-ext\" id=\"LabelRows_labSubResource\">&nbsp;of&nbsp;</span>\r\n            ");
#nullable restore
#line 23 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\Shared\_Btn_Group_Sub_Resource.cshtml"
       Write(ViewBag.MaxPageSubItm);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ]\r\n            &nbsp;\r\n        </span>\r\n");
#nullable restore
#line 27 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\Shared\_Btn_Group_Sub_Resource.cshtml"
         if (ViewBag.MaxPageSubItm > 1)
        {
            if (ViewBag.PageNoSubItm == 1)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <span class=\"first-page\">&nbsp;First&nbsp;</span>\r\n");
#nullable restore
#line 32 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\Shared\_Btn_Group_Sub_Resource.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <a class=\"page-number-sub-resource\" id=\"page-first\">First</a>\r\n");
#nullable restore
#line 36 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\Shared\_Btn_Group_Sub_Resource.cshtml"
            }

            int idx = 1;
            for (int i = 1; i <= ViewBag.MaxPageSubItm; i++)
            {
                if (ViewBag.MaxPageSubItm <= 4)
                {
                    if (ViewBag.PageNoSubItm == i)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span class=\"current-page\">");
#nullable restore
#line 45 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\Shared\_Btn_Group_Sub_Resource.cshtml"
                                              Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 46 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\Shared\_Btn_Group_Sub_Resource.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <a class=\"page-number-sub-resource\">");
#nullable restore
#line 49 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\Shared\_Btn_Group_Sub_Resource.cshtml"
                                                       Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 50 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\Shared\_Btn_Group_Sub_Resource.cshtml"
                    }
                }
                else
                {
                    if (ViewBag.MaxPageSubItm == 5)
                    {
                        if (ViewBag.PageNoSubItm == i)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <span class=\"current-page\">");
#nullable restore
#line 58 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\Shared\_Btn_Group_Sub_Resource.cshtml"
                                                  Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 59 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\Shared\_Btn_Group_Sub_Resource.cshtml"
                        }
                        else
                        {
                            if (i == 1)
                            {
                                if (ViewBag.PageNoSubItm >= 4)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <span class=\"hidden-page\">...</span>\r\n");
#nullable restore
#line 67 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\Shared\_Btn_Group_Sub_Resource.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <a class=\"page-number-sub-resource\">");
#nullable restore
#line 70 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\Shared\_Btn_Group_Sub_Resource.cshtml"
                                                                   Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 71 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\Shared\_Btn_Group_Sub_Resource.cshtml"
                                }
                            }
                            else if (i == 5)
                            {
                                if (ViewBag.PageNoSubItm >= 4)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <a class=\"page-number-sub-resource\">");
#nullable restore
#line 77 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\Shared\_Btn_Group_Sub_Resource.cshtml"
                                                                   Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 78 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\Shared\_Btn_Group_Sub_Resource.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <span class=\"hidden-page\">...</span>\r\n");
#nullable restore
#line 82 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\Shared\_Btn_Group_Sub_Resource.cshtml"
                                }
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <a class=\"page-number-sub-resource\">");
#nullable restore
#line 86 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\Shared\_Btn_Group_Sub_Resource.cshtml"
                                                               Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 87 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\Shared\_Btn_Group_Sub_Resource.cshtml"
                            }


                        }
                    }
                    else
                    {
                        if (idx == 1)
                        {
                            if (ViewBag.PageNoSubItm == i)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <span class=\"current-page\">");
#nullable restore
#line 98 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\Shared\_Btn_Group_Sub_Resource.cshtml"
                                                      Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 99 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\Shared\_Btn_Group_Sub_Resource.cshtml"
                            }
                            else
                            {
                                if (ViewBag.PageNoSubItm >= 4)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <span class=\"hidden-page\">...</span>\r\n");
#nullable restore
#line 105 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\Shared\_Btn_Group_Sub_Resource.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <a class=\"page-number-sub-resource\">");
#nullable restore
#line 108 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\Shared\_Btn_Group_Sub_Resource.cshtml"
                                                                   Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 109 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\Shared\_Btn_Group_Sub_Resource.cshtml"
                                }
                            }
                            idx = idx + 1;
                        }
                        else if (idx == 2)
                        {
                            if (ViewBag.PageNoSubItm >= 4)
                            {
                                if ((ViewBag.PageNoSubItm + 1) == ViewBag.MaxPageSubItm)
                                {
                                    if ((ViewBag.PageNoSubItm - 2) == i)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <a class=\"page-number-sub-resource\">");
#nullable restore
#line 121 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\Shared\_Btn_Group_Sub_Resource.cshtml"
                                                                       Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 122 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\Shared\_Btn_Group_Sub_Resource.cshtml"
                                        idx = idx + 1;
                                    }
                                }
                                else if (ViewBag.PageNoSubItm == ViewBag.MaxPageSubItm)
                                {
                                    if ((ViewBag.PageNoSubItm - 3) == i)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <a class=\"page-number-sub-resource\">");
#nullable restore
#line 129 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\Shared\_Btn_Group_Sub_Resource.cshtml"
                                                                       Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 130 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\Shared\_Btn_Group_Sub_Resource.cshtml"
                                        idx = idx + 1;
                                    }
                                }
                                else
                                {
                                    if ((ViewBag.PageNoSubItm - 1) == i)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <a class=\"page-number-sub-resource\">");
#nullable restore
#line 137 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\Shared\_Btn_Group_Sub_Resource.cshtml"
                                                                       Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 138 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\Shared\_Btn_Group_Sub_Resource.cshtml"
                                        idx = idx + 1;
                                    }
                                }
                            }
                            else
                            {
                                if (ViewBag.PageNoSubItm == i)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <span class=\"current-page\">");
#nullable restore
#line 146 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\Shared\_Btn_Group_Sub_Resource.cshtml"
                                                          Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 147 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\Shared\_Btn_Group_Sub_Resource.cshtml"
                                    idx = idx + 1;
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <a class=\"page-number-sub-resource\">");
#nullable restore
#line 151 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\Shared\_Btn_Group_Sub_Resource.cshtml"
                                                                   Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 152 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\Shared\_Btn_Group_Sub_Resource.cshtml"
                                    idx = idx + 1;
                                }
                            }
                        }
                        else if (idx == 3)
                        {
                            if (ViewBag.PageNoSubItm >= 4)
                            {
                                if ((ViewBag.PageNoSubItm + 1) == ViewBag.MaxPageSubItm)
                                {
                                    if ((ViewBag.PageNoSubItm - 1) == i)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <a class=\"page-number-sub-resource\">");
#nullable restore
#line 164 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\Shared\_Btn_Group_Sub_Resource.cshtml"
                                                                       Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 165 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\Shared\_Btn_Group_Sub_Resource.cshtml"
                                        idx = idx + 1;
                                    }
                                }
                                else if (ViewBag.PageNoSubItm == ViewBag.MaxPageSubItm)
                                {
                                    if ((ViewBag.PageNoSubItm - 2) == i)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <a class=\"page-number-sub-resource\">");
#nullable restore
#line 172 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\Shared\_Btn_Group_Sub_Resource.cshtml"
                                                                       Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 173 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\Shared\_Btn_Group_Sub_Resource.cshtml"
                                        idx = idx + 1;
                                    }
                                }
                                else if (ViewBag.PageNoSubItm == i)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <span class=\"current-page\">");
#nullable restore
#line 178 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\Shared\_Btn_Group_Sub_Resource.cshtml"
                                                          Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 179 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\Shared\_Btn_Group_Sub_Resource.cshtml"
                                    idx = idx + 1;
                                }
                            }
                            else
                            {
                                if (ViewBag.PageNoSubItm == i)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <span class=\"current-page\">");
#nullable restore
#line 186 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\Shared\_Btn_Group_Sub_Resource.cshtml"
                                                          Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 187 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\Shared\_Btn_Group_Sub_Resource.cshtml"
                                    idx = idx + 1;
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <a class=\"page-number-sub-resource\">");
#nullable restore
#line 191 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\Shared\_Btn_Group_Sub_Resource.cshtml"
                                                                   Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 192 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\Shared\_Btn_Group_Sub_Resource.cshtml"
                                    idx = idx + 1;
                                }
                            }
                        }
                        else if (idx == 4)
                        {
                            if (ViewBag.PageNoSubItm >= 4)
                            {
                                if (ViewBag.PageNoSubItm == ViewBag.MaxPageSubItm)
                                {
                                    if ((ViewBag.PageNoSubItm - 1) == i)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <a class=\"page-number-sub-resource\">");
#nullable restore
#line 204 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\Shared\_Btn_Group_Sub_Resource.cshtml"
                                                                       Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 205 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\Shared\_Btn_Group_Sub_Resource.cshtml"
                                        idx = idx + 1;
                                    }
                                }
                                else
                                {
                                    if ((ViewBag.MaxPageSubItm - 1) == ViewBag.PageNoSubItm)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <span class=\"current-page\">");
#nullable restore
#line 212 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\Shared\_Btn_Group_Sub_Resource.cshtml"
                                                              Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 213 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\Shared\_Btn_Group_Sub_Resource.cshtml"
                                        idx = idx + 1;
                                    }
                                    else
                                    {
                                        if ((ViewBag.PageNoSubItm + 2) == ViewBag.MaxPageSubItm)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <a class=\"page-number-sub-resource\">");
#nullable restore
#line 219 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\Shared\_Btn_Group_Sub_Resource.cshtml"
                                                                           Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 220 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\Shared\_Btn_Group_Sub_Resource.cshtml"
                                            idx = idx + 1;
                                        }
                                        else
                                        {
                                            if ((ViewBag.PageNoSubItm + 1) == i)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <a class=\"page-number-sub-resource\">");
#nullable restore
#line 226 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\Shared\_Btn_Group_Sub_Resource.cshtml"
                                                                               Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 227 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\Shared\_Btn_Group_Sub_Resource.cshtml"
                                                idx = idx + 1;
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <a class=\"page-number-sub-resource\">");
#nullable restore
#line 235 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\Shared\_Btn_Group_Sub_Resource.cshtml"
                                                               Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 236 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\Shared\_Btn_Group_Sub_Resource.cshtml"
                                idx = idx + 1;
                            }
                        }
                        else if (idx == 5)
                        {
                            if (ViewBag.PageNoSubItm >= 4)
                            {

                                if ((ViewBag.PageNoSubItm + 2) == ViewBag.MaxPageSubItm)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <a class=\"page-number-sub-resource\">");
#nullable restore
#line 246 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\Shared\_Btn_Group_Sub_Resource.cshtml"
                                                                   Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 247 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\Shared\_Btn_Group_Sub_Resource.cshtml"
                                    break;
                                }
                                else if ((ViewBag.PageNoSubItm + 1) == ViewBag.MaxPageSubItm)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <a class=\"page-number-sub-resource\">");
#nullable restore
#line 251 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\Shared\_Btn_Group_Sub_Resource.cshtml"
                                                                   Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 252 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\Shared\_Btn_Group_Sub_Resource.cshtml"
                                    break;
                                }
                                else if (ViewBag.PageNoSubItm == ViewBag.MaxPageSubItm)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <span class=\"current-page\">");
#nullable restore
#line 256 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\Shared\_Btn_Group_Sub_Resource.cshtml"
                                                          Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 257 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\Shared\_Btn_Group_Sub_Resource.cshtml"
                                    break;
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <span class=\"hidden-page\">...</span>\r\n");
#nullable restore
#line 262 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\Shared\_Btn_Group_Sub_Resource.cshtml"
                                    break;
                                }
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <span class=\"hidden-page\">...</span>\r\n");
#nullable restore
#line 268 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\Shared\_Btn_Group_Sub_Resource.cshtml"
                                break;
                            }
                        }
                    }
                }
            }

            if (ViewBag.PageNoSubItm == ViewBag.MaxPageSubItm)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <span class=\"last-page\">&nbsp;Last&nbsp;</span>\r\n");
#nullable restore
#line 278 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\Shared\_Btn_Group_Sub_Resource.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <a class=\"page-number-sub-resource\" id=\"page-last\">Last</a>\r\n");
#nullable restore
#line 282 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\Shared\_Btn_Group_Sub_Resource.cshtml"
            }
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <span class=\"first-page\">&nbsp;First&nbsp;</span><span class=\"current-page\">&nbsp;1&nbsp;</span><span class=\"last-page\">&nbsp;Last&nbsp;</span>\r\n");
#nullable restore
#line 287 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\Shared\_Btn_Group_Sub_Resource.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>\r\n");
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
