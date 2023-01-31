#pragma checksum "D:\Audit Inspection Sol\ais\AIS\AIS\Views\AdministrationPanel\groups.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2bfcdd6c900e089a196056edfa75805fe9954a6f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_AdministrationPanel_groups), @"mvc.1.0.view", @"/Views/AdministrationPanel/groups.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2bfcdd6c900e089a196056edfa75805fe9954a6f", @"/Views/AdministrationPanel/groups.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a83575d9a718d128afbe97793893afb3e648698d", @"/Views/_ViewImports.cshtml")]
    public class Views_AdministrationPanel_groups : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
#nullable restore
#line 1 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\AdministrationPanel\groups.cshtml"
  
    ViewData["Title"] = "Groups";
    Layout = "_Layout";


#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<script type=""text/javascript"">
    $(document).ready(function () {
        var g_groupId = 0;
        $(""#searchTableRecord"").on(""keyup"", function () {
            var value = $(this).val().toLowerCase();
            $(""#listOfGroups tbody tr"").filter(function () {
                $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
            });
        });
    });

    function newGroupSetup() {
        g_groupId = 0;
        $('#setupGroupModal').modal('show');
        $('#groupNameModalField').val('');
        $('#groupDescModalField').val('');
    }

    function setupGroup(name, description, active, grpId) {
        g_groupId = grpId;
        $('#groupNameModalField').val(name);
        $('#groupDescModalField').val(description);
       
        if (active == ""Y"")
            $('#groupActiveModalField').click();
        else 
            $('#groupInactiveModalField').click();

        $('#setupGroupModal').modal('show');
    }

    function publishGroupC");
            WriteLiteral(@"hanges() {

        var name = $('#groupNameModalField').val();
        var desc = $('#groupDescModalField').val();
        var status;
        var badge;
        if ($('#groupActiveModalField').is(':checked')) {
            status = 'Y';
            badge = 'badge-success ';
        }
        else {
            status = 'N';
            badge = 'badge-danger ';
        }
        $.ajax({
            url: ""/AdministrationPanel/group_add"",
            type: ""POST"",
            data: {
                'GROUP_ID': g_groupId,
                'GROUP_NAME': name,
                'GROUP_DESCRIPTION': desc,
                'ISACTIVE': status
            },
            cache: false,
            success: function (data) {
                $('#setupGroupModal').modal('hide');
                //console.log(data);
                window.location = window.location.pathname;

            },
            dataType: ""json"",
        });
    }
</script>

<div class=""col-md-12"" style=""margin-top:2");
            WriteLiteral(@"0px;"">
    <h3>List of Groups</h3>
    <div class=""row"">
        <div class=""col-md-10"">
            <input class=""form-control"" id=""searchTableRecord"" type=""text"" placeholder=""Search.."">
        </div>
        <div class=""col-md-2"">
            <button onclick=""newGroupSetup();"" class=""btn btn-danger w-100"">Add New</button>
        </div>
    </div>
    <br>
    <table id=""listOfGroups"" class=""table align-middle mb-0 bg-white table-hover table-striped"">
        <thead class=""bg-light"">
            <tr>
                <th>Group Name</th>
                <th>Group Description</th>
                <th>Status</th>
                <th>Action</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 95 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\AdministrationPanel\groups.cshtml"
              
                if (ViewData["GroupsList"] != null)
                {
                    foreach (var item in (dynamic)(ViewData["GroupsList"]))
                    {


#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr");
            BeginWriteAttribute("id", " id=\"", 3058, "\"", 3081, 2);
            WriteAttributeValue("", 3063, "div_", 3063, 4, true);
#nullable restore
#line 101 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\AdministrationPanel\groups.cshtml"
WriteAttributeValue("", 3067, item.GROUP_ID, 3067, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                            <td>\r\n                                <p class=\"fw-normal mb-1\">");
#nullable restore
#line 103 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\AdministrationPanel\groups.cshtml"
                                                     Write(item.GROUP_NAME);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            </td>\r\n                            <td>\r\n                                <p class=\"fw-normal mb-1\">");
#nullable restore
#line 106 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\AdministrationPanel\groups.cshtml"
                                                     Write(item.GROUP_DESCRIPTION);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            </td>\r\n                            <td class=\"dept_status\">\r\n");
#nullable restore
#line 109 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\AdministrationPanel\groups.cshtml"
                                  
                                    if (item.ISACTIVE == "Y")

                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral(" <span class=\"badge badge-success rounded-pill d-inline\">Active</span>");
#nullable restore
#line 112 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\AdministrationPanel\groups.cshtml"
                                                                                                           }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral(" <span class=\"badge badge-danger rounded-pill d-inline\">InActive</span>");
#nullable restore
#line 114 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\AdministrationPanel\groups.cshtml"
                                                                                                        }
                                

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </td>\r\n                            <td>\r\n                                <button type=\"button\" class=\"btn btn-link text-danger btn-sm btn-rounded\"");
            BeginWriteAttribute("onclick", " onclick=\"", 4009, "\"", 4110, 9);
            WriteAttributeValue("", 4019, "setupGroup(\'", 4019, 12, true);
#nullable restore
#line 118 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\AdministrationPanel\groups.cshtml"
WriteAttributeValue("", 4031, item.GROUP_NAME, 4031, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4047, "\',\'", 4047, 3, true);
#nullable restore
#line 118 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\AdministrationPanel\groups.cshtml"
WriteAttributeValue("", 4050, item.GROUP_DESCRIPTION, 4050, 23, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4073, "\',\'", 4073, 3, true);
#nullable restore
#line 118 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\AdministrationPanel\groups.cshtml"
WriteAttributeValue("", 4076, item.ISACTIVE, 4076, 14, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4090, "\',\'", 4090, 3, true);
#nullable restore
#line 118 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\AdministrationPanel\groups.cshtml"
WriteAttributeValue("", 4093, item.GROUP_ID, 4093, 14, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4107, "\');", 4107, 3, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                    Edit\r\n                                </button>\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 123 "D:\Audit Inspection Sol\ais\AIS\AIS\Views\AdministrationPanel\groups.cshtml"
                    }
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        </tbody>
    </table>
</div>

<div id=""setupGroupModal"" class=""modal"" tabindex=""-1"" role=""dialog"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header bg-danger text-white"">
                <h5 class=""modal-title"">Group Setup</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2bfcdd6c900e089a196056edfa75805fe9954a6f11787", async() => {
                WriteLiteral(@"
                    <div class=""form-group"">
                        <label for=""groupNameModalField"">Group Name</label>
                        <input type=""text"" class=""form-control"" id=""groupNameModalField"" aria-describedby=""brcode"" placeholder=""Group Name"">

                    </div>
                    <div class=""form-group"">
                        <label for=""groupDescModalField"">Group Description</label>
                        <textarea rows=""3""  class=""form-control"" id=""groupDescModalField"" placeholder=""Group Description""></textarea>
                    </div>
                    <div class=""form-group"">
                        <label for=""groupStatusModalField"">Status</label>
                        <div class=""row col-md-12"">
                            <div class=""form-check form-check-inline"">
                                <input class=""form-check-input"" type=""radio"" name=""inlineRadioOptions"" id=""groupActiveModalField"" value=""option1"" />
                                <label");
                WriteLiteral(@" class=""form-check-label"" for=""groupActiveModalField"">Active</label>
                            </div>

                            <div class=""form-check form-check-inline"">
                                <input class=""form-check-input"" type=""radio"" name=""inlineRadioOptions"" id=""groupInactiveModalField"" value=""option2"" />
                                <label class=""form-check-label"" for=""groupInactiveModalField"">Inactive</label>
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
                <button onclick=""publishGroupChanges();"" type=""button"" class=""btn btn-danger"">Save changes</button>
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
