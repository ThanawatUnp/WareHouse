#pragma checksum "D:\SourceCode\CSJ Rubber\Authentication\Views\Items\Index.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "9864a86aa6e769a626ae2617e23bb677b1d09c2a38d4d17e9342cc78e0e1b307"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Items_Index), @"mvc.1.0.view", @"/Views/Items/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"9864a86aa6e769a626ae2617e23bb677b1d09c2a38d4d17e9342cc78e0e1b307", @"/Views/Items/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"71bcce66d95c93940ae98c991a01a581406cd371ceec664c269b80da2797d35d", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Items_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Authentication.Models.Item>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_Btn_Group", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-inline frm-float-right"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("frm_txtOrderType"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("z-index: 10000 !important;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("ddlItemCategory"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control txt-search-width-non"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_ViewData", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 2 "D:\SourceCode\CSJ Rubber\Authentication\Views\Items\Index.cshtml"
  
    ViewData["Title"] = "Item";
    ViewBag.Model = Model;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<script type=""text/javascript"">
    var vCreateDate = ""n"";
    var vEditeDate = ""n"";

    function OnCompleteRequest() {
        $('#pop_up').empty();
        $('#pop_up').delay(1000).modal('hide');
    }

    function OnSuccessRequest() {
        alert('On Success');
    }

    function OnFailureRequest() {
        alert('On Failure');
    }

    function showHideSearch() {
        var blockSearch = document.getElementById('search-block');
        if (blockSearch.style.display != ""none"") {
            blockSearch.style.display = 'none';
            document.getElementById('btn-fiter').innerHTML = 'Show Filter';
        }
        else {
            blockSearch.style.display = null;
            document.getElementById('btn-fiter').innerHTML = 'Hide Filter';
        }
    }

    function Search() {
        $.ajax({
            url: '/Items/ViewContent',
            data: {
                //These two keys should keep consistent with the parameters ( int? ProductId , int? Pro");
            WriteLiteral(@"ductPrice ) in action, including uppercase and lowercase.
                itemcode: $('#txtItemCode').val(),
                itemname: $('#txtItemName').val(),
                itemcategory: $('#ddlItemCategory').val(),
                cost: $('#txtCost').val(),
                unit: $('#txtUnit').val(),
                queuetype: $('#ddlQueueType').val(),
                createby: $('#txtCreateBy').val(),
                screatedate: vCreateDate,
                startcreatedate: $('#dtCreateDate').data('daterangepicker').startDate.format('MM/DD/YYYY'),
                endcreatedate: $('#dtCreateDate').data('daterangepicker').endDate.format('MM/DD/YYYY'),
                // editby: $('#txtEditBy').val(),
                // seditdate: vEditeDate,
                // starteditdate: $('#dtEditDate').data('daterangepicker').startDate.format('MM/DD/YYYY'),
                // endeditdate: $('#dtEditDate').data('daterangepicker').endDate.format('MM/DD/YYYY'),
            },
            success: functio");
            WriteLiteral(@"n (result) {
                //let itemcode = $('#txtItemCode').val();
                //let itemname = $('#txtItemName').val();
                //let itemcategory = $('#ddlItemCategory').val();
                //let unit = $('#txtUnit').val();
                //let createby = $('#txtCreateBy').val();
                //let startcreatedate = $('#dtCreateDate').data('daterangepicker').startDate.format('MM/DD/YYYY');
                //let endcreatedate = $('#dtCreateDate').data('daterangepicker').endDate.format('MM/DD/YYYY');
                //let editby = $('#txtEditBy').val();
                //let starteditdate = $('#dtEditDate').data('daterangepicker').startDate.format('MM/DD/YYYY');
                //let endeditdate = $('#dtEditDate').data('daterangepicker').endDate.format('MM/DD/YYYY');
                $('#childLayout').html(result);
                //$('#txtItemCode').val(itemcode);
                //$('#txtItemName').val(itemname);
                //$('#ddlItemCategory').val(itemcategory);");
            WriteLiteral(@"
                //$('#txtUnit').val(unit);
                //$('#txtCreateBy').val(createby);
                //if (vCreateDate === ""y"")
                //    $('#dtCreateDate').daterangepicker({ ""startDate"": String(startcreatedate), ""endDate"": String(endcreatedate) });
                //if (vEditeDate === ""y"")
                //    $('#dtEditDate').daterangepicker({ ""startDate"": String(starteditdate), ""endDate"": String(endeditdate) });
                //$('#txtEditBy').val(editby);
            }
        });
    }

    function clearSearch() {
        globalThis.vCreateDate = ""n"";
        globalThis.vEditeDate = ""n"";
        var f1 = document.getElementById('search-block');
        var arr_input = f1.getElementsByTagName('input');
        for (i = 0; i < arr_input.length; i++) {
            arr_input[i].value = '';
        }
        $('#ddlItemType').val(null);
        $.ajax({
            url: '/Items/ViewContent',
            data: {
                clear: 'clear'
            },
  ");
            WriteLiteral(@"          success: function (result) {
                $('#childLayout').html(result);
            }
        });
    }

    $(document).ready(function () {
        $('#dtCreateDate').daterangepicker({
            showDropdowns: true,
            ""startDate"": moment(),
            ""endDate"": moment(),
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

        $('#dtCreateDate').on('cancel.daterangepicker', function (ev, picker) {
            globalThis.vCreateDate = ""n"";
            $(this).val('');
        });

        $('#dtEditDate').daterangepicker({
            sh");
            WriteLiteral(@"owDropdowns: true,
            ""startDate"": moment(),
            ""endDate"": moment(),
            minDate: '01/01/2021',
            dateLimit: { days: 365 },
            maxDate: moment(),
            autoUpdateInput: false,
            locale: {
                cancelLabel: 'Clear'
            }
        });

        $('#dtEditDate').on('apply.daterangepicker', function (ev, picker) {
            globalThis.vEditeDate = ""y"";
            $(this).val(picker.startDate.format('MM/DD/YYYY') + ' - ' + picker.endDate.format('MM/DD/YYYY'));
        });

        $('#dtEditDate').on('cancel.daterangepicker', function (ev, picker) {
            globalThis.vEditeDate = ""n"";
            $(this).val('');
        });

        // Add Item
        $(document).on(""click"", ""#btNew"", function () {
            $.ajax({
                type: ""GET"",
                data: ""{}"",
                url: $(this).data('url'),
                success: function (result) {
                    $('#pop_up').html(r");
            WriteLiteral(@"esult);
                    $('#pop_up').modal('show');
                },
                error: function (result) {
                    console.log(""error"");
                    alert('error');
                }
            });
            return false;
        });

        // Edit Item
        $(document).on(""click"", ""#ViewData table tbody tr td #edit-item"", function () {
            $.ajax({
                type: ""GET"",
                data: ""{}"",
                url: $(this).attr('href'),
                success: function (result) {
                    $('#pop_up').html(result);
                    $('#pop_up').modal('show');
                },
                error: function (result) {
                    alert('error');
                }
            });
            return false;
        });

        // Detail Item
        $(document).on(""click"", ""#ViewData table tbody tr td #detail-item"", function () {
            $.ajax({
                type: ""GET"",
                dat");
            WriteLiteral(@"a: ""{}"",
                url: $(this).attr('href'),
                success: function (result) {
                    $('#pop_up').html(result);
                    $('#pop_up').modal('show');
                },
                error: function (result) {
                    alert('error');
                }
            });
            return false;
        });

        // Delete Item
        $(document).on(""click"", ""#ViewData table tbody tr td #delete-item"", function () {
            $.ajax({
                type: ""GET"",
                data: ""{}"",
                url: $(this).attr('href'),
                success: function (result) {
                    $('#pop_up').html(result);
                    $('#pop_up').modal('show');
                },
                error: function (result) {
                    alert('error');
                }
            });
            return false;
        });

        // Set Per Page Number
        $(document).on(""click"",""#tool-panel div div di");
            WriteLiteral("v div a\",function () {\r\n            var PerPage = $(this).attr(\'rel\');\r\n            $(\'#btn-perpage\').text($(this).text());\r\n            $.ajax({\r\n                type: \"GET\",\r\n                data: { \"PerPage\": PerPage } ,\r\n                url: \'");
#nullable restore
#line 226 "D:\SourceCode\CSJ Rubber\Authentication\Views\Items\Index.cshtml"
                 Write(Url.Action("SetPerPage"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
                success: function (result) {
                    $('#childLayout').html(result);
                },
                error: function (result) {
                    alert('error');
                }
            });
        });

        //Set Page Number
        $(document).ready(function () {
            $(document).on(""click"",""a.page-number"",function () {
                var PageNo = $(this).text();
                $.ajax({
                    type: ""GET"",
                    data: { ""PageNo"": PageNo } ,
                    url: '");
#nullable restore
#line 243 "D:\SourceCode\CSJ Rubber\Authentication\Views\Items\Index.cshtml"
                     Write(Url.Action("SetPageNo"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
                    success: function (result) {
                        $('#childLayout').html(result);
                    },
                    error: function (result) {
                        alert('error');
                    }
                });
            });
        });
    });

</script>
<div id=""sub-container"">
    <div class=""pt-3 pb-5"" id=""childLayout"">
        <fieldset>
            <legend>
                <span class=""font-weight-bold"" style=""font-size: 16px;"">Search / View Data</span>
            </legend>
        </fieldset>
        <hr class=""mt-0 mb-1"" style=""border-top: 2px solid #bbb;"" />
        <div id=""tool-panel"" class=""border"" style=""width: 100%; white-space: nowrap;"">
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "9864a86aa6e769a626ae2617e23bb677b1d09c2a38d4d17e9342cc78e0e1b30716875", async() => {
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9864a86aa6e769a626ae2617e23bb677b1d09c2a38d4d17e9342cc78e0e1b30718352", async() => {
                WriteLiteral(@"
                            <div class=""form-group div-frm-group-search"">
                                <label class=""mx-3"" for=""txtItemCode""><b>Item Code</b></label>
                                <input class=""form-control txt-search-width-non"" id=""txtItemCode"" />
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
            WriteLiteral("\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9864a86aa6e769a626ae2617e23bb677b1d09c2a38d4d17e9342cc78e0e1b30720223", async() => {
                WriteLiteral(@"
                            <div class=""form-group div-frm-group-search"">
                                <label class=""mx-3"" for=""txtItemName""><b>Item Name</b></label>
                                <input class=""form-control txt-search-width-non"" id=""txtItemName"" />
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
            WriteLiteral("\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9864a86aa6e769a626ae2617e23bb677b1d09c2a38d4d17e9342cc78e0e1b30721928", async() => {
                WriteLiteral("\r\n                            <div class=\"form-group div-frm-group-search\">\r\n                                <label class=\"mx-3\" for=\"ddlItemCategory\"><b>Item Category</b></label>\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9864a86aa6e769a626ae2617e23bb677b1d09c2a38d4d17e9342cc78e0e1b30722432", async() => {
                    WriteLiteral("\r\n                                ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
#nullable restore
#line 286 "D:\SourceCode\CSJ Rubber\Authentication\Views\Items\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = ViewBag.ItemCategoryList;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                            </div>\r\n                        ");
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
            WriteLiteral("\r\n                        \r\n                    </div>\r\n                    <div class=\"col-md-6 col-xl-5\">\r\n                       \r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9864a86aa6e769a626ae2617e23bb677b1d09c2a38d4d17e9342cc78e0e1b30725421", async() => {
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
            WriteLiteral("\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9864a86aa6e769a626ae2617e23bb677b1d09c2a38d4d17e9342cc78e0e1b30727126", async() => {
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "9864a86aa6e769a626ae2617e23bb677b1d09c2a38d4d17e9342cc78e0e1b30729646", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Authentication.Models.Item>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
