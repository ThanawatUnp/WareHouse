#pragma checksum "D:\SourceCode\CSJ Rubber\Authentication\Views\Locations\ViewContent.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "10eae65209b09f0df9ce41113813fca70896868ac9cb66d4878fbb9b94db9755"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Locations_ViewContent), @"mvc.1.0.view", @"/Views/Locations/ViewContent.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"10eae65209b09f0df9ce41113813fca70896868ac9cb66d4878fbb9b94db9755", @"/Views/Locations/ViewContent.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"71bcce66d95c93940ae98c991a01a581406cd371ceec664c269b80da2797d35d", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Locations_ViewContent : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Authentication.Models.Location>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_Btn_Group", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-inline frm-float-right"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("frm_txtOrderType"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("z-index: 10000 !important;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("ddlLocationCategory"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control txt-search-width-non"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("padding-left: 20px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_ViewData", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\SourceCode\CSJ Rubber\Authentication\Views\Locations\ViewContent.cshtml"
  
    Layout = null;
    ViewBag.Model = Model;


#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<script type=""text/javascript"">
    $(document).ready(function () {
        $('#dtCreateDate').daterangepicker({
            showDropdowns: true,
            minDate: '01/01/2021',
            dateLimit: { days: 365 },
            maxDate: moment(),
            autoUpdateInput: false,
            locale: {
                cancelLabel: 'Clear'
            }
        });

        $('#dtCreateDate').on('apply.daterangepicker', function (ev, picker) {
            globalThis.vCreateDate = ""y"";
            $(this).val(picker.startDate.format('MM/DD/YYYY') + ' - ' + picker.endDate.format('MM/DD/YYYY'));
        });

        $('#dtEditDate').daterangepicker({
            showDropdowns: true,
            minDate: '01/01/2021',
            dateLimit: { days: 365 },
            maxDate: moment(),
            autoUpdateInput: false,
            locale: {
                cancelLabel: 'Clear'
            }
        });

        $('#dtEditDate').on('apply.daterangepicker', function (ev, picker) ");
            WriteLiteral("{\r\n            globalThis.vEditeDate = \"y\";\r\n            $(this).val(picker.startDate.format(\'MM/DD/YYYY\') + \' - \' + picker.endDate.format(\'MM/DD/YYYY\'));\r\n        });\r\n\r\n        $(\'#txtLocationCode\').val(");
#nullable restore
#line 43 "D:\SourceCode\CSJ Rubber\Authentication\Views\Locations\ViewContent.cshtml"
                             Write(Html.Raw(Json.Serialize(@ViewBag.locationcode)));

#line default
#line hidden
#nullable disable
            WriteLiteral(");\r\n        $(\'#ddlLocationCategory\').val(");
#nullable restore
#line 44 "D:\SourceCode\CSJ Rubber\Authentication\Views\Locations\ViewContent.cshtml"
                                 Write(Html.Raw(Json.Serialize(@ViewBag.locationcategory)));

#line default
#line hidden
#nullable disable
            WriteLiteral(");\r\n        $(\'#ddlMixExpire\').val(");
#nullable restore
#line 45 "D:\SourceCode\CSJ Rubber\Authentication\Views\Locations\ViewContent.cshtml"
                          Write(Html.Raw(Json.Serialize(@ViewBag.mixexpire)));

#line default
#line hidden
#nullable disable
            WriteLiteral(");\r\n        $(\'#ddlMixItem\').val(");
#nullable restore
#line 46 "D:\SourceCode\CSJ Rubber\Authentication\Views\Locations\ViewContent.cshtml"
                        Write(Html.Raw(Json.Serialize(@ViewBag.mixitem)));

#line default
#line hidden
#nullable disable
            WriteLiteral(");\r\n        $(\'#ddlMixLot\').val(");
#nullable restore
#line 47 "D:\SourceCode\CSJ Rubber\Authentication\Views\Locations\ViewContent.cshtml"
                       Write(Html.Raw(Json.Serialize(@ViewBag.mixlot)));

#line default
#line hidden
#nullable disable
            WriteLiteral("),\r\n        $(\'#txtCreateBy\').val(");
#nullable restore
#line 48 "D:\SourceCode\CSJ Rubber\Authentication\Views\Locations\ViewContent.cshtml"
                         Write(Html.Raw(Json.Serialize(@ViewBag.createby)));

#line default
#line hidden
#nullable disable
            WriteLiteral(");\r\n        $(\'#txtEditBy\').val(");
#nullable restore
#line 49 "D:\SourceCode\CSJ Rubber\Authentication\Views\Locations\ViewContent.cshtml"
                       Write(Html.Raw(Json.Serialize(@ViewBag.editby)));

#line default
#line hidden
#nullable disable
            WriteLiteral(");\r\n        if (String(");
#nullable restore
#line 50 "D:\SourceCode\CSJ Rubber\Authentication\Views\Locations\ViewContent.cshtml"
              Write(Html.Raw(Json.Serialize(@ViewBag.createdatestate)));

#line default
#line hidden
#nullable disable
            WriteLiteral(") === \"y\")\r\n            $(\'#dtCreateDate\').daterangepicker({\r\n                \"startDate\": String(");
#nullable restore
#line 52 "D:\SourceCode\CSJ Rubber\Authentication\Views\Locations\ViewContent.cshtml"
                               Write(Html.Raw(Json.Serialize(@ViewBag.startcreatedate)));

#line default
#line hidden
#nullable disable
            WriteLiteral("),\r\n                \"endDate\": String(");
#nullable restore
#line 53 "D:\SourceCode\CSJ Rubber\Authentication\Views\Locations\ViewContent.cshtml"
                             Write(Html.Raw(Json.Serialize(@ViewBag.endcreatedate)));

#line default
#line hidden
#nullable disable
            WriteLiteral("),\r\n                locale: {\r\n                    cancelLabel: \'Clear\'\r\n                }\r\n            });\r\n\r\n        if (String(");
#nullable restore
#line 59 "D:\SourceCode\CSJ Rubber\Authentication\Views\Locations\ViewContent.cshtml"
              Write(Html.Raw(Json.Serialize(@ViewBag.editdatestate)));

#line default
#line hidden
#nullable disable
            WriteLiteral(") === \"y\")\r\n            $(\'#dtEditDate\').daterangepicker({\r\n                \"startDate\": String(");
#nullable restore
#line 61 "D:\SourceCode\CSJ Rubber\Authentication\Views\Locations\ViewContent.cshtml"
                               Write(Html.Raw(Json.Serialize(@ViewBag.starteditdate)));

#line default
#line hidden
#nullable disable
            WriteLiteral("),\r\n                \"endDate\": String(");
#nullable restore
#line 62 "D:\SourceCode\CSJ Rubber\Authentication\Views\Locations\ViewContent.cshtml"
                             Write(Html.Raw(Json.Serialize(@ViewBag.endeditdate)));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"),
                locale: {
                    cancelLabel: 'Clear'
                }
            });

        $('#dtCreateDate').on('cancel.daterangepicker', function (ev, picker) {
            globalThis.vCreateDate = ""n"";
            console.log(vCreateDate);
            $(this).val('');
        });

        $('#dtEditDate').on('cancel.daterangepicker', function (ev, picker) {
            globalThis.vEditeDate = ""n"";
            $(this).val('');
        });
    });
</script>

<fieldset>
    <legend>
        <span class=""font-weight-bold"" style=""font-size: 16px;"">Search / View Data</span>
    </legend>
</fieldset>
<hr class=""mt-0 mb-1"" style=""border-top: 2px solid #bbb;"" />
<div id=""tool-panel"" class=""border"" style=""width: 100%; white-space: nowrap;"">
    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "10eae65209b09f0df9ce41113813fca70896868ac9cb66d4878fbb9b94db975513013", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
</div>
<div id=""search-block"" class=""border py-3"" style=""box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19) !important;"">
    <div class=""container-fluid p-2"">
        <div class=""row"">
            <div class=""col-md-6 col-xl-5"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "10eae65209b09f0df9ce41113813fca70896868ac9cb66d4878fbb9b94db975514442", async() => {
                WriteLiteral(@"
                    <div class=""form-group div-frm-group-search"">
                        <label class=""mx-3"" for=""txtLocationCode""><b>Location Code</b></label>
                        <input class=""form-control txt-search-width-non"" id=""txtLocationCode"" />
                    </div>
                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "10eae65209b09f0df9ce41113813fca70896868ac9cb66d4878fbb9b94db975516277", async() => {
                WriteLiteral("\r\n                    <div class=\"form-group div-frm-group-search\">\r\n                        <label class=\"mx-3\" for=\"ddlLocationCategory\"><b>Location Category</b></label>\r\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "10eae65209b09f0df9ce41113813fca70896868ac9cb66d4878fbb9b94db975516765", async() => {
                    WriteLiteral("\r\n                        ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
#nullable restore
#line 103 "D:\SourceCode\CSJ Rubber\Authentication\Views\Locations\ViewContent.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = ViewBag.LocationCategoryList;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                    </div>\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            WriteLiteral("            </div>\r\n            <div class=\"col-md-6 col-xl-5\">\r\n\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "10eae65209b09f0df9ce41113813fca70896868ac9cb66d4878fbb9b94db975519787", async() => {
                WriteLiteral(@"
                    <div class=""form-group div-frm-group-search"">
                        <label class=""mx-3"" for=""txtCreateBy""><b>Create By</b></label>
                        <input class=""form-control txt-search-width-non"" id=""txtCreateBy"" />
                    </div>
                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "10eae65209b09f0df9ce41113813fca70896868ac9cb66d4878fbb9b94db975521444", async() => {
                WriteLiteral(@"
                    <div class=""form-group div-frm-group-search"">
                        <label class=""mx-3"" for=""dtCreateDate""><b>Create Date</b></label>
                        <input id=""dtCreateDate"" name=""dtCreateDate"" type='text' class=""form-control text-left txt-search-width-non dt-font"" style=""padding-right:2.5rem;"" placeholder=""mm/dd/yyyy-mm/dd/yyyy"" />
                        <div class=""arrow-datetime"" onclick=""$('#dtCreateDate').data('daterangepicker').toggle();"">
                            <i class=""far fa-calendar-alt""></i>
                        </div>
                    </div>
                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            </div>

        </div>
    </div>
    <div class=""mr-3 mt-2"" align=""right"">
        <button class=""btn bg-new-search btn-search-clear btn-search"" id=""btnSearch"" onclick=""Search()"">Search</button>
        <button class=""btn btn-search-clear btn-clear"" style=""border: 1px solid #ced4da"" onclick=""clearSearch()"">Clear</button>
    </div>
</div>
");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "10eae65209b09f0df9ce41113813fca70896868ac9cb66d4878fbb9b94db975523809", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Authentication.Models.Location>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
