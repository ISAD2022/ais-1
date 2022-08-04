#pragma checksum "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\departments.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6621b62119e2fc5acea0b80afde5bd56a0e842cf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Setup_departments), @"mvc.1.0.view", @"/Views/Setup/departments.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6621b62119e2fc5acea0b80afde5bd56a0e842cf", @"/Views/Setup/departments.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a83575d9a718d128afbe97793893afb3e648698d", @"/Views/_ViewImports.cshtml")]
    public class Views_Setup_departments : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
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
#line 1 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\departments.cshtml"
  
    ViewData["Title"] = "Departments";
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<script type=""text/javascript"">
    $(document).ready(function () {
        var g_deptId = 0;
        $('#sidebar_policy').hide();
        $(""#searchTableRecord"").on(""keyup"", function () {
            var value = $(this).val().toLowerCase();
            $(""#listOfDepartment tbody tr"").filter(function () {
                $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
            });
        });
    });

    function newDeptSetup() {
        g_deptId = 0;
        $('#setupDeptModal').modal('show');
        $('#deptCodeModalField').val('');
        $('#deptNameModalField').val('');
        $('#deptdivNameModalField').val('');
    }

    function setupDepartment(code, name, div_name, status, id, div_id) {
        g_deptId = id;
        $('#deptCodeModalField').val(code);
        $('#deptNameModalField').val(name);

        $('#deptdivNameModalField').val(div_id);
        if (status == ""Active"")
            $('#deptActiveModalField').click();
        else if (status");
            WriteLiteral(@" == ""InActive"")
            $('#deptInactiveModalField').click();

        $('#setupDeptModal').modal('show');
    }

    function publishDepartmentChanges() {

        var code = $('#deptCodeModalField').val();
        var name = $('#deptNameModalField').val();
        var div_id = $('#deptdivNameModalField').val();
        var div_name = $('#deptdivNameModalField option:selected').text();
        var status;
        var badge;
        if ($('#deptActiveModalField').is(':checked')) {
            status = 'Active';
            badge = 'badge-success ';
        }
        else {
            status = 'InActive';
            badge = 'badge-danger ';
        }
        if (g_deptId == 0)
            var row = ""<tr id=\""dept_"" + g_deptId + ""\""><td class=\""dept_code\""><p class=\""fw-normal mb-1\"">"" + code + ""</p></td><td class=\""dept_name\""><p class=\""fw-normal mb-1\"">"" + name + ""</p></td ><td class=\""dept_div\""><p class=\""fw-normal mb-1\"">"" + div_name + ""</p></td><td class=\""dept_status\""><span");
            WriteLiteral(@" class=\""badge "" + badge + "" rounded-pill d-inline\"">"" + status + ""</span></td><td class=\""dept_action\""><button type=\""button\"" class=\""btn btn-link text-danger btn-sm btn-rounded\"" onclick=\""setupDepartment('"" + code + ""','"" + name + ""','"" + div_name + ""','"" + status + ""','"" + g_deptId + ""','"" + div_id + ""');\"">Edit</button></td></tr>"";
        else
            $('#dept_' + g_deptId).html(""<td class=\""dept_code\""><p class=\""fw-normal mb-1\"">"" + code + ""</p></td><td class=\""dept_name\""><p class=\""fw-normal mb-1\"">"" + name + ""</p></td ><td class=\""dept_div\""><p class=\""fw-normal mb-1\"">"" + div_name + ""</p></td><td class=\""dept_status\""><span class=\""badge "" + badge + "" rounded-pill d-inline\"">"" + status + ""</span></td><td class=\""dept_action\""><button type=\""button\"" class=\""btn btn-link text-danger btn-sm btn-rounded\"" onclick=\""setupDepartment('"" + code + ""','"" + name + ""','"" + div_name + ""','"" + status + ""','"" + g_deptId + ""','"" + div_id + ""');\"">Edit</button></td>"");
        $('#listOfDepartment tbody'");
            WriteLiteral(@").append(row);
        $('#setupDeptModal').modal('hide');
        $.ajax({
            url: ""/Setup/department_add"",
            type: ""POST"",
            data: {
                'id': g_deptId,
                'code': code,
                'name': name,
                'div_id': div_id,
                'status': status
            },
            cache: false,
            success: function (data) {
                console.log(data);
                window.location = window.location.pathname;

            },
            dataType: ""json"",
        });
    }
</script>

<div class=""col-md-12"" style=""margin-top:20px;"">
    <h3>List of Departments</h3>
    <div class=""row"">
        <div class=""col-md-9"">
            <input class=""form-control"" id=""searchTableRecord"" type=""text"" placeholder=""Search.."">
        </div>
        <div class=""col-md-3"">
            <button onclick=""newDeptSetup();"" class=""btn btn-danger w-100"">Add New Department</button>
        </div>
    </div>
    <br>");
            WriteLiteral(@"
    <table id=""listOfDepartment"" class=""table align-middle mb-0 bg-white table-hover table-striped"">
        <thead class=""bg-light"">
            <tr>
                <th>Code</th>
                <th>Name</th>
                <th>Division Name</th>
                <th>Status</th>
                <th>Actions</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 105 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\departments.cshtml"
              
                if (ViewData["DepartmentList"] != null)
                {
                    foreach (var item in (dynamic)(ViewData["DepartmentList"]))
                    {


#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr");
            BeginWriteAttribute("id", " id=\"", 4771, "\"", 4789, 2);
            WriteAttributeValue("", 4776, "dept_", 4776, 5, true);
#nullable restore
#line 111 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\departments.cshtml"
WriteAttributeValue("", 4781, item.ID, 4781, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                            <td class=\"dept_code\">\r\n                                <p class=\"fw-normal mb-1\">");
#nullable restore
#line 113 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\departments.cshtml"
                                                     Write(item.CODE);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            </td>\r\n                            <td class=\"dept_name\">\r\n                                <p class=\"fw-normal mb-1\">");
#nullable restore
#line 116 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\departments.cshtml"
                                                     Write(item.NAME);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            </td>\r\n                            <td class=\"dept_div\">\r\n                                <p class=\"fw-normal mb-1\">");
#nullable restore
#line 119 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\departments.cshtml"
                                                     Write(item.DIV_NAME);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                <!--<p class=\"text-muted mb-0\">IT department</p>-->\r\n                            </td>\r\n\r\n                            <td class=\"dept_status\">\r\n");
#nullable restore
#line 124 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\departments.cshtml"
                                  
                                    if (item.STATUS == "Active")

                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral(" <span class=\"badge badge-success rounded-pill d-inline\">");
#nullable restore
#line 127 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\departments.cshtml"
                                                                                         Write(item.STATUS);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>");
#nullable restore
#line 127 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\departments.cshtml"
                                                                                                                 }
                                    else
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral(" <span class=\"badge badge-danger rounded-pill d-inline\">");
#nullable restore
#line 129 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\departments.cshtml"
                                                                                        Write(item.STATUS);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>");
#nullable restore
#line 129 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\departments.cshtml"
                                                                                                                }
                                

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </td>\r\n                            <td class=\"dept_action\">\r\n                                <button type=\"button\" class=\"btn btn-link text-danger btn-sm btn-rounded\"");
            BeginWriteAttribute("onclick", " onclick=\"", 6026, "\"", 6137, 13);
            WriteAttributeValue("", 6036, "setupDepartment(\'", 6036, 17, true);
#nullable restore
#line 133 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\departments.cshtml"
WriteAttributeValue("", 6053, item.CODE, 6053, 10, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 6063, "\',\'", 6063, 3, true);
#nullable restore
#line 133 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\departments.cshtml"
WriteAttributeValue("", 6066, item.NAME, 6066, 10, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 6076, "\',\'", 6076, 3, true);
#nullable restore
#line 133 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\departments.cshtml"
WriteAttributeValue("", 6079, item.DIV_NAME, 6079, 14, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 6093, "\',\'", 6093, 3, true);
#nullable restore
#line 133 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\departments.cshtml"
WriteAttributeValue("", 6096, item.STATUS, 6096, 12, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 6108, "\',\'", 6108, 3, true);
#nullable restore
#line 133 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\departments.cshtml"
WriteAttributeValue("", 6111, item.ID, 6111, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 6119, "\',\'", 6119, 3, true);
#nullable restore
#line 133 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\departments.cshtml"
WriteAttributeValue("", 6122, item.DIV_ID, 6122, 12, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 6134, "\');", 6134, 3, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                    Edit\r\n                                </button>\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 138 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\departments.cshtml"
                                        }
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        </tbody>
    </table>
</div>

<div id=""setupDeptModal"" class=""modal"" tabindex=""-1"" role=""dialog"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header bg-danger text-white"">
                <h5 class=""modal-title"">Department Setup</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6621b62119e2fc5acea0b80afde5bd56a0e842cf15355", async() => {
                WriteLiteral(@"
                    <div class=""form-group"">
                        <label for=""deptCodeModalField"">Code</label>
                        <input type=""text"" class=""form-control"" id=""deptCodeModalField"" aria-describedby=""brcode"" placeholder=""Department Code"">

                    </div>
                    <div class=""form-group"">
                        <label for=""deptNameModalField"">Name</label>
                        <input type=""text"" class=""form-control"" id=""deptNameModalField"" placeholder=""Department Name"">
                    </div>
                    <div class=""form-group"">
                        <label for=""deptdivNameModalField"">Division</label>
                        <select id=""deptdivNameModalField"" class=""form-select form-control"">
");
#nullable restore
#line 167 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\departments.cshtml"
                              
                                if (ViewData["DivisionList"] != null)
                                {
                                    foreach (var item in (dynamic)(ViewData["DivisionList"]))
                                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6621b62119e2fc5acea0b80afde5bd56a0e842cf16916", async() => {
#nullable restore
#line 172 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\departments.cshtml"
                                                                                          Write(item.NAME);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 172 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\departments.cshtml"
                                           WriteLiteral(item.DIVISIONID);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "id", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 172 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\departments.cshtml"
AddHtmlAttributeValue("", 8081, item.DIVISIONID, 8081, 16, false);

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
#line 173 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\departments.cshtml"
                                    }
                                }
                            

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                    </select>
                    </div>
                    <div class=""form-group"">
                        <label for=""branchAddressModalField"">Status</label>
                        <div class=""row col-md-12"">
                            <div class=""form-check form-check-inline"">
                                <input class=""form-check-input"" type=""radio"" name=""inlineRadioOptions"" id=""deptActiveModalField"" value=""option1"" />
                                <label class=""form-check-label"" for=""deptActiveModalField"">Active</label>
                            </div>

                            <div class=""form-check form-check-inline"">
                                <input class=""form-check-input"" type=""radio"" name=""inlineRadioOptions"" id=""deptInactiveModalField"" value=""option2"" />
                                <label class=""form-check-label"" for=""deptInactiveModalField"">Inactive</label>
                            </div>
                        </div>
   ");
                WriteLiteral("                 </div>\r\n\r\n\r\n                ");
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
                <button onclick=""publishDepartmentChanges();"" type=""button"" class=""btn btn-danger"">Save changes</button>
                <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Close</button>
            </div>
        </div>
    </div>
</div>

");
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
