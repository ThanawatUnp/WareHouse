#pragma checksum "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentLocation.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9a4594cc8d2e4f6205160ef23998904944a0308c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__ViewContentLocation), @"mvc.1.0.view", @"/Views/Shared/_ViewContentLocation.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9a4594cc8d2e4f6205160ef23998904944a0308c", @"/Views/Shared/_ViewContentLocation.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"acdb2e1b339642545d0bc56e1deb0ca293ad13ea", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__ViewContentLocation : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("detail-location"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("edit-location"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("delete-location"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<tbody id=\"view-content\">\r\n");
#nullable restore
#line 8 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentLocation.cshtml"
       int i = ViewBag.FirstRec;
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentLocation.cshtml"
         if (Model.Count == 0)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr class=\"no-data\">\r\n                <td colspan=\"14\">Not Found Data</td>\r\n            </tr>\r\n");
#nullable restore
#line 14 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentLocation.cshtml"
        }
        else
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentLocation.cshtml"
             foreach (Location location in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr class=\"tbl-row\">\r\n                    <td>\r\n                        ");
#nullable restore
#line 21 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentLocation.cshtml"
                   Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9a4594cc8d2e4f6205160ef23998904944a0308c6497", async() => {
                WriteLiteral("\r\n                            <i class=\"fas fa-eye\"></i>\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 24 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentLocation.cshtml"
                                                                       WriteLiteral(location.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9a4594cc8d2e4f6205160ef23998904944a0308c8925", async() => {
                WriteLiteral("\r\n                            <i class=\"fas fa-edit\"></i>\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 29 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentLocation.cshtml"
                                                                  WriteLiteral(location.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9a4594cc8d2e4f6205160ef23998904944a0308c11349", async() => {
                WriteLiteral("\r\n                            <i class=\"fas fa-trash\"></i>\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 34 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentLocation.cshtml"
                                                                      WriteLiteral(location.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </td>\r\n                    <td style=\"width: 150px;\">\r\n                        ");
#nullable restore
#line 39 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentLocation.cshtml"
                   Write(location.location_code);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n");
#nullable restore
#line 42 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentLocation.cshtml"
                           if (location.LocationCategory != null)
                            {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 44 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentLocation.cshtml"
                           Write(location.LocationCategory.category_name);

#line default
#line hidden
#nullable disable
#nullable restore
#line 44 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentLocation.cshtml"
                                                                        
                            }
                        

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </td>\r\n                    <td style=\"width: 150px;\">\r\n                        ");
#nullable restore
#line 49 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentLocation.cshtml"
                   Write(location.description);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td style=\"width: 90px;\">\r\n");
#nullable restore
#line 52 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentLocation.cshtml"
                           String sMixItem = "No";
                            if (@location.mix_item == true)
                            {
                                sMixItem = "Yes";
                            }
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 57 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentLocation.cshtml"
                       Write(sMixItem.ToString());

#line default
#line hidden
#nullable disable
#nullable restore
#line 57 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentLocation.cshtml"
                                                ;
                        

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </td>\r\n                    <td style=\"width: 100px;\">\r\n");
#nullable restore
#line 61 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentLocation.cshtml"
                           String sMixExpire = "No";
                            if (@location.mix_expire == true)
                            {
                                sMixExpire = "Yes";
                            }
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 66 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentLocation.cshtml"
                       Write(sMixExpire.ToString());

#line default
#line hidden
#nullable disable
#nullable restore
#line 66 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentLocation.cshtml"
                                                  ;
                        

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </td>\r\n                    <td style=\"width: 90px;\">\r\n");
#nullable restore
#line 70 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentLocation.cshtml"
                           String sMixLot = "No";
                            if (@location.mix_lot == true)
                            {
                                sMixLot = "Yes";
                            }
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 75 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentLocation.cshtml"
                       Write(sMixLot.ToString());

#line default
#line hidden
#nullable disable
#nullable restore
#line 75 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentLocation.cshtml"
                                               ;
                        

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </td>\r\n                    <td style=\"width: 130px;\">\r\n                        ");
#nullable restore
#line 79 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentLocation.cshtml"
                   Write(location.create_by);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td style=\"width: 130px;\">\r\n");
#nullable restore
#line 82 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentLocation.cshtml"
                          
                            DateTime dt = Convert.ToDateTime(@location.create_date);
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 84 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentLocation.cshtml"
                       Write(dt.ToString("dd/MM/yyyy HH:mm:ss"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 84 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentLocation.cshtml"
                                                               ;
                        

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </td>\r\n                    <td style=\"width: 130px;\">\r\n                        ");
#nullable restore
#line 88 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentLocation.cshtml"
                   Write(location.edit_by);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td style=\"width: 130px;\">\r\n");
#nullable restore
#line 91 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentLocation.cshtml"
                          
                            if (@location.edit_date != null)
                            {
                                dt = Convert.ToDateTime(@location.edit_date);
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 95 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentLocation.cshtml"
                           Write(dt.ToString("dd/MM/yyyy HH:mm:ss"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 95 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentLocation.cshtml"
                                                                   ;
                            }
                        

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 100 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentLocation.cshtml"
                i = i + 1;
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 101 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentLocation.cshtml"
             
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