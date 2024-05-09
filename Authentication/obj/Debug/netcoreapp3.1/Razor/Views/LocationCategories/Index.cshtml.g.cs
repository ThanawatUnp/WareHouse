#pragma checksum "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\LocationCategories\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "98a807c791e00a1767251933b26e0c8b5aec242e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_LocationCategories_Index), @"mvc.1.0.view", @"/Views/LocationCategories/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"98a807c791e00a1767251933b26e0c8b5aec242e", @"/Views/LocationCategories/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"acdb2e1b339642545d0bc56e1deb0ca293ad13ea", @"/Views/_ViewImports.cshtml")]
    public class Views_LocationCategories_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Authentication.Models.LocationCategory>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_Btn_Group", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-inline frm-float-right"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("frm_txtOrderType"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("z-index: 10000 !important;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_ViewData", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\LocationCategories\Index.cshtml"
  
    ViewData["Title"] = "Location Category";
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
        $('#viewBody').load('/LocationCategoriesController/Index');
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
            url: '/LocationCategories/ViewContent',
            data: {
                //These two");
            WriteLiteral(@" keys should keep consistent with the parameters ( int? ProductId , int? ProductPrice ) in action, including uppercase and lowercase.
                locationcategory: $('#txtLocationCategory').val(),
                createby: $('#txtCreateBy').val(),
                screatedate: vCreateDate,
                startcreatedate: $('#dtCreateDate').data('daterangepicker').startDate.format('MM/DD/YYYY'),
                endcreatedate: $('#dtCreateDate').data('daterangepicker').endDate.format('MM/DD/YYYY'),
                editby: $('#txtEditBy').val(),
                seditdate: vEditeDate,
                starteditdate: $('#dtEditDate').data('daterangepicker').startDate.format('MM/DD/YYYY'),
                endeditdate: $('#dtEditDate').data('daterangepicker').endDate.format('MM/DD/YYYY'),
            },
            success: function (result) {
                //let locationcategory = $('#txtLocationCategory').val();
                //let createby = $('#txtCreateBy').val();
                //let star");
            WriteLiteral(@"tcreatedate = $('#dtCreateDate').data('daterangepicker').startDate.format('MM/DD/YYYY');
                //let endcreatedate = $('#dtCreateDate').data('daterangepicker').endDate.format('MM/DD/YYYY');
                //let editby = $('#txtEditBy').val();
                //let starteditdate = $('#dtEditDate').data('daterangepicker').startDate.format('MM/DD/YYYY');
                //let endeditdate = $('#dtEditDate').data('daterangepicker').endDate.format('MM/DD/YYYY');
                $('#childLayout').html(result);
                //$('#txtLocationCategory').val(locationcategory);
                //$('#txtCreateBy').val(createby);
                //if (vCreateDate === ""y"")
                //    $('#dtCreateDate').daterangepicker({ ""startDate"": String(startcreatedate), ""endDate"": String(endcreatedate) });
                //if (vEditeDate === ""y"")
                //    $('#dtEditDate').daterangepicker({ ""startDate"": String(starteditdate), ""endDate"": String(endeditdate) });
                //$('#txtEd");
            WriteLiteral(@"itBy').val(editby);
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
        $.ajax({
            url: '/LocationCategories/ViewContent',
            data: {
                clear: 'clear'
            },
            success: function (result) {
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
                canc");
            WriteLiteral(@"elLabel: 'Clear'
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

        $('#dtEditDate').on('apply.daterangepicker', function (ev, picker) {
            globalThis.vEditeDate = ""y"";
            $(this).val(picker.startDate.format('MM/DD/");
            WriteLiteral(@"YYYY') + ' - ' + picker.endDate.format('MM/DD/YYYY'));
        });

        $('#dtEditDate').on('cancel.daterangepicker', function (ev, picker) {
            globalThis.vEditeDate = ""n"";
            $(this).val('');
        });

        // Add Location Category
        $(document).on(""click"", ""#btNew"", function () {
            $.ajax({
                type: ""GET"",
                data: ""{}"",
                url: $(this).data('url'),
                success: function (result) {
                    $('#pop_up').html(result);
                    $('#pop_up').modal('show');
                },
                error: function (result) {
                    console.log(""error"");
                    alert('error');
                }
            });
            return false;
        });

        // Edit Location Category
        $(document).on(""click"", ""#ViewData table tbody tr td #edit-locationtype"", function () {
            $.ajax({
                type: ""GET"",
                data: """);
            WriteLiteral(@"{}"",
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

        // Detail Location Category
        $(document).on(""click"", ""#ViewData table tbody tr td #detail-locationtype"", function () {
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

        // Delete Location Category
        $(document).on(""click"", ");
            WriteLiteral(@"""#ViewData table tbody tr td #delete-locationtype"", function () {
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
        $(document).on(""click"",""#tool-panel div div div div a"",function () {
            var PerPage = $(this).attr('rel');
            $('#btn-perpage').text($(this).text());
            $.ajax({
                type: ""GET"",
                data: { ""PerPage"": PerPage } ,
                url: '");
#nullable restore
#line 212 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\LocationCategories\Index.cshtml"
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
#line 229 "D:\Backup ABSS\Enter User and Pass\Authentication\Authentication\Views\LocationCategories\Index.cshtml"
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "98a807c791e00a1767251933b26e0c8b5aec242e15647", async() => {
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
                    <div class=""col-md-6 col-xl-4"">
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "98a807c791e00a1767251933b26e0c8b5aec242e17100", async() => {
                WriteLiteral(@"
                            <div class=""form-group div-frm-group-search"">
                                <label class=""mx-3"" for=""txtLocationCategory""><b>Category Name</b></label>
                                <input class=""form-control txt-search-width-non"" id=""txtLocationCategory"" />
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "98a807c791e00a1767251933b26e0c8b5aec242e18967", async() => {
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
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"col-md-6 col-xl-4\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "98a807c791e00a1767251933b26e0c8b5aec242e20735", async() => {
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
            WriteLiteral("\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "98a807c791e00a1767251933b26e0c8b5aec242e22786", async() => {
                WriteLiteral(@"
                            <div class=""form-group div-frm-group-search"">
                                <label class=""mx-3"" for=""txtEditBy""><b>Edit By</b></label>
                                <input class=""form-control txt-search-width-non"" id=""txtEditBy"" />
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
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"col-md-6 col-xl-4\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "98a807c791e00a1767251933b26e0c8b5aec242e24548", async() => {
                WriteLiteral(@"
                            <div class=""form-group div-frm-group-search"">
                                <label class=""mx-3"" for=""dtEditDate""><b>Edit Date</b></label>
                                <input id=""dtEditDate"" name=""dtEditDate"" type='text' class=""form-control text-left txt-search-width-non dt-font"" style=""padding-right:2.5rem;"" placeholder=""mm/dd/yyyy-mm/dd/yyyy"" />
                                <div class=""arrow-datetime"" onclick=""$('#dtEditDate').data('daterangepicker').toggle();"">
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "98a807c791e00a1767251933b26e0c8b5aec242e27013", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Authentication.Models.LocationCategory>> Html { get; private set; }
    }
}
#pragma warning restore 1591
