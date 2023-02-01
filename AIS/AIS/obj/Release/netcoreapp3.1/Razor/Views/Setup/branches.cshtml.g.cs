#pragma checksum "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\branches.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c2da46af80c29ae117ba51f1dd608a35a1299945"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Setup_branches), @"mvc.1.0.view", @"/Views/Setup/branches.cshtml")]
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
#line 1 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\_ViewImports.cshtml"
using AIS;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\_ViewImports.cshtml"
using AIS.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c2da46af80c29ae117ba51f1dd608a35a1299945", @"/Views/Setup/branches.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a83575d9a718d128afbe97793893afb3e648698d", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Setup_branches : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "Low", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("Low"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "Medium", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("Medium"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "High", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("High"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\branches.cshtml"
  

    ViewData["Title"] = "Branch Setup";
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<script type=""text/javascript"">
    $(document).ready(function () {
        var g_branchId = 0;
        $(""#searchTableRecord"").on(""keyup"", function () {
            var value = $(this).val().toLowerCase();
            $(""#listOfBranches tbody tr"").filter(function () {
                $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
            });
        });
    });

    function newBranchSetup() {
        g_branchId = 0;
        $('#setupBranchModal').modal('show');
        $('#branchCodeModalField').val('');
        $('#branchNameModalField').val('');
        $('#branchZoneModalField').val('');
        $('#branchSizeModalField').val('');
        $('#branchRiskModalField').val('');
    }

    function setupBranch(code, name, zone, zoneId, size, sizeId,risk, status,brId ) {
        g_branchId = brId;
        $('#branchCodeModalField').val(code);
        $('#branchNameModalField').val(name);
        $('#branchZoneModalField').val(zoneId);
        $('#branchSizeMo");
            WriteLiteral(@"dalField').val(sizeId);
        $('#branchRiskModalField').val(risk);
        if (status == ""Active"")
            $('#branchActiveModalField').click();
        else if (status == ""InActive"")
            $('#branchInactiveModalField').click();

        $('#setupBranchModal').modal('show');
    }

    function publishBranchChanges() {

        var code = $('#branchCodeModalField').val();
        var name = $('#branchNameModalField').val();
        var zoneId = $('#branchZoneModalField').val();
        var zone_name = $('#branchZoneModalField option:selected').text();
        var sizeId = $('#branchSizeModalField').val();
        var size = $('#branchSizeModalField option:selected').text();
        var risk = $('#branchRiskModalField').val();
        var status;
        var badge;
        if ($('#branchActiveModalField').is(':checked')) {
            status = 'Active';
            badge = 'badge-success ';
        }
        else {
            status = 'InActive';
            badge = 'b");
            WriteLiteral(@"adge-danger ';
        }
        if (g_branchId == 0)
            var row = ""<tr id=\""div_"" + g_branchId + "" \""><td><p class=\""fw - normal mb - 1\"">"" + code + ""</p></td><td><p class=\""fw - normal mb - 1\"">"" + name + ""</p></td><td><p class=\""fw - normal mb - 1\"">"" + zone_name + ""</p></td><td><p class=\""fw - normal mb - 1\"">"" + size + ""</p></td><td><p class=\""fw - normal mb - 1\"">"" + risk + ""</p></td><td><span class=\""badge "" + badge + "" rounded - pill d - inline\"">"" + status + ""</span></td><td><button type=\""button\"" class=\""btn btn - link text - danger btn - sm btn - rounded\"" onclick=\""setupBranch('"" + code + ""', '"" + name + ""', '"" + zone_name + ""', '"" + zoneId + ""', '"" + size + ""', '"" + sizeId + ""', '"" + risk + ""', '"" + status + ""', '"" + g_branchId + ""'); \"" > Edit</button></td ></tr >"";
        else
            $('#div_' + g_branchId).html(""<td><p class=\""fw - normal mb - 1\"">"" + code + ""</p></td><td><p class=\""fw - normal mb - 1\"">"" + name + ""</p></td><td><p class=\""fw - normal mb - 1\"">"" + zone_name");
            WriteLiteral(@" + ""</p></td><td><p class=\""fw - normal mb - 1\"">"" + size + ""</p></td><td><p class=\""fw - normal mb - 1\"">"" + risk + ""</p></td><td><span class=\""badge "" + badge + "" rounded - pill d - inline\"">"" + status + ""</span></td><td><button type=\""button\"" class=\""btn btn - link text - danger btn - sm btn - rounded\"" onclick=\""setupBranch('"" + code + ""', '"" + name + ""', '"" + zone_name + ""', '"" + zoneId + ""', '"" + size + ""', '"" + sizeId + ""', '"" + risk + ""', '"" + status + ""', '"" + g_branchId + ""'); \"" > Edit</button></td >"");
        $('#listOfBranches tbody').append(row);
        $('#setupBranchModal').modal('hide');
        $.ajax({
            url: ""/Setup/branch_add"",
            type: ""POST"",
            data: {
                'BRANCHID': g_branchId,
                'BRANCHCODE': code,
                'BRANCHNAME': name,
                'ZONEID': zoneId,
                'BRANCH_SIZE_ID': sizeId,
                'BRANCH_SIZE': size,
                'ZONE_NAME': zone_name,
                'ISACTIVE': s");
            WriteLiteral(@"tatus
            },
            cache: false,
            success: function (data) {
                //console.log(data);
                window.location = window.location.pathname;

            },
            dataType: ""json"",
        });
    }
</script>

<div class=""col-md-12"" style=""margin-top:20px;"">
    <h3>List of Branches</h3>
    <div class=""row"">
        <div class=""col-md-10"">
            <input class=""form-control"" id=""searchTableRecord"" type=""text"" placeholder=""Search.."">
        </div>
        <div class=""col-md-2"">
            <button onclick=""newBranchSetup();"" class=""btn btn-danger w-100"">Add New</button>
        </div>
    </div>
    <br>
    <table id=""listOfBranches"" class=""table align-middle mb-0 bg-white table-hover table-striped"">
        <thead class=""bg-light"">
            <tr>
                <th>Branch Code</th>
                <th>Branch Name</th>
                <th>Zone Name</th>
                <th>Size</th>
                <th>Risk Ratting</th>
 ");
            WriteLiteral("               <th>Status</th>\r\n                <th>Actions</th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 117 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\branches.cshtml"
              
                if (ViewData["BranchList"] != null)
                {
                    foreach (var item in (dynamic)(ViewData["BranchList"]))
                    {


#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr");
            BeginWriteAttribute("id", " id=\"", 5532, "\"", 5555, 2);
            WriteAttributeValue("", 5537, "div_", 5537, 4, true);
#nullable restore
#line 123 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\branches.cshtml"
WriteAttributeValue("", 5541, item.BRANCHID, 5541, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                            <td>\r\n                                <p class=\"fw-normal mb-1\">");
#nullable restore
#line 125 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\branches.cshtml"
                                                     Write(item.BRANCHCODE);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            </td>\r\n                            <td>\r\n                                <p class=\"fw-normal mb-1\">");
#nullable restore
#line 128 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\branches.cshtml"
                                                     Write(item.BRANCHNAME);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            </td>\r\n                            <td>\r\n                                <p class=\"fw-normal mb-1\">");
#nullable restore
#line 131 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\branches.cshtml"
                                                     Write(item.ZONE_NAME);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            </td>\r\n                            <td>\r\n                                <p class=\"fw-normal mb-1\">");
#nullable restore
#line 134 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\branches.cshtml"
                                                     Write(item.BRANCH_SIZE);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            </td>\r\n                            <td>\r\n");
#nullable restore
#line 137 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\branches.cshtml"
                                  
                                    string risk = "Low";
                                    if (item.BRANCH_SIZE.Replace(@"\t|\n|\r", String.Empty)  == "Medium")
                                        risk = "Medium";
                                    else if (item.BRANCH_SIZE.Replace(@"\t|\n|\r", String.Empty) == "Large")
                                        risk = "High";
                                

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <p class=\"fw-normal mb-1\">");
#nullable restore
#line 144 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\branches.cshtml"
                                                     Write(risk);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            </td>\r\n                            <td class=\"dept_status\">\r\n");
#nullable restore
#line 147 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\branches.cshtml"
                                  
                                    if (item.ISACTIVE == "Active")

                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral(" <span class=\"badge badge-success rounded-pill d-inline\">");
#nullable restore
#line 150 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\branches.cshtml"
                                                                                         Write(item.ISACTIVE);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>");
#nullable restore
#line 150 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\branches.cshtml"
                                                                                                                   }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral(" <span class=\"badge badge-danger rounded-pill d-inline\">");
#nullable restore
#line 152 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\branches.cshtml"
                                                                                    Write(item.ISACTIVE);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>");
#nullable restore
#line 152 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\branches.cshtml"
                                                                                                              }
                                

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </td>\r\n                            <td>\r\n                                <button type=\"button\" class=\"btn btn-link text-danger btn-sm btn-rounded\"");
            BeginWriteAttribute("onclick", " onclick=\"", 7391, "\"", 7570, 19);
            WriteAttributeValue("", 7401, "setupBranch(\'", 7401, 13, true);
#nullable restore
#line 156 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\branches.cshtml"
WriteAttributeValue("", 7414, item.BRANCHCODE, 7414, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 7430, "\',\'", 7430, 3, true);
#nullable restore
#line 156 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\branches.cshtml"
WriteAttributeValue("", 7433, item.BRANCHNAME, 7433, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 7449, "\',\'", 7449, 3, true);
#nullable restore
#line 156 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\branches.cshtml"
WriteAttributeValue("", 7452, item.ZONE_NAME, 7452, 15, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 7467, "\',\'", 7467, 3, true);
#nullable restore
#line 156 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\branches.cshtml"
WriteAttributeValue("", 7470, item.ZONEID, 7470, 12, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 7482, "\',\'", 7482, 3, true);
#nullable restore
#line 156 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\branches.cshtml"
WriteAttributeValue("", 7485, item.BRANCH_SIZE, 7485, 17, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 7502, "\',\'", 7502, 3, true);
#nullable restore
#line 156 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\branches.cshtml"
WriteAttributeValue("", 7505, item.BRANCH_SIZE_ID, 7505, 20, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 7525, "\',\'", 7525, 3, true);
#nullable restore
#line 156 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\branches.cshtml"
WriteAttributeValue("", 7528, risk, 7528, 5, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 7533, "\',\'", 7533, 3, true);
#nullable restore
#line 156 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\branches.cshtml"
WriteAttributeValue("", 7536, item.ISACTIVE, 7536, 14, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 7550, "\',\'", 7550, 3, true);
#nullable restore
#line 156 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\branches.cshtml"
WriteAttributeValue("", 7553, item.BRANCHID, 7553, 14, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 7567, "\');", 7567, 3, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                    Edit\r\n                                </button>\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 161 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\branches.cshtml"
                    }
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        </tbody>
    </table>
</div>

<div id=""setupBranchModal"" class=""modal"" tabindex=""-1"" role=""dialog"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header bg-danger text-white"">
                <h5 class=""modal-title"">Branch Setup</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c2da46af80c29ae117ba51f1dd608a35a129994520115", async() => {
                WriteLiteral(@"
                    <div class=""form-group"">
                        <label for=""branchCodeModalField"">Branch Code</label>
                        <input type=""text"" class=""form-control"" id=""branchCodeModalField"" aria-describedby=""brcode"" placeholder=""Branch Code"">

                    </div>
                    <div class=""form-group"">
                        <label for=""branchNameModalField"">Branch Name</label>
                        <input type=""text"" class=""form-control"" id=""branchNameModalField"" placeholder=""Branch Name"">
                    </div>
                    <div class=""form-group"">
                        <label for=""branchZoneModalField"">Zone</label>
                        <select id=""branchZoneModalField"" class=""form-select form-control"">
");
#nullable restore
#line 190 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\branches.cshtml"
                              
                                if (ViewData["ZoneList"] != null)
                                {
                                    foreach (var item in (dynamic)(ViewData["ZoneList"]))
                                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c2da46af80c29ae117ba51f1dd608a35a129994521673", async() => {
#nullable restore
#line 195 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\branches.cshtml"
                                                                                  Write(item.ZONENAME);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 195 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\branches.cshtml"
                                           WriteLiteral(item.ZONEID);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "id", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 195 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\branches.cshtml"
AddHtmlAttributeValue("", 9468, item.ZONEID, 9468, 12, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 196 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\branches.cshtml"
                                    }
                                }
                            

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                        </select>
                    </div>
                    <div class=""form-group"">
                        <label for=""branchSizeModalField"">Zone</label>
                        <select id=""branchSizeModalField"" class=""form-select form-control"">
");
#nullable restore
#line 205 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\branches.cshtml"
                              
                                if (ViewData["BranchSizeList"] != null)
                                {
                                    foreach (var item in (dynamic)(ViewData["BranchSizeList"]))
                                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c2da46af80c29ae117ba51f1dd608a35a129994525087", async() => {
#nullable restore
#line 210 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\branches.cshtml"
                                                                                          Write(item.DESCRIPTION);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 210 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\branches.cshtml"
                                           WriteLiteral(item.BR_SIZE_ID);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "id", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 210 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\branches.cshtml"
AddHtmlAttributeValue("", 10241, item.BR_SIZE_ID, 10241, 16, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 211 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\branches.cshtml"
                                    }
                                }
                            

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                        </select>
                    </div>
                    <div class=""form-group"">
                        <label for=""branchRiskModalField"">Zone</label>
                        <select id=""branchRiskModalField"" class=""form-select form-control"">
                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c2da46af80c29ae117ba51f1dd608a35a129994528053", async() => {
                    WriteLiteral("Low");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c2da46af80c29ae117ba51f1dd608a35a129994529389", async() => {
                    WriteLiteral("Medium");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c2da46af80c29ae117ba51f1dd608a35a129994530728", async() => {
                    WriteLiteral("High");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                        </select>
                    </div>
                  
                    <div class=""form-group"">
                        <label for=""branchAddressModalField"">Status</label>
                        <div class=""row col-md-12"">
                            <div class=""form-check form-check-inline"">
                                <input class=""form-check-input"" type=""radio"" name=""inlineRadioOptions"" id=""branchActiveModalField"" value=""option1"" />
                                <label class=""form-check-label"" for=""branchActiveModalField"">Active</label>
                            </div>

                            <div class=""form-check form-check-inline"">
                                <input class=""form-check-input"" type=""radio"" name=""inlineRadioOptions"" id=""branchInactiveModalField"" value=""option2"" />
                                <label class=""form-check-label"" for=""branchInactiveModalField"">Inactive</label>
                            </div>
                   ");
                WriteLiteral("     </div>\r\n                    </div>\r\n\r\n\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            </div>
            <div class=""modal-footer"">
                <button onclick=""publishBranchChanges();"" type=""button"" class=""btn btn-danger"">Save changes</button>
                <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Close</button>
            </div>
        </div>
    </div>
</div>

");
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
