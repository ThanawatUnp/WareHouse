#pragma checksum "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentOutboundOrder.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "50c6b46c3f9a5f46324e10edd749bf2d489fa44f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__ViewContentOutboundOrder), @"mvc.1.0.view", @"/Views/Shared/_ViewContentOutboundOrder.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"50c6b46c3f9a5f46324e10edd749bf2d489fa44f", @"/Views/Shared/_ViewContentOutboundOrder.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"acdb2e1b339642545d0bc56e1deb0ca293ad13ea", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__ViewContentOutboundOrder : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("edit-outboundorder"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditOutboundOrder", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("delete-outboundorder"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DeleteOutboundOrder", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 8 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentOutboundOrder.cshtml"
       int i = ViewBag.FirstRec;
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentOutboundOrder.cshtml"
         if (Model.Count == 0)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr class=\"no-data\">\r\n                <td colspan=\"17\">Not Found Data</td>\r\n            </tr>\r\n");
#nullable restore
#line 14 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentOutboundOrder.cshtml"
        }
        else
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentOutboundOrder.cshtml"
             foreach (OutboundOrder outboundOrder in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr class=\"tbl-row\">\r\n                    <td>\r\n                        ");
#nullable restore
#line 21 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentOutboundOrder.cshtml"
                   Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "50c6b46c3f9a5f46324e10edd749bf2d489fa44f5939", async() => {
                WriteLiteral("\r\n                            <i class=\"fas fa-edit\"></i>\r\n                        ");
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
#line 24 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentOutboundOrder.cshtml"
                                                                                    WriteLiteral(outboundOrder.Id);

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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "50c6b46c3f9a5f46324e10edd749bf2d489fa44f8391", async() => {
                WriteLiteral("\r\n                            <i class=\"fas fa-trash\"></i>\r\n                        ");
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
#line 29 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentOutboundOrder.cshtml"
                                                                                        WriteLiteral(outboundOrder.Id);

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
#nullable restore
#line 34 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentOutboundOrder.cshtml"
                   Write(outboundOrder.StatusOutboundOrder.status);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 37 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentOutboundOrder.cshtml"
                   Write(outboundOrder.order_no);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 40 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentOutboundOrder.cshtml"
                   Write(outboundOrder.OrderType.order_type);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n");
#nullable restore
#line 43 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentOutboundOrder.cshtml"
                          
                            DateTime dt;
                            if (outboundOrder.plan_ship_date != null)
                            {
                                dt = Convert.ToDateTime(outboundOrder.plan_ship_date);
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 48 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentOutboundOrder.cshtml"
                           Write(dt.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 48 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentOutboundOrder.cshtml"
                                                          ;
                            }
                        

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </td>\r\n                    <td>\r\n");
#nullable restore
#line 53 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentOutboundOrder.cshtml"
                         if (outboundOrder.Customer != null)
                        {
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 55 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentOutboundOrder.cshtml"
                        Write(outboundOrder.Customer.customer_code + ": " + outboundOrder.Customer.customer_name);

#line default
#line hidden
#nullable disable
#nullable restore
#line 55 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentOutboundOrder.cshtml"
                                                                                                                 
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 59 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentOutboundOrder.cshtml"
                   Write(outboundOrder.invoice_no);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 62 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentOutboundOrder.cshtml"
                   Write(outboundOrder.StatusOutboundOrder.description);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 65 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentOutboundOrder.cshtml"
                   Write(outboundOrder.create_by);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n");
#nullable restore
#line 68 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentOutboundOrder.cshtml"
                          
                            dt = Convert.ToDateTime(outboundOrder.create_date);
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 70 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentOutboundOrder.cshtml"
                       Write(dt.ToString("dd/MM/yyyy HH:mm:ss"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 70 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentOutboundOrder.cshtml"
                                                               ;
                        

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 74 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentOutboundOrder.cshtml"
                   Write(outboundOrder.edit_by);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n");
#nullable restore
#line 77 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentOutboundOrder.cshtml"
                          
                            if (outboundOrder.edit_date != null)
                            {
                                dt = Convert.ToDateTime(outboundOrder.edit_date);
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 81 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentOutboundOrder.cshtml"
                           Write(dt.ToString("dd/MM/yyyy HH:mm:ss"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 81 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentOutboundOrder.cshtml"
                                                                   ;
                            }
                        

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 86 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentOutboundOrder.cshtml"
                   Write(outboundOrder.cancel_by);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n");
#nullable restore
#line 89 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentOutboundOrder.cshtml"
                          
                            if (outboundOrder.cancel_date != null)
                            {
                                dt = Convert.ToDateTime(outboundOrder.cancel_date);
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 93 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentOutboundOrder.cshtml"
                           Write(dt.ToString("dd/MM/yyyy HH:mm:ss"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 93 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentOutboundOrder.cshtml"
                                                                   ;
                            }
                        

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 98 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentOutboundOrder.cshtml"
                   Write(outboundOrder.cancel_remark);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 101 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentOutboundOrder.cshtml"
                i = i + 1;
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 102 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentOutboundOrder.cshtml"
             
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