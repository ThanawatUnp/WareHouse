#pragma checksum "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentPutAway.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "89c61b7119f731ad19db65616beadfa0d622e176"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__ViewContentPutAway), @"mvc.1.0.view", @"/Views/Shared/_ViewContentPutAway.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"89c61b7119f731ad19db65616beadfa0d622e176", @"/Views/Shared/_ViewContentPutAway.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"acdb2e1b339642545d0bc56e1deb0ca293ad13ea", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__ViewContentPutAway : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("putaway-receiveditem"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "PutAway", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 8 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentPutAway.cshtml"
       int i = 1;
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentPutAway.cshtml"
         if (Model.Count == 0)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr class=\"no-data\">\r\n                <td colspan=\"12\">Not Found Data</td>\r\n            </tr>\r\n");
#nullable restore
#line 14 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentPutAway.cshtml"
        }
        else
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentPutAway.cshtml"
             foreach (ItemReceived itemReceived in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr class=\"tbl-row\">\r\n                    <td>\r\n                        ");
#nullable restore
#line 21 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentPutAway.cshtml"
                   Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "89c61b7119f731ad19db65616beadfa0d622e1765183", async() => {
                WriteLiteral("\r\n                            <i class=\"fas fa-dolly\"></i>\r\n                        ");
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
#line 24 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentPutAway.cshtml"
                                                                            WriteLiteral(itemReceived.Id);

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
#line 29 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentPutAway.cshtml"
                   Write(itemReceived.InboundItem.InboundOrder.order_no);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 32 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentPutAway.cshtml"
                    Write(itemReceived.InboundItem.Item.item_code + ": " + itemReceived.InboundItem.Item.item_name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 35 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentPutAway.cshtml"
                   Write(itemReceived.ItemReceivedState.state);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 38 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentPutAway.cshtml"
                   Write(itemReceived.receive_qty);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 41 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentPutAway.cshtml"
                   Write(itemReceived.remain_putaway);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 44 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentPutAway.cshtml"
                   Write(itemReceived.cost);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 47 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentPutAway.cshtml"
                   Write(itemReceived.lot_no);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n");
#nullable restore
#line 50 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentPutAway.cshtml"
                          
                            DateTime dt;
                            if (itemReceived.expire_date != null)
                            {
                                dt = Convert.ToDateTime(itemReceived.expire_date);
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 55 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentPutAway.cshtml"
                           Write(dt.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 55 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentPutAway.cshtml"
                                                          ;
                            }
                        

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </td>\r\n                    <td>\r\n");
#nullable restore
#line 60 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentPutAway.cshtml"
                          
                            if (itemReceived.receive_date != null)
                            {
                                dt = Convert.ToDateTime(itemReceived.receive_date);
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 64 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentPutAway.cshtml"
                           Write(dt.ToString("dd/MM/yyyy HH:mm:ss"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 64 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentPutAway.cshtml"
                                                                   ;
                            }
                        

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 69 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentPutAway.cshtml"
                   Write(itemReceived.description);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 72 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentPutAway.cshtml"
                i = i + 1;
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 73 "D:\Project\WareHouse\Authentication\Views\Shared\_ViewContentPutAway.cshtml"
             
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("</tbody>");
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