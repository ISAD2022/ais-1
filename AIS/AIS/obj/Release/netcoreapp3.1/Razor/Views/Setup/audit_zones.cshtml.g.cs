#pragma checksum "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\audit_zones.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "00db058868ae5aa3f7d727f7dc2c984074fae8b9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Setup_audit_zones), @"mvc.1.0.view", @"/Views/Setup/audit_zones.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"00db058868ae5aa3f7d727f7dc2c984074fae8b9", @"/Views/Setup/audit_zones.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a83575d9a718d128afbe97793893afb3e648698d", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Setup_audit_zones : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\audit_zones.cshtml"
  
    ViewData["Title"] = "AuditZone";
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<script type=""text/javascript"">
    $(document).ready(function () {
        var g_divId = 0;
        $('#sidebar_policy').hide();
        $(""#searchTableRecord"").on(""keyup"", function () {
            var value = $(this).val().toLowerCase();
            $(""#listOfAuditZone tbody tr"").filter(function () {
                $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
            });
        });
    });

    function newAZSetup() {
        g_divId = 0;
        $('#setupAZModal').modal('show');
        $('#AZCodeModalField').val('');
        $('#AZNameModalField').val('');
        $('#AZAddressModalField').val('');
    }

    function setupAuditZone(code, name, desc, status, id) {
        g_AZId = id;
        //console.log(code, name, desc, status, id);
        $('#AZCodeModalField').val(code);
        $('#AZNameModalField').val(name);
        $('#AZAddressModalField').val(desc);
        if (status == ""Active"")
            $('#AZActiveModalField').click();
        e");
            WriteLiteral(@"lse if (status == ""InActive"")
            $('#AZInactiveModalField').click();

        $('#setupAZModal').modal('show');
    }

    function publishAuditZoneChanges() {

        var code = $('#AZCodeModalField').val();
        var name = $('#AZNameModalField').val();
        var desc = $('#AZAddressModalField').val();
        var status;
        var badge;
        if ($('#AZActiveModalField').is(':checked')) {
            status = 'Active';
            badge = 'badge-success ';
        }
        else {
            status = 'InActive';
            badge = 'badge-danger ';
        }
        if (g_divId == 0)
            var row = ""<tr id=\""AZ_"" + g_AZId + ""\""><td class=\""AZ_code\""><p class=\""fw-normal mb-1\"">"" + code + ""</p></td><td class=\""AZ_name\""><p class=\""fw-normal mb-1\"">"" + name + ""</p></td ><td class=\""AZ_desc\""><p class=\""fw-normal mb-1\"">"" + desc + ""</p></td><td class=\""AZ_status\""><span class=\""badge "" + badge + "" rounded-pill d-inline\"">"" + status + ""</span></td><td class=\""AZ");
            WriteLiteral(@"_action\""><button type=\""button\"" class=\""btn btn-link text-danger btn-sm btn-rounded\"" onclick=\""setupAuditZone('"" + code + ""','"" + name + ""','"" + desc + ""','"" + status + ""','"" + g_AZId + ""');\"">Edit</button></td></tr>"";
        else
            $('#div_' + g_AZId).html(""<td class=\""AZ_code\""><p class=\""fw-normal mb-1\"">"" + code + ""</p></td><td class=\""AZ_name\""><p class=\""fw-normal mb-1\"">"" + name + ""</p></td ><td class=\""AZ_desc\""><p class=\""fw-normal mb-1\"">"" + desc + ""</p></td><td class=\""AZ_status\""><span class=\""badge "" + badge + "" rounded-pill d-inline\"">"" + status + ""</span></td><td class=\""AZ_action\""><button type=\""button\"" class=\""btn btn-link text-danger btn-sm btn-rounded\"" onclick=\""setupAuditZone('"" + code + ""','"" + name + ""','"" + desc + ""','"" + status + ""','"" + g_AZId + ""');\"">Edit</button></td>"");
        $('#listOfAuditZone tbody').append(row);
        $('#setupAZModal').modal('hide');
        $.ajax({
            url: ""/Setup/AuditZone_add"",
            type: ""POST"",
            da");
            WriteLiteral(@"ta: {
                'id': g_AZId,
                'code': code,
                'name': name,
                'description': desc,
                'status': status
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
    <h3>List of Audit Zones</h3>
    <div class=""row"">
        <div class=""col-md-10"">
            <input class=""form-control"" id=""searchTableRecord"" type=""text"" placeholder=""Search.."">
        </div>
        <div class=""col-md-2"">
            <button onclick=""newAZSetup();"" class=""btn btn-danger w-100"">Add New Audit Zone</button>
        </div>
    </div>
    <br>
    <table id=""listOfAuditZone"" class=""table align-middle mb-0 bg-white table-hover table-striped"">
        <thead class=""bg-light"">
            <tr>
       ");
            WriteLiteral("         <th>Code</th>\r\n                <th>Name</th>\r\n                <th>Description</th>\r\n                <th>Status</th>\r\n                <th>Actions</th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 105 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\audit_zones.cshtml"
              
                if (ViewData["AuditZoneList"] != null)
                {
                    foreach (var item in (dynamic)(ViewData["AuditZoneList"]))
                    {


#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr");
            BeginWriteAttribute("id", " id=\"", 4605, "\"", 4621, 2);
            WriteAttributeValue("", 4610, "AZ_", 4610, 3, true);
#nullable restore
#line 111 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\audit_zones.cshtml"
WriteAttributeValue("", 4613, item.ID, 4613, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                            <td class=\"AZ_code\">\r\n                                <p class=\"fw-normal mb-1\">");
#nullable restore
#line 113 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\audit_zones.cshtml"
                                                     Write(item.ZONECODE);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            </td>\r\n                            <td class=\"AZ_name\">\r\n                                <p class=\"fw-normal mb-1\">");
#nullable restore
#line 116 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\audit_zones.cshtml"
                                                     Write(item.ZONENAME);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                \r\n                            </td>\r\n                            <td class=\"AZ_desc\">\r\n                                <p class=\"fw-normal mb-1\">");
#nullable restore
#line 120 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\audit_zones.cshtml"
                                                     Write(item.DESCRIPTION);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            </td>\r\n\r\n                            <td class=\"AZ_status\">\r\n");
#nullable restore
#line 124 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\audit_zones.cshtml"
                                  
                                    if (item.ISACTIVE == "Y")

                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral(" <span class=\"badge badge-success rounded-pill d-inline\">");
#nullable restore
#line 127 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\audit_zones.cshtml"
                                                                                         Write(item.ISACTIVE);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>");
#nullable restore
#line 127 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\audit_zones.cshtml"
                                                                                                                   }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral(" <span class=\"badge badge-danger rounded-pill d-inline\">");
#nullable restore
#line 129 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\audit_zones.cshtml"
                                                                                    Write(item.STATUS);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>");
#nullable restore
#line 129 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\audit_zones.cshtml"
                                                                                                            }
                                

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </td>\r\n                            <td class=\"AZ_action\">\r\n                                <button type=\"button\" class=\"btn btn-link text-danger btn-sm btn-rounded\"");
            BeginWriteAttribute("onclick", " onclick=\"", 5800, "\"", 5908, 11);
            WriteAttributeValue("", 5810, "setupAuditZone(\'", 5810, 16, true);
#nullable restore
#line 133 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\audit_zones.cshtml"
WriteAttributeValue("", 5826, item.ZONECODE, 5826, 14, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5840, "\',\'", 5840, 3, true);
#nullable restore
#line 133 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\audit_zones.cshtml"
WriteAttributeValue("", 5843, item.ZONENAME, 5843, 14, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5857, "\',\'", 5857, 3, true);
#nullable restore
#line 133 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\audit_zones.cshtml"
WriteAttributeValue("", 5860, item.DESCRIPTION, 5860, 17, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5877, "\',\'", 5877, 3, true);
#nullable restore
#line 133 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\audit_zones.cshtml"
WriteAttributeValue("", 5880, item.ISACTIVE, 5880, 14, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5894, "\',\'", 5894, 3, true);
#nullable restore
#line 133 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\audit_zones.cshtml"
WriteAttributeValue("", 5897, item.ID, 5897, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5905, "\');", 5905, 3, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                    Edit\r\n                                </button>\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 138 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\Setup\audit_zones.cshtml"
                    }
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        </tbody>
    </table>
</div>

<div id=""setupAZModal"" class=""modal"" tabindex=""-1"" role=""dialog"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header bg-danger text-white"">
                <h5 class=""modal-title"">Audit Zone</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "00db058868ae5aa3f7d727f7dc2c984074fae8b914764", async() => {
                WriteLiteral(@"
                    <div class=""form-group"">
                        <label for=""branchCodeModalField"">Code</label>
                        <input type=""text"" class=""form-control"" id=""divCodeModalField"" aria-describedby=""brcode"" placeholder=""Division Code"">

                    </div>
                    <div class=""form-group"">
                        <label for=""AZNameModalField"">Name</label>
                        <input type=""text"" class=""form-control"" id=""AZNameModalField"" placeholder=""Audit Zone Name"">
                    </div>
                    <div class=""form-group"">
                        <label for=""AZAddressModalField"">Address</label>
                        <textarea rows=""3"" class=""form-control"" id=""divAddressModalField"" placeholder=""Division Address"" draggable=""false""></textarea>
                    </div>
                    <div class=""form-group"">
                        <label for=""AZAddressModalField"">Status</label>
                        <div class=""row col-md-12"">");
                WriteLiteral(@"
                            <div class=""form-check form-check-inline"">
                                <input class=""form-check-input"" type=""radio"" name=""inlineRadioOptions"" id=""divActiveModalField"" value=""option1"" />
                                <label class=""form-check-label"" for=""divActiveModalField"">Active</label>
                            </div>

                            <div class=""form-check form-check-inline"">
                                <input class=""form-check-input"" type=""radio"" name=""inlineRadioOptions"" id=""AZInactiveModalField"" value=""option2"" />
                                <label class=""form-check-label"" for=""divInactiveModalField"">Inactive</label>
                            </div>
                        </div>
                    </div>


                ");
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
                <button onclick=""publishAuditZoneChanges();"" type=""button"" class=""btn btn-danger"">Save changes</button>
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
